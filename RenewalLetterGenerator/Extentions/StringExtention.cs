namespace RenewalLetterGenerator.Extentions
{
    public static class StringExtention
    {
        public static bool IsDouble(this string value)
        {
            if (double.TryParse(value, out double result))
            {
                return true;
            }

            return false;
        }
    }
}
