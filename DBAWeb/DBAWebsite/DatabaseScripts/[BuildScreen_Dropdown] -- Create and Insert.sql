USE [DBA_TEST]
GO

/****** Object:  Table [dbo].[Environment_Dropdown]    Script Date: 2/16/2015 9:55:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BuildScreen_Dropdown](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Resource Name] [nvarchar](50) NULL,
	[SQl Version] [nvarchar](50) NULL,
	[Monitoring Tool] [nvarchar](50) NULL,
	[High Availability] [nvarchar](50) NULL)
GO

Insert into [BuildScreen_Dropdown] ([Resource Name]) values ('JOE');
Insert into [BuildScreen_Dropdown] ([Resource Name]) values ('PAUL');
Insert into [BuildScreen_Dropdown] ([Resource Name]) values ('MANOJ');

Insert into [BuildScreen_Dropdown] ([Monitoring Tool]) values ('Manage Engine');
Insert into [BuildScreen_Dropdown] ([Monitoring Tool]) values ('Solar Winds');
Insert into [BuildScreen_Dropdown] ([Monitoring Tool]) values ('Not Monitoring');


Insert into [BuildScreen_Dropdown] ([High Availability]) values ('Log Shipping');
Insert into [BuildScreen_Dropdown] ([High Availability]) values ('AlwaysOn');
Insert into [BuildScreen_Dropdown] ([High Availability]) values ('Mirroring');
Insert into [BuildScreen_Dropdown] ([High Availability]) values ('Replication');
Insert into [BuildScreen_Dropdown] ([High Availability]) values ('Not Applicable');


Insert into [BuildScreen_Dropdown] ([SQl Version]) values ('SQL 2008 R2 -- Standard Edition (64-bit)');
Insert into [BuildScreen_Dropdown] ([SQl Version]) values ('SQL 2008 R2 -- Enterprise Edition (64-bit)');
Insert into [BuildScreen_Dropdown] ([SQl Version]) values ('SQL 2012 R2 -- Standard Edition (64-bit)');
Insert into [BuildScreen_Dropdown] ([SQl Version]) values ('SQL 2012 R2 -- Enterprise Edition (64-bit)');


