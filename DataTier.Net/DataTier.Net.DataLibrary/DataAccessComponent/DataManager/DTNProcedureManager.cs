

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

    #region class DTNProcedureManager
    /// <summary>
    /// This class is used to manage a 'DTNProcedure' object.
    /// </summary>
    public class DTNProcedureManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DTNProcedureManager' object.
        /// </summary>
        public DTNProcedureManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteDTNProcedure()
            /// <summary>
            /// This method deletes a 'DTNProcedure' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteDTNProcedure(DeleteDTNProcedureStoredProcedure deleteDTNProcedureProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteDTNProcedureProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllDTNProcedures()
            /// <summary>
            /// This method fetches a  'List<DTNProcedure>' object.
            /// This method uses the 'DTNProcedures_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DTNProcedure>'</returns>
            /// </summary>
            public List<DTNProcedure> FetchAllDTNProcedures(FetchAllDTNProceduresStoredProcedure fetchAllDTNProceduresProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DTNProcedure> dTNProcedureCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDTNProceduresDataSet = this.DataHelper.LoadDataSet(fetchAllDTNProceduresProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDTNProceduresDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allDTNProceduresDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            dTNProcedureCollection = DTNProcedureReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return dTNProcedureCollection;
            }
            #endregion

            #region FindDTNProcedure()
            /// <summary>
            /// This method finds a  'DTNProcedure' object.
            /// This method uses the 'DTNProcedure_Find' procedure.
            /// </summary>
            /// <returns>A 'DTNProcedure' object.</returns>
            /// </summary>
            public DTNProcedure FindDTNProcedure(FindDTNProcedureStoredProcedure findDTNProcedureProc, DataConnector databaseConnector)
            {
                // Initial Value
                DTNProcedure dTNProcedure = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet dTNProcedureDataSet = this.DataHelper.LoadDataSet(findDTNProcedureProc, databaseConnector);

                    // Verify DataSet Exists
                    if(dTNProcedureDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(dTNProcedureDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load DTNProcedure
                            dTNProcedure = DTNProcedureReader.Load(row);
                        }
                    }
                }

                // return value
                return dTNProcedure;
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

            #region InsertDTNProcedure()
            /// <summary>
            /// This method inserts a 'DTNProcedure' object.
            /// This method uses the 'DTNProcedure_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertDTNProcedure(InsertDTNProcedureStoredProcedure insertDTNProcedureProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertDTNProcedureProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateDTNProcedure()
            /// <summary>
            /// This method updates a 'DTNProcedure'.
            /// This method uses the 'DTNProcedure_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateDTNProcedure(UpdateDTNProcedureStoredProcedure updateDTNProcedureProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateDTNProcedureProc, databaseConnector);
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
