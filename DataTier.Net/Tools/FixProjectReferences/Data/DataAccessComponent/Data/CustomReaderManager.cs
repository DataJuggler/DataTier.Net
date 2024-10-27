

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

    #region class CustomReaderManager
    /// <summary>
    /// This class is used to manage a 'CustomReader' object.
    /// </summary>
    public class CustomReaderManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomReaderManager' object.
        /// </summary>
        public CustomReaderManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteCustomReader()
            /// <summary>
            /// This method deletes a 'CustomReader' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteCustomReader(DeleteCustomReaderStoredProcedure deleteCustomReaderProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteCustomReaderProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllCustomReaders()
            /// <summary>
            /// This method fetches a  'List<CustomReader>' object.
            /// This method uses the 'CustomReaders_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<CustomReader>'</returns>
            /// </summary>
            public List<CustomReader> FetchAllCustomReaders(FetchAllCustomReadersStoredProcedure fetchAllCustomReadersProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<CustomReader> customReaderCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allCustomReadersDataSet = this.DataHelper.LoadDataSet(fetchAllCustomReadersProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allCustomReadersDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allCustomReadersDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            customReaderCollection = CustomReaderReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return customReaderCollection;
            }
            #endregion

            #region FindCustomReader()
            /// <summary>
            /// This method finds a  'CustomReader' object.
            /// This method uses the 'CustomReader_Find' procedure.
            /// </summary>
            /// <returns>A 'CustomReader' object.</returns>
            /// </summary>
            public CustomReader FindCustomReader(FindCustomReaderStoredProcedure findCustomReaderProc, DataConnector databaseConnector)
            {
                // Initial Value
                CustomReader customReader = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet customReaderDataSet = this.DataHelper.LoadDataSet(findCustomReaderProc, databaseConnector);

                    // Verify DataSet Exists
                    if(customReaderDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(customReaderDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load CustomReader
                            customReader = CustomReaderReader.Load(row);
                        }
                    }
                }

                // return value
                return customReader;
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

            #region InsertCustomReader()
            /// <summary>
            /// This method inserts a 'CustomReader' object.
            /// This method uses the 'CustomReader_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertCustomReader(InsertCustomReaderStoredProcedure insertCustomReaderProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertCustomReaderProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateCustomReader()
            /// <summary>
            /// This method updates a 'CustomReader'.
            /// This method uses the 'CustomReader_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateCustomReader(UpdateCustomReaderStoredProcedure updateCustomReaderProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateCustomReaderProc, databaseConnector);
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
