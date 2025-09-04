SET IDENTITY_INSERT [dbo].[Tasks] ON
GO
INSERT INTO [dbo].[Tasks] 
([TaskId], [ProjectId], [Name], [Description], [IsDeleted], [CreatedBy], [ModifiedBy], [CreatedOn], [ModifiedOn]) 
VALUES 
(1, 101, N'Design Database', N'Create and finalize the database schema for the ERP module.', 0, 1, 1, GETDATE(), GETDATE()),
(2, 101, N'Build API', N'Develop core REST APIs for user authentication and data access.', 0, 1, 2, GETDATE(), GETDATE()),
(3, 102, N'UI Wireframe', N'Prepare wireframes and user flow diagrams for the dashboard.', 0, 2, 1, GETDATE(), GETDATE()),
(4, 102, N'Frontend Development', N'Code frontend pages using React and TailwindCSS.', 0, 2, 2, GETDATE(), GETDATE()),
(5, 103, N'Test Suite Setup', N'Integrate Cypress and write automation test scripts.', 1, 3, 2, GETDATE(), GETDATE()),
(6, 104, N'Documentation', N'Document API endpoints and workflows using Swagger.', 0, 1, 1, GETDATE(), GETDATE()),
(7, 104, N'Deployment', N'Set up CI/CD pipelines for staging and production environments.', 0, 3, 1, GETDATE(), GETDATE()),
(8, 105, N'Client Demo', N'Prepare final client demo presentation and checklist.', 1, 1, 3, GETDATE(), GETDATE()),
(9, 105, N'Bug Fixing', N'Address critical issues reported during testing.', 0, 1, 2, GETDATE(), GETDATE()),
(10, 106, N'Performance Optimization', N'Reduce load times and optimize DB queries.', 0, 1, 1, GETDATE(), GETDATE())
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
