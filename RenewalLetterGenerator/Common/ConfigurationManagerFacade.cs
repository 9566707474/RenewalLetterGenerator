namespace RenewalLetterGenerator.Common
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;

    public class ConfigurationManagerFacade : IConfigurationManagerFacade
    {

        private readonly NameValueCollection settings;

        public ConfigurationManagerFacade()
        {
            var configSetting = ConfigurationManager.AppSettings;
            this.settings = configSetting;
        }

        public ConfigurationManagerFacade(NameValueCollection settings)
        {
            this.settings = settings;
        }

        public string InputFileLocation => settings[Constants.InputFileLocation];

        public string InputFilePattern => settings[Constants.InputFilePattern];

        public string OutputFileLocation => settings[Constants.OutputFileLocation];

        public int NumberOfProcessor => Convert.ToInt32(settings[Constants.NumberOfProcessor]);
    }
}
