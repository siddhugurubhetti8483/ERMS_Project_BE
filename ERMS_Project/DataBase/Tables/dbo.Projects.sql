USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.Projects') IS NULL)
BEGIN
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[ProjectName] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[ProjectStatusId] [int] NULL,
	[ProjectCostingTypeId] [int] NULL,
	[ProjectManagerId] [int] NULL,
	[PracticeId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
PRINT 'TABLE CREATED'
END
ELSE
BEGIN
PRINT 'TABLE ALREADY EXIST'
END
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Projects_Accounts'
)
BEGIN
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
END
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Accounts]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Projects_Employees'
)
BEGIN
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Employees] FOREIGN KEY([ProjectManagerId])
REFERENCES [dbo].[Employees] ([EmployeeId])
END
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Employees]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Projects_Practices'
)
BEGIN
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Practices] FOREIGN KEY([PracticeId])
REFERENCES [dbo].[Practices] ([PracticeId])
END
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Practices]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Projects_ProjectCostingTypes'
)
BEGIN
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectCostingTypes] FOREIGN KEY([ProjectCostingTypeId])
REFERENCES [dbo].[ProjectCostingTypes] ([ProjectCostingTypeId])
END
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectCostingTypes]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Projects_ProjectStatus'
)
BEGIN
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectStatus] FOREIGN KEY([ProjectStatusId])
REFERENCES [dbo].[ProjectStatus] ([StatusId])
END
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectStatus]
GO
