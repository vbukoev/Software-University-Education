using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05DateModifier
{
    public class DateModifier
    {
        internal static double GetDaysBetweenDates(string one, string two)
        {
            var first = DateTime.ParseExact(one, "yyyy MM dd", CultureInfo.InvariantCulture);
            var sec = DateTime.ParseExact(two, "yyyy MM dd", CultureInfo.InvariantCulture);

            if (first > sec) return GetDaysBetweenDates(two, one);

            var diff = sec - first;
            return diff.Days;
        }
    }
}
