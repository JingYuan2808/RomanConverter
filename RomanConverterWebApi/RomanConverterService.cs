using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RomanConvertWebApi.Utilities;

namespace RomanConvertWebApi
{
    public class RomanConverterService: IRomanConverterService
    {
        private readonly IRomanDigitalConverter _romanDigitalConverter;
        public RomanConverterService(IRomanDigitalConverter romanDigitalConverter)
        {
            _romanDigitalConverter = romanDigitalConverter;
        }

        public int RomanToDigital(string roman)
        {
            return _romanDigitalConverter.RomanToDigital(roman);
        }

        public string DigitalToRoman(int digital)
        {
            return _romanDigitalConverter.DigitalToRoman(digital);
        }

    }
}
