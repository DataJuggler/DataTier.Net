

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.IO;
using System;
using DataJuggler.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DataTierClient.Xml.Writers;

#endregion

namespace DataTierClient.Controls
{

    #region class BlazorDataServicesControl
    /// <summary>
    /// This control is used to install the Blazor Item Templates and to create 
    /// DataWatchers and Services for a DTNTable.
    /// Also, the Services Folder is set on this control so the next time you 
    /// run this the ServicesFolder will be already set.
    /// </summary>
    public partial class BlazorDataServicesControl : UserControl, ITextChanged, ISaveCancelHost
    {
        
        #region Private Variables
        private const string ItemTemplateInstall = "dotnet new --install DataJuggler.DataTier.Net5.ItemTemplates.BlazorDataServices::2.5.4";
        private const string ItemTemplateUninstall = "dotnet new -uninstall DataJuggler.DataTier.Net5.ItemTemplates.BlazorDataServices";
        private const string CreateServices = "dotnet new DataTier.Net5.ItemTemplates.BlazorDataServices";
        private const string DataWatcherFileName = "DataWatcher.cs";
        private const string ServiceFileName = "Service.cs";
        private string initialProject;
        private Project project;
        private DTNTable table;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'BlazorDataServicesControl' object.
        /// </summary>
        public BlazorDataServicesControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
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
            
            #region CreateBlazorServicesButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            /// <summary>
            /// event is fired when Create Blazor Services Button _ Link Clicked
            /// </summary>
            private void CreateBlazorServicesButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                // locals
                int attempts = 0;
                string path = "";
                string path2 = "";
                bool filesCreated = false;
                string message = "";

                try
                {
                    // if the value for HasServicesFolder is true
                    if ((HasServicesFolder) && (HasTable))
                    {
                        // Setup the Graph
                        Graph.Maximum = 20;
                        Graph.Minimum = 0;
                        Graph.Value = 0;

                        // Show the graph
                        Graph.Visible = true;

                        // Create a Process to launch a command window (hidden) to create the item templates
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.WorkingDirectory = Project.ServicesFolder;
                        startInfo.Arguments = "/C " + CreateServices;
                        process.StartInfo = startInfo;
                        process.Start();

                        // next I am performing a wait for the files to be here, which on different people's machines
                        // speeds I am allowing up to 5 seconds. My machine takes about half a second maybe more, 
                        // so 5 should be enough or give up. If it doesn't work for and you haven't upgraded your
                        // computer in a while, maybe you should buy a new computer.
                        
                        // If your internet is slow and this takes longer than 5 seconds let me know and I will extend 
                        // the wait.

                        do
                        {
                            // Increment the value for attempt
                            attempts++;

                            // Show the graph
                            Graph.Value = attempts;

                            // refresh everything
                            this.Refresh();

                            // Try every half second
                            System.Threading.Thread.Sleep(500);

                            // get the path
                            path = Path.Combine(Project.ServicesFolder, DataWatcherFileName);

                            // if the file exists
                            if (File.Exists(path))
                            {
                                // The files were created
                                filesCreated = true;

                                // break out of the loop
                                break;
                            }
                        }
                        while (attempts < 20);

                         // Wait one extra half second after the file is avialable before trying to modify it
                        System.Threading.Thread.Sleep(500);

                        // if the files were created
                        if (filesCreated)
                        {
                            // ***************************************
                            // ************** DataWatcher.cs Class *************
                            // ***************************************

                            // Now the file must be read
                            string fileText = File.ReadAllText(path);

                            // now create the replaceParameter values
                            string tableName = table.TableName;
                            string variableName = CSharpClassWriter.CapitalizeFirstCharEx(table.TableName, true);
                            string pluralTableName = PluralWordHelper.GetPluralName(table.TableName, false);
                            string pluralVariableName = PluralWordHelper.GetPluralName(table.TableName, true);
                            string primaryKeyDataType = "";
                            string primaryKeyVariableName = "";
                            string primaryKeyPropertyName = "";
                            
                            // Update 12.12.2020: The DataService (for Blazor) requires the PrimaryKey
                            // cataType and field name.
                            DTNField field = FindPrimaryKey(table);

                            // if the field was found
                            if (NullHelper.Exists(field))
                            {
                                // get the dataType
                                primaryKeyDataType = field.DataType.ToString().ToLower();
                                primaryKeyVariableName = CSharpClassWriter.CapitalizeFirstCharEx(field.FieldName, true);
                                primaryKeyPropertyName = CSharpClassWriter.CapitalizeFirstCharEx(field.FieldName, false);

                                // if an autonumber identity field (which most will be)
                                if (primaryKeyDataType == "autonumber")
                                {
                                    // switch to int
                                    primaryKeyDataType = "int";
                                }
                            }

                            // string parameterDataType = FindPrimaryKey
                        
                            // Replace out the fileText replacement parameters
                            fileText = fileText.Replace("[TableName]", tableName);
                            fileText = fileText.Replace("[VariableName]", variableName);
                            fileText = fileText.Replace("[PluralVariableName]", pluralVariableName);
                           
                            // Delete the current file at path 
                            File.Delete(path);

                            // rename the file
                            path = path.Replace("DataWatcher.cs", Table.TableName + "DataWatcher.cs");

                            // Write out the next text
                            File.WriteAllText(path, fileText);

                            // ***************************************
                            // ************** Service.cs Class *************
                            // ***************************************

                            // now change path to the Service class
                            path2 = Path.Combine(Project.ServicesFolder, ServiceFileName);

                            // Now the file must be read
                            fileText = File.ReadAllText(path2);

                            // Replace out the fileText replacement parameters
                            fileText = fileText.Replace("[TableName]", tableName);
                            fileText = fileText.Replace("[VariableName]", variableName);
                            fileText = fileText.Replace("[PluralVariableName]", pluralVariableName);
                            fileText = fileText.Replace("[PluralTableName]", pluralTableName);
                            fileText = fileText.Replace("[ParameterDataType]", primaryKeyDataType);
                            fileText = fileText.Replace("[PrimaryKey]", primaryKeyVariableName);
                            fileText = fileText.Replace("[PrimaryKeyPropertyName]", primaryKeyPropertyName);

                            // Delete the current file at path2
                            File.Delete(path2);

                            // rename the file
                            path2 = path2.Replace("Service.cs", Table.TableName + "Service.cs");

                            // Write out the next text
                            File.WriteAllText(path2, fileText);

                            // Show a message
                            message = "The following classes were created:" + Environment.NewLine + path + Environment.NewLine + path2;

                            // Hide the graph
                            Graph.Visible = false;

                            // Show the user a message
                            MessageBoxHelper.ShowMessage(message, "Files Created");
                        }
                        else
                        {
                            // change the message
                            message = "Oops, something went wrong. Step through the code in DataTier.Net.Client.Controls.BlazorDataServices.cs, event name CreateBlazorServicesButton_Click.";

                            // Show the user a message
                            MessageBoxHelper.ShowMessage(message, "Files Could Not Be Created", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception error)
                {
                    // Set the error
                    DebugHelper.WriteDebugError("CreateBlazorServicesButton_LinkClicked", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The Blazor Data Services Either Were Not Installed Or You Do Not Have Permission To Create Files In This Directory", "Create Data Services Failed");
                }
            }
            #endregion
            
            #region InstallBlazorServicesButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            /// <summary>
            /// event is fired when Install Blazor Services Button _ Link Clicked
            /// </summary>
            private void InstallBlazorServicesButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                try
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + ItemTemplateInstall;
                    process.StartInfo = startInfo;
                    process.Start();

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The Blazor Data Services Item Templates Have Been Installed", "Install Complete");
                }
                catch (Exception error)
                {
                    // Set the error
                    DebugHelper.WriteDebugError("InstallBlazorServicesButton_Click", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The Blazor Data Services May Have Already Been Installed Or You Do Not Have Permission", "Install Failed");
                }
            }
            #endregion

            #region OnTextChanged(Control sender, string text)
            /// <summary>
            /// event is fired when On Text Changed
            /// </summary>
            public void OnTextChanged(Control sender, string text)
            {  
                // if the value for HasProject is true
                if (HasProject)
                {
                    // Set the ServicesFolder
                    Project.ServicesFolder = text;
                }

                // Enable or disable controls
                UIEnable();

            }
            #endregion
            
            #region UninstallBlazorServicesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'UninstallBlazorServicesButton' is clicked.
            /// </summary>
            private void UninstallBlazorServicesButton_Click(object sender, EventArgs e)
            {
                try
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + ItemTemplateUninstall;
                    process.StartInfo = startInfo;
                    process.Start();

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The Blazor Data Services Item Templates Have Been Uninstalled", "Uninstall Complete");
                }
                catch (Exception error)
                {
                    // Set the error
                    DebugHelper.WriteDebugError("UninstallBlazorServicesButton_Click", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The Blazor Data Services Either Were Not Installed Or You Do Not Have Permission", "Uninstall Failed");
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region FindPrimaryKey(DTNTable table)
            /// <summary>
            /// This method returns the Primary Key for a table.
            /// This method is for single field Primary Keys, not 
            /// Composite primary keys consisting of multiple fields.
            /// You can manually add a second jparameter if needed for now.
            /// </summary>
            public DTNField FindPrimaryKey(DTNTable table)
            {
                // initial value
                DTNField primaryKey = null;

                // if the table has fields
                if ((NullHelper.Exists(table)) && (table.HasFields))
                {
                    // iterate the fields
                    foreach (DTNField field in table.Fields)    
                    {
                        // the field is a PrimaryKey
                        if (field.PrimaryKey)
                        {
                            // set the reeturn value
                            primaryKey = field;

                            // no reason to stick around until multiple primary key fields is handled.
                            break;
                        }
                    }
                }
                
                // return value
                return primaryKey;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Setup the listener
                this.ServicesFolderControl.OnTextChangedListener = this;

                // Fill when created
                this.Dock = DockStyle.Fill;
            }
            #endregion
            
            #region OnCancel()
            /// <summary>
            /// method On Cancel
            /// </summary>
            public void OnCancel()
            {
                // if the ParentForm exists
                if (NullHelper.Exists(this.ParentForm))
                {
                    // close the ParentForm
                    this.ParentForm.Close();
                }
            }
            #endregion
            
            #region OnSave(bool close)
            /// <summary>
            /// method returns the Save
            /// </summary>
            public bool OnSave(bool close)
            {
                // initial value
                bool saved = false;

                // if the project exists
                if (HasProject)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // Save the project
                    saved = gateway.SaveProject(ref project);

                    // Show the user a message
                    MessageBoxHelper.ShowMessage("All changes have been saved.", "Save Complete");

                    // create the writer
                    ProjectsWriter writer = new ProjectsWriter();

                    // reset the InitialProject
                    InitialProject = writer.ExportProject(Project);
                }

                // Enable controls
                UIEnable();

                // return value
                return saved;
            }
            #endregion
            
            #region Setup(Project project, DTNTable table)
            /// <summary>
            /// This method Setups this control
            /// </summary>
            public void Setup(Project project, DTNTable table)
            {
                // store the args
                Project = project;
                Table = table;

                // if the value for HasServicesFolder is false
                if (!HasServicesFolder)
                {
                    // Set the DefaultServicesFolder on the project so the Save button becomes enabled
                    Project.ServicesFolder = Path.Combine(Project.ProjectFolder, @"DataGateway\Services");
                }

                // Create a new instance of a 'ProjectsWriter' object.
                ProjectsWriter writer = new ProjectsWriter();

                // Set the InitialProject text so we can compare later
                this.InitialProject = writer.ExportProject(this.Project);

                // Display the Text
                ServicesFolderControl.Text = Project.ServicesFolder;

                // Fix a bug in my control to centger the buttons
                this.SaveCancelControl.CancelButtonTextAlign = ContentAlignment.MiddleCenter;
                this.SaveCancelControl.SaveButtonTextAlign = ContentAlignment.MiddleCenter;

                // Change the text of the CreateBlazorServicesButton
                this.CreateBlazorServicesButton.Text = "Create Data Services For " + Table.TableName;

                // Setup the CancelButton to use Done instead of Cancel
                this.SaveCancelControl.SetupCancelButton("Done", 80);
               
                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method enables or disables control or hides or shows controls based upon the state of the app.
            /// </summary>
            public void UIEnable()
            {
                // local
                bool enabledSaveButton = false;

                // if the value for HasInitialProject is true
                if (HasInitialProject)
                {
                    // if the Project Exists and the ServiceFolder exists and the ServiceFolders are different
                    // Create a new instance of a 'ProjectsWriter' object.
                    ProjectsWriter writer = new ProjectsWriter();

                    // Set the InitialProject text so we can compare later
                    string currentProject = writer.ExportProject(this.Project);

                    // set the value for enabledSaveButton
                    enabledSaveButton = !TextHelper.IsEqual(InitialProject, currentProject);
                }
                else
                {
                    // set to true
                    enabledSaveButton = true;
                }

                // set the value
                SaveCancelControl.EnableSaveButton = enabledSaveButton;
            }
            #endregion

        #endregion

        #region Properties

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

            #region HasInitialProject
            /// <summary>
            /// This property returns true if the 'InitialProject' exists.
            /// </summary>
            public bool HasInitialProject
            {
                get
                {
                    // initial value
                    bool hasInitialProject = (!String.IsNullOrEmpty(this.InitialProject));
                    
                    // return value
                    return hasInitialProject;
                }
            }
            #endregion
            
            #region HasProject
            /// <summary>
            /// This property returns true if this object has a 'Project'.
            /// </summary>
            public bool HasProject
            {
                get
                {
                    // initial value
                    bool hasProject = (this.Project != null);
                    
                    // return value
                    return hasProject;
                }
            }
            #endregion
            
            #region HasServicesFolder
            /// <summary>
            /// This property returns true if the 'ServicesFolder' exists.
            /// </summary>
            public bool HasServicesFolder
            {
                get
                {
                    // initial value
                    bool hasServicesFolder = (!String.IsNullOrEmpty(this.ServicesFolder));
                    
                    // return value
                    return hasServicesFolder;
                }
            }
            #endregion
            
            #region HasTable
            /// <summary>
            /// This property returns true if this object has a 'Table'.
            /// </summary>
            public bool HasTable
            {
                get
                {
                    // initial value
                    bool hasTable = (this.Table != null);
                    
                    // return value
                    return hasTable;
                }
            }
            #endregion
            
            #region InitialProject
            /// <summary>
            /// This property gets or sets the value for 'InitialProject'.
            /// </summary>
            public string InitialProject
            {
                get { return initialProject; }
                set { initialProject = value; }
            }
            #endregion
            
            #region Project
            /// <summary>
            /// This property gets or sets the value for 'Project'.
            /// </summary>
            public Project Project
            {
                get { return project; }
                set { project = value; }
            }
            #endregion
            
            #region ServicesFolder
            /// <summary>
            /// This property gets or sets the value for 'ServicesFolder'.
            /// </summary>
            public string ServicesFolder
            {
                get 
                {
                    // initial value
                    string servicesFolder = "";

                    // if the value for HasProject is true
                    if (HasProject)
                    {
                        // return value
                        servicesFolder = Project.ServicesFolder;
                    }

                    // return value
                    return servicesFolder;
                } 
            }
            #endregion
            
            #region Table
            /// <summary>
            /// This property gets or sets the value for 'Table'.
            /// </summary>
            public DTNTable Table
            {
                get { return table; }
                set { table = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
