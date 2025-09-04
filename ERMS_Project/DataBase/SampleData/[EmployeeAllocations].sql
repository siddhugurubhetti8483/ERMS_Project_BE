USE [ERMS_Db]
SET IDENTITY_INSERT [dbo].[EmployeeAllocations] ON 
GO
INSERT [dbo].[EmployeeAllocations] ([AllocationId], [ProjectId], [EmployeeId], [StartDate], [EndDate], [AllocationStatus], [IsBillable], [IsUtilized], [AllocationPercentage], [BillablePercentage], [Remarks], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (4, NULL, NULL, CAST(N'2022-10-13' AS Date), CAST(N'2023-01-10' AS Date), N'Active', 0, 1, 90, 70, N'Good', 0, 1, 0, CAST(N'2022-10-13T00:00:00.000' AS DateTime), CAST(N'2022-10-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[EmployeeAllocations] ([AllocationId], [ProjectId], [EmployeeId], [StartDate], [EndDate], [AllocationStatus], [IsBillable], [IsUtilized], [AllocationPercentage], [BillablePercentage], [Remarks], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (5, NULL, NULL, CAST(N'2022-10-13' AS Date), CAST(N'2023-04-12' AS Date), N'Active', 0, 1, 100, 70, N'Excellent', 0, 1, 0, CAST(N'2022-10-13T00:00:00.000' AS DateTime), CAST(N'2022-10-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[EmployeeAllocations] ([AllocationId], [ProjectId], [EmployeeId], [StartDate], [EndDate], [AllocationStatus], [IsBillable], [IsUtilized], [AllocationPercentage], [BillablePercentage], [Remarks], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (6, NULL, NULL, CAST(N'2022-10-13' AS Date), CAST(N'2023-06-16' AS Date), N'Active', 0, 1, 95, 75, N' Very Good', 0, 1, 0, CAST(N'2022-10-13T00:00:00.000' AS DateTime), CAST(N'2022-10-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[EmployeeAllocations] ([AllocationId], [ProjectId], [EmployeeId], [StartDate], [EndDate], [AllocationStatus], [IsBillable], [IsUtilized], [AllocationPercentage], [BillablePercentage], [Remarks], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (7, NULL, NULL, CAST(N'2022-10-13' AS Date), CAST(N'2023-10-19' AS Date), N'Active', 0, 1, 90, 50, N'Poor', 0, 1, 1, CAST(N'2022-10-13T00:00:00.000' AS DateTime), CAST(N'2022-10-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[EmployeeAllocations] ([AllocationId], [ProjectId], [EmployeeId], [StartDate], [EndDate], [AllocationStatus], [IsBillable], [IsUtilized], [AllocationPercentage], [BillablePercentage], [Remarks], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) VALUES (8, NULL, NULL, CAST(N'2022-10-13' AS Date), CAST(N'2023-11-25' AS Date), N'Active', 0, 1, 90, 60, N'Average', 0, 1, 2, CAST(N'2022-10-13T00:00:00.000' AS DateTime), CAST(N'2022-10-13T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EmployeeAllocations] OFF
GO
