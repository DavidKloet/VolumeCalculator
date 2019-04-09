using Domain.Calculator;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SimpleCalculationStrategyShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleCalculationStrategy_GetVolume_ThrowsWithInvalidGrid1()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint() } });
            var d = new NonNegativeDecimal(1);
            var calculator = new SimpleCalculationStrategy().GetVolume(null, grid, d, d, d);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleCalculationStrategy_GetVolume_ThrowsWithInvalidGrid2()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint() } });
            var d = new NonNegativeDecimal(1);
            var calculator = new SimpleCalculationStrategy().GetVolume(grid, null, d, d, d);
        }

        [TestMethod]
        public void SimpleCalculationStrategy_GetVolume_ReturnsValidOutput()
        {
            var d0 = new NonNegativeDecimal();
            var d1 = new NonNegativeDecimal(1);
            var baseGrid = new Grid(new List<DataPoint[]> { new[] { new DataPoint(1, 1, d1), new DataPoint(2, 1, d1) }, new[] { new DataPoint(1, 2, d1), new DataPoint(2, 2, d1) } });
            var topGrid = new Grid(new List<DataPoint[]> { new[] { new DataPoint(1, 1, d0), new DataPoint(2, 1, d0) }, new[] { new DataPoint(1, 2, d0), new DataPoint(2, 2, d0) } });

            var volume = new SimpleCalculationStrategy().GetVolume(baseGrid, topGrid, d1, d1, d1);

            Assert.AreEqual(1, volume);
        }

        [TestMethod]
        public void SimpleCalculationStrategy_GetVolume_TakesFluidContactIntoAccount()
        {
            var d0 = new NonNegativeDecimal();
            var d1 = new NonNegativeDecimal(1);
            var d2 = new NonNegativeDecimal(2);
            var baseGrid = new Grid(new List<DataPoint[]> { new[] { new DataPoint(1, 1, d2), new DataPoint(2, 1, d2) }, new[] { new DataPoint(1, 2, d2), new DataPoint(2, 2, d2) } });
            var topGrid = new Grid(new List<DataPoint[]> { new[] { new DataPoint(1, 1, d0), new DataPoint(2, 1, d0) }, new[] { new DataPoint(1, 2, d0), new DataPoint(2, 2, d0) } });

            var volume = new SimpleCalculationStrategy().GetVolume(baseGrid, topGrid, d1, d1, d1);

            Assert.AreEqual(1, volume);
        }
    }
}
