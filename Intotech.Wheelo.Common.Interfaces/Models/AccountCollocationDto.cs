using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Interfaces.Models
{
    public class AccountCollocationDto
    {
        public int idAccount { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Latitudefrom { get; set; }
        public double Longitudefrom { get; set; }
        public double Latitudeto { get; set; }
        public double Longitudeto { get; set; }
        public string Fromhour { get; set; }
        public string Tohour { get; set; }
        public bool AreFriends { get; set; }
        public string PhoneNumber { get; set; }
        public Driver Driver { get; set; }

        /*
     export type CollocateAccount = {
  idAccount: number,
  image: string[],
  name: string,
  surname: string,
  latitudefrom: number,
  longitudefrom: number,
  latitudeto: number,
  longitudeto: number,
  fromhour: string,
  tohour: string
  areFriends: boolean;
  phoneNumber: string;
  isDriver: Driver;
}
    */
    }
}
