USE [ERMS_Db]
GO
SET IDENTITY_INSERT [dbo].[ProjectStatus] ON 
GO
INSERT [dbo].[ProjectStatus] ([StatusId], [Status], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (1, N'InProgress', 0, 1, 0, CAST(N'2022-10-31T00:00:00.000' AS DateTime), CAST(N'2022-10-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectStatus] ([StatusId], [Status], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (2, N'Complete', 0, 2, 0, CAST(N'2022-10-31T00:00:00.000' AS DateTime), CAST(N'2022-10-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectStatus] ([StatusId], [Status], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (3, N'OnHold', 0, 3, 1, CAST(N'2022-10-31T00:00:00.000' AS DateTime), CAST(N'2022-10-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectStatus] ([StatusId], [Status], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (4, N'ToDo', 0, 4, 1, CAST(N'2022-10-31T00:00:00.000' AS DateTime), CAST(N'2022-10-31T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ProjectStatus] OFF
GO
