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

            var finnsRedan = db.Böckers.Any(b => b.Isbn13 == isbn);

            if (finnsRedan)
            {
                Console.WriteLine("En bok med detta ISBN-13 finns redan i databasen.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ange Titel för boken: ");    
            string title = Console.ReadLine();

            var finnsTitel = db.Böckers.Any(b => b.Titel == title);
            if (finnsTitel)
            {
                Console.WriteLine("En bok med denna titel finns redan i databasen.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ange Språk för boken: ");
            string language =  Console.ReadLine();


            Console.Write("Ange Författarens namn: ");
            string author = Console.ReadLine();

            Console.Write("Ange Förlagets namn: "); 
            string publisher = Console.ReadLine();

            Console.Write("Ange Pris för boken (t.ex 10,99): "); 
            decimal price = Convert.ToDecimal(Console.ReadLine());
            

            Console.Write("Ange Utgivningsdatum för boken (ÅÅÅÅ-MM-DD): ");
            DateOnly publishDate = DateOnly.Parse(Console.ReadLine());

            Console.Write("Ange Författarens Id: ");
            int authorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ange Förlagets Id: ");
            int publisherId = Convert.ToInt32(Console.ReadLine());

            int författadeId = 1;

            var nyBok = new Böcker
            {
                Isbn13 = isbn,
                Titel = title,
                Språk = language,
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
