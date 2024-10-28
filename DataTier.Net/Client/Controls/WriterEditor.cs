
#region using statements

using DataJuggler.Core.UltimateHelper;
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

    #region class WriterEditor : UserControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class WriterEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private ReferencesSet selectedReferencesSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a WriterControl.
        /// </summary>
        public WriterEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseWriterFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Browse for the writer folder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseWriterFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the folder
                DataJuggler.Core.UltimateHelper.DialogHelper.ChooseFolder(this.WriterFolderTextBox, this.ProjectFolder);  
            }
            #endregion

            #region EditWriterReferencesSetButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Edit the WriterReferencesSet.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditWriterReferencesSetButton_Click(object sender, EventArgs e)
            {
                // Edit the references set
                ReferencesSet refSet = ReferencesSetManager.EditReferencesSet(this.SelectedReferencesSet, this.SelectedProject);

                // Display selected references
                DisplaySelectedReferences(refSet); 
            }
            #endregion

            #region WriterFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The WriterFolder has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WriterFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the Folder
                    this.SelectedProject.DataWriterFolder = this.WriterFolderTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            }
            #endregion

            #region WriterNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The Writer Namespace has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WriterNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the Namespace
                    this.SelectedProject.DataWriterNamespace = this.WriterNamespaceTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }  
            } 
            #endregion

            #region WriterReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// The Writer ReferencesSet has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WriterReferencesSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Create the references set
                    ReferencesSet refSet = this.WriterReferencesSetComboBox.SelectedItem as ReferencesSet;

                    // if the references set exists
                    if (refSet != null)
                    {
                        // set the SelectedReferencesSet
                        this.SelectedReferencesSet = refSet;

                        // set the ReferencesSet
                        this.SelectedProject.WriterReferencesSet = refSet;

                        // Set the ReaderReferencesSetID
                        this.SelectedProject.DataWriterReferencesSetId = refSet.ReferencesSetId;
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
                this.NextControl = ActiveControlEnum.StoredProceduresTab;

                // Set PrevControl
                this.PrevControl = ActiveControlEnum.ReadersTab;
                
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
                    this.WriterFolderTextBox.Text = this.SelectedProject.DataWriterFolder;

                    // display the namespace
                    this.WriterNamespaceTextBox.Text = this.SelectedProject.DataWriterNamespace;

                    // display the object references set
                    this.DisplaySelectedReferences(this.SelectedProject.WriterReferencesSet);
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
                    ReferencesSetManager.LoadReferencesSetComboBox(this.SelectedProject.AllReferences.ToList(), this.WriterReferencesSetComboBox);

                    // Get the selected index
                    int index = this.WriterReferencesSetComboBox.Items.IndexOf(refSet);

                    // if the index exists
                    if (index >= 0)
                    {
                        // set the selected index
                        this.WriterReferencesSetComboBox.SelectedIndex = index;
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

                        // call the BrowseWriterFolderButton_Click event
                        BrowseWriterFolderButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditWriterReferencesSetButton_Click event
                        EditWriterReferencesSetButton_Click(this, null);

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
                this.EditWriterReferencesSetButton.Enabled = (this.SelectedReferencesSet != null);
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
