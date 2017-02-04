using MovieTicketingSystem.menu.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.ticket {

    // Simple factory implementation
    class TicketFactory {

        public static Ticket createTicket(String type, Screening screening, OptionAttempt attempt) {
            type = type.ToUpper();
            Ticket ticket;

            switch(type) {
                case "ADULT":
                    ticket = new Adult(screening, attempt);
                    break;

                case "SENIOR":
                case "SENIORCITIZEN":
                    ticket = new SeniorCitizen(screening, attempt);
                    break;

                case "STUDENT":
                    ticket = new Student(screening, attempt);
                    break;

                default:
                    ticket = null;
                    break;
            }

            return ticket;
        }
    }
}
