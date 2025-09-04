USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF (OBJECT_ID('dbo.TimeSheet') IS NULL)
BEGIN
    CREATE TABLE [dbo].[TimeSheet](
        [TimeSheetId] [int] IDENTITY(1,1) NOT NULL,
        [EmployeeId] [int] NULL,
        [WeekStartingDate] [datetime] NULL,
        [IsSubmitted] [bit] NULL,
        [SubmittedDate] [datetime] NULL,
        [IsApproved] [bit] NULL,
        [ApprovedDate] [datetime] NULL,
        CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED 
        (
            [TimeSheetId] ASC
        ) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]

    PRINT 'TABLE CREATED'
END
ELSE
BEGIN
    PRINT 'TABLE ALREADY EXISTS'
END
GO