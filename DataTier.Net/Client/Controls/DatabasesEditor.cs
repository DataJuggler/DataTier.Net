
#region using statements

using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using System;
using System.Windows.Forms;
using DataTierClient.Forms;
using DataGateway;
using ObjectLibrary.BusinessObjects;

#endregion

namespace DataTierClient.Controls
{

    #region class DatabasesEditor : BaseWizardControl, IWizardControl
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class DatabasesEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private DTNDatabase selectedDatabase;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a DatabasesEditor.
        /// </summary>
        public DatabasesEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region AddButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This method adds a new database to this project.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void AddButton_Click(object sender, EventArgs e)
            {
                // Add Database
                EditDatabase(new DTNDatabase());
            }
            #endregion

            #region DatabasesListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// The DatabasesListBox selected item has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DatabasesListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Set selected database
                this.SelectedDatabase = this.DatabasesListBox.SelectedItem as DTNDatabase;
                
                // Enable controls
                UIEnable();
            } 
            #endregion

            #region DeleteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The Delete Button Was Clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DeleteButton_Click(object sender, EventArgs e)
            {
                // Delete the selected database
                DeleteDatabase();
            }
            #endregion

            #region EditButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The Edit Button Was Clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditButton_Click(object sender, EventArgs e)
            {
                // Edit the selected database
                EditDatabase(this.SelectedDatabase);
            }
            #endregion

			#region EditEnumerationsButton_Click(object sender, EventArgs e)
			/// <summary>
			/// This method edits the enumerations for a project.
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void EditEnumerationsButton_Click(object sender, EventArgs e)
			{
				// Edit Enumerations
				EditEnumerations();
			}
			#endregion
        
        #endregion

        #region Methods

            #region DeleteDatabase()
            /// <summary>
            /// This method deletes the selected database.
            /// </summary>
            private void DeleteDatabase()
            {
                // verify all of the objects exist
                if ((this.HasSelectedDatabase) && (this.HasParentProjectWizard) && (this.ParentProjectWizard.HasParentMainForm))
                {
                    // get user confirmation to delete
                    bool confirmed = this.ParentProjectWizard.ParentMainForm.ConfirmDelete("Database", this.SelectedDatabase.DatabaseName);
                    
                    // if confirmed
                    if (confirmed)
                    {
                        // Create instance of the gateway
                        Gateway gateway = new Gateway();
                        
                        // Delete the selected database
                        bool deleted = gateway.DeleteDTNDatabase(this.SelectedDatabase.DatabaseId);
                        
                        // If the delete was successful
                        if (deleted)
                        {   
                            // Reload the databases after a delete
                            this.SelectedProject.Databases = gateway.LoadProjectDatabases(this.SelectedProject.ProjectId);
                            
                            // Redisplay
                            this.DisplaySelectedProject();
                        }
                    }
                }
            } 
            #endregion

            #region DisplaySelectedProject()
            /// <summary>
            /// Display the selected project.
            /// </summary>
            public void DisplaySelectedProject()
            {
                try
                {
                    // Clear Listbox
                    this.DatabasesListBox.Items.Clear();

                    // loop through each database
                    foreach (DTNDatabase database in this.SelectedProject.Databases)
                    {
                        // if the database exists
                        if ((database != null) && (!String.IsNullOrEmpty(database.DatabaseName)))
                        {
                            // Add this database
                            this.DatabasesListBox.Items.Add(database);
                        }
                    }

                    // Refresh
                    this.Refresh();
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

            #region EditDatabase(DTNDatabase database)
            /// <summary>
            /// This method adds a new database to the selected project.
            /// </summary>
            private void EditDatabase(DTNDatabase database)
            {
                // If the selected project exists
                if (this.SelectedProject != null)
                {
                    // Create instance of Database SelectorForm
                    DatabaseSelectorForm databaseForm = new DatabaseSelectorForm();

                    // Set selected project
                    databaseForm.DatabaseSelectorControl.Setup(this.SelectedProject, database);

                    // Show Dialog
                    databaseForm.ShowDialog();

                    // if the user did not cancel
                    if (!databaseForm.DatabaseSelectorControl.UserCancelled)
                    {
                        // if the selected project exists and the SelectedDatabase exists on the databaseForm
                        if ((this.HasSelectedProject) && (databaseForm.DatabaseSelectorControl.SelectedDatabase != null))
                        {
                            // Get the index of this database
                            int index = this.SelectedProject.GetDatabaseIndex(databaseForm.DatabaseSelectorControl.SelectedDatabase.DatabaseId);

                            // if the index was found
                            if (index >= 0)
                            {
                                // remove this database
                                this.SelectedProject.Databases.RemoveAt(index);
                            }

                            // Add the selected database
                            this.SelectedProject.Databases.Add(databaseForm.DatabaseSelectorControl.SelectedDatabase);

                            // Display Database
                            this.DisplaySelectedProject();
                        }
                    }
                }
            }
            #endregion

			#region EditEnumerations()
			/// <summary>
			/// This method edits the enumerations for a project.
			/// </summary>
			private void EditEnumerations()
			{
				
			}  
			#endregion

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// </summary>
            public void Init()
            {
                // Set Dock To Fill
                this.Dock = DockStyle.Fill;

                // Set Next Control
                this.NextControl = ActiveControlEnum.DataObjectsTab;

                // Set Previous Control
                this.PrevControl = ActiveControlEnum.ProjectsTab;

                // Enable Controls
                UIEnable();
            }
            #endregion

            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // determine action by the button text
                switch (tabButton.ButtonText)
                {
                    case "Add":

                        // call the AddButton_Click event
                        AddButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditButton_Click event
                        EditButton_Click(this, null);

                        // required
                        break;

                    case "Delete":

                        // Call the DeleteButton_Click event
                        DeleteButton_Click(this, null);

                        // required
                        break;
                }
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method enables the controls on this form.
            /// </summary>
            private void UIEnable()
            {
                // local
                bool enabled = this.HasSelectedDatabase;

                // always enable the Add button
                this.AddButton.Enabled = true;
                this.AddButton.Selected = true;

                // Enable the buttons
                this.EditButton.Enabled = enabled;
                this.DeleteButton.Enabled = enabled;
            } 
            #endregion

            #region ValidateSelectedProject()
            /// <summary>
            /// Validate the selected project.
            /// </summary>
            public bool ValidateSelectedProject()
            {
                // initial value
                bool valid = false;

                // return value
                return valid;
            }
            #endregion

        #endregion

        #region Properties
            
            #region EditMode
            /// <summary>
            /// Is this an existing project or a new project.
            /// </summary>
            public bool EditMode
            {
                get
                {
                    // initial value
                    bool editMode = false;

                    // if the SelectedProject exists
                    if (this.SelectedProject != null)
                    {
                        // Is this a new project or not.
                        editMode = (!this.SelectedProject.IsNew);
                    }

                    // return value
                    return editMode;
                }
            }
            #endregion

            #region HasSelectedDatabase
            /// <summary>
            /// Does this object have a selected Database.
            /// </summary>
            public bool HasSelectedDatabase
            {
                get
                {
                    // initial value
                    bool hasSelectedDatabase = (this.SelectedDatabase != null);

                    // return value
                    return hasSelectedDatabase;
                }
            } 
            #endregion

            #region HasParentProjectWizard
            /// <summary>
            /// Does this object have a ParentProjectWizard.
            /// This object returns true if the ParentProjectWizard
            /// exists; else false.
            /// </summary>
            public bool HasParentProjectWizard
            {
                get
                {
                    // intitial value
                    bool hasParentProjectWizard = (this.ParentProjectWizard != null);

                    // return value
                    return hasParentProjectWizard;
                }
            }
            #endregion

            #region HasSelectedProject
            /// <summary>
            /// Does this object have a SelectedProject.
            /// This object returns true if the SelectedProject
            /// exists; else false.
            /// </summary>
            public bool HasSelectedProject
            {
                get
                {
                    // intitial value
                    bool hasSelectedProject = (this.SelectedProject != null);

                    // return value
                    return hasSelectedProject;
                }
            }
            #endregion

            #region NextControl
            /// <summary>
            /// The NextControl to move to.
            /// </summary>
            public ActiveControlEnum NextControl
            {
                get { return nextControl; }
                set { nextControl = value; }
            }
            #endregion

            #region ParentProjectWizard
            /// <summary>
            /// The parent ProjectWizardControl that this object 
            /// sits on.
            /// </summary>
            public ProjectWizardControl ParentProjectWizard
            {
                get
                {
                    // Initial Value
                    ProjectWizardControl projectWizardControl = null;

                    // get a reference to this objects parent (Cast as a Panel).
                    Panel mainPanel = this.Parent as Panel;

                    // if mainPanel exists
                    if (mainPanel != null)
                    {
                        // set projectWizardControl
                        projectWizardControl = mainPanel.Parent as ProjectWizardControl;
                    }

                    // return value
                    return projectWizardControl;
                }
            }
            #endregion

            #region PrevControl
            /// <summary>
            /// The previous control to move to.
            /// </summary>
            public ActiveControlEnum PrevControl
            {
                get { return prevControl; }
                set { prevControl = value; }
            }
            #endregion  
            
            #region SelectedDatabase
            /// <summary>
            /// The database currently selected.
            /// </summary>
            public DTNDatabase SelectedDatabase
            {
                get { return selectedDatabase; }
                set { selectedDatabase = value; }
            } 
            #endregion

            #region SelectedProject
            /// <summary>
            /// This property is the selected Project
            /// being created or edited.
            /// </summary>
            public Project SelectedProject
            {
                get
                {
                    // initial value
                    Project selectedProject = null;

                    // does this object have a ParentProjectWizard
                    if (this.HasParentProjectWizard)
                    {
                        // Get the selected object from the ParentProjectWizard.
                        selectedProject = this.ParentProjectWizard.SelectedProject;
                    }

                    // return value
                    return selectedProject;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
