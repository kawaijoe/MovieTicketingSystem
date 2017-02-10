//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.menu;
using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.menu.commands.options;
using MovieTicketingSystem.movie;
using System;
using System.Collections.Generic;

namespace MovieTicketingSystem {
    class Program {

        /*
         * IMPORTANT NOTE:
         *   Before using the movie recommendation. Please read what the variables below does.
         * 
         * - RATING_MODIFIER (Default = 25)
         *   Must be an integer value between 0 - 100.
         *   Higher RATING_MODIFIER means more influence rating will have
         *   Lower RATING_MODIFIER means more influence genre will have
         *      Eg. 0 = Only genre will be taken into account
         *          100 = Only rating will be taken into account
         *          
         * - NO_MOVIE_ASKED (Default = 5)
         *   Must be an integer value > 0.
         *   Higher NO_MOVIE_ASKED will increase the algorithm accuracy
         *   Lower NO_MOVIE_ASKED will make the sign up process faster
         */
        public const int RATING_MODIFIER = 25;
        public const int NO_MOVIE_ASKED = 5;

        public static List<Movie> movieList = new List<Movie>();
        public static List<Screening> screeningList = new List<Screening>();
        public static List<CinemaHall> cinemaHallList = new List<CinemaHall>();
        public static List<Order> orderList = new List<Order>();
        public static List<MovieRating> movieRatingList = new List<MovieRating>();

        public const int MAX_ATTEMPT = 3;

        private const String MENU_TEXT = "\nMovie Ticketing System\n" +
            "=================================\n" +
            "1.  List all movies\n" +
            "2.  Add a movie screening session\n" +
            "3.  List movie screenings\n" +
            "4.  Delete a movie screening session\n" +
            "5.  Order movie ticket/s\n" +
            "6.  Add a movie rating\n" +
            "7.  View movie ratings and comments\n" +
            "8.  Recommend movies\n" +
            "0.  Exit\n" +
            "=================================\n" +
            "Enter your option: ";

        static void Main(string[] args) {
            GenerateInformation();

            // Start menu
            new Menu(MENU_TEXT, new Dictionary<int, Command>(){
                { 1, new ListAllMovies() },
                { 2, new AddMovieScreening() },
                { 3, new ListMovieScreening() },
                { 4, new DeleteMovieScreening() },
                { 5, new OrderMovieTicket() },
                { 6, new AddMovieRating() },
                { 7, new ViewMovieRating() },
                { 8, new RecommendMovie() }
            }).Run();
        }

        public static void GenerateInformation() {
            // Add movies
            movieList.Add(new Movie("The Great Wall", 103, MovieClassification.NC16.ToString(),
                new DateTime(2016, 12, 29), new List<MovieGenre> { MovieGenre.Action, MovieGenre.Adventure }));
            movieList.Add(new Movie("Rogue One: A Star Wars Story", 134, MovieClassification.PG13.ToString(),
                new DateTime(2016, 12, 15), new List<MovieGenre> { MovieGenre.Action, MovieGenre.Adventure }));
            movieList.Add(new Movie("Office Christmas Party", 106, MovieClassification.M18.ToString(),
                new DateTime(2017, 1, 15), new List<MovieGenre> { MovieGenre.Comedy }));
            movieList.Add(new Movie("Power Rangers", 120, MovieClassification.G.ToString(),
                new DateTime(2017, 1, 31), new List<MovieGenre> { MovieGenre.Fantasy, MovieGenre.Thriller }));

            // Add cinema halls
            cinemaHallList.Add(new CinemaHall("Singa North", 1, 30));
            cinemaHallList.Add(new CinemaHall("Singa North", 2, 10));
            cinemaHallList.Add(new CinemaHall("Singa West", 1, 50));
            cinemaHallList.Add(new CinemaHall("Singa East", 1, 5));
            cinemaHallList.Add(new CinemaHall("Singa Central", 1, 20));
            cinemaHallList.Add(new CinemaHall("Singa Central", 2, 15));

            // Add screenings
            screeningList.Add(new Screening(new DateTime(2016, 12, 29, 15, 0, 0), "3D", cinemaHallList[2], movieList[0]));
            screeningList.Add(new Screening(new DateTime(2017, 01, 03, 13, 0, 0), "2D", cinemaHallList[3], movieList[1]));
            screeningList.Add(new Screening(new DateTime(2017, 01, 31, 19, 0, 0), "3D", cinemaHallList[0], movieList[3]));
            screeningList.Add(new Screening(new DateTime(2017, 02, 02, 15, 0, 0), "2D", cinemaHallList[1], movieList[3]));
        }
    }
}
