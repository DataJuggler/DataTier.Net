
#region using statements

using DataGateway;
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
using DataJuggler.Net.Enumerations;

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
        private bool showAutoFillHelp;
        private const string CreateDataTierNet5 = "dotnet new DataTier.Net5.ProjectTemplates";
        private const string InstallDataTierNet5 = "dotnet new --install DataJuggler.DataTier.Net5.ProjectTemplates";
        private const string CreateDataTierNet6 = "dotnet new DataTier.Net6.ProjectTemplates";
        private const string InstallDataTierNet6 = "dotnet new --install DataJuggler.DataTier.Net6.ProjectTemplates";

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
            
            #region AutoFillChildFolderInfo_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AutoFillChildFolderInfo' is clicked.
            /// </summary>
            private void AutoFillChildFolderInfo_Click(object sender, EventArgs e)
            {
                // toggle back to false
                this.ShowAutoFillHelp = false;

                // Hide this control
                UIEnable();
            }
            #endregion
            
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

            #region BrowseUIPathButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BrowseUIPathButton' is clicked.
            /// </summary>
            private void BrowseUIPathButton_Click(object sender, EventArgs e)
            {
                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // set the value
                    SelectedProject.UIFolderPath = this.UIFolderTextBox.Text;
                }

                // Enable or disable controls
                UIEnable();
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
            
            #region CreateDotNetProject_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CreateDotNetProject_Click' is clicked.
            /// </summary>
            private void CreateDotNetProject_Click(object sender, EventArgs e)
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
                                // wait a small delay
                                int second = DateTime.Now.Second;
                                int newSecond = 0;
                                int duration = 0;

                                do
                                {
                                    // Get the new second
                                    newSecond = DateTime.Now.Second;

                                    // if a second changed
                                    if (newSecond != second)
                                    {
                                        // Increment the value for duration
                                        duration++;
                                    }

                                } while (duration < 2);

                                // Create a Process to launch a command window (hidden) to create the item templates
                                Process process = new Process();
                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                startInfo.WorkingDirectory = SelectedProject.ProjectFolder;

                                if (SelectedProject.TargetFramework == TargetFrameworkEnum.Net5)
                                {
                                    // if Net5
                                    startInfo.Arguments = "/C " + CreateDataTierNet5;
                                }
                                else
                                {
                                    // if Net6
                                    startInfo.Arguments = "/C " + CreateDataTierNet6;
                                }

                                process.StartInfo = startInfo;
                                process.Start();

                                // get the solution path - default to DotNet6
                                string solutionPath = Path.Combine(SelectedProject.ProjectFolder, "DataTier.Net6.ClassLibrary.sln");

                                // if Net5
                                if (SelectedProject.TargetFramework == TargetFrameworkEnum.Net5)
                                {
                                    // switch for Net6
                                    solutionPath = Path.Combine(SelectedProject.ProjectFolder, "DataTier.Net5.ClassLibrary.sln");
                                }

                                // Set the startTime
                                DateTime startTime = DateTime.Now;

                                // for the graph
                                int width = 0;

                               do
                               {
                                    // Get the currentTime
                                    DateTime currentTime = DateTime.Now;

                                    // set the width
                                    width += 1;

                                    // sleep for 1/40 of a second
                                    System.Threading.Thread.Sleep(25);

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

                                    // has 15 secondes elapsed
                                    if (currentTime.Subtract(startTime).TotalSeconds >= 15)
                                    {
                                        // give up after 15 seconds
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
                    DebugHelper.WriteDebugError("CreateDotNetProject_Clicked", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The datatier could not be created in the Project Folder. Ensure you are connected to the internet and that you have permission to write to the Project Folder.", "Create DataTier Failed");
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
            
            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            /// <summary>
            /// event is fired when a selection is made in the 'On'.
            /// Changing the TargetFramework will revert any custom references saved back to default.
            /// Sorry, not sure how else to do this.
            /// </summary>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    if (TextHelper.IsEqual(control.Name, BindingCallbackOptionControl.Name))
                    {
                        // Set the BindingCallbackOption
                        SelectedProject.BindingCallbackOption = (BindingCallbackOptionEnum) selectedIndex;                   
                    }
                    else if (TextHelper.IsEqual(control.Name, ProjectTypeControl.Name))
                    {
                        // Set the ProjectType
                        SelectedProject.TargetFramework = (TargetFrameworkEnum) (selectedIndex + 4);

                        // The DataJuggler.Net Reference Must Be Changed, based on the target framework

                        // DataJuggler.Net Reference has to change if this changes
                        SelectedProject.UpdateReferences();
                    }
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
                    this.SelectedProject.ProjectName = this.ProjectNameTextBox.Text;

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion
        
            #region ShowAutoFillHelpButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ShowAutoFillHelpButton' is clicked.
            /// </summary>
            private void ShowAutoFillHelpButton_Click(object sender, EventArgs e)
            {
                // Toggle
                this.ShowAutoFillHelp = !this.ShowAutoFillHelp;

                // Update the UI
                UIEnable();
            }
            #endregion
            
            #region UIFolderTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when UI Folder Text Box _ Text Changed
            /// </summary>
            private void UIFolderTextBox_TextChanged(object sender, EventArgs e)
            {
                 // if the SelectedProject exists
                if (this.HasSelectedProject)
                {
                    // Set the ProjectFolder
                    this.SelectedProject.UIFolderPath = this.UIFolderTextBox.Text;
                    
                    // get a reference to the ProjectFolder 
                    string projectFolder = this.SelectedProject.ProjectFolder;
                 
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
                bool enableBlazorFeatures = false;
                int bindingIndex = -1;
                int projectTypeIndex = ProjectTypeControl.FindItemIndexByValue("Net6");
                string uiFolderPath = "";
                
                // if the SelectedProject Exists
                if(this.SelectedProject != null)
                {
                    // set values
                    projectName = this.SelectedProject.ProjectName;
                    projectFolder = this.SelectedProject.ProjectFolder;                    
                    enableBlazorFeatures = SelectedProject.EnableBlazorFeatures;
                    bindingIndex = FindBindingIndex(SelectedProject.BindingCallbackOption);
                    projectTypeIndex = ProjectTypeControl.FindItemIndexByValue(SelectedProject.TargetFramework.ToString());
                    uiFolderPath = SelectedProject.UIFolderPath;
                }
                
                // dislay values now
                ProjectNameTextBox.Text = projectName;
                ProjectFolderTextBox.Text = projectFolder;
                ProjectTypeControl.SelectedIndex = projectTypeIndex;
                BlazorServicesCheckBox.Checked = enableBlazorFeatures;
                BindingCallbackOptionControl.SelectedIndex = bindingIndex;
                UIFolderTextBox.Text = uiFolderPath;
                                
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
                BindingCallbackOptionControl.LoadItems(typeof(BindingCallbackOptionEnum));

                // Load the ProjectTypes combo box
                ProjectTypeControl.LoadItems(typeof(TargetFrameworkEnum));

                // Setup the listener
                ProjectTypeControl.SelectedIndexListener = this;

                // Set the SelectedIndex
                ProjectTypeControl.SelectedIndex = ProjectTypeControl.FindItemIndexByValue("Net6");

                // Should call UIEnable
                OnSelectedIndexChanged(ProjectTypeControl, ProjectTypeControl.SelectedIndex, ProjectTypeControl.SelectedObject);
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

                    if (SelectedProject.TargetFramework == TargetFrameworkEnum.Net5)
                    {
                        // Use Net5
                        startInfo.Arguments = "/C " + InstallDataTierNet5;
                    }
                    else
                    {
                        // Use Net6
                        startInfo.Arguments = "/C " + InstallDataTierNet6;
                    }
                    process.StartInfo = startInfo;

                    // Start
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
                    MessageBoxHelper.ShowMessage("The DataTier.Net.Project Templates could not be installed. Ensure you are connected to the internet and try again.", "Install Templates Failed");
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
                    // Show Enable BlazorServices for DotNet5 or DotNet6 projects only
                    this.BlazorServicesCheckBox.Visible = SelectedProject.IsDotNetCore;

                    // Enable Blazor Features to true
                    this.BindingCallbackOptionControl.Visible = SelectedProject.EnableBlazorFeatures;

                    // Show the CreateDotNet5Project control if DotNet5
                    this.CreateDotNetProject.Visible = SelectedProject.IsDotNetCore;
                }
                else
                {
                    // Do not show for .Net Framework projects
                    this.BlazorServicesCheckBox.Visible = false;
                    this.CreateDotNetProject.Visible = false;
                    this.BindingCallbackOptionControl.Visible = false;
                }

                // if the value for ShowAutoFillHelp is true
                if (ShowAutoFillHelp)
                {
                    // position the control
                    this.AutoFillChildFolderInfo.Left = (this.Width - this.AutoFillChildFolderInfo.Width) / 2;
                    this.AutoFillChildFolderInfo.Top = (this.Height - this.AutoFillChildFolderInfo.Height) / 2;
                }
                
                // Show or hide the AutoFill Help
                this.AutoFillChildFolderInfo.Visible = this.ShowAutoFillHelp;

                // refresh controls
                this.Refresh();
            }
            #endregion

            #region ValidateSelectedProject()
            /// <summary>
            /// Validate the selected project. This is required for the interface. Not actually used.
            /// </summary>
            public bool ValidateSelectedProject()
            {
                // initial value
                bool valid = true;
                
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

            #region ShowAutoFillHelp
            /// <summary>
            /// This property gets or sets the value for 'ShowAutoFillHelp'.
            /// </summary>
            public bool ShowAutoFillHelp
            {
                get { return showAutoFillHelp; }
                set { showAutoFillHelp = value; }
            }
        #endregion

        #endregion

    }
    #endregion
    
}
