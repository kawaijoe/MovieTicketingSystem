using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.ticket {

    // Simple factory implementation
    class TicketFactory {

        /*
         * NOTE: I did not implement any try and catch statement to catch a cast exception as it
         *       will be unrecoverable. Essentially, there is nothing we can do to fix the problem.
         */
        public static Ticket createTicket(String type, Screening screening, Object obj) {
            type = type.ToUpper();
            Ticket ticket;

            switch(type) {
                case "ADULT":
                    ticket = new Adult(screening, (bool)obj);
                    break;

                case "SENIOR":
                case "SENIORCITIZEN":
                    ticket = new SeniorCitizen(screening, (int)obj);
                    break;

                case "STUDENT":
                    ticket = new Student(screening, (String)obj);
                    break;

                default:
                    ticket = null;
                    break;
            }

            return ticket;
        }
    }
}
