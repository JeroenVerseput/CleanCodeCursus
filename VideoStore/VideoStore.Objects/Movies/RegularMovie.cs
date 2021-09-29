namespace VideoStore.Objects.Movies
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title, decimal basePrice)
        {
            Title = title;
            BasePrice = basePrice;
        }

        public override decimal GetRentalPrice(int numberOfDaysRented)
        {
            if (numberOfDaysRented > 2)
            {
                return BasePrice + (numberOfDaysRented - 2) * 1.5m;
            }

            return BasePrice;
        }
    }
}
