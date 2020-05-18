CREATE TABLE Users
(
	Id BIGINT UNIQUE IDENTITY NOT NULL,
    Username VARCHAR(30) UNIQUE NOT NULL,
    Password   VARCHAR(26) NOT NULL,
    ProfilePicture     VARBINARY(MAX),
    LastLoginTime   DATETIME2,
    IsDeleted   BIT DEFAULT(0),
);

ALTER TABLE Users
ADD PRIMARY KEY(Id);

ALTER TABLE Users
ADD CONSTRAINT CH_PictureSize2 CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024);

INSERT INTO Users(Username,Password)
VALUES
('First User','User1'),
('Second User','User2'),
('Third User','User3'),
('Fourth User','User4'),
('Fifth User','User5');