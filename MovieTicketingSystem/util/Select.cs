using MovieTicketingSystem.menu.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.util {
    class Select {
        
        private static Object temptObject = new Object();

        public static int Movie(OptionAttempt attempt) {
            temptObject = attempt.run(() => {
                Display.movies();

                Console.Write("Select a movie: ");
                return Utility.tryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int) obj <= Program.movieList.Count && (int) obj > 0);
            });
            if(temptObject == null) return -1; // Return -1 if failed
            return (int) temptObject;
        }


    }
}
