using Challenges;
using NUnit.Framework;

namespace EnglishClassroom.Tests
{
    public class EnglishClassroomUnitTests
    {
        [Test]
        public void EnglishToMorseShouldReturnCorrectCode()
        {
            var actual = Solution.EnglishToMorse("The wizard quickly jinxed the gnomes before they vaporized.");
            var expected = "- .... .     .-- .. --.. .- .-. -..     --.- ..- .. -.-. -.- .-.. -.--     .--- .. -. -..- . -..     - .... .     --. -. --- -- . ...     -... . ..-. --- .-. .     - .... . -.--     ...- .- .--. --- .-. .. --.. . -.. .-.-.-";
            
            Assert.AreEqual(expected, actual);
        }
    }
}