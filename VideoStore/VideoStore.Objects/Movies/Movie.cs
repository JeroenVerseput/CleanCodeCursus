namespace VideoStore.Objects.Movies
{
    public abstract class Movie
    {
        public string Title { get; set; }
        protected decimal BasePrice { get; set; }

        public virtual int GetFrequentRenterPoints(int numberOfDaysRented)
        {
            return 1;
        }

        public abstract decimal GetRentalPrice(int numberOfDaysRented);
    }
}
