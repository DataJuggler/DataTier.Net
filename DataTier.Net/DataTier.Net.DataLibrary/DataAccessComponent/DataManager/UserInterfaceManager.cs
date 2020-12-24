

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

    #region class UserInterfaceManager
    /// <summary>
    /// This class is used to manage a 'UserInterface' object.
    /// </summary>
    public class UserInterfaceManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UserInterfaceManager' object.
        /// </summary>
        public UserInterfaceManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteUserInterface()
            /// <summary>
            /// This method deletes a 'UserInterface' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteUserInterface(DeleteUserInterfaceStoredProcedure deleteUserInterfaceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteUserInterfaceProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllUserInterfaces()
            /// <summary>
            /// This method fetches a  'List<UserInterface>' object.
            /// This method uses the 'UserInterfaces_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<UserInterface>'</returns>
            /// </summary>
            public List<UserInterface> FetchAllUserInterfaces(FetchAllUserInterfacesStoredProcedure fetchAllUserInterfacesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<UserInterface> userInterfaceCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allUserInterfacesDataSet = this.DataHelper.LoadDataSet(fetchAllUserInterfacesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allUserInterfacesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allUserInterfacesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            userInterfaceCollection = UserInterfaceReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return userInterfaceCollection;
            }
            #endregion

            #region FindUserInterface()
            /// <summary>
            /// This method finds a  'UserInterface' object.
            /// This method uses the 'UserInterface_Find' procedure.
            /// </summary>
            /// <returns>A 'UserInterface' object.</returns>
            /// </summary>
            public UserInterface FindUserInterface(FindUserInterfaceStoredProcedure findUserInterfaceProc, DataConnector databaseConnector)
            {
                // Initial Value
                UserInterface userInterface = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet userInterfaceDataSet = this.DataHelper.LoadDataSet(findUserInterfaceProc, databaseConnector);

                    // Verify DataSet Exists
                    if(userInterfaceDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(userInterfaceDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load UserInterface
                            userInterface = UserInterfaceReader.Load(row);
                        }
                    }
                }

                // return value
                return userInterface;
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

            #region InsertUserInterface()
            /// <summary>
            /// This method inserts a 'UserInterface' object.
            /// This method uses the 'UserInterface_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertUserInterface(InsertUserInterfaceStoredProcedure insertUserInterfaceProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertUserInterfaceProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateUserInterface()
            /// <summary>
            /// This method updates a 'UserInterface'.
            /// This method uses the 'UserInterface_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateUserInterface(UpdateUserInterfaceStoredProcedure updateUserInterfaceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateUserInterfaceProc, databaseConnector);
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
