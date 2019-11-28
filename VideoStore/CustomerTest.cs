using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
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
            customer.addRental(new Movie("Star Wars", Movie.NEW_RELEASE), 6);
            customer.addRental(new Movie("Sofia", Movie.CHILDRENS), 7);
            customer.addRental(new Movie("Inception", Movie.REGULAR), 5);

            String expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7.5\n"
                              + "	Inception	6.5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.statement());
        }
    }
}
