using System;
using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public HashSet<Rental> Rentals { get; } = new HashSet<Rental>();

        public void AddRental(Movie movie, int daysToRent)
        {
            if (daysToRent <= 0)
                throw new ArgumentOutOfRangeException(nameof(daysToRent), "Negative days rented");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var rental = new Rental
            {
                Movie = movie,
                DaysToRent = daysToRent
            };

            Rentals.Add(rental);
        }

        public string Statement()
        {
            return RentalCalculator.Statement(this);
        }
    }
}
