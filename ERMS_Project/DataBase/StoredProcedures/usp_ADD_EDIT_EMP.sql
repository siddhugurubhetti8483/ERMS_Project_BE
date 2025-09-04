USE [ERMS_Db]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_ADD_EDIT_EMP')
BEGIN
	DROP PROCEDURE usp_ADD_EDIT_EMP;
END
GO

CREATE PROCEDURE [dbo].[usp_ADD_EDIT_EMP]
    -- Add the parameters for the stored procedure here
@EmployeeId INT = NULL OUT,
@FirstName  NVARCHAR(50) = NULL,
@MiddleName NVARCHAR(50) = NULL,
@LastName NVARCHAR(50) = NULL,
@DateofJoining DateTime,
@EmployeeCode NVARCHAR(20) = NULL,
@OfficeEmailAddress NVARCHAR(50) = NULL,@EmployeeTypeId INT,@RevisedLocationId INT,@Designation NVARCHAR(20) = NULL,
@TotalExperience DECIMAL(5,2),
@L1ManagerId INT, 
@EmploymentStatus BIT,
@SubPracticeId INT ,@IsEngineering BIT,@IsNextAssignmentIdentified BIT,@NextAssignmentName NVARCHAR(20) = NULL,@NextAssignmentStartDate DateTime,
@CreatedBy INT = NULL,
@ModifiedBy INT = NULL,
@LastWorkingDate DateTime,
@L1ManagerName NVARCHAR(50),
@mode NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	IF(@mode = 'CREATE')
	BEGIN
		IF EXISTS (SELECT 1 FROM Employees WHERE (FirstName = @FirstName AND MiddleName = @MiddleName AND LastName = @LastName ))

	BEGIN            
		    RETURN 1
    END 
	ELSE
		BEGIN
			INSERT INTO Employees (
				FirstName, MiddleName, LastName, DateofJoining, EmployeeCode, OfficialEmail,
				EmployeeTypeId, RevisedLocationId, Designation, OverallExperience,
				ReportingManagerId, EmploymentStatus, SubPracticeId,
				IsEngineering, IsNextAssignmentIdentified, NextAssignmentName,
				NextAssignmentStartDate, IsDeleted, CreatedBy, ModifiedBy,
				CreatedOn, ModifiedOn, RelievingDate, ReportingManagerName
			)
			VALUES (
				@FirstName, @MiddleName, @LastName, @DateofJoining, @EmployeeCode, @OfficeEmailAddress,
				@EmployeeTypeId, @RevisedLocationId, @Designation, @TotalExperience,
				@L1ManagerId, @EmploymentStatus, @SubPracticeId,
				@IsEngineering, @IsNextAssignmentIdentified, @NextAssignmentName,
				@NextAssignmentStartDate, 0, @CreatedBy, NULL,
				GETDATE(), NULL, @LastWorkingDate, @L1ManagerName
			);
			
			SELECT @EmployeeId = SCOPE_IDENTITY();

 			--INSERT INTO [dbo].[SignIns] (EmployeeId) VALUES (@EmployeeId);
			--INSERT INTO SignIns(EmployeeId) VALUES (@EmployeeId);
			IF @EmployeeId IS NOT NULL
			BEGIN
				INSERT INTO SignIns (EmployeeId) VALUES (@EmployeeId);
			END

			SELECT @EmployeeId AS EmployeeId;
			RETURN 0
		END
	END
	ELSE IF (@mode = 'UPDATE')
	BEGIN
		IF EXISTS (SELECT 1 FROM Employees WHERE (FirstName = @FirstName AND MiddleName = @MiddleName AND LastName = @LastName AND [EmployeeId]<>@EmployeeId AND EmployeeCode=@EmployeeCode))
	BEGIN            
		    RETURN 1
    END 
	ELSE
		BEGIN
			UPDATE Employees 
			SET 
				FirstName = @FirstName,
				MiddleName = @MiddleName,
				LastName = @LastName,
				DateofJoining = @DateofJoining,
				EmployeeCode = @EmployeeCode,
				OfficialEmail = @OfficeEmailAddress,
				EmployeeTypeId = @EmployeeTypeId,
				RevisedLocationId = @RevisedLocationId,
				Designation = @Designation,
				OverallExperience = @TotalExperience,
				ReportingManagerId = @L1ManagerId,
				EmploymentStatus = @EmploymentStatus,
				SubPracticeId = @SubPracticeId,
				IsEngineering = @IsEngineering,
				IsNextAssignmentIdentified = @IsNextAssignmentIdentified,
				NextAssignmentName = @NextAssignmentName,
				NextAssignmentStartDate = @NextAssignmentStartDate,
				ModifiedBy = @ModifiedBy,
				ModifiedOn = GETDATE(),
				RelievingDate = @LastWorkingDate,
				ReportingManagerName = @L1ManagerName
			WHERE EmployeeId = @EmployeeId;

			SELECT @EmployeeId;
			RETURN 0
		END
	END
END
