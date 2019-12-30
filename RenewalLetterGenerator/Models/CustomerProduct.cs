namespace RenewalLetterGenerator.Models
{
    using RenewalLetterGenerator.Common;
    using System;

    /// <summary>
    /// Customer with product details
    /// </summary>
    public class CustomerProduct: Customer
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Payout amount
        /// </summary>
        public double PayoutAmount { get; set; }

        /// <summary>
        /// Annual premium
        /// </summary>
        public double AnnualPremium { get; set; }

        /// <summary>
        /// Credit charge
        /// </summary>
        public double CreditCharge { get; set; }

        /// <summary>
        /// Annual premimum plus credit charge
        /// </summary>
        public double TotalPremium { get; set; }

        /// <summary>
        /// Average monthly premium amount
        /// </summary>
        public double AverageMonthlyPremium { get; set; }

        /// <summary>
        /// Initial monthly payment amount
        /// </summary>
        public double InitialMonthlyPayment { get; set; }

        /// <summary>
        /// Other monthly payments amount
        /// </summary>
        public double OtherMonthlyPayments { get; set; }

        /// <summary>
        /// System current date
        /// </summary>
        public string CurrentDate => DateTime.Now.ToString(Constants.DateFormate);
    }
}
