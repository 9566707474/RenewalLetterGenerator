namespace RenewalLetterGenerator.Exceptions
{
    using System;

    [Serializable]
    public class RuleException : Exception
    {
        public RuleException(string message) : base(message)
        {
        }
    }
}
