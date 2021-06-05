using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Plane
    {
        private int id;
        private int seats;
        private int range;
        private string type;

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
        public string Get_type()
        {
            return this.type;
        }
        public Plane()
        {

        }
        public Plane(int id, int seats, int range, string type)
        {
            this.seats = seats;
            this.range = range;
            this.id = id;
            this.type = type;
        }
    }
}
