namespace RenewalLetterGenerator.Features.Rules
{
    using RenewalLetterGenerator.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Class to calculate the payment amount for each customer product data
    /// </summary>
    public class Payments
    {
        public CustomerProduct CustomerProduct { get; set; }

        private ICollection<IRule> rules = new List<IRule>();

        public Payments(CustomerProduct customerProduct)
        {
            CustomerProduct = customerProduct;
            rules.Add(new CreditChargeRule());
            rules.Add(new TotalPremiumRule());
            rules.Add(new AverageMonthlyPremiumRule());
            rules.Add(new InitialMonthlyPaymentAmountRule());
            rules.Add(new OtherMonthlyPaymentsAmountRule());
        }

        /// <summary>
        /// Calculate paymount amounts by applying rules
        /// </summary>
        public void Calculate()
        {
            foreach (var rule in rules)
            {
                CustomerProduct = rule.Apply(CustomerProduct);
            }
        }
    }
}
