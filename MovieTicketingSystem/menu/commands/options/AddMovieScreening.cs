using MovieTicketingSystem.menu.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands.options {
    class AddMovieScreening:Command {

        // Option 2
        public AddMovieScreening() {
        }

        public void execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 2. Add Movie Screening");

            int cinemaHall = 0;
            int movie = 0;
            String screeningType = "";
            Object temptObject = new Object();
            DateTime date = new DateTime(1, 1, 1);

            // Select a cinema hall
            temptObject = attempt.run(() => {
                Display.cinemaHall();
                Console.Write("Select a cinema hall: ");
                return Utility.tryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int) obj <= Program.cinemaHallList.Count && (int) obj > 0);
            });
            if(temptObject == null) return;
            cinemaHall = (int) temptObject;

            // Select a movie
            movie = Select.Movie(attempt);
            if(movie == -1) // Selecting a movie has failed
                return;

            // Select screening type
            temptObject = attempt.run(() => {
                Console.Write("\nSelect a screening type [2D/3D]: ");
                return Console.ReadLine().ToUpper();
            },
            obj => {
                return (obj.Equals("2D") || obj.Equals("3D"));
            });
            if(temptObject == null) return;
            screeningType = (String) temptObject;

            // Enter a screening date and time
            temptObject = attempt.run(() => {
                Console.Write("Enter a screening date and time [eg.DD/MM/YYYY HH:MM]: ");
                return Utility.tryConvertingStringToDateTime(Console.ReadLine());
            },
            obj => {
                return (((DateTime)obj).Year != 1);
            });
            if(temptObject == null) return;
            date = (DateTime) temptObject;

            Program.screeningList.Add(new Screening(date, screeningType, Program.cinemaHallList[--cinemaHall], Program.movieList[--movie]));
            Console.WriteLine("\nMovie screening successfully created.");
        }

    }
}
