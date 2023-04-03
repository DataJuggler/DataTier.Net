﻿

#region using statements

using DataJuggler.Net;
using DataJuggler.Net.Connection;
using System;
using System.Drawing;
using System.Windows.Forms;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using ConnectionBuilder.Enumerations;

#endregion

namespace ConnectionBuilder
{

    #region class ConnectionStringBuilderForm
    /// <summary>
    /// This class is used to build and test connection strings.
    /// </summary>
    public partial class ConnectionStringBuilderForm : Form, ICheckChangedListener, ITextChanged
    {
        
        #region Private Variables
        private const string ConnBuilderServerName = "ConnBuilderServerName";
        private ConnectionInfo connectionInfo;
        private bool formActivated;
        #endregion
        
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
                ConnectionInfo connectionInfo = this.CaptureConnectionInfo();
                
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
                    button.BackgroundImage = Properties.Resources.WoodButtonWidth640;
                }
                else
                {
                    // Setup Disabled button
                    button.ForeColor = Color.DarkGray;
                    button.BackgroundImage = Properties.Resources.WoodButtonWidth640Disabled;
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
                                  
            #region ConnectionStringBuilderForm_Activated(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Connection String Builder Form _ Activated
            /// </summary>
            private void ConnectionStringBuilderForm_Activated(object sender, EventArgs e)
            {
                // if the Form has not been activated yet
                if (!FormActivated)
                {
                    // Set the Server Name if set
                    DatabaseServerControl.Text = ConfigurationHelper.ReadAppSetting("ServerName");

                    // if there is Text
                    if (DatabaseServerControl.HasText)
                    {
                        // Change the focus to the DatabaseName
                        DatabaseNameControl.SetFocusToTextBox();
                    }
                }

                // Set to true
                FormActivated = true;
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
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // This will enable the check box if the IncludeEncryptCheckBox is checked, the
                // ComboBox for EncryptValue will become enabled.
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
                            this.StatusLabel.Text = "Database Connection Passed.";

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
                        MessageBox.Show("You must build or enter a connection string.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("TestDatabaseConnection_Click", this.Name, error);
                    
                    // Show a success message
                    MessageBox.Show("A connection to the database could not be estalished.", "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new instance of a 'ConnectionInfo' object.
                ConnectionInfo = new ConnectionInfo();

                // Default to SQL Server Authentication at First
                SQLServerAuthenticationRadioButton.Checked = true;

                // Setup the listeners                
                DatabaseServerControl.OnTextChangedListener = this;
                DatabaseNameControl.OnTextChangedListener = this;
                DatabaseUserControl.OnTextChangedListener = this;
                DatabasePasswordControl.OnTextChangedListener = this;
                ConnectionstringControl.OnTextChangedListener = this;
                IncludeEncryptCheckBox.CheckChangedListener = this;
                IncludeEncryptCheckBox.Checked = true;
                EncryptValueComboBox.LoadItems(typeof(TrueFalseEnum));
                EncryptValueComboBox.SelectedIndex = EncryptValueComboBox.FindItemIndexByValue("False");

                // This will set the name of the server if you have this set in the app.config
                DatabaseServerControl.Text = ConfigurationHelper.ReadAppSetting("ServerName");
                
                // Enable or disable controls
                UIControl();
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
                    TestDatabaseConnectionButton.Enabled = true;
                    CopyButton.Enabled = true;
                }
                else
                {
                      // Disable the Test and Copy buttons
                    TestDatabaseConnectionButton.Enabled = false;
                    CopyButton.Enabled = false;
                }

                // Enable the ComboBox if the checkbox is checked.
                EncryptValueComboBox.Enabled = IncludeEncryptCheckBox.Checked;
            }
        #endregion

        #endregion

        #region Properties

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
            
            #region FormActivated
            /// <summary>
            /// This property gets or sets the value for 'FormActivated'.
            /// </summary>
            public bool FormActivated
            {
                get { return formActivated; }
                set { formActivated = value; }
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

        #endregion

    }
    #endregion

}
