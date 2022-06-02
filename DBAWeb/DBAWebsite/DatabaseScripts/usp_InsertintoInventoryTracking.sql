USE [DBA_TEST]
GO

/****** Object:  StoredProcedure [dbo].[usp_CompareCheckLists]    Script Date: 3/6/2015 9:00:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_InsertintoInventoryTracking] 
	-- Add the parameters for the stored procedure here
	@servername varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Insert into InventoryTracking ([servername]
      ,[DBedition]
      ,[DBVersion]
      ,[DBVersionShort]
      ,[DBPatchLevel]
      ,[NumberOfProcessors]
      ,[NumberOfLogicalProcessors]
	  ,[InstallDate]
	  ,[RecordInsertDate]
	  ,[status]) 
select [servername]
      ,[SQLedition]
      ,[SQLVersion]
      ,[SQLVersionShort]
      ,[SQLPatchLevel]
      ,[NumberOfProcessors]
      ,[NumberOfLogicalProcessors]
	  ,[SQLInstallDate] 
	  ,GETDATE()
	  ,'Active'
	  from [dbo].[AInventoryInfo] a where a.[servername] = @servername

END

GO


