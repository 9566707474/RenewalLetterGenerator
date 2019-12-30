namespace RenewalLetterGenerator.Tests.Unit.Features.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test the TotalPremiumRule
    /// </summary>
    [TestClass]
    public class TotalPremiumRuleTest
    {
        private TotalPremiumRule underTest;

        private CustomerProduct customerProduct;

        private double annualPremium;

        private double creditCharge;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new TotalPremiumRule();
            annualPremium = 50;
            creditCharge = 2.5;
            customerProduct = BuildCustomerProduct();
        }

        [TestMethod]
        public void TestTotalPremiumRuleAsExpected()
        {
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.Id, customerProduct.Id);
            Assert.AreEqual(value.AnnualPremium, customerProduct.AnnualPremium);
            Assert.AreEqual(value.CreditCharge, customerProduct.CreditCharge);
            Assert.AreEqual(value.TotalPremium, 52.5);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleException))]
        public void TestTotalPremiumRuleWithNullValues()
        {
            var value = underTest.Apply(null);
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder().WithAnnualPremium(annualPremium)
                .WithCreditCharge(creditCharge)
                .Build();
        }
    }
}
