USE [ERMS_Db]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_Get_Delete_Employee')
BEGIN
	DROP PROCEDURE usp_Get_Delete_Employee;

END
GO

CREATE PROCEDURE [dbo].[usp_Get_Delete_Employee]
(
    @EmployeeId int =null,
	@employeeName NVARCHAR(200) = '',
	@mode NVARCHAR(30)
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	IF(@mode = 'GET')
	BEGIN
		SELECT a.[EmployeeId]
      ,a.[FirstName]
      ,a.[MiddleName]
      ,a.[LastName]
      ,a.[DateofJoining]
      ,a.[EmployeeCode]
      ,a.[OfficialEmail] AS OfficeEmailAddress
      ,a.[EmployeeTypeId]
      ,a.[RevisedLocationId]
      ,a.[Designation]
	  ,a.[OverallExperience] AS TotalExperience
      ,a.[ReportingManagerId] AS L1ManagerId
      ,a.[EmploymentStatus] 
      ,a.[SubPracticeId]
	  ,d.[Name] as SubPracticeName
      ,a.[IsEngineering]
      ,a.[IsNextAssignmentIdentified]
      ,a.[NextAssignmentName]
      ,a.[NextAssignmentStartDate]
      ,a.[IsDeleted]
	  ,a.[RelievingDate] As [LastWorkingDate]
      , CONCAT (em.FirstName,' ',em.LastName) AS CreatedBy
      , CONCAT (emp.FirstName,' ',emp.LastName) AS ModifiedBy
      ,a.[CreatedOn]
      ,a.[ModifiedOn]
      ,b.[Type] as [EmployeeType]
      ,c.[Name] as [RevisedLocation]
      ,CONCAT (e.FirstName,' ',e.LastName) AS ManagerName
  FROM [dbo].[Employees] a
  Left join [dbo].[EmployeeType] b on a.EmployeeTypeId=b.EmployeeTypeId
  Left join [dbo].[Locations] c on a.RevisedLocationId=c.Id
  LEFT join [dbo].[Employees] e on a.ReportingManagerId =e.EmployeeId
  LEFT join [dbo].[Employees] em on a.CreatedBy =em.EmployeeId
  LEFT join [dbo].[Employees] emp on a.ModifiedBy =emp.EmployeeId
  Left join [dbo].[SubPractices] d on a.SubPracticeId=d.SubPracticeId
  WHERE ISNULL (a.IsDeleted,0) = 0 AND ( a.FirstName like '%'+ @employeeName + '%'
  OR a.LastName like '%'+ @employeeName +'%');
    END
ELSE IF (@mode = 'DELETE')
		BEGIN
				IF NOT EXISTS (SELECT * FROM Employees WHERE EmployeeId = @EmployeeId AND ISNULL(IsDeleted, 0) = 0)
     			BEGIN
     				select 400 from Employees where EmployeeId = @EmployeeId AND ISNULL(IsDeleted, 0) = 0;
     			END
				ELSE 
				BEGIN
		           	UPDATE Employees 
			        SET [IsDeleted] = 1,
				    [ModifiedBy] = 1,
				    [ModifiedOn] = GETDATE() 
			        WHERE EmployeeId = @EmployeeId;
					select 200 from Employees where EmployeeId = @EmployeeId
				END
		END
END
GO

