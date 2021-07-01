using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using RomanConvertWebApi;
using RomanConvertWebApi.Utilities;

namespace RomanConverterWebApi.test
{
    public class RomanDigitalServiceTest
    {
        private IRomanDigitalConverter _romanDigitalConverter;

        [SetUp]
        public void Setup()
        {
            _romanDigitalConverter = Substitute.For<IRomanDigitalConverter>();
        }

        [TestCase]        
        public void RomanToDigitalTestSucceed()
        {
            var input = "X";
            var output = 10;
            _romanDigitalConverter.RomanToDigital(input).Returns(output);
            Assert.AreEqual(output, new RomanConverterService(_romanDigitalConverter).RomanToDigital(input));
        }

        [TestCase]        
        public void DigitalToRomanTestSucceed()
        {
            var output = "X";
            var input = 10;
            _romanDigitalConverter.DigitalToRoman(input).Returns(output);
            Assert.AreEqual(output, new RomanConverterService(_romanDigitalConverter).DigitalToRoman(input));
        }

    }
}
