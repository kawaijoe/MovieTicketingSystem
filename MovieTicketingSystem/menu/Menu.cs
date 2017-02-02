using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu {
    class Menu {

        private String optionText;

        public Menu(String optionText, Dictionary<int, Command> commandDictionary) {
            this.optionText = optionText;
        }

        public void run() {
            while(true) {
            }
        }

        private int getMenuOption() {
            Console.Write(optionText);
            return Utility.tryConvertingStringToInt(Console.ReadLine());
        }

    }
}
