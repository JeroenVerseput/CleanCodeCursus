using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace VideoStore.Unit.Test
{
    [TestFixture]
    public class CustomerTest
    {
        [SetUp]
        public void SetUp()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Test]
        public void CharacterizationTest()
        {
            var customer = new Customer("John Doe");
            customer.AddRental(new Movie("Star Wars", PriceCode.NewRelease), 6);
            customer.AddRental(new Movie("Sofia", PriceCode.Childrens), 7);
            customer.AddRental(new Movie("Inception", PriceCode.Regular), 5);

            const string expected = "Rental Record for John Doe\n"
                                    + "	Star Wars	18\n"
                                    + "	Sofia	7.5\n"
                                    + "	Inception	6.5\n"
                                    + "Amount owed is 32\n"
                                    + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.GetFullStatement());
        }
    }
}