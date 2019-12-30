namespace RenewalLetterGenerator.Tests.Unit.Features.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test the CreditChargeRule
    /// </summary>
    [TestClass]
    public class CreditChargeRuleTest
    {
        private CreditChargeRule underTest;

        private CustomerProduct customerProduct;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new CreditChargeRule();
            customerProduct = BuildCustomerProduct();
        }

        [TestMethod]
        public void TestCreditChargeRuleAsExpected()
        {
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.Id, customerProduct.Id);
            Assert.AreEqual(value.AnnualPremium, customerProduct.AnnualPremium);
            Assert.AreEqual(value.CreditCharge, 2.5);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleException))]
        public void TestAverageMonthlyPremiumRuleWithNullValues()
        {
            var value = underTest.Apply(null);
        }

        [TestMethod]
        public void TestCreditChargeRuleWithZeroAnnualPremium()
        {
            customerProduct.AnnualPremium = 0;
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.AnnualPremium, 0);
            Assert.AreEqual(value.CreditCharge, 0);
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder().WithAnnualPremium(50).Build();
        }
    }
}
