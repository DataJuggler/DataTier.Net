

#region using statements

using DataTierClient.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataTierClient.Controls
{

    #region class SetupControl
    /// <summary>
    /// This control is designed to make it easy for people to get started with DataTier.Net.
    /// There are now 3 steps that should take 5 minutes or less.
    /// </summary>
    public partial class SetupControl : UserControl, ICheckChangedListener
    {
        
        #region Private Variables
        private bool userCancelled;
        private bool databaseSchemaClicked;
        private const string DatabaseName = "DataTier.Net.Database";
        public const string DotNet5ProjectTemplates = "dotnet new -install DataJuggler.DataTier.Net5.ProjectTemplates";
        public const string UninstallDotNet5ProjectTemplates = "dotnet new -uninstall DataJuggler.DataTier.Net5.ProjectTemplates";
        public const string DotNet6ProjectTemplates = "dotnet new -install DataJuggler.DataTier.Net6.ProjectTemplates";
        public const string UninstallDotNet6ProjectTemplates = "dotnet new -uninstall DataJuggler.DataTier.Net6.ProjectTemplates";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SetupControl' object.
        /// </summary>
        public SetupControl()
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
            
            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CancelButton' is clicked.
            /// </summary>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // close this app
                userCancelled = true;

                // If the ParentForm object exists
                if (ParentForm != null)
                {
                    // close the parent form
                    ParentForm.Close();
                }
            }
            #endregion
            
            #region ConfigureButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ConfigureButton' is clicked.
            /// </summary>
            private void ConfigureButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'ConnectionStringBuilderForm' object.
                ConnectionStringBuilderForm form = new ConnectionStringBuilderForm(DatabaseName);

                // Show the form
                form.ShowDialog();

                // if the user did not cancel
                if (!form.UserCancelled)
                {
                    // Setup is complete
                    this.UserCancelled = false;

                    // Close the Parentform
                    this.ParentForm.Close();
                }
            }
            #endregion
            
            #region ConfigureButton_MouseHover(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Configure Button _ Mouse Hover
            /// </summary>
            private void ConfigureButton_MouseHover(object sender, EventArgs e)
            {
                 // Show InfoLabel3 while hovering
                InfoLabel3.Visible = true;
            }
            #endregion
            
            #region DotNet5Label_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DotNet5Label_Click' is clicked.
            /// </summary>
            private void DotNet5Label_Click(object sender, EventArgs e)
            {
                 try               
                 {
                     // Create a Process to launch a command window (hidden) to create the item templates
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + DotNet5ProjectTemplates;
                    process.StartInfo = startInfo;
                    process.Start();

                    // Show the user a message
                    MessageBoxHelper.ShowMessage("DataJuggler.DataTier.Net5.ProjectTemplates were installed onto your computer.", "Install Complete");
                 }
                 catch (Exception error)
                 {
                     // Set the error
                    DebugHelper.WriteDebugError("DotNet5Label_Click", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The DataTier.Net5.Project Templates could not be installed. Ensure you are connected to the internet and try again.", "Insteall Templates Failed");
                 }
            }
            #endregion
            
            #region InstallDatabaseSchemaButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallDatabaseSchemaButton' is clicked.
            /// </summary>
            private void InstallDatabaseSchemaButton_Click(object sender, EventArgs e)
            {
                // Set to clicked
                DatabaseSchemaClicked = true;
                ClickHere.Visible = false;

                // get the path to the sql
                string path = "../../../Database/SQL Scripts/DataTier.Net.Database.Schema.sql";

                // if the path exists
                if (File.Exists(path))
                {
                    try
                    {
                        // get the fullPath
                        string fullPath = Path.GetFullPath(path);

                        // launch SQL Server Management Studio if installed
                        System.Diagnostics.Process.Start(fullPath);
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("InstallDatabaseSchemaButton_Click", this.Name, error);  
                    }
                }
            }
            #endregion
            
            #region InstallDotNet6Label_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallDotNet6Label' is clicked.
            /// </summary>
            private void InstallDotNet6Label_Click(object sender, EventArgs e)
            {
                try               
                 {
                     // Create a Process to launch a command window (hidden) to create the item templates
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + DotNet6ProjectTemplates;
                    process.StartInfo = startInfo;
                    process.Start();

                    // Show the user a message
                    MessageBoxHelper.ShowMessage("DataJuggler.DataTier.Net6.ProjectTemplates were installed onto your computer.", "Install Complete");
                 }
                 catch (Exception error)
                 {
                     // Set the error
                    DebugHelper.WriteDebugError("DotNet6Label_Click", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The DataTier.Net6.Project Templates could not be installed. Ensure you are connected to the internet and try again.", "Insteall Templates Failed");
                 }
            }
            #endregion
            
            #region InstallProjectTemplatesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallProjectTemplatesButton' is clicked.
            /// </summary>
            private void InstallProjectTemplatesButton_Click(object sender, EventArgs e)
            {
                // set the path to the vsix install
                string vsixPath = "../../../../VSIX/DataTierNet.ProjectTemplates.Installer.vsix";

                // if the vsixPath exists
                if (File.Exists(vsixPath))
                {
                    try
                    {
                        // get the fullPath (relative paths will not launch the file)
                        string fullPath = Path.GetFullPath(vsixPath);

                        // launch the VSIX installer to install the DataTier.Net Project Templates into Visual Studio
                        System.Diagnostics.Process.Start(fullPath);
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("InstallProjectTemplatesButton_Click", this.Name, error);  
                    }
                }
            }
            #endregion
            
            #region InstallProjectTemplatesButton_MouseHover(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Install Project Templates Button _ Mouse Hover
            /// </summary>
            private void InstallProjectTemplatesButton_MouseHover(object sender, EventArgs e)
            {
                // Show InfoLabel2 while hovering
                InfoLabel2.Visible = true;
            }
            #endregion
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // Show or hide the InfoLabel and InfoLabel1 basedup isChecked value.
                InfoLabel.Visible = !isChecked;                
                ClickHere.Visible = ((isChecked) && (!DatabaseSchemaClicked));

                // there is only one label check box control so this has to be the DatabaseCreatedCheckBox
                
                // if isChecked is true
                if (isChecked)
                {
                    // Enable the button
                    InstallDatabaseSchemaButton.Enabled = true;
                    InstallDatabaseSchemaButton.ForeColor = Color.GhostWhite;
                }
                else
                {
                    // Disable the button
                    InstallDatabaseSchemaButton.Enabled = false;
                    InstallDatabaseSchemaButton.ForeColor = Color.DarkGray;
                }
            }
        #endregion

            #region UninstallDotNet5Label_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'UninstallDotNet5Label' is clicked.
            /// </summary>
            private void UninstallDotNet5Label_Click(object sender, EventArgs e)
            {
                try               
                 {
                     // Create a Process to launch a command window (hidden) to create the item templates
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + UninstallDotNet5ProjectTemplates;
                    process.StartInfo = startInfo;
                    process.Start();
                    
                    // Show the user a message
                    MessageBoxHelper.ShowMessage("DataJuggler.DataTier.Net5.ProjectTemplates were uninstalled from your computer.", "Uninstall Complete");
                 }
                 catch (Exception error)
                 {
                     // Set the error
                    DebugHelper.WriteDebugError("UninstallDotNet5_Click", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The DataTier.Net5.Project Templates could not be uninstalled.", "Uninsteall Templates Failed");
                 }
            }
            #endregion
            
            #region UninstallDotNet6Label_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'UninstallDotNet6Label' is clicked.
            /// </summary>
            private void UninstallDotNet6Label_Click(object sender, EventArgs e)
            {
                try               
                 {
                     // Create a Process to launch a command window (hidden) to create the item templates
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + UninstallDotNet6ProjectTemplates;
                    process.StartInfo = startInfo;
                    process.Start();

                    // Show the user a message
                    MessageBoxHelper.ShowMessage("DataJuggler.DataTier.Net6.ProjectTemplates were uninstalled from your computer.", "Uninstall Complete");
                 }
                 catch (Exception error)
                 {
                     // Set the error
                    DebugHelper.WriteDebugError("UninstallDotNet6_Click", this.Name, error);

                    // show the user a message
                    MessageBoxHelper.ShowMessage("The DataTier.Net6.ProjectTemplates could not be uninstalled.", "Uninsteall Templates Failed");
                 }
            }
            #endregion
            
            #region ViewPDFButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ViewPDFButton' is clicked.
            /// </summary>
            private void ViewPDFButton_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Quick Start.pdf");

                // if the path exists
                if (File.Exists(path))
                {
                    // Open the file
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    // Show a message to the user
                    MessageBox.Show("Sorry we could not find the installed documentation.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
            #region ViewWordButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ViewWordButton' is clicked.
            /// </summary>
            private void ViewWordButton_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Quick Start.docx");

                // if the path exists
                if (File.Exists(path))
                {
                    // Open the file
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    // Show a message to the user
                    MessageBox.Show("Sorry we could not find the installed documentation.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to UserCancelled in case the form is closed.
                UserCancelled = true;

                // Setup the listener
                DatabaseCreatedCheckBox.CheckChangedListener = this;
            }
        #endregion

        #endregion

        #region Properties

            #region DatabaseSchemaClicked
            /// <summary>
            /// This property gets or sets the value for 'DatabaseSchemaClicked'.
            /// </summary>
            public bool DatabaseSchemaClicked
            {
                get { return databaseSchemaClicked; }
                set { databaseSchemaClicked = value; }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool UserCancelled
            {
                get { return userCancelled; }
                set 
                { 
                    userCancelled = value;
                }
            }
        #endregion

        #endregion
    }
    #endregion

}
