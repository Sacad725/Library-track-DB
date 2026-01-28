-- steg:3  03_seed_data.sql 

-- Medlemmar (3 st)
INSERT INTO Members (FirstName, LastName, Email) VALUES
('Ali','Ahmed','ali@mail.com'),
('Sara','Omar','sara@mail.com'),
('Jonas','Karlsson','jonas@mail.com');

-- Författare (2 st)
INSERT INTO Authors (FirstName, LastName) VALUES
('Astrid','Lindgren'),
('George','Orwell');

-- Böcker (3 st)
INSERT INTO Books (Title, ISBN, PublishedYear) VALUES
('1984','9780451524935',1949),
('Pippi Långstrump','9789129688313',1945),
('Animal Farm','9780451526342',1945);

-- Koppling bok–författare
INSERT INTO BookAuthors (BookID, AuthorID) VALUES
(1,2),
(2,1),
(3,2);

-- Lån (2 st)
INSERT INTO Loans (MemberID, BookID, Status) VALUES
(1,1,'Active'),
(2,2,'Returned');

-- Reservation (1 st)
INSERT INTO Reservations (MemberID, BookID, Status) VALUES
(3,1,'Waiting');