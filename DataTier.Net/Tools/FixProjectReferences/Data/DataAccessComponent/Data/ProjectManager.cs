

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

    #region class ProjectManager
    /// <summary>
    /// This class is used to manage a 'Project' object.
    /// </summary>
    public class ProjectManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ProjectManager' object.
        /// </summary>
        public ProjectManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteProject()
            /// <summary>
            /// This method deletes a 'Project' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteProject(DeleteProjectStoredProcedure deleteProjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteProjectProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllProjects()
            /// <summary>
            /// This method fetches a  'List<Project>' object.
            /// This method uses the 'Projects_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Project>'</returns>
            /// </summary>
            public List<Project> FetchAllProjects(FetchAllProjectsStoredProcedure fetchAllProjectsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Project> projectCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allProjectsDataSet = this.DataHelper.LoadDataSet(fetchAllProjectsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allProjectsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allProjectsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            projectCollection = ProjectReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return projectCollection;
            }
            #endregion

            #region FindProject()
            /// <summary>
            /// This method finds a  'Project' object.
            /// This method uses the 'Project_Find' procedure.
            /// </summary>
            /// <returns>A 'Project' object.</returns>
            /// </summary>
            public Project FindProject(FindProjectStoredProcedure findProjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                Project project = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet projectDataSet = this.DataHelper.LoadDataSet(findProjectProc, databaseConnector);

                    // Verify DataSet Exists
                    if(projectDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(projectDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Project
                            project = ProjectReader.Load(row);
                        }
                    }
                }

                // return value
                return project;
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

            #region InsertProject()
            /// <summary>
            /// This method inserts a 'Project' object.
            /// This method uses the 'Project_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertProject(InsertProjectStoredProcedure insertProjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertProjectProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateProject()
            /// <summary>
            /// This method updates a 'Project'.
            /// This method uses the 'Project_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateProject(UpdateProjectStoredProcedure updateProjectProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateProjectProc, databaseConnector);
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
