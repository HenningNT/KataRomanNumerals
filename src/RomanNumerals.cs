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

        public string Convert(int input)
        {
            if (Numbers.ContainsKey(input))
                return Numbers[input];

            return Converter(input, 0);
        }

        private string Converter(int input, int index)
        {
            if (index >= Numbers.Count) return string.Empty;

            var count = input / Numbers.Keys.ToArray()[index];
            var result = Numbers[Numbers.Keys.ToArray()[index]].Repeat(count);

            input = input - Numbers.Keys.ToArray()[index] * count;

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