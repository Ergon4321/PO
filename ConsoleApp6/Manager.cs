using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Manager
    {
        private bool exit;
        private string temp;
        private int choice;
        private List<Plane> planes;

        public Manager()
        {
            planes = new List<Plane>();
        }

        // zestaw podstawowych metod koniecznych do obsługi menu
        public void RunMenu()
        {
            while (!exit)
            {
                DoesFilesExist(); /// sprawdzanie czy pliki konieczne do korzystania z programu istnieją (jeśli nie użycie metody CreatingFileWithPath(string path); )
                ReadAllPlanesFromFile();
                Console.Clear(); /// czyszczenie okna konsoli
                PrintHeader(); ///okno tytułowe
                PrintMenu(); /// wyświetlenie podstawowych opcji zarządzaniem menu głównym
                GetInputToSeven(); /// pobranie wkładu użytkownnika przystosowanego do obsługi opcji menu głównego
                MainMenu(choice); /// switch głównego menu
            }
        }


        //MainMenu switch
        private void MainMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    PlaneMenu();//odnośniki do klas poświęconych danemu menu 
                    break;
                case 2:
                    ClientMenu();
                    break;
                case 3:
                    AirPortMenu();
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
        void WriteAllPlanesToScreen()
        {
            foreach (Plane plane in planes)
            {
                Console.WriteLine(plane.ToReadableString());
            }
        }

        void WriteAllPlanesToFile()
        {
            string path = @"samoloty.txt";
            StreamWriter sw;
            sw = new StreamWriter(path, false);
            foreach (Plane plane in planes)
            {
                sw.WriteLine(plane.ToString());
            }
            sw.Close();
        }

        void AddPlane(int type)
        {
            int nextId = 0;
            if (planes.Count() > 0)
            {
                nextId = planes.Last().Get_id() + 1;
            }
            switch (type)
            {
                case 1:
                    planes.Add(new Wide_body(nextId));
                    break;
                case 2:
                    planes.Add(new Regional(nextId));
                    break;
                case 3:
                    planes.Add(new Narrow_body(nextId));
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }
        }

        ///metoda odczytująca informacje z pliku tekstowego samoloty.txt
        private void ReadAllPlanesFromFile()
        {
            planes.Clear();
            string path = @"samoloty.txt";
            StreamReader sr = File.OpenText(path);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] id_and_type = s.Split(';');
                int id = Convert.ToInt32(id_and_type[0]);
                string type = id_and_type[1];
                switch (type)
                {
                    case "Waskokadlubowy":
                        planes.Add(new Wide_body(id));
                        break;
                    case "Regionalny":
                        planes.Add(new Regional(id));
                        break;
                    case "Szerokokadlubowy":
                        planes.Add(new Narrow_body(id));
                        break;
                    default:
                        Console.WriteLine("Niepoprawny typ samolotu w pliku wejsciowym");
                        break;
                }
            }
            sr.Close();
        }

        ///menu dotyczące samolotów
        private void PlaneMenu()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------Menu-Samolotow------------------------------------------------------+");
            WriteAllPlanesToScreen();
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

        ///korzystanie z menu dodawania samolotu
        private void AddingPlane()
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------------Dodaj-Samolot-Do-Floty--------------------------------------------------+\n\n\n");
            Console.WriteLine("1) Szerokokadlubowy. ");
            Console.WriteLine("2) Regionalny. ");
            Console.WriteLine("3) Waskokadłubowy. ");
            Console.WriteLine("0) Anuluj. ");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            GetInputToThree();
            switch (choice)
            {
                case 1:
                    AddPlane(1);
                    break;
                case 2:
                    AddPlane(2);
                    break;
                case 3:
                    AddPlane(3);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }
            WriteAllPlanesToFile();
            PlaneMenu();
        }
        
        private void DeletePlane(int toDelete)
        {
            planes.RemoveAll(plane => plane.Get_id() == toDelete);
        }

        ///korzystanie z menu usuwania samolotu 
        private void DeletingPlane()
        {
            //string path = @"samoloty.txt";
            Console.Clear();
            Console.WriteLine("+----------------------------------------------Usun-Samolot-Z-Floty---------------------------------------------------+");
            Console.WriteLine("Lista dostepnych samolotow: ");
            WriteAllPlanesToScreen();
            Console.WriteLine("\n0. Anuluj ");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("Podaj id samolotu ktory chcesz usunac: ");


            bool isInteger = false;
            while(!isInteger) {
                try {
                    temp = Console.ReadLine();
                    choice = Convert.ToInt32(temp);
                    if (choice >= 0)
                    {
                        isInteger = true;
                    }
                } catch (FormatException e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                }
            }
            if (choice == 0)
                PlaneMenu();
            else
            {
                DeletePlane(choice);
                PlaneMenu();
            }
        }
        //KONIEC METOD SAMOLOTÓW





        //POCZĄTEK METOD KLIENTÓW
        /// menu dotyczące klientów
        private void ClientMenu()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------------------------Menu-Klientow------------------------------------------------------+");
            ReadingClientFile();
            Console.WriteLine("\n\n\n1) Dodawanie klienta. ");
            Console.WriteLine("2) Usuwanie klienta. ");
            Console.WriteLine("0) Wyjscie. \n\n\n");
            GetInputToTwo();
            switch (choice)
            {
                case 1:
                    AddingClient();
                    break;
                case 2:
                    DeletingClient();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }

        }

        ///korzystanie z menu dodawania klientów
        private void AddingClient()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------Dodaj-Klienta-Do-Bazy-Danych----------------------------------------------+");
            ReadingClientFile();
            Console.WriteLine("\n\n\n1) Klient Idywidualny. ");
            Console.WriteLine("2) Klient z Firmy-Posrednika. ");
            Console.WriteLine("0) Anuluj. ");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            GetInputToTwo();
            switch (choice)
            {
                case 1:
                    AddingIndClient();
                    break;
                case 2:
                    AddingFirmClient();
                    break;
                case 0:
                    ClientMenu();
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }
        }

        ///dodawania klientów indywidualnych
        private void AddingIndClient()
        {
            String data_to_file = "";
            Console.Clear();
            Console.WriteLine("+--------------------------------------------Dodaj-Klienta-Indywidualnego---------------------------------------------+\n\n\n");
            Console.WriteLine("Pesel: ");
            temp = Console.ReadLine();
            while (temp.Length != 11)
            {
                Console.WriteLine("Prosze ponownie wprowadzic numer pesel: ");
                temp = Console.ReadLine();
            }
            data_to_file = data_to_file + temp;
            Console.WriteLine("Imie: ");
            temp = Console.ReadLine();
            data_to_file = data_to_file + " " + temp;
            Console.WriteLine("Nazwisko: ");
            temp = Console.ReadLine();
            data_to_file = data_to_file + " " + temp;
            AddingClientToFile(data_to_file);
            ClientMenu();
        }

        ///dodawania klientów z firmy-pośrednika
        private void AddingFirmClient()
        {
            String data_to_file = "";
            Console.Clear();
            Console.WriteLine("+--------------------------------------------Dodaj-Klienta-Firma-Posrednik--------------------------------------------+\n\n\n");
            Console.WriteLine("Nip firmy: ");
            temp = Console.ReadLine();
            while (temp.Length != 10)
            {
                Console.WriteLine("Prosze ponownie wprowadzic numer nip: ");
                temp = Console.ReadLine();
            }
            data_to_file = data_to_file + temp;
            Console.WriteLine("Nazwa firmy: ");
            temp = Console.ReadLine();
            data_to_file = data_to_file + " " + temp;
            AddingClientToFile(data_to_file);
            ClientMenu();
        }

        /// metoda zapisująca informacje do pliku tekstowego klienci.txt
        void AddingClientToFile(string data_to_file)
        {

            string path = @"klienci.txt";
            StreamWriter sw;
            sw = new StreamWriter(path, true);
            sw.WriteLine(data_to_file);
            sw.Close();
        }

        /// metoda odczytująca informacje z pliku tekstowego klienci.txt
        void ReadingClientFile()
        {
            string path = @"klienci.txt";
            StreamReader sr = File.OpenText(path);
            {
                int i = 1;
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(i++ + ". " + s);//zamiast 'i' id klienta
                }
                sr.Close();
            }
        }

        ///korzystanie z menu usuwania klientów
        private void DeletingClient()
        {
            //string path = @"samoloty.txt";
            Console.Clear();
            Console.WriteLine("+--------------------------------------------Usun-Klienta-Z-Bazy-Danych-----------------------------------------------+");
            Console.WriteLine("Lista dostepnych klientow: ");
            ReadingClientFile();
            Console.WriteLine("\n0. Anuluj ");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("Podaj id klienta ktorego chcesz usunac: ");

            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            while (choice < 0)
            {
                Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                temp = Console.ReadLine();
                choice = Convert.ToInt32(temp);
            }
            if (choice == 0)
                ClientMenu();
            else
            {
                ///usuwanie po id obiektu samolot z pliku samoloty.txt 
                ClientMenu();
            }
        }
        //KONIEC METOD KLIENTÓW





        //POCZĄTEK METOD LOTNISK
        /// menu dotyczące lotnisk
        private void AirPortMenu()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------------------------Menu-Lotnisk-------------------------------------------------------+");
            ReadingAirPortFile();
            Console.WriteLine("\n\n\n1) Dodawanie Lotniska. ");
            Console.WriteLine("2) Usuwanie Lotniska. ");
            Console.WriteLine("0) Wyjscie. \n\n\n");
            GetInputToTwo();
            switch (choice)
            {
                case 1:
                    AddingAirPort();
                    break;
                case 2:
                    DeletingAirPort();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Blad Systemu. Nieoczekiwana zmienna.");
                    break;
            }

        }

        ///dodawania lotniska
        private void AddingAirPort()
        {
            String data_to_file = "";
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------Dodaj-Lotnisko------------------------------------------------------+\n\n\n");
            Console.WriteLine("Kraj: ");
            temp = Console.ReadLine();
            data_to_file = data_to_file + temp;
            Console.WriteLine("Miasto: ");
            temp = Console.ReadLine();
            data_to_file = data_to_file + " " + temp;
            Console.WriteLine("Ilosc samolotow na lotnisku: ");
            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);
            for (int i = 0; i < choice; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Wprowadz id samolotu: ");
                    temp = Console.ReadLine();
                    data_to_file = data_to_file + " " + temp;
                }
                else
                {
                    Console.WriteLine("Wprowadz id nastepnego samolotu: ");
                    temp = Console.ReadLine();
                    data_to_file = data_to_file + ", " + temp;
                }
            }
            AddingAirPortToFile(data_to_file);
            AirPortMenu();
        }

        ///korzystanie z menu usuwania lotniska
        private void DeletingAirPort()
        {
            //string path = @"lotniska.txt";
            Console.Clear();
            Console.WriteLine("+--------------------------------------------Usun-Lotnisko-Z-Bazy-Danych----------------------------------------------+");
            Console.WriteLine("Lista lotnisk: ");
            ReadingAirPortFile();
            Console.WriteLine("\n0. Anuluj ");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("Podaj id lotniska ktore chcesz usunac: ");

            temp = Console.ReadLine();
            choice = Convert.ToInt32(temp);

            while (choice < 0)
            {
                Console.WriteLine("Wprowadzono niewlasciwe dane, sprobuj ponownie: ");
                temp = Console.ReadLine();
                choice = Convert.ToInt32(temp);
            }
            if (choice == 0)
                AirPortMenu();
            else
            {
                ///usuwanie po id obiektu samolot z pliku samoloty.txt 
                AirPortMenu();
            }
        }

        /// metoda zapisująca informacje do pliku tekstowego lotniska.txt
        void AddingAirPortToFile(string data_to_file)
        {

            string path = @"lotniska.txt";
            StreamWriter sw;
            sw = new StreamWriter(path, true);
            sw.WriteLine(data_to_file);
            sw.Close();
        }

        /// metoda odczytująca informacje z pliku tekstowego lotniska.txt
        void ReadingAirPortFile()
        {
            string path = @"lotniska.txt";
            StreamReader sr = File.OpenText(path);
            {
                int i = 1;
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(i++ + ". " + s);//zamiast 'i' id klienta
                }
                sr.Close();
            }
        }
        //KONIEC METOD LOTNISK






        /// sprawdzenie czy pliki konieczne do funkcjonowania programu działają 
        void DoesFilesExist()
        {
            string path = @"samoloty.txt";
            //StreamWriter sw;

            if (!File.Exists(path))
            {
                CreatingFileWithPath(path);
            }

            path = @"klienci.txt";

            if (!File.Exists(path))
            {
                CreatingFileWithPath(path);
            }

            path = @"trasy.txt";

            if (!File.Exists(path))
            {
                CreatingFileWithPath(path);
            }

            path = @"lotniska.txt";

            if (!File.Exists(path))
            {
                CreatingFileWithPath(path);
            }
        }

        /// stworzenie plików koniecznych do funkcjonowania programu jeśli nie istnieją
        void CreatingFileWithPath(string path)
        {
            StreamWriter sw;
            sw = File.CreateText(path);
            Console.WriteLine("Stworzono plik " + path + "...");
            Thread.Sleep(1000);
            sw.Close();
        }

        /// wyświetlenie baneru menu
        public void PrintHeader()
        {
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("+                                                  Witaj w systemie                                                   +");
            Console.WriteLine("+                                                 linii lotniczej M&M                                                 +");
            Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------+\n\n\n\n");
        }

        /// wyświetlenie głównego menu linii lotniczej
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

        /// pobranie liczby do obsługi menu w switchu z 2 case'ami
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

        /// pobranie liczby do obsługi menu w switchu z 3 case'ami
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

        /// pobranie liczby do obsługi menu w switchu z 7 case'ami
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

    }
}
