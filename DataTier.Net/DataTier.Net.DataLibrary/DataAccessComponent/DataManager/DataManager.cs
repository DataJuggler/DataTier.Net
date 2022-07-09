

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

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private string connectionName;
        private AdminManager adminManager;
        private CustomReaderManager customreaderManager;
        private DTNDatabaseManager dtndatabaseManager;
        private DTNFieldManager dtnfieldManager;
        private DTNProcedureManager dtnprocedureManager;
        private DTNTableManager dtntableManager;
        private EnumerationManager enumerationManager;
        private FieldSetManager fieldsetManager;
        private FieldSetFieldManager fieldsetfieldManager;
        private FieldSetFieldViewManager fieldsetfieldviewManager;
        private FieldViewManager fieldviewManager;
        private MethodManager methodManager;
        private ProjectManager projectManager;
        private ProjectReferenceManager projectreferenceManager;
        private ProjectReferencesViewManager projectreferencesviewManager;
        private ReferencesSetManager referencessetManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager(string connectionName = "")
        {
            // Store the ConnectionName arg
            this.ConnectionName = connectionName;

            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create Child Object Managers
                this.AdminManager = new AdminManager(this);
                this.CustomReaderManager = new CustomReaderManager(this);
                this.DTNDatabaseManager = new DTNDatabaseManager(this);
                this.DTNFieldManager = new DTNFieldManager(this);
                this.DTNProcedureManager = new DTNProcedureManager(this);
                this.DTNTableManager = new DTNTableManager(this);
                this.EnumerationManager = new EnumerationManager(this);
                this.FieldSetManager = new FieldSetManager(this);
                this.FieldSetFieldManager = new FieldSetFieldManager(this);
                this.FieldSetFieldViewManager = new FieldSetFieldViewManager(this);
                this.FieldViewManager = new FieldViewManager(this);
                this.MethodManager = new MethodManager(this);
                this.ProjectManager = new ProjectManager(this);
                this.ProjectReferenceManager = new ProjectReferenceManager(this);
                this.ProjectReferencesViewManager = new ProjectReferencesViewManager(this);
                this.ReferencesSetManager = new ReferencesSetManager(this);
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region ConnectionName
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region AdminManager
            public AdminManager AdminManager
            {
                get { return adminManager; }
                set { adminManager = value; }
            }
            #endregion

            #region CustomReaderManager
            public CustomReaderManager CustomReaderManager
            {
                get { return customreaderManager; }
                set { customreaderManager = value; }
            }
            #endregion

            #region DTNDatabaseManager
            public DTNDatabaseManager DTNDatabaseManager
            {
                get { return dtndatabaseManager; }
                set { dtndatabaseManager = value; }
            }
            #endregion

            #region DTNFieldManager
            public DTNFieldManager DTNFieldManager
            {
                get { return dtnfieldManager; }
                set { dtnfieldManager = value; }
            }
            #endregion

            #region DTNProcedureManager
            public DTNProcedureManager DTNProcedureManager
            {
                get { return dtnprocedureManager; }
                set { dtnprocedureManager = value; }
            }
            #endregion

            #region DTNTableManager
            public DTNTableManager DTNTableManager
            {
                get { return dtntableManager; }
                set { dtntableManager = value; }
            }
            #endregion

            #region EnumerationManager
            public EnumerationManager EnumerationManager
            {
                get { return enumerationManager; }
                set { enumerationManager = value; }
            }
            #endregion

            #region FieldSetManager
            public FieldSetManager FieldSetManager
            {
                get { return fieldsetManager; }
                set { fieldsetManager = value; }
            }
            #endregion

            #region FieldSetFieldManager
            public FieldSetFieldManager FieldSetFieldManager
            {
                get { return fieldsetfieldManager; }
                set { fieldsetfieldManager = value; }
            }
            #endregion

            #region FieldSetFieldViewManager
            public FieldSetFieldViewManager FieldSetFieldViewManager
            {
                get { return fieldsetfieldviewManager; }
                set { fieldsetfieldviewManager = value; }
            }
            #endregion

            #region FieldViewManager
            public FieldViewManager FieldViewManager
            {
                get { return fieldviewManager; }
                set { fieldviewManager = value; }
            }
            #endregion

            #region MethodManager
            public MethodManager MethodManager
            {
                get { return methodManager; }
                set { methodManager = value; }
            }
            #endregion

            #region ProjectManager
            public ProjectManager ProjectManager
            {
                get { return projectManager; }
                set { projectManager = value; }
            }
            #endregion

            #region ProjectReferenceManager
            public ProjectReferenceManager ProjectReferenceManager
            {
                get { return projectreferenceManager; }
                set { projectreferenceManager = value; }
            }
            #endregion

            #region ProjectReferencesViewManager
            public ProjectReferencesViewManager ProjectReferencesViewManager
            {
                get { return projectreferencesviewManager; }
                set { projectreferencesviewManager = value; }
            }
            #endregion

            #region ReferencesSetManager
            public ReferencesSetManager ReferencesSetManager
            {
                get { return referencessetManager; }
                set { referencessetManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
