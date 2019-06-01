

#region using statements

using System;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;

#endregion


namespace DataTierClient.Controls
{

    #region class DatabaseSelectorControl : UserControl, ISaveCancelControl
    /// <summary>
    /// This control is used to select a SQLServer database.
    /// </summary>
    public partial class DatabaseSelectorControl : UserControl, ISaveCancelControl
    {
    
        #region Private Variables
        private DTNDatabase selectedDatabase;
        private Project selectedProject;
        private bool userCancelled;
		#endregion
    
        #region Constructor()
        /// <summary>
        /// Create a new instance of a DatabaseSelectorControl.
        /// </summary>
        public DatabaseSelectorControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Init
            Init();
        }
        #endregion
        
        #region Events

        #endregion
        
        #region Methods

            #region CaptureSelectedDatabase()
            /// <summary>
            /// This method captures the selected database.
            /// </summary>
            private void CaptureSelectedDatabase()
            {
               // Capture Selected Database
               this.SqlDatabaseEditor.CaptureSelectedDatabase();
            }
            #endregion

            #region DisplaySelectedDatabase()
            /// <summary>
            /// Display the selected database.
            /// </summary>
            public void DisplaySelectedDatabase()
            {
                // Set sql To Visible
                this.SqlDatabaseEditor.Visible = true;
                    
                // Display the selected database on the sql Database Editor
                this.SqlDatabaseEditor.DisplaySelectedDatabase();
            }
            #endregion

            #region EnableSaveButton(bool enable)
            /// <summary>
            /// This method returns the Save Button
            /// </summary>
            internal void EnableSaveButton(bool enable)
            {
                // Enable or disable the Save button
                this.SaveCancelControl.EnableSaveButton(enable);
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// Perform any initializations for this object.
            /// </summary>
            private void Init()
            {  
                // Set BorderStyle to None
                this.BorderStyle = BorderStyle.None;
                
                // Default to user cancelled
                this.UserCancelled = true;
                
                // Show the controls
                UIVisibility();
            }
            #endregion

            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the ParentForm exists
                if (this.HasParentDatabaseSelectorForm)
                {
                    // Close Form
                    this.ParentDatabaseSelectorForm.Close();
                }
            }
            #endregion
            
            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// </summary>
            public void OnSave()
            {
                try
                {
                    // Capture the selected database
                    CaptureSelectedDatabase();

                    // User Did Not Cancel
                    this.UserCancelled = false;

                    // If the ParentForm exists
                    if (this.HasParentDatabaseSelectorForm)
                    {
                        // Close Form
                        this.ParentDatabaseSelectorForm.Close();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

            #region Setup(Project selectedProjectArg, DTNDatabase databaseArg)
            /// <summary>
            /// This method prepares this control to be launched.
            /// </summary>
            /// <param name="selectedProjectArg"></param>
            internal void Setup(Project selectedProjectArg, DTNDatabase databaseArg)
            {
                // set selected project
                this.SelectedProject = selectedProjectArg;
                
                // set SelectedDatabase
                this.SelectedDatabase = databaseArg;
                
                // If this is not a new database (this is an edit)
                if(!this.SelectedDatabase.IsNew)
                {   
                    // if the form exists
                    if(this.HasParentDatabaseSelectorForm)
                    {
                        // Change the text
                        this.ParentDatabaseSelectorForm.Text = "Edit Database";
                    }
                    
                    // Display the selected database
                    this.DisplaySelectedDatabase();
                }
            }
            #endregion

            #region UIVisibility()
            /// <summary>
            /// This method sets the visible control. 
            /// </summary>
            private void UIVisibility()
            {
                // This is SQLServer
                this.SqlDatabaseEditor.Visible = true;
                this.SqlDatabaseEditor.BringToFront();
               
                // Refresh
                this.Refresh();
            }
            #endregion
        
        #endregion
        
        #region Properties

            #region HasParentDatabaseSelectorForm
            /// <summary>
            /// Does this object have a parent database selector form.
            /// </summary>
            public bool HasParentDatabaseSelectorForm
            {
                get
                {
                    // initial value
                    bool hasParentDatabaseSelectorForm = (this.ParentDatabaseSelectorForm != null);
                    
                    // return value
                    return hasParentDatabaseSelectorForm;
                }
            }
            #endregion.

            #region ParentDatabaseSelectorForm
            /// <summary>
            /// This property is a reference to the DatabaseSelectorForm
            /// that this control sits on.
            /// </summary>
            public DatabaseSelectorForm ParentDatabaseSelectorForm
            {
                get
                {
                    // initial value
                    DatabaseSelectorForm parentForm = this.ParentForm as DatabaseSelectorForm;
                    
                    // return value
                    return parentForm;
                }
            }
            #endregion

            #region SelectedDatabase
            /// <summary>
            /// The SelectedDatabase being created or edited.
            /// </summary>
            public DTNDatabase SelectedDatabase
            {
                get { return selectedDatabase; }
                set { selectedDatabase = value; }
            }
            #endregion

            #region SelectedProject
            /// <summary>
            /// The SelectedProject being edited or created.
            /// </summary>
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
            }
            #endregion

            #region UserCancelled
            /// <summary>
            /// Did the user cancel this addnew or edit.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
            #endregion
        
        #endregion


    }
    #endregion
    
}
