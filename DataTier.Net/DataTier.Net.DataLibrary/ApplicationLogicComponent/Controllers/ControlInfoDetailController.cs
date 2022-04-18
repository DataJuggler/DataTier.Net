

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

    #region class ControlInfoDetailController
    /// <summary>
    /// This class controls a(n) 'ControlInfoDetail' object.
    /// </summary>
    public class ControlInfoDetailController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ControlInfoDetailController' object.
        /// </summary>
        public ControlInfoDetailController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateControlInfoDetailParameter
            /// <summary>
            /// This method creates the parameter for a 'ControlInfoDetail' data operation.
            /// </summary>
            /// <param name='controlinfodetail'>The 'ControlInfoDetail' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateControlInfoDetailParameter(ControlInfoDetail controlInfoDetail)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = controlInfoDetail;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ControlInfoDetail tempControlInfoDetail)
            /// <summary>
            /// Deletes a 'ControlInfoDetail' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ControlInfoDetail_Delete'.
            /// </summary>
            /// <param name='controlinfodetail'>The 'ControlInfoDetail' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ControlInfoDetail tempControlInfoDetail)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteControlInfoDetail";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempcontrolInfoDetail exists before attemptintg to delete
                    if(tempControlInfoDetail != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteControlInfoDetailMethod = this.AppController.DataBridge.DataOperations.ControlInfoDetailMethods.DeleteControlInfoDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoDetailParameter(tempControlInfoDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteControlInfoDetailMethod, parameters);

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

            #region FetchAll(ControlInfoDetail tempControlInfoDetail)
            /// <summary>
            /// This method fetches a collection of 'ControlInfoDetail' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ControlInfoDetail_FetchAll'.</summary>
            /// <param name='tempControlInfoDetail'>A temporary ControlInfoDetail for passing values.</param>
            /// <returns>A collection of 'ControlInfoDetail' objects.</returns>
            public List<ControlInfoDetail> FetchAll(ControlInfoDetail tempControlInfoDetail)
            {
                // Initial value
                List<ControlInfoDetail> controlInfoDetailList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ControlInfoDetailMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateControlInfoDetailParameter(tempControlInfoDetail);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ControlInfoDetail> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        controlInfoDetailList = (List<ControlInfoDetail>) returnObject.ObjectValue;
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
                return controlInfoDetailList;
            }
            #endregion

            #region Find(ControlInfoDetail tempControlInfoDetail)
            /// <summary>
            /// Finds a 'ControlInfoDetail' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ControlInfoDetail_Find'</param>
            /// </summary>
            /// <param name='tempControlInfoDetail'>A temporary ControlInfoDetail for passing values.</param>
            /// <returns>A 'ControlInfoDetail' object if found else a null 'ControlInfoDetail'.</returns>
            public ControlInfoDetail Find(ControlInfoDetail tempControlInfoDetail)
            {
                // Initial values
                ControlInfoDetail controlInfoDetail = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempControlInfoDetail != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ControlInfoDetailMethods.FindControlInfoDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoDetailParameter(tempControlInfoDetail);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ControlInfoDetail != null))
                        {
                            // Get ReturnObject
                            controlInfoDetail = (ControlInfoDetail) returnObject.ObjectValue;
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
                return controlInfoDetail;
            }
            #endregion

            #region Insert(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// Insert a 'ControlInfoDetail' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ControlInfoDetail_Insert'.</param>
            /// </summary>
            /// <param name='controlInfoDetail'>The 'ControlInfoDetail' object to insert.</param>
            /// <returns>The id (int) of the new  'ControlInfoDetail' object that was inserted.</returns>
            public int Insert(ControlInfoDetail controlInfoDetail)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ControlInfoDetailexists
                    if(controlInfoDetail != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ControlInfoDetailMethods.InsertControlInfoDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoDetailParameter(controlInfoDetail);

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

            #region Save(ref ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// Saves a 'ControlInfoDetail' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='controlInfoDetail'>The 'ControlInfoDetail' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ControlInfoDetail controlInfoDetail)
            {
                // Initial value
                bool saved = false;

                // If the controlInfoDetail exists.
                if(controlInfoDetail != null)
                {
                    // Is this a new ControlInfoDetail
                    if(controlInfoDetail.IsNew)
                    {
                        // Insert new ControlInfoDetail
                        int newIdentity = this.Insert(controlInfoDetail);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            controlInfoDetail.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ControlInfoDetail
                        saved = this.Update(controlInfoDetail);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method Updates a 'ControlInfoDetail' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ControlInfoDetail_Update'.</param>
            /// </summary>
            /// <param name='controlInfoDetail'>The 'ControlInfoDetail' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ControlInfoDetail controlInfoDetail)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(controlInfoDetail != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ControlInfoDetailMethods.UpdateControlInfoDetail;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateControlInfoDetailParameter(controlInfoDetail);
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
