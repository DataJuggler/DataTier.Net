

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

    #region class UIObjectManager
    /// <summary>
    /// This class is used to manage a 'UIObject' object.
    /// </summary>
    public class UIObjectManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UIObjectManager' object.
        /// </summary>
        public UIObjectManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteUIObject()
            /// <summary>
            /// This method deletes a 'UIObject' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteUIObject(DeleteUIObjectStoredProcedure deleteUIObjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteUIObjectProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllUIObjects()
            /// <summary>
            /// This method fetches a  'List<UIObject>' object.
            /// This method uses the 'UIObjects_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<UIObject>'</returns>
            /// </summary>
            public List<UIObject> FetchAllUIObjects(FetchAllUIObjectsStoredProcedure fetchAllUIObjectsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<UIObject> uIObjectCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allUIObjectsDataSet = this.DataHelper.LoadDataSet(fetchAllUIObjectsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allUIObjectsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allUIObjectsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            uIObjectCollection = UIObjectReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return uIObjectCollection;
            }
            #endregion

            #region FindUIObject()
            /// <summary>
            /// This method finds a  'UIObject' object.
            /// This method uses the 'UIObject_Find' procedure.
            /// </summary>
            /// <returns>A 'UIObject' object.</returns>
            /// </summary>
            public UIObject FindUIObject(FindUIObjectStoredProcedure findUIObjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                UIObject uIObject = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet uIObjectDataSet = this.DataHelper.LoadDataSet(findUIObjectProc, databaseConnector);

                    // Verify DataSet Exists
                    if(uIObjectDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(uIObjectDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load UIObject
                            uIObject = UIObjectReader.Load(row);
                        }
                    }
                }

                // return value
                return uIObject;
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

            #region InsertUIObject()
            /// <summary>
            /// This method inserts a 'UIObject' object.
            /// This method uses the 'UIObject_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertUIObject(InsertUIObjectStoredProcedure insertUIObjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertUIObjectProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateUIObject()
            /// <summary>
            /// This method updates a 'UIObject'.
            /// This method uses the 'UIObject_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateUIObject(UpdateUIObjectStoredProcedure updateUIObjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateUIObjectProc, databaseConnector);
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
