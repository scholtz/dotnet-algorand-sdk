using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorand.AVM.ClientGenerator.Extensions
{
    /// <summary>
    /// Thrown when an ARC32/ARC56 contract spec contains a name that cannot be safely emitted as C# source.
    /// </summary>
    public class SpecValidationException : Exception
    {
        public SpecValidationException(string message) : base(message) { }
    }

    /// <summary>
    /// The generator writes several spec-supplied names verbatim into generated C# (class, method and parameter
    /// identifiers, event signature literals, and the output file name). Specs are untrusted input, so every such
    /// name must be a plain identifier: anything else could break out of its position and become live code in the
    /// consumer's application, or steer the output path outside the output folder.
    /// </summary>
    public static class SpecValidator
    {
        // \z, not $: in .NET `$` also matches before a trailing '\n', which would let "name\n" through.
        private static readonly Regex Identifier = new Regex(@"\A[A-Za-z_][A-Za-z0-9_]{0,199}\z", RegexOptions.CultureInvariant);

        // Names Windows treats as devices whatever the extension ("CON.cs" opens the console, not a file).
        private static readonly Regex WindowsDeviceName = new Regex(@"\A(CON|PRN|AUX|NUL|COM[0-9]|LPT[0-9])\z", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        /// <summary>
        /// Throws unless <paramref name="name"/> is a plain ASCII identifier. Null/empty is rejected when
        /// <paramref name="allowEmpty"/> is false.
        /// </summary>
        public static void RequireIdentifier(string name, string what, bool allowEmpty = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                if (allowEmpty) return;
                throw new SpecValidationException($"The {what} is missing; it must be a plain identifier ([A-Za-z_][A-Za-z0-9_]*).");
            }
            if (!Identifier.IsMatch(name))
            {
                throw new SpecValidationException($"The {what} \"{Show(name)}\" is not a plain identifier ([A-Za-z_][A-Za-z0-9_]*) and cannot be used to generate code.");
            }
        }

        // ABI types ("uint64", "byte[4]", "(uint64,string)[]", "ufixed64x2") and struct names used as types. Some are
        // interpolated into string literals, and the text inside "[...]" is copied into generated code as an array
        // length expression, so brackets may only enclose digits; no quotes, dots, backslashes, braces or semicolons.
        private static readonly Regex AbiType = new Regex(@"\A(?:ref:)?(?:[A-Za-z0-9_(), ]|\[[0-9]*\]){1,10000}\z", RegexOptions.CultureInvariant);

        /// <summary>
        /// Throws unless <paramref name="type"/> only uses characters that occur in ABI type strings. Null/empty is
        /// accepted unless <paramref name="required"/> (a missing type is otherwise reported elsewhere, or means "none").
        /// </summary>
        public static void RequireAbiType(string type, string what, bool required = false)
        {
            if (string.IsNullOrEmpty(type))
            {
                if (required) throw new SpecValidationException($"The {what} is missing.");
                return;
            }
            if (!AbiType.IsMatch(type))
            {
                throw new SpecValidationException($"The {what} \"{Show(type)}\" is not a valid ABI type string and cannot be used to generate code.");
            }
            if (MaxParenthesisDepth(type) > MaxAbiTupleDepth)
            {
                throw new SpecValidationException($"The {what} \"{Show(type)}\" nests tuples deeper than {MaxAbiTupleDepth} levels and cannot be used to generate code.");
            }
        }

        /// <summary>
        /// The generator recurses once per tuple nesting level; an unbounded depth would overflow the stack, which
        /// cannot be caught and ends the process.
        /// </summary>
        public const int MaxAbiTupleDepth = 32;

        private static int MaxParenthesisDepth(string type)
        {
            int depth = 0, max = 0;
            foreach (var c in type)
            {
                if (c == '(') { depth++; if (depth > max) max = depth; }
                else if (c == ')' && depth > 0) depth--;
            }
            return max;
        }

        // C# type text written by the SDK's own spec generator (e.g. "List<ulong>", "ulong?", "Algorand.Address") and
        // emitted verbatim as a type in the generated client, so it must be exactly one well-formed type name.
        private static readonly Regex CSharpTypeChars = new Regex(@"\A[A-Za-z0-9_<>,.?:@\[\]() \t\r\n]{1,2000}\z", RegexOptions.CultureInvariant);

        private static readonly Regex EmptyRank = new Regex(@"\[[, ]*\]", RegexOptions.CultureInvariant);

        /// <summary>
        /// Throws unless <paramref name="value"/> parses, in full and without diagnostics, as a single C# type.
        /// Null/empty is accepted.
        /// </summary>
        public static void RequireCSharpType(string value, string what)
        {
            if (string.IsNullOrEmpty(value)) return;
            var ok = CSharpTypeChars.IsMatch(value);
            if (ok)
            {
                try
                {
                    var parsed = Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseTypeName(value);
                    ok = !parsed.ContainsDiagnostics && parsed.FullSpan.Length == value.Length;
                    // the parser accepts an expression as an array size ("int[Call()]"); only rank commas may sit in brackets
                    if (ok) ok = value.IndexOfAny(new[] { '[', ']' }) < 0 || EmptyRank.Replace(value, "").IndexOfAny(new[] { '[', ']' }) < 0;
                }
                catch (Exception)
                {
                    ok = false; // e.g. InsufficientExecutionStackException on pathologically nested input
                }
            }
            if (!ok)
            {
                throw new SpecValidationException($"The {what} \"{Show(value)}\" is not a plain C# type name and cannot be used to generate code.");
            }
        }

        private static readonly Regex Base64 = new Regex(@"\A[A-Za-z0-9+/=]*\z", RegexOptions.CultureInvariant);
        private static readonly Regex DottedName = new Regex(@"\A[A-Za-z_][A-Za-z0-9_]{0,199}(\.[A-Za-z_][A-Za-z0-9_]{0,199}){0,20}\z", RegexOptions.CultureInvariant);

        /// <summary>
        /// Throws unless <paramref name="value"/> is standard base64 text. Null/empty is accepted.
        /// </summary>
        public static void RequireBase64(string value, string what)
        {
            if (string.IsNullOrEmpty(value)) return;
            if (!Base64.IsMatch(value) || !Convert.TryFromBase64String(value, new byte[(value.Length / 4 + 1) * 3], out _))
            {
                throw new SpecValidationException($"The {what} is not base64 text (\"{Show(value)}\") and cannot be used to generate code.");
            }
        }

        /// <summary>
        /// Throws unless <paramref name="value"/> is a non-empty dotted C# namespace such as "My.Company.Clients". It is written
        /// verbatim into "namespace {value}" of the generated file.
        /// </summary>
        public static void RequireNamespace(string value, string what)
        {
            if (string.IsNullOrWhiteSpace(value) || !DottedName.IsMatch(value))
            {
                throw new SpecValidationException($"The {what} \"{Show(value)}\" is not a dotted identifier such as 'My.Company.Clients'.");
            }
        }

        /// <summary>
        /// Throws unless every byte is printable ASCII other than the quote and backslash, i.e. the bytes can be
        /// decoded and written inside a C# string literal without changing its meaning.
        /// </summary>
        public static void RequireLiteralSafeBytes(byte[] value, string what)
        {
            if (value == null) return;
            foreach (var b in value)
            {
                if (b < 0x20 || b > 0x7e || b == (byte)'"' || b == 0x5c)
                {
                    throw new SpecValidationException($"The {what} contains bytes that cannot be used to generate code.");
                }
            }
        }

        /// <summary>
        /// A contract name becomes a class name and the output file name, so on top of being an identifier it must
        /// not be a reserved Windows device name.
        /// </summary>
        public static void RequireContractName(string name)
        {
            RequireIdentifier(name, "contract name");
            if (WindowsDeviceName.IsMatch(name))
            {
                throw new SpecValidationException($"The contract name \"{name}\" is a reserved device name and cannot be used as an output file name.");
            }
        }

        // Short excerpt with every non-printable-ASCII character shown as \uXXXX, so a hostile value cannot forge log
        // lines or terminal output through the error message.
        public static string Show(string s)
        {
            if (s == null) return "(null)";
            var sb = new StringBuilder();
            foreach (var c in s.Take(40))
            {
                if (c >= 0x20 && c < 0x7f && c != '"' && c != '\\') sb.Append(c);
                else sb.Append("\\u").Append(((int)c).ToString("x4"));
            }
            if (s.Length > 40) sb.Append("...");
            return sb.ToString();
        }
    }
}
