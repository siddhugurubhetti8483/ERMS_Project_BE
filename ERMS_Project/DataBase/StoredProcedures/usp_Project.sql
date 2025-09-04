USE [ERMS_Db]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_Project')
BEGIN
	DROP PROCEDURE usp_Project;
END
GO
CREATE PROCEDURE usp_Project
(
    @ProjectId INT =null,
	@ProjectName NVARCHAR(200) = '',
    @AccountId INT =null, 
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
		SELECT  
		  Projects.ProjectId,
          Accounts.Name AS Account,
          ProjectName,
          Projects.Description,
          ProjectStatus.Status,
          ProjectCostingTypes.Name AS ProjectCostingType,
          CONCAT (Employees.FirstName,' ',Employees.LastName) AS ManagerName,
          Practices.Name AS Practices,
          Projects.IsDeleted,
          CONCAT (Emp.FirstName,' ',Emp.LastName) AS CreatedBy,
          CONCAT (Employ.FirstName,' ',Employ.LastName) AS ModifiedBy,
		  convert(varchar, Projects.EndDate,105) AS EndDate,
		  convert(varchar, Projects.StartDate,105) AS StartDate,
		  convert(varchar, Projects.CreatedOn,105) AS CreatedOn,
		  convert(varchar, Projects.ModifiedOn,105) AS ModifiedOn
          FROM Projects 
		  LEFT JOIN ProjectStatus ON Projects.ProjectStatusId =ProjectStatus.StatusId
		  LEFT JOIN Accounts ON   Projects.AccountId = Accounts.AccountId
		  LEFT JOIN ProjectCostingTypes ON Projects.ProjectCostingTypeId = ProjectCostingTypes.ProjectCostingTypeId
		  LEFT JOIN Practices ON Projects.PracticeId = Practices.PracticeId
		  LEFT JOIN Employees ON Projects.ProjectManagerId = Employees.EmployeeId
		  LEFT JOIN Employees AS Emp ON Projects.CreatedBy=Emp.EmployeeId
		  LEFT JOIN Employees AS Employ ON Projects.ModifiedBy=Employ.EmployeeId
		  WHERE ISNULL(Projects.IsDeleted,0) = 0;

    END
    ELSE IF(@mode = 'GET_BYID')
    BEGIN
		SELECT  
		  Projects.ProjectId,
          Accounts.Name AS Account,
          ProjectName,
          Projects.Description,
          ProjectStatus.Status,
          ProjectCostingTypes.Name AS ProjectCostingType,
          CONCAT (Employees.FirstName,' ',Employees.LastName) AS ManagerName,
          Practices.Name AS Practices,
          Projects.IsDeleted,
          CONCAT (Emp.FirstName,' ',Emp.LastName) AS CreatedBy,
          CONCAT (Employ.FirstName,' ',Employ.LastName) AS ModifiedBy,
		  convert(varchar, Projects.EndDate,105) AS EndDate,
		  convert(varchar, Projects.StartDate,105) AS StartDate,
		  convert(varchar, Projects.CreatedOn,105) AS CreatedOn,
		  convert(varchar, Projects.ModifiedOn,105) AS ModifiedOn
          FROM Projects 
		  LEFT JOIN ProjectStatus ON Projects.ProjectStatusId =ProjectStatus.StatusId
		  LEFT JOIN Accounts ON  Projects.AccountId = Accounts.AccountId
		  LEFT JOIN ProjectCostingTypes ON Projects.ProjectCostingTypeId = ProjectCostingTypes.ProjectCostingTypeId
		  LEFT JOIN Practices ON Projects.PracticeId = Practices.PracticeId
		  LEFT JOIN Employees ON Projects.ProjectManagerId = Employees.EmployeeId
		  LEFT JOIN Employees AS Emp ON Projects.CreatedBy=Emp.EmployeeId
		  LEFT JOIN Employees AS Employ ON Projects.ModifiedBy=Employ.EmployeeId
		  WHERE Projects.AccountId=@AccountId AND ISNULL(Projects.IsDeleted,0) = 0;
    END
	ELSE IF(@mode = 'DELETE')
    BEGIN
		IF NOT EXISTS (SELECT * FROM Projects WHERE ProjectId = @ProjectId AND ISNULL(Projects.IsDeleted,0) = 0)
     			BEGIN
     				select 402  FROM Projects WHERE ProjectId = @ProjectId AND ISNULL(Projects.IsDeleted,0) = 0;
     			END
				ELSE 
				BEGIN
		           	UPDATE Projects 
			               SET [IsDeleted] = 1,
			               	[ModifiedBy] = 1,
			               	[ModifiedOn] = GETDATE() 
			               WHERE [ProjectId] = @ProjectId;

						 UPDATE [dbo].[ProjectTaskColors]
						SET [IsDeleted] = 1,
			               	[ModifiedOn] = GETDATE() 
						WHERE ProjectId = @ProjectId;
					       select 200  FROM Projects WHERE ProjectId = @ProjectId;
				END
    END
END
