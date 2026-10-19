using System;
using System.Collections.Generic;
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
        private static readonly Regex Identifier = new Regex("^[A-Za-z_][A-Za-z0-9_]{0,199}$", RegexOptions.CultureInvariant);

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
                // do not echo the offending value verbatim into logs beyond a short, escaped excerpt
                var shown = name.Length > 40 ? name.Substring(0, 40) + "..." : name;
                throw new SpecValidationException($"The {what} '{System.Text.RegularExpressions.Regex.Escape(shown)}' is not a plain identifier ([A-Za-z_][A-Za-z0-9_]*) and cannot be used to generate code.");
            }
        }

        public static void RequireIdentifiers(IEnumerable<string> names, string what, bool allowEmpty = false)
        {
            if (names == null) return;
            foreach (var n in names) RequireIdentifier(n, what, allowEmpty);
        }
    }
}
