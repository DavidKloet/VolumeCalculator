using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StringExtensionsShould
    {
        [TestMethod]
        public void CsvFileReader_Ctor_ThrowsWithNull()
        {
            string path = null;

            var result = path.IsValidPath();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CsvFileReader_Ctor_ThrowsWithEmptyString()
        {
            var path = "";

            var result = path.IsValidPath();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CsvFileReader_Ctor_ThrowsWithWhitespace()
        {
            var path = "   ";

            var result = path.IsValidPath();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CsvFileReader_Ctor_ThrowsNonsensePath()
        {
            var path = "random string";

            var result = path.IsValidPath();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidPath_ReturnsTrueForValidPath()
        {
            var path = "Tests.dll";

            var result = path.IsValidPath();

            Assert.IsTrue(result);
        }
    }
}
