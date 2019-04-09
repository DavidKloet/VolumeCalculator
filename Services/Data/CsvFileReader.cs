using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Data;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    /// <inheritdoc />
    /// <summary>
    /// Returns a reader that can read delimited data
    /// The delimiter mist be a semicolon
    /// </summary>
    internal sealed class CsvFileReader : IReader
    {
        private readonly string _path;

        public CsvFileReader(string path)
        {
            if (!path.IsValidPath()) throw new ArgumentException("Value must be valid path", nameof(path));

            _path = path;
        }

        public Task<Grid> ReadAsync()
        {
            var data = new List<DataPoint[]>();
            var columnCount = -1;

            using (var reader = new TextFieldParser(_path, Encoding.Default))
            {
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(";");
                reader.HasFieldsEnclosedInQuotes = true;
                reader.TrimWhiteSpace = true;

                try
                {
                    while (!reader.EndOfData)
                    {
                        var lineNumber = (int)reader.LineNumber;
                        var fields = reader.ReadFields();

                        if (columnCount == -1) columnCount = fields.Length;

                        if (fields.Length != columnCount) throw new ReaderException($"Line {lineNumber} has an invalid number of fields");

                        data.Add(new DataPoint[columnCount]);

                        for (var index = 0; index < fields.Length; index++)
                        {
                            if (!NonNegativeDecimal.TryParse(fields[index], out var value))
                            {
                                throw new ReaderException($"Cannot parse value in column {index} of row {lineNumber}");
                            }

                            data[lineNumber - 1][index] = new DataPoint(lineNumber, index, value);
                        }
                    }
                }
                catch (MalformedLineException e)
                {
                    throw new ReaderException("A line could not be parsed", e);
                }
            }

            return Task.FromResult(new Grid(data));
        }
    }
}
