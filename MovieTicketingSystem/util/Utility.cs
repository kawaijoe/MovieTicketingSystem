//============================================================
// Student Number	: S10173251C, S10166858B
// Student Name	    : Chin Wei Hong, Joe Kawai
// Module  Group	: IT04
//============================================================
using System;
using System.Globalization;

namespace MovieTicketingSystem.util {
    class Utility {

        // Returns -1 if convertion is unsuccessful
        public static int TryConvertingStringToInt(String text) {
            int n;
            if(!int.TryParse(text, out n))
                throw new FailedConversionException();
            return n;
        }

        // Returns DateTime.Year == 1 if convertion is unsucessful
        public static DateTime TryConvertingStringToDateTime(String text) {
            DateTime date;
            string[] formats = { "dd/MM/yyyy HH:mm", "dd/MM/yyyy", "yyyy" };
            if(!DateTime.TryParseExact(text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                throw new FailedConversionException();
            return date;
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
