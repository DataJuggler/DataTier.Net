

#region using statements

using System;
using System.Windows.Forms;
using DataTierClient.ClientUtil;
using DataTierClient.Forms;
using DataTierClient.Enumerations;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataTierClient.Controls.Interfaces;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataTierClient.Controls
{

    #region class SQLDatabaseEditor : UserControl, ITabButtonParent
    /// <summary>
    /// This class is used to Register a SQLDatabase with this project.
    /// </summary>
    public partial class SQLDatabaseEditor : UserControl, ITabButtonParent, ICheckChangedListener, ISelectedIndexListener
    {
    
        #region Private Variables
        private SQLAuthenticationTypeEnum authenticationType;
        #endregion
    
        #region Constructor
        /// <summary>
        /// Create a new instance of a SQLDatabaseEditor.
        /// </summary>
        public SQLDatabaseEditor()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this control
            Init();
        }
        #endregion

        #region Events

            #region BrowseDatabaseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Browse Databases Button
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseDatabaseButton_Click(object sender, EventArgs e)
            {
                // Browse For Databases
                BrowseDatabases();    
            }
            #endregion

            #region BrowseServerButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The BrowseServerButton was clicked. Display a list of servers.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BrowseServerButton_Click(object sender, EventArgs e)
            {               
                // Browse Servers
                BrowseServers();   
            }
            #endregion

            #region ConnectionStringTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Connection String Text Box _ Text Changed
            /// </summary>
            private void ConnectionStringTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the ParentDatabaseEditor exists
                if (this.HasParentDatabaseEditor)
                {
                    // do we have a connection string
                    bool hasConnectionString = (!String.IsNullOrEmpty(this.ConnectionStringTextBox.Text));

                    // Enable the save button if we have a connection string
                    this.ParentDatabaseEditor.EnableSaveButton(hasConnectionString);
                }
            }
            #endregion
            
            #region DatabasesComboBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the SelectedDatabase Changes.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DatabasesComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Build Connection String
                BuildConnectionString();
            }
            #endregion

            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // Enable the ComboBox if IncludeEncryptCheckBox is checked
                EncryptValueComboBox.Enabled = isChecked;

                // Update the ConnectionString
                BuildConnectionString();
            }
            #endregion
            
            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            /// <summary>
            /// event is fired when a selection is made in the 'On'.
            /// </summary>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // Build the ConnectionString
                BuildConnectionString();
            }
            #endregion
            
            #region PasswordTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The Password Has Changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void PasswordTextBox_TextChanged(object sender, EventArgs e)
            {
                // Build Connection String
                BuildConnectionString();
            }
            #endregion

            #region ServerTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The ServerTextBox has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ServerTextBox_TextChanged(object sender, EventArgs e)
            {
                // Build ConnectionString
                string buildConnectionString = BuildConnectionString();
            }
            #endregion

            #region SQLRadioButton_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// sql Server Authentication Is Selected.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SQLRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                // If sql Server Radio Button is checked.
                if(this.SQLServerRadioButton.Checked)
                {
                    // sql Server Authentication
                    this.AuthenticationType = SQLAuthenticationTypeEnum.SQLServerAuthentication;

                    // Build ConnectionString
                    BuildConnectionString();

                    // Enable Controls
                    UIEnable();
                }
            } 
            #endregion

            #region SQLUserNameTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The sql Username for sql Server Authentication.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SQLUserNameTextBox_TextChanged(object sender, EventArgs e)
            {
                // Build Connection String
                BuildConnectionString();
            }
            #endregion

            #region WindowsRadioButton_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// Windows Authentication Is Selected
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WindowsRadioButton_CheckedChanged(object sender, EventArgs e)
            {
                // if WindowsRadioButton is checked.
                if(WindowsRadioButton.Checked)
                {
                    // Use Windows Authentication
                    this.AuthenticationType = SQLAuthenticationTypeEnum.WindowsAuthentication;

                    // Build ConnectionString
                    BuildConnectionString();
                    
                    // Enable Controls
                    UIEnable();
                }
            } 
            #endregion
        
        #endregion
        
        #region Methods

            #region BrowseDatabases()
            /// <summary>
            /// This method browses for databases.
            /// </summary>
            private void BrowseDatabases()
            {
                try
                {
                    // 7.17.2019: Clear the list before adding again else it adds twice I found out today
                    // funny this control has been here for 12 years or more.
                    this.DatabasesComboBox.Items.Clear();

                    // locals
                    string serverName = this.ServerTextBox.Text.ToString();

                    // if the parent form exists
                    if (this.ParentForm != null)
                    {
                        // turn on the hourglass
                        this.ParentForm.Cursor = Cursors.WaitCursor;
                    }
                    
                    // Get Databases
                    SQLSMOHelper.GetDatabases(serverName, this.DatabasesComboBox);
                }
                catch (Exception error)
                {
                    // for debugging only or show a message if you want
                    string err = error.ToString();
                }
                finally
                {
                    // if the parent form exists
                    if (this.ParentForm != null)
                    {
                        // turn hourglass off
                        this.ParentForm.Cursor = Cursors.Default;
                    }
                }
            }
            #endregion

            #region BrowseServers()
            /// <summary>
            /// Browse all servers
            /// </summary>
            private void BrowseServers()
            {
                try
                {
                    // turn the hourglass on
                    this.Cursor = Cursors.WaitCursor;
                    
                    // Launch Select Server Form
                    SelectSQLServerForm selectSQLForm = new SelectSQLServerForm();

                    // Set the text box
                    selectSQLForm.SelectSQLServerControl.Setup(this.ServerTextBox);

                    // Show Dialog
                    selectSQLForm.ShowDialog();
                }
                catch (Exception error)
                {
                    // For debugging only
                    string err = error.ToString();

                    // Show a message to the user
                    MessageHelper.DisplayMessage("An error occurred detecting SQL Servers on your network", "SQL Servers Unavailable");
                }
                finally
                {
                    // Revert the cursor back
                    this.Cursor = Cursors.Default;
                }
            }
            #endregion

            #region BuildConnectionString()
            /// <summary>
            /// This method builds a connection string
            /// </summary>
            /// <returns></returns>
            private string BuildConnectionString()
            {
                // locals
                string serverName = this.ServerTextBox.Text.ToString();
                string userName = this.SQLUserNameTextBox.Text.ToString();
                string password = this.PasswordTextBox.Text.ToString();
                string databaseName = "";
                
                // if there is a selected item
                if(this.DatabasesComboBox.SelectedItem != null)
                {
                    // set databaseName
                    databaseName = this.DatabasesComboBox.SelectedItem.ToString();
                }
                
                // local for ConnectionString
                string connectionString = "";
                
                // if windows authentication is used
                if(this.AuthenticationType == SQLAuthenticationTypeEnum.WindowsAuthentication)
                {
                    // create a windows connection string
                    connectionString = BuildWindowsConnectionString(serverName, databaseName);
                }
                else
                {
                    // get the connectionString
                    connectionString = BuildSQLConnectionString(serverName, databaseName, userName, password);
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

                // create the connection string
                this.ConnectionStringTextBox.Text = connectionString;
                
                // return value
                return connectionString;
            }
            #endregion

            #region BuildSQLConnectionString()
            /// <summary>
            /// This method builds a SQLConnectionString
            /// </summary>
            /// <returns></returns>
            private string BuildSQLConnectionString(string serverName, string databaseName, string userID, string password)
            {
                // initial value
                string connectString = "";
                
                // Create Connector
                DataJuggler.Net.SQLDatabaseConnector sqlConnector = new DataJuggler.Net.SQLDatabaseConnector();
                
                // connectString
                connectString = sqlConnector.BuildConnectionString(serverName, databaseName, userID, password);
                
                // return value
                return connectString;
            }
            #endregion

            #region BuildWindowsConnectionString(string serverName, string databaseName)
            /// <summary>
            /// This method builds a WindowsConnection String
            /// </summary>
            /// <param name="serverName"></param>
            /// <param name="databaseName"></param>
            /// <returns></returns>
            private string BuildWindowsConnectionString(string serverName, string databaseName)
            {
                // Create SQLDatabaseConnector
                DataJuggler.Net.SQLDatabaseConnector sqlConnector = new DataJuggler.Net.SQLDatabaseConnector();
                
                // Build a connectionString
                string connectString = sqlConnector.BuildConnectionString(serverName, databaseName);
                
                // return value
                return connectString;
            }
            #endregion

            #region CaptureSelectedDatabase
            /// <summary>
            /// This method captures the selected database.
            /// </summary>
            internal void CaptureSelectedDatabase()
            {
                // if the selected database existg
                if(this.SelectedDatabase != null)
                {
                    // set properties
                    this.SelectedDatabase.ServerName = this.ServerTextBox.Text.ToString();                    
                    this.SelectedDatabase.AuthenticationType = (int) this.AuthenticationType;
                    
                    // only capture the UserID and password if this is SQLServerAuthentication
                    if(this.AuthenticationType == SQLAuthenticationTypeEnum.SQLServerAuthentication)
                    {
                        // get userId
                        this.SelectedDatabase.UserId = this.SQLUserNameTextBox.Text.ToString();
                        
                        // get password
                        this.SelectedDatabase.DBPassword = this.PasswordTextBox.Text.ToString();
                    }                    
                    
                    // if there is a selected item
                    if(this.DatabasesComboBox.SelectedItem != null)
                    {
                        // set database
                        string databaseName = this.DatabasesComboBox.SelectedItem.ToString();
                        
                        // if the database name exists
                        if(!String.IsNullOrEmpty(databaseName))
                        {
                            // get the name
                            this.SelectedDatabase.DatabaseName = databaseName;
                        }
                    }
                    
                    // Set ConnectionString
                    this.SelectedDatabase.ConnectionString = this.ConnectionStringTextBox.Text.ToString();
                    
                    // Set Serializable
                    this.SelectedDatabase.Serializable = this.SerializableCheckBox.Checked;
                }   
            }
            #endregion

            #region DisplaySelectedDatabase()
            /// <summary>
            /// This method displays the values for the selected database
            /// </summary>
            internal void DisplaySelectedDatabase()
            {
                // locals
                string serverName = "";
                string password = "";
                string databaseName = "";
                string userID = "";
                string connectionString = "";
                bool serializable = false;
                bool windowsAuthentication = true;
                
                // if the selected database exists
                if (this.HasSelectedDatabase)
                {
                    // Set locals from SelectedDatabase values
                    serverName = this.SelectedDatabase.ServerName;
                    password = this.SelectedDatabase.DBPassword;
                    userID = this.SelectedDatabase.UserId;
                    databaseName = this.SelectedDatabase.DatabaseName;
                    connectionString = this.SelectedDatabase.ConnectionString;
                    serializable = this.SelectedDatabase.Serializable;
                    
                    // Set the Authentication Type
                    if(this.SelectedDatabase.AuthenticationType == (int) SQLAuthenticationTypeEnum.SQLServerAuthentication)
                    {
                        // Set windows to false
                        windowsAuthentication = false;
                    }
                }

                // Display values now
                this.ServerTextBox.Text = serverName;
                this.SQLUserNameTextBox.Text = userID;
                this.PasswordTextBox.Text = password;
                this.DatabasesComboBox.Text = databaseName;
                this.ConnectionStringTextBox.Text = connectionString;
                
                // if use Windows
                if(windowsAuthentication)
                {
                    // Check the Windows Authentication
                    this.WindowsRadioButton.Checked = true;
                }
                else
                {
                    // user sql Server
                    this.SQLServerRadioButton.Checked = true;
                }
                
                // set Serializable
                this.SerializableCheckBox.Checked = serializable;

                // Refresh 
                this.Refresh();
            } 
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this control. 
            /// </summary>
            private void Init()
            {
                // Default To Windows Being Checked
                WindowsRadioButton.Checked = true;
                
                // Set Serializable to true
                SerializableCheckBox.Checked = true;

                // Enable by default
                EncryptValueComboBox.Enabled = true;

                // Load the items
                EncryptValueComboBox.LoadItems(typeof(TrueFalseEnum));

                // Select False
                EncryptValueComboBox.SelectedIndex = EncryptValueComboBox.FindItemIndexByValue("False");

                // Setup the Listeners
                EncryptValueComboBox.SelectedIndexListener = this;
                IncludeEncryptCheckBox.CheckChangedListener = this;
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

                        // if the ButtonNumber is 1
                        if (tabButton.ButtonNumber == 1)
                        {
                            // call the BrowseServerButton_Click
                            BrowseServerButton_Click(this, null);
                        }
                        // if the ButtonNumber is 2
                        else if (tabButton.ButtonNumber == 2)
                        {
                            // call the BrowseDatabaseButton_Click
                            BrowseDatabaseButton_Click(this, null);
                        }

                        // required
                        break;
                }
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method enables controls based on the context values
            /// </summary>
            private void UIEnable()
            {
                // local
                bool enable = this.AuthenticationType == SQLAuthenticationTypeEnum.SQLServerAuthentication;
                
                // enable controls
                this.SQLUserNameTextBox.Enabled = enable;
                this.PasswordTextBox.Enabled = enable;
                
                // Refresh
                this.Refresh();
            }
        #endregion

        #endregion

        #region Properties

        #region AuthenticationType
        /// <summary>
        /// This property is used to set the type of Authentication 
        /// used.
        /// </summary>
        public SQLAuthenticationTypeEnum AuthenticationType
            {
                get { return authenticationType; }
                set { authenticationType = value; }
            }
            #endregion
            
            #region HasParentDatabaseEditor
            /// <summary>
            /// Does this object have a ParentDatabaseEditor.
            /// </summary>
            public bool HasParentDatabaseEditor
            {
                get
                {
                    // initial value
                    bool hasParentDatabaseEditor = (this.ParentDatabaseEditor != null);
                    
                    // return vlaue
                    return hasParentDatabaseEditor;
                }
            }
            #endregion

            #region HasParentDatabaseSelectorForm
            /// <summary>
            /// This property returns true if this object has a 'ParentDatabaseSelectorForm'.
            /// </summary>
            public bool HasParentDatabaseSelectorForm
            {
                get
                {
                    // initial value
                    bool hasParentDatabaseSelectorForm = (this.ParentDatabaseSelectorForm != null);
                    
                    // return value
                    return hasParentDatabaseSelectorForm;
                }
            }
            #endregion
            
            #region HasSelectedDatabase
            /// <summary>
            /// Does the selected database exist?
            /// </summary>
            public bool HasSelectedDatabase
            {
                get
                {
                    // initial value
                    bool hasSelectedDatabase = (this.SelectedDatabase != null);

                    // return value
                    return hasSelectedDatabase;
                }
            }
            #endregion
            
            #region ParentDatabaseEditor
            /// <summary>
            /// The Parent Control for this control.
            /// </summary>
            internal DatabaseSelectorControl ParentDatabaseEditor
            {
                get
                {
                    // initial value
                    DatabaseSelectorControl parentDatabaseEditor = this.Parent as DatabaseSelectorControl;
                    
                    // return value
                    return parentDatabaseEditor;
                }
            }
            #endregion

            #region ParentDatabaseSelectorForm
            /// <summary>
            /// This read only property returns the value for 'ParentDatabaseSelectorForm'.
            /// </summary>
            public DatabaseSelectorForm ParentDatabaseSelectorForm
            {
                get
                {
                    // initial value
                    DatabaseSelectorForm parentDatabaseSelectorForm = this.ParentForm as DatabaseSelectorForm;

                    // return value
                    return parentDatabaseSelectorForm;
                }
            }
            #endregion
            
            #region SelectedDatabase
            /// <summary>
            /// The selected database being created or edited.
            /// </summary>
            public DTNDatabase SelectedDatabase
            {
                get
                {
                    // initial value
                    DTNDatabase selectedDatabase = null;

                    // if the parent exists
                    if(this.HasParentDatabaseEditor)
                    {
                        // get the selected database
                        selectedDatabase = this.ParentDatabaseEditor.SelectedDatabase;
                    }

                    // return value
                    return selectedDatabase;
                }
            }
            #endregion
            
        #endregion
                
    }
    #endregion
    
}
