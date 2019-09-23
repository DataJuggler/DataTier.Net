
#region using statements

using DataJuggler.Core.UltimateHelper;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using ObjectLibrary.BusinessObjects;
using DataTierClient.ClientUtil;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class ControllerEditor : BaseWizardControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class ControllerEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private ReferencesSet selectedReferencesSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ControllerEditor.
        /// </summary>
        public ControllerEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseControllerFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the Controller folder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseControllerFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DataJuggler.Core.UltimateHelper.DialogHelper.ChooseFolder(this.ControllerFolderTextBox, this.ProjectFolder);  
            } 
            #endregion

            #region ControllerFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The ControllerFolder has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ControllerFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the DataOperationsFolder
                    this.SelectedProject.ControllerFolder = this.ControllerFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            }
            #endregion

            #region ControllerNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The ControllerNamespace has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ControllerNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the DataOperationsFolder
                    this.SelectedProject.ControllerNamespace = this.ControllerNamespaceTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            } 
            #endregion

            #region ControllerReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// A selection was made in the ControllerReferencesSetComboBox.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ControllerReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Create the references set
                    ReferencesSet refSet = this.ControllerReferencesSetComboBox.SelectedItem as ReferencesSet;

                    // if the references set exists
                    if (refSet != null)
                    {
                        // set the SelectedReferencesSet
                        this.SelectedReferencesSet = refSet;
                    
                        // set the ReferencesSet
                        this.SelectedProject.ControllerReferencesSet = refSet;
                    
                        // Set the DataOperationsReferencesSetID
                        this.SelectedProject.ControllerReferencesSetId = refSet.ReferencesSetId;
                    }

                    // Enable Controls
                    UIEnable();
                } 
            }
            #endregion

            #region EditControllerReferencesSetButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event edits the controller refernces set.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditControllerReferencesSetButton_Click(object sender, EventArgs e)
            {
                // Edit the references set
                ReferencesSet refSet = ReferencesSetManager.EditReferencesSet(this.SelectedReferencesSet, this.SelectedProject);

                // Display selected references
                DisplaySelectedReferences(refSet);
            }
            #endregion

            #region NewControllerReferencesSetButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Create a new controller refernces set.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void NewControllerReferencesSetButton_Click(object sender, EventArgs e)
            {
                // create references set
                ReferencesSet refSet = ReferencesSetManager.CreateNewReferencesSet(this.SelectedProject);

                // if the refSet exists
                if (refSet != null)
                {
                    // add this refernce to all references
                    this.SelectedProject.AllReferences.Add(refSet);

                    // set the references set
                    this.SelectedProject.ControllerReferencesSet = refSet;
                }

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
                this.NextControl = ActiveControlEnum.ReadersTab;

                // Set PrevControl
                this.PrevControl = ActiveControlEnum.DataOperationsTab;

                // if the selected project exist
                if (this.SelectedProject != null)
                {
                    // load the references set combo box with all references
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences, this.ControllerReferencesSetComboBox);
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
                if (this.HasSelectedProject)
                {
                    // display the object folder
                    this.ControllerFolderTextBox.Text = this.SelectedProject.ControllerFolder;

                    // display the object namespace
                    this.ControllerNamespaceTextBox.Text = this.SelectedProject.ControllerNamespace;

                    // display the object references set
                    this.DisplaySelectedReferences(this.SelectedProject.ControllerReferencesSet);
                }

                // Enable Controls
                UIEnable();
            }
            #endregion

            #region DisplaySelectedReferences(List<ReferencesSet> refSet)
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
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences, this.ControllerReferencesSetComboBox);

                    // Get the selected index
                    int index = this.ControllerReferencesSetComboBox.Items.IndexOf(refSet);

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the selected index
                        this.ControllerReferencesSetComboBox.SelectedIndex = index;
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
                        BrowseControllerFolderButton_Click(this, null);

                        // required
                        break;

                    case "New":

                        // Call the NewObjectReferencesSetButton_Click event
                        NewControllerReferencesSetButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditObjectReferencesButton_Click event
                        EditControllerReferencesSetButton_Click(this, null);

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
                this.EditControllerReferencesSetButton.Enabled = (this.SelectedReferencesSet != null);
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
