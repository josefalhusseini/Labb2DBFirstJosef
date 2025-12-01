using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2DBFirstJosef
{
    public class LagerSaldo
    {
        public static void ShowLagerSaldo()
        {
            using var db = new Models.BokhandelContext();
            var lagerSaldo = db.LagerSaldos.ToList();
            Console.Write("Ange butikens ID för att visa lagersaldo: ");
            int butikId = Convert.ToInt32(Console.ReadLine());

            

            var saldoFörButik = lagerSaldo.Where(ls => ls.ButikId == butikId).ToList();
            Console.WriteLine($"Lagersaldo för butik ID {butikId}:");

        }
    }
}
