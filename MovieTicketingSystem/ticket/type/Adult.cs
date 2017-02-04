using MovieTicketingSystem.menu.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Adult:Ticket {

        public bool? PopcornOffer { get; set; } = null;

        public Adult() { }

        public Adult(Screening screening, OptionAttempt attempt):base(screening) {
            Object temptObj = new Object();

            temptObj = attempt.run(() => {
                Console.Write("Would you like to buy a popcorn set for $3.00 [Y/N]: ");
                return Console.ReadLine().ToUpper();
            },
            obj => {
                return obj.Equals("Y") ||
                    obj.Equals("N");
            });
            if(temptObj == null) return;
            PopcornOffer = temptObj.Equals("Y") ? true : false;
        }

        public override double CalculatePrice() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
