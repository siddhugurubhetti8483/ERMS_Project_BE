USE [ERMS_Db]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetEmployeeCount')
BEGIN
	DROP PROCEDURE usp_GetEmployeeCount;
END

GO
CREATE PROCEDURE usp_GetEmployeeCount
AS
BEGIN
    SET NOCOUNT ON
	
	SELECT 'TotalEmployees' As [Type], COUNT(*) As[Count] 
	FROM Employees 

	UNION All 

	SELECT 
		CASE 
			WHEN EmploymentStatus = 1 THEN 'ActiveEmployees' 
			WHEN EmploymentStatus = 0 THEN 'InActiveEmployees'
			ELSE 'UnknownStatus'
		END AS [Type],
		COUNT(*)[Count] 
	FROM Employees 
	GROUP BY EmploymentStatus
	
END
GO

----Sample Execution Query-----
EXEC usp_GetEmployeeCount 
