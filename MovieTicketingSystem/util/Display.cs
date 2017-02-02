using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {
    class Display {

        public static void movies() {
            Console.WriteLine(String.Format("\n{0,-5} {1,-30} {2,-15} {3, -20} {4, -20} {5, -20}",
                "No", "Title", "Duration", "Genre", "Classification", "Opening Date"));
            int count = 0;
            foreach(Movie movie in Program.movieList) {
                count++;
                Console.WriteLine("{0,-5} {1,-30}", count, movie.ToString());
            }
        }

        public static void cinemaHall() {
            Console.WriteLine(String.Format("\n{0,-5} {1,-15} {2,-15} {3, -15}",
                "No", "Cinema Name", "Hall No", "Capacity"));
            int count = 0;
            foreach(CinemaHall hall in Program.cinemaHallList) {
                count++;
                Console.WriteLine(String.Format("{0,-5} {1,-20}", count, hall.ToString()));
            }
        }

        public static void movieScreening() {
            Console.WriteLine(String.Format("\n{0,-5} {1,-20} {2,-10} {3, -35} {4, -20}",
                "No", "Location", "Hall No", "Title", "Date/Time"));

            foreach(Screening screening in Program.screeningList) {
                Console.WriteLine(screening.ToString());
            }
        }

    }
}
