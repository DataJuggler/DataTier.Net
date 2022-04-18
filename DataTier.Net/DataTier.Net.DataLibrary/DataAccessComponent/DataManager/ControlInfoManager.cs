

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

    #region class ControlInfoManager
    /// <summary>
    /// This class is used to manage a 'ControlInfo' object.
    /// </summary>
    public class ControlInfoManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ControlInfoManager' object.
        /// </summary>
        public ControlInfoManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteControlInfo()
            /// <summary>
            /// This method deletes a 'ControlInfo' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteControlInfo(DeleteControlInfoStoredProcedure deleteControlInfoProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteControlInfoProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllControlInfos()
            /// <summary>
            /// This method fetches a  'List<ControlInfo>' object.
            /// This method uses the 'ControlInfos_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ControlInfo>'</returns>
            /// </summary>
            public List<ControlInfo> FetchAllControlInfos(FetchAllControlInfosStoredProcedure fetchAllControlInfosProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ControlInfo> controlInfoCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allControlInfosDataSet = this.DataHelper.LoadDataSet(fetchAllControlInfosProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allControlInfosDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allControlInfosDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            controlInfoCollection = ControlInfoReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return controlInfoCollection;
            }
            #endregion

            #region FindControlInfo()
            /// <summary>
            /// This method finds a  'ControlInfo' object.
            /// This method uses the 'ControlInfo_Find' procedure.
            /// </summary>
            /// <returns>A 'ControlInfo' object.</returns>
            /// </summary>
            public ControlInfo FindControlInfo(FindControlInfoStoredProcedure findControlInfoProc, DataConnector databaseConnector)
            {
                // Initial Value
                ControlInfo controlInfo = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet controlInfoDataSet = this.DataHelper.LoadDataSet(findControlInfoProc, databaseConnector);

                    // Verify DataSet Exists
                    if(controlInfoDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(controlInfoDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ControlInfo
                            controlInfo = ControlInfoReader.Load(row);
                        }
                    }
                }

                // return value
                return controlInfo;
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

            #region InsertControlInfo()
            /// <summary>
            /// This method inserts a 'ControlInfo' object.
            /// This method uses the 'ControlInfo_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertControlInfo(InsertControlInfoStoredProcedure insertControlInfoProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertControlInfoProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateControlInfo()
            /// <summary>
            /// This method updates a 'ControlInfo'.
            /// This method uses the 'ControlInfo_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateControlInfo(UpdateControlInfoStoredProcedure updateControlInfoProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateControlInfoProc, databaseConnector);
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
