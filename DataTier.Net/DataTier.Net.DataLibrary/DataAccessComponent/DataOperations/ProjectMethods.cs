

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class ProjectMethods
    /// <summary>
    /// This class contains methods for modifying a 'Project' object.
    /// </summary>
    public static class ProjectMethods
    {

        #region Methods

            #region DeleteProject(Project)
            /// <summary>
            /// This method deletes a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteProjectStoredProcedure deleteProjectProc = null;

                    // verify the first parameters is a(n) 'Project'.
                    if (parameters[0].ObjectValue as Project != null)
                    {
                        // Create Project
                        Project project = (Project) parameters[0].ObjectValue;

                        // verify project exists
                        if(project != null)
                        {
                            // Now create deleteProjectProc from ProjectWriter
                            // The DataWriter converts the 'Project'
                            // to the SqlParameter[] array needed to delete a 'Project'.
                            deleteProjectProc = ProjectWriter.CreateDeleteProjectStoredProcedure(project);
                        }
                    }

                    // Verify deleteProjectProc exists
                    if(deleteProjectProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = ProjectManager.DeleteProject(deleteProjectProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Project' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to delete.
            /// <returns>A PolymorphicObject object with all  'Projects' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Project> projectListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllProjectsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ProjectParameter
                    // Declare Parameter
                    Project paramProject = null;

                    // verify the first parameters is a(n) 'Project'.
                    if (parameters[0].ObjectValue as Project != null)
                    {
                        // Get ProjectParameter
                        paramProject = (Project) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllProjectsProc from ProjectWriter
                    fetchAllProc = ProjectWriter.CreateFetchAllProjectsStoredProcedure(paramProject);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    projectListCollection = ProjectManager.FetchAllProjects(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(projectListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = projectListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindProject(Project)
            /// <summary>
            /// This method finds a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Project project = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindProjectStoredProcedure findProjectProc = null;

                    // verify the first parameters is a 'Project'.
                    if (parameters[0].ObjectValue as Project != null)
                    {
                        // Get ProjectParameter
                        Project paramProject = (Project) parameters[0].ObjectValue;

                        // verify paramProject exists
                        if(paramProject != null)
                        {
                            // Now create findProjectProc from ProjectWriter
                            // The DataWriter converts the 'Project'
                            // to the SqlParameter[] array needed to find a 'Project'.
                            findProjectProc = ProjectWriter.CreateFindProjectStoredProcedure(paramProject);
                        }

                        // Verify findProjectProc exists
                        if(findProjectProc != null)
                        {
                            // Execute Find Stored Procedure
                            project = ProjectManager.FindProject(findProjectProc, dataConnector);

                            // if dataObject exists
                            if(project != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = project;
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
                return returnObject;
            }
            #endregion

            #region InsertProject (Project)
            /// <summary>
            /// This method inserts a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Project project = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertProjectStoredProcedure insertProjectProc = null;

                    // verify the first parameters is a(n) 'Project'.
                    if (parameters[0].ObjectValue as Project != null)
                    {
                        // Create Project Parameter
                        project = (Project) parameters[0].ObjectValue;

                        // verify project exists
                        if(project != null)
                        {
                            // Now create insertProjectProc from ProjectWriter
                            // The DataWriter converts the 'Project'
                            // to the SqlParameter[] array needed to insert a 'Project'.
                            insertProjectProc = ProjectWriter.CreateInsertProjectStoredProcedure(project);
                        }

                        // Verify insertProjectProc exists
                        if(insertProjectProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = ProjectManager.InsertProject(insertProjectProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateProject (Project)
            /// <summary>
            /// This method updates a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Project project = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateProjectStoredProcedure updateProjectProc = null;

                    // verify the first parameters is a(n) 'Project'.
                    if (parameters[0].ObjectValue as Project != null)
                    {
                        // Create Project Parameter
                        project = (Project) parameters[0].ObjectValue;

                        // verify project exists
                        if(project != null)
                        {
                            // Now create updateProjectProc from ProjectWriter
                            // The DataWriter converts the 'Project'
                            // to the SqlParameter[] array needed to update a 'Project'.
                            updateProjectProc = ProjectWriter.CreateUpdateProjectStoredProcedure(project);
                        }

                        // Verify updateProjectProc exists
                        if(updateProjectProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = ProjectManager.UpdateProject(updateProjectProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}
