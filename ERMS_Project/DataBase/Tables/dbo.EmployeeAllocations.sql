USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.EmployeeAllocations') IS NULL)
BEGIN
CREATE TABLE [dbo].[EmployeeAllocations](
	[AllocationId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[EmployeeId] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[AllocationStatus] [nvarchar](20) NULL,
	[IsBillable] [bit] NULL,
	[IsUtilized] [bit] NULL,
	[AllocationPercentage] [int] NULL,
	[BillablePercentage] [int] NULL,
	[Remarks] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_EmployeeAllocations] PRIMARY KEY CLUSTERED 
(
	[AllocationId] ASC
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
    AND NAME='FK_EmployeeAllocations_Employees'
)
BEGIN
	ALTER TABLE [dbo].[EmployeeAllocations]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAllocations_Employees] FOREIGN KEY([EmployeeId])
	REFERENCES [dbo].[Employees] ([EmployeeId])
END
GO
	ALTER TABLE [dbo].[EmployeeAllocations] CHECK CONSTRAINT [FK_EmployeeAllocations_Employees]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_EmployeeAllocations_Projects'
)
BEGIN
	ALTER TABLE [dbo].[EmployeeAllocations]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAllocations_Projects] FOREIGN KEY([ProjectId])
	REFERENCES [dbo].[Projects] ([ProjectId])
	END
GO
	ALTER TABLE [dbo].[EmployeeAllocations] CHECK CONSTRAINT [FK_EmployeeAllocations_Projects]
GO
