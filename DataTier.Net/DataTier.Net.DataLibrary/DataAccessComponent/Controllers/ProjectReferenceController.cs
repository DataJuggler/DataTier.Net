

#region using statements

using System;
using System.Collections.Generic;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Logging;
using DataAccessComponent.DataOperations;
using DataAccessComponent.DataBridge;
using DataAccessComponent.Data;

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
            public static PolymorphicObject Delete(ProjectReference tempProjectReference, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

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
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteProjectReferenceMethod, parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
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
                    ErrorHandler.LogError(methodName, objectName, error);
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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
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
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'ProjectReference' object that was inserted.</returns>
            public static PolymorphicObject Insert(ProjectReference projectReference, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If ProjectReferenceexists
                    if (projectReference != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = ProjectReferenceMethods.InsertProjectReference;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateProjectReferenceParameter(projectReference);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region Save(ref ProjectReference projectReference, DataManager dataManager)
            /// <summary>
            /// Saves a 'ProjectReference' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref ProjectReference projectReference, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the projectReference exists.
                if (projectReference != null)
                {
                    // Is this a new ProjectReference
                    if (projectReference.IsNew)
                    {
                        // Insert new ProjectReference
                        result = Insert(projectReference, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            projectReference.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update ProjectReference
                        result  = Update(projectReference, dataManager);
                    }
                }

                // return value
                return result;
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
            public static PolymorphicObject Update(ProjectReference projectReference, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

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
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
