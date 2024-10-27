

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

    #region class DTNFieldManager
    /// <summary>
    /// This class is used to manage a 'DTNField' object.
    /// </summary>
    public class DTNFieldManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DTNFieldManager' object.
        /// </summary>
        public DTNFieldManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteDTNField()
            /// <summary>
            /// This method deletes a 'DTNField' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteDTNField(DeleteDTNFieldStoredProcedure deleteDTNFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteDTNFieldProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllDTNFields()
            /// <summary>
            /// This method fetches a  'List<DTNField>' object.
            /// This method uses the 'DTNFields_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DTNField>'</returns>
            /// </summary>
            public List<DTNField> FetchAllDTNFields(FetchAllDTNFieldsStoredProcedure fetchAllDTNFieldsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DTNField> dTNFieldCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDTNFieldsDataSet = this.DataHelper.LoadDataSet(fetchAllDTNFieldsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDTNFieldsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allDTNFieldsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            dTNFieldCollection = DTNFieldReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return dTNFieldCollection;
            }
            #endregion

            #region FindDTNField()
            /// <summary>
            /// This method finds a  'DTNField' object.
            /// This method uses the 'DTNField_Find' procedure.
            /// </summary>
            /// <returns>A 'DTNField' object.</returns>
            /// </summary>
            public DTNField FindDTNField(FindDTNFieldStoredProcedure findDTNFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                DTNField dTNField = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet dTNFieldDataSet = this.DataHelper.LoadDataSet(findDTNFieldProc, databaseConnector);

                    // Verify DataSet Exists
                    if(dTNFieldDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(dTNFieldDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load DTNField
                            dTNField = DTNFieldReader.Load(row);
                        }
                    }
                }

                // return value
                return dTNField;
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

            #region InsertDTNField()
            /// <summary>
            /// This method inserts a 'DTNField' object.
            /// This method uses the 'DTNField_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertDTNField(InsertDTNFieldStoredProcedure insertDTNFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertDTNFieldProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateDTNField()
            /// <summary>
            /// This method updates a 'DTNField'.
            /// This method uses the 'DTNField_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateDTNField(UpdateDTNFieldStoredProcedure updateDTNFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateDTNFieldProc, databaseConnector);
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
