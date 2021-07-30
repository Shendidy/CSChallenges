using NUnit.Framework;
using Challenges;

namespace RomanNumbers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(20, "XX")]
        [TestCase(40, "XL")]
        [TestCase(205, "CCV")]
        [TestCase(1975, "MCMLXXV")]

        public void RunShouldReturnRomanNumberWhenGivenAnInteger(int number, string expected)
        {
            var actual = Program.Run(number);

            Assert.AreEqual(expected, actual);
        }
    }
}