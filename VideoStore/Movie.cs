namespace VideoStore
{
    internal class Movie
    {
        private MovieType type;
        private string title;

        internal Movie(string title, MovieType type)
        {
            this.title = title;
            this.type = type;
        }

        internal string GetTitle()
        {
            return title;
        }

        internal MovieType GetMovieType()
        {
            return type;
        }
    }
}
