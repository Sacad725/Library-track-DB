-- steg;2:  02_create_tables.sql
-- Medlemmar
CREATE TABLE Members (
    MemberID INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Författare
CREATE TABLE Authors (
    AuthorID INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Böcker
CREATE TABLE Books (
    BookID INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    ISBN NVARCHAR(20) UNIQUE,
    PublishedYear INT,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Många-till-många: Böcker ↔ Författare
CREATE TABLE BookAuthors (
    BookAuthorID INT IDENTITY PRIMARY KEY,
    BookID INT NOT NULL,
    AuthorID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

-- Lån
CREATE TABLE Loans (
    LoanID INT IDENTITY PRIMARY KEY,
    MemberID INT NOT NULL,
    BookID INT NOT NULL,
    LoanDate DATE DEFAULT GETDATE(),
    ReturnDate DATE NULL,
    Status NVARCHAR(20)
        CHECK (Status IN ('Active','Returned')),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- Reservationer
CREATE TABLE Reservations (
    ReservationID INT IDENTITY PRIMARY KEY,
    MemberID INT NOT NULL,
    BookID INT NOT NULL,
    ReservedAt DATE DEFAULT GETDATE(),
    Status NVARCHAR(20)
        CHECK (Status IN ('Waiting','Cancelled','Fulfilled')),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- ==========================
-- TABELLER & RELATIONER
-- ==========================

-- Members
-- PK: MemberID
-- Relationer:
--  - One-to-Many med Loans (en medlem kan ha många lån)
--  - One-to-Many med Reservations (en medlem kan ha många reservationer)

-- Authors
-- PK: AuthorID
-- Relationer:
--  - Many-to-Many med Books via BookAuthors

-- Books
-- PK: BookID
-- Relationer:
--  - Many-to-Many med Authors via BookAuthors
--  - One-to-Many med Loans (en bok kan lånas många gånger)
--  - One-to-Many med Reservations (en bok kan reserveras många gånger)

-- BookAuthors (kopplingstabell)
-- PK: BookAuthorID
-- FK:
--  - BookID → Books(BookID)
--  - AuthorID → Authors(AuthorID)
-- Syfte:
--  - Hanterar många-till-många-relationen mellan Books och Authors

-- Loans
-- PK: LoanID
-- FK:
--  - MemberID → Members(MemberID)
--  - BookID → Books(BookID)
-- Innehåller:
--  - Status med CHECK ('Active', 'Returned')

-- Reservations
-- PK: ReservationID
-- FK:
--  - MemberID → Members(MemberID)
--  - BookID → Books(BookID)
-- Innehåller:
--  - Status med CHECK ('Waiting', 'Cancelled', 'Fulfilled')