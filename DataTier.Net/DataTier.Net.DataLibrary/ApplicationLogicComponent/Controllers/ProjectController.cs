

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ProjectController
    /// <summary>
    /// This class controls a(n) 'Project' object.
    /// </summary>
    public class ProjectController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ProjectController' object.
        /// </summary>
        public ProjectController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateProjectParameter
            /// <summary>
            /// This method creates the parameter for a 'Project' data operation.
            /// </summary>
            /// <param name='project'>The 'Project' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateProjectParameter(Project project)
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

            #region Delete(Project tempProject)
            /// <summary>
            /// Deletes a 'Project' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Project_Delete'.
            /// </summary>
            /// <param name='project'>The 'Project' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Project tempProject)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteProject";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempproject exists before attemptintg to delete
                    if(tempProject != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteProjectMethod = this.AppController.DataBridge.DataOperations.ProjectMethods.DeleteProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(tempProject);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteProjectMethod, parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Project tempProject)
            /// <summary>
            /// This method fetches a collection of 'Project' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Project_FetchAll'.</summary>
            /// <param name='tempProject'>A temporary Project for passing values.</param>
            /// <returns>A collection of 'Project' objects.</returns>
            public List<Project> FetchAll(Project tempProject)
            {
                // Initial value
                List<Project> projectList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ProjectMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateProjectParameter(tempProject);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Project> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        projectList = (List<Project>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return projectList;
            }
            #endregion

            #region Find(Project tempProject)
            /// <summary>
            /// Finds a 'Project' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Project_Find'</param>
            /// </summary>
            /// <param name='tempProject'>A temporary Project for passing values.</param>
            /// <returns>A 'Project' object if found else a null 'Project'.</returns>
            public Project Find(Project tempProject)
            {
                // Initial values
                Project project = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempProject != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ProjectMethods.FindProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(tempProject);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return project;
            }
            #endregion

            #region Insert(Project project)
            /// <summary>
            /// Insert a 'Project' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Project_Insert'.</param>
            /// </summary>
            /// <param name='project'>The 'Project' object to insert.</param>
            /// <returns>The id (int) of the new  'Project' object that was inserted.</returns>
            public int Insert(Project project)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Projectexists
                    if(project != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ProjectMethods.InsertProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(project);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Project project)
            /// <summary>
            /// Saves a 'Project' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='project'>The 'Project' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Project project)
            {
                // Initial value
                bool saved = false;

                // If the project exists.
                if(project != null)
                {
                    // Is this a new Project
                    if(project.IsNew)
                    {
                        // Insert new Project
                        int newIdentity = this.Insert(project);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(project);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Project project)
            /// <summary>
            /// This method Updates a 'Project' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Project_Update'.</param>
            /// </summary>
            /// <param name='project'>The 'Project' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Project project)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(project != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ProjectMethods.UpdateProject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectParameter(project);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
