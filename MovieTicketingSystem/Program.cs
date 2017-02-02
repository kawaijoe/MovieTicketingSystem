//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.menu;
using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.movie;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Program {
        /*
         * Rants about the flawed design of this assignment
         * 
         * CHAPTER 1: Abuse of override ToString() method
         * Some may insist that the ToString() method may be good for debugging, however there are much more appropriate
         * tools such as loggers and unit testing.
         * 
         * The ToString() method should only be used if you are creating your own collection/data type for example.
         * For instance, creating your own implementation of a WeakList<> which is currently not in C# collections library.
         * 
         * If you can name me a popular open source library that abused ToString() in such a way.
         * (Every class having a ToString() method)
         * I'll follow your pretty dang useless convention. Good luck with that :P
         * 
         * CHAPTER 2: Properties vs Variables
         * 
        */

        public static List<Movie> movieList = new List<Movie>();
        public static List<Screening> screeningList = new List<Screening>();
        public static List<CinemaHall> cinemaHallList = new List<CinemaHall>();
        public static List<Order> orderList = new List<Order>();

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
        private static Menu menu;

        static void Main(string[] args) {
            generateInformation();

            // Start menu
            menu = new Menu(MENU_TEXT, new Dictionary<int, Command>(){
                { 1, new ListAllMovies() },
                { 2, new AddMovieScreening() },
                { 3, new ListMovieScreening() },
                { 4, new DeleteMovieScreening() }
            });
            menu.run();
        }

        public static void generateInformation() {
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
