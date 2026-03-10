

#region using statements

using System;
using System.Collections.Generic;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class ProjectReferenceMethods
    /// <summary>
    /// This class contains methods for modifying a 'ProjectReference' object.
    /// </summary>
    public static class ProjectReferenceMethods
    {

        #region Methods

            #region DeleteProjectReference(ProjectReference)
            /// <summary>
            /// This method deletes a 'ProjectReference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReference' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteProjectReference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteProjectReferenceStoredProcedure deleteProjectReferenceProc = null;

                    // verify the first parameters is a(n) 'ProjectReference'.
                    if (parameters[0].ObjectValue as ProjectReference != null)
                    {
                        // Create ProjectReference
                        ProjectReference projectReference = (ProjectReference) parameters[0].ObjectValue;

                        // verify projectReference exists
                        if(projectReference != null)
                        {
                            // Now create deleteProjectReferenceProc from ProjectReferenceWriter
                            // The DataWriter converts the 'ProjectReference'
                            // to the SqlParameter[] array needed to delete a 'ProjectReference'.
                            deleteProjectReferenceProc = ProjectReferenceWriter.CreateDeleteProjectReferenceStoredProcedure(projectReference);
                        }
                    }

                    // Verify deleteProjectReferenceProc exists
                    if(deleteProjectReferenceProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = ProjectReferenceManager.DeleteProjectReference(deleteProjectReferenceProc, dataConnector);

                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ProjectReference' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReference' to delete.
            /// <returns>A PolymorphicObject object with all  'ProjectReferences' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<ProjectReference> projectReferenceListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllProjectReferencesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ProjectReferenceParameter
                    // Declare Parameter
                    ProjectReference paramProjectReference = null;

                    // verify the first parameters is a(n) 'ProjectReference'.
                    if (parameters[0].ObjectValue as ProjectReference != null)
                    {
                        // Get ProjectReferenceParameter
                        paramProjectReference = (ProjectReference) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllProjectReferencesProc from ProjectReferenceWriter
                    fetchAllProc = ProjectReferenceWriter.CreateFetchAllProjectReferencesStoredProcedure(paramProjectReference);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    projectReferenceListCollection = ProjectReferenceManager.FetchAllProjectReferences(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(projectReferenceListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = projectReferenceListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FindProjectReference(ProjectReference)
            /// <summary>
            /// This method finds a 'ProjectReference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReference' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindProjectReference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                ProjectReference projectReference = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindProjectReferenceStoredProcedure findProjectReferenceProc = null;

                    // verify the first parameters is a 'ProjectReference'.
                    if (parameters[0].ObjectValue as ProjectReference != null)
                    {
                        // Get ProjectReferenceParameter
                        ProjectReference paramProjectReference = (ProjectReference) parameters[0].ObjectValue;

                        // verify paramProjectReference exists
                        if(paramProjectReference != null)
                        {
                            // Now create findProjectReferenceProc from ProjectReferenceWriter
                            // The DataWriter converts the 'ProjectReference'
                            // to the SqlParameter[] array needed to find a 'ProjectReference'.
                            findProjectReferenceProc = ProjectReferenceWriter.CreateFindProjectReferenceStoredProcedure(paramProjectReference);
                        }

                        // Verify findProjectReferenceProc exists
                        if(findProjectReferenceProc != null)
                        {
                            // Execute Find Stored Procedure
                            projectReference = ProjectReferenceManager.FindProjectReference(findProjectReferenceProc, dataConnector);

                            // if dataObject exists
                            if(projectReference != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = projectReference;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region InsertProjectReference (ProjectReference)
            /// <summary>
            /// This method inserts a 'ProjectReference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReference' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertProjectReference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                ProjectReference projectReference = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertProjectReferenceStoredProcedure insertProjectReferenceProc = null;

                    // verify the first parameters is a(n) 'ProjectReference'.
                    if (parameters[0].ObjectValue as ProjectReference != null)
                    {
                        // Create ProjectReference Parameter
                        projectReference = (ProjectReference) parameters[0].ObjectValue;

                        // verify projectReference exists
                        if(projectReference != null)
                        {
                            // Now create insertProjectReferenceProc from ProjectReferenceWriter
                            // The DataWriter converts the 'ProjectReference'
                            // to the SqlParameter[] array needed to insert a 'ProjectReference'.
                            insertProjectReferenceProc = ProjectReferenceWriter.CreateInsertProjectReferenceStoredProcedure(projectReference);
                        }

                        // Verify insertProjectReferenceProc exists
                        if(insertProjectReferenceProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = ProjectReferenceManager.InsertProjectReference(insertProjectReferenceProc, dataConnector);

                            // Set Sucess or false
                            result.Success = result.HasIntegerValue;
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region UpdateProjectReference (ProjectReference)
            /// <summary>
            /// This method updates a 'ProjectReference' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReference' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateProjectReference(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                ProjectReference projectReference = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateProjectReferenceStoredProcedure updateProjectReferenceProc = null;

                    // verify the first parameters is a(n) 'ProjectReference'.
                    if (parameters[0].ObjectValue as ProjectReference != null)
                    {
                        // Create ProjectReference Parameter
                        projectReference = (ProjectReference) parameters[0].ObjectValue;

                        // verify projectReference exists
                        if(projectReference != null)
                        {
                            // Now create updateProjectReferenceProc from ProjectReferenceWriter
                            // The DataWriter converts the 'ProjectReference'
                            // to the SqlParameter[] array needed to update a 'ProjectReference'.
                            updateProjectReferenceProc = ProjectReferenceWriter.CreateUpdateProjectReferenceStoredProcedure(projectReference);
                        }

                        // Verify updateProjectReferenceProc exists
                        if(updateProjectReferenceProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = ProjectReferenceManager.UpdateProjectReference(updateProjectReferenceProc, dataConnector);
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
