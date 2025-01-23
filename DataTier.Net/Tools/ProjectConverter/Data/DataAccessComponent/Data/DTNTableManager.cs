

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data
{

    #region class DTNTableManager
    /// <summary>
    /// This class is used to manage a 'DTNTable' object.
    /// </summary>
    public class DTNTableManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DTNTableManager' object.
        /// </summary>
        public DTNTableManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteDTNTable()
            /// <summary>
            /// This method deletes a 'DTNTable' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteDTNTable(DeleteDTNTableStoredProcedure deleteDTNTableProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteDTNTableProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllDTNTables()
            /// <summary>
            /// This method fetches a  'List<DTNTable>' object.
            /// This method uses the 'DTNTables_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DTNTable>'</returns>
            /// </summary>
            public static List<DTNTable> FetchAllDTNTables(FetchAllDTNTablesStoredProcedure fetchAllDTNTablesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DTNTable> dTNTableCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDTNTablesDataSet = DataHelper.LoadDataSet(fetchAllDTNTablesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDTNTablesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allDTNTablesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            dTNTableCollection = DTNTableReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return dTNTableCollection;
            }
            #endregion

            #region FindDTNTable()
            /// <summary>
            /// This method finds a  'DTNTable' object.
            /// This method uses the 'DTNTable_Find' procedure.
            /// </summary>
            /// <returns>A 'DTNTable' object.</returns>
            /// </summary>
            public static DTNTable FindDTNTable(FindDTNTableStoredProcedure findDTNTableProc, DataConnector databaseConnector)
            {
                // Initial Value
                DTNTable dTNTable = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet dTNTableDataSet = DataHelper.LoadDataSet(findDTNTableProc, databaseConnector);

                    // Verify DataSet Exists
                    if(dTNTableDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(dTNTableDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load DTNTable
                            dTNTable = DTNTableReader.Load(row);
                        }
                    }
                }

                // return value
                return dTNTable;
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

            #region InsertDTNTable()
            /// <summary>
            /// This method inserts a 'DTNTable' object.
            /// This method uses the 'DTNTable_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertDTNTable(InsertDTNTableStoredProcedure insertDTNTableProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertDTNTableProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateDTNTable()
            /// <summary>
            /// This method updates a 'DTNTable'.
            /// This method uses the 'DTNTable_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateDTNTable(UpdateDTNTableStoredProcedure updateDTNTableProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateDTNTableProc, databaseConnector);
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
