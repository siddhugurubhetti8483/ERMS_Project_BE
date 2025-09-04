USE [ERMS_Db]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetEmployeeAllocation')
BEGIN
	DROP PROCEDURE usp_GetEmployeeAllocation;
END

GO
CREATE PROCEDURE usp_GetEmployeeAllocation
(
    @AllocationId INT =null,
	@ProjectName NVARCHAR(200) = '',
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
          SELECT CONCAT (emp.FirstName,' ',emp.LastName) AS EmployeeName, 
		  proj.ProjectName,
		  empAllo.EmployeeId AS EmployeeId,
		  empAllo.ProjectId AS ProjectId,
		  empAllo.AllocationId,
		  empAllo.AllocationStatus,
		  empAllo.AllocationPercentage,
		  empAllo.IsBillable,
		  empAllo.IsUtilized,
		  empAllo.AllocationStatus,
		  CONCAT (Empl.FirstName,' ',Empl.LastName) AS CreatedBy,
		  CONCAT (Employee.FirstName,' ',Employee.LastName) AS ModifiedBy,
		  CONVERT(varchar, empAllo.CreatedOn,105) AS CreatedOn,
		  CONVERT(varchar, empAllo.ModifiedOn,105) AS ModifiedOn,
		  CONVERT(varchar, empAllo.StartDate,105) AS StartDate,
		  CONVERT(varchar, empAllo.EndDate,105) AS EndDate,
		  empAllo.Remarks,
		  CASE
			 WHEN  empAllo.endDate >= GETDATE() AND empAllo.startDate <= GETDATE() THEN 'Allocated'
			 WHEN  empAllo.endDate < GETDATE() OR empAllo.startDate>GETDATE() THEN 'Unallocated'
          END AS status
		  FROM EmployeeAllocations empAllo 
		  LEFT JOIN Employees emp ON empAllo.EmployeeId = emp.EmployeeId 
		  LEFT JOIN Projects proj ON empAllo.ProjectId = proj.ProjectId
		  LEFT JOIN Employees AS Empl ON empAllo.CreatedBy=Empl.EmployeeId
		  LEFT JOIN Employees AS Employee ON empAllo.ModifiedBy=Employee.EmployeeId
		  WHERE ISNULL(empAllo.IsDeleted,0) = 0;

    END
	ELSE IF(@mode = 'GET_BYID')
    BEGIN

          SELECT CONCAT (emp.FirstName,' ',emp.LastName) AS EmployeeName, 
		  proj.ProjectName,
		  empAllo.EmployeeId AS EmployeeId,
		  empAllo.ProjectId AS ProjectId,
		  empAllo.AllocationId,
		  empAllo.AllocationStatus,
		  empAllo.AllocationPercentage,
		  empAllo.IsBillable,
		  empAllo.IsUtilized,
		  empAllo.AllocationStatus,
		  CONCAT (Empl.FirstName,' ',Empl.LastName) AS CreatedBy,
		  CONCAT (Employee.FirstName,' ',Employee.LastName) AS ModifiedBy,
		  CONVERT(varchar, empAllo.CreatedOn,105) AS CreatedOn,
		  CONVERT(varchar, empAllo.ModifiedOn,105) AS ModifiedOn,
		  CONVERT(varchar, empAllo.StartDate,105) AS StartDate,
		  CONVERT(varchar, empAllo.EndDate,105) AS EndDate,
		  empAllo.Remarks,
		  CASE
			 WHEN  empAllo.endDate >= GETDATE() AND empAllo.startDate <= GETDATE() THEN 'Allocate'
			 WHEN  empAllo.endDate < GETDATE() OR empAllo.startDate>GETDATE() THEN 'Unallocate'
          END AS status
		  FROM EmployeeAllocations empAllo 
		  LEFT JOIN Employees emp ON empAllo.EmployeeId = emp.EmployeeId 
		  LEFT JOIN Projects proj ON empAllo.ProjectId = proj.ProjectId
		  LEFT JOIN Employees AS Empl ON empAllo.CreatedBy=Empl.EmployeeId
		  LEFT JOIN Employees AS Employee ON empAllo.ModifiedBy=Employee.EmployeeId
		  WHERE empAllo.AllocationId=@AllocationId AND ISNULL(empAllo.IsDeleted,0) = 0;
    END
   	ELSE  IF (@mode = 'DELETE')
		BEGIN
		IF NOT EXISTS (SELECT * FROM EmployeeAllocations WHERE AllocationId = @AllocationId AND ISNULL(IsDeleted,0) = 0)
     			BEGIN
     				select 402 FROM EmployeeAllocations WHERE AllocationId = @AllocationId AND ISNULL(IsDeleted,0) = 0;
     			END
				ELSE 
				BEGIN
		           	UPDATE EmployeeAllocations 
			             SET [IsDeleted] = 1,
			             	[ModifiedBy] = 1,
			             	[ModifiedOn] = GETDATE() 
			             WHERE [AllocationId] = @AllocationId;
					select 200 FROM EmployeeAllocations WHERE AllocationId = @AllocationId;
				END

		END
END
