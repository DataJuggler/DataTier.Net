

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
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class UIFieldManager
    /// <summary>
    /// This class is used to manage a 'UIField' object.
    /// </summary>
    public class UIFieldManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UIFieldManager' object.
        /// </summary>
        public UIFieldManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteUIField()
            /// <summary>
            /// This method deletes a 'UIField' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteUIField(DeleteUIFieldStoredProcedure deleteUIFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteUIFieldProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllUIFields()
            /// <summary>
            /// This method fetches a  'List<UIField>' object.
            /// This method uses the 'UIFields_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<UIField>'</returns>
            /// </summary>
            public List<UIField> FetchAllUIFields(FetchAllUIFieldsStoredProcedure fetchAllUIFieldsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<UIField> uIFieldCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allUIFieldsDataSet = this.DataHelper.LoadDataSet(fetchAllUIFieldsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allUIFieldsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allUIFieldsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            uIFieldCollection = UIFieldReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return uIFieldCollection;
            }
            #endregion

            #region FindUIField()
            /// <summary>
            /// This method finds a  'UIField' object.
            /// This method uses the 'UIField_Find' procedure.
            /// </summary>
            /// <returns>A 'UIField' object.</returns>
            /// </summary>
            public UIField FindUIField(FindUIFieldStoredProcedure findUIFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                UIField uIField = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet uIFieldDataSet = this.DataHelper.LoadDataSet(findUIFieldProc, databaseConnector);

                    // Verify DataSet Exists
                    if(uIFieldDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(uIFieldDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load UIField
                            uIField = UIFieldReader.Load(row);
                        }
                    }
                }

                // return value
                return uIField;
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

            #region InsertUIField()
            /// <summary>
            /// This method inserts a 'UIField' object.
            /// This method uses the 'UIField_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertUIField(InsertUIFieldStoredProcedure insertUIFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertUIFieldProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateUIField()
            /// <summary>
            /// This method updates a 'UIField'.
            /// This method uses the 'UIField_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateUIField(UpdateUIFieldStoredProcedure updateUIFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateUIFieldProc, databaseConnector);
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
