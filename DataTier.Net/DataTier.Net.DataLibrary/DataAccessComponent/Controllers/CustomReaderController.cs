

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

    #region class CustomReaderController
    /// <summary>
    /// This class controls a(n) 'CustomReader' object.
    /// </summary>
    public class CustomReaderController
    {

        #region Methods

            #region CreateCustomReaderParameter
            /// <summary>
            /// This method creates the parameter for a 'CustomReader' data operation.
            /// </summary>
            /// <param name='customreader'>The 'CustomReader' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateCustomReaderParameter(CustomReader customReader)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = customReader;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(CustomReader tempCustomReader, DataManager dataManager)
            /// <summary>
            /// Deletes a 'CustomReader' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'CustomReader_Delete'.
            /// </summary>
            /// <param name='customreader'>The 'CustomReader' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(CustomReader tempCustomReader, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteCustomReader";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempcustomReader exists before attemptintg to delete
                    if (tempCustomReader != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteCustomReaderMethod = CustomReaderMethods.DeleteCustomReader;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomReaderParameter(tempCustomReader);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteCustomReaderMethod, parameters, dataManager);

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
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(CustomReader tempCustomReader, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'CustomReader' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'CustomReader_FetchAll'.</summary>
            /// <param name='tempCustomReader'>A temporary CustomReader for passing values.</param>
            /// <returns>A collection of 'CustomReader' objects.</returns>
            public static List<CustomReader> FetchAll(CustomReader tempCustomReader, DataManager dataManager)
            {
                // Initial value
                List<CustomReader> customReaderList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = CustomReaderMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateCustomReaderParameter(tempCustomReader);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<CustomReader> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        customReaderList = (List<CustomReader>) returnObject.ObjectValue;
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
                return customReaderList;
            }
            #endregion

            #region Find(CustomReader tempCustomReader, DataManager dataManager)
            /// <summary>
            /// Finds a 'CustomReader' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'CustomReader_Find'</param>
            /// </summary>
            /// <param name='tempCustomReader'>A temporary CustomReader for passing values.</param>
            /// <returns>A 'CustomReader' object if found else a null 'CustomReader'.</returns>
            public static CustomReader Find(CustomReader tempCustomReader, DataManager dataManager)
            {
                // Initial values
                CustomReader customReader = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempCustomReader != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = CustomReaderMethods.FindCustomReader;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomReaderParameter(tempCustomReader);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as CustomReader != null))
                        {
                            // Get ReturnObject
                            customReader = (CustomReader) returnObject.ObjectValue;
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
                return customReader;
            }
            #endregion

            #region Insert(CustomReader customReader, DataManager dataManager)
            /// <summary>
            /// Insert a 'CustomReader' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'CustomReader_Insert'.</param>
            /// </summary>
            /// <param name='customReader'>The 'CustomReader' object to insert.</param>
            /// <returns>The id (int) of the new  'CustomReader' object that was inserted.</returns>
            public static int Insert(CustomReader customReader, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If CustomReaderexists
                    if (customReader != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = CustomReaderMethods.InsertCustomReader;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomReaderParameter(customReader);

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
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref CustomReader customReader, DataManager dataManager)
            /// <summary>
            /// Saves a 'CustomReader' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='customReader'>The 'CustomReader' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref CustomReader customReader, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the customReader exists.
                if (customReader != null)
                {
                    // Is this a new CustomReader
                    if (customReader.IsNew)
                    {
                        // Insert new CustomReader
                        int newIdentity = Insert(customReader, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            customReader.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update CustomReader
                        saved = Update(customReader, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(CustomReader customReader, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'CustomReader' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'CustomReader_Update'.</param>
            /// </summary>
            /// <param name='customReader'>The 'CustomReader' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(CustomReader customReader, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (customReader != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = CustomReaderMethods.UpdateCustomReader;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateCustomReaderParameter(customReader);
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
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
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
