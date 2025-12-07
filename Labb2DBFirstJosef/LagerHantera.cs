using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2DBFirstJosef.Models;


namespace Labb2DBFirstJosef
{
    public class LagerHantera
    {
        public static void AddBookToStore()
        {
            using var db = new BokhandelContext();
            Console.WriteLine("--- Lägg till bok i butik ---");

            
            Console.WriteLine("Välj butik:");
            foreach (var b in db.Butikers) Console.WriteLine($"ID: {b.Id} - {b.Namn}");
            Console.Write("Butik ID: ");
            int butikId = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Välj bok att lägga till:");
            foreach (var b in db.Böckers) Console.WriteLine($"ISBN: {b.Isbn13} - {b.Titel}");
            Console.Write("Ange ISBN: ");
            string isbn = Console.ReadLine();

            
            Console.Write("Antal att lägga till: ");
            int antal = Convert.ToInt32(Console.ReadLine());

            
            var saldo = db.LagerSaldos.FirstOrDefault(ls => ls.ButikId == butikId && ls.Isbn13 == isbn);

            if (saldo != null)
            {
                saldo.Antal += antal;
                Console.WriteLine($"Uppdaterade befintligt saldo. Nytt antal: {saldo.Antal}");
            }
            else
            {
                var nyttSaldo = new Models.LagerSaldo
                {
                    ButikId = butikId,
                    Isbn13 = isbn,
                    Antal = antal
                };
                db.LagerSaldos.Add(nyttSaldo);
                Console.WriteLine("Ny produkt tillagd i butikens lager");
            }

            db.SaveChanges();
            Console.ReadKey();
        }

        public static void RemoveBookFromStore()
        {
            using var db = new BokhandelContext();
            Console.WriteLine("--- Ta bort bok från butik ---");

            
            foreach (var b in db.Butikers) Console.WriteLine($"ID: {b.Id} - {b.Namn}");
            Console.Write("Butik ID: ");
            int butikId = Convert.ToInt32(Console.ReadLine());

            
            var lager = db.LagerSaldos.Where(l => l.ButikId == butikId).ToList();
            if(!lager.Any()) { Console.WriteLine("Butiken är tom."); Console.ReadKey(); return; }

            foreach (var l in lager) Console.WriteLine($"ISBN: {l.Isbn13} | Antal: {l.Antal}");
            
            Console.Write("Ange ISBN att ta bort/minska: ");
            string isbn = Console.ReadLine();

            var saldo = db.LagerSaldos.FirstOrDefault(ls => ls.ButikId == butikId && ls.Isbn13 == isbn);

            if (saldo != null)
            {
                Console.Write("Hur många ska tas bort? (Skriv 0 för att ta bort hela raden): ");
                int antalTaBort = Convert.ToInt32(Console.ReadLine());

                if (antalTaBort >= saldo.Antal || antalTaBort == 0)
                {
                    db.LagerSaldos.Remove(saldo); 
                    Console.WriteLine("Boken borttagen helt från butiken.....");
                }
                else
                {
                    saldo.Antal -= antalTaBort; 
                    Console.WriteLine($"Minskade antal. Kvar: {saldo.Antal}");
                }
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Boken finns inte i denna butik.");
            }
            Console.ReadKey();
        }
    }
}