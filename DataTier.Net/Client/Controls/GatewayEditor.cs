

#region using statements

using DataTierClient.Enumerations;
using DataTierClient.ClientUtil;
using DataTierClient.Controls.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using System.Linq;

#endregion

namespace DataTierClient.Controls
{

    #region class GatewayEditor : UserControl, IWizardControl, ITabButtonParent
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class GatewayEditor : UserControl, IWizardControl, ITabButtonParent
    {

        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a GatewayEditor.
        /// </summary>
        public GatewayEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region BrowseGatewayFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event browses for the Gateway folder
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseGatewayFolderButton_Click(object sender, EventArgs e)
            {
                // Browse for the Gateway.cs file in case they need to change it. 
                DialogHelper.ChooseGatewayFile(this.GatewayFolderTextBox); 
            }
            #endregion

            #region GatewayFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The Gateway folder has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void GatewayFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the DataObjectsFolder
                    this.SelectedProject.GatewayPath = this.GatewayFolderTextBox.Text.ToString();

                    // Enable Controls
                    UIEnable();
                }     
            }
            #endregion

            #region ObjectNamespaceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The object namespace has chagned.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void GatewayNamespaceTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // Set the ObjectNamespace
                    this.SelectedProject.GatewayNamespace = this.GatewayNamespaceTextBox.Text.ToString();

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
                if(this.HasSelectedProject)
                {
                    // display the object folder
                    this.GatewayFolderTextBox.Text = this.SelectedProject.GatewayPath;
                    
                    // display the object namespace
                    this.GatewayNamespaceTextBox.Text = this.SelectedProject.GatewayNamespace;
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

                        // call the BrowseObjectFolderButton_Click event
                        BrowseGatewayFolderButton_Click(this, null);

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
            
            #region SelectedProject
            /// <summary>
            /// This property is the selected Project
            /// being created or edited.
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        #endregion

    }
    #endregion

}