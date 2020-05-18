CREATE TABLE Directors
(
             Id           INT NOT NULL PRIMARY KEY,
             DirectorName NVARCHAR(50) NOT NULL,
             Notes        NVARCHAR(MAX)
);

INSERT INTO Directors(Id,DirectorName)
VALUES
(1,'Director One'),
(2,'Director Two'),
(3,'Director Three'),
(4,'Director Four'),
(5,'Director Five');

CREATE TABLE Genres
(
             Id        INT NOT NULL PRIMARY KEY,
             GenreName NVARCHAR(50) NOT NULL,
             Notes     NVARCHAR(MAX)
);

INSERT INTO Genres(Id,GenreName)
VALUES
(1,'Action'),
(2,'Horror'),
(3,'Thriller'),
(4,'Comedy'),
(5,'History');

CREATE TABLE Categories
(
             Id           INT NOT NULL PRIMARY KEY,
             CategoryName NVARCHAR(50) NOT NULL,
             Notes        NVARCHAR(MAX)
);

INSERT INTO Categories(Id,CategoryName)
VALUES
(1,'CAT One'),
(2,'CAT One'),
(3,'CAT One'),
(4,'CAT One'),
(5,'CAT One');

CREATE TABLE Movies
(
             Id            INT NOT NULL PRIMARY KEY,
             Title         NVARCHAR(255) NOT NULL,
             DirectorId    INT FOREIGN KEY REFERENCES Directors(Id),
             CopyrightYear INT,
             Length        NVARCHAR(50),
             GenreId       INT FOREIGN KEY REFERENCES Genres(Id),
             CategoryId    INT FOREIGN KEY REFERENCES Categories(Id),
             Rating        INT,
             Notes         NVARCHAR(MAX)
);

INSERT INTO Movies(Id,
                   Title,
                   DirectorId,
                   GenreId,
                   CategoryId
                  )
VALUES
(1,'Title One',2,3,2),
(2,'Title Two',3,4,1),
(3,'Title Three',4,5,5),
(4,'Title Four',5,2,4),
(5,'Title Five',1,1,3);