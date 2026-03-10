

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
                PolymorphicObject result = new PolymorphicObject();

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
                        result.Success = ProjectManager.DeleteProject(deleteProjectProc, dataConnector);

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
            /// This method fetches all 'Project' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to delete.
            /// <returns>A PolymorphicObject object with all  'Projects' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                        // set result.ObjectValue
                        result.ObjectValue = projectListCollection;
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

            #region FindProject(Project)
            /// <summary>
            /// This method finds a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                                // set result.ObjectValue
                                result.ObjectValue = project;
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

            #region InsertProject (Project)
            /// <summary>
            /// This method inserts a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                            result.IntegerValue = ProjectManager.InsertProject(insertProjectProc, dataConnector);

                            // Set the value for Sucess based on if the Insert was Successful
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

            #region UpdateProject (Project)
            /// <summary>
            /// This method updates a 'Project' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Project' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateProject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                            result.Success = ProjectManager.UpdateProject(updateProjectProc, dataConnector);
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
