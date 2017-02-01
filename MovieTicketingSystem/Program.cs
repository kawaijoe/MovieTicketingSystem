﻿//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
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
        public enum MovieGenre { Action, Adventure, Comedy, Fantasy, Thriller }
        public enum MovieClassification { G, PG13, NC16, M18, R21 }

        delegate Object delegateReturnObject();
        delegate bool delegateReturnBool(Object obj);

        static delegateReturnObject attemptRun;
        static delegateReturnBool attemptIsCorrect;

        public static List<Movie> movieList = new List<Movie>();
        public static List<Screening> screeningList = new List<Screening>();
        public static List<CinemaHall> cinemaHallList = new List<CinemaHall>();
        public static List<Order> orderList = new List<Order>();

        public const int MAXATTEMPT = 3;

        static void Main(string[] args) {
            generateInformation();

            
        }

        //////////////////// OPTIONS ////////////////////
        // Option 1
        public static void listAllMovies() {
            Console.WriteLine("\nOption 1. List All Movies");
            displayMovies();
        }

        // Option 2
        public static void addMovieScreening() {
            Console.WriteLine("\nOption 2. Add Movie Screening");

            int cinemaHall = 0;
            int movie = 0;
            String screeningType = "";
            Object temptObject = new Object();
            DateTime date = new DateTime(1, 1, 1);

            // Select a cinema hall
            attemptRun = () => {
                displayCinemaHall();
                Console.Write("Select a cinema hall: ");
                return tryConvertingStringToInt(Console.ReadLine());
            };
            attemptIsCorrect = obj => { return ((int) obj <= cinemaHallList.Count && (int) obj > 0); };

            temptObject = attempt(attemptRun, attemptIsCorrect);
            if(temptObject == null)
                return;
            cinemaHall = (int) temptObject;

            // Select a movie
            for(int i = MAXATTEMPT; i >= 0; i--) {
                displayMovies();

                Console.Write("Select a movie: ");
                movie = tryConvertingStringToInt(Console.ReadLine());

                if(movie <= movieList.Count && movie > 0)
                    break;
                else if(i > 0)
                    displayInvalidInput(i);
                else
                    return;
            }

            for(int i = MAXATTEMPT; i >= 0; i--) {
                Console.Write("\nSelect a screening type [2D/3D]: ");
                screeningType = Console.ReadLine().ToUpper();

                if(screeningType.Equals("2D") || screeningType.Equals("3D"))
                    break;
                else if(i > 0)
                    displayInvalidInput(i);
                else
                    return;
            }

            for(int i = MAXATTEMPT; i >= 0; i--) {
                Console.Write("Enter a screening date and time [eg.DD/MM/YYYY HH:MM]: ");
                date = tryConvertingStringToDateTime(Console.ReadLine());

                if(date.Year != 1)
                    break;
                else if(i > 0)
                    displayInvalidInput(i);
                else
                    return;
            }

            screeningList.Add(new Screening(date, screeningType, cinemaHallList[--cinemaHall], movieList[--movie]));
            Console.WriteLine("\nMovie screening successfully created.");
        }

        // Option 3
        public static void listMovieScreening() {
            Console.WriteLine("\nOption 3. List Movie Screenings");

            int option = 0;

            for(int i = MAXATTEMPT; i >= 0; i--) {
                displayMovies();

                Console.Write("Select a movie: ");
                option = tryConvertingStringToInt(Console.ReadLine());

                if(option <= movieList.Count && option > 0)
                    break;
                else if (i > 0)
                    displayInvalidInput(i);
                else
                    return;
            }

            option--;
            Console.WriteLine(String.Format("\n{0,-20} {1,-15} {2, -25} {3, -20}",
                "Location", "Type", "Date/Time", "Seats Remaining"));

            foreach(Screening screening in screeningList) {
                if(screening.Movie == movieList[option]) {
                    Console.WriteLine(String.Format("{0,-20} {1,-15} {2, -25} {3, -20}",
                        screening.CinemaHall.Name, screening.ScreeningType,
                        screening.ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                        screening.SeatsRemaining));
                }
            }
            
        }

        // Option 4
        public static void deleteMovieScreening() {
            Console.WriteLine("\nOption 4. Delete Movie Screenings");

            for(int i = MAXATTEMPT; i >= 0; i--) {
                displayMovieScreening();

                Console.Write("Enter a screening number to delete: ");
                int numberToDelete = tryConvertingStringToInt(Console.ReadLine());

                if(numberToDelete > 0) {
                    foreach(Screening screening in screeningList) {
                        if(Int32.Parse(screening.ScreeningNo) == numberToDelete) {
                            screeningList.Remove(screening);
                            Console.WriteLine("\nScreening deleted.");
                            return;
                        }
                    }
                }

                if(i > 0)
                    displayInvalidInput(i);
                else
                    return;
            }
        }

        //////////////////// OTHER METHODS ////////////////////
        public static void displayMovies() {
            Console.WriteLine(String.Format("\n{0,-5} {1,-30} {2,-15} {3, -20} {4, -20} {5, -20}",
                "No", "Title", "Duration", "Genre", "Classification", "Opening Date"));
            int count = 0;
            foreach(Movie movie in movieList) {
                count++;
                Console.WriteLine("{0,-5} {1,-30}", count, movie.ToString());
            }
        }

        public static void displayCinemaHall() {
            Console.WriteLine(String.Format("\n{0,-5} {1,-15} {2,-15} {3, -15}",
                "No", "Cinema Name", "Hall No", "Capacity"));
            int count = 0;
            foreach (CinemaHall hall in cinemaHallList) {
                count++;
                Console.WriteLine(String.Format("{0,-5} {1,-20}", count, hall.ToString()));
            }
        }

        public static void displayMovieScreening() {
            Console.WriteLine(String.Format("\n{0,-5} {1,-20} {2,-10} {3, -35} {4, -20}",
                "No", "Location", "Hall No", "Title", "Date/Time"));
            
            foreach(Screening screening in screeningList) {
                Console.WriteLine(screening.ToString());
            }
        }

        //////////////////// ETC (Utility methods) ////////////////////
        static Object attempt(delegateReturnObject attemptRun, delegateReturnBool attemptCorrect) {
            Object obj = new Object();
            for(int i = MAXATTEMPT; i >= 0; i--) {
                obj = attemptRun();

                if(attemptCorrect(obj))
                    break;
                else if(i > 0)
                    displayInvalidInput(i);
                else
                    return null;
            }
            return obj;
        }

        public static void displayInvalidInput() {
            Console.WriteLine("You have entered an invalid option! Please try again.");
        }

        public static void displayInvalidInput(int attempts) {
            Console.WriteLine("You have entered an invalid option! Please try again.");
            Console.WriteLine("You have " + attempts.ToString() + " attempts left!");
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
