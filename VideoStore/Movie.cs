using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public class Movie
    {
        public string Title { get; }
        public MovieType MovieType { get; set; }


        public Movie(string title, MovieType movieType)
        {
            Title = title;
            MovieType = movieType;
        }
    }
}
