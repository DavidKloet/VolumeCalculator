using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class GridShould
    {
        [TestMethod]
        public async Task Grid_Enumeration_ReturnsAllSegments()
        {
            var csvFileReader = new CsvFileReader(@"TestData\TopHorizonInFeet.csv");

            var grid = await csvFileReader.ReadAsync();

            Assert.AreEqual(375, grid.Count());
        }
    }
}
