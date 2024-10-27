

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

    #region class AdminManager
    /// <summary>
    /// This class is used to manage a 'Admin' object.
    /// </summary>
    public class AdminManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'AdminManager' object.
        /// </summary>
        public AdminManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteAdmin()
            /// <summary>
            /// This method deletes a 'Admin' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteAdmin(DeleteAdminStoredProcedure deleteAdminProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteAdminProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllAdmins()
            /// <summary>
            /// This method fetches a  'List<Admin>' object.
            /// This method uses the 'Admins_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Admin>'</returns>
            /// </summary>
            public List<Admin> FetchAllAdmins(FetchAllAdminsStoredProcedure fetchAllAdminsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Admin> adminCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allAdminsDataSet = this.DataHelper.LoadDataSet(fetchAllAdminsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allAdminsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allAdminsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            adminCollection = AdminReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return adminCollection;
            }
            #endregion

            #region FindAdmin()
            /// <summary>
            /// This method finds a  'Admin' object.
            /// This method uses the 'Admin_Find' procedure.
            /// </summary>
            /// <returns>A 'Admin' object.</returns>
            /// </summary>
            public Admin FindAdmin(FindAdminStoredProcedure findAdminProc, DataConnector databaseConnector)
            {
                // Initial Value
                Admin admin = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet adminDataSet = this.DataHelper.LoadDataSet(findAdminProc, databaseConnector);

                    // Verify DataSet Exists
                    if(adminDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(adminDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Admin
                            admin = AdminReader.Load(row);
                        }
                    }
                }

                // return value
                return admin;
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

            #region InsertAdmin()
            /// <summary>
            /// This method inserts a 'Admin' object.
            /// This method uses the 'Admin_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertAdmin(InsertAdminStoredProcedure insertAdminProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertAdminProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateAdmin()
            /// <summary>
            /// This method updates a 'Admin'.
            /// This method uses the 'Admin_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateAdmin(UpdateAdminStoredProcedure updateAdminProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateAdminProc, databaseConnector);
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
