SELECT ProjectId 
FROM Project 
WHERE 
    ObjectReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference)
    OR StoredProcedureReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference)
    OR ReaderReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference)
    OR ControllerReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference)
    OR DataOperationsReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference)
    OR DataManagerReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference)
    OR DataWriterReferencesSetId NOT IN (SELECT ReferencesSetId FROM ProjectReference);
