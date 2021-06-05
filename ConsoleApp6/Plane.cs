using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Plane
    {
        protected int id;
        protected int seats;
        protected int range;
        protected string type;

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
        public Plane(int id, int seats, int range, string type)
        {
            this.id = id;
            this.seats = seats;
            this.range = range;
            this.type = type;
        }
        public Plane() { }

        public override string ToString()
        {
            return $"{id};{type}";
        }

        public string ToReadableString()
        {
            return $"id: {id} type: {type}";
        }
    }
}
