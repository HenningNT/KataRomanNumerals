using NUnit.Framework;
using src;

namespace test
{
    public class RomanNumeralsShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(3000 ,"MMM")]
        [TestCase(2000, "MM")]
        [TestCase(1000, "M")]

        public void ShouldReturnRomanGivenArabic(int input, string expected)
        {
            var numero = new RomanNumerals();

            var result = numero.Convert(input);

            Assert.AreEqual(expected, result);
        }
    }
}
