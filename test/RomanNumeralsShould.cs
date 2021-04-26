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
        [TestCase(500, "D")]
        [TestCase(1500, "MD")]
        [TestCase(100, "C")]
        [TestCase(300, "CCC")]
        [TestCase(2800, "MMDCCC")]
        [TestCase(2200, "MMCC")]
        [TestCase(2777, "MMDCCLXXVII")]
        [TestCase(900, "CM")]

        public void ShouldReturnRomanGivenArabic(int input, string expected)
        {
            var numero = new RomanNumerals();

            var result = numero.Convert(input);

            Assert.AreEqual(expected, result);
        }
    }
}
