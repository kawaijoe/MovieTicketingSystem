using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.menu.commands {
    class OptionAttempt {

        //public delegate void Consumer();
        public delegate Object Consumer();
        public delegate bool ObjectPredicate(Object obj);

        private const int MAX_ATTEMPT = Program.MAX_ATTEMPT;

        public OptionAttempt() { }

        public Object run(Consumer attemptRun, ObjectPredicate attemptCorrect) {
            Object obj = new Object();
            for(int i = MAX_ATTEMPT; i >= 0; i--) {
                obj = attemptRun();

                if(attemptCorrect(obj))
                    break;
                else if(i > 0)
                    displayInvalidInput(i);
                else
                    return null;
            }
            return obj;
        }

        /*
         * Return true if the operation was a success
         * Return false if the operation was a failure
         */
        public void run(Consumer attemptRun) {
            Object obj = new Object();
            for(int i = MAX_ATTEMPT; i >= 0; i--) {
                obj = attemptRun();

                if(i > 0 && !(bool)obj)
                    displayInvalidInput(i);
                else
                    return;
            }
        }

        private void displayInvalidInput() {
            Console.WriteLine("You have entered an invalid option! Please try again.");
        }

        private void displayInvalidInput(int attempts) {
            Console.WriteLine("You have entered an invalid option! Please try again.");
            Console.WriteLine("You have " + attempts.ToString() + " attempts left!");
        }
    }
}
