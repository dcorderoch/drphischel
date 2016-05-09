

/*
 * Stored Procedures 
 * DrPhishelDB
 * Proyecto #2
 * Author: Manuel Zumbado C.
 */



 ----CUSTOM ERRORS





 /*
  *  Pre-registration of doctors. Insert into Doctor table with the 'Accepted' flag turned off.
  */ 

GO
  CREATE PROCEDURE usp_preregistDoc 
		@docCode NVARCHAR(15), @pass NVARCHAR(30),
        @idNumber CHAR(9), @name NVARCHAR(30), @lastName1 NVARCHAR(30),
		@lastName2 NVARCHAR(30), @residencePlace NVARCHAR(100), @birthDate DATE,
		@officeAddress NVARCHAR(100), @creditCardNum NVARCHAR(30), @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION t1
		BEGIN TRY
			DECLARE @generatedId int
    		INSERT INTO SystemUser VALUES (@idNumber,@pass,@name,@lastName1,@lastName2,@residencePlace,@birthDate,1)
			SELECT @generatedId=SCOPE_IDENTITY()
			INSERT INTO RolesPerUser VALUES(3,@generatedId)
			INSERT INTO Doctor VALUES (@docCode,@generatedId,@officeAddress,0,@creditCardNum)
		END TRY
		BEGIN CATCH
			SET @errorNum = Error_Number()
			SET @result=0
			ROLLBACK TRANSACTION t1
			RETURN
	    END CATCH
	COMMIT TRANSACTION t1
	SET @result = 1
	RETURN
END
GO


 /*
  *  Appprobation of doctors by doctorCode
  */ 

  GO
  CREATE PROCEDURE usp_acceptDoc 
		@docCode NVARCHAR(15), @result int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
    	UPDATE Doctor SET IsActive = 1 WHERE DoctorId =@docCode
	END TRY
	BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @result=0
		RETURN
	END CATCH
	SET @result = 1
	RETURN
END
GO

/*
 * Doctor's charges per month
 */

<<<<<<< HEAD
GO
  CREATE PROCEDURE usp_doctorsCharges 
		@costPerAppointment DECIMAL(10,2), @date DATE, @resultCode int OUTPUT, @errorNum int OUTPUT
=======
 GO
  CREATE PROCEDURE usp_doctorsCharges 
		@docCode NVARCHAR(15),@date DATE, @resultCode int OUTPUT, @errorNum int OUTPUT
>>>>>>> c2cffd0db9eb6b02c20d9ddae9cb3bfb17b5f497
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
<<<<<<< HEAD
    	SELECT U.Name,U.LastName1,U.LastName2, A.DoctorId, Count(*)*@costPerAppointment AS Charges 
		FROM  Appointment A  JOIN Doctor D ON A.DoctorId=D.DoctorId JOIN SystemUser U ON D.UserId=U.UserId
		WHERE  A.AppointmentDate BETWEEN @date AND  DATEADD(month,1,@date) 
		GROUP BY A.DoctorId, U.Name,U.LastName1,U.LastName2

		
=======
    	SELECT A.UserId, A.AppointmentDate FROM  Appointment A  WHERE A.DoctorId =@docCode 
				                AND A.AppointmentDate >= @date AND A.AppointmentDate < DATEADD(month,1,@date) ORDER BY A.AppointmentDate ASC
>>>>>>> c2cffd0db9eb6b02c20d9ddae9cb3bfb17b5f497
	END TRY
	BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @resultCode=0
		RETURN
	END CATCH
	SET @resultCode = 1
	RETURN
END
GO


<<<<<<< HEAD
---------Medical Record SPs


/*
 * add new register into patients' Medical Record Data for the given userid
 */

 GO
  CREATE PROCEDURE usp_AddMedRecordEntry
		@userId INT, @appointmentId INT, @description VARCHAR(MAX), @diagnosis VARCHAR(MAX), @prescriptionId uniqueidentifier, @resultCode int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		DECLARE @medicalRecordId INT;

		SELECT @medicalRecordId=M.MedicalRecordId FROM MedicalRecord M WHERE M.UserId=@userId

		INSERT INTO MedicalRecordData VALUES (@medicalRecordId,@appointmentId,@description,@diagnosis,@prescriptionId)
    END TRY
	BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @resultCode=0
		RETURN
	END CATCH
	SET @resultCode = 1
	RETURN
END
GO

/*
 * update and existing medical record entry for the given patient id
 */

 GO
  CREATE PROCEDURE usp_updateMedRecordEntry
		@medicalRecordId INT, @appointmentId INT, @description VARCHAR(MAX), @diagnosis VARCHAR(MAX), @prescriptionId UNIQUEIDENTIFIER, @resultCode int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
		UPDATE MedicalRecordData  SET AppointmentId=@appointmentId, MRDescription=@description,MRDiagnosis=@diagnosis,PrescriptionId=@prescriptionId WHERE MedicalRecordId=@medicalRecordId
    END TRY
	BEGIN CATCH
		SET @errorNum = Error_Number()
		SET @resultCode=0
		RETURN
	END CATCH
	SET @resultCode = 1
	RETURN
END
GO


/*
 *  Get a set of medical record entries for the given patient id
 */

  GO
  CREATE PROCEDURE usp_getPatientMedRecord
		@userId INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT D.DoctorId, A.AppointmentDate, MRD.MRDescription, MRD.MRDiagnosis, MRD.PrescriptionId 
	FROM MedicalRecordData MRD JOIN MedicalRecord MR ON MRD.MedicalRecordId=MR.MedicalRecordId JOIN Appointment A ON A.AppointmentId=MRD.AppointmentId JOIN Doctor D ON D.DoctorId=A.DoctorId
	WHERE  MR.UserId=@userId
END
GO




=======
>>>>>>> c2cffd0db9eb6b02c20d9ddae9cb3bfb17b5f497
INSERT INTO Appointment VALUES (11,'DOC222','20160605'),(6,'DOC222','20160603'),
							   (11,'DOC222','20160625'),(3,'ABC005','20160507'),
							   (9,'DOC048','20160615'),(2,'DOC048','20160708')


							   DECLARE @res int, @en int
<<<<<<< HEAD
							   EXEC usp_updateMedRecordEntry @medicalRecordId=2, @description='Consulta general y receta',@diagnosis='Resfriado común y nauseas', @appointmentId=9, @prescriptionId='64cf9b74-25b1-45f4-a097-080693ec00ad', @resultCode=@res OUTPUT, @errorNum = @en OUTPUT
							   Select @res,@en

							  


						
=======
							   EXEC usp_doctorsCharges @docCode='DOC222',@date='20160601',@resultCode=@res OUTPUT,@errorNum = @en OUTPUT
							   Select @res,@en




						SELECT A.UserId, A.AppointmentDate FROM  Appointment A  WHERE A.DoctorId ='DOC222' 
				                AND A.AppointmentDate BETWEEN '20160601' AND DATEADD(month,1,'20160601')   ORDER BY A.AppointmentDate ASC

								SELECT  DATEADD(day,1,'20160601')
>>>>>>> c2cffd0db9eb6b02c20d9ddae9cb3bfb17b5f497
