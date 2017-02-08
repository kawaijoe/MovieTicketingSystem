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
    class Student:Ticket {

        public String LevelOfStudy { get; set; } = null;

        public Student() { }

        public Student(Screening screening, OptionAttempt attempt):base(screening) {
            Object temptObj = new Object();

            temptObj = attempt.Run(() => {
                Console.Write("Please enter level of study [Primary/Secondary/Tertiary]: ");
                return Console.ReadLine().ToUpper();
            },
            obj => {
                return obj.Equals("PRIMARY") ||
                    obj.Equals("SECONDARY") ||
                    obj.Equals("TERTIARY");
            });
            if(temptObj == null) return;
            LevelOfStudy = (String) temptObj;
        }

        public override double CalculatePrice() {
            if(Screening.ScreeningType.Equals("2D")) {
                if(Utility.IsFridayToSunday(Screening.ScreeningDateTime)) {
                    return 12.50;
                } else if(Utility.IsFirstSevenDaysOfOpening(Screening)) {
                    return 8.50;
                }
                return 7.00;
            } else { // 3D Movie
                if(Utility.IsFridayToSunday(Screening.ScreeningDateTime)) {
                    return 14.00;
                } else if(Utility.IsFirstSevenDaysOfOpening(Screening)) {
                    return 11.00;
                }
                return 8.00;
            }
        }

        public override string ToString() {
            return LevelOfStudy;
        }
    }
}
