namespace RomanConvertWebApi.Utilities
{
    public interface IRomanDigitalConverter
    {
        public int RomanToDigital(string roman);
        public string DigitalToRoman(int number);
    }
}
