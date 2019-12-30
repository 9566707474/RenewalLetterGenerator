namespace RenewalLetterGenerator.Features.Rules
{
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Models;
    using System;

    /// <summary>
    /// Used to apply InitialMonthlyPaymentAmountRule
    /// </summary>
    public class InitialMonthlyPaymentAmountRule : IRule
    {
        /// <summary>
        /// Apply Initial Monthly Payment Amount Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AverageMonthlyPremium == null)
            {
                throw new RuleException(ErrorMessages.AverageMonthlyPremium);
            }
            var amount = customerProduct.AverageMonthlyPremium - Math.Round(customerProduct.AverageMonthlyPremium, 2);

            customerProduct.InitialMonthlyPayment = Math.Round((amount * 12) + customerProduct.AverageMonthlyPremium, 2);

            return customerProduct;
        }
    }
}
