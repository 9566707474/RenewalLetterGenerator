namespace RenewalLetterGenerator.Tests.Unit.Features.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test the AverageMonthlyPremiumRule
    /// </summary>
    [TestClass]
    public class AverageMonthlyPremiumRuleTest
    {

        private AverageMonthlyPremiumRule underTest;

        private CustomerProduct customerProduct;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new AverageMonthlyPremiumRule();
            customerProduct = BuildCustomerProduct();
        }

        [TestMethod]
        public void TestAverageMonthlyPremiumRuleAsExpected()
        {
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.Id, customerProduct.Id);
            Assert.AreEqual(value.TotalPremium, customerProduct.TotalPremium);
            Assert.AreEqual(value.AverageMonthlyPremium, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleException))]
        public void TestAverageMonthlyPremiumRuleWithNullValues()
        {
            var value = underTest.Apply(null);
        }

        [TestMethod]
        public void TestAverageMonthlyPremiumRuleWithZeroTotalPremium()
        {
            customerProduct.TotalPremium = 0;
            var value = underTest.Apply(customerProduct);
            Assert.AreEqual(value.AverageMonthlyPremium, 0);
        }

        private CustomerProduct BuildCustomerProduct() {
            return new CustomerProductModelBuilder().WithTotalPremium(120).Build();
        }
    }
}
