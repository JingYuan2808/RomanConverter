using System;
using System.Collections;
using NUnit.Framework;
using RomanConvertWebApi.Utilities;

namespace RomanConvertWebApi.test
{
    public class RomanDigitalConverterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(typeof(RomanToDigitalPositiveCases))]
        public void RomanToDigitalTestSucceed(int digital, string roman)
        {
            Assert.AreEqual(digital, new RomanDigitalConverter().RomanToDigital(roman));
        }

        [TestCaseSource(typeof(RomanToDigitalNegativeCases))]
        public void RomanToDigitalTest_InputOutOfRange_RaiseException(string roman)
        {
            Assert.Throws<ArgumentOutOfRangeException>( ()=>new RomanDigitalConverter().RomanToDigital(roman));
        }

        [TestCaseSource(typeof(DigitalToRomanNegativeCases))]
        public void DigitalToRomanTest_InputOutOfRange_RaiseException(int digital)
        {
           Assert.Throws<ArgumentOutOfRangeException>( ()=>new RomanDigitalConverter().DigitalToRoman(digital));
        }

        [TestCaseSource(typeof(RomanToDigitalPositiveCases))]
        public void DigitalToRomanTestSucceed(int digital, string roman)
        {
            Assert.AreEqual(roman, new RomanDigitalConverter().DigitalToRoman(digital));
        }

        class RomanToDigitalPositiveCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { 0, "" };
                yield return new object[] { 1, "I" };
                yield return new object[] { 4, "IV" };
                yield return new object[] { 9, "IX" };
                yield return new object[] { 90, "XC" };
                yield return new object[] { 900, "CM" };
                yield return new object[] { 1903, "MCMIII" };
                yield return new object[] { 1997, "MCMXCVII" };
                yield return new object[] { 4000, "MMMM" };
            }
        }

        class DigitalToRomanNegativeCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return -1;
                yield return 4001;
            }
        }

        class RomanToDigitalNegativeCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return "XXXCCKK";
                yield return "Xxx";
            }
        }

    }
}

