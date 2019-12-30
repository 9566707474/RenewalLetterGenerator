namespace RenewalLetterGenerator.Features.Rules
{
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Models;
    using System;

    /// <summary>
    /// Used to credit charge rule
    /// </summary>
    public class CreditChargeRule : IRule
    {
        /// <summary>
        /// Apply Credit Charge Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AnnualPremium == null)
            {
                throw new RuleException(ErrorMessages.AnnualPremium);
            }
            customerProduct.CreditCharge = Math.Round((customerProduct.AnnualPremium / 100) * 5, 2);
            return customerProduct;
        }
    }
}
