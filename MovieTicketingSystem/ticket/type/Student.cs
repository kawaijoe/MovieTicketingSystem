using MovieTicketingSystem.menu.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Student:Ticket {

        public String LevelOfStudy = null;

        public Student() { }

        public Student(Screening screening, OptionAttempt attempt):base(screening) {
            Object temptObj = new Object();

            temptObj = attempt.run(() => {
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
            throw new NotImplementedException();
        }

        public override string ToString() {
            return "";
        }
    }
}
