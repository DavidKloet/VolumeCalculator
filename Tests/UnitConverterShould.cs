using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitConverterShould
    {
        [TestMethod]
        public void UnitConverter_FeetToMeter_ReturnsExpectedConversion()
        {
            var feet = 100;
            var expected = 100m * 0.3048m;

            var result = UnitConverter.FeetToMeter(feet);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UnitConverter_MeterToFeet_ReturnsExpectedConversion()
        {
            var meter = 100;
            var expected = 100m / 0.3048m;

            var result = UnitConverter.MeterToFeet(meter);

            Assert.AreEqual(expected, result);
        }
    }
}
