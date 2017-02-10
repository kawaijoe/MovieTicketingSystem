//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.util;
using System;

namespace MovieTicketingSystem.menu.commands.options {
    class AddMovieScreening:Command {

        private OptionAttempt attempt;

        // Option 2
        public AddMovieScreening() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 2. Add Movie Screening");

            this.attempt = attempt;
            int cinemaHall = SelectCinemaHall();
            int movieIndex = Select.Movie(attempt);
            String screeningType = SelectScreeningType();
            DateTime date = SelectScreeningDateTime(movieIndex);

            Program.screeningList.Add(new Screening(date, screeningType, Program.cinemaHallList[--cinemaHall],
                Program.movieList[--movieIndex]));
            Console.WriteLine("\nMovie screening successfully created.");
        }

        private int SelectCinemaHall() {
            return (int) attempt.Run(() => {
                Display.CinemaHall();
                Console.Write("Select a cinema hall: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int) obj <= Program.cinemaHallList.Count);
            });
        }

        private String SelectScreeningType() {
            return (String) attempt.Run(() => {
                Console.Write("\nSelect a screening type [2D/3D]: ");
                return Console.ReadLine().ToUpper();
            },
            obj => {
                return (obj.Equals("2D") || obj.Equals("3D"));
            });
        }

        private DateTime SelectScreeningDateTime(int movieIndex) {
            return (DateTime) attempt.Run(() => {
                Console.Write("Enter a screening date and time [eg.DD/MM/YYYY HH:MM]: ");
                return Utility.TryConvertingStringToDateTime(Console.ReadLine());
            },
            obj => {
                return ((((DateTime) obj).Year != 1) && ((DateTime) obj).Date >= Program.movieList[movieIndex - 1].OpeningDate.Date);
            });
        }

    }
}
