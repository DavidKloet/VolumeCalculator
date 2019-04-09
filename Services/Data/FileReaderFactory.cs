using Domain.Common;
using Domain.Data;
using System;
using System.IO;

namespace Services.Data
{
    /// <summary>
    /// Creates file readers
    /// </summary>
    public class FileReaderFactory
    {
        /// <summary>
        /// Returns the appropriate reader for a file type
        /// Currently only .csv/.txt files are supported 
        /// </summary>
        public IReader GetFileReader(string path)
        {
            if (!path.IsValidPath()) throw new ArgumentException("Value must be valid path", nameof(path));

            var info = new FileInfo(path);

            switch (info.Extension)
            {
                case ".csv":
                case ".txt":
                    return new CsvFileReader(path);
                default:
                    throw new NotImplementedException($"Unsupported file type ({info.Extension})");
            }
        }
    }
}
