--Steg;6 06_views.sql
--Views för säkerhet och rapporter

USE LibraryTrack;
GO

-- Public view (döljer känslig data)
CREATE VIEW vw_PublicMembers AS
SELECT MemberID, FirstName, LastName
FROM Members;
GO

-- Rapport-view för Console App
CREATE VIEW vw_LoanReport AS
SELECT m.FirstName, b.Title, l.Status, l.LoanDate
FROM Loans l
JOIN Members m ON l.MemberID = m.MemberID
JOIN Books b ON l.BookID = b.BookID;
GO