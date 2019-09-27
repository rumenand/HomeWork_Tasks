using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_5._Date_Modifier___Core
{
    public class DateModifier
    {
        public static int CalculateDifference(string date1, string date2)
        {
            var StartDate = DateTime.Parse(date1);
            var EndDate = DateTime.Parse(date2);
            return Math.Abs((int)(EndDate - StartDate).TotalDays);
        }
    }
}
