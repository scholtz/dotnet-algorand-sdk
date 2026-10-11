using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Algorand.AVM.ClientGenerator.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Text for a <c>///</c> XML doc comment. Every line break in a contract description starts a new
        /// comment line, otherwise the continuation would be emitted as code and break the generated client.
        /// </summary>
        public static string ToDocCommentText(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\n///");
        }

        public static string ToPascalCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var result = new StringBuilder();
            var nonWordChars = new Regex(@"[^a-zA-Z0-9]+");
            var tokens = nonWordChars.Split(s);
            foreach (var token in tokens)
            {
                result.Append(PascalCaseSingleWord(token));
            }

            return result.ToString();
        }

        static string PascalCaseSingleWord(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var match = Regex.Match(s, @"^(?<word>\d+|^[a-z]+|[A-Z]+|[A-Z][a-z]+|\d[a-z]+)+$");
            var groups = match.Groups["word"];

            var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            var result = new StringBuilder();
            foreach (var capture in groups.Captures.Cast<Capture>())
            {
                result.Append(textInfo.ToTitleCase(capture.Value.ToLower()));
            }
            return result.ToString();
        }
    }
}
