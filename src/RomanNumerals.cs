using System.Collections.Generic;
using System.Linq;

namespace src
{
    public class RomanNumerals
    {
        readonly Dictionary<int, string> Numbers = new()
        {
            { 1000, "M" },
            { 500, "D" },
            { 100, "C" },
            { 50, "L" },
            { 10, "X" },
            { 5, "V" },
            { 1, "I" }
        };

        readonly Dictionary<int, string> Specials = new()
        {
            { 900, "CM" },
            { 400, "CD" },
            { 90, "XC" },
            { 40, "XL" },
            { 9, "IX" },
            { 4, "IV" }
        };

        public string Convert(int input)
        {
            string result;

            // Have we reached the end?
            if (input == 0) return string.Empty;

            // Get current number in dictionary
            var currentRadix = Numbers.First(num => num.Key <= input).Key;

            // Check if it is a special case
            if (Specials.Any(special => input / special.Key == 1 && special.Key > currentRadix))
            {
                var SpecialCase = Specials.First(special => input / special.Key == 1 && special.Key > currentRadix);

                result = SpecialCase.Value;

                // Subtract the bit we have processed
                input -= SpecialCase.Key;
            }
            else
            {
                // Find number of occurrences
                var count = input / currentRadix;
                result = Numbers[currentRadix].Repeat(count);
                // Subtract the bit we have processed
                input -= currentRadix * count;
            }

            return result + Convert(input);
        }
    }

    public static class StringExtensions
    {
        public static string Repeat(this string me, int count)
        {
            return string.Concat(Enumerable.Repeat(me, count));
        }

    }

}