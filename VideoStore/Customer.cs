using System;
using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        public string Name { get; }
        private readonly List<Rental> _rentals = new List<Rental>(); 

        public Customer(string name)
        {
            this.Name = name;
        }

        public void AddRental(Movie movie, int daysRented)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            if (daysRented <= 0) throw new ArgumentOutOfRangeException(nameof(daysRented));
            var rental = RentalFactory.CreateRental(movie, daysRented);
            _rentals.Add(rental);
        }

        public string Statement()
        {
            decimal totalPrice = 0;
            int totalFrequentRenterPoints = 0;
            string result = $"Rental Record for {Name}\n";
            foreach (var rental in _rentals)
            {
                decimal price = rental.Price;
                int frequentRenterPoints = rental.FrequentRenterPoints;

                result += $"\t{rental.Movie.Title}\t{price:F}\n";

                totalPrice += price;
                totalFrequentRenterPoints += frequentRenterPoints;
            }

            result += $"Amount owed is {totalPrice:F}\n";
            result += $"You earned {totalFrequentRenterPoints} frequent renter points";
            return result;
        }
    }
}
