//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
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
            YearOfBirth = ((DateTime) attempt.Run(() => {
                Console.Write("Please enter year of birth [YYYY]: ");
                return Utility.TryConvertingStringToDateTime(Console.ReadLine());
            },
            obj => {
                return DateTime.Today.Year - 55 >= ((DateTime) obj).Year;
            })).Year;
        }

        public override double CalculatePrice() {
            if(Screening.ScreeningType.Equals("2D")) {
                if(Utility.IsFridayToSunday(Screening.ScreeningDateTime)) {
                    return 12.50;
                } else if(Utility.IsFirstSevenDaysOfOpening(Screening)) {
                    return 8.50;
                }
                return 5.00;
            } else { // 3D Movie
                if(Utility.IsFridayToSunday(Screening.ScreeningDateTime)) {
                    return 14.00;
                } else if(Utility.IsFirstSevenDaysOfOpening(Screening)) {
                    return 11.00;
                }
                return 6.00;
            }
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
