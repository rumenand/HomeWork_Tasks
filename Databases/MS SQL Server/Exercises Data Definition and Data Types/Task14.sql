CREATE TABLE Categories
(
             Id           INT
             PRIMARY KEY NOT NULL,
             CategoryName NVARCHAR(50) NOT NULL,
             DailyRate    DECIMAL(10, 2),
             WeeklyRate   DECIMAL(10, 2),
             MonthlyRate  DECIMAL(10, 2),
             WeekendRate  DECIMAL(10, 2)
);

ALTER TABLE Categories
ADD CONSTRAINT CK_AtLeastOneRate CHECK((DailyRate IS NOT NULL)
                                       OR (WeeklyRate IS NOT NULL)
                                       OR (MonthlyRate IS NOT NULL)
                                       OR (WeekendRate IS NOT NULL));

INSERT INTO Categories(Id,
                       CategoryName,
                       DailyRate,
                       WeeklyRate,
                       MonthlyRate,
                       WeekendRate
                      )
VALUES
(1,'First CAT',10,50,200,50),
(2,'Second CAT',20,90,330,100),
(3,'Third CAT',30,130,2700,155);

CREATE TABLE Cars
(
             Id           INT
             PRIMARY KEY NOT NULL,
             PlateNumber  VARCHAR(50) NOT NULL,
             Manufacturer VARCHAR(50) NOT NULL,
             Model        VARCHAR(50) NOT NULL,
             CarYear      INT NOT NULL,
             CategoryId   INT NOT NULL
                              FOREIGN KEY REFERENCES Categories(Id),
             Doors        TINYINT NOT NULL,
             Picture      VARBINARY(MAX),
             Condition    NVARCHAR(50),
             Available    BIT DEFAULT 1
);

INSERT INTO Cars(Id,
                 PlateNumber,
                 Manufacturer,
                 Model,
                 CarYear,
                 CategoryId,
                 Doors,
                 Available
                )
VALUES
(1,'CA3993CA','Mercedes','320','2010',3,4,1),
(2,'CA3993CA','BMW','535','2012',3,4,1),
(3,'CA3993CA','Porche','320','1999',1,2,1);

CREATE TABLE Employees
(
             Id        INT
             PRIMARY KEY NOT NULL,
             FirstName NVARCHAR(50) NOT NULL,
             LastName  NVARCHAR(50) NOT NULL,
             Title     NVARCHAR(50) NOT NULL,
             Notes     NVARCHAR(MAX)
);

INSERT INTO Employees(Id,
                      FirstName,
                      LastName,
                      Title
                     )
VALUES
(1,'First','One','Mechanic'),
(2,'Second','Two','Team Leader'),
(3,'Third','Three','Boss');

CREATE TABLE Customers
(
             Id                  INT NOT NULL PRIMARY KEY,
             DriverLicenceNumber VARCHAR(50)
             UNIQUE NOT NULL,
             FullName            NVARCHAR(50) NOT NULL,
             [Address]           NVARCHAR(255),
             City                NVARCHAR(50),
             ZIPCode             NVARCHAR(50),
             Notes               NVARCHAR(MAX)
);

INSERT INTO Customers(Id,
                      DriverLicenceNumber,
                      FullName
                     )
VALUES
(1,'123','First Name'),
(2,'234','Second Name'),
(3,'345','Third Name');

CREATE TABLE RentalOrders
(
             Id               INT
             PRIMARY KEY NOT NULL,
             EmployeeId       INT NOT NULL
                                  FOREIGN KEY REFERENCES Employees(Id),
             CustomerId       INT NOT NULL
                                  FOREIGN KEY REFERENCES Customers(Id),
             CarId            INT NOT NULL
                                  FOREIGN KEY REFERENCES Cars(Id),
             TankLevel        NUMERIC(5, 2),
             KilometrageStart INT,
             KilometrageEnd   INT,
             TotalKilometrage INT,
             StartDate        DATE NOT NULL,
             EndDate          DATE NOT NULL,
             TotalDays        INT NOT NULL, 
	--TotalDays AS DATEDIFF(DAY, StartDate, EndDate), 
             RateApplied      DECIMAL(10, 2),
             TaxRate          DECIMAL(10, 2),
             OrderStatus      NVARCHAR(50),
             NOTES            NVARCHAR(MAX)
);

/* *** Verifying TotalDays is correct accrding dates *** */

ALTER TABLE RentalOrders
ADD CONSTRAINT CK_TotalDays CHECK(DATEDIFF(DAY, StartDate, EndDate) = TotalDays);

INSERT INTO RentalOrders(Id,
                         EmployeeId,
                         CustomerId,
                         CarId,
                         StartDate,
                         EndDate,
                         TotalDays
                        )
VALUES
(1,3,3,3,'01-01-2010','01-02-2010',1),
(2,1,1,1,'01-01-2010','01-03-2010',2),
(3,2,2,2,'01-01-2010','01-04-2010',3);