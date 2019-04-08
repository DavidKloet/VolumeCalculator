using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolumeCalculator;

namespace Tests
{
    [TestClass]
    public class DecimalValidatorShould
    {
        [TestMethod]
        public void DecimalValidator_IsValid_AllowsStringWithOnlyNumbers()
        {
            var input = "99";

            var result = DecimalValidator.IsValid(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DecimalValidator_IsValid_AllowsStringWithPeriod()
        {
            var input = "10.44";

            var result = DecimalValidator.IsValid(input);

            Assert.IsTrue(result);
        }
    }
}
