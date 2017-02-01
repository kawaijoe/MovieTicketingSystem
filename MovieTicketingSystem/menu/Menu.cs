using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu {
    class Menu {

        Dictionary<int, commands.Command> commandDictionary = new Dictionary<int, commands.Command>();

        public Menu() {
            //commandDictionary.Add(1, commands.ListAllMovies);
        }

        public void run() {
            while(true) {
            }
        }

        private int getMenuOption() {
            Console.Write("\nMovie Ticketing System\n" +
            "=================================\n" +
            "1.  List all movies\n" +
            "2.  Add a movie screening session\n" +
            "3.  List movie screenings\n" +
            "4.  Delete a movie screening session\n" +
            "5.  Order movie ticket/s\n" +
            "6.  Add a movie rating\n" +
            "7.  View movie ratings and comments\n" +
            "8.  Recommend movies\n" +
            "0.  Exit\n" +
            "=================================\n" +
            "Enter your option: ");
            return Utility.tryConvertingStringToInt(Console.ReadLine());
        }

    }
}
