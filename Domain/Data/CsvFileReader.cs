using Domain.Common;
using Domain.Common.Exceptions;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public sealed class CsvFileReader : IReader
    {
        private readonly string _path;

        public CsvFileReader(string path)
        {
            if (path.IsValidPath()) throw new ArgumentException("Value must be valid path", nameof(path));

            _path = path;
        }

        public Task<Grid> ReadAsync()
        {
            var data = new List<List<DataPoint>>
            {
                new List<DataPoint>()
            };

            var fileContents = File.ReadAllText(_path);
            var columnCount = -1;

            using (var reader = new TextFieldParser(fileContents, Encoding.Default))
            {
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(";", ",");
                reader.HasFieldsEnclosedInQuotes = true;
                reader.TrimWhiteSpace = true;

                try
                {
                    while (!reader.EndOfData)
                    {
                        var fields = reader.ReadFields();

                        if (columnCount == -1) columnCount = fields.Length;

                        if (fields.Length != columnCount) throw new CsvReaderExcpeption($"Line {reader.LineNumber} has an invalid number of fields");

                        for (var index = 0; index < fields.Length; index++)
                        {
                            if (!decimal.TryParse(fields[index], out var value))
                            {
                                throw new CsvReaderExcpeption($"Cannot parse value in column {index} of row {reader.LineNumber}");
                            }

                            data[(int)reader.LineNumber].Add(new DataPoint(reader.LineNumber, index, value));
                        }

                        data.Add(new List<DataPoint>());
                    }
                }
                catch (MalformedLineException e)
                {
                    throw new CsvReaderExcpeption(e.Message);
                }
            }

            data.RemoveAt(data.Count - 1);

            return Task.FromResult(new Grid(data));
        }
    }
}
