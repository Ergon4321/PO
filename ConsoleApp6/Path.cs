using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Path
    {
        List<Airport> airports = new List<Airport>();
        private int distance;
        private int time;
        private int id;

        Path(List<Airport> airports, int distance, int id)
        {
            this.airports = airports;
            this.distance = distance;
            this.id = id;
        }
        public int Get_distance()
        {
            return this.distance;
        }
        public int Get_id()
        {
            return this.id;
        }
        public int Get_time()
        {
            return this.time;
        }
    }
}
