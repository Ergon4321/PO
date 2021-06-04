using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private bool exit;
        private string temp;
        private int choice;


        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunMenu();
        }


        static void CreatingPlaneFile(int type)
        {
            string path = @"samoloty.txt";
            StreamWriter sw;

            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = new StreamWriter(path, true);
            }

            string tekst;

            switch (type)
            {
                case 1:
                    tekst = "Szerokokadlubowy.";
                    Wide_body wide_body = new Wide_body();
                    break;
                case 2:
                    tekst = "Regional.";
                    break;
                case 3:
                    tekst = "Waskokadlubowy.";
                    break;
                default:
                    tekst = "blad";
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }
            sw.WriteLine(tekst);
            sw.Close();
        }


        static void ReadingPlaneFile()
        {
            string path = @"samoloty.txt";
            StreamReader sr = File.OpenText(path);
            string s = "";
            int i = 1;
            while((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(i++ + ". " + s);
            }
            sr.Close();
        }


        public void PrintHeader()
        {
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("+                                                  Witaj w systemie                                                   +");
            Console.WriteLine("+                                                 lini lotniczej M&M                                                  +");
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
                GetInputToSeven();
                SwitchMenu(choice);
            }
        }


        private int GetInputToSeven()
        {
            Console.WriteLine("Prosze wybrac jedna z opcji: ");

            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            while (choice < 0 || choice > 7)
            {
                Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                temp = Console.ReadLine();
                choice = Convert.ToInt32(temp);
            }
            return choice;
        }


        private int GetInputToTwo()
        {
            Console.WriteLine("Prosze wybrac jedna z opcji: ");

            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            while (choice < 0 || choice > 2)
            {
                Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                temp = Console.ReadLine();
                choice = Convert.ToInt32(temp);
            }
            return choice;
        }


        private int GetInputToThree()
        {
            Console.WriteLine("Prosze wybrac jedna z opcji: ");

            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            while (choice < 0 || choice > 3)
            {
                Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                temp = Console.ReadLine();
                choice = Convert.ToInt32(temp);
            }
            return choice;
        }


        private void SwitchMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    PlaneMenu();//odnośniki do klas poświęconych danemu menu 
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


        private void PlaneMenu()
        {
            Console.Clear();

            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            ReadingPlaneFile();
            Console.WriteLine("\n\n\n1) Dodawanie samolotu. ");
            Console.WriteLine("2) Usuwanie samolotu. ");
            Console.WriteLine("0) Wyjscie. \n\n\n");
            GetInputToTwo();
            switch (choice)
            {
                case 1:
                    AddingPlane();
                    break;
                case 2:
                    DeletingPlane();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }

        }


        private void AddingPlane()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+\n\n\n");
            Console.WriteLine("1) Szerokokadlubowy. ");
            Console.WriteLine("2) Regionalny. ");
            Console.WriteLine("3) Waskokadłubowy. ");
            Console.WriteLine("0) Anuluj. ");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            GetInputToThree();
            switch (choice)
            {
                case 1:
                    CreatingPlaneFile(1);
                    break;
                case 2:
                    CreatingPlaneFile(2);
                    break;
                case 3:
                    CreatingPlaneFile(3);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }
        }
        private void DeletingPlane()
        {
            int delId;
            Console.Clear();
            Console.WriteLine("Podaj ID samolotu do usunięcia");
            temp = Console.ReadLine();
            delId = Convert.ToInt32(temp);
        }


    }
}
