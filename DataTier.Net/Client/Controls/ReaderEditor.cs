
#region using statements

using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using DataTierClient.ClientUtil;
using ObjectLibrary.BusinessObjects;
using System.Linq;

#endregion

namespace DataTierClient.Controls
{

    #region class ReaderEditor : UserControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the Reader information for a project.
    /// </summary>
    public partial class ReaderEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private ReferencesSet selectedReferencesSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ReaderEditor.
        /// </summary>
        public ReaderEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseReaderFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the reader folder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseReaderFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DialogHelper.ChooseFolder(this.ReaderFolderTextBox, this.ProjectFolder);  
            }
            #endregion

            #region EditReaderReferencesSetButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Edit the references set for Readers.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditReaderReferencesSetButton_Click(object sender, EventArgs e)
            {
                // Edit the references set
                ReferencesSet refSet = ReferencesSetManager.EditReferencesSet(this.SelectedReferencesSet, this.SelectedProject);

                // Display selected references
                DisplaySelectedReferences(refSet);
            }
            #endregion

            #region ReaderFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The ReaderFolder has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReaderFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the ReaderFolder
                    this.SelectedProject.ReaderFolder = this.ReaderFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            }
            #endregion

            #region ReaderNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The ReaderNamespace has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReaderNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the ReaderFolder
                    this.SelectedProject.ReaderNamespace = this.ReaderNamespaceTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            }
            #endregion

            #region ReaderReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// The ReaderReferencesSet has chagned.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReaderReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Create the references set
                    ReferencesSet refSet = this.ReaderReferencesSetComboBox.SelectedItem as ReferencesSet;

                    // if the references set exists
                    if (refSet != null)
                    {
                        // set the SelectedReferencesSet
                        this.SelectedReferencesSet = refSet;

                        // set the ReferencesSet
                        this.SelectedProject.ReaderReferencesSet = refSet;
                       
                        // Set the ReaderReferencesSetID
                        this.SelectedProject.ReaderReferencesSetId = refSet.ReferencesSetId;
                    }

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
                this.NextControl = ActiveControlEnum.WritersTab;

                // Set PrevControl
                this.PrevControl = ActiveControlEnum.ControllersTab;
                
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
                    this.ReaderFolderTextBox.Text = this.SelectedProject.ReaderFolder;

                    // display the namespace
                    this.ReaderNamespaceTextBox.Text = this.SelectedProject.ReaderNamespace;

                    // display the object references set
                    this.DisplaySelectedReferences(this.SelectedProject.ReaderReferencesSet);
                }

                // Enable Controls
                UIEnable();
            }
            #endregion

            #region DisplaySelectedReferences(ReferencesSet refSet)
            /// <summary>
            /// This method displays the selected referencesSet
            /// </summary>
            /// <param name="refSet"></param>
            private void DisplaySelectedReferences(ReferencesSet refSet)
            {
                // if refSet exists
                if (refSet != null)
                {
                    // Load the references combo 
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences.ToList(), this.ReaderReferencesSetComboBox);

                    // Get the selected index
                    int index = this.ReaderReferencesSetComboBox.Items.IndexOf(refSet);

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the selected index
                        this.ReaderReferencesSetComboBox.SelectedIndex = index;
                    }
                }
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

                        // call the BrowseReaderFolderButton_Click event
                        BrowseReaderFolderButton_Click(this, null);

                        // required
                        break;                    

                    case "Edit":

                        // Call the EditReaderReferencesSetButton_Click event
                        EditReaderReferencesSetButton_Click(this, null);

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
                
                // Enable the Edit button
                this.EditReaderReferencesSetButton.Enabled = (this.SelectedReferencesSet != null);
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
