--Steg;5 05_queries_joins.sql 
--JOIN, GROUP BY, filter och rapporter

-- JOIN: visa lån med namn och bok
SELECT m.FirstName, b.Title, l.Status
FROM Loans l
JOIN Members m ON l.MemberID = m.MemberID
JOIN Books b ON l.BookID = b.BookID;

-- GROUP BY: mest lånade böcker
SELECT b.Title, COUNT(*) AS TotalLoans
FROM Loans l
JOIN Books b ON l.BookID = b.BookID
GROUP BY b.Title;

-- WHERE + ORDER BY: aktiva lån
SELECT * FROM Loans
WHERE Status = 'Active'
ORDER BY LoanDate DESC;

-- Rapport: medlemmar med flest lån
SELECT m.FirstName, COUNT(*) AS LoansCount
FROM Loans l
JOIN Members m ON l.MemberID = m.MemberID
GROUP BY m.FirstName;