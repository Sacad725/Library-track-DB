
using grupparbete_Library_track.Models; // Kopplar till  tabellerna
using Microsoft.EntityFrameworkCore; // Behövs för att hämta data från flera tabeller samtidigt

namespace grupparbete_Library_track
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Startar kontakten med databasen
            using var db = new LibraryContext();
            bool kör = true;

            while (kör)
            {
                try // Felhantering så programmet inte kraschar
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
                            // Hämtar alla medlemmar från databasen
                            var medlemmar = db.Members.ToList();
                            Console.WriteLine("\nMEDLEMMAR:");
                            foreach (var m in medlemmar)
                                Console.WriteLine($"ID: {m.MemberId} - {m.FirstName} {m.LastName}");
                            break;

                        case "2":
                            // Hämtar alla böcker från databasen
                            var böcker = db.Books.ToList();
                            Console.WriteLine("\nBÖCKER:");
                            foreach (var b in böcker)
                                Console.WriteLine($"ID: {b.BookId} - {b.Title}");
                            break;

                        case "3":
                            // Skapar ett nytt lån
                            Console.Write("Medlems-ID: ");
                            int mId = int.Parse(Console.ReadLine());
                            Console.Write("Bok-ID: ");
                            int bId = int.Parse(Console.ReadLine());

                            var lån = new Loan
                            {
                                MemberId = mId,
                                BookId = bId,
                                Status = "Active",
                                LoanDate = DateOnly.FromDateTime(DateTime.Now)
                            };
                            db.Loans.Add(lån);
                            db.SaveChanges(); // Sparar till SQL Server
                            Console.WriteLine("Lånet sparat!");
                            break;

                        case "4":
                            // Ändrar status på ett lån till återlämnat
                            Console.Write("Lån-ID: ");
                            int lånId = int.Parse(Console.ReadLine());
                            var hittatLån = db.Loans.Find(lånId);
                            if (hittatLån != null)
                            {
                                hittatLån.Status = "Returned";
                                db.SaveChanges();
                                Console.WriteLine("Status ändrad till återlämnad.");
                            }
                            else
                            {
                                Console.WriteLine("Lånet hittades inte.");
                            }
                            break;

                        case "5":
                            // Rapport: JOIN mellan Loans, Members och Books
                            var info = db.Loans
                                .Include(l => l.Member)  // Hämtar medlem-info
                                .Include(l => l.Book)    // Hämtar bok-info
                                .ToList();
                            Console.WriteLine("\nRAPPORT - VEM LÅNAR VAD:");
                            foreach (var i in info)
                                Console.WriteLine($"{i.Member.FirstName} lånar {i.Book.Title}");
                            break;

                        case "0":
                            // Avslutar programmet
                            kör = false;
                            Console.WriteLine("Avslutar...");
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Hanterar fel vid felaktig input (t.ex. bokstäver istället för siffror)
                    Console.WriteLine("\nFEL: Du måste ange ett giltigt nummer!");
                }
                catch (Exception ex)
                {
                    // Hanterar alla andra fel
                    Console.WriteLine($"\nFEL: {ex.Message}");
                }

                if (kör)
                {
                    Console.WriteLine("\nTryck på valfri knapp för att gå tillbaka...");
                    Console.ReadKey();
                }
            }
        }
    }

}
    

