//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.util;
using System;

namespace MovieTicketingSystem.menu.commands.options {
    class DeleteMovieScreening:Command {

        OptionAttempt attempt;

        // Option 4
        public DeleteMovieScreening() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 4. Delete Movie Screenings");

            this.attempt = attempt;
            DeleteScreening();
        }

        private void DeleteScreening() {
            attempt.Run(() => {
                Display.movieScreening();

                Console.Write("Enter a screening number to delete: ");
                int numberToDelete = Utility.TryConvertingStringToInt(Console.ReadLine());

                if(numberToDelete > 0) {
                    foreach(Screening screening in Program.screeningList) {
                        if(Int32.Parse(screening.ScreeningNo) == numberToDelete) {
                            Program.screeningList.Remove(screening);
                            Console.WriteLine("\nScreening deleted.");
                            return true; // Return true since the operation is a success
                        }
                    }
                }
                return false; // Return false since the operation is a failure
            });
        }

    }
}
