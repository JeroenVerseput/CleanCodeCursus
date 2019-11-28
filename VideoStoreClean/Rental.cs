using System;
using System.ComponentModel;

namespace VideoStoreClean
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            if (daysRented <= 0) throw new ArgumentOutOfRangeException("Negative days rented");
            this._movie = movie;
            this._daysRented = daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public int CalculateRenterPoints()
        {
            var frequentRenterPoints = 1;
            var isNewRelease = _movie.GetMovieType() == MovieType.NewRelease;
            if (isNewRelease && _daysRented >= 2)
            {
                frequentRenterPoints++;
            }
            return frequentRenterPoints;
        }

        public double CalculatePrice()
        {
            return (_movie.GetMovieType()) switch
            {
                MovieType.Regular => CalculateRegularPrice(),
                MovieType.NewRelease => CalculateNewReleasePrice(),
                MovieType.Childrens => CalculateChildrenPrice(),
                _ => throw new InvalidEnumArgumentException("JDD: Unexpected value: " + _movie.GetType()),
            };
        }

        private double CalculateChildrenPrice()
        {
            var price = 1.5;
            if (_daysRented > 3)
            {
                price += (_daysRented - 3) * 1.5;
            }
            return price;
        }

        private int CalculateNewReleasePrice()
        {
            return _daysRented * 3;
        }

        private double CalculateRegularPrice()
        {
            double price = 2;
            if (_daysRented > 2)
            {
                price += (_daysRented - 2) * 1.5;
            }
            return price;
        }
    }

}
