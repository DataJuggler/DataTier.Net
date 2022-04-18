

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

    #region class ControlInfoDetailManager
    /// <summary>
    /// This class is used to manage a 'ControlInfoDetail' object.
    /// </summary>
    public class ControlInfoDetailManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ControlInfoDetailManager' object.
        /// </summary>
        public ControlInfoDetailManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteControlInfoDetail()
            /// <summary>
            /// This method deletes a 'ControlInfoDetail' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteControlInfoDetail(DeleteControlInfoDetailStoredProcedure deleteControlInfoDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteControlInfoDetailProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllControlInfoDetails()
            /// <summary>
            /// This method fetches a  'List<ControlInfoDetail>' object.
            /// This method uses the 'ControlInfoDetails_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ControlInfoDetail>'</returns>
            /// </summary>
            public List<ControlInfoDetail> FetchAllControlInfoDetails(FetchAllControlInfoDetailsStoredProcedure fetchAllControlInfoDetailsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ControlInfoDetail> controlInfoDetailCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allControlInfoDetailsDataSet = this.DataHelper.LoadDataSet(fetchAllControlInfoDetailsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allControlInfoDetailsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allControlInfoDetailsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            controlInfoDetailCollection = ControlInfoDetailReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return controlInfoDetailCollection;
            }
            #endregion

            #region FindControlInfoDetail()
            /// <summary>
            /// This method finds a  'ControlInfoDetail' object.
            /// This method uses the 'ControlInfoDetail_Find' procedure.
            /// </summary>
            /// <returns>A 'ControlInfoDetail' object.</returns>
            /// </summary>
            public ControlInfoDetail FindControlInfoDetail(FindControlInfoDetailStoredProcedure findControlInfoDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                ControlInfoDetail controlInfoDetail = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet controlInfoDetailDataSet = this.DataHelper.LoadDataSet(findControlInfoDetailProc, databaseConnector);

                    // Verify DataSet Exists
                    if(controlInfoDetailDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(controlInfoDetailDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ControlInfoDetail
                            controlInfoDetail = ControlInfoDetailReader.Load(row);
                        }
                    }
                }

                // return value
                return controlInfoDetail;
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

            #region InsertControlInfoDetail()
            /// <summary>
            /// This method inserts a 'ControlInfoDetail' object.
            /// This method uses the 'ControlInfoDetail_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertControlInfoDetail(InsertControlInfoDetailStoredProcedure insertControlInfoDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertControlInfoDetailProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateControlInfoDetail()
            /// <summary>
            /// This method updates a 'ControlInfoDetail'.
            /// This method uses the 'ControlInfoDetail_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateControlInfoDetail(UpdateControlInfoDetailStoredProcedure updateControlInfoDetailProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateControlInfoDetailProc, databaseConnector);
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
