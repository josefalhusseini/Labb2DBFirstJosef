using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2DBFirstJosef.Models; 


namespace Labb2DBFirstJosef
{
    public class RedigeraFörfattare
    {
        public static void Kör()
        {
            using var db = new BokhandelContext();

            Console.WriteLine("--- Redigera Författare ---");

            //Listar alla författare så man vet vilken id man ska välja
            var allaFörfattare = db.Författares.ToList();
            foreach (var a in allaFörfattare)
            {
                Console.WriteLine($"ID: {a.Id} | {a.Förnamn} {a.Efternamn}");
            }

            Console.Write("\nAnge ID på författaren du vill ändra: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var author = db.Författares.Find(id);

                if (author != null)
                {
                    Console.WriteLine($"\nVald författare: {author.Förnamn} {author.Efternamn}");
                    Console.WriteLine("(Tryck bara ENTER om du vill behålla nuvarande värde)");

                    Console.Write($"Nytt förnamn [{author.Förnamn}]: ");
                    string nyttFnamn = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nyttFnamn))
                    {
                        author.Förnamn = nyttFnamn;
                    }

                    Console.Write($"Nytt efternamn [{author.Efternamn}]: ");
                    string nyttEnamn = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nyttEnamn))
                    {
                        author.Efternamn = nyttEnamn;
                    }

                    db.SaveChanges();
                    Console.WriteLine("\nUppdateringen är sparad!");
                }
                else
                {
                    Console.WriteLine("Hittade ingen författare med det IDt.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt ID.");
            }

            Console.WriteLine("Tryck valfri tangent för att återgå...");
            Console.ReadKey();
        }
    }
}