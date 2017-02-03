using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.menu.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu {
    class Menu {

        private String optionText;
        private Remote remote;

        public Menu(String optionText, Dictionary<int, Command> commandDictionary) {
            this.optionText = optionText;
            remote = new Remote(commandDictionary);
        }

        public void run() {
            int option;
            while(true) {
                option = getMenuOption();
                if(option == 0) break;

                remote.executeCommand(option);
            }
        }

        private int getMenuOption() {
            Console.Write(optionText);
            return Utility.tryConvertingStringToInt(Console.ReadLine());
        }

    }
}
