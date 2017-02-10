//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.ticket;
using MovieTicketingSystem.util;
using System;

namespace MovieTicketingSystem {
    class Adult:Ticket {

        public bool PopcornOffer { get; set; }

        public Adult() { }

        public Adult(Screening screening, OptionAttempt attempt):base(screening) {
            PopcornOffer = attempt.Run(() => {
                Console.Write("Would you like to buy a popcorn set for $3.00 [Y/N]: ");
                return Console.ReadLine().ToUpper();
            },
            obj => {
                return obj.Equals("Y") ||
                    obj.Equals("N");
            }).Equals("Y") ? true : false;
        }

        public override double CalculatePrice() {
            double cost = 0.00;

            if(Screening.ScreeningType.Equals("2D")) {
                if(Utility.IsFridayToSunday(Screening.ScreeningDateTime))
                    cost += 12.50;
                else
                    cost += 8.50;
            } else { // 3D Movie
                if(Utility.IsFridayToSunday(Screening.ScreeningDateTime))
                    cost += 14.00;
                else
                    cost += 11.00;
            }

            if(PopcornOffer) cost += 3.00;
            return cost;
        }

        public override string ToString() {
            return PopcornOffer.ToString();
        }
    }
}
