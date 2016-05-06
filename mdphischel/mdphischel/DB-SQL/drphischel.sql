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
PrescriptionId uniqueidentifier NOT NULL
)

--Creates table Doctor. 

GO
CREATE TABLE Doctor
(
DoctorId nvarchar(15) NOT NULL,
UserId int NOT NULL,
OfficeAddress nvarchar(100) NOT NULL,
IsActive Bit NOT NULL,
CreditCardNumber nvarchar(30) NOT NULL
)

-- Set unique constraints on DoctorCode and CreditCardNumber.

ALTER TABLE Doctor
		ADD UNIQUE (CreditCardNumber)

--Creates table PatientByDoctor. 

GO
CREATE TABLE PatientByDoctor
(
PatientId int NOT NULL,
DoctorId nvarchar(15) NOT NULL
)

--Creates table Prescription. 

GO
CREATE TABLE Prescription
(
PrescriptionId uniqueidentifier NOT NULL,
DoctorId nvarchar(15) NOT NULL,
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
DoctorId nvarchar(15) NOT NULL
)

--Creates table Appointment. 

GO
CREATE TABLE Appointment
(
AppointmentId int identity(1,1) NOT NULL,
UserId int NOT NULL,
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

-- Creates table Charges.

GO
CREATE TABLE Charges
(
DoctorId nvarchar(15) NOT NULL,
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
	ADD CONSTRAINT PK_PatientByDoctor
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


-- Insertion of RolesPerUser

INSERT INTO RolesPerUser
VALUES (1,1),
	   (2,3),
	   (3,5);
GO

--Insertion of Doctors

INSERT INTO Doctor
VALUES ('ABC001', 5,'Puntarenas',1,'1234567890123'),
	   ('ABC005', 6,'Miami',1,'9876567890123')
;
GO

-- Insertion of PatientByDoctor

INSERT INTO PatientByDoctor
VALUES (1,'ABC001'),
	   (1,'ABC005');
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

-- Insertion of SpecialtyPerDoctor

INSERT INTO SpecialtyPerDoctor
VALUES (2,'ABC001'),
	   (7,'ABC005');
GO

-- Insertion of BranchOffices

INSERT INTO BranchOffice
VALUES ('B37E8C8F-C87A-437F-A3EE-6BF8EE4A46A4','Medio Queso', '27849596', 'Los Chiles', 'Farmatica'),
	   ('E9FF6BE1-E98F-4457-921C-9E9D252B1B82','Manuel Antonio', '26709596', 'Quepos', 'Phischel'),
	   ('D8A579BE-787E-4BDA-BF41-9A8633658B53','Cariari', '25325960', 'Pococi','Farmatica'),
	   ('10E29C84-D4C2-4912-800C-F5E85182FA23','San Antonio', '22395960', 'Belen', 'Phischel'),
	   ('90F0E6EF-FD2B-444D-B1E2-8C214F796779','La Aurora', '22934364', 'Heredia', 'Phischel'),
	   ('E0BE3E4A-76C6-4CAD-A5C5-FA29F6E510FB','Chomes', '28734364', 'Puntarenas','Farmatica'),
	   ('56B8F386-9D3B-421F-9782-A87C28EFE38C','Miami', '1998293451', 'Florida','Farmatica'),
	   ('BFFCF0E6-EBAC-45F2-8B12-B639A3EAF9C7','Escazu', '22157084', 'San Jose', 'Farmatica')
	   ;
GO
-- Insertion of Appointments

INSERT INTO Appointment
VALUES (2, 'ABC001', '20160503 14:00:00');
GO

--Insertion of MedicalRecords

INSERT INTO MedicalRecord
VALUES (1),
	   (2),
	   (3)
;
GO

-- Insertion of Medicines

INSERT INTO Medicine
VALUES ('13E4016D-8BCC-441C-9C23-E8BDC3A63D4F','Acetaminofen'),
	   ('2385CC87-28CB-4F9E-9229-6F52899C7B53','Ibuprofeno'),
	   ('4296C5AD-F84E-431A-87C0-EBC25566BEC4','Dorival'),
	   ('BBA8328F-6DEF-4210-AFC7-EFC8E6D0EAAD','Espasmo Canulase'),
	   ('063FBD7F-96CC-452D-85EC-E146C43F8577','Ritalina'),
	   ('BA91B309-E91B-4873-94DC-82E021838F4C','Concerta'),
	   ('C3F002DF-4E5E-41FF-97D6-933B50936EE6','Selfemra')
	   ;	   
GO

-- Insertion of Prescription

DECLARE @PrescriptionId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Prescription
VALUES (@PrescriptionId,'ABC001',1);

-- Insertion of MedicalRecordData

INSERT INTO MedicalRecordData
VALUES (2,1, 'Dolores de cabeza severos', 'Migrañas',@PrescriptionId);

-- Insertion of MedicinesPerPrescription

INSERT INTO MedicinesPerPrescription
VALUES (@PrescriptionId,'13E4016D-8BCC-441C-9C23-E8BDC3A63D4F'),
	   (@PrescriptionId,'BA91B309-E91B-4873-94DC-82E021838F4C'),
	   (@PrescriptionId,'2385CC87-28CB-4F9E-9229-6F52899C7B53'),
	   (@PrescriptionId,'BBA8328F-6DEF-4210-AFC7-EFC8E6D0EAAD');
GO

-- Insertion of MedicinesPerBO

-- Miami
INSERT INTO MedicinesPerBranchOffice
VALUES ('56B8F386-9D3B-421F-9782-A87C28EFE38C', '13E4016D-8BCC-441C-9C23-E8BDC3A63D4F', 20, 11,13.50),
	   ('56B8F386-9D3B-421F-9782-A87C28EFE38C', 'BA91B309-E91B-4873-94DC-82E021838F4C', 50, 25, 2.00),
	   ('56B8F386-9D3B-421F-9782-A87C28EFE38C', '2385CC87-28CB-4F9E-9229-6F52899C7B53', 95, 80, 3.00)
	   ;	   
GO

-- Cariari
INSERT INTO MedicinesPerBranchOffice
VALUES ('D8A579BE-787E-4BDA-BF41-9A8633658B53', 'BBA8328F-6DEF-4210-AFC7-EFC8E6D0EAAD', 20, 15, 10000),
	   ('D8A579BE-787E-4BDA-BF41-9A8633658B53', '13E4016D-8BCC-441C-9C23-E8BDC3A63D4F', 30, 26, 3000),
	   ('D8A579BE-787E-4BDA-BF41-9A8633658B53', '2385CC87-28CB-4F9E-9229-6F52899C7B53', 20, 8, 12500)
	   ;	   
GO

-- Chomes

INSERT INTO MedicinesPerBranchOffice
VALUES ('E0BE3E4A-76C6-4CAD-A5C5-FA29F6E510FB', '13E4016D-8BCC-441C-9C23-E8BDC3A63D4F', 20, 15,10000),
	   ('E0BE3E4A-76C6-4CAD-A5C5-FA29F6E510FB', '2385CC87-28CB-4F9E-9229-6F52899C7B53', 40, 35, 1500),
	   ('E0BE3E4A-76C6-4CAD-A5C5-FA29F6E510FB', '4296C5AD-F84E-431A-87C0-EBC25566BEC4', 30, 26, 3000)
	   ;	   
GO


--******************************************************************************************************************************************
--**
--**                                      Definition of Stored Procedures and Triggers
--**
--******************************************************************************************************************************************

-- Create patient
GO
CREATE PROCEDURE uspCreatePatient @IdNumber char(9),@Pass nvarchar(30),	@Name nvarchar(30),	@LastName1 nvarchar(30), @LastName2 nvarchar(30), @Residence nvarchar(30), @BirthDate Date, @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t100
  BEGIN TRY
   DECLARE @generatedId int
   INSERT INTO SystemUser VALUES (@IdNumber,@Pass,@Name,@LastName1,@LastName2,@Residence,@BirthDate,1)
   SELECT @generatedId=UserId FROM SystemUser WHERE IdNumber=@IdNumber
   INSERT INTO RolesPerUser VALUES(1,@generatedId)
   INSERT INTO MedicalRecord VALUES(@generatedId)
  END TRY
  BEGIN CATCH
   SET @errorNum = Error_Number()
   SET @result = 0
   ROLLBACK TRANSACTION t100
   RETURN 
     END CATCH
 COMMIT TRANSACTION t100
 SET @result =1
 RETURN
END
GO
-- Link Patient to Specific Doctor stored procedure.

GO
CREATE PROCEDURE uspLinkToDoctor @doctorId nvarchar(15), @idNumber char(9), @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
BEGIN TRANSACTION t101
DECLARE @generatedId int
  BEGIN TRY
	SELECT @generatedId=UserId FROM SystemUser WHERE IdNumber=@IdNumber	
	INSERT INTO PatientByDoctor
	VALUES (@generatedId, @doctorId)
  END TRY
	BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result = 0
		ROLLBACK TRANSACTION t101
		RETURN
     END CATCH
 COMMIT TRANSACTION t101
 SET @result =1
 RETURN
END
GO

-- Update patient stored procedure.

GO
CREATE PROCEDURE uspUpdatePatient @IdNumber char(9), @Pass nvarchar(30), @Name nvarchar(30),@LastName1 nvarchar(30), @LastName2 nvarchar(30), @Residence nvarchar(30), @BirthDate Date, @result int OUTPUT, @errorNum int OUTPUT  
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t102
  DECLARE @generatedId int
  BEGIN TRY
	SELECT @generatedId=UserId FROM SystemUser WHERE IdNumber=@IdNumber
	UPDATE SystemUser
	SET IdNumber =@IdNumber, Pass=@Pass, Name= @Name, LastName1=@LastName1, LastName2 =@LastName2, ResidencePlace = @Residence, BirthDate = @BirthDate
    WHERE UserId = @generatedId;
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result = 0
		ROLLBACK TRANSACTION t102
		RETURN
  END CATCH
 COMMIT TRANSACTION t102
 SET @result = 1
 RETURN 	
END
GO

-- Delete patient stored procedure.

GO
CREATE PROCEDURE uspDeletePatient @IdNumber char(9),@result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t103
  DECLARE @generatedId int
  BEGIN TRY
	SELECT @generatedId=UserId FROM SystemUser WHERE IdNumber=@IdNumber
	UPDATE SystemUser
	SET IsActive = 0
	WHERE UserId = @generatedId;
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result= 0
		ROLLBACK TRANSACTION t103
		RETURN 
     END CATCH
 COMMIT TRANSACTION t103
 SET @result = 1
 RETURN
END
GO

-- *************************************************** MedicalSpecialty ****************************************************************************

-- Add new medical specialty.

GO
CREATE PROCEDURE uspAddMedicalSpecialty @MedicalSpecialtyName nvarchar(30), @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t104
  BEGIN TRY
  IF (NOT EXISTS(SELECT * FROM MedicalSpecialty WHERE MedicalSpecialty.Name = @MedicalSpecialtyName)) 
  BEGIN
	INSERT INTO MedicalSpecialty
	VALUES (@MedicalSpecialtyName)
  END
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result = 0
		ROLLBACK TRANSACTION t104
		RETURN
     END CATCH
 COMMIT TRANSACTION t104
 SET @result = 1
 RETURN
END
GO


-- *************************************************** Appointments ****************************************************************************

-- Create new appointment

GO
CREATE PROCEDURE uspAddNewAppointment @UserId int, @DoctorId nvarchar (15), @AppointmentDateTime DateTime, @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t105
  DECLARE @generatedId int
  BEGIN TRY
	IF Convert(datetime, Convert(int, @AppointmentDateTime)) >= Convert(datetime, Convert(int, GetDate())) AND (NOT EXISTS(SELECT * FROM Appointment WHERE Appointment.AppointmentDate = @AppointmentDateTime AND DoctorId = @DoctorId)) 
	INSERT INTO Appointment
	VALUES(@UserId, @DoctorId, @AppointmentDateTime)
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result = 0
		ROLLBACK TRANSACTION t105
		RETURN
  END CATCH
 COMMIT TRANSACTION t105
 SET @result = 1
 RETURN
END
GO

-- Update Appointment Stored Procedure.

GO
CREATE PROCEDURE uspUpdateAppointment @UserId int, @DoctorId nvarchar(15), @OldAppointment DATETIME, @NewAppointment DATETIME, @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t106
  BEGIN TRY
  DECLARE @generatedId int
  BEGIN
	IF Convert(datetime, Convert(int, @NewAppointment)) >= Convert(datetime, Convert(int, GetDate())) AND (NOT EXISTS(SELECT * FROM Appointment WHERE AppointmentDate = @NewAppointment AND DoctorId = @DoctorId))
	SELECT @generatedId=AppointmentId FROM Appointment WHERE DoctorId=@DoctorId AND UserId = @UserId AND AppointmentDate = @OldAppointment
	UPDATE Appointment
	SET AppointmentDate = @NewAppointment
	WHERE AppointmentId = @generatedId;
  END
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result = 0
		ROLLBACK TRANSACTION t106
		RETURN
  END CATCH
 COMMIT TRANSACTION t106
 SET @result = 1
 RETURN
END
GO

-- Delete Appointment stored procedure.

GO
CREATE PROCEDURE uspDeleteAppointment @UserId int, @DoctorId nvarchar(15), @AppointmentDate DATETIME, @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t107
  BEGIN TRY
  DECLARE @generatedId int
  BEGIN
	IF Convert(datetime, Convert(int, @AppointmentDate)) > Convert(datetime, Convert(int, GetDate()))
	SELECT @generatedId=AppointmentId FROM Appointment WHERE DoctorId=@DoctorId AND UserId = @UserId AND AppointmentDate = @AppointmentDate
	DELETE FROM Appointment
	WHERE AppointmentId=@generatedId;
    END
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result = 0
		ROLLBACK TRANSACTION t107
		RETURN
     END CATCH
 COMMIT TRANSACTION t107
 SET @result = 1
 RETURN
END
GO

-- Obtain all appointments from Doctor stored procedure.

GO
CREATE PROCEDURE uspGetAppointmentsByDoctor @DoctorId nvarchar(15)
AS
BEGIN
SET NOCOUNT ON
  BEGIN
	SELECT DoctorId, UserId, AppointmentDate 
	FROM Appointment
	WHERE DoctorId=@DoctorId
  END
END
GO

-- *************************************************** Medicines ****************************************************************************

-- Insert medicine into branch office stored procedure.

GO
CREATE PROCEDURE uspInsertMedicineIntoBranchOffice @BranchOfficeId uniqueidentifier, @MedicineId uniqueidentifier, @Quantity int, @Sales int, @Price decimal(10,2)
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t109
  BEGIN TRY
  DECLARE @errorNum int
  BEGIN
	INSERT INTO MedicinesPerBranchOffice
	VALUES(@BranchOfficeId, @MedicineId, @Quantity, @Sales, @Price)
  END
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		ROLLBACK TRANSACTION t109
		RETURN @errorNum
     END CATCH
 COMMIT TRANSACTION t109
END
GO

-- Synchronize MedicinesPerBranchOffice stored procedure.

CREATE PROCEDURE uspSynchronizeMedicinesPerBranchOffice @BranchOfficeId uniqueidentifier, @MedicineId uniqueidentifier, @Quantity int, @Sales int
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRANSACTION t110
  BEGIN TRY
  DECLARE @errorNum int
  BEGIN
	UPDATE MedicinesPerBranchOffice
	SET QuantityAvailable = @Quantity, Sales = @Sales
	WHERE BranchOfficeId = @BranchOfficeId AND MedicineId = @MedicineId;
  END
  END TRY
  BEGIN CATCH
		SET @errorNum = Error_Number()
		ROLLBACK TRANSACTION t110
		RETURN @errorNum
     END CATCH
 COMMIT TRANSACTION t110
END
GO
