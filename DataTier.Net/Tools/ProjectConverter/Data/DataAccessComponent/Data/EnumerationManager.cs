

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

    #region class EnumerationManager
    /// <summary>
    /// This class is used to manage a 'Enumeration' object.
    /// </summary>
    public class EnumerationManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'EnumerationManager' object.
        /// </summary>
        public EnumerationManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteEnumeration()
            /// <summary>
            /// This method deletes a 'Enumeration' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteEnumeration(DeleteEnumerationStoredProcedure deleteEnumerationProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteEnumerationProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllEnumerations()
            /// <summary>
            /// This method fetches a  'List<Enumeration>' object.
            /// This method uses the 'Enumerations_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Enumeration>'</returns>
            /// </summary>
            public static List<Enumeration> FetchAllEnumerations(FetchAllEnumerationsStoredProcedure fetchAllEnumerationsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Enumeration> enumerationCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allEnumerationsDataSet = DataHelper.LoadDataSet(fetchAllEnumerationsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allEnumerationsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allEnumerationsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            enumerationCollection = EnumerationReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return enumerationCollection;
            }
            #endregion

            #region FindEnumeration()
            /// <summary>
            /// This method finds a  'Enumeration' object.
            /// This method uses the 'Enumeration_Find' procedure.
            /// </summary>
            /// <returns>A 'Enumeration' object.</returns>
            /// </summary>
            public static Enumeration FindEnumeration(FindEnumerationStoredProcedure findEnumerationProc, DataConnector databaseConnector)
            {
                // Initial Value
                Enumeration enumeration = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet enumerationDataSet = DataHelper.LoadDataSet(findEnumerationProc, databaseConnector);

                    // Verify DataSet Exists
                    if(enumerationDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(enumerationDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Enumeration
                            enumeration = EnumerationReader.Load(row);
                        }
                    }
                }

                // return value
                return enumeration;
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

            #region InsertEnumeration()
            /// <summary>
            /// This method inserts a 'Enumeration' object.
            /// This method uses the 'Enumeration_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertEnumeration(InsertEnumerationStoredProcedure insertEnumerationProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertEnumerationProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateEnumeration()
            /// <summary>
            /// This method updates a 'Enumeration'.
            /// This method uses the 'Enumeration_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateEnumeration(UpdateEnumerationStoredProcedure updateEnumerationProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateEnumerationProc, databaseConnector);
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
