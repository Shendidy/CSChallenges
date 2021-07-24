using NUnit.Framework;

namespace FindTheSingleton.Tests
{
    public class FindTheSingleton
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 2, 5, 2, 3, 4, 4, 3 }, 5)]
        [TestCase(new int[] { 2, 4, 5, 4, 2, 5, 6, 8, 7, 7, 9, 8, 6 }, 9)]
        public void RunShouldReturnCorrectStudent(int[] students_list, int expected)
        {
            var actual = Challenges.Solution.Run(students_list);

            Assert.AreEqual(expected, actual);
        }
    }
}