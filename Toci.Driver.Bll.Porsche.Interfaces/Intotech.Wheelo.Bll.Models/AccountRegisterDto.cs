using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Models
{
    public class AccountRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Method { get; set; }
        public string Token { get; set; }

    }
    /*
     {
  "name": "Kacper",
  "surname": "Wyb",
  "gender": 1,
  "pesel": "1234",
  "phone": "123456",
  "email": "kac.wyb@gmail.com",
  "login": "kacper",
  "password": "beatka",
  "idgeographicregion": 1
}
     */
}
