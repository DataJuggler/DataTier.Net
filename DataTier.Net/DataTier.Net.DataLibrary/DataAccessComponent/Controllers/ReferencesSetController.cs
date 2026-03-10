

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
            public static PolymorphicObject Delete(ReferencesSet tempReferencesSet, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteReferencesSet";
                string objectName = "DataAccessComponent.Controllers";

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
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteReferencesSetMethod, parameters, dataManager);
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
                string objectName = "DataAccessComponent.Controllers";

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
                string objectName = "DataAccessComponent.Controllers";

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
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'ReferencesSet' object that was inserted.</returns>
            public static PolymorphicObject Insert(ReferencesSet referencesSet, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If ReferencesSetexists
                    if (referencesSet != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = ReferencesSetMethods.InsertReferencesSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateReferencesSetParameter(referencesSet);

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

            #region Save(ref ReferencesSet referencesSet, DataManager dataManager)
            /// <summary>
            /// Saves a 'ReferencesSet' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='referencesSet'>The 'ReferencesSet' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref ReferencesSet referencesSet, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the referencesSet exists.
                if (referencesSet != null)
                {
                    // Is this a new ReferencesSet
                    if (referencesSet.IsNew)
                    {
                        // Insert new ReferencesSet
                        result = Insert(referencesSet, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            referencesSet.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update ReferencesSet
                        result  = Update(referencesSet, dataManager);
                    }
                }

                // return value
                return result;
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
            public static PolymorphicObject Update(ReferencesSet referencesSet, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (referencesSet != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = ReferencesSetMethods.UpdateReferencesSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateReferencesSetParameter(referencesSet);

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
