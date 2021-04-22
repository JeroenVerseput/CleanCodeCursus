using System;

namespace VideoStore
{
    public class Movie
    {
        public Movie(string title, PriceCode priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        internal PriceCode PriceCode { get; }
        internal string Title { get; }

        internal (string, double) GetMovieStatementWithPrice(int daysRented)
        {
            var moviePriceAmount = GetMoviePriceAmount(PriceCode, daysRented);
            return ($"\t{Title}\t{moviePriceAmount}\n", moviePriceAmount);
        }

        private static double GetMoviePriceAmount(PriceCode priceCode, int daysRented)
        {
            return priceCode switch
            {
                PriceCode.Regular when daysRented > 2 => 2 + (daysRented - 2) * 1.5,
                PriceCode.Regular => 2,
                PriceCode.NewRelease => daysRented * 3,
                PriceCode.Childrens when daysRented > 3 => 1.5 + (daysRented - 3) * 1.5,
                PriceCode.Childrens => 1.5,
                _ => throw new ArgumentOutOfRangeException(nameof(priceCode),
                    $"given price code '{priceCode}' is invalid.")
            };
        }
    }
}