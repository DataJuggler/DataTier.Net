USE [Change To DatabaseName]
GO

/****** Object:  StoredProcedure [dbo].[UpdateProcPermissions]    Script Date: 12/18/2012 10:47:23 PM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProcPermissions]

	-- parameter for the procedure
	@UserName as varchar(50)

AS

declare @sql as varchar(250)

declare @procName as varchar(100)

DECLARE cursorSP CURSOR FOR

	select name from sysobjects where xtype='P' AND category!=2

	OPEN cursorSP 

		FETCH NEXT FROM CursorSP

			INTO @procName

			WHILE @@FETCH_STATUS = 0

			BEGIN
     
				set @sql = 'GRANT EXECUTE ON [dbo].[' + @procName + '] TO [' + @UserName + ']'
		
				exec (@sql)
		
				FETCH NEXT FROM CursorSP
			  
				INTO @procName
				
				

			END
			
			close CursorSP

			Deallocate CursorSP

GO


