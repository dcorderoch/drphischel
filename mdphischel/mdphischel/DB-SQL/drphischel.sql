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

Grant ALTER to DrPhischelDBUser;
GO


--******************************************************************************************************************************************
--**
--**                                      Main definition of tables in DrPhischelDB
--**
--******************************************************************************************************************************************

--Creates table SystemUser. 

GO
CREATE TABLE SystemUser
	(
	UserId char(9) NOT NULL,
	Pass nvarchar(30) NOT NULL,
	Name nvarchar(30) NOT NULL,
	LastName1 nvarchar(30) NOT NULL,
	LastName2 nvarchar(30),
	ResidencePlace nvarchar(100) NOT NULL,
	BirthDate Date NOT NULL
	)

--Creates table SystemRole. 

GO
CREATE TABLE SystemRole
(
RoleId tinyint NOT NULL,
RoleName nvarchar(15) NOT NULL
)

--Creates table RolesPerUser. 

GO
CREATE TABLE RolesPerUser
(
RoleId tinyint NOT NULL,
UserId char(9) NOT NULL
)

--Creates table MedicalRecord.

GO
CREATE TABLE MedicalRecord
(
MedicalRecordId uniqueidentifier NOT NULL,
UserId char(9) NOT NULL,
MRDate Date NOT NULL,
MRDescription varchar(max) NOT NULL,
MRDiagnosis varchar(max) NOT NULL
)

--Creates table Doctor. 

GO
CREATE TABLE Doctor
(
DoctorId nvarchar(15) NOT NULL,
UserId char(9) NOT NULL,
OfficeAddress nvarchar(100) NOT NULL,
Approved Bit NOT NULL,
CreditCardNumber nvarchar(30) NOT NULL,
MedicalSpecialty uniqueidentifier NOT NULL
)

--Creates table PatientOfDoctor. 

GO
CREATE TABLE PatientOfDoctor
(
PatientId char(9) NOT NULL,
DoctorId nvarchar(15) NOT NULL
)

--Creates table Prescription. 

GO
CREATE TABLE Prescription
(
PrescriptionId uniqueidentifier NOT NULL,
DoctorId nvarchar(15) NOT NULL,
PatientId char(9) NOT NULL
)

--Creates table PrescriptionPerMedicalRecord. 

GO
CREATE TABLE PrescriptionPerMedicalRecord
(
MedicalRecordId uniqueidentifier NOT NULL,
PrescriptionId uniqueidentifier NOT NULL
)

--Creates table MedicalSpecialty. 

GO
CREATE TABLE MedicalSpecialty
(
MedicalSpecialtyId uniqueidentifier NOT NULL,
Name nvarchar(30) NOT NULL
)

--Creates table SpecialtyPerDoctor. 

GO
CREATE TABLE SpecialtyPerDoctor
(
SpecialtyId uniqueidentifier NOT NULL,
DoctorId nvarchar(15) NOT NULL
)

--Creates table Appointment. 

GO
CREATE TABLE Appointment
(
AppointmentId uniqueidentifier NOT NULL,
UserId char(9) NOT NULL,
DoctorId nvarchar(15) NOT NULL,
AppointmentDate DateTime NOT NULL
)

--Creates table BranchOffice. 

GO
CREATE TABLE BranchOffice
(
BranchOfficeId uniqueidentifier NOT NULL,
Name nvarchar(30) NOT NULL,
PhoneNumber nvarchar(12) NOT NULL,
BOLocation nvarchar(50) NOT NULL,
Company nvarchar(15)
)

--Creates table Medicine.
GO
CREATE TABLE Medicine
	(
	MedicineId uniqueidentifier NOT NULL,
	Name nvarchar(50) NOT NULL
    )	

-- Creates table MedicinesPerPrescription
GO
CREATE TABLE MedicinesPerPrescription
	(
	PrescriptionId uniqueidentifier NOT NULL,
	MedicineId uniqueidentifier NOT NULL
	)

-- Creates table MedicinesPerBranchOffice
GO
CREATE TABLE MedicinesPerBranchOffice
	(
	BranchOfficeId uniqueidentifier NOT NULL,
	MedicineId uniqueidentifier NOT NULL,
	QuantityAvailable Integer NOT NULL,
	Sales Integer NOT NULL,
	Price decimal(10,2) NOT NULL
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

-- Defines MedicalRecord primary key.

GO
ALTER TABLE MedicalRecord
	ADD CONSTRAINT PK_MedicalRecord
		PRIMARY KEY (MedicalRecordId)

-- Defines PrescriptionPerMedicalRecord primary keys.

GO
ALTER TABLE PrescriptionPerMedicalRecord
	ADD CONSTRAINT PK_PrescriptionPerMedicalRecord
		PRIMARY KEY (MedicalRecordId, PrescriptionId)

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

-- Defines PatientOfDoctor primary keys.

GO
ALTER TABLE PatientOfDoctor
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

-- Defines SpecialtyDoctor primary key.

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

--Defines PatientOfDoctor foreign keys.

GO
ALTER TABLE PatientOfDoctor 
	ADD CONSTRAINT FK_PatientOfDoctor1
		FOREIGN KEY (PatientId)
			REFERENCES SystemUser(UserId)

GO
ALTER TABLE PatientOfDoctor 
	ADD CONSTRAINT FK_PatientOfDoctor2
		FOREIGN KEY (DoctorId)
			REFERENCES Doctor(DoctorId)

--Defines PrescriptionPerMedicalRecord foreign keys.

GO
ALTER TABLE PrescriptionPerMedicalRecord 
	ADD CONSTRAINT FK_PrescriptionPerMedicalRecord1
		FOREIGN KEY (MedicalRecordId)
			REFERENCES MedicalRecord(MedicalRecordId)

GO
ALTER TABLE PrescriptionPerMedicalRecord 
	ADD CONSTRAINT FK_PrescriptionPerMedicalRecord2
		FOREIGN KEY (PrescriptionId)
			REFERENCES Prescription(PrescriptionId)

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
