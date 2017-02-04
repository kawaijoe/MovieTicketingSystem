using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketingSystem.util {
    class Utility {

        public static int tryConvertingStringToInt(String text) {
            int n;
            return int.TryParse(text, out n) ? n : -1;
        }

        public static DateTime tryConvertingStringToDateTime(String text) {
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

    }
}
