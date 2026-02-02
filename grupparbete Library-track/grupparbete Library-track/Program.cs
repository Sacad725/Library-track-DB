
using grupparbete_Library_track.Models; // Kopplar till  tabellerna
using Microsoft.EntityFrameworkCore; // Behövs för att hämta data från flera tabeller samtidigt

namespace grupparbete_Library_track
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Startar  kontakten med databasen
            using var db = new LibraryContext();

            bool kör = true;

            while (kör)
            {
                Console.Clear();
                Console.WriteLine("--- BIBLIOTEK-SYSTEM ---");
                Console.WriteLine("1. Visa medlemmar");
                Console.WriteLine("2. Visa böcker");
                Console.WriteLine("3. Registrera nytt lån");
                Console.WriteLine("4. Ändra status på lån");
                Console.WriteLine("5. Rapport: Vem har lånat vad");
                Console.WriteLine("0. Avsluta");
                Console.Write("\nVälj: ");

                var val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        // Hämtar listan på alla medlemmar
                        var medlemmar = db.Members.ToList();
                        Console.WriteLine("\nMEDLEMMAR:");
                        foreach (var m in medlemmar) Console.WriteLine($"ID: {m.MemberId} - {m.FirstName} {m.LastName}");
                        break;

                    case "2":
                        // Hämtar listan på alla böcker
                        var böcker = db.Books.ToList();
                        Console.WriteLine("\nBÖCKER:");
                        foreach (var b in böcker) Console.WriteLine($"ID: {b.BookId} - {b.Title}");
                        break;

                    case "3":
                        // Skapar en ny rad i lån-tabellen
                        Console.Write("Medlems-ID: ");
                        int mId = int.Parse(Console.ReadLine());
                        Console.Write("Bok-ID: ");
                        int bId = int.Parse(Console.ReadLine());

                        var lån = new Loan { MemberId = mId, BookId = bId, Status = "Active", LoanDate = DateOnly.FromDateTime(DateTime.Now) };
                        db.Loans.Add(lån);
                        db.SaveChanges(); // Sparar till SQL
                        Console.WriteLine("Lånet sparat!");
                        break;

                    case "4":
                        // Hittar ett lån och ändrar status
                        Console.Write("Lån-ID: ");
                        int lånId = int.Parse(Console.ReadLine());
                        var hittatLån = db.Loans.Find(lånId);
                        if (hittatLån != null)
                        {
                            hittatLån.Status = "Returned";
                            db.SaveChanges();
                            Console.WriteLine("Status ändrad till återlämnad.");
                        }
                        break;

                    case "5":
                        // Tar bort en reservation
                        Console.Write("Reservations-ID: ");
                        int resId = int.Parse(Console.ReadLine());
                        var res = db.Reservations.Find(resId);
                        if (res != null)
                        {
                            db.Reservations.Remove(res);
                            db.SaveChanges();
                            Console.WriteLine("Reservationen är raderad.");
                        }
                        break;


                    case "0":
                        kör = false;
                        break;
                }
                Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka...");
                Console.ReadKey();
            }
        }
    }

}
    

