//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;
using System.Collections.Generic;
using System.Globalization;
using MovieTicketingSystem.ticket;
using MovieTicketingSystem.util;

namespace MovieTicketingSystem.menu.commands.options {
    class OrderMovieTicket:Command {

        OptionAttempt attempt;

        // Option 5
        public OrderMovieTicket() { }

        public void Execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 5. Order Movie Tickets");

            this.attempt = attempt;
            List<Ticket> ticketList = new List<Ticket>();
            Order order = new Order();
            order.Status = "Unpaid";

            int movieIndex = Select.Movie(attempt) - 1;
            Screening session = SelectSession(movieIndex);
            int numOfTickets = GetNoOfTicket(session);
            CheckMovieClassification(movieIndex);

            // Ordering of tickets
            for(int i = 1; i <= numOfTickets; i++) {
                Console.WriteLine("\nTicket #" + i);
                // Hand resposibility over to TicketFactory
                Ticket ticket = TicketFactory.CreateTicket(GetTicketType(), session, attempt);
                order.AddTicket(ticket);
            }

            session.SeatsRemaining -= numOfTickets;
            PrintOrderSummary(order, session);
        }

        private Screening SelectSession(int movieIndex) {
            int sessionIndex = (int) attempt.Run(() => {
                Console.WriteLine(String.Format("\n{0, -5} {1,-20} {2,-15} {3, -25} {4, -20}",
               "No", "Location", "Type", "Date/Time", "Seats Remaining"));
                foreach(Screening screening in Program.screeningList) {
                    if(screening.Movie == Program.movieList[movieIndex]) {
                        Console.WriteLine(String.Format("{0, -5} {1,-20} {2,-15} {3, -25} {4, -20}",
                            screening.ScreeningNo, screening.CinemaHall.Name, screening.ScreeningType,
                            screening.ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                            screening.SeatsRemaining));
                    }
                }
                Console.Write("Select a session: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                List<int> correctList = new List<int>();
                foreach(Screening screening in Program.screeningList) {
                    if(screening.Movie == Program.movieList[movieIndex]) {
                        correctList.Add(Int32.Parse(screening.ScreeningNo));
                    }
                }
                return (correctList.Contains((int) obj));
            });

            foreach(Screening screening in Program.screeningList) {
                if(screening.ScreeningNo.Equals(sessionIndex.ToString())) {
                    return screening;
                }
            }
            return null; // Should never return null
        }

        private int GetNoOfTicket(Screening session) {
            return (int) attempt.Run(() => {
                Console.Write("\nPlease enter number of tickets you wish to purchase: ");
                return Utility.TryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return (int) obj > 0 && (int) obj <= session.SeatsRemaining;
            });
        }

        private void CheckMovieClassification(int movieIndex) {
            attempt.Run(() => {
                Console.Write("The movie classification is " +
                    Program.movieList[movieIndex].Classification.ToString() +
                    ". Does every ticket holder meet the age requirements [Y/N]? ");
                String text = Console.ReadLine().ToUpper();
                if(text.Equals("N"))
                    throw new InvalidOptionException(); // Kicks user out to main menu
                return text;
            },
            obj => {
                return obj.Equals("Y");
            });
        }

        private String GetTicketType() {
            return (String) attempt.Run(() => {
                Console.Write("Type of ticket to purchase [Student/Senior/Adult]: ");
                return Console.ReadLine().ToUpper();
            },
                obj => {
                    return obj.Equals("ADULT") ||
                    obj.Equals("SENIOR") ||
                    obj.Equals("SENIORCITIZEN") ||
                    obj.Equals("STUDENT");
                });
        }

        private void PrintOrderSummary(Order order, Screening session) {
            Console.WriteLine("\nOrder #" + order.OrderNo);
            Console.WriteLine("==========");
            Console.WriteLine("Movie title: " + session.Movie.Title);
            Console.WriteLine("Cinema: " + session.CinemaHall.Name);
            Console.WriteLine("Hall: " + session.CinemaHall.HallNo);
            Console.WriteLine("Date/Time: " + session.ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt",
                CultureInfo.InvariantCulture));
            double totalCost = 0;
            foreach(Ticket ticket in order.GetTicketList()) {
                totalCost += ticket.CalculatePrice();
            }
            Console.WriteLine("\nTotal: $" + String.Format("{0:0.00}", totalCost));
            Console.WriteLine("==========");

            Console.WriteLine("Press any key to make payment...");
            order.Status = "Paid";
            Console.WriteLine("Thank you for visiting Singa Cineplexes. Have a great movie!");
        }

    }
}
