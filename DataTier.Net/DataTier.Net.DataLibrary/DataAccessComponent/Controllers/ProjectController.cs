

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ProjectController
    /// <summary>
    /// This class controls a(n) 'Project' object.
    /// </summary>
    public class ProjectController
    {

        #region Methods

            #region CreateProjectParameter
            /// <summary>
            /// This method creates the parameter for a 'Project' data operation.
            /// </summary>
            /// <param name='project'>The 'Project' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateProjectParameter(Project project)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = project;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Project tempProject, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Project' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Project_Delete'.
            /// </summary>
            /// <param name='project'>The 'Project' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(Project tempProject, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteProject";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempproject exists before attemptintg to delete
                    if (tempProject != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteProjectMethod = ProjectMethods.DeleteProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(tempProject);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteProjectMethod, parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Call ErrorHandler.LogError
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Project tempProject, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Project' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Project_FetchAll'.</summary>
            /// <param name='tempProject'>A temporary Project for passing values.</param>
            /// <returns>A collection of 'Project' objects.</returns>
            public static List<Project> FetchAll(Project tempProject, DataManager dataManager)
            {
                // Initial value
                List<Project> projectList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = ProjectMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateProjectParameter(tempProject);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Project> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        projectList = (List<Project>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Call ErrorHandler.LogError
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return projectList;
            }
            #endregion

            #region Find(Project tempProject, DataManager dataManager)
            /// <summary>
            /// Finds a 'Project' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Project_Find'</param>
            /// </summary>
            /// <param name='tempProject'>A temporary Project for passing values.</param>
            /// <returns>A 'Project' object if found else a null 'Project'.</returns>
            public static Project Find(Project tempProject, DataManager dataManager)
            {
                // Initial values
                Project project = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempProject != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = ProjectMethods.FindProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(tempProject);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Project != null))
                        {
                            // Get ReturnObject
                            project = (Project) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Call ErrorHandler.LogError
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return project;
            }
            #endregion

            #region Insert(Project project, DataManager dataManager)
            /// <summary>
            /// Insert a 'Project' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Project_Insert'.</param>
            /// </summary>
            /// <param name='project'>The 'Project' object to insert.</param>
            /// <returns>The id (int) of the new  'Project' object that was inserted.</returns>
            public static int Insert(Project project, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If Projectexists
                    if (project != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = ProjectMethods.InsertProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(project);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Call ErrorHandler.LogError
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Project project, DataManager dataManager)
            /// <summary>
            /// Saves a 'Project' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='project'>The 'Project' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref Project project, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the project exists.
                if (project != null)
                {
                    // Is this a new Project
                    if (project.IsNew)
                    {
                        // Insert new Project
                        int newIdentity = Insert(project, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            project.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Project
                        saved = Update(project, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Project project, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Project' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Project_Update'.</param>
            /// </summary>
            /// <param name='project'>The 'Project' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(Project project, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (project != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = ProjectMethods.UpdateProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(project);
                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Call ErrorHandler.LogError
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}