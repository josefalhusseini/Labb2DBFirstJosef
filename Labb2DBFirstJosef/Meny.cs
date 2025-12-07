using System;

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
                Console.WriteLine("========= Josefs Bokhandel =================");
                Console.WriteLine("1. Hantera Böcker");
                Console.WriteLine("2. Hantera Författare");
                Console.WriteLine("3. Lagerhantering");
                Console.WriteLine("4. Visa lagersaldo");
                Console.WriteLine("5. Lista butiker");
                Console.WriteLine("0. Avsluta");
                Console.WriteLine("============================================");
                Console.Write("Välj ett alternativ: ");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        HanteraBok.Meny();
                        break;

                    case "2":
                        HanteraForfattareMeny();
                        break;

                    case "3":
                        HanteraLagerMeny();
                        break;

                    case "4":
                        LagerSaldo.ShowLagerSaldo();
                        break;

                    case "5":
                        ListaAvButiker.ShowButiker();
                        break;

                    case "0":
                        runMeny = false;
                        Console.WriteLine("Programmet avslutas...");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void HanteraForfattareMeny()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Hantera Författare ---");
                Console.WriteLine("1. Lägg till Författare");
                Console.WriteLine("2. Ta bort Författare");
                Console.WriteLine("3. Redigera Författare");
                Console.WriteLine("0. Tillbaka");
                Console.Write("Val: ");

                string val = Console.ReadLine();
                Console.Clear();

                switch (val)
                {
                    case "1":
                        HanteraFörfattare.AddAuthor();
                        break;
                    case "2":
                        HanteraFörfattare.RemoveAuthor();
                        break;
                    case "3":
                        RedigeraFörfattare.Kör();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void HanteraLagerMeny()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Lagerhantering ---");
                Console.WriteLine("1. Lägg till bok i butik");
                Console.WriteLine("2. Ta bort bok från butik");
                Console.WriteLine("0. Tillbaka");
                Console.Write("Val: ");

                string val = Console.ReadLine();
                Console.Clear();

                switch (val)
                {
                    case "1":
                        LagerHantera.AddBookToStore();
                        break;
                    case "2":
                        LagerHantera.RemoveBookFromStore();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}   