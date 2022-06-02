USE [DBA_TEST]
GO

/****** Object:  Table [dbo].[BackupType_Dropdown]    Script Date: 2/13/2015 2:59:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryType_Dropdown](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InventoryType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InventoryType] PRIMARY KEY CLUSTERED 
(
	[InventoryType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [InventoryType_Dropdown] values('New');
INSERT INTO [InventoryType_Dropdown] values('Replacement');
INSERT INTO [InventoryType_Dropdown] values('Temporary');


