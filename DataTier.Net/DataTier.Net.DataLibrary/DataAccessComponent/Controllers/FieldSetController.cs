

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

    #region class FieldSetController
    /// <summary>
    /// This class controls a(n) 'FieldSet' object.
    /// </summary>
    public class FieldSetController
    {

        #region Methods

            #region CreateFieldSetParameter
            /// <summary>
            /// This method creates the parameter for a 'FieldSet' data operation.
            /// </summary>
            /// <param name='fieldset'>The 'FieldSet' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateFieldSetParameter(FieldSet fieldSet)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = fieldSet;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(FieldSet tempFieldSet, DataManager dataManager)
            /// <summary>
            /// Deletes a 'FieldSet' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'FieldSet_Delete'.
            /// </summary>
            /// <param name='fieldset'>The 'FieldSet' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static PolymorphicObject Delete(FieldSet tempFieldSet, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteFieldSet";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempfieldSet exists before attemptintg to delete
                    if (tempFieldSet != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteFieldSetMethod = FieldSetMethods.DeleteFieldSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetParameter(tempFieldSet);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteFieldSetMethod, parameters, dataManager);
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

            #region FetchAll(FieldSet tempFieldSet, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'FieldSet' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FieldSet_FetchAll'.</summary>
            /// <param name='tempFieldSet'>A temporary FieldSet for passing values.</param>
            /// <returns>A collection of 'FieldSet' objects.</returns>
            public static List<FieldSet> FetchAll(FieldSet tempFieldSet, DataManager dataManager)
            {
                // Initial value
                List<FieldSet> fieldSetList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = FieldSetMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFieldSetParameter(tempFieldSet);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FieldSet> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        fieldSetList = (List<FieldSet>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return fieldSetList;
            }
            #endregion

            #region Find(FieldSet tempFieldSet, DataManager dataManager)
            /// <summary>
            /// Finds a 'FieldSet' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'FieldSet_Find'</param>
            /// </summary>
            /// <param name='tempFieldSet'>A temporary FieldSet for passing values.</param>
            /// <returns>A 'FieldSet' object if found else a null 'FieldSet'.</returns>
            public static FieldSet Find(FieldSet tempFieldSet, DataManager dataManager)
            {
                // Initial values
                FieldSet fieldSet = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempFieldSet != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = FieldSetMethods.FindFieldSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetParameter(tempFieldSet);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as FieldSet != null))
                        {
                            // Get ReturnObject
                            fieldSet = (FieldSet) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return fieldSet;
            }
            #endregion

            #region Insert(FieldSet fieldSet, DataManager dataManager)
            /// <summary>
            /// Insert a 'FieldSet' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'FieldSet_Insert'.</param>
            /// </summary>
            /// <param name='fieldSet'>The 'FieldSet' object to insert.</param>
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'FieldSet' object that was inserted.</returns>
            public static PolymorphicObject Insert(FieldSet fieldSet, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If FieldSetexists
                    if (fieldSet != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = FieldSetMethods.InsertFieldSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetParameter(fieldSet);

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

            #region Save(ref FieldSet fieldSet, DataManager dataManager)
            /// <summary>
            /// Saves a 'FieldSet' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='fieldSet'>The 'FieldSet' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref FieldSet fieldSet, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the fieldSet exists.
                if (fieldSet != null)
                {
                    // Is this a new FieldSet
                    if (fieldSet.IsNew)
                    {
                        // Insert new FieldSet
                        result = Insert(fieldSet, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            fieldSet.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update FieldSet
                        result  = Update(fieldSet, dataManager);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region Update(FieldSet fieldSet, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'FieldSet' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'FieldSet_Update'.</param>
            /// </summary>
            /// <param name='fieldSet'>The 'FieldSet' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static PolymorphicObject Update(FieldSet fieldSet, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (fieldSet != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = FieldSetMethods.UpdateFieldSet;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetParameter(fieldSet);
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
