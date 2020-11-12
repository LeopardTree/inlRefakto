using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod
{
    class Person
    {
        public string namn, adress, telefon, email;
        public Person(string N, string A, string T, string E)
        {
            namn = N; adress = A; telefon = T; email = E;
        }
        public void Print()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", P.namn, P.adress, P.telefon, P.email);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Dict = new List<Person>();
            int found;
            Console.Write("Laddar adresslistan ... ");
            Load(Dict);
            Console.WriteLine("klart!");

            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då!");
                }
                else if (command == "ny")
                {
                    New(Dict);
                }
                else if (command == "ta bort")
                {
                    Console.Write("Vem vill du ta bort (ange namn): ");
                    string villÄndra = Console.ReadLine();
                    found = GetIndex(Dict, villÄndra);
                    if (found != -1)
                    {
                        Dict.RemoveAt(found);
                    }
                }
                else if (command == "visa")
                {
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        Person P = Dict[i];
                        P.Print();
                    }
                }
                else if (command == "ändra")
                {
                    Console.Write("Vem vill du ändra (ange namn): ");
                    string villÄndra = Console.ReadLine();
                    found = GetIndex(Dict, villÄndra);
                    if (found != -1)
                    {
                        Change(Dict, found, villÄndra);
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
            Console.ReadKey();
        }

        private static void Change(List<Person> Dict, int found, string villÄndra)
        {
            Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
            string fältAttÄndra = Console.ReadLine();
            Console.Write("Vad vill du ändra {0} på {1} till: ", fältAttÄndra, villÄndra);
            string nyttVärde = Console.ReadLine();
            switch (fältAttÄndra)
            {
                case "namn": Dict[found].namn = nyttVärde; break;
                case "adress": Dict[found].adress = nyttVärde; break;
                case "telefon": Dict[found].telefon = nyttVärde; break;
                case "email": Dict[found].email = nyttVärde; break;
                default: break;
            }
        }

        private static int GetIndex(List<Person> Dict, string villÄndra)
        {
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].namn == villÄndra) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", villÄndra);
            }
            return found;
        }

        private static void New(List<Person> Dict)
        {
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            string name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            string adress = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            string telefon = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            string email = Console.ReadLine();
            Dict.Add(new Person(name, adress, telefon, email));
        }

        private static void Load(List<Person> Dict)
        {
            //string pathtest = "C:\\Users\\ludvi\\progmet\\adressboktest.txt"
            using (StreamReader fileStream = new StreamReader(@"C:\Users\ludvi\progmet\adressboktest3.txt"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    // Console.WriteLine(line);
                    string[] word = line.Split('#');
                    // Console.WriteLine("{0}, {1}, {2}, {3}", word[0], word[1], word[2], word[3]);
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
        }
    }
}