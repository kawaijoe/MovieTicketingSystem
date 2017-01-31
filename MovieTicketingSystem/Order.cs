using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Order {
        public static int OrderCount { get; set; } = 0;
        public String OrderNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double Amount { get; set; }
        public String Status { get; set; }
        public List<Ticket> TicketList { get; set; }

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
            return base.ToString();
        }
    }
}
