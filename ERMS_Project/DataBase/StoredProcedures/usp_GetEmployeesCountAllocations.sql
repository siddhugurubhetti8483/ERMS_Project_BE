USE [ERMS_Db]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetEmployeesCountAllocations')
BEGIN
	DROP PROCEDURE usp_GetEmployeesCountAllocations;
END

GO
CREATE PROCEDURE usp_GetEmployeesCountAllocations
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
        COUNT(*) AS TotalEmployeesAllocationsCount,
        SUM(CASE WHEN IsUtilized = 1 THEN 1 ELSE 0 END) AS ActiveEmployeesAllocationsCount,
        SUM(CASE WHEN IsUtilized = 0 OR IsUtilized IS NULL THEN 1 ELSE 0 END) AS InactiveEmployeesAllocationsCount
    FROM EmployeeAllocations
    WHERE IsDeleted = 0

	---- Total count excluding deleted allocations
	--SELECT 'TotalEmployeesAllocationsCount' As [Type], COUNT(*) As[Count] 
	--FROM EmployeeAllocations
	--WHERE IsDeleted = 0

	--UNION All 

	---- Active Utilized Allocations
	--SELECT 'ActiveEmployeesAllocationsCount' AS [Type], COUNT(*) AS [Count]
 --   FROM EmployeeAllocations
 --   WHERE IsDeleted = 0 AND IsUtilized = 1

	--UNION ALL

 --   -- Inactive Utilized Allocations
 --   SELECT 'InactiveEmployeesAllocationsCount' AS [Type], COUNT(*) AS [Count]
 --   FROM EmployeeAllocations
 --   WHERE IsDeleted = 0 AND (IsUtilized = 0 OR IsUtilized IS NULL)
	
END
GO

----Sample Execution Query-----
--EXEC usp_GetEmployeesCountAllocations

--SELECT COUNT(DISTINCT EmployeeId)
--FROM EmployeeAllocations
--WHERE ISNULL(IsDeleted, 0) = 0 AND AllocationPercentage = 100
