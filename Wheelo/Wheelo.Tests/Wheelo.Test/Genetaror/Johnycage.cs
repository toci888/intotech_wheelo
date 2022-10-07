using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheelo.Test.Generator
{
    public class JohnnyCage
    {
        // 
        public string GetRandomWord(int length)
        {

            Random raiden = new Random();

            const string chars = "abcdefghijklmnoprstuvwz0123456789";
            string fatality = string.Empty;

            for (int i = 0; i < length; i++) {
                int thunder = raiden.Next(0, chars.Length - 1);

                fatality += chars[thunder];
            }

            return fatality;
        }

    }
}