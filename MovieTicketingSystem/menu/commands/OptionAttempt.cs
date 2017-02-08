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

// DO NOT EDIT THIS CLASS. This class is closed for any modification :)
namespace MovieTicketingSystem.menu.commands {
    class OptionAttempt {

        public delegate Object Consumer();
        public delegate bool ObjectPredicate(Object obj);

        private const int MAX_ATTEMPT = Program.MAX_ATTEMPT;

        public OptionAttempt() { }

        public Object Run(Consumer attemptRun, ObjectPredicate attemptCorrect) {
            Object obj = new Object();
            for(int i = MAX_ATTEMPT; i >= 0; i--) {
                obj = attemptRun();

                if(attemptCorrect(obj))
                    break;
                else if(i > 0)
                    DisplayInvalidInput(i);
                else
                    return null;
            }
            return obj;
        }

        /*
         * Return true if the operation was a success
         * Return false if the operation was a failure
         */
        public void Run(Consumer attemptRun) {
            Object obj = new Object();
            for(int i = MAX_ATTEMPT; i >= 0; i--) {
                obj = attemptRun();

                if(i > 0 && !(bool)obj)
                    DisplayInvalidInput(i);
                else
                    return;
            }
        }

        private void DisplayInvalidInput() {
            Console.WriteLine("You have entered an invalid option! Please try again.");
        }

        private void DisplayInvalidInput(int attempts) {
            Console.WriteLine("You have entered an invalid option! Please try again.");
            Console.WriteLine("You have " + attempts.ToString() + " attempts left!");
        }
    }
}
