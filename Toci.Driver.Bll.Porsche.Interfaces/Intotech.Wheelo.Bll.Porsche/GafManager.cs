using Intotech.Wheelo.Bll.Models.Gaf;
using Intotech.Wheelo.Bll.Porsche.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Bll.Porsche
{
    public class GafManager
    {
        public virtual void LoginByMethod(string method, string token)
        {
            if (method == "google")
            {
                GoogleUserDto dto = new GoogleUserService().GetUserByToken(token);
            }

            if (method == "facebok")
            {
                FacebookUserDto dto = new FacebookUserService().GetUserByToken(token);
            }
        }

        //save
    }
}
