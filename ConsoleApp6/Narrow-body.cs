using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Narrow_body : Plane
    {
        public Narrow_body(int id_)
        {
            id = id_;
            seats = 125;
            range = 5000;
            type = "Waskokadlubowy";
        }
    }
}
