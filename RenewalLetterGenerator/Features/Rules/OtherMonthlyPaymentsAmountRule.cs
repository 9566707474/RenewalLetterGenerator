namespace RenewalLetterGenerator.Features.Rules
{
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Models;
    using System;

    /// <summary>
    /// Used to calculate the other monthly payments amount
    /// </summary>
    public class OtherMonthlyPaymentsAmountRule : IRule
    {
        /// <summary>
        /// Apply Other Monthly Payments Amount Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AverageMonthlyPremium == null)
            {
                throw new RuleException(ErrorMessages.AverageMonthlyPremium);
            }

            customerProduct.OtherMonthlyPayments = Math.Round(customerProduct.AverageMonthlyPremium, 2);
            return customerProduct;
        }
    }
}
