using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {
    class ListAllMovies:Command {
    
        // Option 1
        public ListAllMovies() { }

        public void execute() {
            Console.WriteLine("\nOption 1. List All Movies");
            displayMovies();
        }
    }
}
