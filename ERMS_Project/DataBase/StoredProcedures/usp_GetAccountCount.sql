
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE type = 'P' AND name = 'usp_GetAccountCount')
BEGIN
	DROP PROCEDURE usp_GetAccountCount;
END
GO
CREATE PROCEDURE usp_GetAccountCount

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	
Select 'TotalAccounts'[Type],	
Count(1)[Count] 
FROM Accounts UNION All 
SELECT CASE WHEN ISNULL(isDeleted,0) = 0 THEN 'ActiveAccounts' ELSE 'InActiveAccounts'  END [Type],
COUNT(*)[Count] FROM Accounts GROUP BY ISNULL(isDeleted,0)
	
END
GO
------Sample Execution Query-----
--	EXEC usp_GetAccountCount 
