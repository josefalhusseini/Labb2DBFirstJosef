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
                Console.WriteLine("========= Välkommen till Josefs bokhandelcentral! =========");
                Console.WriteLine("1. Lägg till en bok");
                Console.WriteLine("2. Visa lagersaldo");
                Console.WriteLine("3. Lista av butiker");
                Console.WriteLine("4. Avsluta");
                Console.WriteLine("===========================================================");
                Console.Write("Välj ett alternativ: ");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        AddBook.AddNewBook();
                        break;

                    case "2":
                        LagerSaldo.ShowLagerSaldo();
                        break;

                    case "3":
                        ListaAvButiker.ShowButiker();
                        break;

                    case "4":
                        runMeny = false;
                        Console.WriteLine("Programmet avslutas...");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                
            }
        }
    }
}
