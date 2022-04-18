

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class UIObjectController
    /// <summary>
    /// This class controls a(n) 'UIObject' object.
    /// </summary>
    public class UIObjectController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'UIObjectController' object.
        /// </summary>
        public UIObjectController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateUIObjectParameter
            /// <summary>
            /// This method creates the parameter for a 'UIObject' data operation.
            /// </summary>
            /// <param name='uiobject'>The 'UIObject' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateUIObjectParameter(UIObject uIObject)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = uIObject;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(UIObject tempUIObject)
            /// <summary>
            /// Deletes a 'UIObject' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'UIObject_Delete'.
            /// </summary>
            /// <param name='uiobject'>The 'UIObject' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(UIObject tempUIObject)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteUIObject";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempuIObject exists before attemptintg to delete
                    if(tempUIObject != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteUIObjectMethod = this.AppController.DataBridge.DataOperations.UIObjectMethods.DeleteUIObject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIObjectParameter(tempUIObject);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteUIObjectMethod, parameters);

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

            #region FetchAll(UIObject tempUIObject)
            /// <summary>
            /// This method fetches a collection of 'UIObject' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'UIObject_FetchAll'.</summary>
            /// <param name='tempUIObject'>A temporary UIObject for passing values.</param>
            /// <returns>A collection of 'UIObject' objects.</returns>
            public List<UIObject> FetchAll(UIObject tempUIObject)
            {
                // Initial value
                List<UIObject> uIObjectList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.UIObjectMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateUIObjectParameter(tempUIObject);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<UIObject> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        uIObjectList = (List<UIObject>) returnObject.ObjectValue;
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
                return uIObjectList;
            }
            #endregion

            #region Find(UIObject tempUIObject)
            /// <summary>
            /// Finds a 'UIObject' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'UIObject_Find'</param>
            /// </summary>
            /// <param name='tempUIObject'>A temporary UIObject for passing values.</param>
            /// <returns>A 'UIObject' object if found else a null 'UIObject'.</returns>
            public UIObject Find(UIObject tempUIObject)
            {
                // Initial values
                UIObject uIObject = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempUIObject != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.UIObjectMethods.FindUIObject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIObjectParameter(tempUIObject);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as UIObject != null))
                        {
                            // Get ReturnObject
                            uIObject = (UIObject) returnObject.ObjectValue;
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
                return uIObject;
            }
            #endregion

            #region Insert(UIObject uIObject)
            /// <summary>
            /// Insert a 'UIObject' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'UIObject_Insert'.</param>
            /// </summary>
            /// <param name='uIObject'>The 'UIObject' object to insert.</param>
            /// <returns>The id (int) of the new  'UIObject' object that was inserted.</returns>
            public int Insert(UIObject uIObject)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If UIObjectexists
                    if(uIObject != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.UIObjectMethods.InsertUIObject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIObjectParameter(uIObject);

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

            #region Save(ref UIObject uIObject)
            /// <summary>
            /// Saves a 'UIObject' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='uIObject'>The 'UIObject' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref UIObject uIObject)
            {
                // Initial value
                bool saved = false;

                // If the uIObject exists.
                if(uIObject != null)
                {
                    // Is this a new UIObject
                    if(uIObject.IsNew)
                    {
                        // Insert new UIObject
                        int newIdentity = this.Insert(uIObject);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            uIObject.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update UIObject
                        saved = this.Update(uIObject);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(UIObject uIObject)
            /// <summary>
            /// This method Updates a 'UIObject' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'UIObject_Update'.</param>
            /// </summary>
            /// <param name='uIObject'>The 'UIObject' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(UIObject uIObject)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(uIObject != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.UIObjectMethods.UpdateUIObject;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUIObjectParameter(uIObject);
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
