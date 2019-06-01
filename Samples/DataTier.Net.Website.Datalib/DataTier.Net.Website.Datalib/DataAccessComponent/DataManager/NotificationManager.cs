

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class NotificationManager
    /// <summary>
    /// This class is used to manage a 'Notification' object.
    /// </summary>
    public class NotificationManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NotificationManager' object.
        /// </summary>
        public NotificationManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteNotification()
            /// <summary>
            /// This method deletes a 'Notification' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteNotification(DeleteNotificationStoredProcedure deleteNotificationProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteNotificationProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllNotifications()
            /// <summary>
            /// This method fetches a  'List<Notification>' object.
            /// This method uses the 'Notifications_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Notification>'</returns>
            /// </summary>
            public List<Notification> FetchAllNotifications(FetchAllNotificationsStoredProcedure fetchAllNotificationsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Notification> notificationCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allNotificationsDataSet = this.DataHelper.LoadDataSet(fetchAllNotificationsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allNotificationsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allNotificationsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            notificationCollection = NotificationReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return notificationCollection;
            }
            #endregion

            #region FindNotification()
            /// <summary>
            /// This method finds a  'Notification' object.
            /// This method uses the 'Notification_Find' procedure.
            /// </summary>
            /// <returns>A 'Notification' object.</returns>
            /// </summary>
            public Notification FindNotification(FindNotificationStoredProcedure findNotificationProc, DataConnector databaseConnector)
            {
                // Initial Value
                Notification notification = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet notificationDataSet = this.DataHelper.LoadDataSet(findNotificationProc, databaseConnector);

                    // Verify DataSet Exists
                    if(notificationDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(notificationDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Notification
                            notification = NotificationReader.Load(row);
                        }
                    }
                }

                // return value
                return notification;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertNotification()
            /// <summary>
            /// This method inserts a 'Notification' object.
            /// This method uses the 'Notification_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertNotification(InsertNotificationStoredProcedure insertNotificationProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertNotificationProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateNotification()
            /// <summary>
            /// This method updates a 'Notification'.
            /// This method uses the 'Notification_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateNotification(UpdateNotificationStoredProcedure updateNotificationProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateNotificationProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
