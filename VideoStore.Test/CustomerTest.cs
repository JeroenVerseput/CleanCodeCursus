using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace VideoStore.Test
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
            customer.AddRental(new Movie("Star Wars", MovieType.NewRelease), 6);
            customer.AddRental(new Movie("Sofia", MovieType.Childrens), 7);
            customer.AddRental(new Movie("Inception", MovieType.Regular), 5);

            string expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18.00\n"
                              + "	Sofia	7.50\n"
                              + "	Inception	6.50\n"
                              + "Amount owed is 32.00\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.Statement());
        }
    }
}
