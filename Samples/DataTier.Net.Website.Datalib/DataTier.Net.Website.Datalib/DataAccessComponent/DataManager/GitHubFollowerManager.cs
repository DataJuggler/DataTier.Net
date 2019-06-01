

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

    #region class GitHubFollowerManager
    /// <summary>
    /// This class is used to manage a 'GitHubFollower' object.
    /// </summary>
    public class GitHubFollowerManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'GitHubFollowerManager' object.
        /// </summary>
        public GitHubFollowerManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteGitHubFollower()
            /// <summary>
            /// This method deletes a 'GitHubFollower' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteGitHubFollower(DeleteGitHubFollowerStoredProcedure deleteGitHubFollowerProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteGitHubFollowerProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllGitHubFollowers()
            /// <summary>
            /// This method fetches a  'List<GitHubFollower>' object.
            /// This method uses the 'GitHubFollowers_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<GitHubFollower>'</returns>
            /// </summary>
            public List<GitHubFollower> FetchAllGitHubFollowers(FetchAllGitHubFollowersStoredProcedure fetchAllGitHubFollowersProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<GitHubFollower> gitHubFollowerCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allGitHubFollowersDataSet = this.DataHelper.LoadDataSet(fetchAllGitHubFollowersProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allGitHubFollowersDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allGitHubFollowersDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            gitHubFollowerCollection = GitHubFollowerReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return gitHubFollowerCollection;
            }
            #endregion

            #region FindGitHubFollower()
            /// <summary>
            /// This method finds a  'GitHubFollower' object.
            /// This method uses the 'GitHubFollower_Find' procedure.
            /// </summary>
            /// <returns>A 'GitHubFollower' object.</returns>
            /// </summary>
            public GitHubFollower FindGitHubFollower(FindGitHubFollowerStoredProcedure findGitHubFollowerProc, DataConnector databaseConnector)
            {
                // Initial Value
                GitHubFollower gitHubFollower = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet gitHubFollowerDataSet = this.DataHelper.LoadDataSet(findGitHubFollowerProc, databaseConnector);

                    // Verify DataSet Exists
                    if(gitHubFollowerDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(gitHubFollowerDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load GitHubFollower
                            gitHubFollower = GitHubFollowerReader.Load(row);
                        }
                    }
                }

                // return value
                return gitHubFollower;
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

            #region InsertGitHubFollower()
            /// <summary>
            /// This method inserts a 'GitHubFollower' object.
            /// This method uses the 'GitHubFollower_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertGitHubFollower(InsertGitHubFollowerStoredProcedure insertGitHubFollowerProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertGitHubFollowerProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateGitHubFollower()
            /// <summary>
            /// This method updates a 'GitHubFollower'.
            /// This method uses the 'GitHubFollower_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateGitHubFollower(UpdateGitHubFollowerStoredProcedure updateGitHubFollowerProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateGitHubFollowerProc, databaseConnector);
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
