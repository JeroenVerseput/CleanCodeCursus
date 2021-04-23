using System;

namespace VideoStore
{
    public class Movie
    {
        private readonly string _title;
        private MovieType _movieType;

        public Movie(String title, MovieType movieType)
        {
            _title = title;
            _movieType = movieType;
        }

        public MovieType GetMovieType()
        {
            return _movieType;
        }

        public void SetMovieType(MovieType movieType)
        {
            _movieType = movieType;
        }

        public string GetTitle()
        {
            return _title;
        }
    }

    public enum MovieType
    {
        Regular = 0,
        NewRelease = 1,
        Children = 2
    }
}
