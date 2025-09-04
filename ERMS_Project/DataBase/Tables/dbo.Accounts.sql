USE [ERMS_Db]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF(OBJECT_ID('dbo.Accounts') IS NULL)
BEGIN
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Description] [nvarchar](200) NULL,
	[AccountLocation] [nvarchar](50) NULL,
	[POCName] [nvarchar](150) NULL,
	[POCEmail] [nvarchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[CountryId] [int] NULL,
	[PocMobileNumber] [nvarchar](20) NULL,
	[GstNumber] [nvarchar](20) NULL,
	[PaymentTermsDuration] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
PRINT 'TABLE CREATED'
END 
ELSE
BEGIN
PRINT 'TABLE ALREADY EXIST'
END
GO--------------------
IF NOT EXISTS
(
    SELECT 1
    FROM sys.objects
    WHERE TYPE_DESC='FOREIGN_KEY_CONSTRAINT'
    AND NAME='FK_Accounts_Country'
)
BEGIN
	ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Country] FOREIGN KEY([CountryId])
	REFERENCES [dbo].[Country] ([CountryId])
END
GO
	ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Country]
GO
