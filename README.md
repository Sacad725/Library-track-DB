# 📚 LibraryTrack – SQL Relationsdatabas & .NET Console App


## 📌 Projektöversikt
LibraryTrack är ett databaskurs-projekt som visar hur man **designar, skapar och använder en relationsdatabas i SQL Server** samt hur den kopplas till en **.NET Console App med Database First (Entity Framework Core)**.


Databasen är projektets **källa till sanningen**. All design och data skapas först i SQL och dokumenteras i SQL-script innan någon C#-kod skrivs.


---


## 🎯 Syfte
Projektet visar att vi kan:


- Modellera en relationsdatabas (PK, FK, relationer)
- Skriva strukturerade SQL-script
- Använda CRUD, JOINs, Views och Security
- Jobba Database First med Entity Framework Core
- Koppla en Console App till databasen
- Arbeta professionellt i GitHub med issues, commits och struktur


---


## 🧩 Scenario
**LibraryTrack – Bibliotekssystem**


Systemet hanterar:
- Medlemmar
- Böcker
- Författare
- Lån
- Reservationer


Scenariot valdes eftersom det är realistiskt och tydligt visar:
- många-till-många-relationer
- transaktioner (lån)
- statusfält och rapporter


---


## 🗄️ Databasdesign


### Huvudtabeller
- **Members** – bibliotekets medlemmar  
- **Books** – böcker  
- **Authors** – författare  
- **BookAuthors** – kopplingstabell (many-to-many)  
- **Loans** – boklån  
- **Reservations** – bokreservationer  


### Relationer
- En Member kan ha många Loans  
- En Book kan ha många Loans  
- Books ↔ Authors (many-to-many via BookAuthors)  


Alla tabeller har:
- Primary Key
- Foreign Keys där det krävs
- NOT NULL, UNIQUE och CHECK constraints
- DEFAULT-värden för datumfält


📌 **ER-diagram finns i mappen `/erd`**


---


## 📁 Repo-struktur



/sql
01_create_database.sql
02_create_tables.sql
03_seed_data.sql
04_crud_examples.sql
05_queries_joins.sql
06_views.sql
07_security.sql
08_cleanup.sql (ska ej köras)

/src
Console App (.NET)

/erd
ER-diagram (bild/pdf)

/screenshots
Bilder på queries eller rapporter

README.md



---


## ▶️ Hur man kör SQL-delarna


Alla i gruppen jobbar mot **egen lokal SQL Server-databas**.  
Databasen delas inte – **endast SQL-filerna delas via GitHub**.


### Kör filerna i SSMS i denna ordning:
1. `01_create_database.sql`
2. `02_create_tables.sql`
3. `03_seed_data.sql`
4. `04_crud_examples.sql`
5. `05_queries_joins.sql`
6. `06_views.sql`
7. `07_security.sql`


⚠️ **VIKTIGT**  
`08_cleanup.sql` ska **inte exekveras**.  
Den ska endast sparas i repot.


---


## 🔐 Views & Security
Projektet innehåller:
- **Public View** – döljer känslig data
- **Report View** – används av Console App
- **Role + User** med SELECT-rättigheter endast på views  
  (ingen direkt access till tabeller)


---


## 🖥️ Console App – Database First


### Teknik
- .NET Console App
- SQL Server
- Entity Framework Core (Database First)
- LINQ för läsning och rapporter


### Installerade NuGet-paket
```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Scaffold Database First
Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=LibraryTrack;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context LibraryContext -Force
📊 Funktioner i Console App

Lista entiteter (Members, Books)

Skapa lån och relationer

Uppdatera status

Ta bort data

Rapportmeny med SELECT-frågor via LINQ

👥 Gruppmedlemmar

Projektet är genomfört av:

Mazen Alamin Hassan

Sacad Elmi

Yousuf Abdulrahman

Alla i gruppen kan förklara:

Databasdesign & ERD

SQL-script, CRUD & JOINs

Views & Security

Console App & Database First
