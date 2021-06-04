using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Plane
    {
        private int seats;
        private int range;
        private int id;

        public int Get_id()
        {
            return this.id;
        }
        public int Get_seats()
        {
            return this.seats;
        }
        public int Get_range()
        {
            return this.range;
        }
        public Plane()
        {

        }
        public Plane(int id, int seats, int range)
        {
            this.seats = seats;
            this.range = range;
            this.id = id;
        }
    }
}
