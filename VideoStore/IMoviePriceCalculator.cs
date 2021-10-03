namespace VideoStore
{
    public interface IMoviePriceCalculator
    {
        decimal CalculatePrice(int daysRented);
    }

    public class RegularMoviePriceCalculator : IMoviePriceCalculator
    {
        public decimal CalculatePrice(int daysRented)
        {
            decimal amount = 2;
            if (daysRented > 2)
                amount += (decimal) ((daysRented - 2) * 1.5);

            return amount;
        }
    }

    public class NewReleaseMoviePriceCalculator : IMoviePriceCalculator
    {
        public decimal CalculatePrice(int daysRented)
        {
            return daysRented * 3;
        }
    }

    public class ChildrensMoviePriceCalculator : IMoviePriceCalculator
    {
        public decimal CalculatePrice(int daysRented)
        {
            decimal amount = 1.5m;
            if (daysRented > 3)
                amount += (decimal) ((daysRented - 3) * 1.5);

            return amount;
        }
    }
}