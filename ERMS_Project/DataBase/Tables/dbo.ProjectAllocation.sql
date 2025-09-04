USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF (OBJECT_ID('dbo.ProjectAllocation') IS NULL)
BEGIN
    CREATE TABLE [dbo].[ProjectAllocation](
        [ProjectAllocationId] [int] IDENTITY(1,1) NOT NULL,
        [ProjectId] [int] NULL,
        [EmployeeId] [int] NULL,
        [IsBillable] [bit] NULL,
        [StartDate] [datetime] NULL,
        [EndDate] [datetime] NULL,
        [NumberOfEmployee] [int] NULL,
        [ProjectStatus] [nvarchar](50) NULL,
        [IsDeleted] [bit] NULL,
        [CreatedBy] [int] NULL,
        [ModifiedBy] [int] NULL,
        [CreatedOn] [datetime] NULL,
        [ModifiedOn] [datetime] NULL,
        CONSTRAINT [PK_ProjectAllocation] PRIMARY KEY CLUSTERED 
        (
            [ProjectAllocationId] ASC
        ) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]

    PRINT 'TABLE CREATED'
END
ELSE
BEGIN
    PRINT 'TABLE ALREADY EXISTS'
END
GO
