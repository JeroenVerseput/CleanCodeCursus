using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStoreClean
{
    public class Movie
    {
        private readonly string _title;
        private readonly MovieType _type;

        public Movie(string title, MovieType type)
        {
            this._title = title;
            this._type = type;
        }

        public MovieType GetMovieType()
        {
            return _type;
        }

        public string GetTitle()
        {
            return _title;
        }
    }
}
