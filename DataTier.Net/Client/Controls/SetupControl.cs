

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
using DataTierClient.ClientUtil;
using ObjectLibrary.Enumerations;

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
        private StepEnum currentStep;       
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
            
            #region InstallDatabaseSchemaButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallDatabaseSchemaButton' is clicked.
            /// </summary>
            private void InstallDatabaseSchemaButton_Click(object sender, EventArgs e)
            {
                // Set to clicked
                DatabaseSchemaClicked = true;
                ClickHereButton.Visible = false;

                // get the path to the sql
                string path = "../../../Database/SQL Scripts/DataTier.Net.Database.Schema.sql";

                // set path2
                FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
                string path2 = Path.Combine(fileInfo.DirectoryName,  @"SQL Scripts\DataTier.Net.Database.Schema.sql");

                // if the path exists
                if ((File.Exists(path)) || (File.Exists(path2)))
                {
                    try
                    {
                        // get the fullPath
                        string fullPath = Path.GetFullPath(path);

                        // if the file exists, than this is Visual Studio
                        if (File.Exists(fullPath))
                        {
                            // launch SQL Server Management Studio if installed
                            System.Diagnostics.Process.Start(fullPath);

                            // Advance to the next step
                            CurrentStep = StepEnum.Step2;
                        }
                        else
                        {
                            // set fullPath for exe version
                            fullPath = Path.GetFullPath(path2);

                            // if the file exists
                            if (File.Exists(fullPath))
                            {
                                // launch SQL Server Management Studio if installed
                                System.Diagnostics.Process.Start(fullPath);

                                // Advance to the next step
                                CurrentStep = StepEnum.Step2;
                            }
                            else
                            {
                                // Show the user a message
                                MessageHelper.DisplayMessage("SQL Script could not be located. Find and execute the script DataTier.Net.Database.Schema.sql", "File Not Found");
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("InstallDatabaseSchemaButton_Click", this.Name, error);  

                        // Show a message
                        MessageHelper.DisplayMessage("An error occurred launching SQL Server Management Studio", "Error Launching SSMS");
                    }
                }
                else
                {
                    // Show a message
                    MessageHelper.DisplayMessage("Could not located the SQL Scripts path. Look for the file 'DataTier.Net.Database.Schema.sql in the install directory for DataTier.Net", "File Not Found");
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion
          
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                    // Show or hide the InfoLabel and InfoLabel1 basedup isChecked value.                
                    ClickHereButton.Visible = ((isChecked) && (!DatabaseSchemaClicked));

                    // there is only one label check box control so this has to be the DatabaseCreatedCheckBox
                
                    // if isChecked is true
                    if (isChecked)
                    {
                        // Show the button                        
                        InstallDatabaseSchemaButton.Visible = true;
                        InstallDatabaseSchemaButton.ForeColor = Color.GhostWhite;
                    }
                    else
                    {
                        // Hide the button                        
                        InstallDatabaseSchemaButton.Visible = false;
                    }
                }
                #endregion

            #region RemoveTemplatesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RemoveTemplatesButton' is clicked.
            /// </summary>
            private void RemoveTemplatesButton_Click(object sender, EventArgs e)
            {
                // Remove focus from this control
                HiddenButton.Focus();

                 // Create a new instance of a 'RemoveTemplatesForm' object.
                RemoveTemplatesForm form = new RemoveTemplatesForm();

                // Show the form
                form.Show();
            }
            #endregion
            
            #region Step1Button_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'Step1Button' is clicked.
            /// </summary>
            private void Step1Button_Click(object sender, EventArgs e)
            {
                
            }
            #endregion
            
            #region Step1Button_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Step 1 Button _ Enabled Changed
            /// </summary>
            private void Step1Button_EnabledChanged(object sender, EventArgs e)
            {
                // If Enabled
                if (Step1Button.Enabled)
                {
                    // Use Enabled Red Image
                    Step1Button.BackgroundImage = Properties.Resources.WoodButtonRed;

                    // Use White
                    Step1Button.ForeColor = Color.White;
                }
                else
                {
                    // Use Disabled Dark Gray
                    Step1Button.BackgroundImage = Properties.Resources.WoodButtonDarkGray;

                    // Use White
                    Step1Button.ForeColor = Color.FromArgb(20, 20, 20);
                }
            }
            #endregion
            
            #region Step2Button_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'Step2Button' is clicked.
            /// </summary>
            private void Step2Button_Click(object sender, EventArgs e)
            {
                // create a new ConnectionStringBuilderForm
                ConnectionStringBuilderForm form = new ConnectionStringBuilderForm(DatabaseName);

                // Show the form
                form.ShowDialog();

                // if the user did not cancel
                if (!form.UserCancelled)
                {
                    // Setup is complete
                    UserCancelled = false;

                    // Close the Parentform
                    ParentForm.Close();
                }
            }
            #endregion
            
            #region Step2Button_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Step 2 Button _ Enabled Changed
            /// </summary>
            private void Step2Button_EnabledChanged(object sender, EventArgs e)
            {
                // If Enabled
                if (Step2Button.Enabled)
                {
                    // Use Enabled Red Image
                    Step2Button.BackgroundImage = Properties.Resources.WoodButtonRed;

                    // Use White
                    Step2Button.ForeColor = Color.White;
                }
                else
                {
                    // Use Disabled Dark Gray
                    Step2Button.BackgroundImage = Properties.Resources.WoodButtonDarkGray;

                    // Use White
                    Step2Button.ForeColor = Color.FromArgb(20, 20, 20);
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

                // if the value for IsInstalledVersion is true
                if (IsInstalledVersion)
                {
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
            
            #region ViewWordButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ViewWordButton' is clicked.
            /// </summary>
            private void ViewWordButton_Click(object sender, EventArgs e)
            {
                // get the path to the file 
                string path = Path.GetFullPath(@"../../../Class Room/Documents/DataTier.Net Quick Start.docx");

                // if the value for IsInstalledVersion is true
                if (IsInstalledVersion)
                {
                    // change the path to the install folder
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

                // Set to 1
                CurrentStep = StepEnum.Step1;

                // Enable or disable controls
                UIEnable();
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

            #region UIEnable()
            /// <summary>
            /// UI Enable
            /// </summary>
            public void UIEnable()
            {
                // Enable the buttons
                Step1Button.Enabled = ((int) CurrentStep ==  1);
                Step2Button.Enabled = ((int) CurrentStep ==  2);  
                
                // Deteremine which controls are visible
                if (CurrentStep == StepEnum.Step1)
                {
                    ManHoldingSign.BackgroundImage = Properties.Resources.ManHoldingSignWithSSMSTExt;
                    DatabaseCreatedCheckBox.Visible = true;
                }
                else
                {
                    ManHoldingSign.BackgroundImage = Properties.Resources.setupStep2;
                    InstallDatabaseSchemaButton.Visible = false;
                    ClickHereButton.Visible = false;
                    DatabaseCreatedCheckBox.Visible = false;
                }

                // Update the UI
                Refresh();
                Application.DoEvents();
            }
            #endregion
            
        #endregion

        #region Properties

            #region CurrentStep
            /// <summary>
            /// This property gets or sets the value for 'CurrentStep'.
            /// </summary>
            public StepEnum CurrentStep
            {
                get { return currentStep; }
                set { currentStep = value; }
            }
            #endregion
            
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
