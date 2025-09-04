USE [ERMS_Db]
GO
SET IDENTITY_INSERT [dbo].[EmployeeType] ON 
GO
INSERT [dbo].[EmployeeType] ([EmployeeTypeId], [Type], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (1, N'FTE', 0, 1, 1, CAST(N'1989-09-23T00:00:00.000' AS DateTime), CAST(N'1989-09-23T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[EmployeeType] ([EmployeeTypeId], [Type], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (2, N'Consultant', 0, 1, 1, CAST(N'2022-09-23T00:00:00.000' AS DateTime), CAST(N'2022-09-23T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EmployeeType] OFF
GO
