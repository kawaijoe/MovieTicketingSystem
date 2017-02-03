using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Student:Ticket {

        public String LevelOfStudy;

        public Student() { }

        public Student(Screening screening, String levelOfStudy):base(screening) {
            this.LevelOfStudy = levelOfStudy;
        }

        public override double CalculatePrice() {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
