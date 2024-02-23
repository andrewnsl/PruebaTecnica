CREATE DATABASE PruebaTecnica
GO 

USE PruebaTecnica
GO


CREATE TABLE Country(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CountryCode INT NOT NULL,
	CountryName VARCHAR(150) NOT NULL,
	CountryActive BIT NOT NULL
)

CREATE TABLE Department(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CountryId INT FOREIGN KEY REFERENCES Country(Id) NOT NULL,
	DepartmentCode INT NOT NULL,
	DepartmentName VARCHAR(150) NOT NULL,
	DepartmentActive BIT NOT NULL
)

CREATE TABLE City(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DepartmentId INT FOREIGN KEY REFERENCES Department(Id) NOT NULL,
	CityCode INT NOT NULL,
	CityName VARCHAR(150) NOT NULL,
	CityActive BIT NOT NULL
)

CREATE TABLE Location(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CityId INT FOREIGN KEY REFERENCES City(Id) NOT NULL,
	LocationName VARCHAR(150) NOT NULL,
	LocationActive BIT NOT NULL
)

CREATE TABLE CarBrand(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CarBrandName VARCHAR(150) NOT NULL,
	CarBrandActive BIT NOT NULL
)


CREATE TABLE Car(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CarBrand INT FOREIGN KEY REFERENCES CarBrand(Id) NOT NULL,
	CarModel INT NOT NULL,
	CarCylinder INT NOT NULL,
	CarActive BIT NOT NULL
)

CREATE TABLE CarAvailable(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CarId INT FOREIGN KEY REFERENCES Car(Id) NOT NULL,
	CollectionLocationId INT FOREIGN KEY REFERENCES Location(Id) NOT NULL,
	ReturnLocationId INT FOREIGN KEY REFERENCES Location(Id) NOT NULL,
	CarAvailableActive BIT NOT NULL
)

GO

INSERT INTO Country(CountryCode, CountryName, CountryActive)
VALUES(1,'Colombia', 1)

GO

INSERT INTO Department(CountryId, DepartmentCode, DepartmentName, DepartmentActive)
VALUES(1, 1,'Antioquia', 1)

GO

INSERT INTO City(DepartmentId, CityCode, CityName, CityActive)
VALUES(1, 1,'Medellin', 1),
(1, 2,'Bello', 1)

GO

INSERT INTO Location(CityId, LocationName, LocationActive)
VALUES (1, 'Localidad sur', 1),
(1, 'Localidad norte', 1),
(2, 'Localidad niquia', 1),
(2, 'Localidad centro', 1)

GO

INSERT INTO CarBrand(CarBrandName, CarBrandActive)
VALUES ('Kia', 1),
('Renault', 1),
('Toyota', 1)

GO

INSERT INTO Car(CarBrand, CarModel, CarCylinder, CarActive)
VALUES(1, 2022,2000, 1),
(2, 2020,1600, 1),
(3, 2024,3000, 1)

GO

INSERT INTO CarAvailable(CarId, CollectionLocationId, ReturnLocationId, CarAvailableActive)
VALUES (1, 1, 2,1),
(2, 3, 4,1),
(3, 1, 1,1)