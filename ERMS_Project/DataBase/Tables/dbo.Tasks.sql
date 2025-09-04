USE [ERMS_Db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF (OBJECT_ID('dbo.Tasks') IS NULL)
BEGIN
    CREATE TABLE [dbo].[Tasks] (
        [TaskId] INT IDENTITY(1,1) NOT NULL,
        [ProjectId] INT NOT NULL,
        [Name] NVARCHAR(255) NULL,
        [Description] NVARCHAR(1000) NULL,
        [IsDeleted] BIT NULL,
        [CreatedBy] INT NULL,
        [ModifiedBy] INT NULL,
        [CreatedOn] DATETIME NULL,
        [ModifiedOn] DATETIME NULL,
        CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
        (
            [TaskId] ASC
        ) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]

    PRINT 'TABLE CREATED'
END
ELSE
BEGIN
    PRINT 'TABLE ALREADY EXIST'
END
GO
