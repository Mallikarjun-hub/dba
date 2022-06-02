USE [DBA_TEST]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdateInventoryTracking]    Script Date: 3/6/2015 3:57:37 PM ******/
DROP PROCEDURE [dbo].[usp_UpdateInventoryTracking]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdateInventoryTracking]    Script Date: 3/6/2015 3:57:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_UpdateInventoryTracking] 
	-- Add the parameters for the stored procedure here
	@oldservername varchar(250),
	@newservername varchar(250),
	@upgradedate Date

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

       UPDATE [dbo].[InventoryTracking] SET
       [Oldservername] = [servername]
      ,[OldDBedition] = [DBedition]
      ,[OldDBVersion] = [DBVersion]
      ,[OldDBVersionShort] = [DBVersionShort]
      ,[OldDBPatchLevel] = [DBPatchLevel]
      ,[OldNumberOfProcessors] = [NumberOfProcessors]
      ,[OldNumberOfLogicalProcessors] = [NumberOfLogicalProcessors]
	  ,[RecordUpdateDate] = GETDATE()
	  ,[UpgradeDate] = @upgradedate
	  WHERE servername = @oldservername


	  UPDATE [dbo].[InventoryTracking] SET 
	  [servername] = A.[servername]
      ,[DBedition] = A.[SQLedition]
      ,[DBVersion] = A.[SQLVersion]
      ,[DBVersionShort] = A.[SQLVersionShort]
      ,[DBPatchLevel] = A.[SQLPatchLevel]
      ,[NumberOfProcessors] = A.[NumberOfProcessors]
      ,[NumberOfLogicalProcessors] = A.[NumberOfLogicalProcessors]
	  FROM [dbo].[AInventoryInfo] A
	  WHERE A.servername = @newservername and [dbo].[InventoryTracking].servername = @oldservername

END



GO


