using Intotech.Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models.OldModels
{
    public class AccountMetadataDto : DtoEntityBase
    {
        public int AccountId { get; set; }
        public int Gender { get; set; }
        public string Pesel { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Occupation { get; set; }
        public bool IsSmoker { get; set; }
        public bool IsWithAnimals { get; set; }
        public string MetaJson { get; set; }

    }
}
