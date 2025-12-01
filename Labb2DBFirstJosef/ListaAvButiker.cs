using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2DBFirstJosef
{
    public class ListaAvButiker
    {
        public static void ShowButiker()
        {
            using var context = new Models.BokhandelContext();
            var butiker = context.Butikers.ToList();
            Console.WriteLine("Lista över butiker (Tryck ENTER för att bläddra):");
            foreach (var butik in butiker)
            {
                Console.WriteLine($"ID: {butik.Id}, Namn: {butik.Namn}, Adress: {butik.Adress}, Stad: {butik.Stad}, Postnummer: {butik.Postnummer}");
                Console.ReadKey();
            }

        }
    }
}
