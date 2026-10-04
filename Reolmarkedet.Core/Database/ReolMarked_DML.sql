-- ===============================
-- Forbinder til databasen
-- ===============================
USE ReolMarkedDB;
GO

-- ===============================
-- Tilføjer reoltyper
-- ===============================
INSERT INTO ShelfType (ShelfTypeName, ShelfCount, HasHangerRod)
VALUES
    ('6 hylder', 6, 0),
    ('3 hylder + bøjlestang', 3, 1);
GO

-- ===============================
-- Tilføjer 80 reoler
-- Type: reol 70-80 har bøjlestang, resten 6 hylder
-- Status: 1 = Ledig, 0 = Optaget
-- ===============================
DECLARE @i INT = 1;
WHILE @i <= 80
BEGIN
    SET NOCOUNT ON; 
    INSERT INTO Shelf (ShelfName, ShelfTypeID, ShelfStatus)
    VALUES (
        'Reol ' + CAST(@i AS NVARCHAR(10)),
        CASE WHEN @i BETWEEN 70 AND 80 THEN 2 ELSE 1 END,
        1 -- alle oprettes som ledige, opdateres nedenfor
    );
    SET @i = @i + 1;
END;
GO

-- ===============================
-- Opretter lejere
-- ===============================
INSERT INTO Tenant (FirstName, LastName, Email, PhoneNumber)
VALUES
    ('Peter', 'Holm', 'peter.holm@mail.dk', '22334455'),
    ('Louise', 'Ebersbach', 'louise.ebersbach@mail.dk', '22335577'),
    ('Hanne', 'Sørensen', 'hanne.sorensen@mail.dk', '22447788'),
    ('Mette', 'Jensen', 'mette.jensen@mail.dk', '20123456'),
    ('Anders', 'Nielsen', 'anders.nielsen@mail.dk', '30234567'),
    ('Sofie', 'Larsen', 'sofie.larsen@mail.dk', '40345678'),
    ('Peter', 'Hansen', 'peter.hansen@mail.dk', '50456789'),
    ('Camilla', 'Poulsen', 'camilla.poulsen@mail.dk', '60567890'),
    ('Lars', 'Christensen', 'lars.christensen@mail.dk', '21678901'),
    ('Julie', 'Andersen', 'julie.andersen@mail.dk', '31789012'),
    ('Mikkel', 'Pedersen', 'mikkel.pedersen@mail.dk', '41890123'),
    ('Stine', 'Møller', 'stine.moller@mail.dk', '51901234'),
    ('Jonas', 'Thomsen', 'jonas.thomsen@mail.dk', '61012345'),
    ('Ida', 'Rasmussen', 'ida.rasmussen@mail.dk', '22123456'),
    ('Frederik', 'Jørgensen', 'frederik.jorgensen@mail.dk', '32234567'),
    ('Emma', 'Sørensen', 'emma.sorensen@mail.dk', '42345678'),
    ('Victor', 'Knudsen', 'victor.knudsen@mail.dk', '52456789'),
    ('Laura', 'Madsen', 'laura.madsen@mail.dk', '62567890'),
    ('Oliver', 'Kristensen', 'oliver.kristensen@mail.dk', '23678901'),
    ('Freja', 'Mortensen', 'freja.mortensen@mail.dk', '33789012'),
    ('Mathias', 'Dam', 'mathias.dam@mail.dk', '43890123'),          -- interesseret, endnu ingen leje
    ('Clara', 'Holm', 'clara.holm@mail.dk', '53901234'),            -- interesseret, endnu ingen leje
    ('Simon', 'Vester', 'simon.vester@mail.dk', '63012345'),        -- interesseret, endnu ingen leje
    ('Anton', 'Mikkelsen', 'anton.mikkelsen@mail.dk', '22556699');  -- interesseret, endnu ingen leje
GO

-- ===============================
-- Opretter bankkonti
-- Kun til lejere med aktiv leje (ikke Anton, jf. forretningsreglen)
-- ===============================
INSERT INTO BankAccount (TenantID, RegistrationNumber, AccountNumber)
VALUES
    (1, '9570', '1234567890'),
    (2, '2222', '2345678901'),
    (3, '9693', '3456789012'),
    (4, '1551', '4567890123'),
    (5, '9280', '5678901234'),
    (6, '7470', '6789012345'),
    (7, '0400', '7890123456'),
    (8, '8075', '8901234567'),
    (9, '5471', '9012345678'),
    (10, '6060', '0123456789'),
    (11, '1111', '1122334455'),
    (12, '9999', '2233445566'),
    (13, '7110', '3344556677'),
    (14, '3409', '4455667788'),
    (15, '2100', '5566778899'),
    (16, '8117', '6677889900'),
    (17, '6845', '7788990011'),
    (18, '0545', '8899001122'),
    (19, '5301', '9900112233'),
    (20, '9087', '0011223344');
GO

-- ===============================
-- Opretter lejemål (scenarie 2: Peter lejer sin tredje reol)
-- Reol 7 og 42 lejet 15.07.2026, reol 43 tilføjet 02.09.2026
-- ===============================
DECLARE @PeterID INT = (SELECT TenantID FROM Tenant WHERE Email = 'peter.holm@mail.dk'); -- Angiver en lokal variabel og deklarerer den med et specifikt ID.

INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (@PeterID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 7'),  '2026-07-15', 850.00, NULL),
    (@PeterID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 42'), '2026-07-15', 825.00, NULL),
    (@PeterID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 43'), '2026-09-02', 825.00, NULL);
GO

-- ===============================
-- Opretter lejemål (scenarie 5: Louise opsiger reol 54)
-- Reol 54 opsagt pr. 30.10.2026, reol 55 fortsat aktiv
-- ===============================
DECLARE @LouiseID INT = (SELECT TenantID FROM Tenant WHERE Email = 'louise.ebersbach@mail.dk');

INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (@LouiseID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 54'), '2026-03-15', 850.00, '2026-10-30'),
    (@LouiseID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 55'), '2026-04-15', 825.00, NULL);
GO

-- ===============================
-- Opretter lejemål (Hanne Sørensen, nævnt i artiklen: "booket to reoler")
-- ===============================
DECLARE @HanneID INT = (SELECT TenantID FROM Tenant WHERE Email = 'hanne.sorensen@mail.dk');

INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (@HanneID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 19'), '2026-06-01', 850.00, NULL),
    (@HanneID, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 27'), '2026-06-01', 825.00, NULL);
GO

-- ===============================
-- Opretter lejemål for de resterende lejere (TenantID 4-20)
-- Spredning på tværs af 1, 2, 3 og 4+ reoler for at teste prisniveauer
-- ===============================

-- 1 reol (850 kr/md)
INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (4,  (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 1'),  '2026-05-01', 850.00, NULL), -- Mette Jensen
    (5,  (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 2'),  '2026-05-10', 850.00, NULL), -- Anders Nielsen
    (10, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 15'), '2026-06-15', 850.00, NULL), -- Julie Andersen
    (11, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 16'), '2026-06-20', 850.00, NULL), -- Mikkel Pedersen
    (13, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 20'), '2026-07-01', 850.00, NULL), -- Jonas Thomsen
    (14, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 21'), '2026-07-05', 850.00, NULL), -- Ida Rasmussen
    (15, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 22'), '2026-07-10', 850.00, NULL), -- Frederik Jørgensen
    (17, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 25'), '2026-08-01', 850.00, NULL), -- Victor Knudsen
    (18, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 26'), '2026-08-05', 850.00, NULL), -- Laura Madsen
    (19, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 28'), '2026-08-10', 850.00, NULL), -- Oliver Kristensen
    (20, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 70'), '2026-08-15', 850.00, NULL); -- Freja Mortensen (bøjlestang)
GO

-- 2 reoler (825 kr/md pr. reol)
INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (6,  (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 3'),  '2026-05-15', 850.00, NULL), -- Sofie Larsen
    (6,  (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 4'),  '2026-05-15', 825.00, NULL),
    (7,  (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 5'),  '2026-05-20', 850.00, NULL), -- Peter Hansen
    (7,  (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 6'),  '2026-05-20', 825.00, NULL),
    (12, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 17'), '2026-06-25', 850.00, NULL), -- Stine Møller
    (12, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 18'), '2026-06-25', 825.00, NULL),
    (16, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 23'), '2026-07-20', 850.00, NULL), -- Emma Sørensen
    (16, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 24'), '2026-07-20', 825.00, NULL);
GO

-- 3 reoler (825 kr/md pr. reol)
INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (8, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 8'),  '2026-06-01', 850.00, NULL), -- Camilla Poulsen
    (8, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 9'),  '2026-06-01', 825.00, NULL),
    (8, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 10'), '2026-06-01', 825.00, NULL);
GO

-- 4 reoler (800 kr/md pr. reol)
INSERT INTO Lease (TenantID, ShelfID, StartDate, Price, TerminationDate)
VALUES
    (9, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 11'), '2026-06-10', 850.00, NULL), -- Lars Christensen
    (9, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 12'), '2026-06-10', 825.00, NULL),
    (9, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 13'), '2026-06-10', 825.00, NULL),
    (9, (SELECT ShelfID FROM Shelf WHERE ShelfName = 'Reol 14'), '2026-06-10', 800.00, NULL);
GO

-- ===============================
-- Opdaterer status på de nye udlejede reoler (0 = Optaget)
-- ===============================
UPDATE Shelf SET ShelfStatus = 0
WHERE ShelfName IN (
    'Reol 1','Reol 2','Reol 3','Reol 4','Reol 5','Reol 6','Reol 7',
    'Reol 8','Reol 9','Reol 10','Reol 11','Reol 12','Reol 13','Reol 14',
    'Reol 15','Reol 16','Reol 17','Reol 18', 'Reol 19','Reol 20','Reol 21',
    'Reol 22','Reol 23','Reol 24','Reol 25','Reol 26', 'Reol 27','Reol 28',
    'Reol 42', 'Reol 43','Reol 54', 'Reol 55','Reol 70'
);
GO

-- ===============================
-- Opretter venteliste (scenarie 1: Anton besøger markedet)
-- Han går uden at beslutte sig, men vil starte i det små med hylder
-- ===============================
DECLARE @AntonID INT = (SELECT TenantID FROM Tenant WHERE Email = 'anton.mikkelsen@mail.dk');
DECLARE @MathiasID INT = (SELECT TenantID FROM Tenant WHERE Email = 'mathias.dam@mail.dk');
DECLARE @ClaraID INT = (SELECT TenantID FROM Tenant WHERE Email = 'clara.holm@mail.dk');
DECLARE @SimonID INT = (SELECT TenantID FROM Tenant WHERE Email = 'simon.vester@mail.dk');

INSERT INTO Waitlist (NewTenantID, DesiredShelfTypeID, DateAdded, Note, WaitStatus)
VALUES 
    (@AntonID, 1, '2026-09-22', 'Overvejer at sælge håndlavede trævarer.', 'Aktiv'),
    (@MathiasID, 1, '2026-08-01', 'Ønsker helst en reol med 6 hylder', 'Aktiv'),
    (@ClaraID, 2, '2026-08-10', 'Skal bruge bøjlestang til tøj', 'Aktiv'),
    (@SimonID, NULL, '2026-08-20', 'Ingen specifik præference', 'Inaktiv');

-- ===============================
-- Sikrer at ventelisten kun gemmer 4 værdier
-- ===============================
ALTER TABLE Waitlist
ADD CONSTRAINT CHK_Waitlist_WaitStatus
CHECK (WaitStatus IN ('Aktiv', 'Konverteret', 'Trukket sig', 'Inaktiv'));
GO