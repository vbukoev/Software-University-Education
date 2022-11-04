using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05DateModifier
{
    public class DateModifier
    {
        public static double GetDaysBetweenDates(string one, string two)
        {
            var firstDay = DateTime.ParseExact(one, "yyyy MM dd", CultureInfo.InvariantCulture);
            var secondDay = DateTime.ParseExact(two, "yyyy MM dd", CultureInfo.InvariantCulture);

            if (firstDay > secondDay) return GetDaysBetweenDates(two, one);

            System.TimeSpan diff = secondDay - firstDay;
            return Math.Abs(diff.Days);

            // another solution
            //var firstDay = DateTime.Parse(one);
            //var secondDay = DateTime.Parse(two);

            //if (firstDay > secondDay) return GetDaysBetweenDates(two, one);

            //System.TimeSpan diff = secondDay - firstDay;
            //return Math.Abs(diff.Days);
        }
    }
}