using System;
using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        private string name;
        private Dictionary<Movie, int> rentals = new Dictionary<Movie, int>(); 

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Movie movie, int daysOfRental)
        {
            if (daysOfRental <= 0)
            {
                throw new ArgumentOutOfRangeException("Negative days rented");
            }

            rentals.Add(movie, daysOfRental);
        }

        public string GetName() => name;

        public string GetRentalStatement()
        {
            double totalRentalCosts = 0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + GetName() + "\n";

            foreach (var rental in rentals)
            {
                result = FrequentRenterPoints(rental, ref frequentRenterPoints, result, ref totalRentalCosts);
            }
            
            // add footer lines
            result += "Amount owed is " + totalRentalCosts + "\n";
            result += "You earned " + frequentRenterPoints
                                    + " frequent renter points";
            return result;
        }

        private static string FrequentRenterPoints(
            KeyValuePair<Movie, int> rental,
            ref int frequentRenterPoints,
            string result,
            ref double totalRentalCosts)
        {
            Movie movie = rental.Key;
            int daysOfRental = rental.Value;

            double rentalCosts = CalculateRentalCosts(movie, daysOfRental);

            frequentRenterPoints += CalculateFrequentRenterPoints(movie, daysOfRental);

            // show figures line for this rental
            result += $"\t{movie.GetTitle()}\t{rentalCosts}\n";
            totalRentalCosts += rentalCosts;
            return result;
        }

        private static double CalculateRentalCosts(Movie movie, int daysOfRental)
        {
            double rentalCosts = 0;

            switch (movie.GetMovieType())
            {
                case MovieType.Regular:
                    rentalCosts += 2;
                    if (daysOfRental > 2)
                        rentalCosts += (daysOfRental - 2) * 1.5;
                    break;
                case MovieType.NewRelease:
                    rentalCosts += daysOfRental * 3;
                    break;
                case MovieType.Children:
                    rentalCosts += 1.5;
                    if (daysOfRental > 3)
                        rentalCosts += (daysOfRental - 3) * 1.5;
                    break;
            }

            return rentalCosts;
        }

        private static int CalculateFrequentRenterPoints(Movie movie, int daysOfRental)
        {
            int frequentRenterPoints = 1;

            // add bonus for a two day new release rental
            if (movie.GetMovieType() == MovieType.NewRelease && daysOfRental > 1)
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }
    }
}
