USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.ProjectCostingTypes') IS NULL)
BEGIN
CREATE TABLE [dbo].[ProjectCostingTypes](
	[ProjectCostingTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_ProjectCostingTypes] PRIMARY KEY CLUSTERED 
(
	[ProjectCostingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
PRINT 'TABLE CREATED'
END
ELSE
BEGIN
PRINT 'TABLE ALREADY EXIST'
END
GO
