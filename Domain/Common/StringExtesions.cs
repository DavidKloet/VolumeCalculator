using System;
using System.IO;

namespace Domain.Common
{
    public static class StringExtensions
    {
        public static bool IsValidPath(this string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1) return false;

            try
            {
                var info = new FileInfo(path);

                return info.Exists;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
