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
            if (Numbers.ContainsKey(input))
                return Numbers[input];

            return Converter(input, 0);
        }

        private string Converter(int input, int index)
        {
            if (input == 0) return string.Empty;

            // Have we reached the end on the dictionary?
            if (index >= Numbers.Count) return string.Empty;

            string result;

            var currentRadix = Numbers.Keys.ToArray()[index];

            // Find number of occurrences
            var count = input / currentRadix;
            if (Specials.Any(special => input % special.Key == 0 && input / special.Key == 1))
            {
                result = Specials.First(special => input % special.Key == 0).Value;
                input -= Specials.First(special => input % special.Key == 0).Key;
            }
            else
            {
                result = Numbers[currentRadix].Repeat(count);
                // Subtract the bit we have processed
                input -= currentRadix * count;
            }

            return result + Converter(input, index + 1);
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