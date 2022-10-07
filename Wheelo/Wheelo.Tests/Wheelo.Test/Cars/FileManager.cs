using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wheelo.Test.Cars
{
    class FileManager
    {
        public string ReadFile(string path)
        {
            StreamReader plik = new StreamReader(path);

            string content = plik.ReadToEnd();

            return content;


        }

    }
}
