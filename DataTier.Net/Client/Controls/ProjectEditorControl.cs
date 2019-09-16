
#region using statements

using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using DataJuggler.Net;
using DataTierClient.ClientUtil;
using ObjectLibrary.Enumerations;
using ObjectLibrary.BusinessObjects;
using System.IO;
using DataTierClient.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class ProjectEditorControl : UserControl, IWizardControl
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class ProjectEditorControl : UserControl, IWizardControl, ITabButtonParent
    {
        
        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        #endregion 
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a ProjectInfoControl.
        /// </summary>
        public ProjectEditorControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region BrowseProjectFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event chooses the ProjectFolder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseProjectFolderButton_Click(object sender, EventArgs e)
            {
                // Choose the folder
                DialogHelper.ChooseFolder(this.ProjectFolderTextBox, this.ProjectFolder);
            }
            #endregion

            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region DotNetCoreCheckBox_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Dot Net Core Check Box _ Checked Changed
            /// </summary>
            private void DotNetCoreCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // set the value
                    SelectedProject.DotNetCore = DotNetCoreCheckBox.Checked;
                }
            }
            #endregion
            
            #region EditEnumerationsButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This method edits the enumerations for this project.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditEnumerationsButton_Click(object sender, EventArgs e)
            {
                if (this.HasSelectedProject)
                {
                    // Create the editor form
                    EnumerationEditorForm editorForm = new EnumerationEditorForm();
                    
                    // Setup the editor form
                    editorForm.Setup(this.SelectedProject);
                    
                    // Now show the form
                    editorForm.ShowDialog();
                }
            } 
            #endregion

            #region HelpButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'HelpButton' is clicked.
            /// </summary>
            private void HelpButton_Click(object sender, EventArgs e)
            {
                // Create the helpForm
                HelpForm helpForm = new HelpForm();

                // Show the helpForm
                helpForm.ShowDialog();
            }
            #endregion
            
            #region ProjectFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the ProjectFolderTextBox has its
            /// value changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ProjectFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.HasSelectedProject)
                {
                    // Set the ProjectFolder
                    this.SelectedProject.ProjectFolder = this.ProjectFolderTextBox.Text.ToString();
                    
                    // get a reference to the ProjectFolder 
                    string projectFolder = this.SelectedProject.ProjectFolder;
                    
                    // If the ProjectFolder exists and the AutoFill is selected
                    if(!String.IsNullOrEmpty(projectFolder) && (Directory.Exists(projectFolder)) && (this.AutoFillChildFoldersCheckBox.Checked))
                    {
                        // Auto Fill The Child Folders
                        this.SelectedProject.AutoFillChildFolders();
                    }

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion

            #region ProjectNameTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the ProjectName has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ProjectNameTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the ProjectName
                    this.SelectedProject.ProjectName = this.ProjectNameTextBox.Text.ToString();

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion
        
        #endregion
        
        #region Methods

            #region DisplaySelectedProject()
            /// <summary>
            /// Display the selected project.
            /// </summary>
            public void DisplaySelectedProject()
            {
                // locals
                string projectName = "";
                string projectFolder = "";
                int index = 0;
                bool dotNetCore = false;
                
                // if the SelectedProject Exists
                if(this.SelectedProject != null)
                {
                    // set values
                    projectName = this.SelectedProject.ProjectName;
                    projectFolder = this.SelectedProject.ProjectFolder;
                    index = (int) this.SelectedProject.ClassFileOption;
                    dotNetCore = SelectedProject.DotNetCore;
                }
                
                // dislay values now
                this.ProjectNameTextBox.Text = projectName;
                this.ProjectFolderTextBox.Text = projectFolder;
                this.DotNetCoreCheckBox.Checked = dotNetCore;
                
                // Refresh
                this.Refresh();
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

                // This is the first control, there is not a previous control
                this.PrevControl = ActiveControlEnum.NotSet;

                // Set the next control
                this.NextControl = ActiveControlEnum.DatabasesTab;
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

                        // call the BrowseProjectFolderButton_Click event
                        BrowseProjectFolderButton_Click(this, null);

                        // required
                        break;

                    case "Enumerations":

                        // Call the EditEnumerationsButton_Click event
                        EditEnumerationsButton_Click(this, null);

                        // required
                        break;
                }
            }
            #endregion

            #region SetFocusToProjectNameControl()
            /// <summary>
            /// This method Set Focus To Project Name Control
            /// </summary>
            public void SetFocusToProjectNameControl()
            {
                // Set Focus To The ProjectName TextBox
                this.ProjectNameTextBox.Focus();
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method enables controls for this object.
            /// </summary>
            internal void UIEnable()
            {
                // Enable the enumeation button
                this.EnumerationsButton.Enabled = ((this.HasSelectedProject) && (!this.SelectedProject.IsNew));
            
                // Enable Controls
                if (this.HasParentProjectWizard)
                {
                    // Enable Controls on the project wizard
                    this.ParentProjectWizard.UIEnable();
                }    
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
                    if(this.HasSelectedProject)
                    {
                        // Get the project folder
                        projectFolder = this.SelectedProject.ProjectFolder;
                    }
                    
                    // return value
                    return projectFolder;
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

        #endregion

    }
    #endregion
    
}
