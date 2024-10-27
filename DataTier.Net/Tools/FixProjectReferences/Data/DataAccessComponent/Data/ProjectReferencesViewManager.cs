

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

    #region class ProjectReferencesViewManager
    /// <summary>
    /// This class is used to manage a 'ProjectReferencesView' object.
    /// </summary>
    public class ProjectReferencesViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ProjectReferencesViewManager' object.
        /// </summary>
        public ProjectReferencesViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllProjectReferencesViews()
            /// <summary>
            /// This method fetches a  'List<ProjectReferencesView>' object.
            /// This method uses the 'ProjectReferencesViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ProjectReferencesView>'</returns>
            /// </summary>
            public List<ProjectReferencesView> FetchAllProjectReferencesViews(FetchAllProjectReferencesViewsStoredProcedure fetchAllProjectReferencesViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ProjectReferencesView> projectReferencesViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allProjectReferencesViewsDataSet = this.DataHelper.LoadDataSet(fetchAllProjectReferencesViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allProjectReferencesViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allProjectReferencesViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            projectReferencesViewCollection = ProjectReferencesViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return projectReferencesViewCollection;
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
