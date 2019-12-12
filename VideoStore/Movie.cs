using System;

namespace VideoStore
{
    public class Movie
    {
        public Movie(string title, PriceCode priceCode)
        {
            Title = title ?? throw new ArgumentNullException();
            PriceCode = priceCode;
        }

        public PriceCode PriceCode { get; }

        public string Title { get; }
    }

    public enum PriceCode
    {
        Regular = 0,
        NewRelease = 1,
        Children = 2,
    }
}
