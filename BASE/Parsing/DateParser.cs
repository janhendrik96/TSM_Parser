using System;
using System.Globalization;
using System.Linq;

namespace Kindle.IntegrationUtilities.RMB
{
    public static class DateParser
    {
        // LOOK AT MAKING IT AN INTERFACE:
        public static DateTime Parse(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                throw new ArgumentNullException(nameof(date), "Date must not be null");
            }
            if (date.Length != 6 || (!DateTime.TryParseExact(
                                                         date,
                                                         "yyMMdd",
                                                         CultureInfo.InvariantCulture,
                                                         DateTimeStyles.None,
                                                         out DateTime d)))
            {
                throw new FormatException("Date has to be given in the form yyMMdd");
            }
            if (!date.All(char.IsNumber))
            {
                throw new FormatException("Date must only contain numbers 0-9");
            }

            string century = DateTime.Today.Year.ToString();
            century = $"{century.Substring(0, 2)}00";
            //int century = GetCenturyFromYear(DateTime.Today.Year);;

            var year = int.Parse(century) + int.Parse(date.Substring(0, 2));
            var month = int.Parse(date.Substring(2, 2));
            var day = int.Parse(date.Substring(4, 2));

            return new DateTime(year, month, day);
        }

        public static int GetCenturyFromYear(int year)
        {
            //return (int)(year / 100) + ((year % 100 == 0) ? 0 : 1);
            return ((int)(year / 100) + ((year % 100 == 0) ? 0 : 1) - 1); // ADD -1 because of century being one year ahead of current
        }
    }
}
