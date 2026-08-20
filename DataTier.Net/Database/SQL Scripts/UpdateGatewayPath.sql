-- First a query to update the Gateway Path
UPDATE [dbo].[Project]
SET GatewayPath = REPLACE(ControllerFolder, 'Controllers', 'DataGateway\Gateway.cs')
WHERE TemplateVersion = 2;


CREATE TABLE #GatewayCheck (
    ProjectId INT,
    GatewayPath NVARCHAR(255),
    FileExists INT,
    IsDirectory INT,
    ParentExists INT
);

DECLARE @ProjectId INT, @Path NVARCHAR(255);

DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT ProjectId, GatewayPath FROM dbo.Project WHERE GatewayPath IS NOT NULL;

OPEN cur;
FETCH NEXT FROM cur INTO @ProjectId, @Path;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @Result TABLE (FileExists INT, IsDirectory INT, ParentExists INT);

    INSERT INTO @Result
    EXEC master.dbo.xp_fileexist @Path;

    INSERT INTO #GatewayCheck
    SELECT @ProjectId, @Path, FileExists, IsDirectory, ParentExists FROM @Result;

    DELETE FROM @Result;
    FETCH NEXT FROM cur INTO @ProjectId, @Path;
END

CLOSE cur;
DEALLOCATE cur;

-- This is the part that actually does what you asked:
UPDATE p
SET p.GatewayPath = NULL
FROM dbo.Project p
JOIN #GatewayCheck c ON c.ProjectId = p.ProjectId
WHERE c.FileExists = 0 AND c.IsDirectory = 0;

DROP TABLE #GatewayCheck;