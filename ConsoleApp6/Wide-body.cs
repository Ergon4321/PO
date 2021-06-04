using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Wide_body : Plane
    {
        private int seats = 60;
        private int range = 15000;
        private int id;

        public Wide_body(int seats, int range, int id)
        {
            this.seats = seats;
            this.range = range;
            this.id = id;
        }
    }
}
