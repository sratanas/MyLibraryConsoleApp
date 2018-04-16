CREATE TABLE Books (
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(200),
YearPublished INT,
);

CREATE TABLE Authors(
Id INT IDENTITY PRIMARY KEY,
LastName VARCHAR(50),
FirstName VARCHAR(50),
IsFemale VARCHAR(5) DEFAULT 'No'
)

CREATE TABLE Locations(
Id INT IDENTITY PRIMARY KEY,
LocationName VARCHAR(100)
)

CREATE TABLE Genres(
Id INT IDENTITY PRIMARY KEY,
GenreName VARCHAR(80)
)

CREATE TABLE Books_OutOnLoan
(Id INT IDENTITY PRIMARY KEY,
BookId INT REFERENCES Books(Id),
LoanedTo VARCHAR(50),
DateLoaned DATE
)

ALTER TABLE Books
ADD Author INT REFERENCES Authors(Id)

ALTER TABLE Books
ADD Genre INT REFERENCES Genres(Id)

ALTER TABLE Books
ADD Location INT REFERENCES Locations(Id)

INSERT INTO Locations (LocationName)
VALUES ('Living Room Shelf'),
('Dining Room Shelf'),
('Bedroom'),
('On Loan')

--MOCK DATA INSERTS--

INSERT INTO Authors (LastName, FirstName, IsFemale)
VALUES ('Didion', 'Joan', 1),
('Pullman', 'Philip', 0)

INSERT INTO Genres (GenreName)
VALUES ('Essay'),('YA Fantasy')

INSERT INTO Books (Title, YearPublished, Author, Genre, Location)
VALUES ('Slouching Towards Bethlehem', 1968, 1, 1, 4)
INSERT INTO Books_OutOnLoan (BookId, LoanedTo, DateLoaned)
VALUES (@@IDENTITY, 'Ashley', CONVERT(DATE, '2018-02-08'))