using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class SeniorCitizen:Ticket {

        public int YearOfBirth { get; set; }

        public SeniorCitizen() { }

        public SeniorCitizen(Screening screening, int yearOfBirth):base(screening) {
            this.YearOfBirth = yearOfBirth;
        }

        public override double CalculatePrice() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
