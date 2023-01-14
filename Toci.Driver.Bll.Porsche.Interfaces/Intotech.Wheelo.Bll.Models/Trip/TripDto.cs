using Intotech.Wheelo.Bll.Models.TimeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.Trip
{
    public class TripDto
    {
        public List<int> AccountIds { get; set; }
        public int Id { get; set; }
        public int Idinitiatoraccount { get; set; }
        public int Idworktrip { get; set; }
        public DateOnlyDto TripdateDto { get; set; }
        public DateOnly Tripdate
        {
            get { return new DateOnly(TripdateDto.Year, TripdateDto.Month, TripdateDto.Day); }
        }
        public bool? Iscurrent { get; set; }
        public TimeOnlyDto FromhourDto { get; set; }
        public TimeOnly Fromhour
        {
            get { return new TimeOnly(FromhourDto.Hour, FromhourDto.Minute); }
        }
        public TimeOnlyDto TohourDto { get; set; }
        public TimeOnly Tohour
        {
            get { return new TimeOnly(TohourDto.Hour, TohourDto.Minute); }
        }
        public string? Summary { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Leftseats { get; set; }
    }
}
