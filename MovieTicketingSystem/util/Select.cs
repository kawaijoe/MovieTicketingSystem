//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
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
            return (int) attempt.Run(() => {
                Display.Movies();

                Console.Write("Select a movie: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return ((int) obj <= Program.movieList.Count && (int) obj > 0);
            });
        }

        public static double MovieRating(Movie movie) {
            int total = 0;
            int count = 0;

            for(int i = 0; i < Program.movieRatingList.Count; i++) {
                if(movie == Program.movieRatingList[i].Movie) {
                    total += Program.movieRatingList[i].Rating;
                    count++;
                }
            }
            if(count == 0) count++;
            return total/count;
        }

    }
}
