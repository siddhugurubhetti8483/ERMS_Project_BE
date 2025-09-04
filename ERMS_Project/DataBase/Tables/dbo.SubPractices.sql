USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.SubPractices') IS NULL)
BEGIN
CREATE TABLE [dbo].[SubPractices](
	[SubPracticeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[PracticeId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_SubPractices] PRIMARY KEY CLUSTERED 
(
	[SubPracticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
PRINT 'TABLE CREATED'
END
ELSE
BEGIN
PRINT 'TABLE ALREADY CREATED'
END
GO
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_SubPractices_Practices'
)
BEGIN
ALTER TABLE [dbo].[SubPractices]  WITH CHECK ADD  CONSTRAINT [FK_SubPractices_Practices] FOREIGN KEY([PracticeId])
REFERENCES [dbo].[Practices] ([PracticeId])
END
GO
ALTER TABLE [dbo].[SubPractices] CHECK CONSTRAINT [FK_SubPractices_Practices]
GO
