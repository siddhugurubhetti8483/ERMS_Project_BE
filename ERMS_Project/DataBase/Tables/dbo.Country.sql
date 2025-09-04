USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF (OBJECT_ID('dbo.Country') IS NULL)
BEGIN
    CREATE TABLE [dbo].[Country](
        [CountryId] [int] IDENTITY(1,1) NOT NULL,
        [CountryName] [nvarchar](50) NULL,
        [Region] [nvarchar](50) NULL,
        [IsDeleted] [bit] NULL,
        [CreatedBy] [int] NULL,
        [ModifiedBy] [int] NULL,
        [CreatedOn] [datetime] NULL,
        [ModifiedOn] [datetime] NULL,
        CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
        (
            [CountryId] ASC
        ) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]

    PRINT 'TABLE CREATED'
END
ELSE
BEGIN
    PRINT 'TABLE ALREADY EXISTS'
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Accounts_Country'
)
BEGIN
    ALTER TABLE [dbo].[Accounts] WITH CHECK ADD CONSTRAINT [FK_Accounts_Country] FOREIGN KEY([CountryId])
    REFERENCES [dbo].[Country] ([CountryId])
END
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Country]
GO
