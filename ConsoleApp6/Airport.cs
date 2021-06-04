using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Airport
    {
        private string country;
        private string city;
        private int id;

        public Airport(string country, string city)
        {
            this.country = country; 
            this.city = city; 
        }
        public int Get_id()
        {
            return this.id;
        }
    }
}
