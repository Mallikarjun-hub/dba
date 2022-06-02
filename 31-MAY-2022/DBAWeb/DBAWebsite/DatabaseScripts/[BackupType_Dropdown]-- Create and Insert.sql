USE [DBA_TEST]
GO

/****** Object:  Table [dbo].[BUILDFORM]    Script Date: 2/11/2015 2:19:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BackupType_Dropdown](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BackupType]  nvarchar(50) NOT NULL,	
 CONSTRAINT [PK_BackupType] PRIMARY KEY CLUSTERED 
(
	[BackupType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [dbo].[BackupType_Dropdown] values('CommVault');
INSERT INTO [dbo].[BackupType_Dropdown] values('Disk_local');
INSERT INTO [dbo].[BackupType_Dropdown] values('Disk_AppServer');
INSERT INTO [dbo].[BackupType_Dropdown] values('Disk_FPServer');



