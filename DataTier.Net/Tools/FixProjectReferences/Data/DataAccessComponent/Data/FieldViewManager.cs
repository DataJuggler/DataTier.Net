

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

    #region class FieldViewManager
    /// <summary>
    /// This class is used to manage a 'FieldView' object.
    /// </summary>
    public class FieldViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FieldViewManager' object.
        /// </summary>
        public FieldViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllFieldViews()
            /// <summary>
            /// This method fetches a  'List<FieldView>' object.
            /// This method uses the 'FieldViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<FieldView>'</returns>
            /// </summary>
            public List<FieldView> FetchAllFieldViews(FetchAllFieldViewsStoredProcedure fetchAllFieldViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<FieldView> fieldViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFieldViewsDataSet = this.DataHelper.LoadDataSet(fetchAllFieldViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFieldViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allFieldViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            fieldViewCollection = FieldViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return fieldViewCollection;
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
