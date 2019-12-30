namespace RenewalLetterGenerator.Tests.Unit.Builders.Models
{
    using RenewalLetterGenerator.Models;

    /// <summary>
    /// Customer product model builder
    /// </summary>
    public class CustomerProductModelBuilder
    {
        private long id;

        private string title;

        private string firstName;

        private string surname;

        private string productName;

        private double payoutAmount;

        private double annualPremium;

        private double creditCharge;

        private double totalPremium;

        private double averageMonthlyPremium;

        private double initialMonthlyPayment;

        private double otherMonthlyPayments;

        public CustomerProductModelBuilder()
        {
            WithId(1).WithTitle("Miss").WithFirstName("Sally")
                .WithSurname("Smith").WithProductName("Standard Cover")
                .WithPayoutAmount(190820).WithAnnualPremium(123.45);
        }

        public CustomerProduct Build()
        {
            return new CustomerProduct()
            {
                Id = id,
                Title = title,
                FirstName = firstName,
                Surname = surname,
                ProductName = productName,
                PayoutAmount = payoutAmount,
                AnnualPremium = annualPremium,
                CreditCharge = creditCharge,
                TotalPremium = totalPremium,
                AverageMonthlyPremium = averageMonthlyPremium,
                InitialMonthlyPayment = initialMonthlyPayment,
                OtherMonthlyPayments = otherMonthlyPayments
            };
        }

        public CustomerProductModelBuilder WithId(long usingId)
        {
            id = usingId;
            return this;
        }

        public CustomerProductModelBuilder WithTitle(string usingTitle)
        {
            title = usingTitle;
            return this;
        }

        public CustomerProductModelBuilder WithFirstName(string usingFirstName)
        {
            firstName = usingFirstName;
            return this;
        }

        public CustomerProductModelBuilder WithSurname(string usingSurname)
        {
            surname = usingSurname;
            return this;
        }

        public CustomerProductModelBuilder WithProductName(string usingProductName)
        {
            productName = usingProductName;
            return this;
        }

        public CustomerProductModelBuilder WithPayoutAmount(double usingPayoutAmount)
        {
            payoutAmount = usingPayoutAmount;
            return this;
        }

        public CustomerProductModelBuilder WithAnnualPremium(double usingAnnualPremium)
        {
            annualPremium = usingAnnualPremium;
            return this;
        }

        public CustomerProductModelBuilder WithCreditCharge(double usingCreditCharge)
        {
            creditCharge = usingCreditCharge;
            return this;
        }

        public CustomerProductModelBuilder WithTotalPremium(double usingTotalPremium)
        {
            totalPremium = usingTotalPremium;
            return this;
        }

        public CustomerProductModelBuilder WithAverageMonthlyPremium(double usingAverageMonthlyPremium)
        {
            averageMonthlyPremium = usingAverageMonthlyPremium;
            return this;
        }

        public CustomerProductModelBuilder WithInitialMonthlyPayment(double usingInitialMonthlyPayment)
        {
            initialMonthlyPayment = usingInitialMonthlyPayment;
            return this;
        }

        public CustomerProductModelBuilder WithOtherMonthlyPayments(double usingOtherMonthlyPayments)
        {
            otherMonthlyPayments = usingOtherMonthlyPayments;
            return this;
        }
    }
}
