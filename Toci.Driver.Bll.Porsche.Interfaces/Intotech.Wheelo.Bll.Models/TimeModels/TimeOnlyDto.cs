using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.TimeModels
{
    public class TimeOnlyDto
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public TimeOnlyDto()
        {
            
        }

        public TimeOnlyDto(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public TimeOnlyDto(TimeOnly time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
        }

        public TimeOnly GetTime()
        {
            return new TimeOnly(Hour, Minute);
        }
    }
}
