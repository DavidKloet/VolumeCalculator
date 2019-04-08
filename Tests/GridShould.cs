using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class GridShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Grid_Ctor_ThrowsWithTooFewRows()
        {
            var grid = new Grid(null);

            Assert.Fail("Invalid construction should have thrown an exception");
        }

        [TestMethod]
        public void Grid_Ctor_DoesNotThrowWithValidData()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint() } });

            Assert.IsNotNull(grid);
        }

        [TestMethod]
        public void Grid_Enumeration_ReturnsNoElementsWithFewerThanFourPoints()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint() } });

            Assert.AreEqual(0, grid.Count());
        }

        [TestMethod]
        public void Grid_Enumeration_ReturnsOneElementWithFourPoints()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint(), new DataPoint() }, new[] { new DataPoint(), new DataPoint() } });

            Assert.AreEqual(1, grid.Count());
        }

        [TestMethod]
        public async Task Grid_Enumeration_ReturnsAllSegments()
        {
            var csvFileReader = new CsvFileReader(@"TestData\TopHorizonInFeet.csv");

            var grid = await csvFileReader.ReadAsync();

            Assert.AreEqual(375, grid.Count());
        }
    }
}
