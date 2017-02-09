//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.menu.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.ticket {
    // Simple factory implementation
    class TicketFactory {

        public static Ticket CreateTicket(String type, Screening screening, OptionAttempt attempt) {
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
                    throw new SystemException(); // Throw SystemException as it can't be handled
            }

            return ticket;
        }
    }
}
