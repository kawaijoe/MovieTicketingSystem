//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.movie;
using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands.options {
    class ViewMovieRating:Command {

        public ViewMovieRating() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 7. View Movie Rating and Comments");

            // Get movie selection
            int movieSelection = Select.Movie(attempt);
            if(movieSelection == -1) return;
            Movie movie = Program.movieList[movieSelection - 1];

            // Get movie object
            Console.WriteLine(String.Format("\nThe rating for {0} is {1:0.00}", movie.Title, Select.MovieRating(movie)));

            // Get Comments
            int count = 0;
            foreach(MovieRating rating in Program.movieRatingList) {
                if(rating.Movie == movie)
                    Console.WriteLine("Comment #" + ++count + ": " + rating.Comment);
            }
        }
    }
}
