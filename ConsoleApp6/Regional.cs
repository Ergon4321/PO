using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Regional
    {
        private int seats = 50;
        private int range = 20000;
        private int id;

        public Regional(int seats, int range, int id)
        {
            this.seats = seats;
            this.range = range;
            this.id = id;
        }
    }
}
