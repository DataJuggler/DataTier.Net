

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

    #region class ProjectReferenceManager
    /// <summary>
    /// This class is used to manage a 'ProjectReference' object.
    /// </summary>
    public class ProjectReferenceManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ProjectReferenceManager' object.
        /// </summary>
        public ProjectReferenceManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteProjectReference()
            /// <summary>
            /// This method deletes a 'ProjectReference' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteProjectReference(DeleteProjectReferenceStoredProcedure deleteProjectReferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteProjectReferenceProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllProjectReferences()
            /// <summary>
            /// This method fetches a  'List<ProjectReference>' object.
            /// This method uses the 'ProjectReferences_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ProjectReference>'</returns>
            /// </summary>
            public List<ProjectReference> FetchAllProjectReferences(FetchAllProjectReferencesStoredProcedure fetchAllProjectReferencesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ProjectReference> projectReferenceCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allProjectReferencesDataSet = this.DataHelper.LoadDataSet(fetchAllProjectReferencesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allProjectReferencesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allProjectReferencesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            projectReferenceCollection = ProjectReferenceReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return projectReferenceCollection;
            }
            #endregion

            #region FindProjectReference()
            /// <summary>
            /// This method finds a  'ProjectReference' object.
            /// This method uses the 'ProjectReference_Find' procedure.
            /// </summary>
            /// <returns>A 'ProjectReference' object.</returns>
            /// </summary>
            public ProjectReference FindProjectReference(FindProjectReferenceStoredProcedure findProjectReferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                ProjectReference projectReference = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet projectReferenceDataSet = this.DataHelper.LoadDataSet(findProjectReferenceProc, databaseConnector);

                    // Verify DataSet Exists
                    if(projectReferenceDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(projectReferenceDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ProjectReference
                            projectReference = ProjectReferenceReader.Load(row);
                        }
                    }
                }

                // return value
                return projectReference;
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

            #region InsertProjectReference()
            /// <summary>
            /// This method inserts a 'ProjectReference' object.
            /// This method uses the 'ProjectReference_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertProjectReference(InsertProjectReferenceStoredProcedure insertProjectReferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertProjectReferenceProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateProjectReference()
            /// <summary>
            /// This method updates a 'ProjectReference'.
            /// This method uses the 'ProjectReference_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateProjectReference(UpdateProjectReferenceStoredProcedure updateProjectReferenceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateProjectReferenceProc, databaseConnector);
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
