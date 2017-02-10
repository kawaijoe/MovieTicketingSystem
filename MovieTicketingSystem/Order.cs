//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.ticket;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MovieTicketingSystem {
    class Order {
        public static int OrderCount { get; set; } = 0;
        public String OrderNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double Amount { get; set; }
        public String Status { get; set; }
        public List<Ticket> TicketList { get; set; } = new List<Ticket>();

        public Order() {
            OrderNo = (++OrderCount).ToString();
        }

        public void AddTicket(Ticket ticket) {
            TicketList.Add(ticket);
        }

        public List<Ticket> GetTicketList() {
            return TicketList;
        }

        public override string ToString() {
            return String.Format("{0,-5} {1,-20} {2,-20} {3, -20}",
                OrderNo, OrderDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                Amount, Status);
        }
    }
}
