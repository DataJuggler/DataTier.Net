

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
            public static PolymorphicObject Delete(FieldSetField tempFieldSetField, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

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
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteFieldSetFieldMethod, parameters, dataManager);
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
                    ErrorHandler.LogError(methodName, objectName, error);
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
                    ErrorHandler.LogError(methodName, objectName, error);
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
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'FieldSetField' object that was inserted.</returns>
            public static PolymorphicObject Insert(FieldSetField fieldSetField, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If FieldSetFieldexists
                    if (fieldSetField != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = FieldSetFieldMethods.InsertFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(fieldSetField);

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

            #region Save(ref FieldSetField fieldSetField, DataManager dataManager)
            /// <summary>
            /// Saves a 'FieldSetField' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref FieldSetField fieldSetField, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the fieldSetField exists.
                if (fieldSetField != null)
                {
                    // Is this a new FieldSetField
                    if (fieldSetField.IsNew)
                    {
                        // Insert new FieldSetField
                        result = Insert(fieldSetField, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            fieldSetField.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update FieldSetField
                        result  = Update(fieldSetField, dataManager);
                    }
                }

                // return value
                return result;
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
            public static PolymorphicObject Update(FieldSetField fieldSetField, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

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
