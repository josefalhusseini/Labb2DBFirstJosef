using Labb2DBFirstJosef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2DBFirstJosef
{
    public class AddBook
    {
        public static void AddNewBook()
        {

            using var db = new BokhandelContext();

            Console.Write("Ange ISBN-13 för boken: ");
            string isbn = Console.ReadLine();

            Console.Write("Ange titel för boken: ");    
            string title = Console.ReadLine();

            Console.Write("Ange författarens namn: ");
            string author = Console.ReadLine();

            Console.Write("Ange förlagets namn: "); 
            string publisher = Console.ReadLine();

            Console.Write("Ange pris för boken (t.ex 10,99): "); 
            decimal price = Convert.ToDecimal(Console.ReadLine());

            int författadeId = 1;

            var nyBok = new Böcker
            {
                Isbn13 = isbn,
                Titel = title,
                FörfattareId = författadeId,
                FörlagsId = 1,
                Pris = price
            };

            db.Böckers.Add(nyBok);

            db.SaveChanges();

            Console.WriteLine("Boken har lagts till i databasen.");
            Console.ReadLine();


        }
    }
}
