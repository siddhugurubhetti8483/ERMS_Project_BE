USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'USP_CountryMaster')
BEGIN
    DROP PROCEDURE USP_CountryMaster;
END
GO

CREATE PROCEDURE USP_CountryMaster
    @CountryId INT = NULL OUT,
    @CountryName NVARCHAR(50) = NULL,
    @Region NVARCHAR(50) = NULL,
    @CreatedBy INT = NULL,
    @ModifiedBy INT = NULL,
    @mode NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@mode = 'CREATE')
    BEGIN
        IF EXISTS (SELECT 1 FROM Country WHERE CountryName = @CountryName AND ISNULL(IsDeleted, 0) = 0)
        BEGIN
            SELECT CAST(409 AS INT) AS CountryId;
			RETURN;
        END
ELSE
	BEGIN
        INSERT INTO Country (CountryName, Region, IsDeleted, CreatedBy, CreatedOn)
        VALUES (@CountryName, @Region, 0, @CreatedBy, GETDATE());

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS CountryId;
    END
END
    ELSE IF (@mode = 'UPDATE')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Country WHERE CountryId = @CountryId AND ISNULL(IsDeleted, 0) = 0)
        BEGIN
			SELECT 400 AS StatusCode;
            --RETURN 0; -- Not found
        END

        IF EXISTS (SELECT 1 FROM Country WHERE CountryName = @CountryName AND CountryId <> @CountryId AND ISNULL(IsDeleted, 0) = 0)
        BEGIN
			SELECT 402 AS StatusCode --Duplicate
            --RETURN 402; -- Duplicate
        END

        UPDATE Country
        SET CountryName = @CountryName,
            Region = @Region,
            ModifiedBy = @ModifiedBy,
            ModifiedOn = GETDATE()
        WHERE CountryId = @CountryId;
		SELECT 200 AS StatusCode
        --RETURN 200; -- ✅ No SELECT
    END

    ELSE IF (@mode = 'GET')
    BEGIN
        SELECT
            C.CountryId,
            C.CountryName,
            C.Region,
            CONCAT(Emp.FirstName, ' ', Emp.LastName) AS CreatedBy,
            CONCAT(ModEmp.FirstName, ' ', ModEmp.LastName) AS ModifiedBy,
            C.CreatedOn,
            C.ModifiedOn,
            C.IsDeleted,
            C.CreatedBy AS CreatedById,
            C.ModifiedBy AS ModifiedById
        FROM Country C
        LEFT JOIN Employees Emp ON C.CreatedBy = Emp.EmployeeId
        LEFT JOIN Employees ModEmp ON C.ModifiedBy = ModEmp.EmployeeId
        WHERE ISNULL(C.IsDeleted, 0) = 0
        ORDER BY C.CountryName;
    END

    ELSE IF (@mode = 'GET_BYID')
    BEGIN
        SELECT
            C.CountryId,
            C.CountryName,
            C.Region,
            CONCAT(Emp.FirstName, ' ', Emp.LastName) AS CreatedBy,
            CONCAT(ModEmp.FirstName, ' ', ModEmp.LastName) AS ModifiedBy,
            C.CreatedOn,
            C.ModifiedOn,
            C.IsDeleted,
            C.CreatedBy AS CreatedById,
            C.ModifiedBy AS ModifiedById
        FROM Country C
        LEFT JOIN Employees Emp ON C.CreatedBy = Emp.EmployeeId
        LEFT JOIN Employees ModEmp ON C.ModifiedBy = ModEmp.EmployeeId
        WHERE ISNULL(C.IsDeleted, 0) = 0 AND C.CountryId = @CountryId;
    END

    ELSE IF (@mode = 'GET_BYNAME')
    BEGIN
        SELECT
            C.CountryId,
            C.CountryName,
            C.Region,
            CONCAT(Emp.FirstName, ' ', Emp.LastName) AS CreatedBy,
            CONCAT(ModEmp.FirstName, ' ', ModEmp.LastName) AS ModifiedBy,
            C.CreatedOn,
            C.ModifiedOn,
            C.IsDeleted,
            C.CreatedBy AS CreatedById,
            C.ModifiedBy AS ModifiedById
        FROM Country C
        LEFT JOIN Employees Emp ON C.CreatedBy = Emp.EmployeeId
        LEFT JOIN Employees ModEmp ON C.ModifiedBy = ModEmp.EmployeeId
        WHERE ISNULL(C.IsDeleted, 0) = 0 AND C.CountryName LIKE '%' + @CountryName + '%';
    END

    ELSE IF (@mode = 'DELETE')
    BEGIN
        IF EXISTS (SELECT 1 FROM Country WHERE CountryId = @CountryId AND ISNULL(IsDeleted, 0) = 0)
        BEGIN
            UPDATE Country
            SET IsDeleted = 1,
                ModifiedBy = @ModifiedBy,
                ModifiedOn = GETDATE()
            WHERE CountryId = @CountryId;
			SELECT 200 AS StatusCode;
        END
        ELSE
        BEGIN
             SELECT 400 AS StatusCode;
        END
    END
END
GO

--select * from Country 

--DECLARE @CountryId INT;

--EXEC USP_CountryMaster
--    @CountryId = @CountryId OUTPUT,
--    @CountryName = 'r', -- partial ya full name
--    @Region = NULL,
--    @CreatedBy = NULL,
--    @ModifiedBy = NULL,
--    @mode = 'GET_BYNAME';

--DECLARE @CountryId INT;
--EXEC @CountryId = USP_CountryMaster
--    @CountryName = 'TestLand',
--    @Region = 'Asia',
--    @CreatedBy = 1,
--    @mode = 'CREATE';

---- This will NOT return inserted ID
---- Instead:
--EXEC USP_CountryMaster
--    @CountryName = 'TestLand2',
--    @Region = 'Asia',
--    @CreatedBy = 1,
--    @mode = 'CREATE';

-- ✔️ This should return inserted CountryId (INT)
