

/*
 * Stored Procedures 
 * DrPhishelDB
 * Proyecto #2
 * Author: Manuel Zumbado C.
 */


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

 GO
  CREATE PROCEDURE usp_doctorsCharges 
		@docCode NVARCHAR(15),@date DATE, @resultCode int OUTPUT, @errorNum int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
    	SELECT A.UserId, A.AppointmentDate FROM  Appointment A  WHERE A.DoctorId =@docCode 
				                AND A.AppointmentDate >= @date AND A.AppointmentDate < DATEADD(month,1,@date) ORDER BY A.AppointmentDate ASC
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


INSERT INTO Appointment VALUES (11,'DOC222','20160605'),(6,'DOC222','20160603'),
							   (11,'DOC222','20160625'),(3,'ABC005','20160507'),
							   (9,'DOC048','20160615'),(2,'DOC048','20160708')


							   DECLARE @res int, @en int
							   EXEC usp_doctorsCharges @docCode='DOC222',@date='20160601',@resultCode=@res OUTPUT,@errorNum = @en OUTPUT
							   Select @res,@en




						SELECT A.UserId, A.AppointmentDate FROM  Appointment A  WHERE A.DoctorId ='DOC222' 
				                AND A.AppointmentDate BETWEEN '20160601' AND DATEADD(month,1,'20160601')   ORDER BY A.AppointmentDate ASC

								SELECT  DATEADD(day,1,'20160601')