using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanConvertWebApi
{
    public interface IRomanConverterService
    {
        int RomanToDigital(string roman);
        string DigitalToRoman(int digital);
    }
}
