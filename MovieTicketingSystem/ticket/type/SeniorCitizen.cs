using MovieTicketingSystem.menu.commands;
using MovieTicketingSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class SeniorCitizen:Ticket {

        public int? YearOfBirth { get; set; } = null;

        public SeniorCitizen() { }

        public SeniorCitizen(Screening screening, OptionAttempt attempt):base(screening) {
            Object temptObj = new Object();

            temptObj = attempt.run(() => {
                Console.Write("Please enter year of birth [YYYY]: ");
                return Utility.tryConvertingStringToDateTime(Console.ReadLine());
            },
            obj => {
                int currentYear = DateTime.Today.Year;
                return ((DateTime) obj).Year != 1 &&
                    currentYear - 55 >= ((DateTime) obj).Year;
            });
            if(temptObj == null) return;
            YearOfBirth = ((DateTime)temptObj).Year;
        }

        public override double CalculatePrice() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
