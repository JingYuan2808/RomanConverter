using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanConvertWebApi.Utilities
{
    public class RomanDigitalConverter:IRomanDigitalConverter
    {
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public int RomanToDigital(string roman)
        {
            if(roman.Any(x=>!RomanMap.ContainsKey(x)))
            {
                throw new ArgumentOutOfRangeException("Insert only Roman character (IVXLCDM)");
            }

            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }

            return number;
        }


        public string DigitalToRoman(int number)
        {
            if ((number < 0) || (number > 4000))
                throw new ArgumentOutOfRangeException("Insert value between 1 and 4000");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + DigitalToRoman(number - 1000);
            if (number >= 900) return "CM" + DigitalToRoman(number - 900);
            if (number >= 500) return "D" + DigitalToRoman(number - 500);
            if (number >= 400) return "CD" + DigitalToRoman(number - 400);
            if (number >= 100) return "C" + DigitalToRoman(number - 100);
            if (number >= 90) return "XC" + DigitalToRoman(number - 90);
            if (number >= 50) return "L" + DigitalToRoman(number - 50);
            if (number >= 40) return "XL" + DigitalToRoman(number - 40);
            if (number >= 10) return "X" + DigitalToRoman(number - 10);
            if (number >= 9) return "IX" + DigitalToRoman(number - 9);
            if (number >= 5) return "V" + DigitalToRoman(number - 5);
            if (number >= 4) return "IV" + DigitalToRoman(number - 4);
            if (number >= 1) return "I" + DigitalToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
