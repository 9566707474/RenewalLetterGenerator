namespace RenewalLetterGenerator.Tests.Unit.Features.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test the InitialMonthlyPaymentAmountRule
    /// </summary>
    [TestClass]
    public class InitialMonthlyPaymentAmountRuleTest
    {
        private InitialMonthlyPaymentAmountRule underTest;

        private CustomerProduct customerProduct;

        private double averageMonthlyPremium;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new InitialMonthlyPaymentAmountRule();
            averageMonthlyPremium = 10.3245;
            customerProduct = BuildCustomerProduct();
        }

        [TestMethod]
        public void TestInitialMonthlyPaymentAmountRuleAsExpected()
        {
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.Id, customerProduct.Id);
            Assert.AreEqual(value.AverageMonthlyPremium, customerProduct.AverageMonthlyPremium);
            Assert.AreEqual(value.InitialMonthlyPayment, 10.38);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleException))]
        public void TestInitialMonthlyPaymentAmountRuleWithNullValues()
        {
            var value = underTest.Apply(null);
        }

        [TestMethod]
        public void TestInitialMonthlyPaymentAmountRuleWithZeroValue()
        {
            customerProduct.AverageMonthlyPremium = 0;
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.AverageMonthlyPremium, 0);
            Assert.AreEqual(value.InitialMonthlyPayment, 0);
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder().WithAverageMonthlyPremium(averageMonthlyPremium).Build();
        }
    }
}
