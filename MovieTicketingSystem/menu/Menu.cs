//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;

namespace MovieTicketingSystem.menu {
    class Menu {

        private String optionText;
        private Remote remote;

        public Menu(String optionText, Dictionary<int, Command> commandDictionary) {
            this.optionText = optionText;
            remote = new Remote(commandDictionary);
        }

        public void Run() {
            int option;
            while(true) {
                option = GetMenuOption();
                if(option == 0) break;

                remote.ExecuteCommand(option);
            }
        }

        private int GetMenuOption() {
            Console.Write(optionText);
            try {
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            } catch(FailedConversionException) {
                return -1;
            }
        }

    }
}
