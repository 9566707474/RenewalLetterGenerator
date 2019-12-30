namespace RenewalLetterGenerator.Common
{
    public static class OutputTemplate
    {
        public static string Load { private get; set; }
        public static string Get => Load;
    }
}
