

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

    #region class MethodManager
    /// <summary>
    /// This class is used to manage a 'Method' object.
    /// </summary>
    public class MethodManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MethodManager' object.
        /// </summary>
        public MethodManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteMethod()
            /// <summary>
            /// This method deletes a 'Method' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteMethod(DeleteMethodStoredProcedure deleteMethodProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteMethodProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllMethods()
            /// <summary>
            /// This method fetches a  'List<Method>' object.
            /// This method uses the 'Methods_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Method>'</returns>
            /// </summary>
            public static List<Method> FetchAllMethods(FetchAllMethodsStoredProcedure fetchAllMethodsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Method> methodCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allMethodsDataSet = DataHelper.LoadDataSet(fetchAllMethodsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allMethodsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allMethodsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            methodCollection = MethodReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return methodCollection;
            }
            #endregion

            #region FindMethod()
            /// <summary>
            /// This method finds a  'Method' object.
            /// This method uses the 'Method_Find' procedure.
            /// </summary>
            /// <returns>A 'Method' object.</returns>
            /// </summary>
            public static Method FindMethod(FindMethodStoredProcedure findMethodProc, DataConnector databaseConnector)
            {
                // Initial Value
                Method method = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet methodDataSet = DataHelper.LoadDataSet(findMethodProc, databaseConnector);

                    // Verify DataSet Exists
                    if(methodDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(methodDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Method
                            method = MethodReader.Load(row);
                        }
                    }
                }

                // return value
                return method;
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

            #region InsertMethod()
            /// <summary>
            /// This method inserts a 'Method' object.
            /// This method uses the 'Method_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertMethod(InsertMethodStoredProcedure insertMethodProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertMethodProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateMethod()
            /// <summary>
            /// This method updates a 'Method'.
            /// This method uses the 'Method_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateMethod(UpdateMethodStoredProcedure updateMethodProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateMethodProc, databaseConnector);
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
