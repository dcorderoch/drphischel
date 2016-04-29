--******************************************************************************************************************************************
--**
--**                                     Azure configuration and user account creation
--**
--******************************************************************************************************************************************

CREATE LOGIN DrPhischelDBUser
	WITH PASSWORD = 'DrPhischel';
GO

CREATE USER DrPhischelDBUser FOR LOGIN DrPhischelDBUser;
GO

--Grant permissions
EXEC sp_addrolemember 'db_owner', 'DrPhischelDBUser';
GO

CREATE DATABASE DrPhischelDB;
GO

USE DrPhischelDB
Grant ALTER to DrPhischelDBUser;
GO

DROP DATABASE DrPhischelDB
--******************************************************************************************************************************************
--**
--**                                      Main definition of tables in DrPhischelDB
--**
--******************************************************************************************************************************************

--Creates table SystemUser. 

GO
CREATE TABLE SystemUser
	(
	UserId int identity(1,1) NOT NULL,
	IdNumber char(9) unique NOT NULL,
	Pass nvarchar(30) NOT NULL,
	Name nvarchar(30) NOT NULL,
	LastName1 nvarchar(30) NOT NULL,
	LastName2 nvarchar(30),
	ResidencePlace nvarchar(100) NOT NULL,
	BirthDate Date NOT NULL,
	IsActive Bit NOT NULL
	)

-- Adds unique constraint to IdNumber.

	ALTER TABLE SystemUser
		ADD UNIQUE (IdNumber)

--Creates table SystemRole. 

GO
CREATE TABLE SystemRole
(
RoleId int identity(1,1) NOT NULL,
RoleName nvarchar(15) NOT NULL
)

--Creates table RolesPerUser. 

GO
CREATE TABLE RolesPerUser
(
RoleId int NOT NULL,
UserId int NOT NULL
)

--Creates table MedicalRecord.

GO
CREATE TABLE MedicalRecord
(
MedicalRecordId int identity(1,1) NOT NULL,
UserId int NOT NULL
)

--Creates table MedicalRecordData.

GO
CREATE TABLE MedicalRecordData
(
MedicalRecordId int NOT NULL,
AppointmentId int NOT NULL,
MRDescription varchar(max) NOT NULL,
MRDiagnosis varchar(max) NOT NULL,
PrescriptionId int NOT NULL
)

--Creates table Doctor. 

GO
CREATE TABLE Doctor
(
DoctorId int identity(1,1) NOT NULL,
DoctorCode nvarchar (15) NOT NULL,
UserId int NOT NULL,
OfficeAddress nvarchar(100) NOT NULL,
IsActive Bit NOT NULL,
CreditCardNumber nvarchar(30) NOT NULL
)

-- Set unique constraints on DoctorCode and CreditCardNumber.

ALTER TABLE Doctor
		ADD UNIQUE (DoctorCode)

ALTER TABLE Doctor
		ADD UNIQUE (CreditCardNumber)

--Creates table PatientByDoctor. 

GO
CREATE TABLE PatientByDoctor
(
PatientId int NOT NULL,
DoctorId int NOT NULL
)

--Creates table Prescription. 

GO
CREATE TABLE Prescription
(
PrescriptionId int identity(1,1) NOT NULL,
DoctorId int NOT NULL,
PatientId int NOT NULL
)


--Creates table MedicalSpecialty. 

GO
CREATE TABLE MedicalSpecialty
(
MedicalSpecialtyId int identity(1,1) NOT NULL,
Name nvarchar(30) NOT NULL
)

--Creates table SpecialtyPerDoctor. 

GO
CREATE TABLE SpecialtyPerDoctor
(
SpecialtyId int NOT NULL,
DoctorId int NOT NULL
)

--Creates table Appointment. 

GO
CREATE TABLE Appointment
(
AppointmentId int identity(1,1) NOT NULL,
UserId int NOT NULL,
DoctorId int NOT NULL,
AppointmentDate DateTime NOT NULL
)

--Creates table BranchOffice. 

GO
CREATE TABLE BranchOffice
(
BranchOfficeId int identity(1,1) NOT NULL,
Name nvarchar(30) NOT NULL,
PhoneNumber nvarchar(12) NOT NULL,
BOLocation nvarchar(50) NOT NULL,
Company nvarchar(15)
)

--Creates table Medicine.
GO
CREATE TABLE Medicine
	(
	MedicineId int identity(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL
    )	

-- Creates table MedicinesPerPrescription

GO
CREATE TABLE MedicinesPerPrescription
	(
	PrescriptionId int NOT NULL,
	MedicineId int NOT NULL
	)

-- Creates table MedicinesPerBranchOffice

GO
CREATE TABLE MedicinesPerBranchOffice
	(
	BranchOfficeId int NOT NULL,
	MedicineId int NOT NULL,
	QuantityAvailable Integer NOT NULL,
	Sales Integer NOT NULL,
	Price decimal(10,2) NOT NULL
	)

-- Creates table Charges.

GO
CREATE TABLE Charges
(
DoctorId int NOT NULL,
AppointmentId int NOT NULL
)

--******************************************************************************************************************************************
--**
--**                                      Primary keys definition for tables in DrPhischelDB
--**
--******************************************************************************************************************************************

-- Defines SystemUser primary key.

GO
ALTER TABLE SystemUser
	ADD CONSTRAINT PK_User
		PRIMARY KEY (UserId)

-- Defines SystemRole primary key.

GO
ALTER TABLE SystemRole
	ADD CONSTRAINT PK_Role
		PRIMARY KEY (RoleId)

-- Defines MedicalRecord primary keys.

GO
ALTER TABLE MedicalRecord
	ADD CONSTRAINT PK_MedicalRecord
		PRIMARY KEY (MedicalRecordId)

-- Defines MedicalRecord primary keys.

GO
ALTER TABLE MedicalRecordData
	ADD CONSTRAINT PK_MedicalRecordData
		PRIMARY KEY (MedicalRecordId, AppointmentId)

-- Defines RolesPerUser primary keys.

GO
ALTER TABLE RolesPerUser
	ADD CONSTRAINT PK_RolesPerUser
		PRIMARY KEY (RoleId, UserId)

-- Defines Doctor primary key.

GO
ALTER TABLE Doctor
	ADD CONSTRAINT PK_Doctor
		PRIMARY KEY (DoctorId)

-- Defines PatientByDoctor primary keys.

GO
ALTER TABLE PatientByDoctor
	ADD CONSTRAINT PK_PatientOfDoctor
		PRIMARY KEY (PatientId, DoctorId)

-- Defines Appointment primary key.

GO
ALTER TABLE Appointment
	ADD CONSTRAINT PK_Appointment
		PRIMARY KEY (AppointmentId)

-- Defines Prescription primary key.

GO
ALTER TABLE Prescription
	ADD CONSTRAINT PK_Prescription
		PRIMARY KEY (PrescriptionId)

-- Defines MedicalSpecialty primary key.

GO
ALTER TABLE MedicalSpecialty
	ADD CONSTRAINT PK_MedicalSpecialty
		PRIMARY KEY (MedicalSpecialtyId)

-- Defines SpecialtyPerDoctor primary key.

GO
ALTER TABLE SpecialtyPerDoctor
	ADD CONSTRAINT PK_SpecialtyPerDoctor
		PRIMARY KEY (SpecialtyId)

-- Defines BranchOffice primary key.

GO
ALTER TABLE BranchOffice
	ADD CONSTRAINT PK_BranchOffice
		PRIMARY KEY (BranchOfficeId)

-- Defines Medicine primary key.

GO
ALTER TABLE Medicine
	ADD CONSTRAINT PK_Medicine
		PRIMARY KEY (MedicineId)

-- Defines MedicinesPerBranchOffice primary keys.

GO
ALTER TABLE MedicinesPerBranchOffice
	ADD CONSTRAINT PK_MedicinesPerBranchOffice
		PRIMARY KEY (BranchOfficeId, MedicineId)

-- Defines MedicinesPerPrescription primary keys.

GO
ALTER TABLE MedicinesPerPrescription
	ADD CONSTRAINT PK_MedicinesPerPrescription
		PRIMARY KEY (PrescriptionId, MedicineId)

-- Defines Charges primary key.

GO
ALTER TABLE Charges
	ADD CONSTRAINT PK_Charges
		PRIMARY KEY (DoctorId)

--******************************************************************************************************************************************
--**
--**                                      Foreign keys definition for tables in DrPhischelDB
--**
--******************************************************************************************************************************************

--Defines RolesPerUser foreign keys.

GO
ALTER TABLE RolesPerUser 
	ADD CONSTRAINT FK_RolesPerUser1
		FOREIGN KEY (RoleId)
			REFERENCES SystemRole(RoleId)

GO
ALTER TABLE RolesPerUser 
	ADD CONSTRAINT FK_RolesPerUser2
		FOREIGN KEY (UserId)
			REFERENCES SystemUser(UserId)

--Defines MedicalRecord foreign key.

GO
ALTER TABLE MedicalRecord 
	ADD CONSTRAINT FK_MedicalRecord
		FOREIGN KEY (UserId)
			REFERENCES SystemUser(UserId)

--Defines Doctor foreign key.

GO
ALTER TABLE Doctor 
	ADD CONSTRAINT FK_Doctor
		FOREIGN KEY (UserId)
			REFERENCES SystemUser(UserId)

--Defines PatientByDoctor foreign keys.

GO
ALTER TABLE PatientByDoctor 
	ADD CONSTRAINT FK_PatientOfDoctor1
		FOREIGN KEY (PatientId)
			REFERENCES SystemUser(UserId)

GO
ALTER TABLE PatientByDoctor 
	ADD CONSTRAINT FK_PatientOfDoctor2
		FOREIGN KEY (DoctorId)
			REFERENCES Doctor(DoctorId)

--Defines Appointment foreign keys.

GO
ALTER TABLE Appointment 
	ADD CONSTRAINT FK_Appointment1
		FOREIGN KEY (UserId)
			REFERENCES SystemUser(UserId)

GO
ALTER TABLE Appointment 
	ADD CONSTRAINT FK_Appointment2
		FOREIGN KEY (DoctorId)
			REFERENCES Doctor(DoctorId)

--Defines Prescription foreign keys.

GO
ALTER TABLE Prescription 
	ADD CONSTRAINT FK_Prescription1
		FOREIGN KEY (PatientId)
			REFERENCES SystemUser(UserId)

GO
ALTER TABLE Prescription 
	ADD CONSTRAINT FK_Prescription2
		FOREIGN KEY (DoctorId)
			REFERENCES Doctor(DoctorId)

--Defines SpecialtyPerDoctor foreign keys.

GO
ALTER TABLE SpecialtyPerDoctor 
	ADD CONSTRAINT FK_SpecialtyPerDoctor1
		FOREIGN KEY (SpecialtyId)
			REFERENCES MedicalSpecialty(MedicalSpecialtyId)

GO
ALTER TABLE SpecialtyPerDoctor 
	ADD CONSTRAINT FK_SpecialtyPerDoctor2
		FOREIGN KEY (DoctorId)
			REFERENCES Doctor(DoctorId)

--Defines MedicinesPerBranchOffice foreign keys.

GO
ALTER TABLE MedicinesPerBranchOffice 
	ADD CONSTRAINT FK_MedicinesPerBranchOffice1
		FOREIGN KEY (BranchOfficeId)
			REFERENCES BranchOffice(BranchOfficeId)

GO
ALTER TABLE MedicinesPerBranchOffice 
	ADD CONSTRAINT FK_MedicinesPerBranchOffice2
		FOREIGN KEY (MedicineId)
			REFERENCES Medicine(MedicineId)

--Defines MedicinesPerPrescription foreign keys.

GO
ALTER TABLE MedicinesPerPrescription 
	ADD CONSTRAINT FK_MedicinesPerPrescription1
		FOREIGN KEY (PrescriptionId)
			REFERENCES Prescription(PrescriptionId)

GO
ALTER TABLE MedicinesPerPrescription 
	ADD CONSTRAINT FK_MedicinesPerPrescription2
		FOREIGN KEY (MedicineId)
			REFERENCES Medicine(MedicineId)

-- Defines Charges foreign key.
GO
ALTER TABLE Charges
	ADD CONSTRAINT FK_Charges
		FOREIGN KEY(DoctorId)
			REFERENCES Doctor(DoctorId)

-- Defines MedicalRecordData foreign keys.

GO
ALTER TABLE MedicalRecordData
	ADD CONSTRAINT FK_MedicalRecordData1
		FOREIGN KEY (MedicalRecordId)
			REFERENCES MedicalRecord(MedicalRecordId)

GO
ALTER TABLE MedicalRecordData
	ADD CONSTRAINT FK_MedicalRecordData2
		FOREIGN KEY (AppointmentId)
			REFERENCES Appointment(AppointmentId)

GO
ALTER TABLE MedicalRecordData
	ADD CONSTRAINT FK_MedicalRecordData3
		FOREIGN KEY (PrescriptionId)
			REFERENCES Prescription(PrescriptionId)


--******************************************************************************************************************************************
--**
--**                                      DrPhischelDB Population
--**
--******************************************************************************************************************************************

-- Insertion of Roles

GO
INSERT INTO SystemRole
VALUES ('Patient'),
	   ('Administrator'),
	   ('Doctor')
	   ;
GO

-- Insertion of BranchOffices

INSERT INTO BranchOffice
VALUES ('Medio Queso', '27849596', 'Los Chiles', 'Farmatica'),
	   ('Manuel Antonio', '26709596', 'Quepos', 'Phischel'),
	   ('Cariari', '25325960', 'Pococi','Farmatica'),
	   ('San Antonio', '22395960', 'Belen', 'Phischel'),
	   ('La Aurora', '22934364', 'Heredia', 'Phischel'),
	   ('Chomes', '28734364', 'Puntarenas','Farmatica'),
	   ('Miami', '1998293451', 'Florida','Farmatica'),
	   ('Escazu', '22157084', 'San Jose', 'Farmatica')
	   ;
GO

-- Insertion of Users.

INSERT INTO	SystemUser
VALUES ('123456789', 'moradodecorazon32', 'Kevin', 'Umaña', 'Ortega', 'Heredia', '1992-10-03', 1),
	   ('987654321', 'frenteampliorocks', 'Manuel', 'Zumbado', 'Corrales', 'Belen', '1993-11-11', 1),
	   ('123581321', 'miamigohelo', 'Nicolas', 'Jimenez', 'Garcia', 'Tres Rios', '1994-12-12',1),
	   ('111222333', 'soypoliglota', 'David', 'Cordero', 'Chavarria', 'Chomes', '1991-10-10',1),
	   ('101230456', 'adelrio', 'Alberto', 'Del Rio', '', 'Puntarenas', '1964-09-10',1),
	   ('991230456', 'bsmith', 'Ben', 'Smith', ' ', 'Miami','1975-12-08',1)
	   ;
GO
--Insertion of Doctors

INSERT INTO Doctor
VALUES ('ABC001', 5,'Puntarenas',1,'1234567890123'),
	   ('ABC005', 6,'Miami',1,'9876567890123')
;
GO
-- Insertion of BranchOffices

INSERT INTO BranchOffice
VALUES ('Medio Queso', '27849596', 'Los Chiles', 'Farmatica'),
	   ('Manuel Antonio', '26709596', 'Quepos', 'Phischel'),
	   ('Cariari', '25325960', 'Pococi','Farmatica'),
	   ('San Antonio', '22395960', 'Belen', 'Phischel'),
	   ('La Aurora', '22934364', 'Heredia', 'Phischel'),
	   ('Chomes', '28734364', 'Puntarenas','Farmatica'),
	   ('Miami', '1998293451', 'Florida','Farmatica'),
	   ('Escazu', '22157084', 'San Jose', 'Farmatica')
	   ;
GO
-- Insertion of Appointments

INSERT INTO Appointment
VALUES (2, 1, '20160503 14:00:00');
GO
--Insertion of MedicalRecords

INSERT INTO MedicalRecord
VALUES (1),
	   (2),
	   (3)
;
GO
-- Insertion of Prescription

INSERT INTO Prescription
VALUES (1,2);
GO
-- Insertion of MedicalRecordData

INSERT INTO MedicalRecordData
VALUES (2,1, 'Dolores de cabeza severos', 'Migrañas',1);
GO
--Insertion of Medical Specialties

INSERT INTO MedicalSpecialty
VALUES ('Ginecologia'),
	   ('Otorrinolaringologia'),	
	   ('Urologia'),
	   ('Ortopedia'),
	   ('Odontologia'),
	   ('Cardiologia'),
	   ('Urologia'),
	   ('Neurologia');
GO	   
-- Insertion of Medicines

INSERT INTO Medicine
VALUES ('Acetaminofen'),
	   ('Ibuprofeno'),
	   ('Dorival'),
	   ('Espasmo Canulase'),
	   ('Ritalina'),
	   ('Concerta'),
	   ('Selfemra')
	   ;	   
	   GO
-- Insertion of MedicinesPerBO

INSERT INTO MedicinesPerBranchOffice
VALUES (17, 1, 20, 11,13.50);	   
GO

-- Insertion of MedicinesPerPrescription

INSERT INTO MedicinesPerPrescription
VALUES (1,2),
	   (1,3),
	   (1,7),
	   (1,5);
GO
-- Insertion of PatientByDoctor

INSERT INTO PatientByDoctor
VALUES (1,1),
	   (1,2);
GO
-- Insertion of RolesPerUser

INSERT INTO RolesPerUser
VALUES (1,1),
	   (2,3),
	   (3,5);
GO

-- Insertion of SpecialtyPerDoctor

INSERT INTO SpecialtyPerDoctor
VALUES (2,2),
	   (7,2);
GO
