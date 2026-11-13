

#region using statements

using System;
using System.Collections.Generic;
using System.Data;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Data.Readers;

#endregion


namespace DataAccessComponent.Data
{

    #region class BuildExcludesManager
    /// <summary>
    /// This class is used to manage a 'BuildExcludes' object.
    /// </summary>
    public class BuildExcludesManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'BuildExcludesManager' object.
        /// </summary>
        public BuildExcludesManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteBuildExcludes()
            /// <summary>
            /// This method deletes a 'BuildExcludes' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteBuildExcludes(DeleteBuildExcludesStoredProcedure deleteBuildExcludesProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteBuildExcludesProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllBuildExcludes()
            /// <summary>
            /// This method fetches a  'List<BuildExcludes>' object.
            /// This method uses the 'BuildExcludes_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<BuildExcludes>'</returns>
            /// </summary>
            public static List<BuildExcludes> FetchAllBuildExcludes(FetchAllBuildExcludesStoredProcedure fetchAllBuildExcludesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<BuildExcludes> buildExcludesCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allBuildExcludesDataSet = DataHelper.LoadDataSet(fetchAllBuildExcludesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allBuildExcludesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allBuildExcludesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            buildExcludesCollection = BuildExcludesReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return buildExcludesCollection;
            }
            #endregion

            #region FindBuildExcludes()
            /// <summary>
            /// This method finds a  'BuildExcludes' object.
            /// This method uses the 'BuildExcludes_Find' procedure.
            /// </summary>
            /// <returns>A 'BuildExcludes' object.</returns>
            /// </summary>
            public static BuildExcludes FindBuildExcludes(FindBuildExcludesStoredProcedure findBuildExcludesProc, DataConnector databaseConnector)
            {
                // Initial Value
                BuildExcludes buildExcludes = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet buildExcludesDataSet = DataHelper.LoadDataSet(findBuildExcludesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(buildExcludesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(buildExcludesDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load BuildExcludes
                            buildExcludes = BuildExcludesReader.Load(row);
                        }
                    }
                }

                // return value
                return buildExcludes;
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

            #region InsertBuildExcludes()
            /// <summary>
            /// This method inserts a 'BuildExcludes' object.
            /// This method uses the 'BuildExcludes_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertBuildExcludes(InsertBuildExcludesStoredProcedure insertBuildExcludesProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertBuildExcludesProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateBuildExcludes()
            /// <summary>
            /// This method updates a 'BuildExcludes'.
            /// This method uses the 'BuildExcludes_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateBuildExcludes(UpdateBuildExcludesStoredProcedure updateBuildExcludesProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateBuildExcludesProc, databaseConnector);
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
