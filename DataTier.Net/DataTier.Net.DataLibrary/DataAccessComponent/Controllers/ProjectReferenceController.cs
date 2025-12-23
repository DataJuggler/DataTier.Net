

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

    #region class ProjectReferenceController
    /// <summary>
    /// This class controls a(n) 'ProjectReference' object.
    /// </summary>
    public class ProjectReferenceController
    {

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

            #region Delete(ProjectReference tempProjectReference, DataManager dataManager)
            /// <summary>
            /// Deletes a 'ProjectReference' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'ProjectReference_Delete'.
            /// </summary>
            /// <param name='projectreference'>The 'ProjectReference' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(ProjectReference tempProjectReference, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteProjectReference";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempprojectReference exists before attemptintg to delete
                    if (tempProjectReference != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteProjectReferenceMethod = ProjectReferenceMethods.DeleteProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(tempProjectReference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteProjectReferenceMethod, parameters, dataManager);

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

            #region FetchAll(ProjectReference tempProjectReference, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'ProjectReference' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ProjectReference_FetchAll'.</summary>
            /// <param name='tempProjectReference'>A temporary ProjectReference for passing values.</param>
            /// <returns>A collection of 'ProjectReference' objects.</returns>
            public static List<ProjectReference> FetchAll(ProjectReference tempProjectReference, DataManager dataManager)
            {
                // Initial value
                List<ProjectReference> projectReferenceList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = ProjectReferenceMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateProjectReferenceParameter(tempProjectReference);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ProjectReference> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        projectReferenceList = (List<ProjectReference>) returnObject.ObjectValue;
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
                return projectReferenceList;
            }
            #endregion

            #region Find(ProjectReference tempProjectReference, DataManager dataManager)
            /// <summary>
            /// Finds a 'ProjectReference' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ProjectReference_Find'</param>
            /// </summary>
            /// <param name='tempProjectReference'>A temporary ProjectReference for passing values.</param>
            /// <returns>A 'ProjectReference' object if found else a null 'ProjectReference'.</returns>
            public static ProjectReference Find(ProjectReference tempProjectReference, DataManager dataManager)
            {
                // Initial values
                ProjectReference projectReference = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempProjectReference != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = ProjectReferenceMethods.FindProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(tempProjectReference);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

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
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return projectReference;
            }
            #endregion

            #region Insert(ProjectReference projectReference, DataManager dataManager)
            /// <summary>
            /// Insert a 'ProjectReference' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ProjectReference_Insert'.</param>
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to insert.</param>
            /// <returns>The id (int) of the new  'ProjectReference' object that was inserted.</returns>
            public static int Insert(ProjectReference projectReference, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If ProjectReferenceexists
                    if (projectReference != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = ProjectReferenceMethods.InsertProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(projectReference);

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

            #region Save(ref ProjectReference projectReference, DataManager dataManager)
            /// <summary>
            /// Saves a 'ProjectReference' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref ProjectReference projectReference, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the projectReference exists.
                if (projectReference != null)
                {
                    // Is this a new ProjectReference
                    if (projectReference.IsNew)
                    {
                        // Insert new ProjectReference
                        int newIdentity = Insert(projectReference, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
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
                        saved = Update(projectReference, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ProjectReference projectReference, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'ProjectReference' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ProjectReference_Update'.</param>
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(ProjectReference projectReference, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (projectReference != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = ProjectReferenceMethods.UpdateProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(projectReference);
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
