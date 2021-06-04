using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Person : Client
    {
        private string name;
        private string surname;
        private string pesel;

        public Person(string name, string surname, string pesel)
        {
            this.name = name;
            this.surname= surname;
            this.pesel= pesel;
        }
    }
}
