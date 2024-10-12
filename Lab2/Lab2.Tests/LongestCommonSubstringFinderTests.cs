using NUnit.Framework;

namespace Lab2.Tests
{
    [TestFixture]
    public class LongestCommonSubstringFinderTests
    {
        [Test]
        public void FindLongestCommonSubstring_BothStringsHaveCommonSubstring_ReturnsCorrectSubstrings()
        {
            // Arrange
            string xi = "abcdef";
            string eta = "zbcdf";

            // Act
            var result = LongestCommonSubstringFinder.FindLongestCommonSubstring(xi, eta);
            Console.WriteLine("Result: " + result);

            // Assert
            Assert.That(result.alpha, Is.EqualTo("bcd"));
            Assert.That(result.beta, Is.EqualTo("bcd"));
        }

        [Test]
        public void FindLongestCommonSubstring_NoCommonSubstring_ReturnsEmptySubstrings()
        {
            // Arrange
            string xi = "abc";
            string eta = "xyz";

            // Act
            var result = LongestCommonSubstringFinder.FindLongestCommonSubstring(xi, eta);
            Console.WriteLine("Result: " + result);

            // Assert
            Assert.That(result.alpha, Is.EqualTo(string.Empty));
            Assert.That(result.beta, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FindLongestCommonSubstring_OneStringEmpty_ReturnsEmptySubstrings()
        {
            // Arrange
            string xi = "";
            string eta = "abc";

            // Act
            var result = LongestCommonSubstringFinder.FindLongestCommonSubstring(xi, eta);
            Console.WriteLine("Result: " + result);

            // Assert
            Assert.That(result.alpha, Is.EqualTo(string.Empty));
            Assert.That(result.beta, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FindLongestCommonSubstring_StringsAreIdentical_ReturnsFullStrings()
        {
            // Arrange
            string xi = "abcdef";
            string eta = "abcdef";

            // Act
            var result = LongestCommonSubstringFinder.FindLongestCommonSubstring(xi, eta);
            Console.WriteLine("Result: " + result);

            // Assert
            Assert.That(result.alpha, Is.EqualTo("abcdef"));
            Assert.That(result.beta, Is.EqualTo("abcdef"));
        }

        [Test]
        public void FindLongestCommonSubstring_PartialCommonSubstringAtEnd_ReturnsCorrectSubstring()
        {
            // Arrange
            string xi = "xyzabc";
            string eta = "defabc";

            // Act
            var result = LongestCommonSubstringFinder.FindLongestCommonSubstring(xi, eta);
            Console.WriteLine("Result: " + result);

            // Assert
            Assert.That(result.alpha, Is.EqualTo("abc"));
            Assert.That(result.beta, Is.EqualTo("abc"));
        }
    }
}
