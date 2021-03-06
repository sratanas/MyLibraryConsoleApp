﻿CREATE PROCEDURE GetAllBookInfo

AS

SELECT b.Title, g.GenreName, b.YearPublished, l.LocationName, a.FirstName, a.LastName
FROM Books as b
JOIN Locations as l ON b.Location = l.Id
JOIN Authors as a ON b.Author = a.Id
JOIN Genres AS g ON b.Genre = g.Id



CREATE PROCEDURE SearchAuthors
@AuthorSearchParam VARCHAR(50)

AS

SELECT * FROM Authors
WHERE FirstName LIKE @AuthorSearchParam
OR
LastName LIKE @AuthorSearchParam
OR 
CONCAT(FirstName, ' ', LastName) = @AuthorSearchParam



CREATE PROCEDURE AddAuthor
@AuthorFirstName VARCHAR(50),
@AuthorLastName VARCHAR(50),
@IsFemale VARCHAR(5)

AS

INSERT INTO Authors (FirstName, LastName, IsFemale)
VALUES (@AuthorFirstName, @AuthorLastName, @IsFemale)



CREATE PROCEDURE GetBooksByAuthor
@AuthorId INT

AS

SELECT * FROM Books
WHERE Author = @AuthorId



CREATE PROCEDURE TitleSearch
@TitleSearchParam VARCHAR(50)

AS

SELECT * FROM Books
WHERE Title LIKE @TitleSearchParam

CREATE PROCEDURE GetAllGenres

AS

SELECT * FROM Genres

CREATE PROCEDURE GetAllLocations

AS

SELECT * FROM Locations

CREATE PROCEDURE GetLocationById
@LocationId INT
AS

SELECT * FROM Locations
WHERE Id = @LocationId

CREATE PROCEDURE GetGenreById
@GenreId INT
AS

SELECT * FROM Genres
WHERE Id = @GenreId


CREATE PROCEDURE AddBook
@Title varchar(100),
@YearPublished INT,
@Author INT,
@Genre INT,
@Location INT

AS

INSERT INTO Books (Title, YearPublished, Author, Genre, Location)
VALUES (@Title, @YearPublished, @Author, @Genre, @Location)