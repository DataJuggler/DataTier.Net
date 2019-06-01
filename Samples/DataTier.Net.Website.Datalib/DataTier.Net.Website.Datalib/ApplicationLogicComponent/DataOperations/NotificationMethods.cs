

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class NotificationMethods
    /// <summary>
    /// This class contains methods for modifying a 'Notification' object.
    /// </summary>
    public class NotificationMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'NotificationMethods' object.
        /// </summary>
        public NotificationMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteNotification(Notification)
            /// <summary>
            /// This method deletes a 'Notification' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Notification' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteNotification(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteNotificationStoredProcedure deleteNotificationProc = null;

                    // verify the first parameters is a(n) 'Notification'.
                    if (parameters[0].ObjectValue as Notification != null)
                    {
                        // Create Notification
                        Notification notification = (Notification) parameters[0].ObjectValue;

                        // verify notification exists
                        if(notification != null)
                        {
                            // Now create deleteNotificationProc from NotificationWriter
                            // The DataWriter converts the 'Notification'
                            // to the SqlParameter[] array needed to delete a 'Notification'.
                            deleteNotificationProc = NotificationWriter.CreateDeleteNotificationStoredProcedure(notification);
                        }
                    }

                    // Verify deleteNotificationProc exists
                    if(deleteNotificationProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.NotificationManager.DeleteNotification(deleteNotificationProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Notification' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Notification' to delete.
            /// <returns>A PolymorphicObject object with all  'Notifications' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Notification> notificationListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllNotificationsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get NotificationParameter
                    // Declare Parameter
                    Notification paramNotification = null;

                    // verify the first parameters is a(n) 'Notification'.
                    if (parameters[0].ObjectValue as Notification != null)
                    {
                        // Get NotificationParameter
                        paramNotification = (Notification) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllNotificationsProc from NotificationWriter
                    fetchAllProc = NotificationWriter.CreateFetchAllNotificationsStoredProcedure(paramNotification);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    notificationListCollection = this.DataManager.NotificationManager.FetchAllNotifications(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(notificationListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = notificationListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindNotification(Notification)
            /// <summary>
            /// This method finds a 'Notification' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Notification' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindNotification(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Notification notification = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindNotificationStoredProcedure findNotificationProc = null;

                    // verify the first parameters is a 'Notification'.
                    if (parameters[0].ObjectValue as Notification != null)
                    {
                        // Get NotificationParameter
                        Notification paramNotification = (Notification) parameters[0].ObjectValue;

                        // verify paramNotification exists
                        if(paramNotification != null)
                        {
                            // Now create findNotificationProc from NotificationWriter
                            // The DataWriter converts the 'Notification'
                            // to the SqlParameter[] array needed to find a 'Notification'.
                            findNotificationProc = NotificationWriter.CreateFindNotificationStoredProcedure(paramNotification);
                        }

                        // Verify findNotificationProc exists
                        if(findNotificationProc != null)
                        {
                            // Execute Find Stored Procedure
                            notification = this.DataManager.NotificationManager.FindNotification(findNotificationProc, dataConnector);

                            // if dataObject exists
                            if(notification != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = notification;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertNotification (Notification)
            /// <summary>
            /// This method inserts a 'Notification' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Notification' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertNotification(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Notification notification = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertNotificationStoredProcedure insertNotificationProc = null;

                    // verify the first parameters is a(n) 'Notification'.
                    if (parameters[0].ObjectValue as Notification != null)
                    {
                        // Create Notification Parameter
                        notification = (Notification) parameters[0].ObjectValue;

                        // verify notification exists
                        if(notification != null)
                        {
                            // Now create insertNotificationProc from NotificationWriter
                            // The DataWriter converts the 'Notification'
                            // to the SqlParameter[] array needed to insert a 'Notification'.
                            insertNotificationProc = NotificationWriter.CreateInsertNotificationStoredProcedure(notification);
                        }

                        // Verify insertNotificationProc exists
                        if(insertNotificationProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.NotificationManager.InsertNotification(insertNotificationProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateNotification (Notification)
            /// <summary>
            /// This method updates a 'Notification' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Notification' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateNotification(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Notification notification = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateNotificationStoredProcedure updateNotificationProc = null;

                    // verify the first parameters is a(n) 'Notification'.
                    if (parameters[0].ObjectValue as Notification != null)
                    {
                        // Create Notification Parameter
                        notification = (Notification) parameters[0].ObjectValue;

                        // verify notification exists
                        if(notification != null)
                        {
                            // Now create updateNotificationProc from NotificationWriter
                            // The DataWriter converts the 'Notification'
                            // to the SqlParameter[] array needed to update a 'Notification'.
                            updateNotificationProc = NotificationWriter.CreateUpdateNotificationStoredProcedure(notification);
                        }

                        // Verify updateNotificationProc exists
                        if(updateNotificationProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.NotificationManager.UpdateNotification(updateNotificationProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
