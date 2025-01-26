

#region using statements

using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using DataTierClient.ClientUtil;
using System.Linq;

#endregion

namespace DataTierClient.Controls
{

    #region class DataOperationsEditor : UserControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class DataOperationsEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private ReferencesSet selectedReferencesSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a DataOperationsEditor.
        /// </summary>
        public DataOperationsEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseDataOperationsFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is used to browse for the Data Operations
            /// folder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseDataOperationsFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DialogHelper.ChooseFolder(this.DataOperationsFolderTextBox, this.ProjectFolder);    
            }
            #endregion

            #region DataOperationsFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The DataOperations Folder has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataOperationsFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the DataOperationsFolder
                    this.SelectedProject.DataOperationsFolder = this.DataOperationsFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            }
            #endregion

            #region DataOperationsNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The Data Operations Namespace
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataOperationsNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the ProjectFolder
                    this.SelectedProject.DataOperationsNamespace = this.DataOperationsNamespaceTextBox.Text.ToString();

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion

            #region DataOperationsReferencesSetCombobox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// The Data Operations References Set SelectedIndex has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataOperationsReferencesSetCombobox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    if (DataOperationsReferencesSetCombobox.SelectedItem is ReferencesSet refSet)
                    { 
                        // set refernces set
                        SelectedReferencesSet = refSet;
                    
                        // Set references set
                        SelectedProject.DataOperationsReferencesSet = refSet;
                    
                        // Set the DataOperationsReferencesSetID
                        SelectedProject.DataOperationsReferencesSetId = refSet.ReferencesSetId;
                    }

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion

            #region EditDataOperationsReferencesSet_Click(object sender, EventArgs e)
            /// <summary>
            /// Edit the list of references 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditDataOperationsReferencesSet_Click(object sender, EventArgs e)
            {
                // Edit the references set
                ReferencesSet refSet = ReferencesSetManager.EditReferencesSet(this.SelectedReferencesSet, this.SelectedProject);

                // Display selected references
                DisplaySelectedReferences(refSet);     
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
                this.NextControl = ActiveControlEnum.ControllersTab;

                // Set PrevControl
                this.PrevControl = ActiveControlEnum.DataManagerTab;
                
                // if the selected project exist
                if(this.SelectedProject != null)
                {
                    // load the references set combo box with all references
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences.ToList(), this.DataOperationsReferencesSetCombobox);
                }
                
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
                if(this.HasSelectedProject)
                {
                    // display the object folder
                    this.DataOperationsFolderTextBox.Text = this.SelectedProject.DataOperationsFolder;
                    
                    // display the object namespace
                    this.DataOperationsNamespaceTextBox.Text = this.SelectedProject.DataOperationsNamespace;
                    
                    // display the object references set
                    this.DisplaySelectedReferences(this.SelectedProject.DataOperationsReferencesSet);
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
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences.ToList(), this.DataOperationsReferencesSetCombobox);

                    // Get the selected index
                    int index = this.DataOperationsReferencesSetCombobox.Items.IndexOf(refSet);

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the selected index
                        this.DataOperationsReferencesSetCombobox.SelectedIndex = index;
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

                        // call the BrowseObjectFolderButton_Click event
                        BrowseDataOperationsFolderButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditDataOperationsReferencesSet_Click event
                        EditDataOperationsReferencesSet_Click(this, null);

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
                
                // Enable the DataOperations ReferencesSet button.
                this.EditDataOperationsReferencesSet.Enabled = (this.SelectedReferencesSet != null);
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
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

                    if (this.Parent is Panel mainPanel)
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
