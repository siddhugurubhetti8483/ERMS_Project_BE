USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_Accounts')
BEGIN
	DROP PROCEDURE usp_Accounts;
END
GO
CREATE PROCEDURE usp_Accounts
    -- Add the parameters for the stored procedure here
@AccountId INT = NULL OUT,
@Name VARCHAR(150) = NULL,
@Description VARCHAR(200)= NULL,
@AccountLocation VARCHAR(50)= NULL,
@POCName VARCHAR(150)= NULL,
@POCEmail VARCHAR(100)= NULL,
@PocMobileNumber VARCHAR(20)=NULL,
@CountryId INT=NULL,
@GstNumber VARCHAR(20)=NULL,
@PaymentTermsDuration INT=NULL,
@CreatedBy INT = NULL,
@ModifiedBy INT = NULL,
@mode NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	IF(@mode = 'CREATE')
		BEGIN
			IF EXISTS (SELECT 1 FROM Accounts WHERE [Name] = @Name)   
				BEGIN            
						RETURN 1
				END 
			ELSE
				BEGIN
					INSERT INTO Accounts([Name],[Description],[AccountLocation],[POCName],[POCEmail],[PocMobileNumber],[CountryId]
					,[GstNumber],[PaymentTermsDuration],[IsDeleted],[CreatedBy],[ModifiedBy],[CreatedOn],[ModifiedOn])
					VALUES(@Name,@Description,@AccountLocation,
					@POCName,@POCEmail,@PocMobileNumber,@CountryId,@GstNumber,@PaymentTermsDuration,0,@CreatedBy,NULL,GETDATE(),NULL);
					SELECT SCOPE_IDENTITY() AS AccountId
					RETURN 0
				END
	END
	ELSE IF (@mode = 'UPDATE')
		BEGIN
			IF EXISTS (SELECT 1 FROM Accounts WHERE [Name] = @Name AND [AccountId]<>@AccountId)   
				BEGIN            
						RETURN 1
				END 
	ELSE
		BEGIN
			UPDATE Accounts 
			SET [Name]=@Name, 
				[Description]=@Description,
				[AccountLocation]=@AccountLocation,
				[POCName]=@POCName,
				[POCEmail]=@POCEmail,
				[PocMobileNumber]=@PocMobileNumber,
				[CountryId]=@CountryId,
				
				[GstNumber]=@GstNumber,
				[PaymentTermsDuration]=@PaymentTermsDuration,
				[ModifiedBy]=@ModifiedBy,[ModifiedOn]=GETDATE() 
			WHERE [AccountId]=@AccountId;
			SELECT @AccountId;
			RETURN 0
		END
	END
	ELSE IF (@mode = 'GET')
		BEGIN
			SELECT
				 a.[AccountId]
				,a.[Name]
				,a.[Description]
				,a.[AccountLocation]
				,a.[POCName]
				,a.[POCEmail]
				,a.[PocMobileNumber]
				,a.[CountryId]
				,Cou.[CountryName]
				,a.[GstNumber]
				,a.[PaymentTermsDuration]
				,CONCAT (Emp.FirstName,' ',Emp.LastName) AS CreatedBy
		        ,CONCAT (Employee.FirstName,' ',Employee.LastName) AS ModifiedBy
				,a.[IsDeleted]
				,a.[CreatedBy] as CreatedById
				,a.[ModifiedBy] as ModifiedById
				,a.[CreatedOn]
				,a.[ModifiedOn]
			    FROM [dbo].[Accounts] a
			    LEFT JOIN Employees AS Emp ON a.CreatedBy=Emp.EmployeeId
                LEFT JOIN Employees AS Employee ON a.ModifiedBy=Employee.EmployeeId
				LEFT JOIN Country AS Cou ON a.CountryId=Cou.CountryId
 		        WHERE ISNULL(a.[IsDeleted],0) = 0 
				ORDER BY a.[Name];

		END
	ELSE IF (@mode = 'GET_BYID')
		BEGIN
			SELECT
				 a.[AccountId]
				,a.[Name]
				,a.[Description]
				,a.[AccountLocation]
				,a.[POCName]
				,a.[POCEmail]
				,a.[PocMobileNumber]
				,a.[CountryId]
				,a.[GstNumber]
				,a.[PaymentTermsDuration]
				,CONCAT (Emp.FirstName,' ',Emp.LastName) AS CreatedBy
		        ,CONCAT (Employee.FirstName,' ',Employee.LastName) AS ModifiedBy
				,a.[IsDeleted]
				,a.[CreatedBy]
				,a.[ModifiedBy]
				,a.[CreatedOn]
				,a.[ModifiedOn]
			    FROM [dbo].[Accounts] a
			    LEFT JOIN Employees AS Emp ON a.CreatedBy=Emp.EmployeeId
                LEFT JOIN Employees AS Employee ON a.ModifiedBy=Employee.EmployeeId 
			WHERE ISNULL(a.[IsDeleted],0) = 0 
				AND [AccountId]=@AccountId;
		END
	ELSE IF (@mode = 'GET_BYNAME')
		BEGIN
			SELECT
				a.[AccountId]
				,a.[Name]
				,a.[Description]
				,a.[AccountLocation]
				,a.[POCName]
				,a.[POCEmail]
				,a.[PocMobileNumber]
				,a.[CountryId]
				,a.[GstNumber]
				,a.[PaymentTermsDuration]
				,CONCAT (Emp.FirstName,' ',Emp.LastName) AS CreatedBy
		        ,CONCAT (Employee.FirstName,' ',Employee.LastName) AS ModifiedBy
				,a.[IsDeleted]
				,a.[CreatedBy]
				,a.[ModifiedBy]
				,a.[CreatedOn]
				,a.[ModifiedOn]
			    FROM [dbo].[Accounts] a
			    LEFT JOIN Employees AS Emp ON a.CreatedBy=Emp.EmployeeId
                LEFT JOIN Employees AS Employee ON a.ModifiedBy=Employee.EmployeeId
			    WHERE ISNULL(a.IsDeleted,0) = 0 
				AND ([Name] like '%' + @Name + '%');
		END
	ELSE IF (@mode = 'DELETE')
		BEGIN
			UPDATE Accounts 
			SET [IsDeleted] = 1,
				[ModifiedBy] = 1,
				[ModifiedOn] = GETDATE() 
			WHERE [AccountId] = @AccountId;
			SELECT @AccountId;
		END
END



