using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MovieTicketingSystem.ticket;
using MovieTicketingSystem.util;

namespace MovieTicketingSystem.menu.commands.options {
    class OrderMovieTicket:Command {

        public OrderMovieTicket() { }

        public void execute(OptionAttempt attempt) {
            Console.WriteLine("\nOption 5. Order Movie Tickets");

            Object temptObject = new Object();
            int movie;
            Screening session = null;
            int numOfTickets;
            List<Ticket> ticketList = new List<Ticket>();
            Order order = new Order();
            order.Status = "Unpaid";

            // Select a movie
            movie = Select.Movie(attempt);
            if(movie == -1) // Selecting a movie has failed
                return;
            movie--; // Adjust movie for indexing

            // Select a session
            temptObject = attempt.run(() => {
                Console.WriteLine(String.Format("{0, -5} {1,-20} {2,-15} {3, -25} {4, -20}",
               "No", "Location", "Type", "Date/Time", "Seats Remaining"));
                foreach(Screening screening in Program.screeningList) {
                    if(screening.Movie == Program.movieList[movie]) {
                        Console.WriteLine(String.Format("{0, -5} {1,-20} {2,-15} {3, -25} {4, -20}",
                            screening.ScreeningNo, screening.CinemaHall.Name, screening.ScreeningType,
                            screening.ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                            screening.SeatsRemaining));
                    }
                }
                Console.Write("Select a session: ");
                return Utility.tryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                List<int> correctList = new List<int>();
                foreach(Screening screening in Program.screeningList) {
                    if(screening.Movie == Program.movieList[movie]) {
                        correctList.Add(Int32.Parse(screening.ScreeningNo));
                    }
                }
                return (correctList.Contains((int) obj));
            });
            if(temptObject == null) return;
            foreach(Screening screening in Program.screeningList) {
                if(screening.ScreeningNo.Equals(temptObject)) {
                    session = screening;
                    break;
                }
            }

            // Number of tickets you wish to purchase
            temptObject = attempt.run(() => {
                Console.Write("Please enter number of tickets you wish to purchase: ");
                return Utility.tryConvertingStringToInt(Console.ReadLine());
            },
            obj => {
                return (int) obj > 0;
            });
            if(temptObject == null) return;
            numOfTickets = (int) temptObject;

            // Movie Classification
            temptObject = attempt.run(() => {
                Console.Write("The movie classification is " +
                    Program.movieList[movie].Classification.ToString() +
                    ". Does every ticket holder meet the age requirements [Y/N]? ");
                return Console.ReadLine().ToUpper();
            },
            obj => {
                return obj.Equals("N") || obj.Equals("Y");
            });
            if(temptObject == null || temptObject.Equals("N")) return;

            // Ordering of tickets
            for(int i = 1; i <= numOfTickets; i++) {

                // Get ticket type
                temptObject = attempt.run(() => {
                    Console.WriteLine("Ticket #" + i);
                    Console.Write("Type of ticket to purchase [Student/Senior/Adult]: ");
                    return Console.ReadLine().ToUpper();
                },
                obj => {
                    return obj.Equals("ADULT") ||
                    obj.Equals("SENIOR") ||
                    obj.Equals("SENIORCITIZEN") ||
                    obj.Equals("STUDENT");
                });
                if(temptObject == null) return;

                // Hand resposibility over to TicketFactory
                Ticket ticket = TicketFactory.createTicket((String) temptObject, session, attempt);

                // Check if an error has occurred
                if(ticket is Adult && ((Adult)ticket).PopcornOffer == null) return;
                else if(ticket is SeniorCitizen && ((SeniorCitizen)ticket).YearOfBirth == null) return;
                else if(ticket is Student && ((Student)ticket).LevelOfStudy == null) return;

                order.AddTicket(ticket);
            }

            // Order Summary
            Console.WriteLine("Order #" + order.OrderNo);
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

            // Ending
            Console.WriteLine("Press any key to make payment...");
            order.Status = "Paid";
            Console.WriteLine("Thank you for visiting Singa Cineplexes. Have a great movie!");
        }
    }
}
