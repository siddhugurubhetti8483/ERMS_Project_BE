USE [ERMS_Db]
GO
SET IDENTITY_INSERT [dbo].[ProjectCostingTypes] ON 
GO
INSERT [dbo].[ProjectCostingTypes] ([ProjectCostingTypeId], [Name], [Description], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (1, N'PF', N'PF Description', 0, 0, 1, CAST(N'2022-07-12T00:00:00.000' AS DateTime), CAST(N'2021-10-17T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectCostingTypes] ([ProjectCostingTypeId], [Name], [Description], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (2, N'Internal', N'Internal Description', 0, 0, 1, CAST(N'2022-08-22T00:00:00.000' AS DateTime), CAST(N'2021-10-12T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectCostingTypes] ([ProjectCostingTypeId], [Name], [Description], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (3, N'RFB', N'RFB Description', 0, 0, 1, CAST(N'2021-09-24T00:00:00.000' AS DateTime), CAST(N'2021-12-17T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectCostingTypes] ([ProjectCostingTypeId], [Name], [Description], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (4, N'T&M', N'T&M Description', 0, 0, 1, CAST(N'2022-10-12T00:00:00.000' AS DateTime), CAST(N'2021-10-17T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ProjectCostingTypes] OFF
GO
