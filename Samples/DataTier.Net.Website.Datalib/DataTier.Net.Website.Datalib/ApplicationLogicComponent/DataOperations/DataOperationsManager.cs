

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

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private GitHubFollowerMethods githubfollowerMethods;
        private NotificationMethods notificationMethods;
        private NotificationHistoryMethods notificationhistoryMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.GitHubFollowerMethods = new GitHubFollowerMethods(this.DataManager);
                this.NotificationMethods = new NotificationMethods(this.DataManager);
                this.NotificationHistoryMethods = new NotificationHistoryMethods(this.DataManager);
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

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region GitHubFollowerMethods
            public GitHubFollowerMethods GitHubFollowerMethods
            {
                get { return githubfollowerMethods; }
                set { githubfollowerMethods = value; }
            }
            #endregion

            #region NotificationMethods
            public NotificationMethods NotificationMethods
            {
                get { return notificationMethods; }
                set { notificationMethods = value; }
            }
            #endregion

            #region NotificationHistoryMethods
            public NotificationHistoryMethods NotificationHistoryMethods
            {
                get { return notificationhistoryMethods; }
                set { notificationhistoryMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
