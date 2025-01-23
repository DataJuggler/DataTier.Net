

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
            public static bool Delete(DTNDatabase tempDTNDatabase, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNDatabase";
                string objectName = "ApplicationLogicComponent.Controllers";

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
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDTNDatabaseMethod, parameters, dataManager);

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
                string objectName = "ApplicationLogicComponent.Controllers";

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
                string objectName = "ApplicationLogicComponent.Controllers";

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
            /// <returns>The id (int) of the new  'DTNDatabase' object that was inserted.</returns>
            public static int Insert(DTNDatabase dTNDatabase, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DTNDatabaseexists
                    if (dTNDatabase != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = DTNDatabaseMethods.InsertDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(dTNDatabase);

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

            #region Save(ref DTNDatabase dTNDatabase, DataManager dataManager)
            /// <summary>
            /// Saves a 'DTNDatabase' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref DTNDatabase dTNDatabase, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the dTNDatabase exists.
                if (dTNDatabase != null)
                {
                    // Is this a new DTNDatabase
                    if (dTNDatabase.IsNew)
                    {
                        // Insert new DTNDatabase
                        int newIdentity = Insert(dTNDatabase, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            dTNDatabase.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DTNDatabase
                        saved = Update(dTNDatabase, dataManager);
                    }
                }

                // return value
                return saved;
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
            public static bool Update(DTNDatabase dTNDatabase, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (dTNDatabase != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DTNDatabaseMethods.UpdateDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(dTNDatabase);
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
