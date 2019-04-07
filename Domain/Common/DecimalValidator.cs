using System.Text.RegularExpressions;

namespace Domain.Common
{
    public static class DecimalValidator
    {
        private static readonly Regex DecimalFormatMatcher = new Regex("^[0-9]*\\.?[0-9]*$", RegexOptions.Compiled);

        public static bool IsValid(string input)
        {
            if (input == null) return false;

            return DecimalFormatMatcher.IsMatch(input);
        }
    }
}
