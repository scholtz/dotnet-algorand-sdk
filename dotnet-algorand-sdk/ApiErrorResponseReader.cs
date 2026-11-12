using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorand
{
    /// <summary>The result of reading an error body: the typed object (null for an empty body) and the raw text.</summary>
    internal readonly struct ApiErrorBody<T>
    {
        internal ApiErrorBody(T obj, string text)
        {
            Object = obj;
            Text = text;
        }

        internal T Object { get; }

        internal string Text { get; }
    }

    /// <summary>
    /// Shared reader for the body of an error (non-200) HTTP response, used by the Algod and Indexer clients.
    ///
    /// Error responses do not always come from the Algorand daemon itself. A reverse proxy, WAF, API
    /// gateway or rate limiter in front of the node typically answers 401/403/429/502/503 with a plain
    /// text or HTML body ("Denied", "Too Many Requests", an HTML error page, ...) rather than the
    /// daemon's JSON <c>ErrorResponse</c>. Parsing such a body as JSON used to surface as a confusing
    /// "Could not deserialize the response body stream" exception with the body thrown away, hiding the
    /// real problem (the HTTP status). This reader always keeps the raw body, and reports an
    /// unparseable body as what it is.
    /// </summary>
    internal static class ApiErrorResponseReader
    {
        /// <summary>
        /// Upper bound on how much of an error body is read and kept. Daemon error documents are tiny; this
        /// only guards against an upstream that answers an error status with a huge or endless body (the
        /// clients send with ResponseHeadersRead, so nothing else bounds it). A longer body is truncated.
        /// </summary>
        internal const int MaxErrorBodyBytes = 64 * 1024;

        /// <summary>
        /// True when the response is an error response whose body should be read through
        /// <see cref="ReadAsync{T}"/>. This mirrors the generated callers, which treat exactly HTTP 200 as
        /// success and read every other status as an <c>ErrorResponse</c>.
        /// </summary>
        internal static bool ShouldHandle(HttpResponseMessage response)
        {
            return response != null && response.Content != null && (int)response.StatusCode != 200;
        }

        /// <summary>
        /// Reads (at most <see cref="MaxErrorBodyBytes"/> of) the error body and tries to deserialize it
        /// as <typeparamref name="T"/> - as msgpack when the response is labelled so, otherwise as JSON.
        /// </summary>
        /// <returns>The deserialized object (null for an empty body) and the raw body text.</returns>
        /// <exception cref="ApiException">
        /// The body is not a valid <typeparamref name="T"/>. The exception carries the HTTP status code and
        /// the raw body in <see cref="ApiException.Response"/>; the body is deliberately not embedded in
        /// the exception message (see <see cref="ApiException"/>).
        /// </exception>
        internal static async Task<ApiErrorBody<T>> ReadAsync<T>(
            HttpResponseMessage response,
            IReadOnlyDictionary<string, IEnumerable<string>> headers,
            Newtonsoft.Json.JsonSerializerSettings settings,
            CancellationToken cancellationToken)
        {
            var bytes = await ReadBodyAsync(response.Content, cancellationToken).ConfigureAwait(false);
            // Decoded as UTF-8 regardless of the declared charset: daemon errors are UTF-8 JSON, and an
            // unknown charset label from a proxy must not turn into an exception that hides the status.
            var responseText = Encoding.UTF8.GetString(bytes);
            var mediaType = response.Content.Headers?.ContentType?.MediaType;

            if (mediaType == "application/msgpack" && bytes.Length > 0)
            {
                try
                {
                    return new ApiErrorBody<T>(Algorand.Utils.Encoder.DecodeFromMsgPack<T>(bytes), responseText);
                }
                catch (Exception)
                {
                    // Not msgpack after all - fall through and try it as JSON before giving up.
                }
            }

            try
            {
                // A JsonTextReader (rather than JsonConvert.DeserializeObject) so that, as before, content
                // trailing the JSON document does not prevent a typed error from being returned.
                using (var stringReader = new StringReader(responseText))
                using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(stringReader))
                {
                    var serializer = Newtonsoft.Json.JsonSerializer.Create(settings);
                    return new ApiErrorBody<T>(serializer.Deserialize<T>(jsonTextReader), responseText);
                }
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                // Only the numeric status, its well-known name and the media type token go into the
                // message; the server-controlled reason phrase and body stay out of it.
                var message = "The server returned HTTP " + (int)response.StatusCode + " (" + response.StatusCode + ") with a body that could not be read as "
                    + typeof(T).Name + " (content type: " + (mediaType ?? "none") + "). This usually means the request was rejected by a proxy, "
                    + "gateway or rate limiter in front of the node rather than by the node itself.";
                throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
            }
        }

        private static async Task<byte[]> ReadBodyAsync(HttpContent content, CancellationToken cancellationToken)
        {
            using (var stream = await content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var buffer = new MemoryStream())
            {
                var chunk = new byte[8192];
                while (buffer.Length < MaxErrorBodyBytes)
                {
                    var wanted = (int)Math.Min(chunk.Length, MaxErrorBodyBytes - buffer.Length);
                    var read = await stream.ReadAsync(chunk, 0, wanted, cancellationToken).ConfigureAwait(false);
                    if (read <= 0)
                    {
                        break;
                    }
                    buffer.Write(chunk, 0, read);
                }
                return buffer.ToArray();
            }
        }
    }
}
