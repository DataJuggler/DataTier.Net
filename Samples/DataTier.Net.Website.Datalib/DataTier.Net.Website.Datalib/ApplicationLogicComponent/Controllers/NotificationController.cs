

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

    #region class NotificationController
    /// <summary>
    /// This class controls a(n) 'Notification' object.
    /// </summary>
    public class NotificationController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'NotificationController' object.
        /// </summary>
        public NotificationController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateNotificationParameter
            /// <summary>
            /// This method creates the parameter for a 'Notification' data operation.
            /// </summary>
            /// <param name='notification'>The 'Notification' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateNotificationParameter(Notification notification)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = notification;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Notification tempNotification)
            /// <summary>
            /// Deletes a 'Notification' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Notification_Delete'.
            /// </summary>
            /// <param name='notification'>The 'Notification' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Notification tempNotification)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteNotification";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempnotification exists before attemptintg to delete
                    if(tempNotification != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteNotificationMethod = this.AppController.DataBridge.DataOperations.NotificationMethods.DeleteNotification;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationParameter(tempNotification);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteNotificationMethod, parameters);

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

            #region FetchAll(Notification tempNotification)
            /// <summary>
            /// This method fetches a collection of 'Notification' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Notification_FetchAll'.</summary>
            /// <param name='tempNotification'>A temporary Notification for passing values.</param>
            /// <returns>A collection of 'Notification' objects.</returns>
            public List<Notification> FetchAll(Notification tempNotification)
            {
                // Initial value
                List<Notification> notificationList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.NotificationMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateNotificationParameter(tempNotification);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Notification> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        notificationList = (List<Notification>) returnObject.ObjectValue;
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
                return notificationList;
            }
            #endregion

            #region Find(Notification tempNotification)
            /// <summary>
            /// Finds a 'Notification' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Notification_Find'</param>
            /// </summary>
            /// <param name='tempNotification'>A temporary Notification for passing values.</param>
            /// <returns>A 'Notification' object if found else a null 'Notification'.</returns>
            public Notification Find(Notification tempNotification)
            {
                // Initial values
                Notification notification = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempNotification != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.NotificationMethods.FindNotification;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationParameter(tempNotification);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Notification != null))
                        {
                            // Get ReturnObject
                            notification = (Notification) returnObject.ObjectValue;
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
                return notification;
            }
            #endregion

            #region Insert(Notification notification)
            /// <summary>
            /// Insert a 'Notification' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Notification_Insert'.</param>
            /// </summary>
            /// <param name='notification'>The 'Notification' object to insert.</param>
            /// <returns>The id (int) of the new  'Notification' object that was inserted.</returns>
            public int Insert(Notification notification)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Notificationexists
                    if(notification != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.NotificationMethods.InsertNotification;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationParameter(notification);

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

            #region Save(ref Notification notification)
            /// <summary>
            /// Saves a 'Notification' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='notification'>The 'Notification' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Notification notification)
            {
                // Initial value
                bool saved = false;

                // If the notification exists.
                if(notification != null)
                {
                    // Is this a new Notification
                    if(notification.IsNew)
                    {
                        // Insert new Notification
                        int newIdentity = this.Insert(notification);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            notification.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Notification
                        saved = this.Update(notification);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Notification notification)
            /// <summary>
            /// This method Updates a 'Notification' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Notification_Update'.</param>
            /// </summary>
            /// <param name='notification'>The 'Notification' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Notification notification)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(notification != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.NotificationMethods.UpdateNotification;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateNotificationParameter(notification);
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
