using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem {
    class Screening {
        public static int ScreeningCount { get; set; } = 1000;
        public String ScreeningNo { get; set; }
        public DateTime ScreeningDateTime { get; set; }
        public String ScreeningType { get; set; }
        public int SeatsRemaining { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Movie Movie { get; set; }

        public Screening() {
        }

        public Screening(DateTime screeningDateTime, String screeningType, CinemaHall cinemaHall, Movie movie) {
            ScreeningNo = (++ScreeningCount).ToString();
            this.ScreeningDateTime = screeningDateTime;
            this.ScreeningType = screeningType;
            this.CinemaHall = cinemaHall;
            this.Movie = movie;
        }

        public override string ToString() {
            return String.Format("{0,-5} {1,-20} {2,-10} {3, -20}",
                ScreeningNo, CinemaHall.Name, CinemaHall.HallNo, Movie.Title,
                ScreeningDateTime.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
        }
    }
}
