

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

    #region class FieldSetManager
    /// <summary>
    /// This class is used to manage a 'FieldSet' object.
    /// </summary>
    public class FieldSetManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FieldSetManager' object.
        /// </summary>
        public FieldSetManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteFieldSet()
            /// <summary>
            /// This method deletes a 'FieldSet' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteFieldSet(DeleteFieldSetStoredProcedure deleteFieldSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteFieldSetProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllFieldSets()
            /// <summary>
            /// This method fetches a  'List<FieldSet>' object.
            /// This method uses the 'FieldSets_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<FieldSet>'</returns>
            /// </summary>
            public static List<FieldSet> FetchAllFieldSets(FetchAllFieldSetsStoredProcedure fetchAllFieldSetsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<FieldSet> fieldSetCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFieldSetsDataSet = DataHelper.LoadDataSet(fetchAllFieldSetsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFieldSetsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allFieldSetsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            fieldSetCollection = FieldSetReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return fieldSetCollection;
            }
            #endregion

            #region FindFieldSet()
            /// <summary>
            /// This method finds a  'FieldSet' object.
            /// This method uses the 'FieldSet_Find' procedure.
            /// </summary>
            /// <returns>A 'FieldSet' object.</returns>
            /// </summary>
            public static FieldSet FindFieldSet(FindFieldSetStoredProcedure findFieldSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                FieldSet fieldSet = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet fieldSetDataSet = DataHelper.LoadDataSet(findFieldSetProc, databaseConnector);

                    // Verify DataSet Exists
                    if(fieldSetDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(fieldSetDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load FieldSet
                            fieldSet = FieldSetReader.Load(row);
                        }
                    }
                }

                // return value
                return fieldSet;
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

            #region InsertFieldSet()
            /// <summary>
            /// This method inserts a 'FieldSet' object.
            /// This method uses the 'FieldSet_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertFieldSet(InsertFieldSetStoredProcedure insertFieldSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertFieldSetProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateFieldSet()
            /// <summary>
            /// This method updates a 'FieldSet'.
            /// This method uses the 'FieldSet_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateFieldSet(UpdateFieldSetStoredProcedure updateFieldSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateFieldSetProc, databaseConnector);
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
