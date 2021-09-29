namespace VideoStore.Objects.Movies
{
    public class NewReleasedMovie : Movie
    {
        public NewReleasedMovie(string title, decimal basePrice)
        {
            Title = title;
            BasePrice = basePrice;
        }

        public override int GetFrequentRenterPoints(int numberOfDaysRented)
        {
            if (numberOfDaysRented > 1)
            {
                return base.GetFrequentRenterPoints(numberOfDaysRented) + 1;
            }

            return base.GetFrequentRenterPoints(numberOfDaysRented);
        }

        public override decimal GetRentalPrice(int numberOfDaysRented)
        {
            return BasePrice * numberOfDaysRented;
        }
    }
}
