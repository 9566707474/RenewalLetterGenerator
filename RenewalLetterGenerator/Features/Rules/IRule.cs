namespace RenewalLetterGenerator.Features.Rules
{
    using RenewalLetterGenerator.Models;

    /// <summary>
    /// Interface to apply rules
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Apply rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        CustomerProduct Apply(CustomerProduct customerProduct);
    }
}
