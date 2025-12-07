using Labb2DBFirstJosef.Models;
using System;
using System.Linq;

namespace Labb2DBFirstJosef
{
    public class HanteraFörfattare
    {
        public static void AddAuthor()
        {
            using var db = new BokhandelContext();
            Console.WriteLine("--- Lägg till ny författare ---");

            Console.Write("Förnamn: ");
            string fnamn = Console.ReadLine();

            Console.Write("Efternamn: ");
            string enamn = Console.ReadLine();

            Console.Write("Födelsedatum (YYYY-MM-DD), lämna tomt om okänt: ");
            string datumStr = Console.ReadLine();
            DateOnly? datum = string.IsNullOrEmpty(datumStr) ? null : DateOnly.Parse(datumStr);

            var författare = new Författare
            {
                Förnamn = fnamn,
                Efternamn = enamn,
                Födelsedatum = datum
            };

            db.Författares.Add(författare);
            db.SaveChanges();
            Console.WriteLine("Författare tillagd!");
            Console.ReadKey();
        }

        public static void RemoveAuthor()
        {
            using var db = new BokhandelContext();
            var authors = db.Författares.ToList();

            Console.WriteLine("--- Ta bort författare ---");
            foreach (var a in authors)
            {
                Console.WriteLine($"ID: {a.Id} - {a.Förnamn} {a.Efternamn}");
            }

            Console.Write("Ange ID på författaren du vill ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var authorToRemove = db.Författares.Find(id);
                if (authorToRemove != null)
                {

                    db.Författares.Remove(authorToRemove);
                    db.SaveChanges();
                    Console.WriteLine("Författare borttagen.");
                }
                else
                {
                    Console.WriteLine("Hittade ingen författare med det IDt.");
                }
            }
            Console.ReadKey();
        }

        public static int ValjForfattare(BokhandelContext db)
        {
            var authors = db.Författares.ToList();
            Console.WriteLine("--- Välj författare ---");
            foreach (var a in authors)
            {
                Console.WriteLine($"ID: {a.Id} | {a.Förnamn} {a.Efternamn}");
            }
            Console.Write("Ange ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}