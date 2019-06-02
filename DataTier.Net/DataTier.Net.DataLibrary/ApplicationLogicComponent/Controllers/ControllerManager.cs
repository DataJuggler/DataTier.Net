

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private CustomReaderController customreaderController;
        private DTNDatabaseController dtndatabaseController;
        private DTNFieldController dtnfieldController;
        private DTNProcedureController dtnprocedureController;
        private DTNTableController dtntableController;
        private EnumerationController enumerationController;
        private FieldSetController fieldsetController;
        private FieldSetFieldController fieldsetfieldController;
        private FieldSetFieldViewController fieldsetfieldviewController;
        private MethodController methodController;
        private ProjectController projectController;
        private ProjectReferenceController projectreferenceController;
        private ReferencesSetController referencessetController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.CustomReaderController = new CustomReaderController(this.ErrorProcessor, this.AppController);
                this.DTNDatabaseController = new DTNDatabaseController(this.ErrorProcessor, this.AppController);
                this.DTNFieldController = new DTNFieldController(this.ErrorProcessor, this.AppController);
                this.DTNProcedureController = new DTNProcedureController(this.ErrorProcessor, this.AppController);
                this.DTNTableController = new DTNTableController(this.ErrorProcessor, this.AppController);
                this.EnumerationController = new EnumerationController(this.ErrorProcessor, this.AppController);
                this.FieldSetController = new FieldSetController(this.ErrorProcessor, this.AppController);
                this.FieldSetFieldController = new FieldSetFieldController(this.ErrorProcessor, this.AppController);
                this.FieldSetFieldViewController = new FieldSetFieldViewController(this.ErrorProcessor, this.AppController);
                this.MethodController = new MethodController(this.ErrorProcessor, this.AppController);
                this.ProjectController = new ProjectController(this.ErrorProcessor, this.AppController);
                this.ProjectReferenceController = new ProjectReferenceController(this.ErrorProcessor, this.AppController);
                this.ReferencesSetController = new ReferencesSetController(this.ErrorProcessor, this.AppController);
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

            #region CustomReaderController
            public CustomReaderController CustomReaderController
            {
                get { return customreaderController; }
                set { customreaderController = value; }
            }
            #endregion

            #region DTNDatabaseController
            public DTNDatabaseController DTNDatabaseController
            {
                get { return dtndatabaseController; }
                set { dtndatabaseController = value; }
            }
            #endregion

            #region DTNFieldController
            public DTNFieldController DTNFieldController
            {
                get { return dtnfieldController; }
                set { dtnfieldController = value; }
            }
            #endregion

            #region DTNProcedureController
            public DTNProcedureController DTNProcedureController
            {
                get { return dtnprocedureController; }
                set { dtnprocedureController = value; }
            }
            #endregion

            #region DTNTableController
            public DTNTableController DTNTableController
            {
                get { return dtntableController; }
                set { dtntableController = value; }
            }
            #endregion

            #region EnumerationController
            public EnumerationController EnumerationController
            {
                get { return enumerationController; }
                set { enumerationController = value; }
            }
            #endregion

            #region FieldSetController
            public FieldSetController FieldSetController
            {
                get { return fieldsetController; }
                set { fieldsetController = value; }
            }
            #endregion

            #region FieldSetFieldController
            public FieldSetFieldController FieldSetFieldController
            {
                get { return fieldsetfieldController; }
                set { fieldsetfieldController = value; }
            }
            #endregion

            #region FieldSetFieldViewController
            public FieldSetFieldViewController FieldSetFieldViewController
            {
                get { return fieldsetfieldviewController; }
                set { fieldsetfieldviewController = value; }
            }
            #endregion

            #region MethodController
            public MethodController MethodController
            {
                get { return methodController; }
                set { methodController = value; }
            }
            #endregion

            #region ProjectController
            public ProjectController ProjectController
            {
                get { return projectController; }
                set { projectController = value; }
            }
            #endregion

            #region ProjectReferenceController
            public ProjectReferenceController ProjectReferenceController
            {
                get { return projectreferenceController; }
                set { projectreferenceController = value; }
            }
            #endregion

            #region ReferencesSetController
            public ReferencesSetController ReferencesSetController
            {
                get { return referencessetController; }
                set { referencessetController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
