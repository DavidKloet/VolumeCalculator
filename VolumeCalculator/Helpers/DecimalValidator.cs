using System.Text.RegularExpressions;

namespace VolumeCalculator.Helpers
{
    /// <summary>
    /// Validates if a given string can be converted to a <see cref="decimal"/>
    /// </summary>
    public static class DecimalValidator
    {
        private static readonly Regex DecimalFormatMatcher = new Regex("^[0-9]*\\.?[0-9]*$", RegexOptions.Compiled);

        /// <summary>
        /// Return true when the given string can be converted to a <see cref="decimal"/>
        /// </summary>
        public static bool IsValid(string input)
        {
            if (input == null) return false;

            return DecimalFormatMatcher.IsMatch(input);
        }
    }
}
