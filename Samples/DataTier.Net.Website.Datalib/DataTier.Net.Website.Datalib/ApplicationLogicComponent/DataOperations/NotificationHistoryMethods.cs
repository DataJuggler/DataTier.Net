

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

    #region class NotificationHistoryMethods
    /// <summary>
    /// This class contains methods for modifying a 'NotificationHistory' object.
    /// </summary>
    public class NotificationHistoryMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'NotificationHistoryMethods' object.
        /// </summary>
        public NotificationHistoryMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteNotificationHistory(NotificationHistory)
            /// <summary>
            /// This method deletes a 'NotificationHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'NotificationHistory' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteNotificationHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteNotificationHistoryStoredProcedure deleteNotificationHistoryProc = null;

                    // verify the first parameters is a(n) 'NotificationHistory'.
                    if (parameters[0].ObjectValue as NotificationHistory != null)
                    {
                        // Create NotificationHistory
                        NotificationHistory notificationHistory = (NotificationHistory) parameters[0].ObjectValue;

                        // verify notificationHistory exists
                        if(notificationHistory != null)
                        {
                            // Now create deleteNotificationHistoryProc from NotificationHistoryWriter
                            // The DataWriter converts the 'NotificationHistory'
                            // to the SqlParameter[] array needed to delete a 'NotificationHistory'.
                            deleteNotificationHistoryProc = NotificationHistoryWriter.CreateDeleteNotificationHistoryStoredProcedure(notificationHistory);
                        }
                    }

                    // Verify deleteNotificationHistoryProc exists
                    if(deleteNotificationHistoryProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.NotificationHistoryManager.DeleteNotificationHistory(deleteNotificationHistoryProc, dataConnector);

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
            /// This method fetches all 'NotificationHistory' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'NotificationHistory' to delete.
            /// <returns>A PolymorphicObject object with all  'NotificationHistorys' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<NotificationHistory> notificationHistoryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllNotificationHistorysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get NotificationHistoryParameter
                    // Declare Parameter
                    NotificationHistory paramNotificationHistory = null;

                    // verify the first parameters is a(n) 'NotificationHistory'.
                    if (parameters[0].ObjectValue as NotificationHistory != null)
                    {
                        // Get NotificationHistoryParameter
                        paramNotificationHistory = (NotificationHistory) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllNotificationHistorysProc from NotificationHistoryWriter
                    fetchAllProc = NotificationHistoryWriter.CreateFetchAllNotificationHistorysStoredProcedure(paramNotificationHistory);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    notificationHistoryListCollection = this.DataManager.NotificationHistoryManager.FetchAllNotificationHistorys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(notificationHistoryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = notificationHistoryListCollection;
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

            #region FindNotificationHistory(NotificationHistory)
            /// <summary>
            /// This method finds a 'NotificationHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'NotificationHistory' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindNotificationHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                NotificationHistory notificationHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindNotificationHistoryStoredProcedure findNotificationHistoryProc = null;

                    // verify the first parameters is a 'NotificationHistory'.
                    if (parameters[0].ObjectValue as NotificationHistory != null)
                    {
                        // Get NotificationHistoryParameter
                        NotificationHistory paramNotificationHistory = (NotificationHistory) parameters[0].ObjectValue;

                        // verify paramNotificationHistory exists
                        if(paramNotificationHistory != null)
                        {
                            // Now create findNotificationHistoryProc from NotificationHistoryWriter
                            // The DataWriter converts the 'NotificationHistory'
                            // to the SqlParameter[] array needed to find a 'NotificationHistory'.
                            findNotificationHistoryProc = NotificationHistoryWriter.CreateFindNotificationHistoryStoredProcedure(paramNotificationHistory);
                        }

                        // Verify findNotificationHistoryProc exists
                        if(findNotificationHistoryProc != null)
                        {
                            // Execute Find Stored Procedure
                            notificationHistory = this.DataManager.NotificationHistoryManager.FindNotificationHistory(findNotificationHistoryProc, dataConnector);

                            // if dataObject exists
                            if(notificationHistory != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = notificationHistory;
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

            #region InsertNotificationHistory (NotificationHistory)
            /// <summary>
            /// This method inserts a 'NotificationHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'NotificationHistory' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertNotificationHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                NotificationHistory notificationHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertNotificationHistoryStoredProcedure insertNotificationHistoryProc = null;

                    // verify the first parameters is a(n) 'NotificationHistory'.
                    if (parameters[0].ObjectValue as NotificationHistory != null)
                    {
                        // Create NotificationHistory Parameter
                        notificationHistory = (NotificationHistory) parameters[0].ObjectValue;

                        // verify notificationHistory exists
                        if(notificationHistory != null)
                        {
                            // Now create insertNotificationHistoryProc from NotificationHistoryWriter
                            // The DataWriter converts the 'NotificationHistory'
                            // to the SqlParameter[] array needed to insert a 'NotificationHistory'.
                            insertNotificationHistoryProc = NotificationHistoryWriter.CreateInsertNotificationHistoryStoredProcedure(notificationHistory);
                        }

                        // Verify insertNotificationHistoryProc exists
                        if(insertNotificationHistoryProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.NotificationHistoryManager.InsertNotificationHistory(insertNotificationHistoryProc, dataConnector);
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

            #region UpdateNotificationHistory (NotificationHistory)
            /// <summary>
            /// This method updates a 'NotificationHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'NotificationHistory' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateNotificationHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                NotificationHistory notificationHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateNotificationHistoryStoredProcedure updateNotificationHistoryProc = null;

                    // verify the first parameters is a(n) 'NotificationHistory'.
                    if (parameters[0].ObjectValue as NotificationHistory != null)
                    {
                        // Create NotificationHistory Parameter
                        notificationHistory = (NotificationHistory) parameters[0].ObjectValue;

                        // verify notificationHistory exists
                        if(notificationHistory != null)
                        {
                            // Now create updateNotificationHistoryProc from NotificationHistoryWriter
                            // The DataWriter converts the 'NotificationHistory'
                            // to the SqlParameter[] array needed to update a 'NotificationHistory'.
                            updateNotificationHistoryProc = NotificationHistoryWriter.CreateUpdateNotificationHistoryStoredProcedure(notificationHistory);
                        }

                        // Verify updateNotificationHistoryProc exists
                        if(updateNotificationHistoryProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.NotificationHistoryManager.UpdateNotificationHistory(updateNotificationHistoryProc, dataConnector);

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
