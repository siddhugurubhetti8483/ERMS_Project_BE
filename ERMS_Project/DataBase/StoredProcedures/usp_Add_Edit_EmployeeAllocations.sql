USE [ERMS_Db]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_Add_Edit_EmployeeAllocations')
BEGIN
	DROP PROCEDURE usp_Add_Edit_EmployeeAllocations;
END
	
GO
CREATE PROCEDURE [dbo].[usp_Add_Edit_EmployeeAllocations]
(
	@AllocationId INT = NULL OUT,
	@ProjectId INT = NULL,
	@EmployeeId INT = NULL,
	@StartDate DATE  = NULL,
	@EndDate DATE = NULL,
	@AllocationStatus VARCHAR(20) = NULL,
	@IsBillable BIT = NULL,
	@IsUtilized BIT = NULL,
	@AllocationPercentage INT = NULL,
	@BillablePercentage INT = NULL,
	@Remarks VARCHAR(200) = NULL,
	@CreatedBy INT = NULL,
	@ModifiedBy INT = NULL,
	@mode NVARCHAR(25)
)
AS
BEGIN SET NOCOUNT ON
	IF(@mode = 'ALLOCATE_EMPLOYEES')
		BEGIN
		IF EXISTS (SELECT 1 FROM EmployeeAllocations WHERE ProjectId = @ProjectId AND EmployeeId = @EmployeeId)   
		BEGIN            
				RETURN 1
		END      
		ELSE 
			BEGIN
				INSERT INTO EmployeeAllocations([ProjectId]
							  ,[EmployeeId]
							  ,[StartDate]
							  ,[EndDate]
							  ,[AllocationStatus]
							  ,[IsBillable]
							  ,[IsUtilized]
							  ,[AllocationPercentage]
							  ,[BillablePercentage]
							  ,[Remarks]
							  ,[IsDeleted]
							  ,[CreatedBy]
							  ,[ModifiedBy]
							  ,[CreatedOn]
							  ,[ModifiedOn])
				VALUES(@ProjectId, @EmployeeId, @StartDate, @EndDate, @AllocationStatus, @IsBillable, @IsUtilized, @AllocationPercentage, @BillablePercentage, @Remarks, 0, @CreatedBy, @CreatedBy, GETDATE(), GETDATE());       
				SELECT SCOPE_IDENTITY() AS AllocationId
				RETURN 0
			END
		END 
	ELSE IF(@mode = 'UPDATE')
		BEGIN
			UPDATE EmployeeAllocations SET [ProjectId] = @ProjectId
							,[EmployeeId] = @EmployeeId
							,[StartDate] = @StartDate
							,[EndDate] = @EndDate
							,[AllocationStatus] =  @AllocationStatus
							,[IsBillable] = @IsBillable
							,[IsUtilized] = @IsUtilized
							,[AllocationPercentage] = @AllocationPercentage
							,[BillablePercentage] = @BillablePercentage
							,[Remarks] = @Remarks
							,[ModifiedBy] = @ModifiedBy
							,[ModifiedOn] = GETDATE()
						WHERE AllocationId = @AllocationId;
						SELECT @AllocationId;
		END
	ELSE IF(@mode = 'GET_BY_ALLOCATIO_ID')
		BEGIN
			SELECT
				   [ProjectId]
				  ,[EmployeeId]
				  ,[StartDate]
				  ,[EndDate]
				  ,[AllocationStatus]
				  ,[IsBillable]
				  ,[IsUtilized]
				  ,[AllocationPercentage]
				  ,[BillablePercentage]
				  ,[Remarks]
				  ,[IsDeleted]
				  ,[CreatedBy]
				  ,[ModifiedBy]
				  ,[CreatedOn]
				  ,[ModifiedOn]
				  FROM EmployeeAllocations WHERE AllocationId = @AllocationId;
		END
END
