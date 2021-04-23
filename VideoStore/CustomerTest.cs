using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace VideoStore
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
            Customer customer = new Customer("John Doe");
            customer.AddRental(new Movie("Star Wars", MovieType.NewRelease), daysOfRental:6);
            customer.AddRental(new Movie("Sofia", MovieType.Children), daysOfRental:7);
            customer.AddRental(new Movie("Inception", MovieType.Regular), daysOfRental:5);

            string expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7.5\n"
                              + "	Inception	6.5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.GetRentalStatement());
        }
    }
}
