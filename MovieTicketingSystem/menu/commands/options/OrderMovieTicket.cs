using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTicketingSystem.menu.util;
using System.Globalization;

namespace MovieTicketingSystem.menu.commands.options {
    class OrderMovieTicket:Command {

        public OrderMovieTicket() { }

        public void execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 5. Order Movie Tickets");

            Object temptObject = new Object();
            int movie;
            int session;

            // Select a movie
            movie = Select.Movie(attempt);
            if(movie == -1) // Selecting a movie has failed
                return;

            // Select a session
            Console.WriteLine(String.Format("\n{0,-20} {1,-15} {2, -25} {3, -20}",
                "Location", "Type", "Date/Time", "Seats Remaining"));
            foreach(Screening screening in Program.screeningList) {
                if(screening.Movie == Program.movieList[movie-1]) {
                    Console.WriteLine(String.Format("{0,-20} {1,-15} {2, -25} {3, -20}",
                        screening.CinemaHall.Name, screening.ScreeningType,
                        screening.ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                        screening.SeatsRemaining));
                }
            }

            Console.WriteLine("Select a session: ");
            Display.movieScreening();
            Console.Write("Enter a screening number to delete: ");
            int numberToDelete = Utility.tryConvertingStringToInt(Console.ReadLine());

        }
    }
}
