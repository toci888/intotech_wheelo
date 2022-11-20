using AutoMapper;
using Intotech.Common;
using Intotech.Wheelo.Social.Database.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.Social
{
    public class OrganizemeetingDto : Organizemeeting
    {
        public string OrganizerName { get; set; }
        public string OrganizerSurname { get; set; }
        public string OrganizerEmail { get; set; }
        public string OrganizerPhone { get; set; }
    }
}
