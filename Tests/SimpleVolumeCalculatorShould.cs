using Domain.Calculator;
using Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SimpleVolumeCalculatorShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleVolumeCalculator_Ctor_ThrowsWithInvalidGrid1()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint() } });
            var calculator = new SimpleVolumeCalculator(null, grid, 1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleVolumeCalculator_Ctor_ThrowsWithInvalidGrid2()
        {
            var grid = new Grid(new List<DataPoint[]> { new[] { new DataPoint() } });
            var calculator = new SimpleVolumeCalculator(grid, null, 1, 1, 1);
        }
    }
}
