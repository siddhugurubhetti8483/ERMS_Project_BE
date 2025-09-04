--USE [ERMS_Db]
--GO

--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetSequenceNumber')
--BEGIN
--    DROP PROCEDURE usp_GetSequenceNumber;
--END
--GO

--CREATE PROCEDURE usp_GetSequenceNumber
--    @EMPSEQ INT OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;
    
--    DECLARE @MaxNumber INT = 0;
--    DECLARE @CurrentNumber INT;
--    DECLARE @Code VARCHAR(20);
    
--    -- Create a temporary table to store extracted numbers
--    DECLARE @NumberTable TABLE (ExtractedNumber INT);
    
--    -- Extract all numeric suffixes from EmployeeCode
--    INSERT INTO @NumberTable
--    SELECT 
--        CAST(
--            CASE
--                -- When code ends with numbers after letters (like NVS0012)
--                WHEN EmployeeCode LIKE '%[^0-9]%[0-9]%' 
--                THEN REVERSE(SUBSTRING(REVERSE(EmployeeCode), 1, 
--                    PATINDEX('%[^0-9]%', REVERSE(EmployeeCode)) - 1))
--                -- When code is all numbers
--                WHEN ISNUMERIC(EmployeeCode) = 1 
--                THEN EmployeeCode
--                ELSE '0'
--            END AS INT)
--    FROM Employees
--    WHERE EmployeeCode IS NOT NULL;
    
--    -- Get the maximum extracted number
--    SELECT @MaxNumber = ISNULL(MAX(ExtractedNumber), 0) 
--    FROM @NumberTable
--    WHERE ExtractedNumber IS NOT NULL;
    
--    -- Set the next sequence number
--    SET @EMPSEQ = @MaxNumber + 1;
    
--    RETURN;
--END
--GO

----DECLARE @NextSequence INT;

----EXEC usp_GetSequenceNumber @EMPSEQ = @NextSequence OUTPUT;

----SELECT @NextSequence AS NextEmployeeCodeNumber;
----;


--I think this sp is not coorect thats why i am comment it. 
--Thank you