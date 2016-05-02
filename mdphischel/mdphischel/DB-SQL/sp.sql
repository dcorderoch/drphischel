

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

GO
	DECLARE @result int, @errorCode int;
  EXEC usp_preregistDoc @docCode='DOC048',@idNumber='15467764',@pass='ccchhhaaa',@officeAddress= 'San Pedro',@creditCardNum='3457632873829383',
                        @name='Esteban',@lastName1='Rodriguez',@lastName2='Vega', @residencePlace='San Jose', @birthDate='19700704',@result=@result OUTPUT, @errorNum=@errorCode OUTPUT;
  SELECT @result AS ResultCode, @errorCode AS ErrorCode;

GO