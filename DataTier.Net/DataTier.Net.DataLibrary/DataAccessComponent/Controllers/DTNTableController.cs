

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

    #region class DTNTableController
    /// <summary>
    /// This class controls a(n) 'DTNTable' object.
    /// </summary>
    public class DTNTableController
    {

        #region Methods

            #region CreateDTNTableParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNTable' data operation.
            /// </summary>
            /// <param name='dtntable'>The 'DTNTable' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDTNTableParameter(DTNTable dTNTable)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNTable;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNTable tempDTNTable, DataManager dataManager)
            /// <summary>
            /// Deletes a 'DTNTable' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'DTNTable_Delete'.
            /// </summary>
            /// <param name='dtntable'>The 'DTNTable' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static PolymorphicObject Delete(DTNTable tempDTNTable, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNTable";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempdTNTable exists before attemptintg to delete
                    if (tempDTNTable != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNTableMethod = DTNTableMethods.DeleteDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(tempDTNTable);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDTNTableMethod, parameters, dataManager);
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

            #region FetchAll(DTNTable tempDTNTable, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'DTNTable' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNTable_FetchAll'.</summary>
            /// <param name='tempDTNTable'>A temporary DTNTable for passing values.</param>
            /// <returns>A collection of 'DTNTable' objects.</returns>
            public static List<DTNTable> FetchAll(DTNTable tempDTNTable, DataManager dataManager)
            {
                // Initial value
                List<DTNTable> dTNTableList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = DTNTableMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNTableParameter(tempDTNTable);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNTable> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNTableList = (List<DTNTable>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return dTNTableList;
            }
            #endregion

            #region Find(DTNTable tempDTNTable, DataManager dataManager)
            /// <summary>
            /// Finds a 'DTNTable' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNTable_Find'</param>
            /// </summary>
            /// <param name='tempDTNTable'>A temporary DTNTable for passing values.</param>
            /// <returns>A 'DTNTable' object if found else a null 'DTNTable'.</returns>
            public static DTNTable Find(DTNTable tempDTNTable, DataManager dataManager)
            {
                // Initial values
                DTNTable dTNTable = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempDTNTable != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = DTNTableMethods.FindDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(tempDTNTable);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNTable != null))
                        {
                            // Get ReturnObject
                            dTNTable = (DTNTable) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return dTNTable;
            }
            #endregion

            #region Insert(DTNTable dTNTable, DataManager dataManager)
            /// <summary>
            /// Insert a 'DTNTable' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNTable_Insert'.</param>
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' object to insert.</param>
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'DTNTable' object that was inserted.</returns>
            public static PolymorphicObject Insert(DTNTable dTNTable, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If DTNTableexists
                    if (dTNTable != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = DTNTableMethods.InsertDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(dTNTable);

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

            #region Save(ref DTNTable dTNTable, DataManager dataManager)
            /// <summary>
            /// Saves a 'DTNTable' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref DTNTable dTNTable, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the dTNTable exists.
                if (dTNTable != null)
                {
                    // Is this a new DTNTable
                    if (dTNTable.IsNew)
                    {
                        // Insert new DTNTable
                        result = Insert(dTNTable, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            dTNTable.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update DTNTable
                        result  = Update(dTNTable, dataManager);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region Update(DTNTable dTNTable, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'DTNTable' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNTable_Update'.</param>
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static PolymorphicObject Update(DTNTable dTNTable, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (dTNTable != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DTNTableMethods.UpdateDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(dTNTable);
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
