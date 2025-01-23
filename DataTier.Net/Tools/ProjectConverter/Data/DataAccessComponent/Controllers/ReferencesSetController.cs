

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

    #region class ReferencesSetController
    /// <summary>
    /// This class controls a(n) 'ReferencesSet' object.
    /// </summary>
    public class ReferencesSetController
    {

        #region Methods

            #region CreateReferencesSetParameter
            /// <summary>
            /// This method creates the parameter for a 'ReferencesSet' data operation.
            /// </summary>
            /// <param name='referencesset'>The 'ReferencesSet' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateReferencesSetParameter(ReferencesSet referencesSet)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = referencesSet;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ReferencesSet tempReferencesSet, DataManager dataManager)
            /// <summary>
            /// Deletes a 'ReferencesSet' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'ReferencesSet_Delete'.
            /// </summary>
            /// <param name='referencesset'>The 'ReferencesSet' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(ReferencesSet tempReferencesSet, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteReferencesSet";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempreferencesSet exists before attemptintg to delete
                    if (tempReferencesSet != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteReferencesSetMethod = ReferencesSetMethods.DeleteReferencesSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateReferencesSetParameter(tempReferencesSet);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteReferencesSetMethod, parameters, dataManager);

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
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(ReferencesSet tempReferencesSet, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'ReferencesSet' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ReferencesSet_FetchAll'.</summary>
            /// <param name='tempReferencesSet'>A temporary ReferencesSet for passing values.</param>
            /// <returns>A collection of 'ReferencesSet' objects.</returns>
            public static List<ReferencesSet> FetchAll(ReferencesSet tempReferencesSet, DataManager dataManager)
            {
                // Initial value
                List<ReferencesSet> referencesSetList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = ReferencesSetMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateReferencesSetParameter(tempReferencesSet);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ReferencesSet> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        referencesSetList = (List<ReferencesSet>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return referencesSetList;
            }
            #endregion

            #region Find(ReferencesSet tempReferencesSet, DataManager dataManager)
            /// <summary>
            /// Finds a 'ReferencesSet' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ReferencesSet_Find'</param>
            /// </summary>
            /// <param name='tempReferencesSet'>A temporary ReferencesSet for passing values.</param>
            /// <returns>A 'ReferencesSet' object if found else a null 'ReferencesSet'.</returns>
            public static ReferencesSet Find(ReferencesSet tempReferencesSet, DataManager dataManager)
            {
                // Initial values
                ReferencesSet referencesSet = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempReferencesSet != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = ReferencesSetMethods.FindReferencesSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateReferencesSetParameter(tempReferencesSet);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ReferencesSet != null))
                        {
                            // Get ReturnObject
                            referencesSet = (ReferencesSet) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return referencesSet;
            }
            #endregion

            #region Insert(ReferencesSet referencesSet, DataManager dataManager)
            /// <summary>
            /// Insert a 'ReferencesSet' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ReferencesSet_Insert'.</param>
            /// </summary>
            /// <param name='referencesSet'>The 'ReferencesSet' object to insert.</param>
            /// <returns>The id (int) of the new  'ReferencesSet' object that was inserted.</returns>
            public static int Insert(ReferencesSet referencesSet, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ReferencesSetexists
                    if (referencesSet != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = ReferencesSetMethods.InsertReferencesSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateReferencesSetParameter(referencesSet);

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
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref ReferencesSet referencesSet, DataManager dataManager)
            /// <summary>
            /// Saves a 'ReferencesSet' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='referencesSet'>The 'ReferencesSet' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref ReferencesSet referencesSet, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the referencesSet exists.
                if (referencesSet != null)
                {
                    // Is this a new ReferencesSet
                    if (referencesSet.IsNew)
                    {
                        // Insert new ReferencesSet
                        int newIdentity = Insert(referencesSet, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            referencesSet.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ReferencesSet
                        saved = Update(referencesSet, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ReferencesSet referencesSet, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'ReferencesSet' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ReferencesSet_Update'.</param>
            /// </summary>
            /// <param name='referencesSet'>The 'ReferencesSet' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(ReferencesSet referencesSet, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (referencesSet != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = ReferencesSetMethods.UpdateReferencesSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateReferencesSetParameter(referencesSet);
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
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}
