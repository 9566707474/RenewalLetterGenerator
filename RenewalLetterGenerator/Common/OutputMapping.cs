namespace RenewalLetterGenerator.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains customer attribute mapping columns for generating invitation letter
    /// </summary>
    public static class OutputMapping
    {
        /// <summary>
        /// Static column mapping dictionary
        /// </summary>
        public static Dictionary<string, string> Columns = new Dictionary<string, string>
    {
        {"#CurrentDate#", "CurrentDate"},
        {"#Title#", "Title"},
        {"#FirstName#", "FirstName"},
        {"#Surname#", "Surname"},
        {"#ProductName#", "ProductName"},
        {"#PayoutAmount#", "PayoutAmount"},
        {"#AnnualPremium#", "AnnualPremium"},
        {"#CreditCharge#", "CreditCharge"},
        {"#AnnualPremiumWithCreditCharge#", "TotalPremium"},
        {"#InitialMonthlyPaymentAmount#", "InitialMonthlyPayment"},
        {"#OtherMonthlyPaymentsAmount#", "OtherMonthlyPayments"}
    };

        /// <summary>
        /// Access the Dictionary from external sources
        /// </summary>
        public static string GetAttributeToReplace(string word)
        {
            if (Columns.TryGetValue(word, out string result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
