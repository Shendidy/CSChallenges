using NUnit.Framework;

namespace WeLoveMathematics.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(100000001, false)]
        [TestCase(0, false)]
        [TestCase(-14, false)]
        public void RunShouldReturnFalseIfNumberIsOutOfRange(int number, bool expected)
        {
            var actual = Solution.Run(number);
            Assert.AreEqual(expected,actual);
        }

        [Test]
        [TestCase(14, true)]
        [TestCase(25, true)]
        [TestCase(26, true)]
        [TestCase(34, true)]
        [TestCase(55, true)]
        [TestCase(86, true)]
        public void RunShouldReturnTrueIfNumberIsSemiPrime(int number, bool expected)
        {
            var actual = Solution.Run(number);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(5, false)]
        [TestCase(23, false)]
        [TestCase(37, false)]
        [TestCase(56, false)]
        [TestCase(80, false)]
        [TestCase(98, false)]
        public void RunShouldReturnFalseIfNumberIsNotSemiPrime(int number, bool expected)
        {
            var actual = Solution.Run(number);
            Assert.AreEqual(expected, actual);
        }
    }
}