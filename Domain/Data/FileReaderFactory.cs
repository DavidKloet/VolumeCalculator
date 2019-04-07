using Domain.Common;
using System;
using System.IO;

namespace Domain.Data
{
    public class FileReaderFactory
    {
        public IReader GetFileReader(string path)
        {
            if (path.IsValidPath()) throw new ArgumentException("Value must be valid path", nameof(path));

            var info = new FileInfo(path);

            switch (info.Extension)
            {
                case "csv":
                case "txt":
                    return new CsvFileReader(path);
                default:
                    throw new NotImplementedException($"Unsupported file type ({info.Extension})");
            }
        }
    }
}
