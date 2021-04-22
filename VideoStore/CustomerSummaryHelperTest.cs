using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace VideoStore
{
    [TestFixture]
    public class CustomerSummaryHelperTest
    {
        [SetUp]
        public void SetUp()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Test]
        public void GetCustommerSummary_Returns_Correctly()
        {
            Customer customer = new Customer("John Doe");

            customer.AddRental(new Rental(new Movie("Star Wars", MovieType.NewRelease), 6));
            customer.AddRental(new Rental(new Movie("Sofia", MovieType.Children), 7));
            customer.AddRental(new Rental(new Movie("Inception", MovieType.Regular), 5));

            string expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7.5\n"
                              + "	Inception	6.5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            var result = CustomerSummaryHelper.GetCustomerSummary(customer);

            Assert.AreEqual(expected, result);
        }
    }
}
