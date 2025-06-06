
#region using statements

using DataTierClient.Controls.Interfaces;
using DataTierClient.ClientUtil;
using DataTierClient.Enumerations;
using ObjectLibrary.BusinessObjects;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

#endregion

namespace DataTierClient.Controls
{

    #region class DataManagerEditor : UserControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class DataManagerEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private ReferencesSet selectedReferencesSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a DataManagerEditor.
        /// </summary>
        public DataManagerEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseDataManagerFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the DataManagerFolder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseDataManagerFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DialogHelper.ChooseFolder(this.DataManagerFolderTextBox, this.ProjectFolder); 
            }
            #endregion

            #region DataManagerFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The DataManagerFolder value has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataManagerFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the DataManagerFolder
                    this.SelectedProject.DataManagerFolder = this.DataManagerFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }     
            }
            #endregion

            #region DataManagerNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The DataManagerNamespace value changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataManagerNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the DataManagerNamepsace
                    this.SelectedProject.DataManagerNamespace = this.DataManagerNamespaceTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }     
            }
            #endregion

            #region DataManagerReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// The selected references set has changed for a project.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataManagerReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Create the references set
                    ReferencesSet refSet = this.DataManagerReferencesSetComboBox.SelectedItem as ReferencesSet;

                    // if the references set exists
                    if (refSet != null)
                    {
                        // Set selected references set
                        this.SelectedReferencesSet = refSet;

                        // set ReferencesSet
                        this.SelectedProject.DataManagerReferencesSet = refSet;

                        // Set the ObjectReferencesSetID
                        this.SelectedProject.DataManagerReferencesSetId = refSet.ReferencesSetId;
                    }

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion

            #region EditDataManagerReferencesSetButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This method edits the selected references set.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditDataManagerReferencesSetButton_Click(object sender, EventArgs e)
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
                this.NextControl = ActiveControlEnum.DataOperationsTab;

                // Set PrevControl
                this.PrevControl = ActiveControlEnum.DataObjectsTab;
                
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
                    // display the object namespace
                    this.DataManagerNamespaceTextBox.Text = this.SelectedProject.DataManagerNamespace;
                    
                    // display the object folder
                    this.DataManagerFolderTextBox.Text = this.SelectedProject.DataManagerFolder;

                    // display the object references set
                    this.DisplaySelectedReferences(this.SelectedProject.DataManagerReferencesSet);
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
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences.ToList(), this.DataManagerReferencesSetComboBox);

                    // Get the selected index
                    int index = this.DataManagerReferencesSetComboBox.Items.IndexOf(refSet);

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the selected index
                        this.DataManagerReferencesSetComboBox.SelectedIndex = index;
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
                        BrowseDataManagerFolderButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditObjectReferencesButton_Click event
                        EditDataManagerReferencesSetButton_Click(this, null);

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

                // enable the EditObjectReferencesSetButton
                this.EditDataManagerReferencesSetButton.Enabled = (this.SelectedReferencesSet != null);
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
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ActiveControlEnum PrevControl
            {
                get { return prevControl; }
                set { prevControl = value; }
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
