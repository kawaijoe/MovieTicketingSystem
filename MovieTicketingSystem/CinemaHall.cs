//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class CinemaHall {
        public String Name { get; set; }
        public int HallNo { get; set; }
        public int Capacity { get; set; }


        public CinemaHall() {
        }

        public CinemaHall(String name, int hallNo, int capacity) {
            this.Name = name;
            this.HallNo = hallNo;
            this.Capacity = capacity;
        }

        public override string ToString() {
            return String.Format("{0,-15} {1,-15} {2, -15}", Name, HallNo, Capacity);
        }
    }
}
