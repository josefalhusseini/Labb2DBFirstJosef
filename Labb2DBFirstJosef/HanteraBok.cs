using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2DBFirstJosef.Models;


namespace Labb2DBFirstJosef
{
    public class HanteraBok
    {
        public static void Meny()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Hantera Böcker ---");
                Console.WriteLine("1. Lägg till ny bok");
                Console.WriteLine("2. Redigera bok");
                Console.WriteLine("3. Ta bort bok");
                Console.WriteLine("0. Tillbaka");
                Console.Write("Val: ");

                string val = Console.ReadLine();
                Console.Clear();

                switch (val)
                {
                    case "1":
                        AddNewBook();
                        break;
                    case "2":
                        EditBook();
                        break;
                    case "3":
                        RemoveBook();
                        break;
                    case "0":
                        running = false;
                        break;
                }
            }
        }

        public static void AddNewBook()
        {
            using var db = new BokhandelContext();
            Console.WriteLine("--- Lägg till ny bok ---");
            Console.Write("Ange ISBN-13: ");
            string isbn = Console.ReadLine();

            if (db.Böckers.Any(b => b.Isbn13 == isbn))
            {
                Console.WriteLine("ISBN finns redan.");
                Console.ReadKey();
                return;
            }

            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Språk: ");
            string language = Console.ReadLine();
            Console.Write("Pris: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Utgivningsdatum (YYYY-MM-DD): ");
            DateOnly publishDate = DateOnly.Parse(Console.ReadLine());

            int authorId = HanteraFörfattare.ValjForfattare(db);

            Console.WriteLine("--- Välj Förlag ---");
            foreach (var f in db.Förlags)
            {
                Console.WriteLine($"ID: {f.Id} | {f.Namn}");
            }
            Console.Write("Ange Förlags ID: ");
            int publisherId = Convert.ToInt32(Console.ReadLine());

            var nyBok = new Böcker
            {
                Isbn13 = isbn,
                Titel = title,
                Språk = language,
                Pris = price,
                Utgivningsdatum = publishDate,
                FörfattareId = authorId,
                FörlagsId = publisherId
            };

            db.Böckers.Add(nyBok);
            db.SaveChanges();
            Console.WriteLine("Boken sparad.");
            Console.ReadKey();
        }

        public static void EditBook()
        {
            using var db = new BokhandelContext();
            Console.WriteLine("--- Redigera Bok ---");
            Console.Write("Ange ISBN på boken: ");
            string isbn = Console.ReadLine();

            var bok = db.Böckers.Find(isbn);
            if (bok != null)
            {
                Console.WriteLine($"Titel: {bok.Titel} | Pris: {bok.Pris}");

                Console.Write("Ny titel (tomt för att behålla): ");
                string nyTitel = Console.ReadLine();
                if (!string.IsNullOrEmpty(nyTitel))
                {
                    bok.Titel = nyTitel;
                }

                Console.Write("Nytt pris (tomt för att behålla): ");
                string prisStr = Console.ReadLine();
                if (decimal.TryParse(prisStr, out decimal nyttPris))
                {
                    bok.Pris = nyttPris;
                }

                db.SaveChanges();
                Console.WriteLine("Boken uppdaterad.");
            }
            else
            {
                Console.WriteLine("Boken hittades inte.");
            }
            Console.ReadKey();
        }

        public static void RemoveBook()
        {
            using var db = new BokhandelContext();
            Console.WriteLine("--- Ta bort Bok ---");
            Console.Write("Ange ISBN: ");
            string isbn = Console.ReadLine();

            var bok = db.Böckers.Find(isbn);
            if (bok != null)
            {
                bool finnsILager = db.LagerSaldos.Any(l => l.Isbn13 == isbn);
                if (finnsILager)
                {
                    Console.WriteLine("Kan inte ta bort boken eftersom den finns i lager hos butiker.");
                }
                else
                {
                    db.Böckers.Remove(bok);
                    db.SaveChanges();
                    Console.WriteLine("Boken borttagen från systemet");
                }
            }
            else
            {
                Console.WriteLine("Boken hittades inte......");
            }
            Console.ReadKey();
        }
    }
}