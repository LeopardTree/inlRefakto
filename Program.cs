using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod
{
    /* CLASS: Person
    * PURPOSE: Are used in the list dict and in the methods for the commands.
    */
    class Person
    {
        public string name, adress, phone, email;
        public Person(string N, string A, string P, string E)
        {
            name = N; adress = A; phone = P; email = E;
        }

        /* METHOD: Print
        * PURPOSE: Prints out the parameters name, adress, phone and email
        * which 
        * PARAMETERS: alla parametrarnas namn och innebörd
        * RETURN VALUE: returvärdets innebörd
        */
        public void Print()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", name, adress, phone, email);
        }
        public Person()
        {
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            adress = Console.ReadLine();
            Console.Write("  3. ange phone: ");
            phone = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            email = Console.ReadLine();
        }
        public void ModifyInfo(string toModify, string newValue)
        {
            switch (toModify)
            {
                case "name": 
                    name = newValue;
                    break;
                case "adress": 
                    adress = newValue; 
                    break;
                case "phone": 
                    phone = newValue; 
                    break;
                case "email": 
                    email = newValue; 
                    break;
                default: break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> dict = new List<Person>();
            int found;
            string changeThisPerson;
            string command;
            Console.Write("Laddar adresslistan ... ");
            Load(dict);
            Console.WriteLine("klart!");

            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
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
                    dict.Add(new Person());
                }
                else if (command == "ta bort")
                {
                    Console.Write("Vem vill du ta bort (ange namn): ");
                    changeThisPerson = Console.ReadLine();
                    found = GetIndex(dict, changeThisPerson);
                    if (found != -1)
                    {
                        dict.RemoveAt(found);
                    }
                }
                else if (command == "visa")
                {
                    for (int i = 0; i < dict.Count(); i++)
                    {
                        dict[i].Print();
                    }
                }
                else if (command == "ändra")
                {
                    Console.Write("Vem vill du ändra (ange namn): ");
                    changeThisPerson = Console.ReadLine();
                    found = GetIndex(dict, changeThisPerson);
                    if (found != -1)
                    {
                        Change(dict, found, changeThisPerson);
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
            Console.ReadKey();
        }

        /* METHOD: Change (static void)
        * PURPOSE: Ask user for what they want to change at a certain person; name, adress, phone or email. Reads user input to string.
        * Asks for the new value and reads user input to string. Rewrites the value at the index in the list dict with the help from the method ModifyInfo.
        * PARAMETERS:  
        * dict: List with name 'dict' and type defined by the constructor 'Person'.
        * The value of one of the strings is changed at index 'found' in the list
        * with the method 'ModifyInfo'.
        * found: the value of the index where the value's gonna be modified
        * changeThisPerson: string with the name which info's gonna be changed
        * RETURN VALUE: none
        */
        private static void Change(List<Person> dict, int found, string changeThisPerson)
        {
            Console.Write("Vad vill du ändra (name, adress, phone eller email): ");
            string toModify = Console.ReadLine();
            Console.Write("Vad vill du ändra {0} på {1} till: ", toModify, changeThisPerson);
            string newValue = Console.ReadLine();
            dict[found].ModifyInfo(toModify, newValue);
        }
        /* METHOD: GetIndex (static int)
        * PURPOSE: Sets int 'found' to -1. Goes through all indexes in 'dict' with a for loop.
        * Checks if the string name in each index is equal to the string with value of the person that wants to be changed.
        * If it's equal sets int found to the index value.
        * If 'found''s value haven't changed in the loop; prints that it not have been found.
        * PARAMETERS:  
        * List dict: Uses it's values name to compare with.
        * String changeThisPerson: Uses it's values name to compare with.
        * RETURN VALUE: returns found which has the index in dict for the person to modify.
        */
        private static int GetIndex(List<Person> dict, string changeThisPerson)
        {
            int found = -1;
            for (int i = 0; i < dict.Count(); i++)
            {
                if (dict[i].name == changeThisPerson) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", changeThisPerson);
            }
            return found;
        }
        /* METHOD: Load (static void)
        * PURPOSE: creates an instance of the textreader Streamreader with the using statement.
        * Reads one line at a time if every line contains something.
        * Splits the strings at char '#' and puts them in an array.
        * The constructor Person are assigned the words in the array to the strings name, phone, etc.
        * Then adds the new person with the Add method.
        * PARAMETERS:  
        * List dict: Calls the list and adds values to it with the Add method.
        * RETURN VALUE: none
        */
        private static void Load(List<Person> dict)
        {
            //string pathtest = "C:\\Users\\ludvi\\progmet\\adressboktest.txt"
            using (StreamReader fileStream = new StreamReader(@"C:\Users\ludvi\progmet\adressboktest2.txt"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    // Console.WriteLine(line);
                    string[] word = line.Split('#');
                    // Console.WriteLine("{0}, {1}, {2}, {3}", word[0], word[1], word[2], word[3]);
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    dict.Add(P);
                }
            }
        }
    }
}
