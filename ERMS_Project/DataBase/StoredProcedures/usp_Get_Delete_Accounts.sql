Use [ERMS_Db]
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_Get_Delete_Accounts')
BEGIN
    DROP PROCEDURE usp_Get_Delete_Accounts;
END
GO

CREATE PROCEDURE [dbo].[usp_Get_Delete_Accounts]
(
    @AccountId INT = NULL,
    @Name VARCHAR(150) = NULL,
    @mode NVARCHAR(20)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@mode = 'GET')
    BEGIN
        SELECT
             a.[AccountId]
            ,a.[Name]
            ,a.[Description]
            ,a.[AccountLocation]
            ,a.[POCName]
            ,a.[POCEmail]
            ,a.[PocMobileNumber]
            ,a.[CountryId]
            ,Cou.[CountryName]
            ,a.[GstNumber]
            ,a.[PaymentTermsDuration]
            ,CONCAT(Cr.FirstName, ' ', Cr.LastName) AS CreatedBy
            ,CONCAT(Md.FirstName, ' ', Md.LastName) AS ModifiedBy
            ,a.[IsDeleted]
            ,a.[CreatedBy] AS CreatedById
            ,a.[ModifiedBy] AS ModifiedById
            ,a.[CreatedOn]
            ,a.[ModifiedOn]
        FROM [dbo].[Accounts] a
        LEFT JOIN Employees Cr ON a.CreatedBy = Cr.EmployeeId
        LEFT JOIN Employees Md ON a.ModifiedBy = Md.EmployeeId
        LEFT JOIN Country Cou ON a.CountryId = Cou.CountryId
        WHERE ISNULL(a.[IsDeleted], 0) = 0
        ORDER BY a.[Name];
    END

    ELSE IF (@mode = 'GET_BYID')
    BEGIN
        SELECT
             a.[AccountId]
            ,a.[Name]
            ,a.[Description]
            ,a.[AccountLocation]
            ,a.[POCName]
            ,a.[POCEmail]
            ,a.[PocMobileNumber]
            ,a.[CountryId]
            ,Cou.[CountryName]
            ,a.[GstNumber]
            ,a.[PaymentTermsDuration]
            ,CONCAT(Cr.FirstName, ' ', Cr.LastName) AS CreatedBy
            ,CONCAT(Md.FirstName, ' ', Md.LastName) AS ModifiedBy
            ,a.[IsDeleted]
            ,a.[CreatedBy]
            ,a.[ModifiedBy]
            ,a.[CreatedOn]
            ,a.[ModifiedOn]
        FROM [dbo].[Accounts] a
        LEFT JOIN Employees Cr ON a.CreatedBy = Cr.EmployeeId
        LEFT JOIN Employees Md ON a.ModifiedBy = Md.EmployeeId
        LEFT JOIN Country Cou ON a.CountryId = Cou.CountryId
        WHERE ISNULL(a.[IsDeleted], 0) = 0 AND a.AccountId = @AccountId;
    END

    ELSE IF (@mode = 'GET_BYNAME')
    BEGIN
        SELECT
             a.[AccountId]
            ,a.[Name]
            ,a.[Description]
            ,a.[AccountLocation]
            ,a.[POCName]
            ,a.[POCEmail]
            ,a.[PocMobileNumber]
            ,a.[CountryId]
            ,Cou.[CountryName]
            ,a.[GstNumber]
            ,a.[PaymentTermsDuration]
            ,CONCAT(Cr.FirstName, ' ', Cr.LastName) AS CreatedBy
            ,CONCAT(Md.FirstName, ' ', Md.LastName) AS ModifiedBy
            ,a.[IsDeleted]
            ,a.[CreatedBy]
            ,a.[ModifiedBy]
            ,a.[CreatedOn]
            ,a.[ModifiedOn]
        FROM [dbo].[Accounts] a
        LEFT JOIN Employees Cr ON a.CreatedBy = Cr.EmployeeId
        LEFT JOIN Employees Md ON a.ModifiedBy = Md.EmployeeId
        LEFT JOIN Country Cou ON a.CountryId = Cou.CountryId
        WHERE ISNULL(a.[IsDeleted], 0) = 0 AND a.[Name] LIKE '%' + @Name + '%';
    END

    ELSE IF (@mode = 'DELETE')
    BEGIN
        IF EXISTS (SELECT 1 FROM [Accounts] WHERE [AccountId] = @AccountId AND ISNULL(IsDeleted, 0) = 0)
        BEGIN
            UPDATE [Accounts]
            SET [IsDeleted] = 1,
                [ModifiedBy] = 1,
                [ModifiedOn] = GETDATE()
            WHERE [AccountId] = @AccountId;
            SELECT 200 AS StatusCode; -- Success
        END
        ELSE
        BEGIN
            SELECT 400 AS StatusCode; -- Not Found or Already Deleted
        END
    END
END
GO
