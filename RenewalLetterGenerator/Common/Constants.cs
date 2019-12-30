namespace RenewalLetterGenerator.Common
{
    public static class Constants
    {
        public static string DateFormate = "dd/MM/yyyy";

        public static string NumberOfProcessor = "NumberOfProcessor";

        public static string OutputFileLocation = "OutputFileLocation";

        public static string InputFileLocation = "InputFileLocation";

        public static string InputFilePattern = "InputFilePattern";

        public static string OutputTemplatePath = @"\App_Data\InvitationTemplate.txt";
    }

    public static class FileTypes
    {
        public static string Csv = ".CSV";

        public static string Text = ".TXT";
    }

    public static class ErrorMessages
    {
        public static string TotalPremium = "Customer product total premium not found";

        public static string AnnualPremium = "Customer product annual premium not found";

        public static string AverageMonthlyPremium = "Customer product average monthly premium not found";

        public static string AnnualPremiumOrCreditCharge = "Customer product annual premium or credit charge not found";
    }
}
