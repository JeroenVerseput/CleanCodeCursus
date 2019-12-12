using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public class Rental
    {
        private readonly IMoviePriceCalculator _moviePriceCalculator;
        private readonly IFrequentRenterPointsCalculator _frequentRenterPointsCalculator;
        public Movie Movie { get; set; }
        public int DaysRented { get; set; }

        public Rental(IMoviePriceCalculator moviePriceCalculator, IFrequentRenterPointsCalculator frequentRenterPointsCalculator)
        {
            _moviePriceCalculator = moviePriceCalculator;
            _frequentRenterPointsCalculator = frequentRenterPointsCalculator;
        }

        public decimal Price => _moviePriceCalculator.CalculatePrice(DaysRented);

        public int FrequentRenterPoints => _frequentRenterPointsCalculator.CalculateFrequentRenterPoints(DaysRented);
    }
}
