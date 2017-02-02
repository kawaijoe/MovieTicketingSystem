﻿using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {
    class DeleteMovieScreening:Command {

        // Option 4
        public DeleteMovieScreening() { }

        public void execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 4. Delete Movie Screenings");

            // Enter a screening date and time
            attempt.run(() => {
                Display.movieScreening();

                Console.Write("Enter a screening number to delete: ");
                int numberToDelete = Utility.tryConvertingStringToInt(Console.ReadLine());

                if(numberToDelete > 0) {
                    foreach(Screening screening in Program.screeningList) {
                        if(Int32.Parse(screening.ScreeningNo) == numberToDelete) {
                            Program.screeningList.Remove(screening);
                            Console.WriteLine("\nScreening deleted.");
                            // Return true since the operation is a success
                            return true;
                        }
                    }
                }
                // Return false since the operation is a failure
                return false;
            });

        }
    }
}
