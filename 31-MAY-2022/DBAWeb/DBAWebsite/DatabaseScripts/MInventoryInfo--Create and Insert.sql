USE [DBA_TEST]
GO

/****** Object:  Table [dbo].[MInventoryInfo]    Script Date: 2/11/2015 4:48:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MInventoryInfo](
	[Site Name] [nvarchar](255) NULL,
	[Site Size] [nvarchar](255) NULL,
	[Plant Tech] [nvarchar](255) NULL,
	[Cell Phone] [nvarchar](255) NULL,
	[Office] [nvarchar](255) NULL,
	[Manager] [nvarchar](255) NULL,
	[Cell Phone1] [nvarchar](255) NULL,
	[Office1] [nvarchar](255) NULL,
	[Other Contact] [nvarchar](255) NULL,
	[Cell Phone2] [nvarchar](255) NULL,
	[Office2] [nvarchar](255) NULL,
	[other ] [nvarchar](255) NULL,
	[IT Contact Team] [nvarchar](100) NULL,
	[Business Contact] [nvarchar](100) NULL,
	[Location ID] [nvarchar](100) NULL,
	[Application Info] [nvarchar](100) NULL
) ON [PRIMARY]

GO



  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([IT Contact Team],[Business Contact],[Application Info]) values ('Shop Floor','Shannin Rudman','SAP')

  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JLA')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JMC')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JKU')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JCB')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JGI')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JYU')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JIN')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JGC')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JCI')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JXI')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JCO')
  insert into [DBA_TEST].[dbo].[MInventoryInfo] ([Location ID]) values ('JHA')