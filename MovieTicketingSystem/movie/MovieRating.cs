//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;

namespace MovieTicketingSystem.movie {
    class MovieRating {
        public int Rating { get; }
        public String Comment { get; }
        public Movie Movie { get; }

        public MovieRating(int rating, string comment, Movie movie) {
            this.Rating = rating;
            this.Comment = comment;
            this.Movie = movie;
        }
    }
}
