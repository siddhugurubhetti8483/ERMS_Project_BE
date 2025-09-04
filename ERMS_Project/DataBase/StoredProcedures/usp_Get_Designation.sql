USE [ERMS_Db]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_Get_Designation')
	BEGIN
		DROP PROCEDURE usp_Get_Designation;
	END
GO

CREATE PROCEDURE usp_Get_Designation
(
	@mode NVARCHAR(30)
)

AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON
		IF(@mode = 'GET')
		BEGIN
			SELECT DISTINCT
			Designation
			FROM Employees
			WHERE ISNULL (IsDeleted,0) = 0
		END
	END
GO