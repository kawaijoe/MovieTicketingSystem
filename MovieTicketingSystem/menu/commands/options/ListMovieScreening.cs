﻿using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {
    class ListMovieScreening:Command {

        // Option 3
        public ListMovieScreening() { }

        public void execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 3. List Movie Screenings");

            int option = 0;
            Object temptObject = new Object();

            temptObject = attempt.run(() => {
                Display.movies();

                Console.Write("Select a movie: ");
                return Utility.tryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int) obj <= Program.movieList.Count && (int) obj > 0);
            });
            if(temptObject == null) return;
            option = (int) temptObject;

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
