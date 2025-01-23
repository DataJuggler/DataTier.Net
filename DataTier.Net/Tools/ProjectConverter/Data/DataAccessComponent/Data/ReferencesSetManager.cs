

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

    #region class ReferencesSetManager
    /// <summary>
    /// This class is used to manage a 'ReferencesSet' object.
    /// </summary>
    public class ReferencesSetManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ReferencesSetManager' object.
        /// </summary>
        public ReferencesSetManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteReferencesSet()
            /// <summary>
            /// This method deletes a 'ReferencesSet' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteReferencesSet(DeleteReferencesSetStoredProcedure deleteReferencesSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteReferencesSetProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllReferencesSets()
            /// <summary>
            /// This method fetches a  'List<ReferencesSet>' object.
            /// This method uses the 'ReferencesSets_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ReferencesSet>'</returns>
            /// </summary>
            public static List<ReferencesSet> FetchAllReferencesSets(FetchAllReferencesSetsStoredProcedure fetchAllReferencesSetsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ReferencesSet> referencesSetCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allReferencesSetsDataSet = DataHelper.LoadDataSet(fetchAllReferencesSetsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allReferencesSetsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allReferencesSetsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            referencesSetCollection = ReferencesSetReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return referencesSetCollection;
            }
            #endregion

            #region FindReferencesSet()
            /// <summary>
            /// This method finds a  'ReferencesSet' object.
            /// This method uses the 'ReferencesSet_Find' procedure.
            /// </summary>
            /// <returns>A 'ReferencesSet' object.</returns>
            /// </summary>
            public static ReferencesSet FindReferencesSet(FindReferencesSetStoredProcedure findReferencesSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                ReferencesSet referencesSet = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet referencesSetDataSet = DataHelper.LoadDataSet(findReferencesSetProc, databaseConnector);

                    // Verify DataSet Exists
                    if(referencesSetDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(referencesSetDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ReferencesSet
                            referencesSet = ReferencesSetReader.Load(row);
                        }
                    }
                }

                // return value
                return referencesSet;
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

            #region InsertReferencesSet()
            /// <summary>
            /// This method inserts a 'ReferencesSet' object.
            /// This method uses the 'ReferencesSet_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertReferencesSet(InsertReferencesSetStoredProcedure insertReferencesSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertReferencesSetProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateReferencesSet()
            /// <summary>
            /// This method updates a 'ReferencesSet'.
            /// This method uses the 'ReferencesSet_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateReferencesSet(UpdateReferencesSetStoredProcedure updateReferencesSetProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateReferencesSetProc, databaseConnector);
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
