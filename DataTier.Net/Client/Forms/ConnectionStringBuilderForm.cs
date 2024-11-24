

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using DataJuggler.Net;
using DataJuggler.Net.Cryptography;
using DataJuggler.Net.Connection;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using DataTierClient.Enumerations;
using DataTierClient.ClientUtil;

#endregion

namespace DataTierClient.Forms
{

    #region class ConnectionStringBuilderForm
    /// <summary>
    /// This class is used to build and test connection strings.
    /// </summary>
    public partial class ConnectionStringBuilderForm : Form, ICheckChangedListener, ITextChanged
    {
        
        #region Private Variables
        private ConnectionInfo connectionInfo;
        private bool userCancelled;
        private List<TextLine> appConfigTextLines;
        private string appConfigPath;
        private int connectionStringIndex;
        private int setupCompleteIndex;
        private int useEncryptionIndex;
        private int encryptionKeyIndex;
        private bool isExecutableConfig;
        private const string HTMLCommentStart = "<!--";
        private const string ConnectionStringStart = "<add key=\"ConnectionString\" value=";
        private const string SetupCompleteStart = "<add key=\"SetupComplete\" value=";
        private const string UseEncryptionStart = "<add key=\"UseEncryption\" value=";
        private const string EncryptionKeyStart = "<add key=\"EncryptionKey\" value=";
        #endregion
        
        #region Constructors

            #region Constructor
            /// <summary>
            /// This constructor [enter description here].
            /// </summary>
            public ConnectionStringBuilderForm()
            {
                // Create Controls
                InitializeComponent();
            
                // Perform Initializations for this object
                Init();
            }
            #endregion

            #region Parameterized Constructor(string databaseName)
            /// <summary>
            /// Create a new instance of a ConnectionStringBuilderForm and set the databaseName
            /// </summary>
            public ConnectionStringBuilderForm(string databaseName)
            {
                // Create Controls
                InitializeComponent();
            
                // Perform Initializations for this object
                Init();

                // Set DatabaseName control text
                this.DatabaseNameControl.Text = databaseName;
            }
            #endregion

        #endregion
        
        #region Events
            
            #region BuildConnectionStringButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event builds a connection string from the values entered.
            /// </summary>
            private void BuildConnectionStringButton_Click(object sender, EventArgs e)
            {
                // locals
                string connectionString = "";
                
                // Capture the connection info 
                this.ConnectionInfo = this.CaptureConnectionInfo();
                
                // if the value for HasConnectionInfo is true
                if (HasConnectionInfo)
                {
                    // if the connection string should use IntegratedSecurity (Windows Authentication)
                    if (connectionInfo.IntegratedSecurity)
                    {
                        // Build the connectionString
                        connectionString = ConnectionStringHelper.BuildConnectionString(connectionInfo.DatabaseServer, connectionInfo.DatabaseName);
                    }
                    else
                    {
                        // Build the connectionString
                        connectionString = ConnectionStringHelper.BuildConnectionString(connectionInfo.DatabaseServer, connectionInfo.DatabaseName, connectionInfo.DatabaseUserName, connectionInfo.DatabasePassword);
                    }

                    // if this value is checked
                    if (IncludeEncryptCheckBox.Checked)
                    {
                        // if the connection string ends with a semicolon
                        if (connectionString.EndsWith(";"))
                        {
                            // Append the Encrypt value
                            connectionString += "Encrypt=" + EncryptValueComboBox.ComboBoxText + ";";
                        }
                        else
                        {
                            // Append a semicolon then the Encrypt value
                            connectionString += ";Encrypt=" + EncryptValueComboBox.ComboBoxText + ";";
                        }
                    }

                    // display the connectionString
                    this.ConnectionstringControl.Text = connectionString;
                }
            }
            #endregion
            
            #region Button_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enabled Changed
            /// </summary>
            private void Button_EnabledChanged(object sender, EventArgs e)
            {
                // cast the sender as a button
                Button button = sender as Button;

                // if enabled
                if (button.Enabled)
                {  
                    // Setup Enabled button
                    button.ForeColor = Color.Black;                

                     // if a wide button
                    if (button.Width > 400)
                    {
                        // use 2560 width image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth2560;
                    }
                    // if a little bit wide
                    else if (button.Width > 200)
                    {
                        // use 1280 width image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth1280;
                    }
                    else
                    {
                        // use normal image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth640;
                    }            
                }
                else
                {
                    // Setup Disabled button
                    button.ForeColor = Color.DarkGray;
                    
                    // if a wide button
                    if (button.Width > 400)
                    {
                        // use 2560 width image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth2560Disabled;
                    }
                    // if a little bit wide
                    else if (button.Width > 200)
                    {
                        // use 1280 width image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth1280Disabled;
                    }
                    else
                    {
                        // use normal image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth640Disabled;
                    }            
                }
            }
            #endregion
            
            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Change to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // Change to default
                this.Cursor = Cursors.Default;
            }
            #endregion
                                  
            #region CopiedTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Copied Timer _ Tick
            /// </summary>
            private void CopiedTimer_Tick(object sender, EventArgs e)
            {
                // Only runonce
                this.CopiedTimer.Enabled = false;

                // Hide the image
                this.CopiedImage.Visible = false;
            }
            #endregion
            
            #region CopyButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'CopyButton' is clicked.
            /// </summary>
            private void CopyButton_Click(object sender, EventArgs e)
            {
                // Encrypt the Connection String
                string connectionString = this.ConnectionstringControl.Text;

                // Copy the connectionString to the clipboard
                Clipboard.SetText(connectionString);

                // Show the user a message
                Clipboard.SetText(connectionString);
                
                // Show the CopiedImage and start the timer
                ShowCopiedImage();
            }
            #endregion
            
            #region DoneButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'DoneButton' is clicked.
            /// </summary>
            private void DoneButton_Click(object sender, EventArgs e)
            {
                // close this form 
                this.Close();
            }
            #endregion
            
            #region InstallConnectionStringButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallConnectionStringButton' is clicked.
            /// </summary>
            private void InstallConnectionStringButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // get the connection string line from the app.config
                    // TextLine connectionStringLine = GetConnectionStringLine();

                    // Install the ConnectionString in a User Level Environment Variable
                    InstallConnectionString();                    
                }
                catch (Exception error)
                {  
                    // forr debugging only
                    DebugHelper.WriteDebugError("InstallConnectionString_Click", "ConnectionStringBuilderForm", error);

                    // Show user a message
                    MessageHelper.DisplayMessage("An error occurred updating your configuration: " + error.ToString(), "Update Config Error");
                }
            }
            #endregion
            
            #region InstalledTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Installed Timer _ Tick
            /// </summary>
            private void InstalledTimer_Tick(object sender, EventArgs e)
            {
                // Only runonce
                this.InstalledTimer.Enabled = false;

                // Hide the image
                this.InstalledImage.Visible = false;

                // Close this form
                this.Close();
            }
            #endregion
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // Enable or disable buttons
                UIControl();
            }
            #endregion

            #region OnTextChanged(Control control, string text)
            /// <summary>
            /// event is fired when On Text Changed
            /// </summary>
            public void OnTextChanged(Control control, string text)
            {
                // if the value for HasConnectionInfo is true
                if (HasConnectionInfo)
                {
                    // cast the control as a LabelTextBox
                    LabelTextBoxControl textBox = control as LabelTextBoxControl;

                    // If the textBox object exists
                    if (NullHelper.Exists(textBox))
                    {
                        // determine the action by the name
                        switch (textBox.Name)
                        {
                            case "DatabaseServerControl":

                                // Set the value for DatabaseServer
                                ConnectionInfo.DatabaseServer = text;

                                // required
                                break;

                            case "DatabaseNameControl":

                                 // Set the value for DatabaseName
                                ConnectionInfo.DatabaseName = text;

                                // required
                                break;

                            case "DatabaseUserControl":

                                 // Set the value for DatabaseUserName
                                ConnectionInfo.DatabaseUserName = text;

                                // required
                                break;

                            case "DatabasePasswordControl":

                                 // Set the value for DatabasePassword
                                ConnectionInfo.DatabasePassword = text;

                                // required
                                break;

                            case "x":

                                // set the connection string
                                ConnectionInfo.ConnectionString = text;

                                // required
                                break;
                        }
                    }
                }

                // Enable or disable ncontrols
                UIControl();
            }
            #endregion
            
            #region SQLServerAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the SQL Server radio button is checked.
            /// </summary>
            private void SQLServerAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                // shortcut
                bool isChecked = this.SQLServerAuthenticationRadioButton.Checked;
                
                // Show or hide the controls based upon the value of isChecked
                this.DatabaseUserControl.Visible = isChecked;
                this.DatabasePasswordControl.Visible = isChecked;

                // if the value for HasConnectionInfo is true
                if (HasConnectionInfo)
                {
                    // set the value for IntegratedSecurity
                    ConnectionInfo.IntegratedSecurity = WindowsAuthenticationRadioButton.Checked;

                    // Enable or disable controls
                    UIControl();
                }
            }
            #endregion
            
            #region TestDatabaseConnectionButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the Test Database Connection button is clieccked.
            /// </summary>
            private void TestDatabaseConnectionButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // set the connectionTest
                    bool connectionTest = false;
                    
                    // Set the connectionString
                    string connectionString = this.ConnectionstringControl.Text;
                    
                    // test for a connectionString 
                    bool hasConnectionString = (!String.IsNullOrEmpty(connectionString));
                    
                    // if a connection string has been established
                    if (hasConnectionString)
                    {
                        // set the dataConnector
                        SQLDatabaseConnector dataConnector = new SQLDatabaseConnector();
                        
                        // set the connection string
                        dataConnector.ConnectionString = connectionString;
                        
                        // Test the connection
                        connectionTest = SQLDatabaseTester.TestDatabaseConnection(dataConnector);
                        
                        // if the connection test passed
                        if (connectionTest)
                        {
                            // Change the text to passed
                            this.StatusLabel.Text = "Database Connection Test Passed.";

                            // Show Success
                            this.StatusImage.BackgroundImage = Properties.Resources.Success;

                                // Set the text to the clipboard
                            Clipboard.SetText(connectionString);

                            // Show the CopiedImage and start the CopiedTimer
                            ShowCopiedImage();
                        }
                        else
                        {
                            // Show a success message
                            this.StatusLabel.Text = "Database Connection Failed.";

                            // Show Failure
                            this.StatusImage.BackgroundImage = Properties.Resources.Failure;
                        }    

                        // Show the StatusLabel and Image
                        this.StatusLabel.Visible = true;
                        this.StatusImage.Visible = true;
                    }
                    else
                    {
                        // Show a warning message
                        MessageHelper.DisplayMessage("You must build or enter a connection string.", "Missing Information");
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                    
                    // Show a success message
                    MessageHelper.DisplayMessage("A connection to the database count not be estalished.", "Connection Test Failed");
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region CaptureConnectionInfo()
            /// <summary>
            /// This method captures the data on this form.
            /// </summary>
            private ConnectionInfo CaptureConnectionInfo()
            {
                // initial value
                ConnectionInfo connectionInfo = new ConnectionInfo();
                
                // Create the connection info
                connectionInfo = new ConnectionInfo();
                
                // Set the values
                connectionInfo.DatabaseName = this.DatabaseNameControl.Text;
                connectionInfo.DatabaseServer = this.DatabaseServerControl.Text;
                connectionInfo.IntegratedSecurity = this.WindowsAuthenticationRadioButton.Checked;
                
                // if not Windows Authentication
                if (!connectionInfo.IntegratedSecurity)
                {
                    // Set the database user name & password
                    connectionInfo.DatabaseUserName = this.DatabaseUserControl.Text;
                    connectionInfo.DatabasePassword = this.DatabasePasswordControl.Text;
                }
                
                // return value
                return connectionInfo;
            }
            #endregion
            
            #region GetConnectionStringLine()
            /// <summary>
            /// This method returns the Connection String Line
            /// </summary>
            public TextLine GetConnectionStringLine()
            {
                // initial value
                TextLine connectionStringLine = null;

                // Set the ConnectionStringIndex
                ConnectionStringIndex = -1;

                // local
                int index = -1;
                
                 // set the appConfig file location relative to bin\debug
                string appConfig = "../../App.config";

                // Get the executing assembly's folder
                string directory = AppDomain.CurrentDomain.BaseDirectory;

                // this is visual studio
                bool isVisualStudio = ((directory.ToLower().Contains("debug")) || (directory.ToLower().Contains("release")));
                IsExecutableConfig = !isVisualStudio;
                
                // if this is VisualStudio
                if ((isVisualStudio) && (File.Exists(appConfig)))
                {
                    // get the full path
                    string fullPath = Path.GetFullPath(appConfig);

                    // Set the AppConfigPath
                    AppConfigPath = fullPath;

                    // read the text of the AppConfig
                    string appConfigText = File.ReadAllText(fullPath);

                    // If the appConfigText string exists
                    if (TextHelper.Exists(appConfigText))
                    {
                        // get the textLines
                        List<TextLine> textLines = TextHelper.GetTextLines(appConfigText);

                        // If the textLines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(textLines))
                        {
                            // store the textLines so they can be updated in the next step
                            AppConfigTextLines = textLines;

                            // Iterate the collection of TextLine objects
                            foreach (TextLine textLine in textLines)
                            {
                                // Increment the value for tempIndex
                                index++;

                                // if this is not a comment line
                                if (!textLine.Text.Trim().StartsWith(HTMLCommentStart))
                                {
                                    // if this is the ConnectionStringLine
                                    if (textLine.Text.Trim().StartsWith(ConnectionStringStart))
                                    {
                                        // get the textLine
                                        connectionStringLine = textLine;

                                        // Set the ConnectionStringIndex
                                        ConnectionStringIndex = index;

                                        // break out of this loop
                                        break;
                                    }
                                    else if (textLine.Text.Trim().StartsWith(SetupCompleteStart))
                                    {
                                        // Set the SetupCompleteIndex
                                        SetupCompleteIndex = index;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Show a message to user
                        MessageHelper.DisplayMessage("Error: 002: Error reading connection string: " + appConfig, "Invalid Configuration");
                    }
                }
                
                // return value
                return connectionStringLine;
            }
            #endregion
            
            #region GetUseEncryptionTextLine(bool setEncryptionKeyAlso = false)
            /// <summary>
            /// This method returns the Use Encryption Text Line
            /// </summary>
            public TextLine GetUseEncryptionTextLine(bool setEncryptionKeyAlso = false)
            {
                // local
                int index = -1;

                // initial value
                TextLine useEncryptionTextLine = null;

                // if the AppConfigTextLines exist
                if (ListHelper.HasOneOrMoreItems(AppConfigTextLines))
                {
                    // Iterate the collection of TextLine objects
                    foreach (TextLine textLine in AppConfigTextLines)
                    {
                        // Increment the value for tempIndex
                        index++;

                        // if this is not a comment line
                        if (!textLine.Text.Trim().StartsWith(HTMLCommentStart))
                        {
                            // if this is the ConnectionStringLine
                            if (textLine.Text.Trim().StartsWith(UseEncryptionStart))
                            {
                                // get the textLine
                                useEncryptionTextLine = textLine;

                                // Set the UseEncryptionIndex
                                UseEncryptionIndex = index;

                                // if the value for setEncryptionKeyAlso is false
                                if (!setEncryptionKeyAlso)
                                {
                                    // break out of this loop
                                    break;
                                }
                            }
                            else if (textLine.Text.Trim().StartsWith(EncryptionKeyStart))
                            {
                                // Set the SetupCompleteIndex
                                EncryptionKeyIndex = index;

                                // now we can exit
                                break;
                            }
                        }
                    }
                }
                
                // return value
                return useEncryptionTextLine;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to UserCancelled = true
                UserCancelled = true;

                // Create a new instance of a 'ConnectionInfo' object.
                this.ConnectionInfo = new ConnectionInfo();

                // Default to SQL Server Authentication at First
                this.SQLServerAuthenticationRadioButton.Checked = true;

                // Setup the listeners
                this.DatabaseServerControl.OnTextChangedListener = this;
                this.DatabaseNameControl.OnTextChangedListener = this;
                this.DatabaseUserControl.OnTextChangedListener = this;
                this.DatabasePasswordControl.OnTextChangedListener = this;
                this.ConnectionstringControl.OnTextChangedListener = this;
                IncludeEncryptCheckBox.Checked = true;
                EncryptValueComboBox.LoadItems(typeof(TrueFalseEnum));
                EncryptValueComboBox.SelectedIndex = EncryptValueComboBox.FindItemIndexByValue("False");

                // Change the Content Alignment
                this.ConnectionstringControl.LabelTextAlign = ContentAlignment.TopRight;
                
                // Enable or disable controls
                UIControl();
            }
            #endregion

            #region InstallConnectionString()
            /// <summary>
            /// This method returns the Connection String
            /// </summary>
            public bool InstallConnectionString()
            {
                // initial value
                bool installed = false;

                // If the ConnectionString string exists
                if (TextHelper.Exists(ConnectionString))
                {
                    // Set the value
                    bool environmentVariableSet = ApplicationLogicComponent.Connection.EnvironmentVariableHelper.SetEnvironmentVariableValue(MainForm.DataTierNetConnectionName, ConnectionString);

                    // if the value for environmentVariableSet is true
                    if (environmentVariableSet)
                    {
                        // success
                        UserCancelled = false;

                        // Change the text to finished
                        this.CancelButton.Text = "Finished";

                        // just in case this is visible after a Test still
                        this.CopiedImage.Visible = false;

                        // Show the Installed Image
                        this.InstalledImage.Visible = true;
                                
                        // Start the timer (this form will close in 5 seconds if the user doesn't close it sooner)
                        InstalledTimer.Enabled = true;
                    }
                    else
                    {
                        // Show a message here
                        MessageHelper.DisplayMessage("The environment variable could not be set. Create a User Level Environment Variable named DataTierNetConnection and set the value to your connection string.", "Install Connection String Failed");
                    }
                }
                
                // return value
                return installed;
            }
            #endregion
            
            #region ShowCopiedImage()
            /// <summary>
            /// This method Show Copied Image
            /// </summary>
            public void ShowCopiedImage()
                {
                     // Show the CopiedImage
                    this.CopiedImage.Visible = true;

                    // Start the timer to get rid of the Copied Image
                    this.CopiedTimer.Enabled = true;
                }
                #endregion
            
            #region UIControl()
            /// <summary>
            /// This method enables or disables controls
            /// </summary>
            public void UIControl()
            {
                // if we have a valid connection info
                if ((HasConnectionInfo) && (ConnectionInfo.IsValid))
                {
                    // Enable the button for BuildConnectionString
                    BuildConnectionStringButton.Enabled = true;
                }
                else
                {
                    // Disable the button for BuildConnectionString
                    BuildConnectionStringButton.Enabled = false;
                }

                // if the ConnectionStringControl.Text exists
                if (ConnectionstringControl.HasText)
                {
                    // Enable the Test and Copy buttons
                    InstallConnectionStringButton.Enabled = true;
                    TestButton.Enabled = true;
                    CopyButton.Enabled = true;
                }
                else
                {
                    // Disable the Test and Copy buttons
                    InstallConnectionStringButton.Enabled = false;
                    TestButton.Enabled = false;
                    CopyButton.Enabled = false;
                }

                // Enable the ComboBox if the checkbox is checked.
                EncryptValueComboBox.Enabled = IncludeEncryptCheckBox.Checked;
            }
            #endregion

            #region WriteOutAppConfigText()
            /// <summary>
            /// This method returns the Out App Config Text
            /// </summary>
            public string WriteOutAppConfigText()
            {
                // initial value
                string appConfigText = "";

                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder();

                // If the AppConfigTextLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(AppConfigTextLines))
                {
                    // Iterate the collection of TextLine objects
                    foreach (TextLine textLine in AppConfigTextLines)
                    {
                        // write out this line
                        sb.Append(textLine.Text);

                        // Add a new line character
                        sb.Append(Environment.NewLine);
                    }

                    // set the return value
                    appConfigText = sb.ToString();
                }
                
                // return value
                return appConfigText;
            }
            #endregion
            
        #endregion

        #region Properties

            #region AppConfigPath
            /// <summary>
            /// This property gets or sets the value for 'AppConfigPath'.
            /// </summary>
            public string AppConfigPath
            {
                get { return appConfigPath; }
                set { appConfigPath = value; }
            }
            #endregion
            
            #region AppConfigTextLines
            /// <summary>
            /// This property gets or sets the value for 'AppConfigTextLines'.
            /// </summary>
            public List<TextLine> AppConfigTextLines
            {
                get { return appConfigTextLines; }
                set { appConfigTextLines = value; }
            }
            #endregion
            
            #region ConnectionInfo
            /// <summary>
            /// This property gets or sets the value for 'ConnectionInfo'.
            /// </summary>
            public ConnectionInfo ConnectionInfo
            {
                get { return connectionInfo; }
                set { connectionInfo = value; }
            }
            #endregion

            #region ConnectionString
            /// <summary>
            /// This read only property returns the ConnectionString from the ConnectionStringTextBox
            /// </summary>
            public string ConnectionString
            {
                get
                {
                    // initial value
                    string connectionString = ConnectionstringControl.Text;

                    // return value
                    return connectionString;
                }
            }
            #endregion
            
            #region ConnectionStringIndex
            /// <summary>
            /// This property gets or sets the value for 'ConnectionStringIndex'.
            /// </summary>
            public int ConnectionStringIndex
            {
                get { return connectionStringIndex; }
                set { connectionStringIndex = value; }
            }
            #endregion
            
            #region EncryptionKeyIndex
            /// <summary>
            /// This property gets or sets the value for 'EncryptionKeyIndex'.
            /// </summary>
            public int EncryptionKeyIndex
            {
                get { return encryptionKeyIndex; }
                set { encryptionKeyIndex = value; }
            }
            #endregion
            
            #region HasAppConfigPath
            /// <summary>
            /// This property returns true if the 'AppConfigPath' exists.
            /// </summary>
            public bool HasAppConfigPath
            {
                get
                {
                    // initial value
                    bool hasAppConfigPath = (!String.IsNullOrEmpty(this.AppConfigPath));
                    
                    // return value
                    return hasAppConfigPath;
                }
            }
            #endregion
            
            #region HasConnectionInfo
            /// <summary>
            /// This property returns true if this object has a 'ConnectionInfo'.
            /// </summary>
            public bool HasConnectionInfo
            {
                get
                {
                    // initial value
                    bool hasConnectionInfo = (this.ConnectionInfo != null);
                    
                    // return value
                    return hasConnectionInfo;
                }
            }
            #endregion
            
            #region HasConnectionStringIndex
            /// <summary>
            /// This property returns true if the 'ConnectionStringIndex' is set.
            /// </summary>
            public bool HasConnectionStringIndex
            {
                get
                {
                    // initial value
                    bool hasConnectionStringIndex = (this.ConnectionStringIndex > 0);
                    
                    // return value
                    return hasConnectionStringIndex;
                }
            }
            #endregion
            
            #region HasSetupCompleteIndex
            /// <summary>
            /// This property returns true if the 'SetupCompleteIndex' is set.
            /// </summary>
            public bool HasSetupCompleteIndex
            {
                get
                {
                    // initial value
                    bool hasSetupCompleteIndex = (this.SetupCompleteIndex > 0);
                    
                    // return value
                    return hasSetupCompleteIndex;
                }
            }
            #endregion
            
            #region IsAdministrator
            /// <summary>
            /// This read only property returns the value for 'IsAdministrator'.
            /// </summary>
            public static bool IsAdministrator
            {
                get
                {
                    var identity = WindowsIdentity.GetCurrent();
                    var principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }
            #endregion
            
            #region IsExecutableConfig
            /// <summary>
            /// This property gets or sets the value for 'IsExecutableConfig'.
            /// </summary>
            public bool IsExecutableConfig
            {
                get { return isExecutableConfig; }
                set { isExecutableConfig = value; }
            }
            #endregion
            
            #region SetupCompleteIndex
            /// <summary>
            /// This property gets or sets the value for 'SetupCompleteIndex'.
            /// </summary>
            public int SetupCompleteIndex
            {
                get { return setupCompleteIndex; }
                set { setupCompleteIndex = value; }
            }
            #endregion
            
            #region UseEncryptionIndex
            /// <summary>
            /// This property gets or sets the value for 'UseEncryptionIndex'.
            /// </summary>
            public int UseEncryptionIndex
            {
                get { return useEncryptionIndex; }
                set { useEncryptionIndex = value; }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
