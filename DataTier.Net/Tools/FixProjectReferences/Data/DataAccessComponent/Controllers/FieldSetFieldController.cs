

#region using statements

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

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'FieldSetFieldController' object.
        /// </summary>
        public FieldSetFieldController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region Delete(FieldSetField tempFieldSetField)
            /// <summary>
            /// Deletes a 'FieldSetField' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'FieldSetField_Delete'.
            /// </summary>
            /// <param name='fieldsetfield'>The 'FieldSetField' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(FieldSetField tempFieldSetField)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteFieldSetField";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempfieldSetField exists before attemptintg to delete
                    if(tempFieldSetField != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteFieldSetFieldMethod = this.AppController.DataBridge.DataOperations.FieldSetFieldMethods.DeleteFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(tempFieldSetField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteFieldSetFieldMethod, parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(FieldSetField tempFieldSetField)
            /// <summary>
            /// This method fetches a collection of 'FieldSetField' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FieldSetField_FetchAll'.</summary>
            /// <param name='tempFieldSetField'>A temporary FieldSetField for passing values.</param>
            /// <returns>A collection of 'FieldSetField' objects.</returns>
            public List<FieldSetField> FetchAll(FieldSetField tempFieldSetField)
            {
                // Initial value
                List<FieldSetField> fieldSetFieldList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.FieldSetFieldMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(tempFieldSetField);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FieldSetField> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        fieldSetFieldList = (List<FieldSetField>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return fieldSetFieldList;
            }
            #endregion

            #region Find(FieldSetField tempFieldSetField)
            /// <summary>
            /// Finds a 'FieldSetField' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'FieldSetField_Find'</param>
            /// </summary>
            /// <param name='tempFieldSetField'>A temporary FieldSetField for passing values.</param>
            /// <returns>A 'FieldSetField' object if found else a null 'FieldSetField'.</returns>
            public FieldSetField Find(FieldSetField tempFieldSetField)
            {
                // Initial values
                FieldSetField fieldSetField = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempFieldSetField != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.FieldSetFieldMethods.FindFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(tempFieldSetField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return fieldSetField;
            }
            #endregion

            #region Insert(FieldSetField fieldSetField)
            /// <summary>
            /// Insert a 'FieldSetField' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'FieldSetField_Insert'.</param>
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to insert.</param>
            /// <returns>The id (int) of the new  'FieldSetField' object that was inserted.</returns>
            public int Insert(FieldSetField fieldSetField)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If FieldSetFieldexists
                    if(fieldSetField != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.FieldSetFieldMethods.InsertFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(fieldSetField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref FieldSetField fieldSetField)
            /// <summary>
            /// Saves a 'FieldSetField' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref FieldSetField fieldSetField)
            {
                // Initial value
                bool saved = false;

                // If the fieldSetField exists.
                if(fieldSetField != null)
                {
                    // Is this a new FieldSetField
                    if(fieldSetField.IsNew)
                    {
                        // Insert new FieldSetField
                        int newIdentity = this.Insert(fieldSetField);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(fieldSetField);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(FieldSetField fieldSetField)
            /// <summary>
            /// This method Updates a 'FieldSetField' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'FieldSetField_Update'.</param>
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(FieldSetField fieldSetField)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(fieldSetField != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.FieldSetFieldMethods.UpdateFieldSetField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFieldSetFieldParameter(fieldSetField);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
