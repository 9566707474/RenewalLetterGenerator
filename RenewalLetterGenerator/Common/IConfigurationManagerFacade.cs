namespace RenewalLetterGenerator.Common
{
    public interface IConfigurationManagerFacade
    {
        string InputFileLocation { get; }

        string InputFilePattern { get; }

        string OutputFileLocation { get; }

        int NumberOfProcessor { get; }
    }
}
