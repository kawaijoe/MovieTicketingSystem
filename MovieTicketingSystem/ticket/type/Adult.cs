using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Adult:Ticket {

        public bool PopcornOffer { get; set; }

        public Adult() { }

        public Adult(Screening screening, bool popcornOffer):base(screening) {
            this.PopcornOffer = popcornOffer;
        }

        public override double CalculatePrice() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
