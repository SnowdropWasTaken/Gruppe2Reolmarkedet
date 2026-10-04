-- ===============================
-- Opretter Databasen
-- ===============================
CREATE DATABASE ReolMarkedDB;
GO

-- ===============================
-- Forbinder til databasen
-- ===============================
USE ReolMarkedDB;
GO

-- ===============================
-- Opretter tabel til lejere
-- ===============================
CREATE TABLE Tenant(
	TenantID	INT				IDENTITY(1,1) PRIMARY KEY,
	FirstName	NVARCHAR(50)	NOT NULL,  
	LastName	NVARCHAR(50)	NOT NULL,  
	Email		NVARCHAR(100)	NOT NULL UNIQUE,  
	PhoneNumber	NVARCHAR(20)	NOT NULL
);
GO

-- ===============================
-- Opretter tabel til bankkonto
-- ===============================
CREATE TABLE BankAccount (
	AccountID			INT				IDENTITY(1,1) PRIMARY KEY,
	TenantID			INT				NOT NULL FOREIGN KEY REFERENCES Tenant(TenantID),
	RegistrationNumber	NVARCHAR(4)		NOT NULL,
	AccountNumber		NVARCHAR(10)	NOT NULL  
);
GO

-- ===============================
-- Opretter tabel til reoltype
-- ===============================
CREATE TABLE ShelfType (
	ShelfTypeID		INT				IDENTITY(1,1) PRIMARY KEY,
	ShelfTypeName	NVARCHAR(30)	NOT NULL UNIQUE,
	ShelfCount		TINYINT			NOT NULL,
	HasHangerRod	BIT				NOT NULL
);
GO

-- ===============================
-- Opretter tabel til reol
-- ===============================
CREATE TABLE Shelf (
	ShelfID			INT				IDENTITY(1,1) PRIMARY KEY,
	ShelfName		NVARCHAR(30)	NOT NULL,
	ShelfTypeID		INT				NOT NULL FOREIGN KEY REFERENCES ShelfType(ShelfTypeID),
	ShelfStatus		BIT				NOT NULL
);
GO

-- ===============================
-- Opretter tabel til leje
-- ===============================
CREATE TABLE Lease (
	LeaseID			INT				IDENTITY(1,1) PRIMARY KEY,
    TenantID		INT				NOT NULL FOREIGN KEY REFERENCES Tenant(TenantID),
	ShelfID			INT				NOT NULL FOREIGN KEY REFERENCES Shelf(ShelfID),
	StartDate		DATE			NOT NULL,
	Price			DECIMAL(10,2)	NOT NULL,
	TerminationDate	DATE			NULL
);
GO

-- ===============================
-- Opretter tabel til venteliste
-- ===============================
CREATE TABLE Waitlist (
    WaitlistID			INT				IDENTITY(1,1) PRIMARY KEY,
    NewTenantID			INT				NOT NULL FOREIGN KEY REFERENCES Tenant(TenantID),
    DesiredShelfTypeID	INT				NULL FOREIGN KEY REFERENCES ShelfType(ShelfTypeID),
    DateAdded			DATE			NOT NULL,
    Note				NVARCHAR(256)	NULL,
    WaitStatus			NVARCHAR(20)	NOT NULL
		CHECK (WaitStatus IN ('Aktiv', 'Inaktiv', 'Konverteret', 'Trukket sig'))
);