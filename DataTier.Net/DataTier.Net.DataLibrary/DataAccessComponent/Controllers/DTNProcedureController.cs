

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

    #region class DTNProcedureController
    /// <summary>
    /// This class controls a(n) 'DTNProcedure' object.
    /// </summary>
    public class DTNProcedureController
    {

        #region Methods

            #region CreateDTNProcedureParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNProcedure' data operation.
            /// </summary>
            /// <param name='dtnprocedure'>The 'DTNProcedure' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDTNProcedureParameter(DTNProcedure dTNProcedure)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNProcedure;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNProcedure tempDTNProcedure, DataManager dataManager)
            /// <summary>
            /// Deletes a 'DTNProcedure' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'DTNProcedure_Delete'.
            /// </summary>
            /// <param name='dtnprocedure'>The 'DTNProcedure' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(DTNProcedure tempDTNProcedure, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNProcedure";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempdTNProcedure exists before attemptintg to delete
                    if (tempDTNProcedure != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNProcedureMethod = DTNProcedureMethods.DeleteDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(tempDTNProcedure);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDTNProcedureMethod, parameters, dataManager);

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

            #region FetchAll(DTNProcedure tempDTNProcedure, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'DTNProcedure' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNProcedure_FetchAll'.</summary>
            /// <param name='tempDTNProcedure'>A temporary DTNProcedure for passing values.</param>
            /// <returns>A collection of 'DTNProcedure' objects.</returns>
            public static List<DTNProcedure> FetchAll(DTNProcedure tempDTNProcedure, DataManager dataManager)
            {
                // Initial value
                List<DTNProcedure> dTNProcedureList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = DTNProcedureMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNProcedureParameter(tempDTNProcedure);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNProcedure> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNProcedureList = (List<DTNProcedure>) returnObject.ObjectValue;
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
                return dTNProcedureList;
            }
            #endregion

            #region Find(DTNProcedure tempDTNProcedure, DataManager dataManager)
            /// <summary>
            /// Finds a 'DTNProcedure' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNProcedure_Find'</param>
            /// </summary>
            /// <param name='tempDTNProcedure'>A temporary DTNProcedure for passing values.</param>
            /// <returns>A 'DTNProcedure' object if found else a null 'DTNProcedure'.</returns>
            public static DTNProcedure Find(DTNProcedure tempDTNProcedure, DataManager dataManager)
            {
                // Initial values
                DTNProcedure dTNProcedure = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempDTNProcedure != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = DTNProcedureMethods.FindDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(tempDTNProcedure);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNProcedure != null))
                        {
                            // Get ReturnObject
                            dTNProcedure = (DTNProcedure) returnObject.ObjectValue;
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
                return dTNProcedure;
            }
            #endregion

            #region Insert(DTNProcedure dTNProcedure, DataManager dataManager)
            /// <summary>
            /// Insert a 'DTNProcedure' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNProcedure_Insert'.</param>
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' object to insert.</param>
            /// <returns>The id (int) of the new  'DTNProcedure' object that was inserted.</returns>
            public static int Insert(DTNProcedure dTNProcedure, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If DTNProcedureexists
                    if (dTNProcedure != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = DTNProcedureMethods.InsertDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(dTNProcedure);

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

            #region Save(ref DTNProcedure dTNProcedure, DataManager dataManager)
            /// <summary>
            /// Saves a 'DTNProcedure' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref DTNProcedure dTNProcedure, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the dTNProcedure exists.
                if (dTNProcedure != null)
                {
                    // Is this a new DTNProcedure
                    if (dTNProcedure.IsNew)
                    {
                        // Insert new DTNProcedure
                        int newIdentity = Insert(dTNProcedure, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            dTNProcedure.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DTNProcedure
                        saved = Update(dTNProcedure, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DTNProcedure dTNProcedure, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'DTNProcedure' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNProcedure_Update'.</param>
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(DTNProcedure dTNProcedure, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (dTNProcedure != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DTNProcedureMethods.UpdateDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(dTNProcedure);
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
