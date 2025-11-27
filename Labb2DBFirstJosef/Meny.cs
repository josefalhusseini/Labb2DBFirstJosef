using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2DBFirstJosef
{
    public class Meny
    {


        public static void Run()
        {
            bool runMeny = true;

            while (runMeny)
            {
                Console.Clear();
                Console.WriteLine("=========Välkommen till Josefs bokhandelcentral!=========");
                Console.WriteLine("1. Lägg till en bok");
                Console.WriteLine("2. Visa lagersaldo");
                Console.WriteLine("3. Avsluta programmet");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    AddBook.AddNewBook();
                }
                else if (input == "2")
                {
                    LagerSaldo.ShowLagerSaldo();
                }
                else if (input == "3")
                {
                    runMeny = false;
                }
            }
        }
    }
}