DECLARE @ProjectId INT;

DECLARE ProjectCursor CURSOR FOR
SELECT ProjectId FROM Project;

OPEN ProjectCursor;

FETCH NEXT FROM ProjectCursor INTO @ProjectId;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE Project
    SET 
        ObjectReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'DataObjects' AND ProjectId = @ProjectId),
        StoredProcedureReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'StoredProcedures' AND ProjectId = @ProjectId),
        ReaderReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'Readers' AND ProjectId = @ProjectId),
        ControllerReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'Controllers' AND ProjectId = @ProjectId),
        DataOperationsReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'DataOperations' AND ProjectId = @ProjectId),
        DataManagerReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'DataManager' AND ProjectId = @ProjectId),
        DataWriterReferencesSetId = (SELECT ReferencesSetId FROM ProjectReference WHERE ReferenceName = 'Writers' AND ProjectId = @ProjectId)
    WHERE ProjectId = @ProjectId;

    FETCH NEXT FROM ProjectCursor INTO @ProjectId;
END;

CLOSE ProjectCursor;
DEALLOCATE ProjectCursor;
