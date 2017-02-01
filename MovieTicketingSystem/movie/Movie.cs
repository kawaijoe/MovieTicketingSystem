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
    class Movie {

        /* Getters and setters for public variables always makes sense */
        public String Title { get; set; }
        public int Duration { get; set; }
        public String Classification { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<Program.MovieGenre> GenreList { get; set; }

        public Movie() {
        }

        public Movie(String title, int duration, String classification, DateTime openingDate, List<Program.MovieGenre> genreList) {
            this.Title = title;
            this.Duration = duration;
            this.Classification = classification;
            this.OpeningDate = openingDate;
            this.GenreList = genreList;
        }

        /* Getter method for GenreList wts. Aren't there a get property above? o.o */
        public List<Program.MovieGenre> GetGenreList() {
            return GenreList;
        }

        /* As usual, the school teaching us to abuse the ToString() method.
         * Happy?
         */
        public override string ToString() {
            String genreString = "";
            
            foreach(Program.MovieGenre genre in GenreList) {
                genreString += genre.ToString() + ", ";
            }
            genreString = genreString.Substring(0, genreString.Length - 2);
            
            return String.Format("{0,-30} {1,-15} {2, -20} {3, -20} {4, -20}",
                    Title, Convert.ToString(Duration), genreString, Classification,
                    OpeningDate.Day.ToString() + "-" + OpeningDate.ToString("MMM") + "-" + OpeningDate.ToString("yy"));
        }

    }
}
