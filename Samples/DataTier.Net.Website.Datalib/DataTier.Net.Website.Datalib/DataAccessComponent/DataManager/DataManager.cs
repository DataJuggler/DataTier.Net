

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

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private GitHubFollowerManager githubfollowerManager;
        private NotificationManager notificationManager;
        private NotificationHistoryManager notificationhistoryManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager()
        {
            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create Child Object Managers
                this.GitHubFollowerManager = new GitHubFollowerManager(this);
                this.NotificationManager = new NotificationManager(this);
                this.NotificationHistoryManager = new NotificationHistoryManager(this);
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region GitHubFollowerManager
            public GitHubFollowerManager GitHubFollowerManager
            {
                get { return githubfollowerManager; }
                set { githubfollowerManager = value; }
            }
            #endregion

            #region NotificationManager
            public NotificationManager NotificationManager
            {
                get { return notificationManager; }
                set { notificationManager = value; }
            }
            #endregion

            #region NotificationHistoryManager
            public NotificationHistoryManager NotificationHistoryManager
            {
                get { return notificationhistoryManager; }
                set { notificationhistoryManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
