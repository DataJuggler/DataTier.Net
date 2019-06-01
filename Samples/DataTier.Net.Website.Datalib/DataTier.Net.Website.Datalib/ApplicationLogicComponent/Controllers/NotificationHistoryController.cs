

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

    #region class NotificationHistoryController
    /// <summary>
    /// This class controls a(n) 'NotificationHistory' object.
    /// </summary>
    public class NotificationHistoryController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'NotificationHistoryController' object.
        /// </summary>
        public NotificationHistoryController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateNotificationHistoryParameter
            /// <summary>
            /// This method creates the parameter for a 'NotificationHistory' data operation.
            /// </summary>
            /// <param name='notificationhistory'>The 'NotificationHistory' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateNotificationHistoryParameter(NotificationHistory notificationHistory)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = notificationHistory;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(NotificationHistory tempNotificationHistory)
            /// <summary>
            /// Deletes a 'NotificationHistory' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'NotificationHistory_Delete'.
            /// </summary>
            /// <param name='notificationhistory'>The 'NotificationHistory' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(NotificationHistory tempNotificationHistory)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteNotificationHistory";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempnotificationHistory exists before attemptintg to delete
                    if(tempNotificationHistory != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteNotificationHistoryMethod = this.AppController.DataBridge.DataOperations.NotificationHistoryMethods.DeleteNotificationHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationHistoryParameter(tempNotificationHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteNotificationHistoryMethod, parameters);

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

            #region FetchAll(NotificationHistory tempNotificationHistory)
            /// <summary>
            /// This method fetches a collection of 'NotificationHistory' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'NotificationHistory_FetchAll'.</summary>
            /// <param name='tempNotificationHistory'>A temporary NotificationHistory for passing values.</param>
            /// <returns>A collection of 'NotificationHistory' objects.</returns>
            public List<NotificationHistory> FetchAll(NotificationHistory tempNotificationHistory)
            {
                // Initial value
                List<NotificationHistory> notificationHistoryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.NotificationHistoryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateNotificationHistoryParameter(tempNotificationHistory);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<NotificationHistory> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        notificationHistoryList = (List<NotificationHistory>) returnObject.ObjectValue;
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
                return notificationHistoryList;
            }
            #endregion

            #region Find(NotificationHistory tempNotificationHistory)
            /// <summary>
            /// Finds a 'NotificationHistory' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'NotificationHistory_Find'</param>
            /// </summary>
            /// <param name='tempNotificationHistory'>A temporary NotificationHistory for passing values.</param>
            /// <returns>A 'NotificationHistory' object if found else a null 'NotificationHistory'.</returns>
            public NotificationHistory Find(NotificationHistory tempNotificationHistory)
            {
                // Initial values
                NotificationHistory notificationHistory = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempNotificationHistory != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.NotificationHistoryMethods.FindNotificationHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationHistoryParameter(tempNotificationHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as NotificationHistory != null))
                        {
                            // Get ReturnObject
                            notificationHistory = (NotificationHistory) returnObject.ObjectValue;
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
                return notificationHistory;
            }
            #endregion

            #region Insert(NotificationHistory notificationHistory)
            /// <summary>
            /// Insert a 'NotificationHistory' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'NotificationHistory_Insert'.</param>
            /// </summary>
            /// <param name='notificationHistory'>The 'NotificationHistory' object to insert.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Insert(NotificationHistory notificationHistory)
            {
                // Initial values
                bool inserted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If NotificationHistoryexists
                    if(notificationHistory != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.NotificationHistoryMethods.InsertNotificationHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationHistoryParameter(notificationHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // Set the return value to true
                        inserted = true;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Set inserted to false
                        inserted = false;
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return inserted;
            }
            #endregion

            #region Save(ref NotificationHistory notificationHistory)
            /// <summary>
            /// Saves a 'NotificationHistory' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='notificationHistory'>The 'NotificationHistory' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref NotificationHistory notificationHistory)
            {
                // Initial value
                bool saved = false;

                // If the notificationHistory exists.
                if(notificationHistory != null)
                {
                    // Since this is not an Autonumber field, we must attempt to look up this item before we decide to Insert or Update

                    // Look up this item to see if it already exists
                    NotificationHistory tempNotificationHistory = this.Find(notificationHistory);

                    // Is this a new object ?
                    bool isNew = (tempNotificationHistory == null);

                    // If this is a new object
                    if (isNew)
                    {
                        // Perform the insert
                        saved = this.Insert(notificationHistory);
                    }
                    else
                    {
                        // Perform the update
                        saved = this.Update(notificationHistory);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(NotificationHistory notificationHistory)
            /// <summary>
            /// This method Updates a 'NotificationHistory' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'NotificationHistory_Update'.</param>
            /// </summary>
            /// <param name='notificationHistory'>The 'NotificationHistory' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(NotificationHistory notificationHistory)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(notificationHistory != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.NotificationHistoryMethods.UpdateNotificationHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationHistoryParameter(notificationHistory);
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
