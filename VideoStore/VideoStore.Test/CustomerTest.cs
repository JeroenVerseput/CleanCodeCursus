using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using VideoStore.Objects.Customers;
using VideoStore.Objects.Movies;

namespace VideoStore
{
    [TestFixture]
    public class CustomerTest
    {
        public IEnumerable<Movie> MovieCollection { get; set; }

		[SetUp]
	    public void SetUp()
	    {
            MovieCollection = new List<Movie>
            {
                new NewReleasedMovie("Star Wars", 3),
                new ChildrensMovie("Sofia", 1.5m),
                new RegularMovie("Inception", 2),
             
            };

		    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
		}

        [Test]
        public void CharacterizationTest()
        {
            Customer customer = new Customer("John Doe");
            customer.AddRentalRecord(new RentalRecord(MovieCollection.Single(m => m.Title == "Star Wars"), 6));
            customer.AddRentalRecord(new RentalRecord(MovieCollection.Single(m => m.Title == "Sofia"), 7));
            customer.AddRentalRecord(new RentalRecord(MovieCollection.Single(m => m.Title == "Inception"), 5));

            var expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7.5\n"
                              + "	Inception	6.5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, customer.ToString());
        }
    }
}
