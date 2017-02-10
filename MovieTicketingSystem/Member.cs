//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;
using System.Collections.Generic;

namespace MovieTicketingSystem {
    class Member {

        public String Name { get; }
        public DateTime Birthday { get; }
        public Dictionary<MovieGenre, int> GenreLikings { get; set; } = new Dictionary<MovieGenre, int>();

        public Member(String name ,DateTime birthday) {
            this.Name = name;
            this.Birthday = birthday;

            foreach(MovieGenre genre in Enum.GetValues(typeof(MovieGenre)))
                GenreLikings.Add(genre, 0);
        }
    }
}
