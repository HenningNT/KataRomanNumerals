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
        [TestCase(400, "CD")]
        [TestCase(90, "XC")]
        [TestCase(40, "XL")]
        [TestCase(9, "IX")]
        [TestCase(4, "IV")]
        [TestCase(999, "CMXCIX")]
        [TestCase(3999, "MMMCMXCIX")]
        [TestCase(949, "CMXLIX")] 

        public void ReturnRomanGivenArabic(int input, string expected)
        {
            var numero = new RomanNumerals();

            var result = numero.Convert(input);

            Assert.AreEqual(expected, result);
        }
    }
}

