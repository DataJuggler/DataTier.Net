

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

    #region class NotificationHistoryManager
    /// <summary>
    /// This class is used to manage a 'NotificationHistory' object.
    /// </summary>
    public class NotificationHistoryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NotificationHistoryManager' object.
        /// </summary>
        public NotificationHistoryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteNotificationHistory()
            /// <summary>
            /// This method deletes a 'NotificationHistory' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteNotificationHistory(DeleteNotificationHistoryStoredProcedure deleteNotificationHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteNotificationHistoryProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllNotificationHistorys()
            /// <summary>
            /// This method fetches a  'List<NotificationHistory>' object.
            /// This method uses the 'NotificationHistorys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<NotificationHistory>'</returns>
            /// </summary>
            public List<NotificationHistory> FetchAllNotificationHistorys(FetchAllNotificationHistorysStoredProcedure fetchAllNotificationHistorysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<NotificationHistory> notificationHistoryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allNotificationHistorysDataSet = this.DataHelper.LoadDataSet(fetchAllNotificationHistorysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allNotificationHistorysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allNotificationHistorysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            notificationHistoryCollection = NotificationHistoryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return notificationHistoryCollection;
            }
            #endregion

            #region FindNotificationHistory()
            /// <summary>
            /// This method finds a  'NotificationHistory' object.
            /// This method uses the 'NotificationHistory_Find' procedure.
            /// </summary>
            /// <returns>A 'NotificationHistory' object.</returns>
            /// </summary>
            public NotificationHistory FindNotificationHistory(FindNotificationHistoryStoredProcedure findNotificationHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                NotificationHistory notificationHistory = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet notificationHistoryDataSet = this.DataHelper.LoadDataSet(findNotificationHistoryProc, databaseConnector);

                    // Verify DataSet Exists
                    if(notificationHistoryDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(notificationHistoryDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load NotificationHistory
                            notificationHistory = NotificationHistoryReader.Load(row);
                        }
                    }
                }

                // return value
                return notificationHistory;
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

            #region InsertNotificationHistory()
            /// <summary>
            /// This method inserts a 'NotificationHistory' object.
            /// This method uses the 'NotificationHistory_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertNotificationHistory(InsertNotificationHistoryStoredProcedure insertNotificationHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertNotificationHistoryProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateNotificationHistory()
            /// <summary>
            /// This method updates a 'NotificationHistory'.
            /// This method uses the 'NotificationHistory_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateNotificationHistory(UpdateNotificationHistoryStoredProcedure updateNotificationHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateNotificationHistoryProc, databaseConnector);
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
