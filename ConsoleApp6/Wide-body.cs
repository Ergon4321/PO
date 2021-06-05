using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Wide_body : Plane
    {
        public Wide_body(int id_)
        {
            id = id_;
            seats = 400;
            range = 12000;
            type = "Szerokokadlubowy";
        }
    }
}
