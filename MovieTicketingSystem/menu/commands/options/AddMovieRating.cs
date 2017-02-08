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
    class AddMovieRating : Command {

        public AddMovieRating() { } 

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 6. Add Movie Rating");

            Movie movie;
            int rating = 0;
            string comment;
            Object temptObject = new Object();

            // Get movies to be reviewed
            temptObject = attempt.Run(() => {
                Display.Movies();

                Console.Write("\nEnter a movie number to review movie: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int)obj <= Program.movieList.Count && (int)obj > 0);
            });
            if (temptObject == null) return; 
            movie = Program.movieList[(int)temptObject - 1];

            // Get current rating for movie
            Console.WriteLine("The current rating for the " + movie.Title + " is " +
                String.Format("{0:0.00}.", Select.MovieRating(movie)));

            // Enter rating for movie
            temptObject = attempt.Run(() => {
                Console.Write("\nPlease enter a rating [0=Very bad; 5=Very good]: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return (int)obj >= 0 && (int)obj <= 5;

            });
            if (temptObject == null) return;
            rating = (int)temptObject;
 
            // Comments about movie
            Console.Write("Please enter comments about the movie: ");
            comment = Console.ReadLine();

            //Add input review
            Program.movieRatingList.Add(new MovieRating(rating, comment, movie));

            // Ending
            Console.WriteLine("\nThank you for your submission.");
            Console.WriteLine("the new rating for the movie is " +
                String.Format("{0:0.00}.", Select.MovieRating(movie)));
        }
    }
}
