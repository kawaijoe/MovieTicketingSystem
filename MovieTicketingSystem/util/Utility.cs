//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.util {
    class Utility {

        public static int TryConvertingStringToInt(String text) {
            int n;
            return int.TryParse(text, out n) ? n : -1;
        }

        public static DateTime TryConvertingStringToDateTime(String text) {
            DateTime date;
            string[] formats = { "dd/MM/yyyy HH:mm", "yyyy" };
            return DateTime.TryParseExact(text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
                ? date : new DateTime(1, 1, 1, 1, 1, 1);
        }

        public static bool IsFridayToSunday(DateTime date) {
            return date.DayOfWeek == DayOfWeek.Friday ||
                date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsFirstSevenDaysOfOpening(Screening screening) {
            return screening.ScreeningDateTime.Date > screening.Movie.OpeningDate.AddDays(7).Date;
        }

    }
}
