namespace RenewalLetterGenerator.Exceptions
{
    using System;

    public class FileNotProcessedException : Exception
    {
        public FileNotProcessedException(string message) : base(message)
        {
        }
    }
}
