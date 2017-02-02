using MovieTicketingSystem.util;
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

        public void executeCommand(int option) {
            Command command;
            command = commandDictionary.TryGetValue(option, out command) ? command : null;
            if(command == null) Console.WriteLine("You have entered an invalid option! Please try again.");
            command.execute(attempt);
        }

    }
}
