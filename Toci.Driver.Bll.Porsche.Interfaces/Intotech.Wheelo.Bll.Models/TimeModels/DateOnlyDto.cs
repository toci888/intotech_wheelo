using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.TimeModels
{
    public class DateOnlyDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateOnlyDto()
        {

        }

        public DateOnlyDto(DateOnly date)
        {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
        }

        public DateOnlyDto(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public DateOnly GetDate()
        {
            return new DateOnly(Year, Month, Day);
        }
    }
}
