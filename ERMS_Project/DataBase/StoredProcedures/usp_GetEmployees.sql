Use [ERMS_Db]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetEmployees')
BEGIN
	DROP PROCEDURE usp_GetEmployees;
END

GO
CREATE PROCEDURE usp_GetEmployees
(
    @employeeId INT = NULL OUT,
	@employeeName NVARCHAR(200) = '',
	@mode NVARCHAR(10)
	 -- @count INT OUTPUT
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
        ,a.[OfficialEmail] As OfficeEmailAddress
        ,a.[EmployeeTypeId]
        ,a.[RevisedLocationId]
        ,a.[Designation]
        ,a.[OverallExperience] As TotalExperience
		,a.[Skill_Id]
		,s.SkillName
		,a.[ReportingManagerName] As L1ManagerName
        ,a.[EmploymentStatus] 
		,a.[RelievingDate] As LastWorkingDate
		,a.[SubPracticeId]
		,d.[Name] As SubPracticeName
        ,a.[IsEngineering]
        ,a.[IsNextAssignmentIdentified]
        ,a.[NextAssignmentName]
        ,a.[NextAssignmentStartDate]
        ,a.[IsDeleted]
        , CONCAT (em.FirstName,' ',em.LastName) AS CreatedBy
        , CONCAT (emp.FirstName,' ',emp.LastName) AS ModifiedBy
        ,a.[CreatedOn]
        ,a.[ModifiedOn]
        ,b.[Type] as [EmployeeType]
        ,c.[Name] as [RevisedLocation]
        FROM [dbo].[Employees] a
        Left JOIN [dbo].[EmployeeType] b on a.EmployeeTypeId=b.EmployeeTypeId
        Left JOIN [dbo].[Locations] c on a.RevisedLocationId=c.Id
        LEFT JOIN [dbo].[Employees] e on a.ReportingManagerId =e.EmployeeId
        LEFT JOIN [dbo].[Employees] em on a.CreatedBy =em.EmployeeId
        LEFT JOIN [dbo].[Employees] emp on a.ModifiedBy =emp.EmployeeId
		Left JOIN [dbo].[SubPractices] d on a.SubPracticeId=d.SubPracticeId
		LEFT JOIN [dbo].[SkillSets] s ON a.Skill_Id = s.Skill_Id
	    WHERE ISNULL(a.IsDeleted,0) = 0;
	END
	ELSE IF(@mode = 'GET_BYID')
	BEGIN 
	SELECT a.[EmployeeId]
        ,a.[FirstName]
        ,a.[MiddleName]
        ,a.[LastName]
        ,a.[DateofJoining]
        ,a.[EmployeeCode]
        ,a.[OfficialEmail] As OfficeEmailAddress
        ,a.[EmployeeTypeId]
        ,a.[RevisedLocationId]
        ,a.[Designation]
        ,a.[OverallExperience] As TotalExperience
		,a.[Skill_Id]
		,s.SkillName
		,a.[ReportingManagerName] As L1ManagerName
        ,a.[EmploymentStatus] 
		,a.[RelievingDate] As LastWorkingDate
		,a.[SubPracticeId]
		,d.[Name] As SubPracticeName
        ,a.[IsEngineering]
        ,a.[IsNextAssignmentIdentified]
        ,a.[NextAssignmentName]
        ,a.[NextAssignmentStartDate]
        ,a.[IsDeleted]
        , CONCAT (em.FirstName,' ',em.LastName) AS CreatedBy
        , CONCAT (emp.FirstName,' ',emp.LastName) AS ModifiedBy
        ,a.[CreatedOn]
        ,a.[ModifiedOn]
        ,b.[Type] as [EmployeeType]
        ,c.[Name] as [RevisedLocation]
        FROM [dbo].[Employees] a
        Left JOIN [dbo].[EmployeeType] b on a.EmployeeTypeId=b.EmployeeTypeId
        Left JOIN [dbo].[Locations] c on a.RevisedLocationId=c.Id
        LEFT JOIN [dbo].[Employees] e on a.ReportingManagerId =e.EmployeeId
        LEFT JOIN [dbo].[Employees] em on a.CreatedBy =em.EmployeeId
        LEFT JOIN [dbo].[Employees] emp on a.ModifiedBy =emp.EmployeeId
		Left JOIN [dbo].[SubPractices] d on a.SubPracticeId=d.SubPracticeId
		LEFT JOIN [dbo].[SkillSets] s ON a.Skill_Id = s.Skill_Id
	  WHERE a.[EmployeeId] = @employeeId AND ISNULL(a.[IsDeleted],0) = 0;
	END
	ELSE IF(@mode = 'GET_COUNTS')
	BEGIN
		SELECT COUNT(EMPLOYEES.EmployeeId) [TotalEmployees]
		FROM EMPLOYEES 
		
		SELECT COUNT(EMPLOYEES.EmployeeId) [ActiveEmployess]
		FROM EMPLOYEES 
		WHERE ISNULL(EMPLOYEES.IsDeleted,0) = 0;

		SELECT COUNT(EMPLOYEES.EmployeeId) [InActiveEmployees]
		FROM EMPLOYEES 
		WHERE ISNULL(EMPLOYEES.IsDeleted,0) = 1;

	END
	ELSE IF(@mode = 'GET_BYNAME')
	BEGIN
		SELECT a.[EmployeeId]
        ,a.[FirstName]
        ,a.[MiddleName]
        ,a.[LastName]
        ,a.[DateofJoining]
        ,a.[EmployeeCode]
        ,a.[OfficialEmail] As OfficeEmailAddress
        ,a.[EmployeeTypeId]
        ,a.[RevisedLocationId]
        ,a.[Designation]
        ,a.[OverallExperience] As TotalExperience
		,a.[Skill_Id]
		,s.SkillName
		,a.[ReportingManagerName] As L1ManagerName
        ,a.[EmploymentStatus] 
		,a.[RelievingDate] As LastWorkingDate
		,a.[SubPracticeId]
		,d.[Name] As SubPracticeName
        ,a.[IsEngineering]
        ,a.[IsNextAssignmentIdentified]
        ,a.[NextAssignmentName]
        ,a.[NextAssignmentStartDate]
        ,a.[IsDeleted]
        , CONCAT (em.FirstName,' ',em.LastName) AS CreatedBy
        , CONCAT (emp.FirstName,' ',emp.LastName) AS ModifiedBy
        ,a.[CreatedOn]
        ,a.[ModifiedOn]
        ,b.[Type] as [EmployeeType]
        ,c.[Name] as [RevisedLocation]
        FROM [dbo].[Employees] a
        LEFT JOIN [dbo].[EmployeeType] b on a.EmployeeTypeId=b.EmployeeTypeId
        LEFT JOIN [dbo].[Locations] c on a.RevisedLocationId=c.Id
        LEFT JOIN [dbo].[Employees] e on a.ReportingManagerId =e.EmployeeId
        LEFT JOIN [dbo].[Employees] em on a.CreatedBy =em.EmployeeId
        LEFT JOIN [dbo].[Employees] emp on a.ModifiedBy =emp.EmployeeId
		LEFT JOIN [dbo].[SubPractices] d on a.SubPracticeId=d.SubPracticeId
		LEFT JOIN [dbo].[SkillSets] s ON a.Skill_Id = s.Skill_Id
	  WHERE ISNULL(a.[IsDeleted],0) = 0 AND (a.[FirstName] like '%' + @employeeName +'%' 
			--OR a.[MiddleName] like '%'+ @employeeName +'%' 
			OR a.[LastName] like '%'+ @employeeName +'%');
	END
END
GO
------Sample Execution Query-----
--EXEC usp_GetEmployees 
--@mode='GET',
--@employeeId = 3, 
--@employeeName=''


--DECLARE @employeeId INT;

--EXEC usp_GetEmployees 
--    @employeeId = @employeeId,  -- NULL pass hoga by default
--    @employeeName = '',
--    @mode = 'GET';