USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.SkillSets') IS NULL)
BEGIN
CREATE TABLE [dbo].[SkillSets](
	[Skill_Id] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[PracticeId] [int] NULL,
	[IsDeleted] [int] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [date] NULL,
	[ModifiedOn] [date] NULL,
 CONSTRAINT [PK_SkillSets] PRIMARY KEY CLUSTERED 
(
	[Skill_Id] ASC
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
    AND NAME='FK_SkillSets_Practices'
)
BEGIN
ALTER TABLE [dbo].[SkillSets]  WITH CHECK ADD  CONSTRAINT [FK_SkillSets_Practices] FOREIGN KEY([PracticeId])
REFERENCES [dbo].[Practices] ([PracticeId])
END
GO
ALTER TABLE [dbo].[SkillSets] CHECK CONSTRAINT [FK_SkillSets_Practices]
GO
