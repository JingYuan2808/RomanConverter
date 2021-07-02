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
            if (number < 1 || number > 4000)
                throw new ArgumentOutOfRangeException("Insert value between 1 and 4000");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + (number == 1000?string.Empty:DigitalToRoman(number - 1000));
            if (number >= 900) return "CM" + (number == 900?string.Empty:DigitalToRoman(number - 900));
            if (number >= 500) return "D" + (number == 500?string.Empty:DigitalToRoman(number - 500));
            if (number >= 400) return "CD" + (number == 400?string.Empty:DigitalToRoman(number - 400));
            if (number >= 100) return "C" + (number == 100?string.Empty:DigitalToRoman(number - 100));
            if (number >= 90) return "XC" + (number == 90?string.Empty:DigitalToRoman(number - 90));
            if (number >= 50) return "L" + (number == 50?string.Empty:DigitalToRoman(number - 50));
            if (number >= 40) return "XL" + (number == 40?string.Empty:DigitalToRoman(number - 40));
            if (number >= 10) return "X" + (number == 10?string.Empty:DigitalToRoman(number - 10));
            if (number >= 9) return "IX" + (number == 9?string.Empty:DigitalToRoman(number - 9));
            if (number >= 5) return "V" + (number == 5?string.Empty:DigitalToRoman(number - 5));
            if (number >= 4) return "IV" + (number == 4?string.Empty:DigitalToRoman(number - 4));
            if (number >= 1) return "I" + (number == 1?string.Empty:DigitalToRoman(number - 1));
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
