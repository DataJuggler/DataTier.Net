

#region using statements

using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ProjectReferenceController
    /// <summary>
    /// This class controls a(n) 'ProjectReference' object.
    /// </summary>
    public class ProjectReferenceController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ProjectReferenceController' object.
        /// </summary>
        public ProjectReferenceController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateProjectReferenceParameter
            /// <summary>
            /// This method creates the parameter for a 'ProjectReference' data operation.
            /// </summary>
            /// <param name='projectreference'>The 'ProjectReference' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateProjectReferenceParameter(ProjectReference projectReference)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = projectReference;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ProjectReference tempProjectReference)
            /// <summary>
            /// Deletes a 'ProjectReference' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ProjectReference_Delete'.
            /// </summary>
            /// <param name='projectreference'>The 'ProjectReference' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ProjectReference tempProjectReference)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteProjectReference";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempprojectReference exists before attemptintg to delete
                    if(tempProjectReference != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteProjectReferenceMethod = this.AppController.DataBridge.DataOperations.ProjectReferenceMethods.DeleteProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(tempProjectReference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteProjectReferenceMethod, parameters);

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

            #region FetchAll(ProjectReference tempProjectReference)
            /// <summary>
            /// This method fetches a collection of 'ProjectReference' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ProjectReference_FetchAll'.</summary>
            /// <param name='tempProjectReference'>A temporary ProjectReference for passing values.</param>
            /// <returns>A collection of 'ProjectReference' objects.</returns>
            public List<ProjectReference> FetchAll(ProjectReference tempProjectReference)
            {
                // Initial value
                List<ProjectReference> projectReferenceList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ProjectReferenceMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateProjectReferenceParameter(tempProjectReference);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ProjectReference> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        projectReferenceList = (List<ProjectReference>) returnObject.ObjectValue;
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
                return projectReferenceList;
            }
            #endregion

            #region Find(ProjectReference tempProjectReference)
            /// <summary>
            /// Finds a 'ProjectReference' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ProjectReference_Find'</param>
            /// </summary>
            /// <param name='tempProjectReference'>A temporary ProjectReference for passing values.</param>
            /// <returns>A 'ProjectReference' object if found else a null 'ProjectReference'.</returns>
            public ProjectReference Find(ProjectReference tempProjectReference)
            {
                // Initial values
                ProjectReference projectReference = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempProjectReference != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ProjectReferenceMethods.FindProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(tempProjectReference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ProjectReference != null))
                        {
                            // Get ReturnObject
                            projectReference = (ProjectReference) returnObject.ObjectValue;
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
                return projectReference;
            }
            #endregion

            #region Insert(ProjectReference projectReference)
            /// <summary>
            /// Insert a 'ProjectReference' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ProjectReference_Insert'.</param>
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to insert.</param>
            /// <returns>The id (int) of the new  'ProjectReference' object that was inserted.</returns>
            public int Insert(ProjectReference projectReference)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ProjectReferenceexists
                    if(projectReference != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ProjectReferenceMethods.InsertProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(projectReference);

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

            #region Save(ref ProjectReference projectReference)
            /// <summary>
            /// Saves a 'ProjectReference' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ProjectReference projectReference)
            {
                // Initial value
                bool saved = false;

                // If the projectReference exists.
                if(projectReference != null)
                {
                    // Is this a new ProjectReference
                    if(projectReference.IsNew)
                    {
                        // Insert new ProjectReference
                        int newIdentity = this.Insert(projectReference);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            projectReference.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ProjectReference
                        saved = this.Update(projectReference);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ProjectReference projectReference)
            /// <summary>
            /// This method Updates a 'ProjectReference' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ProjectReference_Update'.</param>
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ProjectReference projectReference)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(projectReference != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ProjectReferenceMethods.UpdateProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(projectReference);
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
