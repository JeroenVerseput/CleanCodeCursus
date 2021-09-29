namespace VideoStore.Objects.Movies
{
    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title, decimal basePrice)
        {
            Title = title;
            BasePrice = basePrice;
        }

        public override decimal GetRentalPrice(int numberOfDaysRented)
        {
            if (numberOfDaysRented > 3)
            {
                return BasePrice + (numberOfDaysRented - 3) * 1.5m;
            }

            return BasePrice;
        }
    }
}
