using System;
using System.Collections.Generic;

namespace VideoStore
{
    internal class Customer
    {
        public Customer(string name)
        {
            Name = name;
            Rentals = new Dictionary<Movie, int>();
        }

        private string Name { get; }
        private Dictionary<Movie, int> Rentals { get; }


        public void AddRental(Movie movie, int daysRented)
        {
            if (daysRented <= 0) throw new ArgumentOutOfRangeException(nameof(daysRented), "Negative days rented");
            Rentals.Add(movie, daysRented);
        }

        public string GetFullStatement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            var result = "Rental Record for " + Name + "\n";

            foreach (var (movie, daysRented) in Rentals)
            {
                frequentRenterPoints++;
                frequentRenterPoints = AddBonusPointsIfAvailable(movie, daysRented, frequentRenterPoints);

                var (movieStatement, moviePriceAmount) = movie.GetMovieStatementWithPrice(daysRented);

                result += movieStatement;
                totalAmount += moviePriceAmount;
            }

            return $"{result}Amount owed is {totalAmount}\nYou earned {frequentRenterPoints} frequent renter points";
        }

        private static int AddBonusPointsIfAvailable(Movie movie, int daysRented, int frequentRenterPoints)
        {
            if (movie.PriceCode == PriceCode.NewRelease && daysRented > 1) frequentRenterPoints++;
            return frequentRenterPoints;
        }
    }
}