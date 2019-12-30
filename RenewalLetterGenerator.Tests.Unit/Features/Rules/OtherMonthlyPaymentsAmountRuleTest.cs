namespace RenewalLetterGenerator.Tests.Unit.Features.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test the OtherMonthlyPaymentsAmountRule
    /// </summary>
    [TestClass]
    public class OtherMonthlyPaymentsAmountRuleTest
    {
        private OtherMonthlyPaymentsAmountRule underTest;

        private CustomerProduct customerProduct;

        private double averageMonthlyPremium;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new OtherMonthlyPaymentsAmountRule();
            averageMonthlyPremium = 10.3245;
            customerProduct = BuildCustomerProduct();
        }

        [TestMethod]
        public void TestOtherMonthlyPaymentsAmountRuleAsExpected()
        {
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.Id, customerProduct.Id);
            Assert.AreEqual(value.AverageMonthlyPremium, customerProduct.AverageMonthlyPremium);
            Assert.AreEqual(value.OtherMonthlyPayments, 10.32);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleException))]
        public void TestOtherMonthlyPaymentsAmountRuleWithNullValues()
        {
            var value = underTest.Apply(null);
        }

        [TestMethod]
        public void TestOtherMonthlyPaymentsAmountRuleWithZeroValue()
        {
            customerProduct.AverageMonthlyPremium = 0;
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.AverageMonthlyPremium, 0);
            Assert.AreEqual(value.OtherMonthlyPayments, 0);
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder().WithAverageMonthlyPremium(averageMonthlyPremium).Build();
        }
    }
}
