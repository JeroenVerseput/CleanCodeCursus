using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    class Customer
    {
        private string name;
        private Dictionary<Movie, int> rentals = new Dictionary<Movie, int>(); 

        public Customer(String name)
        {
            this.name = name;
        }

        public void addRental(Movie m, int d)
        {
            if (d <= 0) throw new ArgumentOutOfRangeException("Negative days rented");
            rentals.Add(m, d);
        }

        public String getName()
        {
            return name;
        }

        public String statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + getName() + "\n";
            foreach (var rental in rentals)
            {
                double thisAmount = 0;
                Movie each = (Movie)rental.Key;
                // determine amounts for each line
                int dr = rental.Value;
                switch (each.getPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (dr > 2)
                            thisAmount += (dr - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += dr * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (dr > 3)
                            thisAmount += (dr - 3) * 1.5;
                        break;
                }
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if (each.getPriceCode() != null &&
                    (each.getPriceCode() == Movie.NEW_RELEASE)
                    && dr > 1)
                    frequentRenterPoints++;
                // show figures line for this rental
                result += "\t" + each.getTitle() + "\t"
                          + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints
                                    + " frequent renter points";
            return result;
        }
    }
}
