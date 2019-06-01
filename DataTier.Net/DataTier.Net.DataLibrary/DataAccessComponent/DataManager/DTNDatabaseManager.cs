

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

    #region class DTNDatabaseManager
    /// <summary>
    /// This class is used to manage a 'DTNDatabase' object.
    /// </summary>
    public class DTNDatabaseManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DTNDatabaseManager' object.
        /// </summary>
        public DTNDatabaseManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteDTNDatabase()
            /// <summary>
            /// This method deletes a 'DTNDatabase' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteDTNDatabase(DeleteDTNDatabaseStoredProcedure deleteDTNDatabaseProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteDTNDatabaseProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllDTNDatabases()
            /// <summary>
            /// This method fetches a  'List<DTNDatabase>' object.
            /// This method uses the 'DTNDatabases_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DTNDatabase>'</returns>
            /// </summary>
            public List<DTNDatabase> FetchAllDTNDatabases(FetchAllDTNDatabasesStoredProcedure fetchAllDTNDatabasesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DTNDatabase> dTNDatabaseCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDTNDatabasesDataSet = this.DataHelper.LoadDataSet(fetchAllDTNDatabasesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDTNDatabasesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allDTNDatabasesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            dTNDatabaseCollection = DTNDatabaseReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return dTNDatabaseCollection;
            }
            #endregion

            #region FindDTNDatabase()
            /// <summary>
            /// This method finds a  'DTNDatabase' object.
            /// This method uses the 'DTNDatabase_Find' procedure.
            /// </summary>
            /// <returns>A 'DTNDatabase' object.</returns>
            /// </summary>
            public DTNDatabase FindDTNDatabase(FindDTNDatabaseStoredProcedure findDTNDatabaseProc, DataConnector databaseConnector)
            {
                // Initial Value
                DTNDatabase dTNDatabase = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet dTNDatabaseDataSet = this.DataHelper.LoadDataSet(findDTNDatabaseProc, databaseConnector);

                    // Verify DataSet Exists
                    if(dTNDatabaseDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(dTNDatabaseDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load DTNDatabase
                            dTNDatabase = DTNDatabaseReader.Load(row);
                        }
                    }
                }

                // return value
                return dTNDatabase;
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

            #region InsertDTNDatabase()
            /// <summary>
            /// This method inserts a 'DTNDatabase' object.
            /// This method uses the 'DTNDatabase_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertDTNDatabase(InsertDTNDatabaseStoredProcedure insertDTNDatabaseProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertDTNDatabaseProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateDTNDatabase()
            /// <summary>
            /// This method updates a 'DTNDatabase'.
            /// This method uses the 'DTNDatabase_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateDTNDatabase(UpdateDTNDatabaseStoredProcedure updateDTNDatabaseProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateDTNDatabaseProc, databaseConnector);
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
