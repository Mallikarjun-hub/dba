USE [DBA_TEST]
GO

/****** Object:  Table [dbo].[BackupType_Dropdown]    Script Date: 2/13/2015 3:14:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Environment_Dropdown](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Environment] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Environment] PRIMARY KEY CLUSTERED 
(
	[Environment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [Environment_Dropdown] values ('Production');

INSERT INTO [Environment_Dropdown] values ('Test');

INSERT INTO [Environment_Dropdown] values ('Development');

