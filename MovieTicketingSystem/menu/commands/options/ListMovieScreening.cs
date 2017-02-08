//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands.options {
    class ListMovieScreening:Command {

        // Option 3
        public ListMovieScreening() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 3. List Movie Screenings");

            int option = 0;
            Object temptObject = new Object();

            // Select a movie
            option = Select.Movie(attempt);
            if(option == -1) // Selecting a movie has failed
                return;

            option--;
            Console.WriteLine(String.Format("\n{0,-20} {1,-15} {2, -25} {3, -20}",
                "Location", "Type", "Date/Time", "Seats Remaining"));

            foreach(Screening screening in Program.screeningList) {
                if(screening.Movie == Program.movieList[option]) {
                    Console.WriteLine(String.Format("{0,-20} {1,-15} {2, -25} {3, -20}",
                        screening.CinemaHall.Name, screening.ScreeningType,
                        screening.ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                        screening.SeatsRemaining));
                }
            }
        }
    }
}
