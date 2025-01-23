

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

    #region class FieldSetFieldViewManager
    /// <summary>
    /// This class is used to manage a 'FieldSetFieldView' object.
    /// </summary>
    public class FieldSetFieldViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FieldSetFieldViewManager' object.
        /// </summary>
        public FieldSetFieldViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllFieldSetFieldViews()
            /// <summary>
            /// This method fetches a  'List<FieldSetFieldView>' object.
            /// This method uses the 'FieldSetFieldViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<FieldSetFieldView>'</returns>
            /// </summary>
            public static List<FieldSetFieldView> FetchAllFieldSetFieldViews(FetchAllFieldSetFieldViewsStoredProcedure fetchAllFieldSetFieldViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<FieldSetFieldView> fieldSetFieldViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFieldSetFieldViewsDataSet = DataHelper.LoadDataSet(fetchAllFieldSetFieldViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFieldSetFieldViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allFieldSetFieldViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            fieldSetFieldViewCollection = FieldSetFieldViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return fieldSetFieldViewCollection;
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
