using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Firm : Client
    {
        private string nip;
        private string name;

        public Firm(string nip, string name)
        {
            this.nip = nip;
            this.name= name;
        }
    }
}
