using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Regional : Plane
    {
        public Regional(int id_)
        {
            id = id_;
            seats = 100;
            range = 3000;
            type = "Regionalny";
        }
    }
}
