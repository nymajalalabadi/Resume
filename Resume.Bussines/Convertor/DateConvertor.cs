using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateOnly value)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            DateTime dateTime = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);

            return persianCalendar.GetYear(dateTime) + "/" +
                   persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
                   persianCalendar.GetDayOfMonth(dateTime).ToString("00");
        }
    }
}
