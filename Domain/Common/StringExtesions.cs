using System.Text.RegularExpressions;

namespace Domain.Common
{
    public static class StringExtensions
    {
        public static bool IsValidPath(this string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            if (Regex.IsMatch(path, @"^(\S.*)(\.[A-Za-z]+)$")) return false;

            return path.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1;
        }
    }
}
