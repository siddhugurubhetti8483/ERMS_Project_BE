USE [ERMS_Db]
GO
SET IDENTITY_INSERT [dbo].[ProjectAllocation] ON
GO
INSERT INTO [dbo].[ProjectAllocation] 
([ProjectAllocationId], [ProjectId], [EmployeeId], [IsBillable], [StartDate], [EndDate], [NumberOfEmployee], [ProjectStatus], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn])
VALUES
(1, 101, 1001, 1, '2024-01-01', '2024-06-30', 3, N'Active', 0, 1, 1, GETDATE(), GETDATE()),
(2, 102, 1002, 0, '2024-02-15', '2024-08-15', 2, N'On Hold', 0, 2, 1, GETDATE(), GETDATE()),
(3, 103, 1003, 1, '2024-03-01', '2024-09-30', 1, N'Completed', 1, 1, 2, GETDATE(), GETDATE()),
(4, 101, 1004, 1, '2024-01-10', '2024-06-10', 1, N'Active', 0, 2, 1, GETDATE(), GETDATE()),
(5, 104, 1005, 0, '2024-04-01', '2024-10-31', 2, N'Active', 0, 1, 3, GETDATE(), GETDATE()),
(6, 105, 1006, 1, '2024-05-01', '2024-12-31', 1, N'Planning', 0, 3, 2, GETDATE(), GETDATE()),
(7, 102, 1007, 0, '2024-06-01', '2024-11-30', 2, N'Cancelled', 1, 1, 1, GETDATE(), GETDATE()),
(8, 106, 1008, 1, '2024-01-20', '2024-07-31', 4, N'Active', 0, 2, 2, GETDATE(), GETDATE()),
(9, 107, 1009, 0, '2024-03-15', '2024-09-15', 1, N'Completed', 0, 3, 3, GETDATE(), GETDATE()),
(10, 108, 1010, 1, '2024-02-01', '2024-08-01', 3, N'Active', 0, 1, 2, GETDATE(), GETDATE()),
-- Sample 1: Active, Billable project
(1, 3, 1, '2024-01-01', '2024-12-31', 5, 'Active', 0, 1, 2, GETDATE(), GETDATE()),

-- Sample 2: Completed, Non-Billable
(2, 4, 0, '2023-01-01', '2023-12-31', 3, 'Completed', 0, 2, 3, GETDATE(), GETDATE()),

-- Sample 3: On Hold
(3, 14, 1, '2024-06-01', NULL, 1, 'On Hold', 0, 4, 4, GETDATE(), GETDATE()),

-- Sample 4: Cancelled
(4, 13, 0, '2024-02-01', '2024-04-30', 2, 'Cancelled', 1, 5, 5, GETDATE(), GETDATE()),

-- Sample 5: In Progress with future end date
(5, 20, 1, '2025-01-01', '2025-12-31', 4, 'In Progress', 0, 6, 6, GETDATE(), GETDATE());
GO
SET IDENTITY_INSERT [dbo].[ProjectAllocation] OFF
GO



