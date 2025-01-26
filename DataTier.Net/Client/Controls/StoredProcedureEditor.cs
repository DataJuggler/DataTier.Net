
#region using statements

using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using DataTierClient.ClientUtil;

#endregion

namespace DataTierClient.Controls
{

    #region class StoredProcedureEditor : UserControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class StoredProcedureEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private ReferencesSet selectedReferencesSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a StoredProcedureEditor.
        /// </summary>
        public StoredProcedureEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseStoredProcedureFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the StoredProcedureFolder button.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseStoredProcedureFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DialogHelper.ChooseFolder(this.StoredProcedureFolderTextBox, this.ProjectFolder);  
            }
            #endregion

            #region BrowseStoredProcedureSQLFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the StoredProcedureSQLFolder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseStoredProcedureSQLFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DialogHelper.ChooseFolder(this.StoredProcedureSQLFolderTextBox, this.ProjectFolder);  
            }
            #endregion

            #region StoredProcedureFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the StoredProcedureFolder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void StoredProcedureFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the Folder
                    this.SelectedProject.StoredProcedureObjectFolder = this.StoredProcedureFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }       
            } 
            #endregion

            #region StoredProcedureNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event sets the StoredProcedureNamespace.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void StoredProcedureNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the Namespace
                    this.SelectedProject.StoredProcedureObjectNamespace = this.StoredProcedureNamespaceTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            } 
            #endregion

            #region StoredProcedureSQLFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The StoredProcedureSQLFolder has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void StoredProcedureSQLFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the Folder
                    this.SelectedProject.StoredProcsFolder = this.StoredProcedureSQLFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }       
            } 
            #endregion
        
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// </summary>
            public void Init()
            {
                // Set Dock To Fill
                this.Dock = DockStyle.Fill;

                // Set Next Control
                this.NextControl = ActiveControlEnum.NotSet;

                // Set PrevControl
                this.PrevControl = ActiveControlEnum.WritersTab;
                
                // Enable Controls
                UIEnable();
            }
            #endregion

            #region DisplaySelectedProject()
            /// <summary>
            /// Display the selected project.
            /// </summary>
            public void DisplaySelectedProject()
            {
                // if the selected project exists
                if (this.HasSelectedProject)
                {
                    // display the folder
                    this.StoredProcedureFolderTextBox.Text = this.SelectedProject.StoredProcedureObjectFolder;

                    // display the namespace
                    this.StoredProcedureNamespaceTextBox.Text = this.SelectedProject.StoredProcedureObjectNamespace;

                    // Display the stored procs folder
                    this.StoredProcedureSQLFolderTextBox.Text = this.SelectedProject.StoredProcsFolder;
                }

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
                    case "...":

                        if (tabButton.ButtonNumber == 1)
                        {
                            // call the BrowseStoredProcedureFolderButton_Click event
                            BrowseStoredProcedureFolderButton_Click(this, null);
                        }
                        else if (tabButton.ButtonNumber == 2)
                        {
                            // call the BrowseStoredProcedureFolderButton_Click event
                            BrowseStoredProcedureSQLFolderButton_Click(this, null);
                        }

                        // required
                        break;
                }
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method enables controls for this object.
            /// </summary>
            internal void UIEnable()
            {
                // Enable Controls
                if (this.HasParentProjectWizard)
                {
                    // Enable Controls on the project wizard
                    this.ParentProjectWizard.UIEnable();
                }
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

            #region ProjectFolder
            /// <summary>
            /// Get the ProjectFolder from the
            /// SelectedProject if any.
            /// </summary>
            public string ProjectFolder
            {
                get
                {
                    // initial value
                    string projectFolder = null;

                    // If the SelectedProject exists
                    if (this.HasSelectedProject)
                    {
                        // Get the project folder
                        projectFolder = this.SelectedProject.ProjectFolder;
                    }

                    // return value
                    return projectFolder;
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

            #region SelectedReferencesSet
            /// <summary>
            /// The selected references set being edited.
            /// </summary>
            public ReferencesSet SelectedReferencesSet
            {
                get { return selectedReferencesSet; }
                set { selectedReferencesSet = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
