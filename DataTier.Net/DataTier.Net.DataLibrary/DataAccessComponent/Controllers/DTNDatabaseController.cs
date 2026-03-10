

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

    #region class DTNDatabaseController
    /// <summary>
    /// This class controls a(n) 'DTNDatabase' object.
    /// </summary>
    public class DTNDatabaseController
    {

        #region Methods

            #region CreateDTNDatabaseParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNDatabase' data operation.
            /// </summary>
            /// <param name='dtndatabase'>The 'DTNDatabase' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDTNDatabaseParameter(DTNDatabase dTNDatabase)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNDatabase;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNDatabase tempDTNDatabase, DataManager dataManager)
            /// <summary>
            /// Deletes a 'DTNDatabase' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'DTNDatabase_Delete'.
            /// </summary>
            /// <param name='dtndatabase'>The 'DTNDatabase' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static PolymorphicObject Delete(DTNDatabase tempDTNDatabase, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNDatabase";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempdTNDatabase exists before attemptintg to delete
                    if (tempDTNDatabase != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNDatabaseMethod = DTNDatabaseMethods.DeleteDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(tempDTNDatabase);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDTNDatabaseMethod, parameters, dataManager);
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

            #region FetchAll(DTNDatabase tempDTNDatabase, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'DTNDatabase' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNDatabase_FetchAll'.</summary>
            /// <param name='tempDTNDatabase'>A temporary DTNDatabase for passing values.</param>
            /// <returns>A collection of 'DTNDatabase' objects.</returns>
            public static List<DTNDatabase> FetchAll(DTNDatabase tempDTNDatabase, DataManager dataManager)
            {
                // Initial value
                List<DTNDatabase> dTNDatabaseList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = DTNDatabaseMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(tempDTNDatabase);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNDatabase> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNDatabaseList = (List<DTNDatabase>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return dTNDatabaseList;
            }
            #endregion

            #region Find(DTNDatabase tempDTNDatabase, DataManager dataManager)
            /// <summary>
            /// Finds a 'DTNDatabase' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNDatabase_Find'</param>
            /// </summary>
            /// <param name='tempDTNDatabase'>A temporary DTNDatabase for passing values.</param>
            /// <returns>A 'DTNDatabase' object if found else a null 'DTNDatabase'.</returns>
            public static DTNDatabase Find(DTNDatabase tempDTNDatabase, DataManager dataManager)
            {
                // Initial values
                DTNDatabase dTNDatabase = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempDTNDatabase != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = DTNDatabaseMethods.FindDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(tempDTNDatabase);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNDatabase != null))
                        {
                            // Get ReturnObject
                            dTNDatabase = (DTNDatabase) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return dTNDatabase;
            }
            #endregion

            #region Insert(DTNDatabase dTNDatabase, DataManager dataManager)
            /// <summary>
            /// Insert a 'DTNDatabase' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNDatabase_Insert'.</param>
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to insert.</param>
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'DTNDatabase' object that was inserted.</returns>
            public static PolymorphicObject Insert(DTNDatabase dTNDatabase, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If DTNDatabaseexists
                    if (dTNDatabase != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = DTNDatabaseMethods.InsertDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(dTNDatabase);

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

            #region Save(ref DTNDatabase dTNDatabase, DataManager dataManager)
            /// <summary>
            /// Saves a 'DTNDatabase' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref DTNDatabase dTNDatabase, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the dTNDatabase exists.
                if (dTNDatabase != null)
                {
                    // Is this a new DTNDatabase
                    if (dTNDatabase.IsNew)
                    {
                        // Insert new DTNDatabase
                        result = Insert(dTNDatabase, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            dTNDatabase.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update DTNDatabase
                        result  = Update(dTNDatabase, dataManager);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region Update(DTNDatabase dTNDatabase, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'DTNDatabase' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNDatabase_Update'.</param>
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static PolymorphicObject Update(DTNDatabase dTNDatabase, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (dTNDatabase != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DTNDatabaseMethods.UpdateDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(dTNDatabase);
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
