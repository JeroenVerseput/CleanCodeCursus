using System;
using VideoStore.Objects.Movies;

namespace VideoStore.Objects.Customers
{
    public class RentalRecord
    {
        public Movie Movie { get; private set; }
        public int NumberOfDaysRented { get; private set; }

        public RentalRecord(Movie movie, int numberOfDaysRented)
        {
            if (numberOfDaysRented < 1)
            {
                throw new ArgumentNullException("Number of days rented cannot be a negative value.");
            }

            Movie = movie ?? throw new ArgumentNullException("Movie cannot be null.");
            NumberOfDaysRented = numberOfDaysRented;
        }

        public decimal GetRentalPrice()
        {
            return Movie.GetRentalPrice(NumberOfDaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(NumberOfDaysRented);
        }

        public override string ToString()
        {
            return "\t" + Movie.Title + "\t"
                         + GetRentalPrice() + "\n";
        }
    }
}
