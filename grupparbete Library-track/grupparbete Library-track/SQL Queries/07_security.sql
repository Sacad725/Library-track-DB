--steg;7  07_security.sql

-- Roll med rättigheter endast till views

CREATE ROLE LibraryReader;

GRANT SELECT ON vw_PublicMembers TO LibraryReader;
GRANT SELECT ON vw_LoanReport TO LibraryReader;