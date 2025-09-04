USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.Employees') IS NULL)
BEGIN
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](10) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateofBirth] [date] NULL,
	[CountryofBirth] [nvarchar](50) NULL,
	[Gender] [nvarchar](20) NULL,
	[MaritalStatus] [nvarchar](20) NULL,
	[DateofMarriage] [date] NULL,
	[PersonalEmail] [nvarchar](50) NULL,
	[ContactNumber] [nchar](10) NULL,
	[DateofJoining] [date] NULL,
	[EmployeeCode] [nvarchar](50) NULL,
	[OfficialEmail] [nvarchar](50) NULL,
	[EmployeeTypeId] [int] NULL,
	[RevisedLocationId] [int] NULL,
	[Designation] [nvarchar](50) NULL,
	[OverallExperience] [decimal](5, 2) NULL,
	[Skill_Id] [int] NULL,
	[ReportingManagerId] [int] NULL,
	[ReportingManagerName] [nvarchar](50) NULL,
	[HighestEducation] [nvarchar](100) NULL,
	[EmploymentStatus] [bit] NULL,
	[RelievingDate] [date] NULL,
	[SubPracticeId] [int] NULL,
	[IsEngineering] [bit] NULL,
	[IsNextAssignmentIdentified] [bit] NULL,
	[NextAssignmentName] [nvarchar](50) NULL,
	[NextAssignmentStartDate] [date] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
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
    AND NAME='FK_Employees_EmployeeType'
)
BEGIN
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_EmployeeType] FOREIGN KEY([EmployeeTypeId])
REFERENCES [dbo].[EmployeeType] ([EmployeeTypeId])
END
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_EmployeeType]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Employees_Locations'
)
BEGIN
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Locations] FOREIGN KEY([RevisedLocationId])
REFERENCES [dbo].[Locations] ([Id])
END
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Locations]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Employees_SkillSets'
)
BEGIN
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_SkillSets] FOREIGN KEY([Skill_Id])
REFERENCES [dbo].[SkillSets] ([Skill_Id])
END
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_SkillSets]
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Employees_SubPractices'
)
BEGIN
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_SubPractices] FOREIGN KEY([SubPracticeId])
REFERENCES [dbo].[SubPractices] ([SubPracticeId])
END
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_SubPractices]
GO
