//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.movie;
using MovieTicketingSystem.util;
using System;

namespace MovieTicketingSystem.menu.commands.options {
    class ViewMovieRating:Command {

        // Option 7
        public ViewMovieRating() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 7. View Movie Rating and Comments");

            Movie movie = Program.movieList[Select.Movie(attempt) - 1];
            Console.WriteLine(String.Format("\nThe rating for {0} is {1:0.00}", movie.Title, Select.MovieRating(movie)));
            PrintComments(movie);
        }

        private void PrintComments(Movie movie) {
            int count = 0;
            foreach(MovieRating rating in Program.movieRatingList) {
                if(rating.Movie == movie)
                    Console.WriteLine("Comment #" + ++count + ": " + rating.Comment);
            }
        }

    }
}
