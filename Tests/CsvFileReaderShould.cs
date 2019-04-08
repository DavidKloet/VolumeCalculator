using Domain.Common.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Data;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class CsvFileReaderShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CsvFileReader_Ctor_ThrowsInvalidPath()
        {
            var csvFileReader = new CsvFileReader("Non-existing path");

            Assert.Fail("A non-existing path should have thrown an error");
        }

        [TestMethod]
        public async Task CsvFileReader_ReadAsync_ReturnsGridFromValidFile()
        {
            var csvFileReader = new CsvFileReader(@"TestData\TopHorizonInFeet.csv");

            var grid = await csvFileReader.ReadAsync();

            Assert.IsNotNull(grid);
        }

        [TestMethod]
        [ExpectedException(typeof(ReaderException))]
        public async Task CsvFileReader_ReadAsync_ReturnsErrorFromMissingColumn()
        {
            var csvFileReader = new CsvFileReader(@"TestData\TopHorizonInFeet - invalid column.csv");

            var grid = await csvFileReader.ReadAsync();

            Assert.Fail("Reading with irregular column count should have thrown an error");
        }

        [TestMethod]
        [ExpectedException(typeof(ReaderException))]
        public async Task CsvFileReader_ReadAsync_ReturnsErrorFromInvalidValue()
        {
            var csvFileReader = new CsvFileReader(@"TestData\TopHorizonInFeet - invalid value.csv");

            var grid = await csvFileReader.ReadAsync();

            Assert.Fail("Parsing a non-numeric value should have thrown an error");
        }
    }
}
