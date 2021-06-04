using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Plane
    {
        private int seats;
        private int range;
        private int id;
        private int type;

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
        public int Get_type()
        {
            return this.type;
        }
        public Plane()
        {

        }
        public Plane(int id, int seats, int range, int type)
        {
            this.seats = seats;
            this.range = range;
            this.id = id;
            this.type = type;
        }
        public int Id
        {
            get{ return id; }
            set{ id = value; }
        }
    }
}
