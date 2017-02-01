using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    abstract class Attempt {

        public const int MAXATTEMPT = 3;

        public Attempt() {
        }

        public abstract Object run();

        public abstract Boolean check(Object obj);

        public Object running() {
            Object obj = new Object();
            for(int i = MAXATTEMPT; i >= 0; i--) {
                obj = run();

                if(check(obj))
                    break;
                else if(i > 0)
                    displayInvalidInput(i);
                else
                    return -1;
            }
            return obj;
        }

        private void displayInvalidInput(int attempts) {
            Console.WriteLine("You have entered an invalid option! Please try again.");
            Console.WriteLine("You have " + attempts.ToString() + " attempts left!");
        }

    }
}
