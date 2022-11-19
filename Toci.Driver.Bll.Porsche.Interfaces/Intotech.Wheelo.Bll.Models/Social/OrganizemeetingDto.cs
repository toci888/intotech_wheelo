using AutoMapper;
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

        public static OrganizemeetingDto MapperFill(Organizemeeting orM)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => 
                cfg.CreateMap<Organizemeeting, OrganizemeetingDto>());

            Mapper mapper = new Mapper(config);

            OrganizemeetingDto organizemeetingDto = mapper.Map<OrganizemeetingDto>(orM);

            return organizemeetingDto;
        }
    }
}
