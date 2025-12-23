

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

    #region class DTNFieldController
    /// <summary>
    /// This class controls a(n) 'DTNField' object.
    /// </summary>
    public class DTNFieldController
    {

        #region Methods

            #region CreateDTNFieldParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNField' data operation.
            /// </summary>
            /// <param name='dtnfield'>The 'DTNField' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDTNFieldParameter(DTNField dTNField)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNField;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNField tempDTNField, DataManager dataManager)
            /// <summary>
            /// Deletes a 'DTNField' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'DTNField_Delete'.
            /// </summary>
            /// <param name='dtnfield'>The 'DTNField' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(DTNField tempDTNField, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNField";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempdTNField exists before attemptintg to delete
                    if (tempDTNField != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNFieldMethod = DTNFieldMethods.DeleteDTNField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNFieldParameter(tempDTNField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDTNFieldMethod, parameters, dataManager);

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

            #region FetchAll(DTNField tempDTNField, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'DTNField' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNField_FetchAll'.</summary>
            /// <param name='tempDTNField'>A temporary DTNField for passing values.</param>
            /// <returns>A collection of 'DTNField' objects.</returns>
            public static List<DTNField> FetchAll(DTNField tempDTNField, DataManager dataManager)
            {
                // Initial value
                List<DTNField> dTNFieldList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = DTNFieldMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNFieldParameter(tempDTNField);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNField> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNFieldList = (List<DTNField>) returnObject.ObjectValue;
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
                return dTNFieldList;
            }
            #endregion

            #region Find(DTNField tempDTNField, DataManager dataManager)
            /// <summary>
            /// Finds a 'DTNField' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNField_Find'</param>
            /// </summary>
            /// <param name='tempDTNField'>A temporary DTNField for passing values.</param>
            /// <returns>A 'DTNField' object if found else a null 'DTNField'.</returns>
            public static DTNField Find(DTNField tempDTNField, DataManager dataManager)
            {
                // Initial values
                DTNField dTNField = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempDTNField != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = DTNFieldMethods.FindDTNField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNFieldParameter(tempDTNField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNField != null))
                        {
                            // Get ReturnObject
                            dTNField = (DTNField) returnObject.ObjectValue;
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
                return dTNField;
            }
            #endregion

            #region Insert(DTNField dTNField, DataManager dataManager)
            /// <summary>
            /// Insert a 'DTNField' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNField_Insert'.</param>
            /// </summary>
            /// <param name='dTNField'>The 'DTNField' object to insert.</param>
            /// <returns>The id (int) of the new  'DTNField' object that was inserted.</returns>
            public static int Insert(DTNField dTNField, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If DTNFieldexists
                    if (dTNField != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = DTNFieldMethods.InsertDTNField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNFieldParameter(dTNField);

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

            #region Save(ref DTNField dTNField, DataManager dataManager)
            /// <summary>
            /// Saves a 'DTNField' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNField'>The 'DTNField' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref DTNField dTNField, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the dTNField exists.
                if (dTNField != null)
                {
                    // Is this a new DTNField
                    if (dTNField.IsNew)
                    {
                        // Insert new DTNField
                        int newIdentity = Insert(dTNField, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            dTNField.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DTNField
                        saved = Update(dTNField, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DTNField dTNField, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'DTNField' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNField_Update'.</param>
            /// </summary>
            /// <param name='dTNField'>The 'DTNField' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(DTNField dTNField, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (dTNField != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DTNFieldMethods.UpdateDTNField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNFieldParameter(dTNField);
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
