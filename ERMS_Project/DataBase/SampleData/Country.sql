SET IDENTITY_INSERT [dbo].[Country] ON
GO
INSERT INTO [dbo].[Country] 
([CountryId], [CountryName], [Region], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn])
VALUES 
(1, N'India', N'South Asia', 0, 1, 1, GETDATE(), GETDATE()),
(2, N'United States', N'North America', 0, 1, 1, GETDATE(), GETDATE()),
(3, N'Germany', N'Europe', 0, 1, 1, GETDATE(), GETDATE()),
(4, N'Australia', N'Oceania', 0, 1, 1, GETDATE(), GETDATE()),
(5, N'Japan', N'East Asia', 0, 1, 1, GETDATE(), GETDATE()),
(6, N'Brazil', N'South America', 1, 1, 1, GETDATE(), GETDATE()),
(7, N'South Africa', N'Africa', 0, 1, 1, GETDATE(), GETDATE()),
(8, N'Canada', N'North America', 0, 1, 1, GETDATE(), GETDATE()),
(9, N'France', N'Europe', 0, 1, 1, GETDATE(), GETDATE()),
(10, N'Singapore', N'Southeast Asia', 0, 1, 1, GETDATE(), GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
