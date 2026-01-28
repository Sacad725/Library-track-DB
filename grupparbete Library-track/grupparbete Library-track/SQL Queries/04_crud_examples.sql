--steg;4 04_crud_examples.sql

-- CREATE
INSERT INTO Members (FirstName, LastName, Email)
VALUES ('Emma','Nilsson','emma@mail.com');

-- READ
SELECT * FROM Books;

-- UPDATE
UPDATE Loans
SET Status = 'Returned'
WHERE LoanID = 1;

-- DELETE
DELETE FROM Reservations
WHERE ReservationID = 1;