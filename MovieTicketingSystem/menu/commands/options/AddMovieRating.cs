//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.movie;
using MovieTicketingSystem.util;
using System;

namespace MovieTicketingSystem.menu.commands.options {
    class AddMovieRating : Command {

        OptionAttempt attempt;

        // Option 6
        public AddMovieRating() { } 

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 6. Add Movie Rating");

            this.attempt = attempt;

            Movie movie = GetMovie();

            // Display current rating
            Console.WriteLine("The current rating for the " + movie.Title + " is " +
                String.Format("{0:0.00}.", Select.MovieRating(movie)));

            int rating = GetRating();
 
            // Enter comments
            Console.Write("Please enter comments about the movie: ");
            Program.movieRatingList.Add(new MovieRating(rating, Console.ReadLine(), movie));

            Console.WriteLine("\nThank you for your submission.");
            Console.WriteLine("the new rating for the movie is " +
                String.Format("{0:0.00}.", Select.MovieRating(movie)));
        }

        private Movie GetMovie() {
            return Program.movieList[(int) attempt.Run(() => {
                Display.Movies();

                Console.Write("\nEnter a movie number to review movie: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int) obj <= Program.movieList.Count && (int) obj > 0);
            }) - 1];
        }

        private int GetRating() {
            return (int) attempt.Run(() => {
                Console.Write("\nPlease enter a rating [0=Very bad; 5=Very good]: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return (int) obj >= 0 && (int) obj <= 5;

            });
        }

    }
}
