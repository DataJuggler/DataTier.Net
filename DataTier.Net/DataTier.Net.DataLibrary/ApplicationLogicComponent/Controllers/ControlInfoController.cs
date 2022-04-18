

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

    #region class ControlInfoController
    /// <summary>
    /// This class controls a(n) 'ControlInfo' object.
    /// </summary>
    public class ControlInfoController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ControlInfoController' object.
        /// </summary>
        public ControlInfoController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateControlInfoParameter
            /// <summary>
            /// This method creates the parameter for a 'ControlInfo' data operation.
            /// </summary>
            /// <param name='controlinfo'>The 'ControlInfo' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateControlInfoParameter(ControlInfo controlInfo)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = controlInfo;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ControlInfo tempControlInfo)
            /// <summary>
            /// Deletes a 'ControlInfo' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ControlInfo_Delete'.
            /// </summary>
            /// <param name='controlinfo'>The 'ControlInfo' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ControlInfo tempControlInfo)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteControlInfo";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempcontrolInfo exists before attemptintg to delete
                    if(tempControlInfo != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteControlInfoMethod = this.AppController.DataBridge.DataOperations.ControlInfoMethods.DeleteControlInfo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoParameter(tempControlInfo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteControlInfoMethod, parameters);

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

            #region FetchAll(ControlInfo tempControlInfo)
            /// <summary>
            /// This method fetches a collection of 'ControlInfo' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ControlInfo_FetchAll'.</summary>
            /// <param name='tempControlInfo'>A temporary ControlInfo for passing values.</param>
            /// <returns>A collection of 'ControlInfo' objects.</returns>
            public List<ControlInfo> FetchAll(ControlInfo tempControlInfo)
            {
                // Initial value
                List<ControlInfo> controlInfoList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ControlInfoMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateControlInfoParameter(tempControlInfo);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ControlInfo> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        controlInfoList = (List<ControlInfo>) returnObject.ObjectValue;
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
                return controlInfoList;
            }
            #endregion

            #region Find(ControlInfo tempControlInfo)
            /// <summary>
            /// Finds a 'ControlInfo' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ControlInfo_Find'</param>
            /// </summary>
            /// <param name='tempControlInfo'>A temporary ControlInfo for passing values.</param>
            /// <returns>A 'ControlInfo' object if found else a null 'ControlInfo'.</returns>
            public ControlInfo Find(ControlInfo tempControlInfo)
            {
                // Initial values
                ControlInfo controlInfo = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempControlInfo != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ControlInfoMethods.FindControlInfo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoParameter(tempControlInfo);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ControlInfo != null))
                        {
                            // Get ReturnObject
                            controlInfo = (ControlInfo) returnObject.ObjectValue;
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
                return controlInfo;
            }
            #endregion

            #region Insert(ControlInfo controlInfo)
            /// <summary>
            /// Insert a 'ControlInfo' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ControlInfo_Insert'.</param>
            /// </summary>
            /// <param name='controlInfo'>The 'ControlInfo' object to insert.</param>
            /// <returns>The id (int) of the new  'ControlInfo' object that was inserted.</returns>
            public int Insert(ControlInfo controlInfo)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ControlInfoexists
                    if(controlInfo != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ControlInfoMethods.InsertControlInfo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoParameter(controlInfo);

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

            #region Save(ref ControlInfo controlInfo)
            /// <summary>
            /// Saves a 'ControlInfo' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='controlInfo'>The 'ControlInfo' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ControlInfo controlInfo)
            {
                // Initial value
                bool saved = false;

                // If the controlInfo exists.
                if(controlInfo != null)
                {
                    // Is this a new ControlInfo
                    if(controlInfo.IsNew)
                    {
                        // Insert new ControlInfo
                        int newIdentity = this.Insert(controlInfo);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            controlInfo.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ControlInfo
                        saved = this.Update(controlInfo);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ControlInfo controlInfo)
            /// <summary>
            /// This method Updates a 'ControlInfo' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ControlInfo_Update'.</param>
            /// </summary>
            /// <param name='controlInfo'>The 'ControlInfo' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ControlInfo controlInfo)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(controlInfo != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ControlInfoMethods.UpdateControlInfo;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoParameter(controlInfo);
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
