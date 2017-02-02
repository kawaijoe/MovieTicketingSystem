using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.util {
    class OptionAttempt {

        public delegate Object delegateReturnObject();
        public delegate bool delegateReturnBool(Object obj);

        public delegateReturnObject attemptRun;
        public delegateReturnBool attemptIsCorrect;

        private const int MAX_ATTEMPT = Program.MAXATTEMPT;

        public OptionAttempt() {
        }

        public Object attempt(delegateReturnObject attemptRun, delegateReturnBool attemptCorrect) {
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

        private void displayInvalidInput() {
            Console.WriteLine("You have entered an invalid option! Please try again.");
        }

        private void displayInvalidInput(int attempts) {
            Console.WriteLine("You have entered an invalid option! Please try again.");
            Console.WriteLine("You have " + attempts.ToString() + " attempts left!");
        }
    }
}
