namespace RenewalLetterGenerator.Tests.Unit.Features.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test the Payments
    /// </summary>
    [TestClass]
    public class PaymentsTest
    {
        private Payments underTest;

        private CustomerProduct customerProduct;

        [TestInitialize]
        public void TestInitialize()
        {
            customerProduct = BuildCustomerProduct();
            underTest = new Payments(customerProduct);
        }

        [TestMethod]
        public void TestPaymentsAsExpected()
        {
            underTest.Calculate();
            AssertCustomerProduct(underTest.CustomerProduct, customerProduct);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleException))]
        public void TestPaymentsWithNullValues()
        {
            underTest = new Payments(null);
            underTest.Calculate();
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder()
                .Build();
        }

        private void AssertCustomerProduct(CustomerProduct actual, CustomerProduct expected)
        {
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.Title, expected.Title);
            Assert.AreEqual(actual.FirstName, expected.FirstName);
            Assert.AreEqual(actual.Surname, expected.Surname);
            Assert.AreEqual(actual.ProductName, expected.ProductName);
            Assert.AreEqual(actual.PayoutAmount, expected.PayoutAmount);
            Assert.AreEqual(actual.AnnualPremium, expected.AnnualPremium);
            Assert.AreEqual(actual.AverageMonthlyPremium, expected.AverageMonthlyPremium);
            Assert.AreEqual(actual.CreditCharge, expected.CreditCharge);
            Assert.AreEqual(actual.TotalPremium, expected.TotalPremium);
            Assert.AreEqual(actual.CurrentDate, expected.CurrentDate);
        }
    }
}
