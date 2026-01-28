📚 LibraryTrack – SQL Relationsdatabasprojekt
👥 Skapad av

Mazen Alamin Hassan

Sacad Elmi

Yousuf Abdulrahman

📌 Projektbeskrivning

LibraryTrack är ett relationsdatabasprojekt som visar hur man:

designar en SQL-databas

skapar tabeller och relationer

använder CRUD-operationer och JOINs

kopplar databasen till en .NET Console App via Entity Framework Core

Projektet är byggt för att visa förståelse för databaser och hur en applikation hämtar data från SQL Server.

🧩 Databasdesign (kort)

Databasen är normaliserad (ca 3NF) och innehåller bland annat:

Members – bibliotekets medlemmar

Books – böcker

Authors – författare

BookAuthors – många-till-många-relation

Loans – utlåning

Reservations – reservationer

Relationer hanteras med Primary Keys, Foreign Keys, constraints och kopplingstabeller.

🗂️ SQL-struktur

Alla SQL-filer delas i GitHub, men varje gruppmedlem skapar databasen lokalt i SSMS genom att köra scripten i rätt ordning.

Exempel:

skapa databas och tabeller

lägga in testdata

CRUD-exempel

JOIN-queries

Views och säkerhet

cleanup-script (ska inte exekveras)

🔗 Console App & Entity Framework Core

Projektet innehåller en Console App i .NET som kopplas till databasen via Entity Framework Core (Database First).

För att underlätta kopplingen mellan:

SQL Server Management Studio (SSMS)

databasen

Console Appen

har vi installerat följande Entity Framework-paket:

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

Dessa paket gör det möjligt att:

scaffolda databasen till C#-klasser

använda DbContext

hämta data från databasen direkt i Console Appen

🧠 Vad projektet visar

Förståelse för relationsdatabaser

Korrekt användning av PK, FK och constraints

SQL-queries (SELECT, INSERT, UPDATE, DELETE, JOIN)

Koppling mellan SQL Server och C# via EF Core
