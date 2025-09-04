Use [ERMS_Db];

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetManagers]
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
		,a.[ReportingManagerName] As L1ManagerName
		,a.[ReportingManagerId] As L1ManagerId
        ,a.[EmploymentStatus] 
        ,a.[IsEngineering]
        ,a.[IsNextAssignmentIdentified]
        ,a.[NextAssignmentName]
        ,a.[NextAssignmentStartDate]
        ,a.[IsDeleted]
        ,a.[CreatedOn]
        ,a.[ModifiedOn]
		,a.[OverallExperience] As TotalExperience
        FROM [dbo].[Employees] a
        INNER join [dbo].[Employees] e on e.EmployeeId = a.EmployeeId
	    WHERE ISNULL(a.IsDeleted,0) = 0 and e.Designation='Practice Head';
	END
END


--Use [ERMS_Db]

--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetManagers')
--BEGIN
--	DROP PROCEDURE usp_GetManagers;
--END

--GO
--CREATE PROCEDURE usp_GetManagers
--AS
--BEGIN
--    SET NOCOUNT ON;

--    SELECT DISTINCT a.EmployeeId,
--           a.FirstName,
--           a.MiddleName,
--           a.LastName,
--           a.EmployeeCode,
--           a.OfficialEmail AS OfficeEmailAddress,
--           a.Designation,
--           a.EmploymentStatus,
--           a.IsDeleted
--    FROM Employees a
--    WHERE a.EmployeeId IN (
--        SELECT DISTINCT ReportingManagerId 
--        FROM Employees 
--        WHERE ReportingManagerId IS NOT NULL
--    ) 
--    AND ISNULL(a.IsDeleted, 0) = 0;
--END
--GO