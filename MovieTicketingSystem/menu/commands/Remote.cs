//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {
    class Remote {

        Dictionary<int, Command> commandDictionary = new Dictionary<int, Command>();
        OptionAttempt attempt = new OptionAttempt();

        public Remote(Dictionary<int, Command> commandDictionary) {
            this.commandDictionary = commandDictionary;
        }

        public void ExecuteCommand(int option) {
            Command command;
            command = commandDictionary.TryGetValue(option, out command) ? command : null;
            if(command == null) {
                Console.WriteLine("You have entered an invalid option! Please try again.");
            } else {
                try {
                    command.Execute(attempt);
                } catch(InvalidOptionException) {
                    // Pretty much do nothing :P
                    // Automatically kicks user out back to the main menu
                }
            }
        }

    }
}
