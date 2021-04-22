using System;

namespace VideoStore
{
    internal class Rental
    {
        private Movie movie;
        private int duration;

        internal Rental(Movie movie, int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException("Rental duration is negative");
            }

            this.movie = movie;
            this.duration = duration;
        }

        internal Movie GetMovie()
        {
            return movie;
        }

        internal int CalculatePoints()
        {
            var frequentRenterPoints = 1;
            var isNewRelease = movie.GetMovieType() == MovieType.NewRelease;
            if (isNewRelease && duration >= 2)
            {
                frequentRenterPoints++;
            }
            return frequentRenterPoints;
        }

        internal double CalculatePrice()
        {
            double price = 0;

            switch (movie.GetMovieType())
            {
                case MovieType.Regular:
                    price = CalculatePriceRegular();
                    break;
                case MovieType.Children:
                    price = CalculatePriceChildren();
                    break;
                case MovieType.NewRelease:
                    price = CalculatePriceNewRelease();
                    break;
            }
            return price;
        }

        private double CalculatePriceRegular()
        {
            double price = 2;
            if (duration > 2)
            {
                price += (duration - 2) * 1.5;
            }
            return price;
        }

        private double CalculatePriceChildren()
        {
            double price = 1.5;
            if (duration > 3)
            {
                price += (duration - 3) * 1.5;
            }
            return price;
        }

        private double CalculatePriceNewRelease()
        {
            return duration * 3;
        }
    }
}
