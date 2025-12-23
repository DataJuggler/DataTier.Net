

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

    #region class FieldSetFieldController
    /// <summary>
    /// This class controls a(n) 'FieldSetField' object.
    /// </summary>
    public class FieldSetFieldController
    {

        #region Methods

            #region CreateFieldSetFieldParameter
            /// <summary>
            /// This method creates the parameter for a 'FieldSetField' data operation.
            /// </summary>
            /// <param name='fieldsetfield'>The 'FieldSetField' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateFieldSetFieldParameter(FieldSetField fieldSetField)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = fieldSetField;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(FieldSetField tempFieldSetField, DataManager dataManager)
            /// <summary>
            /// Deletes a 'FieldSetField' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'FieldSetField_Delete'.
            /// </summary>
            /// <param name='fieldsetfield'>The 'FieldSetField' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(FieldSetField tempFieldSetField, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteFieldSetField";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempfieldSetField exists before attemptintg to delete
                    if (tempFieldSetField != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteFieldSetFieldMethod = FieldSetFieldMethods.DeleteFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(tempFieldSetField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteFieldSetFieldMethod, parameters, dataManager);

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

            #region FetchAll(FieldSetField tempFieldSetField, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'FieldSetField' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FieldSetField_FetchAll'.</summary>
            /// <param name='tempFieldSetField'>A temporary FieldSetField for passing values.</param>
            /// <returns>A collection of 'FieldSetField' objects.</returns>
            public static List<FieldSetField> FetchAll(FieldSetField tempFieldSetField, DataManager dataManager)
            {
                // Initial value
                List<FieldSetField> fieldSetFieldList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = FieldSetFieldMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(tempFieldSetField);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FieldSetField> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        fieldSetFieldList = (List<FieldSetField>) returnObject.ObjectValue;
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
                return fieldSetFieldList;
            }
            #endregion

            #region Find(FieldSetField tempFieldSetField, DataManager dataManager)
            /// <summary>
            /// Finds a 'FieldSetField' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'FieldSetField_Find'</param>
            /// </summary>
            /// <param name='tempFieldSetField'>A temporary FieldSetField for passing values.</param>
            /// <returns>A 'FieldSetField' object if found else a null 'FieldSetField'.</returns>
            public static FieldSetField Find(FieldSetField tempFieldSetField, DataManager dataManager)
            {
                // Initial values
                FieldSetField fieldSetField = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempFieldSetField != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = FieldSetFieldMethods.FindFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(tempFieldSetField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as FieldSetField != null))
                        {
                            // Get ReturnObject
                            fieldSetField = (FieldSetField) returnObject.ObjectValue;
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
                return fieldSetField;
            }
            #endregion

            #region Insert(FieldSetField fieldSetField, DataManager dataManager)
            /// <summary>
            /// Insert a 'FieldSetField' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'FieldSetField_Insert'.</param>
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to insert.</param>
            /// <returns>The id (int) of the new  'FieldSetField' object that was inserted.</returns>
            public static int Insert(FieldSetField fieldSetField, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If FieldSetFieldexists
                    if (fieldSetField != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = FieldSetFieldMethods.InsertFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(fieldSetField);

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

            #region Save(ref FieldSetField fieldSetField, DataManager dataManager)
            /// <summary>
            /// Saves a 'FieldSetField' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref FieldSetField fieldSetField, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the fieldSetField exists.
                if (fieldSetField != null)
                {
                    // Is this a new FieldSetField
                    if (fieldSetField.IsNew)
                    {
                        // Insert new FieldSetField
                        int newIdentity = Insert(fieldSetField, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            fieldSetField.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update FieldSetField
                        saved = Update(fieldSetField, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(FieldSetField fieldSetField, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'FieldSetField' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'FieldSetField_Update'.</param>
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(FieldSetField fieldSetField, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (fieldSetField != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = FieldSetFieldMethods.UpdateFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(fieldSetField);
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
