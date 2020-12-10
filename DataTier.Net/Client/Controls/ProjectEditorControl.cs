
#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using DataTierClient.ClientUtil;
using ObjectLibrary.Enumerations;
using ObjectLibrary.BusinessObjects;
using System.IO;
using DataTierClient.Forms;
using System.Collections.Generic;

#endregion

namespace DataTierClient.Controls
{

    #region class ProjectEditorControl : UserControl, IWizardControl
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class ProjectEditorControl : UserControl, IWizardControl, ITabButtonParent, ISelectedIndexListener
    {
        
        #region Private Variables
        private ActiveControlEnum nextControl;
        private ActiveControlEnum prevControl;
        private const string CreateDataTier = "dotnet new DataJuggler.DataTier.Net5.ProjectTemplates";
        
        // Used to install the Project Templates on the ProjectEditorControl.cs
        private const int GraphWidth = 268;
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
            
            #region BlazorServicesCheckBox_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Blazor Services Check Box _ Checked Changed
            /// </summary>
            private void BlazorServicesCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                 // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // set the value
                    SelectedProject.EnableBlazorFeatures = BlazorServicesCheckBox.Checked;
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region BrowseProjectFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event chooses the ProjectFolder.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseProjectFolderButton_Click(object sender, EventArgs e)
            {
                // Choose the folder
                DataJuggler.Core.UltimateHelper.DialogHelper.ChooseFolder(this.ProjectFolderTextBox, this.ProjectFolder);
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
            
            #region CreateDotNet5Project_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CreateDotNet5Project_Click' is clicked.
            /// </summary>
            private void CreateDotNet5Project_Click(object sender, EventArgs e)
            {
                try
                {
                    // if the SelectedProject exists
                    if ((HasSelectedProject) && (TextHelper.Exists(SelectedProject.ProjectFolder)))
                    {
                        // Test if there are any files in this directory
                        List<string> files = FileHelper.GetFiles(SelectedProject.ProjectFolder, "", false);

                        // If the files collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(files))
                        {
                            // show the user a message
                            MessageBoxHelper.ShowMessage("The Project Folder is not empty. You must select an empty folder for a Dot Net Core data-tier.", "Project Folder Is Not Empty");
                        }
                        else
                        {
                            // Install the templates
                            bool installed = InstallDataTierNetTemplates();

                            // if the value for installed is true
                            if (installed)
                            {
                                 // update anything
                                Refresh();
                                Application.DoEvents();

                                // Create a Process to launch a command window (hidden) to create the item templates
                                Process process = new Process();
                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                startInfo.WorkingDirectory = SelectedProject.ProjectFolder;
                                startInfo.Arguments = "/C " + CreateDataTier;
                                process.StartInfo = startInfo;
                                process.Start();

                                // get the solution path
                                string solutionPath = Path.Combine(SelectedProject.ProjectFolder, "DataTier.Net5.ClassLibrary.sln");

                                // Set the startTime
                                DateTime startTime = DateTime.Now;

                                // for the graph
                                int width = 0;

                               do
                               {
                                    // Get the currentTime
                                    DateTime currentTime = DateTime.Now;

                                    // set the width
                                    width += 5;

                                    // if above the maximum width (268)
                                    if (width >= GraphWidth)
                                    {
                                        // cap
                                        width = GraphWidth;
                                    }

                                    // set the width
                                    Graph.Width = width;

                                    // Show the Graph
                                    Graph.Visible = true;

                                    // Do Events
                                    this.Refresh();
                                    Application.DoEvents();

                                    // has 5 secondes elapsed
                                    if (currentTime.Subtract(startTime).TotalSeconds >= 10)
                                    {
                                        // give up after 10 seconds
                                        break;
                                    }
                                    else
                                    {
                                        // if the solutionPath exists
                                        if (File.Exists(solutionPath))
                                        {
                                            // break out of the loop
                                            break;
                                        }
                                    }



                               } while (true);

                               // hide the graph
                               Graph.Visible = false;

                                // update anything
                                Refresh();
                                Application.DoEvents();

                                // if the solutionPath exists
                                if (File.Exists(solutionPath))
                                {
                                    // show the user a message
                                    MessageBoxHelper.ShowMessage("Your DataTier has been created.", "DataTier Created");
                                }
                                else
                                {
                                    // show the user a message
                                    MessageBoxHelper.ShowMessage("Oops. Something went wrong", "Data Tier Not Created");
                                }
                            }
                        }
                    }
                    else
                    {
                        // show the user a message
                        MessageBoxHelper.ShowMessage("The Project Folder is required.", "DataTier Creation Failed");
                    }
                }
                catch (Exception error)
                {
                    // Set the error
                    DebugHelper.WriteDebugError("CreateDotNet5Button_LinkClicked", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The datatier could not be created in the Project Folder. Ensure you are connected to the internet and that you have permission to write to the Project Folder.", "Create DataTier Failed");
                }
            }
            #endregion
            
            #region DotNet5CheckBox_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Dot Net Core Check Box _ Checked Changed
            /// </summary>
            private void DotNet5CheckBox_CheckedChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // set the value
                    SelectedProject.DotNet5 = DotNet5CheckBox.Checked;
                }

                // Enable or disable controls
                UIEnable();
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
            
            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            /// <summary>
            /// event is fired when a selection is made in the 'On'.
            /// </summary>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // Set the value
                    SelectedProject.BindingCallbackOption = (BindingCallbackOptionEnum) selectedIndex;                   
                }

                // Enable or disable controls
                UIEnable();
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
                bool dotNet5 = false;
                bool enableBlazorFeatures = false;
                int bindingIndex = -1;
                
                // if the SelectedProject Exists
                if(this.SelectedProject != null)
                {
                    // set values
                    projectName = this.SelectedProject.ProjectName;
                    projectFolder = this.SelectedProject.ProjectFolder;
                    dotNet5 = SelectedProject.DotNet5;
                    enableBlazorFeatures = SelectedProject.EnableBlazorFeatures;
                    bindingIndex = FindBindingIndex(SelectedProject.BindingCallbackOption);
                }
                
                // dislay values now
                this.ProjectNameTextBox.Text = projectName;
                this.ProjectFolderTextBox.Text = projectFolder;
                this.DotNet5CheckBox.Checked = dotNet5;
                this.BlazorServicesCheckBox.Checked = enableBlazorFeatures;
                this.BindingCallbackOptionControl.SelectedIndex = bindingIndex;
                                
                // Enable controls
                UIEnable();
            }
            #endregion
        
            #region FindBindingIndex(BindingCallbackOptionEnum bindingCallbackOption)
            /// <summary>
            /// This method returns the Binding Index
            /// </summary>
            public int FindBindingIndex(BindingCallbackOptionEnum bindingCallbackOption)
            {
                // initial value
                int index = -1;

                // Determine the action by the bindingCallbackOption
                switch (bindingCallbackOption)
                {
                    case BindingCallbackOptionEnum.Allow_Binding:
                    
                        // set the return value
                        index = 1;

                        // required
                        break;

                    case BindingCallbackOptionEnum.No_Binding:

                        // set the return value
                        index = 0;

                        // required
                        break;

                    case BindingCallbackOptionEnum.Create_Binding:

                        // set the return value
                        index = 2;

                        // required
                        break;
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// </summary>
            public void Init()
            {
                // Setup the listener
                this.BindingCallbackOptionControl.SelectedIndexListener = this;

                // Set Dock To Fill
                this.Dock = DockStyle.Fill;

                // This is the first control, there is not a previous control
                this.PrevControl = ActiveControlEnum.NotSet;

                // Set the next control
                this.NextControl = ActiveControlEnum.DatabasesTab;

                // Load the binding choices
                this.BindingCallbackOptionControl.LoadItems(typeof(BindingCallbackOptionEnum));
            }
            #endregion

            #region InstallDataTierNetTemplates()
            /// <summary>
            /// This method Install Data Tier Net Templates
            /// </summary>
            public bool InstallDataTierNetTemplates()
            {
                // initial value
                bool installed = false;

                try               
                 {
                     // Create a Process to launch a command window (hidden) to create the item templates
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + SetupControl.DotNet5ProjectTemplates;
                    process.StartInfo = startInfo;
                    process.Start();

                    // Set to true
                    installed = true;
                 }
                 catch (Exception error)
                 {
                    // set to false
                    installed = false;

                    // Set the error
                    DebugHelper.WriteDebugError("InstallDataTierNetTemplates", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The DataTier.Net5.Project Templates could not be installed. Ensure you are connected to the internet and try again.", "Insteall Templates Failed");
                 }

                 // return value
                 return installed;
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

                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // Show Enable BlazorServices for DotNet5 projects only
                    this.BlazorServicesCheckBox.Visible = SelectedProject.DotNet5;

                    // Enable Blazor Features to true
                    this.BindingCallbackOptionControl.Visible = SelectedProject.EnableBlazorFeatures;

                    // Show the CreateDotNet5Project control if DotNet5
                    this.CreateDotNet5Project.Visible = SelectedProject.DotNet5;
                }
                else
                {
                    // Do not show for .Net Framework projects
                    this.BlazorServicesCheckBox.Visible = false;
                    this.CreateDotNet5Project.Visible = false;
                    this.BindingCallbackOptionControl.Visible = false;
                }

                // refresh controls
                this.Refresh();
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
