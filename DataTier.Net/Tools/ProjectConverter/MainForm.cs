

#region using statements

using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.NET9;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System.IO;
using System.Reflection;

#endregion

namespace ProjectConverter
{

    #region class MainForm
    /// <summary>
    /// This class is the Main Form for this project.
    /// </summary>
    public partial class MainForm : Form, ISelectedIndexListener
    {

        #region Private Variables
        private bool confirmationVisible;
        private bool confirmed;
        private Project selectedProject;
        private ScreenTypeEnum screenType;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region CancelConvertButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'CancelConvertButton' is clicked.
        /// </summary>
        private void CancelConvertButton_Click(object sender, EventArgs e)
        {
            // Restore
            ScreenType = ScreenTypeEnum.Default;

            // Set to false            
            ConfirmationVisible = false;

            // Refresh
            UIEnable();
        }
        #endregion

        #region ConfirmButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ConfirmButton' is clicked.
        /// </summary>
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ScreenType == ScreenTypeEnum.ConvertOrFixProjects)
            {
                // Fix projects
                ConvertOrFixProjects();
            }
            else if (ScreenType == ScreenTypeEnum.UpgradeProjects)
            {
                // Update to .NET 9
                UpdateProjects();
            }
            else if (ScreenType == ScreenTypeEnum.MoveProjects)
            {
                // Move this project
                MoveDatabase();
            }
        }
        #endregion

        #region ConvertProjectButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ConvertProjectButton' is clicked.
        /// </summary>
        private void ConvertProjectButton_Click(object sender, EventArgs e)
        {
            // local
            string projectFolder = "";

            // Set the ScreenType
            ScreenType = ScreenTypeEnum.ConvertOrFixProjects;

            // if the Directory exists
            if (Directory.Exists(SourceControl.Text))
            {
                projectFolder = SourceControl.Text;
            }
            else
            {
                // Create a fileInfo
                FileInfo fileInfo = new FileInfo(SourceControl.Text);

                // Set the projectFolder
                projectFolder = fileInfo.Directory.FullName;
            }

            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionConstants.Name);

            // Load the project
            List<Project> projects = gateway.LoadProjects();

            // If the projects collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(projects))
            {
                // Get the tempSelectedProject
                SelectedProject = projects.FirstOrDefault(x => x.ProjectFolder == projectFolder);

                // try again without a backslash
                if (!HasSelectedProject)
                {
                    // Add a backslash
                    projectFolder = TextHelper.CombineStrings(projectFolder, @"\");

                    // Get the tempSelectedProject
                    SelectedProject = projects.FirstOrDefault(x => x.ProjectFolder == projectFolder);
                }

                // Show the Panel if the SelectedProject exists and it hasn't been confirmed yet
                ConfirmationVisible = (HasSelectedProject && !Confirmed);

                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // Set the TextBox
                    ProjectNameTextBox.Text = SelectedProject.ProjectName;
                }

                // Enable or disable controls
                UIEnable();
            }
            else
            {
                // Get the LastException
                gateway.GetLastException();
            }
        }
        #endregion

        #region MoveDatabaseButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'MoveDatabaseButton' is clicked.
        /// </summary>
        private void MoveDatabaseButton_Click(object sender, EventArgs e)
        {
            // Clear list box
            StatusListBox.Items.Clear();

            // if the value for HasSelectedProject is true
            if (HasSelectedProject)
            {
                // Show an error
                StatusListBox.Items.Add("Selected Project " + SelectedProject.ProjectName + " is ready to be moved.", 1);

                // Set ScreenType
                ScreenType = ScreenTypeEnum.MoveProjects;

                // Set to true
                ConfirmationVisible = true;

                // Set the text
                ConfirmationLabel.Text = "Confirm Move Project " + SelectedProject.ProjectName + "?";

                // Enable or disable controls
                UIEnable();
            }
            else
            {
                // Show an error
                StatusListBox.Items.Add("Selected Project Does Not Exist In MoveDatabase_Click", 1);
            }
        }
        #endregion

        #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
        /// <summary>
        /// event is fired when a selection is made in the 'On'.
        /// </summary>
        public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
        {
            // Get the selected project name
            string projectName = DatabaseComboBox.ComboBoxText;

            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionNameControl.Text);

            // Set the Selected Project
            SelectedProject = gateway.FindProjectByProjectName(projectName);
        }
        #endregion
        
        #region RefreshButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'RefreshButton' is clicked.
        /// </summary>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Set the text
            DatabaseComboBox.ComboBoxText = "...";

            // Refresh the UI
            Refresh();
            Application.DoEvents();

            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionNameControl.Text);

            // Load the projects
            List<Project> projects = gateway.LoadProjects();

            // If the projects collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(projects))
            {
                // Load the Items
                DatabaseComboBox.LoadItems(projects);
            }

             // Set the text
            DatabaseComboBox.ComboBoxText = "";

            // Refresh the UI
            Refresh();
            Application.DoEvents();
        }
        #endregion

        #region RefreshButton_MouseEnter(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Refresh Button _ Mouse Enter
        /// </summary>
        private void RefreshButton_MouseEnter(object sender, EventArgs e)
        {
            // Change the cursor to a hand
            Cursor = Cursors.Hand;
        }
        #endregion
        
        #region RefreshButton_MouseLeave(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Refresh Button _ Mouse Leave
        /// </summary>
        private void RefreshButton_MouseLeave(object sender, EventArgs e)
        {
            // Change the cursor back to the default pointer
            Cursor = Cursors.Default;
        }
        #endregion
        
        #region UpgradeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'UpgradeButton' is clicked.
        /// </summary>
        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            // Set the ScreenType
            ScreenType = ScreenTypeEnum.UpgradeProjects;

            // Show a message
            ConfirmationLabel.Text = "Confirm Upgrade to .NET 9";

            // Set the value for the property 'ConfirmationVisible' to true
            ConfirmationVisible = true;

            // Enable or disable controls
            UIEnable();
        }
        #endregion

        #endregion

        #region Methods

        #region ConvertOrFixProjects()
        /// <summary>
        /// Convert Or Fix Projects
        /// </summary>
        public void ConvertOrFixProjects()
        {
            try
            {
                // get the currentDirectory
                string currentDirectory = Environment.CurrentDirectory;

                // Create a list of replacements
                List<Replacement> replacements = new List<Replacement>();

                // Add two new Replacements
                replacements.Add(new Replacement("ApplicationLogicComponent", "DataAccessComponent"));
                replacements.Add(new Replacement("class Connection", "class ConnectionConstants"));
                replacements.Add(new Replacement("DataAccessComponent.DataManager", "DataAccessComponent.Data"));
                replacements.Add(new Replacement("this.", ""));
                replacements.Add(new Replacement("AppController.ControllerManager.", ""));

                // if the value for HasSelectedProject is true
                if (HasSelectedProject)
                {
                    // Set to true
                    Confirmed = true;

                    // Hide the ConfirmPanel
                    ConfirmationVisible = false;

                    // Enable or disable controls
                    UIEnable();

                    // if checked
                    if ((BackupCheckBox.Checked) && (BackupPathControl.HasText))
                    {
                        // Backup The Project
                        CopyDirectory(SelectedProject.ProjectFolder, BackupPathControl.Text);

                        // Set the Backup Path
                        StatusListBox.Items.Add("Backup Complete.", 0);

                        // Copy the Controllers
                        string connectionFolder = Path.Combine(SelectedProject.ProjectFolder, @"ApplicationLogicComponent\Connection");
                        string connectionDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\Connection");

                        // Move the folder
                        CopyDirectory(connectionFolder, connectionDestination);

                        // Disiplay Result
                        StatusListBox.Items.Add("Connection Folder Copy Complete.", 0);

                        // Copy the Exceptions
                        string exceptionsFolder = Path.Combine(SelectedProject.ProjectFolder, @"ApplicationLogicComponent\Exceptions");
                        string exceptionsDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\Exceptions");

                        // Move the folder
                        CopyDirectory(exceptionsFolder, exceptionsDestination);

                        // Get the .cs files in this folder
                        List<string> files = FileHelper.GetFiles(exceptionsDestination, ".cs");

                        // If the files collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(files))
                        {
                            // Iterate the collection of string objects
                            foreach (string file in files)
                            {
                                // Replace ApplicationLogicComponent with DataAccessComponent
                                TextHelper.ReplaceTextInFile(file, "ApplicationLogicComponent", "DataAccessComponent");
                            }
                        }

                        // Disiplay Result
                        StatusListBox.Items.Add("Exceptions Folder Copy Complete.", 0);

                        // get a path to the ConnectionFile
                        string connectionFile = Path.Combine(connectionDestination, "Connection.cs");
                        string authenticationManagerFile = Path.Combine(connectionDestination, "AuthenticationManager.cs");
                        string thisConnectionFile = Path.Combine(currentDirectory, @"Connection\ConnectionConstants.cs");
                        string thisAuthenticationManager = Path.Combine(currentDirectory, @"Connection\AuthenticationManager.cs");
                        string destinationFileName = connectionFile.Replace("Connection.cs", "ConnectionConstants.cs");

                        // if the file exists
                        if (FileHelper.Exists(connectionFile))
                        {
                            // Find the ConnectionName
                            string connectionName = FindConnectionName(connectionFile);

                            // Delete the old one
                            RemoveFile(connectionFile);

                            // Delete
                            RemoveFile(destinationFileName);

                            // Copy the ConnectionConstants
                            File.Copy(thisConnectionFile, destinationFileName);

                            // If the connectionName string exists
                            if (TextHelper.Exists(connectionName))
                            {
                                // Update the ConnectionName
                                TextHelper.ReplaceTextInFile(destinationFileName, ConnectionConstants.Name, connectionName);
                            }

                            // Disiplay Result
                            StatusListBox.Items.Add("Connection.cs renamed to ConnectionConstants.cs Complete.", 0);
                        }

                        // Delete
                        RemoveFile(authenticationManagerFile);

                        // Copy this AuthenticationManager file
                        File.Copy(thisAuthenticationManager, authenticationManagerFile);

                        // Get the DirectoryName
                        string directoryName = Path.GetDirectoryName(destinationFileName);

                        // Rename the files
                        ReplaceTextInDirectory(directoryName, ".cs", replacements);

                        // Disiplay Result
                        StatusListBox.Items.Add("AuthenticationManager update Complete.", 0);

                        // Set the Controllers
                        string controllerFolder = Path.Combine(SelectedProject.ProjectFolder, @"ApplicationLogicComponent\Controllers");
                        string controllerDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\Controllers");
                        string thisApplicationController = Path.Combine(currentDirectory, @"Controllers\ApplicationController.cs");
                        string existingApplicationController = Path.Combine(controllerDestination, "ApplicationController.cs");
                        string thisSystemController = Path.Combine(currentDirectory, @"Controllers\SystemController.cs");
                        string existingSystemController = Path.Combine(controllerDestination, "SystemController.cs");

                        // Move the Controlelrs folder
                        CopyDirectory(controllerFolder, controllerDestination);

                        // Delete this file
                        RemoveFile(existingApplicationController);

                        // Copy this file
                        File.Copy(thisApplicationController, existingApplicationController);

                        // Delete this file
                        RemoveFile(existingSystemController);

                        // Copy this file
                        File.Copy(thisSystemController, existingSystemController);

                        // Replace all the text in the directory
                        ReplaceTextInDirectory(controllerDestination, ".cs", replacements);

                        // Disiplay Result
                        StatusListBox.Items.Add("Controllers Folder Copy Complete.", 0);

                        // Get the existin Gateway folder
                        string existingGatewayFolder = Path.Combine(SelectedProject.ProjectFolder, @"DataGateway");
                        string gatewayDestination = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\DataGateway");

                        // Copy the Gateway
                        CopyDirectory(existingGatewayFolder, gatewayDestination);

                        // Replace out invalid using statements
                        ReplaceTextInDirectory(gatewayDestination, ".cs", replacements);

                        // Disiplay Result
                        StatusListBox.Items.Add("Gateway Folder Copy Complete.", 0);

                        // Copy the DataOperations                    
                        string dataOperationsFolder = Path.Combine(SelectedProject.ProjectFolder, @"ApplicationLogicComponent\DataOperations");
                        string dataOperationsDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\DataOperations");
                        string dataOperationsManager = Path.Combine(dataOperationsDestination, "DataOperationsManager.cs");
                        string thisSystemMethods = Path.Combine(currentDirectory, @"DataOperations\SystemMethods.cs");
                        string existingSystemMethods = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\DataOperations\SystemMethods.cs");

                        // Delete this file
                        RemoveFile(dataOperationsManager);

                        // Move the Data Operations Folder
                        CopyDirectory(dataOperationsFolder, dataOperationsDestination);

                        // Delete
                        RemoveFile(existingSystemMethods);

                        // Now copy this file
                        File.Copy(thisSystemMethods, existingSystemMethods);

                        // Replace the files in DataOperations
                        ReplaceTextInDirectory(dataOperationsDestination, ".cs", replacements);

                        // Disiplay Result
                        StatusListBox.Items.Add("Data Operations Folder Copy Complete.", 0);

                        // Handle Data
                        string dataManagerFolder = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\DataManager");
                        string dataManagerDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\Data");
                        string thisDataHelper = Path.Combine(currentDirectory, @"Data\DataHelper.cs");
                        string existingDataHelper = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\Data\DataHelper.cs");
                        string thisDataManager = Path.Combine(currentDirectory, @"Data\DataManager.cs");
                        string existingDataManager = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\Data\DataManager.cs");

                        if (Directory.Exists(dataManagerFolder))
                        {
                            // Perform the Move
                            Directory.Move(dataManagerFolder, dataManagerDestination);
                        }

                        // local
                        string dataJugglerNetVersion = "";

                        // If the one exists on their project (should)
                        if (File.Exists(existingDataHelper))
                        {
                            // get using DataJuggler.NET8.Sql; (example)
                            dataJugglerNetVersion = FindExistingDataJugglerNetVersion(existingDataHelper);

                            // Delete                        
                            RemoveFile(existingDataHelper);
                        }

                        // Copy this file
                        File.Copy(thisDataHelper, existingDataHelper);

                        // If the dataJugglerNetVersion string exists
                        if (TextHelper.Exists(dataJugglerNetVersion))
                        {
                            string currentDataJugglerNetVersion = "using DataJuggler.NET9.Sql;";

                            // if not equal
                            if (!TextHelper.IsEqual(dataJugglerNetVersion, currentDataJugglerNetVersion))
                            {
                                // Replace Text in a File
                                TextHelper.ReplaceTextInFile(existingDataHelper, currentDataJugglerNetVersion, dataJugglerNetVersion);
                            }
                        }

                        // Delete                        
                        RemoveFile(existingDataManager);

                        // Copy this file
                        File.Copy(thisDataManager, existingDataManager);

                        // ControllerManager must be removed
                        string controllerManager = Path.Combine(controllerDestination, "ControllerManager.cs");

                        // If the controllerManager Exists On Disk
                        if (FileHelper.Exists(controllerManager))
                        {
                            // Delete thie file
                            RemoveFile(controllerManager);
                        }

                        // Replace out the text in DataManager
                        ReplaceTextInDirectory(dataManagerDestination, ".cs", replacements);

                        // Now the project file must be edited
                        string dacProjectFile = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\DataAccessComponent.csproj");

                        // Create a seccond list of replacements
                        List<Replacement> replacements2 = new List<Replacement>();

                        // <Folder Include="DataManager\Readers\" />
                        // <Folder Include="DataManager\Writers\" />

                        // Add each of these
                        replacements2.Add(new Replacement("<Folder Include=\"DataManager\\Readers\\\" />", "<Folder Include=\"Data\\Readers\\\" />"));
                        replacements2.Add(new Replacement("<Folder Include=\"DataManager\\Writers\\\" />", "<Folder Include=\"Data\\Writers\\\" />"));

                        // Replace the text in the file
                        TextHelper.ReplaceTextInFile(dacProjectFile, replacements2);

                        // Show a message
                        StatusListBox.Items.Add("DataManager renamed to Data Complete", 0);

                        // Copy the Controllers
                        string dataBridgeFolder = Path.Combine(SelectedProject.ProjectFolder, @"ApplicationLogicComponent\DataBridge");
                        string dataBridgeDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\DataBridge");
                        string thisDataBridge = Path.Combine(currentDirectory, @"DataBridge\DataBridgeManager.cs");
                        string existingDataBridge = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\DataBridge\DataBridgeManager.cs");

                        // Move the Data Operations Folder
                        CopyDirectory(dataBridgeFolder, dataBridgeDestination);

                        // If the file exists
                        if (File.Exists(existingDataBridge))
                        {
                            // Delete
                            RemoveFile(existingDataBridge);
                        }

                        // Now copy this DataBridge
                        File.Move(thisDataBridge, existingDataBridge);

                        // Replace out ApplicationLogicComponent for for DataAccessComponent
                        ReplaceTextInDirectory(dataBridgeDestination, ".cs", replacements);

                        // Disiplay Result
                        StatusListBox.Items.Add("Data Bridge Folder Copy Complete.", 0);

                        // Logging Folder comes from this project
                        // Copy the Controllers

                        // set the logging folder and destination
                        string loggingFolder = Path.Combine(currentDirectory, @"Logging");
                        string loggingFolderDestination = Path.Combine(selectedProject.ProjectFolder, @"DataAccessComponent\Logging");

                        // Move the Data Operations Folder
                        CopyDirectory(loggingFolder, loggingFolderDestination);

                        // Set the Backup Path
                        StatusListBox.Items.Add("Logging Folder Copy Complete", 0);

                        // Update to version2
                        SelectedProject.TemplateVersion = 2;

                        // Update the Namespaces
                        SelectedProject.ControllerNamespace = "DataAccessComponent.Controllers";
                        SelectedProject.DataManagerNamespace = "DataAccessComponent.Data";
                        SelectedProject.DataOperationsNamespace = "DataAccessComponent.DataOperations";
                        SelectedProject.DataWriterNamespace = "DataAccessComponent.Data.Writers";
                        SelectedProject.ReaderNamespace = "DataAccessComponent.Data.Readers";

                        // Update the Folders
                        SelectedProject.ControllerFolder = controllerDestination;
                        SelectedProject.DataManagerFolder = dataManagerDestination;
                        SelectedProject.DataOperationsFolder = dataOperationsDestination;
                        SelectedProject.DataWriterFolder = Path.Combine(dataManagerDestination, @"Writers");
                        SelectedProject.ReaderFolder = Path.Combine(dataManagerDestination, @"Readers");
                        SelectedProject.StoredProcedureObjectFolder = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\StoredProcedureManager");
                        SelectedProject.StoredProcsFolder = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\StoredProcedureSQL");

                        // update
                        Gateway gateway = new Gateway(ConnectionConstants.Name);

                        // Save this project
                        bool saved = gateway.SaveProject(ref selectedProject);

                        // if the value for saved is true
                        if (saved)
                        {
                            // Show success
                            StatusListBox.Items.Add("Project paths have been updated.", 0);
                        }
                        else
                        {
                            // Show success
                            StatusListBox.Items.Add("Project path update failed", 1);
                        }

                        // Now the Controllers, DataManager & DataOperations need to be removed

                        // Load the Tables
                        List<DTNTable> tables = gateway.LoadDTNTablesForProjectId(SelectedProject.ProjectId);

                        // Set the gatewayPath
                        string gatewayPath = Path.Combine(gatewayDestination, "Gateway.cs");
                        string thisGatewayPath = Path.Combine(currentDirectory, @"DataGateway\Gateway.cs");

                        // Create a new collection of 'Replacement' objects.
                        List<Replacement> replacements3 = new List<Replacement>();

                        // If the tables collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(tables))
                        {
                            // Iterate the collection of DTNTable objects
                            foreach (DTNTable table in tables)
                            {
                                // Get the path to the Controller for this table
                                string path = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\Controllers\" + table.TableName + "Controller.cs");

                                // Delete this file
                                RemoveFile(path);

                                // Get the path to the Controller for this table
                                path = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\Data\" + table.TableName + "Manager.cs");

                                // Delete this file
                                RemoveFile(path);

                                // Get the path to the DataOperation Method for this table
                                path = Path.Combine(SelectedProject.ProjectFolder, @"DataAccessComponent\DataOperations\" + table.TableName + "Methods.cs");

                                // Delete this file
                                RemoveFile(path);

                                // Create the replacements for all 5 methods for this table
                                string variableName = TextHelper.CapitalizeFirstChar(table.TableName, true);
                                string collectionVariableName = PluralWordHelper.GetPluralName(variableName, true);
                                string tableName = table.TableName;
                                string controllerName = tableName + "Controller";

                                // Delete
                                string deleteOld = "deleted = " + controllerName + ".Delete(temp" + tableName + ");";
                                string deleteNew = "deleted = " + controllerName + ".Delete(temp" + tableName + ", DataManager);";
                                replacements3.Add(new Replacement(deleteOld, deleteNew));

                                // find
                                string findNew = variableName + " = " + controllerName + ".Find(temp" + tableName + ");";
                                string findOld = variableName + " = " + controllerName + ".Find(temp" + tableName + ", DataManager);";
                                replacements3.Add(new Replacement(findNew, findOld));

                                // load
                                string loadOld = collectionVariableName + " = " + controllerName + ".FetchAll(temp" + tableName + ");";
                                string loadNew = collectionVariableName + " = " + controllerName + ".FetchAll(temp" + tableName + ", DataManager);";
                                replacements3.Add(new Replacement(loadOld, loadNew));

                                // Save
                                string saveOld = "saved = " + controllerName + ".Save(ref " + variableName + ");";
                                string saveNew = "saved = " + controllerName + ".Save(ref " + variableName + ", DataManager);";
                                replacements3.Add(new Replacement(saveOld, saveNew));
                            }
                        }

                        // If the replacements3 collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(replacements3))
                        {
                            // If the gatewayPath Exists On Disk
                            if (FileHelper.Exists(gatewayPath))
                            {
                                // Replace out the text in files
                                TextHelper.ReplaceTextInFile(gatewayPath, replacements3);

                                // Show a message
                                StatusListBox.Items.Add("Gateway has been updated.", 0);
                            }
                        }

                        // If the gatewayPath and thisGatewayPath Exist On Disk
                        if ((FileHelper.Exists(gatewayPath)) && (FileHelper.Exists(thisGatewayPath)))
                        {
                            // Get the text lines from file
                            List<TextLine> lines = TextHelper.GetTextLinesFromFile(gatewayPath);

                            // Get the lines from thisGatewayPath
                            List<TextLine> lines2 = TextHelper.GetTextLinesFromFile(thisGatewayPath);

                            // if both lists have one or more items
                            if (ListHelper.HasOneOrMoreItems(lines, lines2))
                            {
                                // Find the InsertIndex for the DataManager property
                                TextLine insertLine = lines.FirstOrDefault(x => x.Text.Contains("#region HasAppController"));

                                // If the insertLine object exists
                                if (NullHelper.Exists(insertLine))
                                {
                                    // Now we need to copy a list of lines from thisGatewayPath
                                    TextLine copyLine = lines2.FirstOrDefault(x => x.Text.Contains("#region DataManager"));

                                    // Now we need to copy a list of lines from thisGatewayPath
                                    TextLine existingLine = lines.FirstOrDefault(x => x.Text.Contains("#region DataManager"));

                                    // If the copyLine object exists and the existingLine does not
                                    if ((NullHelper.Exists(copyLine)) && (NullHelper.IsNull(existingLine)))
                                    {
                                        // Get the insert index
                                        int insertIndex = insertLine.LineNumber - 1;

                                        // Find copy_line start at index in lines2
                                        int startIndex = copyLine.LineNumber - 1;

                                        // Ensure startIndex is valid and greater than 0
                                        if (startIndex > 0)
                                        {
                                            // Find end of copy_line which is an #endregion
                                            int endIndex = lines2.FindIndex(startIndex, x => x.Text.Contains("#endregion"));

                                            // Ensure endIndex is greater than startIndex
                                            if (endIndex > startIndex)
                                            {
                                                // Select the range of lines to insert
                                                List<TextLine> linesToInsert = lines2.GetRange(startIndex, (endIndex - startIndex) + 2);

                                                // Now insert the lines into the insertIndex position of lines
                                                lines.InsertRange(insertIndex, linesToInsert);

                                                // Export the text
                                                string fileContent = TextHelper.ExportTextLines(lines);

                                                // Write All Text
                                                File.WriteAllText(gatewayPath, fileContent);

                                                // Show a message
                                                StatusListBox.Items.Add("The Property DataManager was added to the Gateway", 0);
                                            }
                                        }
                                    }
                                    else if (NullHelper.Exists(existingLine))
                                    {
                                        // Show a message
                                        StatusListBox.Items.Add("The Property DataManager already exists in the Gateway", 0);
                                    }
                                }
                            }
                        }

                        // load the references
                        List<ProjectReferencesView> references = gateway.LoadProjectReferencesViewsForProjectId(SelectedProject.ProjectId);

                        // Iterate the collection of ProjectReferencesView objects
                        foreach (ProjectReferencesView reference in references)
                        {
                            // if the reference contains ApplicationLogicComponent
                            if ((reference.ReferenceName.Contains("ApplicationLogicComponent")) || (reference.ReferenceName.Contains("DataAccessComponent.DataManager")))
                            {
                                // Find the Reference
                                ProjectReference projectReference = gateway.FindProjectReference(reference.ReferencesId);
                                   
                                // if this reference contains
                                if (projectReference.ReferenceName.Contains("ApplicationLogicComponent"))
                                {
                                    // change the name
                                    projectReference.ReferenceName = projectReference.ReferenceName.Replace("ApplicationLogicComponent", "DataAccessComponent");

                                    // Clone this
                                    ProjectReference tempReference = projectReference.Clone();

                                    // Perform Save
                                    saved = gateway.SaveProjectReference(ref tempReference);
                                }
                                // if this reference contains
                                else if (projectReference.ReferenceName.Contains("DataAccessComponent.DataManager"))
                                {
                                    // change the name
                                    projectReference.ReferenceName = projectReference.ReferenceName.Replace("DataAccessComponent.DataManager", "DataAccessComponent.Data");

                                    // Clone this
                                    ProjectReference tempReference = projectReference.Clone();

                                    // Perform Save
                                    saved = gateway.SaveProjectReference(ref tempReference);
                                }                                
                            }
                        }

                        // Load the References
                        List<ProjectReference> controllerReferences = gateway.LoadProjectReferencesForReferencesSetId(SelectedProject.ControllerReferencesSetId);

                        // If the controllerReferences collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(controllerReferences))
                        {
                            // locals
                            string referenceName = "DataAccessComponent.Data";
                            ProjectReference dataReference = controllerReferences.FirstOrDefault(x => x.ReferenceName == referenceName);

                            // If the dataReference object does not exist
                            if (NullHelper.IsNull(dataReference))
                            {
                                // Create a new instance of a 'dataReference' object.
                                dataReference = new ProjectReference();

                                dataReference.ReferenceName = referenceName;
                                dataReference.ReferencesSetId = selectedProject.ControllerReferencesSetId;

                                // Perform Save
                                saved = gateway.SaveProjectReference(ref dataReference);

                                // if the value for saved is true
                                if (saved)
                                {
                                    // Show success
                                    StatusListBox.Items.Add("Controller References Updated", 0);
                                }
                                else
                                {
                                    // Show success
                                    StatusListBox.Items.Add("Controller References update failed", 1);
                                }
                            }
                        }

                        // Set the Backup Path
                        StatusListBox.Items.Add("Project References Have Been Updated", 0);

                        // Show a message
                        StatusListBox.Items.Add("Convert / Fix Project Complete. You must build with DataTier.NET", 0);
                    }
                    else
                    {
                        // Set the Backup Path
                        StatusListBox.Items.Add("Backup Path Must Be Set.", 1);
                    }
                }
            }
            catch (Exception error)
            {
                // Show a message
                StatusListBox.Items.Add("An error occurred converting your project.", 1);

                // Get the message
                string message = error.ToString();

                // get the text lines
                List<TextLine> errorLines = TextHelper.GetTextLines(message);

                // If the errorLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(errorLines))
                {
                    // Iterate the collection of TextLine objects
                    foreach (TextLine line in errorLines)
                    {
                        // Show this error
                        StatusListBox.Items.Add(line.Text);
                    }
                }
            }
        }
        #endregion

        #region CopyDirectory(string sourceDir, string destinationDir)
        /// <summary>
        /// method returns the Directory
        /// </summary>
        public static void CopyDirectory(string sourceDir, string destinationDir)
        {
            // if does not already exist
            if (!Directory.Exists(destinationDir))
            {
                // Create the Destination Directory
                Directory.CreateDirectory(destinationDir);
            }

            // if the directory exists
            if (Directory.Exists(sourceDir))
            {
                foreach (var file in Directory.GetFiles(sourceDir))
                {
                    string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                    File.Copy(file, destFile, true);
                }

                // iterate the sub directories
                foreach (var dir in Directory.GetDirectories(sourceDir))
                {
                    string destDir = Path.Combine(destinationDir, Path.GetFileName(dir));
                    CopyDirectory(dir, destDir);
                }
            }
        }
        #endregion

        #region FindConnectionName(string path)
        /// <summary>
        /// Find Connection Name
        /// </summary>
        public string FindConnectionName(string path)
        {
            // initial value
            string connectionName = "";

            // Get the textLines
            List<TextLine> textLines = TextHelper.GetTextLinesFromFile(path);

            // If the textLines collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(textLines))
            {
                // Iterate the collection of TextLine objects
                foreach (TextLine line in textLines)
                {
                    // if the line contains public const string Name = 
                    if (line.Text.Contains("public const string Name = "))
                    {
                        // Find the text in quotes - Example public const string Name = "RunnerConnString";                        
                        connectionName = TextHelper.FindTextInQuotes(line.Text);

                        // exit loop
                        break;
                    }
                }
            }

            // return value
            return connectionName;
        }
        #endregion

        #region FindExistingDataJugglerNetVersion(string path)
        /// <summary>
        /// returns the Existing Data Juggler Net Version
        /// </summary>
        public string FindExistingDataJugglerNetVersion(string path)
        {
            // initial value
            string version = "";

            // If the path Exists On Disk
            if (FileHelper.Exists(path))
            {
                // Get the textLines
                List<TextLine> textLines = TextHelper.GetTextLinesFromFile(path);

                // If the textLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(textLines))
                {
                    // Iterate the collection of TextLine objects
                    foreach (TextLine line in textLines)
                    {
                        // if this is the .NET 8 version
                        if (line.Text.Contains("using DataJuggler.NET8.Sql;"))
                        {
                            // set the return value
                            version = "using DataJuggler.NET8.Sql;";

                            // exit loop
                            break;
                        }
                    }
                }
            }

            // return value
            return version;
        }
        #endregion

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // Wire up the listener
            DatabaseComboBox.SelectedIndexListener = this;

            // Set the ConnectionName
            ConnectionNameControl.Text = "DataTierNetConnection";

            // Default
            BackupPathControl.Text = @"D:\Backup\TestOp";

            // Select File
            SourceControl.Text = @"C:\Projects\RCPMainBranch\RCP.HydrostaticTests\RCP.HydrostaticTests.Data\RCP.DataLib";
        }
        #endregion
        
        #region MoveDatabase()
        /// <summary>
        /// Move Database
        /// </summary>
        public void MoveDatabase()
        {
            
        }
        #endregion
        
        #region RemoveFile(string path)
        /// <summary>
        /// Remove File
        /// </summary>
        public void RemoveFile(string path)
        {
            try
            {
                // If the path Exists On Disk
                if (FileHelper.Exists(path))
                {
                    // Delete this file
                    File.Delete(path);

                    // Show an error
                    StatusListBox.Items.Add("Removed file '" + path, 0);
                }
            }
            catch (Exception error)
            {
                // For debugging only
                DebugHelper.WriteDebugError("RemoveFile", "MainForm.cs", error);

                // Show an error
                StatusListBox.Items.Add("Could not remove file '" + path, 1);
            }
        }
        #endregion

        #region ReplaceTextInDirectory(string directory, string extension, List<Replacement> replacements))
        /// <summary>
        /// Replace Text In Directory
        /// </summary>
        public void ReplaceTextInDirectory(string directory, string extension, List<Replacement> replacements)
        {
            // locals
            List<string> extensions = new List<string>();
            extensions.Add(extension);

            // Get a list of flies recursively
            List<string> files = new List<string>();

            // Get the files
            FileHelper.GetFilesRecursively(directory, ref files, extensions);

            // If the files collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(files))
            {
                // Iterate the collection of string objects
                foreach (string file in files)
                {
                    // Replace the text
                    TextHelper.ReplaceTextInFile(file, replacements);
                }
            }
        }
        #endregion

        #region UIEnable()
        /// <summary>
        /// This method enables or disabvles or hides or shows controls
        /// </summary>
        public void UIEnable()
        {
            // Update
            ConfirmationPanel.Visible = ConfirmationVisible;

            // Refresh The UI
            Refresh();
            Application.DoEvents();
        }
        #endregion

        #region UpdateProjects()
        /// <summary>
        /// Update Projects
        /// </summary>
        public void UpdateProjects()
        {
            // Clear
            StatusListBox.Items.Clear();

            // locals            
            string searchText = "net8.0-windows";
            string searchText2 = "net8.0";
            string replaceText = "net9.0-windows";
            bool saved = false;
            string oldReferenceName = "";
            string newReferenceName = "";

            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(ConnectionNameControl.Text);

            // Load the Projects
            List<Project> projects = gateway.LoadProjects();

            // create a fileInfo
            FileInfo fileInfo = new FileInfo(SourceControl.Text);

             // If the projects collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(projects))
            {
                // Get the tempSelectedProject
                SelectedProject = projects.FirstOrDefault(x => x.ProjectFolder == fileInfo.Directory.FullName);
            }

            // if the value for HasSelectedProject is true
            if (HasSelectedProject)
            {
                // Create a new collection of 'Replacement' objects.
                List<Replacement> replacements = new List<Replacement>();

                // Add both
                replacements.Add(new Replacement(searchText, replaceText));
                replacements.Add(new Replacement(searchText2, replaceText));

                // if the text exists
                if (FileHelper.Exists(SourceControl.Text))
                {
                    // Set the DAC
                    string dac = Path.Combine(fileInfo.DirectoryName, @"DataAccessComponent\DataAccessComponent.csproj");

                    // Set the Object Library
                    string objectLibraryPath = Path.Combine(fileInfo.DirectoryName, @"ObjectLibrary\ObjectLibrary.csproj");

                    // If the dac Exists On Disk
                    if (FileHelper.Exists(dac))
                    {
                        // Replace out the TargetFramework
                        TextHelper.ReplaceTextInFile(dac, replacements);

                        // Show a message
                        StatusListBox.Items.Add("DAC Project File Updated", 0);
                    }

                    // If the objectLibraryPath Exists On Disk
                    if (FileHelper.Exists(objectLibraryPath))
                    {
                        // Show a message
                        TextHelper.ReplaceTextInFile(objectLibraryPath, replacements);

                        // Show a message
                        StatusListBox.Items.Add("Object Library Project File Updated", 0);
                    }                

                    // Load the references
                    List<ProjectReferencesView> references = gateway.LoadProjectReferencesViewsForProjectId(SelectedProject.ProjectId);

                    // If the references collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(references))
                    {
                        // Iterate the collection of ProjectReferencesView objects
                        foreach (ProjectReferencesView view in references)
                        {
                            // get the old reference name
                            oldReferenceName = view.ReferenceName;

                            // if .NET 8
                            if (view.ReferenceName.Contains("DataJuggler.Net8"))
                            {
                                // we need to find this ProjectReference
                                ProjectReference projectReference = gateway.FindProjectReference(view.ReferencesId);

                                // If the projectReference object exists
                                if (NullHelper.Exists(projectReference))
                                {
                                    // Update
                                    projectReference.ReferenceName = view.ReferenceName.Replace("DataJuggler.Net8", "DataJuggler.NET9");

                                    // Save0
                                    saved = gateway.SaveProjectReference(ref projectReference);

                                    // if the value for saved is true
                                    if (saved)
                                    {
                                        // set new name
                                        newReferenceName = view.ReferenceName;

                                        // Show a message
                                        StatusListBox.Items.Add("Renamed Reference " + oldReferenceName + " to " + newReferenceName + ".", 0);
                                    }
                                    else
                                    {
                                        // Show a message
                                        StatusListBox.Items.Add("Renamed Reference failed for " + oldReferenceName + " to " + newReferenceName + ".", 1);
                                    }
                                }
                            }
                        }
                    }

                    // Show a message
                    StatusListBox.Items.Add("Update Project Complete. You must build with DataTier.NET", 0);
                }
                else
                {
                    // Show an error
                    StatusListBox.Items.Add("Solution Does Not Exist", 1);
                }
            }
            else
            {
                // Show an error
                StatusListBox.Items.Add("A project could not be found matching this folder.", 1);
                StatusListBox.Items.Add("Verify this folder is correct in DataTier.NET", 1);
            }
        }
        #endregion

        #endregion

        #region Properties

        #region ConfirmationVisible
        /// <summary>
        /// This property gets or sets the value for 'ConfirmationVisible'.
        /// </summary>
        public bool ConfirmationVisible
        {
            get { return confirmationVisible; }
            set { confirmationVisible = value; }
        }
        #endregion

        #region Confirmed
        /// <summary>
        /// This property gets or sets the value for 'Confirmed'.
        /// </summary>
        public bool Confirmed
        {
            get { return confirmed; }
            set { confirmed = value; }
        }
        #endregion

        #region HasSelectedProject
        /// <summary>
        /// This property returns true if this object has a 'SelectedProject'.
        /// </summary>
        public bool HasSelectedProject
        {
            get
            {
                // initial value
                bool hasSelectedProject = (SelectedProject != null);

                // return value
                return hasSelectedProject;
            }
        }
        #endregion

        #region ScreenType
        /// <summary>
        /// This property gets or sets the value for 'ScreenType'.
        /// </summary>
        public ScreenTypeEnum ScreenType
        {
            get { return screenType; }
            set { screenType = value; }
        }
        #endregion

        #region SelectedProject
        /// <summary>
        /// This property gets or sets the value for 'SelectedProject'.
        /// </summary>
        public Project SelectedProject
        {
            get { return selectedProject; }
            set { selectedProject = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
