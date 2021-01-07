

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private AdminMethods adminMethods;
        private CustomReaderMethods customreaderMethods;
        private DTNDatabaseMethods dtndatabaseMethods;
        private DTNFieldMethods dtnfieldMethods;
        private DTNProcedureMethods dtnprocedureMethods;
        private DTNTableMethods dtntableMethods;
        private EnumerationMethods enumerationMethods;
        private FieldSetMethods fieldsetMethods;
        private FieldSetFieldMethods fieldsetfieldMethods;
        private FieldSetFieldViewMethods fieldsetfieldviewMethods;
        private MethodMethods methodMethods;
        private ProjectMethods projectMethods;
        private ProjectReferenceMethods projectreferenceMethods;
        private ReferencesSetMethods referencessetMethods;
        private UIFieldMethods uifieldMethods;
        private UserInterfaceMethods userinterfaceMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.AdminMethods = new AdminMethods(this.DataManager);
                this.CustomReaderMethods = new CustomReaderMethods(this.DataManager);
                this.DTNDatabaseMethods = new DTNDatabaseMethods(this.DataManager);
                this.DTNFieldMethods = new DTNFieldMethods(this.DataManager);
                this.DTNProcedureMethods = new DTNProcedureMethods(this.DataManager);
                this.DTNTableMethods = new DTNTableMethods(this.DataManager);
                this.EnumerationMethods = new EnumerationMethods(this.DataManager);
                this.FieldSetMethods = new FieldSetMethods(this.DataManager);
                this.FieldSetFieldMethods = new FieldSetFieldMethods(this.DataManager);
                this.FieldSetFieldViewMethods = new FieldSetFieldViewMethods(this.DataManager);
                this.MethodMethods = new MethodMethods(this.DataManager);
                this.ProjectMethods = new ProjectMethods(this.DataManager);
                this.ProjectReferenceMethods = new ProjectReferenceMethods(this.DataManager);
                this.ReferencesSetMethods = new ReferencesSetMethods(this.DataManager);
                this.UIFieldMethods = new UIFieldMethods(this.DataManager);
                this.UserInterfaceMethods = new UserInterfaceMethods(this.DataManager);
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager
            public DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region AdminMethods
            public AdminMethods AdminMethods
            {
                get { return adminMethods; }
                set { adminMethods = value; }
            }
            #endregion

            #region CustomReaderMethods
            public CustomReaderMethods CustomReaderMethods
            {
                get { return customreaderMethods; }
                set { customreaderMethods = value; }
            }
            #endregion

            #region DTNDatabaseMethods
            public DTNDatabaseMethods DTNDatabaseMethods
            {
                get { return dtndatabaseMethods; }
                set { dtndatabaseMethods = value; }
            }
            #endregion

            #region DTNFieldMethods
            public DTNFieldMethods DTNFieldMethods
            {
                get { return dtnfieldMethods; }
                set { dtnfieldMethods = value; }
            }
            #endregion

            #region DTNProcedureMethods
            public DTNProcedureMethods DTNProcedureMethods
            {
                get { return dtnprocedureMethods; }
                set { dtnprocedureMethods = value; }
            }
            #endregion

            #region DTNTableMethods
            public DTNTableMethods DTNTableMethods
            {
                get { return dtntableMethods; }
                set { dtntableMethods = value; }
            }
            #endregion

            #region EnumerationMethods
            public EnumerationMethods EnumerationMethods
            {
                get { return enumerationMethods; }
                set { enumerationMethods = value; }
            }
            #endregion

            #region FieldSetMethods
            public FieldSetMethods FieldSetMethods
            {
                get { return fieldsetMethods; }
                set { fieldsetMethods = value; }
            }
            #endregion

            #region FieldSetFieldMethods
            public FieldSetFieldMethods FieldSetFieldMethods
            {
                get { return fieldsetfieldMethods; }
                set { fieldsetfieldMethods = value; }
            }
            #endregion

            #region FieldSetFieldViewMethods
            public FieldSetFieldViewMethods FieldSetFieldViewMethods
            {
                get { return fieldsetfieldviewMethods; }
                set { fieldsetfieldviewMethods = value; }
            }
            #endregion

            #region MethodMethods
            public MethodMethods MethodMethods
            {
                get { return methodMethods; }
                set { methodMethods = value; }
            }
            #endregion

            #region ProjectMethods
            public ProjectMethods ProjectMethods
            {
                get { return projectMethods; }
                set { projectMethods = value; }
            }
            #endregion

            #region ProjectReferenceMethods
            public ProjectReferenceMethods ProjectReferenceMethods
            {
                get { return projectreferenceMethods; }
                set { projectreferenceMethods = value; }
            }
            #endregion

            #region ReferencesSetMethods
            public ReferencesSetMethods ReferencesSetMethods
            {
                get { return referencessetMethods; }
                set { referencessetMethods = value; }
            }
            #endregion

            #region UIFieldMethods
            public UIFieldMethods UIFieldMethods
            {
                get { return uifieldMethods; }
                set { uifieldMethods = value; }
            }
            #endregion

            #region UserInterfaceMethods
            public UserInterfaceMethods UserInterfaceMethods
            {
                get { return userinterfaceMethods; }
                set { userinterfaceMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
