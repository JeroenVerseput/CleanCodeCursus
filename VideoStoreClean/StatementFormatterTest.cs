using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace VideoStoreClean
{
    [TestFixture]
    public class StatementFormatterTest
    {

        [Test]
        public void characterizationTest()
        {
            List<Rental> rentals = new List<Rental>
            {
                new Rental(new Movie("Star Wars", MovieType.NewRelease), 6),
                new Rental(new Movie("Sofia", MovieType.Childrens), 7),
                new Rental(new Movie("Inception", MovieType.Regular), 5)
            };

            String expected = "Rental Record for John Doe\n"
                              + "	Star Wars	18\n"
                              + "	Sofia	7,5\n"
                              + "	Inception	6,5\n"
                              + "Amount owed is 32\n"
                              + "You earned 4 frequent renter points";

            Assert.AreEqual(expected, new StatementFormatter()
                .formatStatement("John Doe", rentals));
        }

    }
}
