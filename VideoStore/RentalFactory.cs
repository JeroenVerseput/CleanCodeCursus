using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public class RentalFactory
    {
        public static Rental CreateRental(Movie movie, int daysRented)
        {
            IMoviePriceCalculator moviePriceCalculator;
            IFrequentRenterPointsCalculator frequentRenterPointsCalculator;

            switch (movie.MovieType)
            {
                case MovieType.Regular:
                    moviePriceCalculator = new RegularMoviePriceCalculator();
                    frequentRenterPointsCalculator = new DefaultFrequentRenterPointsCalculator();
                    break;
                case MovieType.NewRelease:
                    moviePriceCalculator = new NewReleaseMoviePriceCalculator();
                    frequentRenterPointsCalculator = new NewReleaseFrequentRenterPointsCalculator();
                    break;
                case MovieType.Childrens:
                    moviePriceCalculator = new ChildrensMoviePriceCalculator();
                    frequentRenterPointsCalculator = new DefaultFrequentRenterPointsCalculator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movie.MovieType));
            }

            return new Rental(moviePriceCalculator, frequentRenterPointsCalculator)
            {
                Movie = movie,
                DaysRented = daysRented
            };
        }
    }
}
