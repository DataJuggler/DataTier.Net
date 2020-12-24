

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using DataJuggler.Net.Enumerations;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class UIFieldController
    /// <summary>
    /// This class controls a(n) 'UIField' object.
    /// </summary>
    public class UIFieldController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'UIFieldController' object.
        /// </summary>
        public UIFieldController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateUIFieldParameter
            /// <summary>
            /// This method creates the parameter for a 'UIField' data operation.
            /// </summary>
            /// <param name='uifield'>The 'UIField' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateUIFieldParameter(UIField uIField)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = uIField;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(UIField tempUIField)
            /// <summary>
            /// Deletes a 'UIField' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'UIField_Delete'.
            /// </summary>
            /// <param name='uifield'>The 'UIField' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(UIField tempUIField)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteUIField";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempuIField exists before attemptintg to delete
                    if(tempUIField != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteUIFieldMethod = this.AppController.DataBridge.DataOperations.UIFieldMethods.DeleteUIField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIFieldParameter(tempUIField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteUIFieldMethod, parameters);

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

            #region FetchAll(UIField tempUIField)
            /// <summary>
            /// This method fetches a collection of 'UIField' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'UIField_FetchAll'.</summary>
            /// <param name='tempUIField'>A temporary UIField for passing values.</param>
            /// <returns>A collection of 'UIField' objects.</returns>
            public List<UIField> FetchAll(UIField tempUIField)
            {
                // Initial value
                List<UIField> uIFieldList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.UIFieldMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateUIFieldParameter(tempUIField);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<UIField> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        uIFieldList = (List<UIField>) returnObject.ObjectValue;
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
                return uIFieldList;
            }
            #endregion

            #region Find(UIField tempUIField)
            /// <summary>
            /// Finds a 'UIField' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'UIField_Find'</param>
            /// </summary>
            /// <param name='tempUIField'>A temporary UIField for passing values.</param>
            /// <returns>A 'UIField' object if found else a null 'UIField'.</returns>
            public UIField Find(UIField tempUIField)
            {
                // Initial values
                UIField uIField = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempUIField != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.UIFieldMethods.FindUIField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIFieldParameter(tempUIField);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as UIField != null))
                        {
                            // Get ReturnObject
                            uIField = (UIField) returnObject.ObjectValue;
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
                return uIField;
            }
            #endregion

            #region Insert(UIField uIField)
            /// <summary>
            /// Insert a 'UIField' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'UIField_Insert'.</param>
            /// </summary>
            /// <param name='uIField'>The 'UIField' object to insert.</param>
            /// <returns>The id (int) of the new  'UIField' object that was inserted.</returns>
            public int Insert(UIField uIField)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If UIFieldexists
                    if(uIField != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.UIFieldMethods.InsertUIField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIFieldParameter(uIField);

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

            #region Save(ref UIField uIField)
            /// <summary>
            /// Saves a 'UIField' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='uIField'>The 'UIField' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref UIField uIField)
            {
                // Initial value
                bool saved = false;

                // If the uIField exists.
                if(uIField != null)
                {
                    // Is this a new UIField
                    if(uIField.IsNew)
                    {
                        // Insert new UIField
                        int newIdentity = this.Insert(uIField);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            uIField.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update UIField
                        saved = this.Update(uIField);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(UIField uIField)
            /// <summary>
            /// This method Updates a 'UIField' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'UIField_Update'.</param>
            /// </summary>
            /// <param name='uIField'>The 'UIField' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(UIField uIField)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(uIField != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.UIFieldMethods.UpdateUIField;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIFieldParameter(uIField);
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
