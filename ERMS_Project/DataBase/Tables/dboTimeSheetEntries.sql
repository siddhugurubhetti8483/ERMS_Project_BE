USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF (OBJECT_ID('dbo.TimeSheetEntries') IS NULL)
BEGIN
    CREATE TABLE [dbo].[TimeSheetEntries](
        [TimeSheetEntryId] [int] IDENTITY(1,1) NOT NULL,
        [TimeSheetId] [int] NULL,
        [TaskId] [int] NULL,
        [EmployeeId] [int] NULL,
        [HoursWorked] [decimal](18, 2) NULL,
        [StartTime] [datetime] NULL,
        [EndTime] [datetime] NULL,
        [WeekNo] [int] NULL,
        CONSTRAINT [PK_TimeSheetEntries] PRIMARY KEY CLUSTERED 
        (
            [TimeSheetEntryId] ASC
        ) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]

    PRINT 'TABLE CREATED'
END
ELSE
BEGIN
    PRINT 'TABLE ALREADY EXISTS'
END
GO
