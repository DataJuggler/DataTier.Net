

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

    #region class BuildExcludesController
    /// <summary>
    /// This class controls a(n) 'BuildExcludes' object.
    /// </summary>
    public class BuildExcludesController
    {

        #region Methods

            #region CreateBuildExcludesParameter
            /// <summary>
            /// This method creates the parameter for a 'BuildExcludes' data operation.
            /// </summary>
            /// <param name='buildexcludes'>The 'BuildExcludes' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateBuildExcludesParameter(BuildExcludes buildExcludes)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = buildExcludes;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(BuildExcludes tempBuildExcludes, DataManager dataManager)
            /// <summary>
            /// Deletes a 'BuildExcludes' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'BuildExcludes_Delete'.
            /// </summary>
            /// <param name='buildexcludes'>The 'BuildExcludes' to delete.</param>
            /// <returns>The result of the Delete</returns>
            public static PolymorphicObject Delete(BuildExcludes tempBuildExcludes, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteBuildExcludes";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempbuildExcludes exists before attemptintg to delete
                    if (tempBuildExcludes != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteBuildExcludesMethod = BuildExcludesMethods.DeleteBuildExcludes;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateBuildExcludesParameter(tempBuildExcludes);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteBuildExcludesMethod, parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Store the Error
                    result.Exception = error;

                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll(BuildExcludes tempBuildExcludes, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'BuildExcludes' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'BuildExcludes_FetchAll'.</summary>
            /// <param name='tempBuildExcludes'>A temporary BuildExcludes for passing values.</param>
            /// <returns>A collection of 'BuildExcludes' objects.</returns>
            public static List<BuildExcludes> FetchAll(BuildExcludes tempBuildExcludes, DataManager dataManager)
            {
                // Initial value
                List<BuildExcludes> buildExcludesList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = BuildExcludesMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateBuildExcludesParameter(tempBuildExcludes);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<BuildExcludes> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        buildExcludesList = (List<BuildExcludes>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return buildExcludesList;
            }
            #endregion

            #region Find(BuildExcludes tempBuildExcludes, DataManager dataManager)
            /// <summary>
            /// Finds a 'BuildExcludes' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'BuildExcludes_Find'</param>
            /// </summary>
            /// <param name='tempBuildExcludes'>A temporary BuildExcludes for passing values.</param>
            /// <returns>A 'BuildExcludes' object if found else a null 'BuildExcludes'.</returns>
            public static BuildExcludes Find(BuildExcludes tempBuildExcludes, DataManager dataManager)
            {
                // Initial values
                BuildExcludes buildExcludes = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempBuildExcludes != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = BuildExcludesMethods.FindBuildExcludes;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateBuildExcludesParameter(tempBuildExcludes);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as BuildExcludes != null))
                        {
                            // Get ReturnObject
                            buildExcludes = (BuildExcludes) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return buildExcludes;
            }
            #endregion

            #region Insert(BuildExcludes buildExcludes, DataManager dataManager)
            /// <summary>
            /// Insert a 'BuildExcludes' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'BuildExcludes_Insert'.</param>
            /// </summary>
            /// <param name='buildExcludes'>The 'BuildExcludes' object to insert.</param>
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'BuildExcludes' object that was inserted.</returns>
            public static PolymorphicObject Insert(BuildExcludes buildExcludes, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If BuildExcludesexists
                    if (buildExcludes != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = BuildExcludesMethods.InsertBuildExcludes;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateBuildExcludesParameter(buildExcludes);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Store the Error
                    result.Exception = error;

                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region Save(ref BuildExcludes buildExcludes, DataManager dataManager)
            /// <summary>
            /// Saves a 'BuildExcludes' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='buildExcludes'>The 'BuildExcludes' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref BuildExcludes buildExcludes, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the buildExcludes exists.
                if (buildExcludes != null)
                {
                    // Is this a new BuildExcludes
                    if (buildExcludes.IsNew)
                    {
                        // Insert new BuildExcludes
                        result = Insert(buildExcludes, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            buildExcludes.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update BuildExcludes
                        result  = Update(buildExcludes, dataManager);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region Update(BuildExcludes buildExcludes, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'BuildExcludes' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'BuildExcludes_Update'.</param>
            /// </summary>
            /// <param name='buildExcludes'>The 'BuildExcludes' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static PolymorphicObject Update(BuildExcludes buildExcludes, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (buildExcludes != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = BuildExcludesMethods.UpdateBuildExcludes;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateBuildExcludesParameter(buildExcludes);
                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Store the Error
                    result.Exception = error;

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
