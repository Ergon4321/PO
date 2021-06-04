using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        private bool exit;
        private string temp;
        private int choice;


        static void Main(string[] args)
        {
            Program program = new Program();
            Narrow_body narrow1 = new Narrow_body();
        }

        public void PrintHeader()
        {
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("+                                                  Witaj w systemie                                                   +");
            Console.WriteLine("+                                                 rezerwacji biletow                                                  +");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+\n\n\n\n");
        }

        public void PrintMenu()
        {
            Console.WriteLine("1) Zarzadzanie samolotami. ");
            Console.WriteLine("2) Zarzadzanie kilentami. ");
            Console.WriteLine("3) Zarzadzanie lotniskami. ");
            Console.WriteLine("4) Zarzadzanie trasami. ");
            Console.WriteLine("5) Zarzadzanie lotami. ");
            Console.WriteLine("6) Zarzadzanie rezerwacjami. ");
            Console.WriteLine("7) Generowanie lotow.");
            Console.WriteLine("0) Wyjscie. \n\n\n");
        }

        public void RunMenu()
        {
            while (!exit)
            {
                Console.Clear();
                PrintHeader();
                PrintMenu();
                SwitchMenu();
            }
        }


        private void SwitchMenu()
        {
            Console.WriteLine("Prosze wybrac jedna z opcje: ");

            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            while (choice < 0 || choice > 7)
            {
                Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                temp = Console.ReadLine();
                choice = Convert.ToInt32(temp);
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("case 1.");
                    break;
                case 2:
                    Console.WriteLine("case 2.");
                    break;
                case 3:
                    Console.WriteLine("case 3.");
                    break;
                case 4:
                    Console.WriteLine("case 4.");
                    break;
                case 5:
                    Console.WriteLine("case 5.");
                    break;
                case 6:
                    Console.WriteLine("case 6.");
                    break;
                case 7:
                    Console.WriteLine("case 7.");
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;


            }
        }
    }
}
