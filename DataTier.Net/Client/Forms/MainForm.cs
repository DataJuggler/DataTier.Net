

#region using statements

using ApplicationLogicComponent.Controllers;
using DataGateway;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using DataJuggler.Net;
using DataJuggler.Net.Cryptography;
using DataJuggler.Net.Enumerations;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataTier.Net.StoredProcedureGenerator;
using DataTierClient.Builders;
using DataTierClient.ClientUtil;
using DataTierClient.Controls.Images;
using DataTierClient.Enumerations;
using DataTierClient.Objects;
using DataTierClient.Xml.Parsers;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Forms
{

    #region class MainForm : Form, ICheckChangedListener
    /// <summary>
    /// The main UI for this application.
    /// </summary>
    public partial class MainForm : Form, ICheckChangedListener
    {
    
        #region Private Variables
        private Project openProject;
        private List<Project> allProjects;
        private DataManager dataManager;
        private ApplicationController appController;
        private Gateway gateway;
        private string currentDirectory;
        private Image selectedImage;
        private Image notSelectedImage;
        private bool buildComplete;
        private ProjectFileManager fileManager;
        private bool setupComplete;
        private ButtonManager buttonManager;
        private string storedProceduresSQLPath;
        private Admin admin;
        internal const string DataTierNetConnectionName = "DataTierNetConnection";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Creates a new MainForm.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();
            
            // Perfrom Initializations
            Init();
            
            // Set the current directory
            this.CurrentDirectory = Environment.CurrentDirectory;
        }
        #endregion

        #region Delegates
        public delegate bool BuildOperation(ref Exception error);
        #endregion
       
        #region Events
    
            #region BuildAllButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BuildAllButton' is clicked.
            /// </summary>
            private void BuildAllButton_Click(object sender, EventArgs e)
            {
                // if the BuildAllButton is enabled
                if (ButtonManager.IsButtonEnabled(BuildAllButton))
                {
                    // Set Focus to the HiddenButton
                    HiddenButton.Focus();

                    // Update the UI
                    Refresh();
                    Application.DoEvents();

                     // Build 
                    BuildAll();
                }
            }
            #endregion
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // cast the sender as a button    
                Button button = sender as Button;

                // if the button exists
                if (NullHelper.Exists(button))
                {   
                    // The YouTube button is always enabled
                    if (button.Name.Contains("YouTube"))
                    {
                        // Change the cursor to a hand
                        Cursor = Cursors.Hand;
                    }
                    else
                    {
                        // is this button enabled
                        bool isButtonEnabled = buttonManager.IsButtonEnabled(button);

                        // if the value for isButtonEnabled is true
                        if (isButtonEnabled)
                        {
                            // Change the cursor to a hand
                            Cursor = Cursors.Hand;
                        }
                    }
                }
                else
                {
                    // Change the cursor to a hand
                    Cursor = Cursors.Hand;
                }
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
            
            #region CloseProjectButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CloseProjectButton' is clicked.
            /// </summary>
            private void CloseProjectButton_Click(object sender, EventArgs e)
            {   
                // If the OpenProject exists
                if (HasOpenProject)
                {
                    // remove the focus 
                    HiddenButton.Focus();

                    // Set the open project to null
                    OpenProject = null;

                    // set build complete to false
                    BuildComplete = false;
                }

                // Clear results
                StatusListBox.Items.Clear();

                // Display Selected Project
                DisplaySelectedProject(OpenProject);
            }
            #endregion
           
            #region EditProjectButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'EditProjectButton' is clicked.
            /// </summary>
            private void EditProjectButton_Click(object sender, EventArgs e)
            {
                // if this button is currently enabled
                if (ButtonManager.IsButtonEnabled(EditProjectButton))
                {
                     // If this object has a ParentMainForm.
                    if (this.HasOpenProject)
                    {
                        // Set Focus to the HiddenButton
                        HiddenButton.Focus();

                        // Update the UI
                        Refresh();
                        Application.DoEvents();

                        // Edit the existing project
                        EditProject();
                    }
                }
            }
            #endregion
            
            #region ManageDataButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ManageDataButton_Click' is clicked.
            /// </summary>
            private void ManageDataButton_Click(object sender, EventArgs e)
            {
                // Set Focus to the HiddenButton
                HiddenButton.Focus();

                // Update the UI
                Refresh();
                Application.DoEvents();

                // Reload the table here because because New Tables are not saved if you don't
                this.OpenProject.Tables = gateway.LoadDTNTablesByProjectId(this.OpenProject.ProjectId);

                // Create a new instance of a 'DataEditorForm' object.
                DataEditorForm dataEditor = new DataEditorForm();

                // Setup the OpenProject
                dataEditor.Setup(this.OpenProject);

                // Show the dataEditor
                dataEditor.ShowDialog();

                // if the user did not cancel
                if (!dataEditor.UserCancelled)
                {
                    // reload the project
                    this.OpenProject = gateway.FindProject(OpenProject.ProjectId);

                    // Get the tables from the dataEditor control
                    this.OpenProject.Tables = dataEditor.Tables;

                    // Get the ChangesSet from the dataEditor
                    ChangesSet changesSet = dataEditor.GetChangesSet();

                    // If the changesSet object exists
                    if (NullHelper.Exists(changesSet))
                    {
                        // Save the database schema
                        bool saved = SaveChangesSet(changesSet);
                    }
                }
            }
            #endregion
            
            #region NewProjectButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'NewProjectButton' is clicked.
            /// </summary>
            private void NewProjectButton_Click(object sender, EventArgs e)
            {
                // if the NewProjectButton is enabled
                if (ButtonManager.IsButtonEnabled(NewProjectButton))
                {
                    // remove the focus 
                    HiddenButton.Focus();

                    // Create New Project
                    CreateNewProject();
                }
            }
            #endregion
           
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // if the Admin object exists
                if (HasAdmin)
                {
                    // set the value
                    Admin.CheckForUpdates = isChecked;

                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // save the admin
                    bool saved = gateway.SaveAdmin(ref admin);

                    // if saved
                    if (saved)
                    {
                        // show the text
                        MainStatus.Text = "   Your changes have been saved.";

                        // Enable the timer
                        StatusTimer.Enabled = true;
                    }
                }
            }
            #endregion
            
            #region OpenProjectButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'OpenProjectButton' is clicked.
            /// </summary>
            private void OpenProjectButton_Click(object sender, EventArgs e)
            {  
                // if the OpenProjectButton is enabled
                if (ButtonManager.IsButtonEnabled(OpenProjectButton))
                {
                    // Set Focus to the HiddenButton
                    HiddenButton.Focus();

                    // Update the UI
                    Refresh();
                    Application.DoEvents();

                     // Choose Project
                     this.ChooseProject();    
                }
            }
            #endregion

            #region RepairGatewayButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RepairGatewayButton' is clicked.
            /// </summary>
            private void RepairGatewayButton_Click(object sender, EventArgs e)
            {
                // get the dataObjectsFolder
                string gatewayPath = Path.Combine(OpenProject.ProjectFolder, @"DataGateway\Gateway.cs");

                // if the Template Version is 2
                if (OpenProject.TemplateVersion == 2)
                {
                    // V2 inside DataAccessComponent
                    gatewayPath = Path.Combine(OpenProject.ProjectFolder, @"DataAccessComponent\DataGateway\Gateway.cs");
                }

                // Take the backup
                string backupPath = gatewayPath.Replace(".cs", ".cs.backup");

                // if it exists
                if (!File.Exists(gatewayPath))
                {
                    // If the file exists
                    if (File.Exists(backupPath))
                    {
                        // Copy the file back from the backup
                        File.Copy(backupPath, gatewayPath);

                        // Show a  message
                        MessageHelper.DisplayMessage("The gateway has been repaired.", "Repair Complete");
                    }
                    else
                    {
                        // Show a  message
                        MessageHelper.DisplayMessage("A backup could not be found. You're screwed.", "Beyond Repair");
                    }
                }
                else
                {
                    // Show a  message
                    MessageHelper.DisplayMessage("The Gateway exists. You're screwed.", "Beyond Repair");
                }
            }
            #endregion
            
            #region RunSetupButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RunSetupButton' is clicked.
            /// </summary>
            private void RunSetupButton_Click(object sender, EventArgs e)
            {
                // run the setup
                bool userCancelledSetup = RunSetup();

                // local
                bool restartRequired = false;

                // if the user did not cancel
                if ((!userCancelledSetup) && (!SetupComplete))
                {
                    // A restart is required if the user did not cancel
                    restartRequired = true;
                }

                // if the user cancelled the setup
                if (userCancelledSetup)
                {
                    // user cancelled the setup
                    UserCancelledSetup(userCancelledSetup, restartRequired);
                }
            }
            #endregion
            
            #region StatusListBox_DoubleClick(object sender, EventArgs e)
            /// <summary>
            /// The Status list box was double clicked. This method
            /// will display the error if any.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void StatusListBox_DoubleClick(object sender, EventArgs e)
            {
                // If there is exactly one item selected
                if(this.StatusListBox.SelectedItems.Count == 1)
                {
                    // Get the list item
                    ListViewItem listItem = this.StatusListBox.SelectedItems[0];
                    
                    // If the listItem exists
                    if ((listItem != null) && (listItem.Tag as Exception != null))
                    {
                        // Set error
                        Exception error = listItem.Tag as Exception;
                        
                        // Set errorMessage
                        string errorMessage = "";
                        
                        // If there is a UserFriendly Error
                        if(!String.IsNullOrEmpty(error.Message))
                        {
                            // Set errorMessage
                            errorMessage = error.Message;
                        }
                        else
                        {
                            // Set the error
                            errorMessage = error.ToString();
                        }
                        
                        // Inform user of error
                        MessageHelper.DisplayMessage(errorMessage, "Error");
                    }
                }
            } 
            #endregion
        
            #region StatusTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Status Timer _ Tick
            /// </summary>
            private void StatusTimer_Tick(object sender, EventArgs e)
            {
                // erase the text
                MainStatus.Text = "";

                // disable the timer now
                StatusTimer.Enabled = false;
            }
            #endregion
            
            #region StoredProcedureSQLButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'StoredProcedureSQLButton' is clicked.
            /// </summary>
            private void StoredProcedureSQLButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // if the storedProceduresSQLPath text exists and the File exists on the hard drive
                    if ((HasStoredProceduresSQLPath) && (File.Exists(this.StoredProceduresSQLPath)))
                    {
                        // Open the file in SQL Server Management Studio (provided the user has SSMS installed)
                        System.Diagnostics.Process.Start(storedProceduresSQLPath);
                    }
                }
                catch (Exception error)
                {
                    // write to the console for now
                    DebugHelper.WriteDebugError("StoredProcedureSQLButton_Click", "MainForm", error);
                }
            }
            #endregion
            
            #region ViewPDFButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ViewPDFButton' is clicked.
            /// </summary>
            private void ViewPDFButton_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Quick Start.pdf");

                // if this is the InstalledVersion
                if (IsInstalledVersion)
                {
                    // Get the path in the ProgramFiles folder
                    path = Path.GetFullPath(@"Class Room/Documents/DataTier.Net Quick Start.pdf");
                }

                // if the path exists
                if (File.Exists(path))
                {
                    // Open the file
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    // Show a message to the user
                    MessageHelper.DisplayMessage("Sorry we could not find the installed documentation.", "File Not Found");
                }
            }
            #endregion

            #region ViewPDFButton2_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ViewPDFButton2' is clicked.
            /// </summary>
            private void ViewPDFButton2_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Users Guide.pdf");

                // if this is the InstalledVersion
                if (IsInstalledVersion)
                {
                    // Get the path in the ProgramFiles folder
                    path = Path.GetFullPath(@"Class Room/Documents/DataTier.Net Users Guide.pdf");
                }

                // if the path exists
                if (File.Exists(path))
                {
                    // Open the file
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    // Show a message to the user
                    MessageHelper.DisplayMessage("Sorry we could not find the installed documentation.", "File Not Found");
                }
            }
            #endregion
            
            #region ViewWordButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ViewWordButton' is clicked.
            /// </summary>
            private void ViewWordButton_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Quick Start.docx");

                // if this is the InstalledVersion
                if (IsInstalledVersion)
                {
                    // Get the path in the ProgramFiles folder
                    path = Path.GetFullPath(@"Class Room/Documents/DataTier.Net Quick Start.docx");
                }
                
                // if the path exists
                if (File.Exists(path))
                {
                    // Open the file
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    // Show a message to the user
                    MessageHelper.DisplayMessage("Sorry we could not find the installed documentation.", "File Not Found");
                }
            }
            #endregion

            #region ViewWordButton2_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ViewWordButton2' is clicked.
            /// </summary>
            private void ViewWordButton2_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Users Guide.docx");

                 // if this is the InstalledVersion
                if (IsInstalledVersion)
                {
                    // Get the path in the ProgramFiles folder
                    path = Path.GetFullPath(@"Class Room/Documents/DataTier.Net Users Guide.docx");
                }
                
                // if the path exists
                if (File.Exists(path))
                {
                    // Open the file
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    // Show a message to the user
                    MessageHelper.DisplayMessage("Sorry we could not find the installed documentation.", "File Not Found");
                }
            }
            #endregion
            
            #region YouTubeButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'YouTubeButton' is clicked.
            /// </summary>
            private void YouTubeButton_Click(object sender, EventArgs e)
            {
                // open to my website
                System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCaw0joqvisKr3lYJ9Pd2vHA");
            }
            #endregion
            
        #endregion
        
        #region Methods

            #region AddColumnHeader()
            /// <summary>
            /// This method adds a status item to the list box
            /// </summary>
            private void AddColumnHeader()
            {
                // Create listItem
                this.StatusListBox.Columns.Add("", this.StatusListBox.Width);
            } 
            #endregion

            #region BuildAll()
            /// <summary>
            /// Build all classes and stored procedures
            /// </summary>
            private void BuildAll()
            {
				try
				{
				    // default value
				    this.BuildComplete = false;

                    // Update for version 1.2.3: Clearing the list box and hiding the StoredProcedures link button
                    StatusListBox.Items.Clear();
                    StoredProcedureSQLButton.Visible = false;
				
					// safeguard
					if ((OpenProject == null) || (OpenProject.Databases == null) || (OpenProject.Databases.Count < 1))
					{
						// Show a message
						string message = "You must add a database before you can build. Please add a database delete and try again." + Environment.NewLine + "If the project is corrupt it is recommended to recreate it.";
						string title = "Missing or Corrupt Database";

						// Inform user corrupt database
						MessageHelper.DisplayMessage(message, title);

						// exit
						return;
					}

                    // if the ProjectFolder deos not exist
                    if (!Directory.Exists(OpenProject.ProjectFolder))
                    {
                        // Show a message
						string message = "The project folder '" + OpenProject.ProjectFolder + "' could not be found. Edit the project and try again.";
						string title = "Project Folder Missing";

						// Inform user corrupt database
						MessageHelper.DisplayMessage(message, title);

						// exit
						return;
                    }

					// turn on hourglass
					this.Cursor = Cursors.WaitCursor;
					
					// create a file manager
					this.FileManager = new ProjectFileManager();

					// Clear ListBox
					this.StatusListBox.Items.Clear();

					// Add a column header
					AddColumnHeader();

					// Create Status Message
					CreateStatusMessage("Preparing to build...");

					// Creating Object Classes
					PerformBuildOperation(BuildClasses, "Creating Object Classes...");

                    // Get Database Status Message
					string statusMessage = CreateDatabaseStatusMessage(this.OpenProject.Databases);

					// Create Stored procs 
					PerformBuildOperation(BuildProcedures, statusMessage);

					// Creating Object Readers
					PerformBuildOperation(BuildObjectReaders, "Creating Object Readers...");

					// Creating Controllers
					PerformBuildOperation(BuildControllers, "Creating Controllers...");

					// Creating Data Operations
					PerformBuildOperation(BuildDataOperationMethods, "Creating Data Operation Methods...");

					// Creating DataManager
					PerformBuildOperation(BuildDataManager, "Creating Data Manager...");

					// Creating Stored Procedure Objects
					PerformBuildOperation(BuildStoredProcedureObjects, "Creating Stored Procedure Objects...");

					// Creating Data Object Managers
					PerformBuildOperation(BuildDataObjectManagers, "Creating Data Object Managers...");

					// Creating Data Writers
					PerformBuildOperation(BuildDataWriters, "Creating Data Writers...");

                    // Update 12.16.2012: Building gateway
                    PerformBuildOperation(BuildGatewayMethods, "Building Gateway Methods...");

					// Create Status Message
					CreateStatusMessage("Build Complete.");
					
					// the build was complete
					this.BuildComplete = true;

                    // Set the storedProceduresSQL
                    this.StoredProceduresSQLPath = GetStoredProceduresSQLPath();
					
					// enable controls
				    UIEnable();

                    // Only launch the VisualStudio Project Updater if this new files were added
                    if ((this.HasFileManager) && (FileManager.WereNewFilesCreated))
                    { 
                        // only show this for Non SDK Style Projects, which is only my work project still on .NET Framework
                        if (OpenProject.TargetFramework == TargetFrameworkEnum.NetFramework)
                        {
                            // include the files generated in the project.
                            IncludeProjectFiles();
                        }
                    }
                    
                    // Update the value for Excluded after a build.
                    StoreExcludedTables();
				}
				catch (Exception)
				{
					string message = "An error occurred building your project.";
					string title = "Build Error";
					MessageHelper.DisplayMessage(message, title);
				}
				finally
				{
                    // turn hourglass off
                    this.Cursor = Cursors.Default;
                }
            }
            #endregion

            #region BuildControllers(ref Exception error)
            /// <summary>
            /// This method builds the Controllers for each table.
            /// </summary>
            private bool BuildControllers(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // Create A ClassBuilder to build DataObjects
                    ClassBuilder classBuilder = new ClassBuilder(false);

                    // load references
                    List<ProjectReference> references = this.OpenProject.ControllerReferencesSet.References;
                    DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "Controllers");

                    // Get namespace and project namew
                    string nameSpaceName = this.OpenProject.ControllerNamespace;
                    string projectName = this.OpenProject.ProjectName;
                    string rootControllerPath = this.OpenProject.ControllerFolder;

                    // 12.19.2021
                    TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                    // Create ControllerManagerCreator
                    ControllerCreator creator = new ControllerCreator(DataTables, convertedReferences, rootControllerPath, projectName, nameSpaceName, this.FileManager, targetFramework, OpenProject);

                    // local for created
                    creator.CreateControllers(this.DataTables);

                    // set success to true
                    success = true;
                }
                catch (Exception exception)
                {
                    // Set error
                    error = exception;
                
                    // set success to false
                    success = false;
                }

                // return value
                return success;
            }
            #endregion

            #region BuildDataObjectManagers(ref Exception error)
            /// <summary>
            /// This class builds the manager for each data object.
            /// </summary>
            private bool BuildDataObjectManagers(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // Create A ClassBuilder to build DataObjects
                    ClassBuilder classBuilder = new ClassBuilder(false);

                    // load references
                    List<ProjectReference> references = this.OpenProject.DataManagerReferencesSet.References;
                    DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "DataManagers");

                    // Set rootDataManagerPath
                    string rootDataManagerPath = this.OpenProject.DataManagerFolder;

                    // Set namespace
                    string nameSpace = this.OpenProject.DataManagerNamespace;

                    // 12.19.2021
                    TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                    // Create 
                    ObjectManagerCreator creator = new ObjectManagerCreator(this.DataTables, convertedReferences, rootDataManagerPath, nameSpace, fileManager, targetFramework);

                    // local for created
                    creator.CreateObjectManagers(this.DataTables);
                    
                    // set success to true
                    success = true;
                }
                catch (Exception exception)
                {
                    // Set exception
                    error = exception;
                
                    // set success to false
                    success = false;
                }
                
                // return value
                return success;
            } 
            #endregion

            #region BuildDataOperationMethods(ref Exception error)
            /// <summary>
            /// Build the DataOperation Methods for each table.
            /// </summary>
            private bool BuildDataOperationMethods(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // Create A ClassBuilder to build DataObjects
                    ClassBuilder classBuilder = new ClassBuilder(false);

                    // load references
                    List<ProjectReference> references = this.OpenProject.DataOperationsReferencesSet.References;
                    DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "DataOperations");

                    // Get namespace and project namew
                    string nameSpaceName = this.OpenProject.DataOperationsNamespace;
                    string rootDataOperationsPath = this.OpenProject.DataOperationsFolder;

                    // 12.19.2021
                    TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                    // Create 
                    DataOperationMethodCreator creator = new DataOperationMethodCreator(this.DataTables, convertedReferences, rootDataOperationsPath, nameSpaceName, FileManager, targetFramework);

                    // local for created
                    creator.CreateDataOperationMethods(this.DataTables);

                    // set success to true
                    success = true;
                }
                catch (Exception exception)
                {
                    // Set error
                    error = exception;
                
                    // set success to false
                    success = false;            
                }
                
                // return value
                return success; 
            }
            #endregion

            #region BuildDataWriters(ref Exception error)
            /// <summary>
            /// This method builds the DataObject writers.
            /// </summary>
            private bool BuildDataWriters(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // if data tables exists
                    if (this.DataTables != null)
                    {
                        // Create ClassBuilder
                        ClassBuilder classBuilder = new ClassBuilder(false);

                        // 12.19.2021
                        TargetFrameworkEnum targetFramework = OpenProject.TargetFramework;

                        // 10.28.2021: Testing if this is needed.
                        // if not .NET8, this needs to be reloaded
                        //if (targetFramework != TargetFrameworkEnum.Net8)
                        //{
                        //    // reload
                        //    OpenProject.CreateDefaultReferences();
                        //}

                        // load references
                        List<ProjectReference> references = this.OpenProject.WriterReferencesSet.References;
                        DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "Writers");

                        // Get namespace and project namew
                        string nameSpace = this.OpenProject.DataWriterNamespace;
                        string rootDataWriterPath = this.OpenProject.DataWriterFolder;

                        // create the writer
                        DataWriterCreator writer = new DataWriterCreator(this.DataTables, convertedReferences, rootDataWriterPath, nameSpace, this.FileManager, targetFramework);

                        // Write Classes
                        writer.CreateObjectWriters();

                        // set success to true
                        success = true;
                    }
                }
                catch (Exception exception)
                {
                    // Set exception
                    error = exception;
                
                    // set success to false
                    success = false;
                }
                
                // return value
                return success;
            } 
            #endregion

            #region BuildGatewayMethods(ref Exception error)
            /// <summary>
            /// This method builds the BuildGatewayMethods methods.
            /// </summary>
            private bool BuildGatewayMethods(ref Exception error)
            {
                // initial value
                bool success = false;

                try
                {
                    // if data tables exists and has at least 1 item
                    if (ListHelper.HasOneOrMoreItems(DataTables))
                    {
                        // Create ClassBuilder
                        ClassBuilder classBuilder = new ClassBuilder(false);

                        // load references
                        List<ProjectReference> references = this.OpenProject.WriterReferencesSet.References;
                        DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "Writers");

                        // Get namespace and project namew
                        string nameSpace = OpenProject.DataWriterNamespace;
                        string projectName = OpenProject.ProjectName;
                        string gatewayPath = FindGatewayPath(OpenProject.ProjectFolder);

                        // 12.19.2021
                        TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                        // create the writer
                        GatewayCreator writer = new GatewayCreator(DataTables, convertedReferences, gatewayPath, projectName, nameSpace, this.FileManager, targetFramework);

                        // Write Classes
                        writer.CreateGatewayMethods();

                        // set success to true
                        success = true;
                    }
                }
                catch (Exception exception)
                {
                    // Set exception
                    error = exception;

                    // set success to false
                    success = false;
                }

                // return value
                return success;
            }
            #endregion

            #region BuildObjectReaders(ref Exception error)
            /// <summary>
            /// This method builds the Object Readers
            /// </summary>
            private bool BuildObjectReaders(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // if the DataTables & OpenProject exist.
                    if ((this.DataTables != null) && (this.HasOpenProject))
                    {   
                        // Create ClassBuilder
                        ClassBuilder classBuilder = new ClassBuilder(false);
                        
                        // load references
                        List<ProjectReference> references = this.OpenProject.ReaderReferencesSet.References;
                        DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "ObjectReaders");
                        
                        // 12.19.2021
                        TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                        // Create writer
                        DataObjectReaderCreator writer = new DataObjectReaderCreator(DataTables, convertedReferences, OpenProject.ReaderFolder, OpenProject.ReaderNamespace, FileManager, targetFramework);
                        
                        // Write Classes
                        writer.CreateObjectReaders();
                        
                        // set success to true
                        success = true;
                    }
                }
                catch (Exception exception)
                {   
                    // Set error
                    error = exception;
                
                    // set success to false
                    success = false;
                }
                
                // return value
                return success;
            }
            #endregion

            #region BuildClasses(ref Exception error)
            /// <summary>
            /// Build the object classes.
            /// </summary>
            /// <returns></returns>
            private bool BuildClasses(ref Exception error)
            {
                // local 
                bool success = false;
                
                // write classes
                bool writeClasses = true;
                
                try
                {
                    // Create A ClassBuilder to build DataObjects
                    ClassBuilder builder = new ClassBuilder(false);

                    // Build DataObjects & Set DataTables
                    success = builder.BuildClasses(this.OpenProject,this.FileManager, writeClasses);

                    // if the first pass was successful
                    if(success)
                    {
                        // Now Build BusinessObjects
                        builder = new ClassBuilder(true);
                        
                        // Build BusinessObjects
                        success = builder.BuildClasses(this.OpenProject, this.FileManager, writeClasses);
                        
                        // Set DataManager
                        this.DataManager = builder.DataManager;

                        // Before Saving, The DataManager must be updated with the values from the OpenProject
                        UpdateDataManager();

                        // Update for DataTier.Net - Saving the database schema for this project
                        SaveDatabaseSchema();
                    }
                }
                catch (Exception exception)
                {
                    // set error
                    error = exception;
                    
                    // set success to false
                    success = false;
                }
                
                // return value
                return success;
            } 
            #endregion

            #region BuildDataManager(ref Exception error)
            /// <summary>
            /// This method builds the DataManager object.
            /// </summary>
            private bool BuildDataManager(ref Exception error)
            {
                // initial value
                bool success = false;
            
                try
                {
                    // if the OpenProject exists
                    if(this.OpenProject != null)
                    {
                        // Create A ClassBuilder to build DataObjects
                        ClassBuilder classBuilder = new ClassBuilder(false);

                        // load references
                        List<ProjectReference> references = this.OpenProject.DataManagerReferencesSet.References;
                        DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "Controllers");

                        // Get namespace and project namew
                        string nameSpaceName = this.OpenProject.DataManagerNamespace;
                        string rootDataManagerPath = this.OpenProject.DataManagerFolder;

                        // 12.19.2021
                        TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                        // Create 
                        DataManagerCreator creator = new DataManagerCreator(this.DataTables, convertedReferences, rootDataManagerPath, OpenProject.ProjectName, nameSpaceName, this.FileManager, targetFramework);

                        // local for created
                        creator.CreateDataManager(this.DataTables);

                        // success = true
                        success = true;
                    }
                }
                catch (Exception exception)
                {
                    // Set Error
                    error = exception;
                
                    // return value
                    success = false;
                }
                
                // return value
                return success;
            }
            #endregion

            #region BuildProcedures(ref Exception error)
            /// <summary>
            /// This method builds the stored procedures
            /// </summary>
            private bool BuildProcedures(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // if data tables exists
                    if ((this.DataManager != null) && (this.DataManager.Databases != null) && (HasOpenProject) && (OpenProject.HasTables))
                    {
                        // loop through each database
                        foreach(Database db in this.DataManager.Databases)
                        {  
                            // Create sql procs
                            success = CreateProcedureSQL(db, ref error);
                        }
                    }
                }
                catch (Exception exception)
                {  
                    // Set error
                    error = exception;
                    
                    // set success = false
                    success = false;    
                }
                
                // return value
                return success;
            }
            #endregion

            #region BuildStoredProcedureObjects(ref Exception error)
            /// <summary>
            /// This method buils the stored 
            /// </summary>
            private bool BuildStoredProcedureObjects(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // Create A ClassBuilder to get database schema
                    ClassBuilder classBuilder = new ClassBuilder(false);

                    // load references
                    List<ProjectReference> references = this.OpenProject.StoredProcedureReferencesSet.References;
                    DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "StoredProcedureObjects");

                    // set namespace and project namew
                    string rootStoredProceduresPath = this.OpenProject.StoredProcedureObjectFolder;

                    // set namespace
                    string nameSpace = this.OpenProject.StoredProcedureObjectNamespace;

                    // 12.19.2021
                    TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) OpenProject.TargetFramework;

                    // Create 
                    StoredProcedureObjectCreator creator = new StoredProcedureObjectCreator(this.DataTables, convertedReferences, rootStoredProceduresPath, nameSpace, this.FileManager, targetFramework);

                    // local for created
                    creator.CreateStoredProcedureObjects(this.DataTables);

                    // set success to true
                    success = true;
                }
                catch (Exception exception)
                {
                    // get error
                    error = exception;
                    
                    // set success to false
                    success = false;
                }
                
                // return value
                return success;
            } 
            #endregion
            
            #region ConfirmDelete(string itemType)
            /// <summary>
            /// If the user confirms deleting
            /// the selected item
            /// </summary>
            /// <returns></returns>
            public bool ConfirmDelete(string itemType, string name)
            {
                // initial value
                bool confirmed = false;

                // locals
                string prompt = "Are you sure you wisth to delete the selected '" + itemType + "' named '" + name + "'?" + System.Environment.NewLine + "This action can not be undone.";
                string title = "Confirm Delete";

                // Get Dialog Result
                DialogResult result = MessageBox.Show(prompt, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // if user choose 'Yes'
                if (result == DialogResult.Yes)
                {
                    // user confirmed the delete
                    confirmed = true;
                }

                // return value
                return confirmed;
            }
            #endregion

            #region ChooseProject()
            /// <summary>
            /// This method chooses a project.
            /// </summary>
            internal void ChooseProject()
            {
                // Create instance of chooser form
                ProjectChooserForm chooserForm = new ProjectChooserForm(this.AllProjects);

                // Show the form
                chooserForm.ShowDialog();

                // All Projects must be reloaded in case a delete took place during the add
                this.AllProjects = Gateway.LoadProjects();

                // if the user did not cancel
                if (!chooserForm.UserCancelled)
                {
                    // Set the open project
                    this.OpenProject = chooserForm.SelectedProject;

                    // Load the last saved database schema (in case the user goes directly to manage tables)
                    LoadSavedDatabaseSchema();
                }
                
                // call UIEnable whether or not a project was selected.
                UIEnable();
            } 
            #endregion

            #region CreateCustomMethods(List<Method> methods)
            /// <summary>
            /// This method returns the Custom Methods
            /// </summary>
            public ProcedureWriter CreateCustomMethods(List<Method> methods)
            {
                // initial value
                ProcedureWriter textWriter = null;

                // locals
                DTNTable table = null;
                DataTable dataTable = null;
                
                // Parameter Fields
                DTNField parameterField = null;
                DataField parameter = null;
                List<DTNField> parameters = null;
                List<DataField> parameterList = null;

                // locals for OrderBy
                DTNField orderByField = null;
                FieldSet orderByFieldSet = null;
                bool descending = false;

                // locals for CustomWhere
                bool useCustomWhere = false;
                string whereText = "";

                // new feature TopRows
                int topRows = 0;
                
                // If the methods collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(methods))
                {
                    // Create a new instance of a 'ProcedureWriter' object.
                    textWriter = new ProcedureWriter(true);

                    // Iterate the collection of Method objects
                    foreach (Method method in methods)
                    { 
                        // reset the values
                        descending = false;
                        topRows = method.TopRows;

                        // set the value for useCustomWhere
                        useCustomWhere = method.UseCustomWhere;
                            
                        // if useCustomWhere is true
                        if (useCustomWhere)
                        {
                            // set the value for whereText
                            whereText = method.WhereText;
                        }
                        else
                        {
                            // erase
                            whereText = "";
                        }

                        // only update if UpdateProcedureOnBuild is true
                        if (method.UpdateProcedureOnBuild)
                        {
                            // if the table does not exist or if the Ta
                            if ((NullHelper.IsNull(table)) || (table.TableId != method.TableId))
                            {
                                // find the table
                                table = gateway.FindDTNTable(method.TableId);
                            }

                            // if the CustomReaderId is set
                            if (method.CustomReaderId > 0)
                            {
                                // set the CustomReader
                                method.CustomReader = gateway.FindCustomReader(method.CustomReaderId);    

                                // If the value for the property method.HasCustomReader is true
                                if (method.HasCustomReader)
                                {
                                    // Set the FieldSet
                                    method.CustomReader.FieldSet = gateway.FindFieldSet(method.CustomReader.FieldSetId);

                                    // if the CustomReader.FieldSet exists
                                    if (method.CustomReader.HasFieldSet)
                                    {
                                        // Load the Fields
                                        method.CustomReader.FieldSet.Fields = FieldSetHelper.LoadFieldSetFields(method.CustomReader.FieldSetId);

                                        // if the Fields collection exists and has 1 or ore itm                                        
                                        if (ListHelper.HasOneOrMoreItems(method.CustomReader.FieldSet.Fields))
                                        {
                                            // Convert the DTNFields to DataJuggler.Net.DataField o
                                            method.CustomReader.FieldSet.DataFields = DataConverter.ConvertDataFields(method.CustomReader.FieldSet.Fields);
                                        }
                                    }
                                }
                            }

                            // if OrderByType equals SingleField
                            if (method.OrderByType == OrderByTypeEnum.Single_Field)
                            {
                                // Single Field
                                orderByField = gateway.FindDTNField(method.OrderByFieldId);

                                // set the value for descending
                                descending = method.OrderByDescending;
                            }
                            // if OrderByType equals FieldSet
                            else if (method.OrderByType == OrderByTypeEnum.Field_Set)
                            {
                                // set the fieldSet
                                orderByFieldSet = gateway.FindFieldSet(method.OrderByFieldSetId);

                                // Field Set
                                orderByFieldSet.Fields = FieldSetHelper.LoadFieldSetFields(method.OrderByFieldSetId);
                            }
                            else
                            {
                                // Erase both values
                                orderByField = null;
                                orderByFieldSet = null;
                            }

                            // if the table exists
                            if (NullHelper.Exists(table))
                            {
                                // now load the fields for this table
                                table.Fields = gateway.LoadDTNFieldsForTable(method.TableId);

                                // Convert the table
                                dataTable = DataConverter.ConvertDataTable(table, this.OpenProject);

                                // if this is a Single Field
                                if (method.ParameterType == ParameterTypeEnum.Single_Field)
                                {
                                    // load the parameter Field
                                    parameterField = gateway.FindDTNField(method.ParameterFieldId);

                                    // Convert the field to a parameter
                                    parameter = DataConverter.ConvertDataField(parameterField);

                                    // if this is a Delete By Proc
                                    if (method.MethodType == MethodTypeEnum.Delete_By)
                                    {
                                        // Delete procedures do not need to be updated since there is not a select statement
                                    }
                                    // If Find By is the Method Type
                                    else if (method.MethodType == MethodTypeEnum.Find_By)
                                    {
                                        // create a find procedure
                                        textWriter.CreateFindProc(dataTable, false, method.ProcedureName, parameter, method.CustomReader, orderByField, orderByFieldSet, descending, topRows, useCustomWhere, whereText);
                                    }
                                    else if (method.MethodType == MethodTypeEnum.Load_By)
                                    {
                                        // create a fetch all procedure
                                        textWriter.CreateFindProc(dataTable, true, method.ProcedureName, parameter, method.CustomReader, orderByField, orderByFieldSet, descending, topRows, useCustomWhere, whereText);
                                    }
                                }
                                else if (method.ParameterType == ParameterTypeEnum.Field_Set)
                                {
                                    // load the parameters
                                    parameters = FieldSetHelper.LoadFieldSetFields(method.ParametersFieldSetId);

                                    // create a parametersList
                                    parameterList = DataConverter.ConvertDataFields(parameters);

                                     // if this is a Delete By Proc
                                    if (method.MethodType == MethodTypeEnum.Delete_By)
                                    {
                                        // Delete procedures do not need to be updated since there is not a select statement
                                    }
                                    // If Find By is the Method Type
                                    else if (method.MethodType == MethodTypeEnum.Find_By)
                                    {
                                        // create a find procedure
                                        textWriter.CreateFindProc(dataTable, false, method.ProcedureName, parameterList, method.CustomReader, orderByField, orderByFieldSet, descending, topRows, useCustomWhere, whereText);
                                    }
                                    else if (method.MethodType == MethodTypeEnum.Load_By)
                                    {
                                        // create a fetch all procedure
                                        textWriter.CreateFindProc(dataTable, true, method.ProcedureName, parameterList, method.CustomReader, orderByField, orderByFieldSet, descending, topRows, useCustomWhere, whereText);
                                    }
                                }
                                else
                                {
                                    // erase everything
                                    parameter = null;
                                    parameterField = null;
                                    parameters = null;
                                    parameterList = null;
                                }
                            }
                        }
                    }
                }
                
                // return value
                return textWriter;
            }
            #endregion
            
            #region CreateDatabaseStatusMessage(List<DTNDatabase> databases)
            /// <summary>
            /// This method creates the database status message.
            /// </summary>
            /// <param name="databasesCollection"></param>
            /// <returns></returns>
            private string CreateDatabaseStatusMessage(List<DTNDatabase> databases)
            {
                // create string builder
                StringBuilder sb = new StringBuilder("Creating ");

                // locals
                bool hasSQL = false;
                
                // Loop through each database
                foreach (DTNDatabase database in databases)
                {  
                    // set hasSQL to true
                    hasSQL = true;

                    // break out of loop
                    break;
                }
                
                // if has SQL
                if(hasSQL)
                {
                    // Append Creating Both Messages
                    sb.Append("Sql Stored Procedures..."); 
                }
                
                // return value
                return sb.ToString();
            } 
            #endregion

            #region CreateNewProject()
            /// <summary>
            ///  This method creates a new project.
            /// </summary>
            private Project CreateNewProject()
            {
                // initial value
                Project project = null;

                // Create instance of ProjectWizardForm.
                ProjectWizardForm wizardForm = new ProjectWizardForm();

                // set wizardForm
                Project newProject = new Project();

                // New projects must create default references
                newProject.CreateDefaultReferences();

                // Setup Wizartd Form
                wizardForm.ProjectWizardControl.Setup(newProject, ActiveControlEnum.ProjectsTab, this);

                // set the images
                wizardForm.ProjectWizardControl.SetImages(this.SelectedImage, this.NotSelectedImage);

                // Setup WizardForm
                wizardForm.ShowDialog();

                // set project.
                project = wizardForm.ProjectWizardControl.SelectedProject;

                // if the project exists and it is not new (meaning the project was saved.)
                if ((project != null) && (!project.IsNew))
                {
                    // All Projects must be reloaded at this point
                    this.AllProjects = Gateway.LoadProjects();

                    // Set the open project
                    this.OpenProject = project;

                    // Load and Save the database schema, so tables or fields can be excluded before the first build
                    LoadAndSaveDatabaseSchema();

                    // Set the open project again (this time child objects will load since the schema has been saved)
                    this.OpenProject = project;

                    // Display Selected Project
                    this.DisplaySelectedProject(project);
                }
                
                // Enable Controls
                UIEnable();

                // return value
                return project;
            }
            #endregion
          
            #region CreateProcedureSQL(Databases database, ref Exception error)
            /// <summary>
            /// This method writes the procedure sql to a file.
            /// </summary>
            /// <param name="database"></param>
            private bool CreateProcedureSQL(Database db, ref Exception error)
            {
                // initial value
                bool success = false;

                try
                {
                    // local
                    string filePath = Path.Combine(OpenProject.StoredProcsFolder, "StoredProcedures.sql");
                    
                    // If the database exists
                    if (NullHelper.Exists(db, db.Tables, Gateway))
                    {
                        // Update for DataTier.Net: Custom Methods must be loaded
                        List<Method> methods = this.Gateway.LoadMethodsByProjectId(this.OpenProject.ProjectId);
                        List<TextLine> textLines = null;

                        // If the methods collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(methods))
                        {
                             // Create a new instance of a 'ProcedureWriter' object.
                            ProcedureWriter textWriter = CreateCustomMethods(methods);

                            // if the textWriter exists and the StringBuilder exists
                            if ((NullHelper.Exists(textWriter)) && (textWriter.HasTextWriter))
                            {
                                // get the string
                                string text = textWriter.TextWriter.ToString();

                                // get the text
                                textLines = TextHelper.GetTextLines(text);
                            }
                        }

                        // create stored procedure writer
                        ProcedureWriter writer = new ProcedureWriter();

                        // Create stored procedures
                        writer.CreateStoredProcedures(db.ActiveTables, filePath, textLines, db.Name);

                        // set success to true
                        success = true;
                    }
                }
                catch (Exception exception)
                {   
                    // Set the error
                    error = exception;
                }
                
                // return value
                return success;
            } 
            #endregion

            #region CreateStatusMessage(string statusMessage)
            /// <summary>
            /// This method creates the status message. This is to be 
            /// used before you call a build method. After the completion
            /// of a build method, call UpdateStatusMessage with the
            /// success or failure.
            /// </summary>
            /// <param name="statusMessage"></param>
            private ListViewItem CreateStatusMessage(string statusMessage)
            {
                // initial value
                ListViewItem listItem = this.StatusListBox.Items.Add(statusMessage);
                
                // Refresh
                this.Refresh();
                
                // return value
                return listItem;
            }
            #endregion
            
            #region DisplaySelectedProject()
            /// <summary>
            /// This method displays the selected project.
            /// </summary>
            internal void DisplaySelectedProject(Project project)
            {
                // initial value
                string projectName = "No Project Selected";

                // if the project exists
                if (project != null)
                {
                    // set projectName
                    projectName = project.ProjectName;
                }

                // display value on control
                CurrentProjectLabel.Text = projectName;

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region EditProject()
            /// <summary>
            /// This method edits the selected project.
            /// </summary>
            private void EditProject()
            {
                // If the ParentMainForm exists
                if (this.HasOpenProject)
                {
                    // Create instance of ProjectWizardForm.
                    ProjectWizardForm wizardForm = new ProjectWizardForm();

                    // set wizardForm
                    Project project = this.OpenProject;

                    // Setup Wizartd Form
                    wizardForm.ProjectWizardControl.Setup(project, ActiveControlEnum.ProjectsTab, this);

                    // set the images
                    wizardForm.ProjectWizardControl.SetImages(this.SelectedImage, this.NotSelectedImage);

                    // Setup WizardForm
                    wizardForm.ShowDialog();

                    // set project.
                    project = wizardForm.ProjectWizardControl.SelectedProject;

                    // Set the open project
                    this.OpenProject = project;

                    // Display Selected Project
                    this.DisplaySelectedProject(project);

                    // Enable Controls
                    UIEnable();
                }
            }
            #endregion

            #region FindGatewayPath(string projectFolder)
            /// <summary>
            /// This method returns the Gateway Path
            /// </summary>
            private string FindGatewayPath(string projectFolder)
            {
                // initial value
                string gatewayPath = "";

                try
                {
                    List<string> files = new List<string>();
                    List<string> extensions = new List<string>();
                    extensions.Add(".cs");

                    // if the projectFolder exists
                    if (Directory.Exists(projectFolder))
                    {
                        // get the files
                        FileHelper.GetFilesRecursively(projectFolder, ref files, extensions);

                        // If the files collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(files))
                        {
                            // Iterate the collection of string objects
                            foreach (string file in files)
                            {
                                // create a fileInfo
                                FileInfo fileInfo = new FileInfo(file);

                                // if this is the Gateway
                                if (TextHelper.IsEqual(fileInfo.Name, "Gateway.cs"))
                                {
                                    // set the return value
                                    gatewayPath = file;

                                    // exit the loop
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return gatewayPath;
            }
            #endregion
            
            #region GetSqlHash()
            /// <summary>
            /// This method returns the Sql Hash
            /// </summary>
            public string GetSqlHash()
            {
                // initial value
                string sqlHash = "";

                // create a database
                Database database = new Database();

                // paste in your connectionstring
                database.ConnectionString = ConfigurationHelper.ReadAppSetting("Connectionstring");

                try
                {
                    // if the connecionstring exists
                    if (TextHelper.Exists(database.ConnectionString))
                    {
                        // Create a new instance of a 'SQLDatabaseConnector' object.
                        SQLDatabaseConnector connector = new SQLDatabaseConnector();

                        // set the connectionstring on the connector
                        connector.ConnectionString = database.ConnectionString;

                        // open the connection
                        connector.Open();

                        // get the sqlHash
                        sqlHash = connector.GetDatabaseSchemaHash(database);

                        // close the connection
                        connector.Close();
                    }
                    else
                    {
                        // Show the user a message
                        MessageHelper.DisplayMessage("You must paste in a connection string to continue.", "Connectionstring Required");
                    }
                }
                catch (Exception error)
                {
                    // Show the user a message
                    DebugHelper.WriteDebugError("GetSqlHash", this.Name, error);
                }
                
                // return value
                return sqlHash;
            }
            #endregion
            
            #region GetStoredProceduresSQLPath()
            /// <summary>
            /// This method returns the Stored Procedures SQL Path
            /// </summary>
            public string GetStoredProceduresSQLPath()
            {
                // initial value
                string storedProceduresSQLPath = "";

                // if the value for HasOpenProject is true
                if ((HasOpenProject) && (TextHelper.Exists(OpenProject.ProjectFolder)))
                {
                    // if the ProjectFolder exists on the hard drive
                    if (Directory.Exists(OpenProject.ProjectFolder))
                    {
                        // set the storedProcedure
                        storedProceduresSQLPath = Path.Combine(OpenProject.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\StoredProcedureSQL\StoredProcedures.sql");
                    }
                }
                
                // return value
                return storedProceduresSQLPath;
            }
            #endregion
            
            #region IncludeProjectFiles()
            /// <summary>
            /// This method updates the files that are generated and not
            /// included in the Visual Studio project yet.
            /// </summary>
            private void IncludeProjectFiles()
            {
                // verify the file manager.Files exists
                if ((this.FileManager != null) && (this.FileManager.Files != null))
                {
                    // create an instance of an UpdateForm.
                    VisualStudioProjectUpdateForm updateForm = new VisualStudioProjectUpdateForm();
                    
                    // setup the control
                    updateForm.Setup(this.OpenProject, this.FileManager.Files);
                    
                    // show the form
                    updateForm.Show();
                    
                    // if the user did not cancel
                    if (!updateForm.UserCancelled)
                    {
                        // set build
                        this.BuildComplete = false;
                    }

                    // Recreate the ProjectFileManager so that this button will no longer be enabled.
                    this.FileManager = new ProjectFileManager();

                    // Enable or disable controls
                    UIEnable();
                }
            } 
            #endregion

            #region Init()
            /// <summary>
            /// This method performs Initializations for this object.
            /// </summary>
            private void Init()
            {
                // local
                bool userCancelledSetup = false;
                bool restartRequired = false;
               
                // Adding the version number (taking off the last .0. Probably will never be used).
                this.Text = "DataTier.Net - Version " + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);

                // Create the buttonManager
                ButtonManager = new ButtonManager();

                // Test the database connection, if this fails, it will run setup again
                SetupComplete = TestDatabaseConnection();
               
                // If the Setup is not complete, show the Setup Form
                if (!SetupComplete)
                {
                    // run the setup
                    userCancelledSetup = RunSetup();

                    // if the user did not cancel
                    if (!userCancelledSetup)
                    {
                        // A restart is required if the user did not cancel
                        restartRequired = true;
                    }
                }

                // If Setup is complete
                if (SetupComplete)
                {
                    // Connect To The Local Database
                    bool connected = TestDatabaseConnection();
                
                    // If not connected 
                    if(!connected)
                    {  
                        // set message
                        string message = "A connection to the database could not be established.";

                        // set the title
                        string title = "Connection Failed.";
                    
                        // Inform user of connection
                        MessageHelper.DisplayMessage(message, title);
                    
                        // Close this form
                        this.Close();
                    
                        // Exit this routine
                        return;
                    }

                    // Create the gateway
                    this.Gateway = new Gateway();

                    // Load Projects
                    this.AllProjects = this.Gateway.LoadProjects();

                    Exception error = gateway.GetLastException();
                 
                    // Create the AppController
                    this.AppController = new ApplicationController();
                
                    // set the selected and not selected images
                    this.SelectedImage = ImageHelper.LoadImage(ButtonImagesEnum.DeepBlue);
                    this.NotSelectedImage = ImageHelper.LoadImage(ButtonImagesEnum.DeepGray);
                
                    // set the images in the buttons
                    this.NewProjectButton.Enabled = true;
                    this.OpenProjectButton.Enabled = true;    
                    this.BuildAllButton.Enabled = false;
                    this.EditProjectButton.Enabled = false;
                    this.CloseProjectButton.Enabled = false;

                    // Enable Controls
                    UIEnable();
                }
                else
                {  
                    // run the final part of user cancelled setup
                    UserCancelledSetup(userCancelledSetup, restartRequired);
                }
            }
            #endregion
            
            #region LoadAndSaveDatabaseSchema()
            /// <summary>
            /// This method Load And Save Database Schema
            /// </summary>
            public void LoadAndSaveDatabaseSchema()
            {
                try
				{
					// safeguard
					if ((this.OpenProject == null) || (this.OpenProject.Databases == null) || (this.OpenProject.Databases.Count < 1))
					{
						// Show a message
						string message = "The current project does not have any databases created. You must edit this project and add one or more databases.";
						string title = "Databases Required";

						// Inform user corrupt database
						MessageHelper.DisplayMessage(message, title);

						// exit
						return;
					}
					
					// turn on hourglass
					this.Cursor = Cursors.WaitCursor;

                    // Create a new instance of a 'ClassBuilder' object, which inherits from CSharpClassWriter
                    ClassBuilder builder = new ClassBuilder(false);

                    // Create the DataManager, Note, VBNet is not supported, I just never felt like removing that. I was never fond of VBNet.
                    builder.DataManager = new DataManager(OpenProject.ProjectFolder, OpenProject.ProjectName, DataManager.ClassOutputLanguage.CSharp);

                    // Display Message
                    ListViewItem listItem = CreateStatusMessage("Loading database schema...");                
                
                    // Add the databases
                    builder.AddDatabases(ref openProject);

                    // if the builder.Databases exist
                    if ((builder.DataManager != null) && (ListHelper.HasOneOrMoreItems(builder.DataManager.Databases)))
                    {
                        // now update the list item with success
                        UpdateStatus(listItem, true);    
                    }
                    else
                    {
                        // Set the tag
                        listItem.Tag = "Failed to load database schema.";

                        // now update the list item with failure
                        UpdateStatus(listItem, false);    
                    }

                    // Set DataManager
                    this.DataManager = builder.DataManager;

                    // Save the Database Schema
                    SaveDatabaseSchema();

                    // Now we must reload the schema to fix an issue of the TableIds not being set 
                    LoadSavedDatabaseSchema();
					
					// enable controls
				    UIEnable();
				}
				catch (Exception error)
				{
                    // for debugging only
                    string err = error.ToString();

					string message = "An error occurred loading your database schema and saving your project.";
					string title = "Load And Save Database Schema Error";
					MessageHelper.DisplayMessage(message, title);
				}
				finally
				{
                    // turn hourglass off
                    this.Cursor = Cursors.Default;
                }
            }
            #endregion
            
            #region LoadSavedDatabaseSchema()
            /// <summary>
            /// This method Load Saved Database Schema
            /// </summary>
            public void LoadSavedDatabaseSchema()
            {
                // If the OpenProject object exists
                if (this.HasOpenProject)
                {
                    // load the tables for this project
                    OpenProject.Tables = Gateway.LoadDTNTablesByProjectId(this.OpenProject.ProjectId);

                    // If the tables collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(OpenProject.Tables))
                    {
                        // Iterate the collection of DTNTable objects
                        foreach (DTNTable table in OpenProject.Tables)
                        {
                            // Load the fields for this table
                            table.Fields = gateway.LoadDTNFieldsForTable(table.TableId);
                        }
                    }
                }
            }
            #endregion
            
            #region PerformBuildOperation(BuildOperation buildMethod, string displayText)
            /// <summary>
            /// This method performs a build operation and updates
            /// the status for the operation.
            /// </summary>
            /// <param name="buildMethod"></param>
            private bool PerformBuildOperation(BuildOperation buildMethod, string displayText)
            {
                // initial value
                bool success = false;
                
                // local 
                Exception error = null;
                
                // Display Message
                ListViewItem listItem = CreateStatusMessage(displayText);                
                
                // execute method
                success = buildMethod(ref error);
                
                // set the tag
                listItem.Tag = error;

                // now update the list item with success or failure
                UpdateStatus(listItem, success);
                
                // return value
                return success;
            } 
            #endregion
        
            #region RunSetup()
            /// <summary>
            /// This method Run Setup
            /// </summary>
            public bool RunSetup()
            {
                // initial value
                bool userCancelled = true;

                // Create a new instance of a 'SetupForm' object.
                SetupForm setupForm = new SetupForm();

                // Show the SetupForm
                setupForm.ShowDialog();

                // if the user did not cancel
                if (!setupForm.UserCancelled)
                {
                    // User did not cancel, therefore a restart is required
                    userCancelled = false;

                    // if SetupComplete is true
                    if (!SetupComplete)
                    {
                        // Set the value for SetupComplete
                        SetupComplete = setupForm.SetupComplete;
                    }

                    // DataTier.Net has to be restarted.
                    MessageHelper.DisplayMessage("DataTier.Net has to be restarted to register your changes." + Environment.NewLine + "This program will now end.", "Restart Required");

                    // close this form
                    this.Close();
                }
                
                // return value
                return userCancelled;
            }
            #endregion
            
            #region SaveDatabaseSchema()
            /// <summary>
            /// This method returns the Database Schema
            /// </summary>
            public bool SaveDatabaseSchema()
            {
                // initial value
                bool saved = false;

                // Display Message
                ListViewItem listItem = CreateStatusMessage("Saving Database Schema...");

                // Update the UI
                this.Refresh();
                Application.DoEvents();

                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway();

                // locals
                Exception error = null;
                DTNTable existingTable = null;
                List<DTNTable> existingTables = null;

                // if the DataManager exists and has one or more Databases
                if ((this.HasDataManager) && (ListHelper.HasOneOrMoreItems(this.DataManager.Databases)) && (this.HasOpenProject))
                {
                    // change the value to true until something fails
                    saved = true;

                    // Now the tables are loaded when the project is opened
                    List<DTNTable> tables = this.OpenProject.Tables;

                    // load the existingTables
                    existingTables = gateway.LoadDTNTablesByProjectId(OpenProject.ProjectId);

                    // The tables above stay loaded in memory, so we still have the values for Exclude 
                    // which is going to be reset after the values are set
                    
                    // iterate the Databases
                    foreach (Database database in this.DataManager.Databases)
                    {
                        // Find the Database in the project for this database
                        DTNDatabase projectDatabase = OpenProject.Databases.FirstOrDefault(x => x.DatabaseName == database.Name);

                        // verify the projectDatabase was found
                        if (NullHelper.Exists(projectDatabase))
                        {
                            // iterate the tables
                            foreach (DataTable dataTable in database.Tables)
                            {
                                // Convert this DataTable to a DTNTable to store in SQL
                                DTNTable table = DataConverter.ConvertDataTable(dataTable, this.OpenProject, projectDatabase);

                                // before saving we must see if we can find this table 

                                // if the existingTables collection exists
                                if (NullHelper.Exists(existingTables)) 
                                {
                                    // now attempt to find this table in the existing tables
                                    existingTable  = existingTables.FirstOrDefault(x => x.TableName == table.TableName);    
                                }

                                // If the existingTable object exists
                                if (NullHelper.Exists(existingTable))
                                {
                                    // load the existing Fields
                                    existingTable.Fields = gateway.LoadDTNFieldsForTable(existingTable.TableId);

                                    // preserve the Exclude value
                                    table.Exclude = existingTable.Exclude;

                                    // set the Exclude value on the DataTable - The DataTable is what is the code generation source object
                                    dataTable.Exclude = existingTable.Exclude;

                                    // Set to true
                                    existingTable.FoundInLatestSchema = true;

                                    // Update the Id so a Save is performed instead of a 
                                    table.UpdateIdentity(existingTable.TableId);
                                }

                                // Save the table
                                bool tempSaved = gateway.SaveDTNTable(ref table);

                                // if the value for tempSaved is true
                                if ((tempSaved) && (ListHelper.HasOneOrMoreItems(dataTable.Fields)))
                                {
                                    // load the fields
                                    table.Fields = DataConverter.ConvertDataFields(dataTable.Fields, projectDatabase.DatabaseId, openProject.ProjectId, table.TableId);
                                
                                    // if the table has fields
                                    if (table.HasFields)
                                    {
                                        // now save each field
                                        foreach (DTNField field in table.Fields)
                                        {
                                            // before saving, we must see if we can find this field in the existingTable

                                            // If the existingTable object exists and it is not a new table
                                            if ((NullHelper.Exists(existingTable)) && (!existingTable.IsNew) && (ListHelper.HasOneOrMoreItems(existingTable.Fields)))
                                            {
                                                // attempt to find the existingField
                                                DTNField existingField = existingTable.Fields.FirstOrDefault(x => x.FieldName == field.FieldName);

                                                // if the existingField was found
                                                if ((NullHelper.Exists(existingField)) && (!existingField.IsNew))
                                                {
                                                    // Update the Id so the field is updated and not inserted
                                                    field.UpdateIdentity(existingField.FieldId);

                                                    // if the field was already excluded, make sure it still is
                                                    field.Exclude = existingField.Exclude;
                                                
                                                    // if the field is excluded
                                                    if (field.Exclude)
                                                    {
                                                        // find this field in the dataTable.Fields and set the Exclude value
                                                        DataField dataField = dataTable.Fields.FirstOrDefault(x => x.FieldName == field.FieldName);

                                                        // if the dataField was found
                                                        if (NullHelper.Exists(dataField))
                                                        {
                                                            // set to true
                                                            dataField.Exclude = true;
                                                        }
                                                    }
                                                }
                                            }

                                            // clone this field so it can be passed by reference
                                            DTNField clone = field.Clone();

                                            // Save the DTNField
                                            tempSaved = gateway.SaveDTNField(ref clone);

                                            // if not saved
                                            if (!tempSaved)
                                            {
                                                // set to false
                                                saved = false;

                                                // get the error, for debugging only
                                                error = gateway.GetLastException();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // save failed
                                    saved = false;

                                    // get the error, for debugging only
                                    error = gateway.GetLastException();
                                }

                                // Update 12.28.2018: We must load the fields from the database for this table, and
                                //                              test if any fields have been dropped from the database.
                                if ((NullHelper.Exists(existingTable)) && (!existingTable.IsNew) && (ListHelper.HasOneOrMoreItems(existingTable.Fields)))
                                {  
                                    // iterate the fields for this table
                                    foreach (DTNField existingField in existingTable.Fields)
                                    {
                                        // we must check that each of these fields exists in the dataTable now, else it was dropped
                                        DataField field = dataTable.Fields.FirstOrDefault(x => x.FieldName == existingField.FieldName);

                                        // if the field does not exist
                                        if (NullHelper.IsNull(field))
                                        {
                                            // perform the delete
                                            bool deleted = Gateway.DeleteDTNField(existingField.FieldId);

                                            // if the value for deleted is false
                                            if (!deleted)
                                            {
                                                // not saved
                                                saved = false;
                                            }
                                        }
                                    }
                                }
                            }

                            // Update 12.29.2018: We must check if any tables have been dropped. 
                            List<DTNTable> deleteTables = existingTables.Where(x => x.FoundInLatestSchema == false).ToList();

                            // If the deleteTables collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(deleteTables))
                            {
                                // Iterate the collection of DTNTable objects
                                foreach (DTNTable table in deleteTables)
                                {
                                    // perform the delete
                                    bool deleted = Gateway.DeleteDTNTable(table.TableId);

                                    // if the value for deleted is false
                                    if (!deleted)
                                    {
                                        // toggle the value
                                        saved = false;
                                    }
                                }
                            }
                        }
                    }
                }

                // Update Status
                UpdateStatus(listItem, saved);
                
                // set the tag
                listItem.Tag = error;
                
                // return value
                return saved;
            }
            #endregion

            #region SaveDTNDatabaseSchema(ChangesSet changesSet)
            /// <summary>
            /// This method saves the CurrentProject.Tables
            /// without requiring the DataManager be present like
            /// the SaveDatabaseSchema method.
            /// </summary>
            public bool SaveChangesSet(ChangesSet changesSet)
            {
                // initial value
                bool saved = false;

                // locals
                bool tempSaved = false;
                DTNTable table = null;
                DTNField field = null;

                // If the changesSet object exists and there any Tables or Fields with Exclude changed
                if ((NullHelper.Exists(changesSet)) && (changesSet.HasOneOrMoreChanges) && (HasOpenProject) && (OpenProject.HasTables))
                {  
                    // default to true
                    saved = true;

                    // itereate the changes
                    foreach(ExcludeInfo change in changesSet.Changes)
                    {
                        // attempt to find this table
                        table = OpenProject.Tables.FirstOrDefault(x => x.TableId == change.TableId);

                        // if the tableExists
                        if (NullHelper.Exists(table))
                        {
                            // if a Table has changed
                            if (change.ObjectType == ExcludeObjectTypeEnum.Table)
                            {
                                // Set the new value for Exclude
                                table.Exclude = change.Exclude;

                                // Save this table
                                tempSaved = Gateway.SaveDTNTable(ref table);

                                // if not saved
                                if (!tempSaved)
                                {
                                    // set saved to false
                                    saved = false;
                                }
                            }
                            // if a Field has changed
                            else if (change.ObjectType == ExcludeObjectTypeEnum.Field)
                            {
                                // If the value for the property table.HasFields is true
                                if (table.HasFields)
                                {
                                    // attempt to find the field
                                    field = table.Fields.FirstOrDefault(x => x.FieldId == change.FieldId && x.TableId == change.TableId);

                                    // If the field object exists
                                    if (NullHelper.Exists(field))
                                    {
                                        // Set the Field
                                        field.Exclude = change.Exclude;

                                         // Save this field
                                        tempSaved = Gateway.SaveDTNField(ref field);

                                        // if not saved
                                        if (!tempSaved)
                                        {
                                            // set saved to false
                                            saved = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                // return value
                return saved;
            }
            #endregion
            
            #region ShowOrHideControls(VisibilityEnum visibility)
            /// <summary>
            /// This method Show Or Hide Controls
            /// </summary>
            public void ShowOrHideControls(VisibilityEnum visibility)
            {
                if (visibility == VisibilityEnum.Show)
                {
                    // Show or hide any controls that are in the way of the AdverSkyControls
                    this.RightPanel.Visible = true;
                    this.StatusListBox.Visible = true;
                }
                else
                {
                    // Hide any controls that are in the way of the AdverSkyControls
                    this.RightPanel.Visible = false;
                    this.StatusListBox.Visible = false;
                }
            }
            #endregion
            
            #region StoreExcludedTables()
            /// <summary>
            /// This method Store Excluded Tables
            /// </summary>
            public void StoreExcludedTables()
            {
                // local
                bool saved = false;

                // if the Databases collection exist
                if (OpenProject.HasDatabases)
                {
                    // iterate the databases
                    foreach (DTNDatabase database in OpenProject.Databases)
                    {
                        // if this database has tables
                        if (NullHelper.Exists(database.Tables))
                        {
                            // iterate the tables
                            foreach (DTNTable table in database.Tables)
                            {
                                // If the values are not for equal
                                if (table.Exclude != table.Excluded)
                                {
                                    // Toggle the value of Excluded to the value of Exclude
                                    table.Excluded = table.Exclude;

                                    // Clone this object
                                    DTNTable clone = table.Clone();

                                    // Perform the save
                                    saved = this.Gateway.SaveDTNTable(ref clone);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region TestDatabaseConnection()
            /// <summary>
            /// This method tests the database connection.
            /// </summary>
            internal bool TestDatabaseConnection()
            {
                // initial value
                bool connected = false;
            
                // Create App Controller
                this.AppController = new ApplicationController();

                // Clear ListBox
                this.StatusListBox.Items.Clear();

                // Add a column header
                AddColumnHeader();

                // Creating Data Writers
                connected = PerformBuildOperation(this.AppController.TestDatabaseConnection, "Testing Database Connection...");

                // Create Status Message
                CreateStatusMessage("Test Complete.");
                
                // return value
                return connected;
            } 
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// Enable controls
            /// </summary>
            internal void UIEnable()
            {
                // initial values
                bool enabled = (this.OpenProject != null);
                
                // set the control's enable property
                ButtonManager.EnableBuiildAll = enabled;
                ButtonManager.EnableNewProject = !enabled;
                ButtonManager.EnableOpenProject = !enabled;
                ButtonManager.EnableEditProject = enabled;
                ButtonManager.EnableCloseProject = enabled;

                // Now Update Each Button's Image
                ButtonManager.HandleButtonImage(NewProjectButton, ButtonManager.EnableNewProject);
                ButtonManager.HandleButtonImage(OpenProjectButton, ButtonManager.EnableOpenProject);
                ButtonManager.HandleButtonImage(EditProjectButton, ButtonManager.EnableEditProject);
                ButtonManager.HandleButtonImage(CloseProjectButton, ButtonManager.EnableCloseProject);
                ButtonManager.HandleButtonImage(BuildAllButton, ButtonManager.EnableBuiildAll);
                
                // if the value for enabled is true
                if (enabled)
                {
                    CurrentProjectLabel.ForeColor = Color.LemonChiffon;
                }
                else
                {
                    CurrentProjectLabel.ForeColor = Color.DimGray;
                }

                // if the OpenProject exists
                if ((HasOpenProject) && (this.OpenProject.HasTables) && (this.OpenProject.Tables.Count > 0))
                {
                    // Update for DataTier.Net version 1
                    ManageDataButton.ForeColor = Color.LemonChiffon;
                    ManageDataButton.Enabled = true;
                    ButtonManager.HandleButtonImage(ManageDataButton, true);

                    // Set up the StoredProcedureSQLButton (white button)
                    StoredProcedureSQLButton.Visible = true;
                    
                    // Show the StoredProcedureSQLButton if the StoredProceduresSQLPath text exists and the file exists
                    this.StoredProcedureSQLButton.Visible = ((HasStoredProceduresSQLPath) && (File.Exists(StoredProceduresSQLPath)));
                }
                else
                {
                    // Update for DataTier.Net v1
                    ManageDataButton.Enabled = false;
                    ButtonManager.HandleButtonImage(ManageDataButton, false);
                    StoredProcedureSQLButton.Visible = false;
                }

                // if there is an OpenProject
                if (HasOpenProject)
                {
                    // get the dataObjectsFolder
                    string gatewayPath = Path.Combine(OpenProject.ProjectFolder, @"DataGateway\Gateway.cs");

                    // if the Template Version is 2
                    if (OpenProject.TemplateVersion == 2)
                    {
                        // V2 inside DataAccessComponent
                        gatewayPath = Path.Combine(OpenProject.ProjectFolder, @"DataAccessComponent\DataGateway\Gateway.cs");
                    }

                    // If the file does not exist on disk
                    RepairGatewayButton.Visible = (!File.Exists(gatewayPath));
                }
                else
                {
                    // Hide
                    RepairGatewayButton.Visible = false;
                }

                // refresh everything
                this.Refresh();
            }
            #endregion

            #region UpdateDataManager()
            /// <summary>
            /// This method Update Data Manager
            /// </summary>
            public void UpdateDataManager()
            {
                // if data tables exists
                if ((this.DataManager != null) && (this.DataManager.Databases != null) && (HasOpenProject) && (OpenProject.HasTables))
                {
                    // Before Calling Create Procedures, the DataManager.Databases need to be
                    // updated with the value of Exclude from the CurrentProject.Tables
                    // so that procedures are not created for Excluded Tables, and to make
                    // sure fields are not written if they are excluded
                    // loop through each database
                    foreach(Database db in this.DataManager.Databases)
                    {  
                        // if the database has tables
                        if (db.HasTables)
                        {
                            // iterate the Tables
                            foreach (DataTable dataTable in db.Tables)
                            {
                                // here we must attempt to find the DTNTable that matches this DataTable
                                DTNTable table = OpenProject.Tables.FirstOrDefault(x => x.TableName == dataTable.Name);

                                // If the table object exists
                                if (NullHelper.Exists(table))
                                {
                                    // Update the value for Exclude to the current value from the project
                                    dataTable.Exclude = table.Exclude;

                                    // if this table should not be excluded
                                    if ((!dataTable.Exclude) && (dataTable.Fields != null) && (table.HasFields))
                                    {
                                        // iterate the fields
                                        foreach (DataField dataField in dataTable.Fields)
                                        {
                                            // Now we must find the DTNField in the table
                                            DTNField field = table.Fields.FirstOrDefault(x => x.FieldName == dataField.FieldName);

                                            // If the field object exists
                                            if (NullHelper.Exists(field))
                                            {
                                                // Set the value for Exclude
                                                dataField.Exclude = field.Exclude;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region UpdateStatus(ListViewItem listItem, bool success)
            /// <summary>
            /// This method updates the status message.
            /// </summary>
            /// <param name="listItem"></param>
            /// <param name="success"></param>
            private void UpdateStatus(ListViewItem listItem, bool success)
            {
                // if the listItem exists
                if(listItem != null)
                {   
                    // if successfull
                    if(success)
                    {
                        // use success
                        listItem.ImageIndex = 0;

                        // Update Text
                        listItem.Text += "Done.";
                    }
                    else
                    {
                        // use error
                        listItem.ImageIndex = 1;

                        // Update Text
                        listItem.Text += "Failed.";
                    }

                    // refresh
                    this.Refresh();
                    Application.DoEvents();
                }
            }
            #endregion        
            
            #region UserCancelledSetup(bool userCancelledSetup, bool restartRequired)
            /// <summary>
            /// This method User Cancelled Setup
            /// </summary>
            public void UserCancelledSetup(bool userCancelledSetup, bool restartRequired)
            {
                // if the user cancelled Setup
                if ((userCancelledSetup) && (!SetupComplete))
                {
                    // set message
                    string message = "Setup was cancelled by the user. This program will now close.";

                    // set the title
                    string title = "Setup Cancelled";
                    
                    // Inform user of connection
                    MessageHelper.DisplayMessage(message, title);
                    
                    // Close this form
                    this.Close();
                    
                    // Exit this routine
                    return;
                }
                else if ((restartRequired) && (!SetupComplete))
                {
                        // set message
                    string message = "DataTier.Net was not setup properly. Please restart this program and try again.";

                    // set the title
                    string title = "Setup Was Not Successful";
                    
                    // Inform user of connection
                    MessageHelper.DisplayMessage(message, title);
                    
                    // Close this form
                    this.Close();
                    
                    // Exit this routine
                    return;
                }
            }
        #endregion

        #endregion

        #region Properties

            #region Admin
            /// <summary>
            /// This property gets or sets the value for 'Admin'.
            /// </summary>
            public Admin Admin
            {
                get { return admin; }
                set { admin = value; }
            }
            #endregion
            
            #region AllProjects
            /// <summary>
            /// A collection of all projects.
            /// </summary>
            public List<Project> AllProjects
            {
                get { return allProjects; }
                set { allProjects = value; }
            }
            #endregion

            #region AppController
            /// <summary>
            /// The Application Controller.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            } 
            #endregion
            
            #region BuildComplete
            /// <summary>
            /// This property is set to true after a build.
            /// </summary>
            public bool BuildComplete
            {
                get { return buildComplete; }
                set { buildComplete = value; }
            } 
            #endregion

            #region ButtonManager
            /// <summary>
            /// This property gets or sets the value for 'ButtonManager'.
            /// </summary>
            public ButtonManager ButtonManager
            {
                get { return buttonManager; }
                set { buttonManager = value; }
            }
            #endregion

            #region CreatedFilesCount
            /// <summary>
            /// The number of files from the FileManager
            /// that were created during a build.
            /// </summary>
            public int CreatedFilesCount
            {
                get 
                { 
                    // initial value
                    int createdFilesCount = 0;
                    
                    // if the file manager exists
                    if ((this.FileManager != null) && (this.FileManager.Files != null))
                    {
                        // set the created files count
                        createdFilesCount = this.FileManager.Files.Count;
                    }
                    
                    // return value
                    return createdFilesCount;
                }
            }
            #endregion
            
            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

            #region CurrentDirectory
            /// <summary>
            /// This method is the current directory.
            /// This is set the first time this method is called,
            /// this ensures relative paths will work by setting
            /// the Enviroment.CurrentDirectory after the first set.
            /// </summary>
            public string CurrentDirectory
            {
                get { return currentDirectory; }
                set
                {
                    // Only set if there is not a value
                    if (String.IsNullOrEmpty(currentDirectory))
                    {
                        // Set the current directory
                        currentDirectory = value;
                    }
                }
            }
            #endregion
          
            #region DataManager
            /// <summary>
            /// The DataManager object created from the OpenProject.
            /// </summary>
            public DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            } 
            #endregion
            
            #region DataTables
            /// <summary>
            /// This is the collection of all DataTables from
            /// the DataManager.Databases objects.
            /// </summary>
            public List<DataJuggler.Net.DataTable> DataTables
            {
                get 
                { 
                    // initial value
                    List<DataJuggler.Net.DataTable> dataTables = new List<DataJuggler.Net.DataTable>();
                    
                    // if the DataManager exists
                    if(this.DataManager != null)
                    {
                        // Add each dataTable from each database
                        foreach(Database db in this.DataManager.Databases)
                        {
                            // loop through each table
                            foreach(DataJuggler.Net.DataTable dataTable in db.ActiveTables)
                            {
                                // Add this dataTable
                                dataTables.Add(dataTable);
                            }
                        }
                    }
                    
                    // return value
                    return dataTables; 
                }
            }
            #endregion

            #region FileManager
            /// <summary>
            /// The FileManager is used to keep track 
            /// of files that were created during a build.
            /// </summary>
            public ProjectFileManager FileManager
            {
                get { return fileManager; }
                set { fileManager = value; }
            } 
            #endregion

            #region Gateway
            /// <summary>
            /// This object is the gateway to loading and saving all objects.
            /// </summary>
            internal Gateway Gateway
            {
                get { return gateway; }
                set { gateway = value; }
            }
            #endregion
            
            #region HasAdmin
            /// <summary>
            /// This property returns true if this object has an 'Admin'.
            /// </summary>
            public bool HasAdmin
            {
                get
                {
                    // initial value
                    bool hasAdmin = (this.Admin != null);
                    
                    // return value
                    return hasAdmin;
                }
            }
            #endregion
            
            #region HasDataManager
            /// <summary>
            /// This property returns true if this object has a 'DataManager'.
            /// </summary>
            public bool HasDataManager
            {
                get
                {
                    // initial value
                    bool hasDataManager = (this.DataManager != null);
                    
                    // return value
                    return hasDataManager;
                }
            }
            #endregion
            
            #region HasFileManager
            /// <summary>
            /// This property returns true if this object has a 'FileManager'.
            /// </summary>
            public bool HasFileManager
            {
                get
                {
                    // initial value
                    bool hasFileManager = (this.FileManager != null);
                    
                    // return value
                    return hasFileManager;
                }
            }
            #endregion
            
            #region HasGateway
            /// <summary>
            /// This property returns true if this object has a 'Gateway'.
            /// </summary>
            public bool HasGateway
            {
                get
                {
                    // initial value
                    bool hasGateway = (this.Gateway != null);
                    
                    // return value
                    return hasGateway;
                }
            }
            #endregion
            
            #region HasOpenProject
            /// <summary>
            /// Does this object have an open project.
            /// </summary>
            public bool HasOpenProject
            {
                get
                {
                    // initial value
                    bool hasOpenProject = this.OpenProject != null;

                    // return value
                    return hasOpenProject;
                }
            }
            #endregion

            #region HasStoredProceduresSQLPath
            /// <summary>
            /// This property returns true if the 'StoredProceduresSQLPath' exists.
            /// </summary>
            public bool HasStoredProceduresSQLPath
            {
                get
                {
                    // initial value
                    bool hasStoredProceduresSQLPath = (!String.IsNullOrEmpty(this.StoredProceduresSQLPath));
                    
                    // return value
                    return hasStoredProceduresSQLPath;
                }
            }
            #endregion
            
            #region IsInstalledVersion
            /// <summary>
            /// This read only property returns the value for 'IsInstalledVersion'.
            /// </summary>
            public bool IsInstalledVersion
            {
                get
                {
                    // initial value
                    bool isInstalledVersion = !IsVisualStudio;
                    
                    // return value
                    return isInstalledVersion;
                }
            }
            #endregion
            
            #region IsVisualStudio
            /// <summary>
            /// This read only property returns the value for 'IsVisualStudio'.
            /// </summary>
            public bool IsVisualStudio
            {
                get
                {
                    // initial value
                    bool isVisualStudio = false;
                    
                    // Get the executing assembly's folder
                    string directory = AppDomain.CurrentDomain.BaseDirectory;
                    
                    // this is visual studio
                    isVisualStudio = ((directory.ToLower().Contains("debug")) || (directory.ToLower().Contains("release")));
                    
                    // return value
                    return isVisualStudio;
                }
            }
            #endregion
            
            #region NotSelectedImage
            /// <summary>
            /// Image to display when this control is not selected
            /// (or disabled when ShowNotSelectedImageWhenDisabled = True.
            /// </summary>
            public Image NotSelectedImage
            {
                get { return notSelectedImage; }
                set { notSelectedImage = value; }
            }
            #endregion

            #region OpenProject
            /// <summary>
            /// The open project.
            /// </summary>
            public Project OpenProject
            {
                get { return openProject; }
                set 
                { 
                    // set value
                    openProject = value; 

                    // if the OpenProject exists
                    if (openProject != null)
                    {
                        // Load the child objects
                        Gateway.LoadChildObjects(openProject);
                    
                        // Display Open Project
                        this.DisplaySelectedProject(this.OpenProject);

                        // enable controls
                        UIEnable();

                        // if the references had to be recreated
                        if ((openProject.ReferencesRecreated) && (!OpenProject.IsNew))
                        {
                            // Toggle Off
                            OpenProject.ReferencesRecreated = false;

                            // Show a message to the user
                            MessageHelper.DisplayMessage("Your references had to be recreated. Any customizations made to your references have been lost. You must select Edit Project and Save your project before building.", "References Recreated");
                        }
                    }
                }
            }
            #endregion

            #region SelectedImage
            /// <summary>
            /// The image to display when this control is selected
            /// (Or enable if ShowNotSelectedImageWhenDisabled = True.
            /// </summary>
            public Image SelectedImage
            {
                get { return selectedImage; }
                set { selectedImage = value; }
            }
            #endregion

            #region SetupComplete
            /// <summary>
            /// This property gets or sets the value for 'SetupComplete'.
            /// </summary>
            public bool SetupComplete
            {
                get { return setupComplete; }
                set { setupComplete = value; }
            }
            #endregion
            
            #region StatusLabelControl
            /// <summary>
            /// The StatusLabel on MainForm.
            /// </summary>
            public System.Windows.Forms.ToolStripStatusLabel StatusLabelControl
            {
                get
                {
                    return this.StatusLabel;
                }
            }
            #endregion

            #region StoredProceduresSQLPath
            /// <summary>
            /// This property gets or sets the value for 'StoredProceduresSQLPath'.
            /// </summary>
            public string StoredProceduresSQLPath
            {
                get { return storedProceduresSQLPath; }
                set { storedProceduresSQLPath = value; }
            }
            #endregion

        #endregion
    }
    #endregion
    
}