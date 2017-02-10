//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.util;
using System;

namespace MovieTicketingSystem.menu.commands.options {
    class ListAllMovies:Command {
    
        // Option 1
        public ListAllMovies() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 1. List All Movies");
            Display.Movies();
        }
    }
}
