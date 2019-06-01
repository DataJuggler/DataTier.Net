
#region using statements

using ApplicationLogicComponent.Logging;
using ApplicationLogicComponent.Security;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

#endregion

namespace ApplicationLogicComponent.Connection
{

    #region class ApplicationConfigurationManager
    /// <summary>
    /// This class is used to read and store values 
    /// from the app.config file.
    /// </summary>
    public class ApplicationConfigurationManager
    {

        #region Private Variables
        private string applicationPassword;
        private string applicationUserName;
        private string connectionString;
        private string databasePath;
        private string databaseName;
        private string databasePassword;
        private string databaseServer;
        private string databaseUserName;
        private ErrorHandler errorProcessor;
        private bool logAsSystemEvent;
        private string logFileName;
        private bool logToFile;
        private bool savePassword;
        private bool integratedSecurity;
        private bool useEncryption;
        private string encryptionKey;
        XmlDocument xmlDoc;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a ApplicationConfigurationManager object.
        /// This object represents the values from the app.config file.
        /// The values will always be publicly unencrypted, but when you 
        /// save this file, the values are stored with encryption for security.
        /// </summary>
        public ApplicationConfigurationManager(ErrorHandler errorProcessorArg)
        {
            // Set ErrorProcessor
            this.ErrorProcessor = errorProcessorArg;

            // Startup 
            Init();
        }
        #endregion

        #region Methods

        #region Init()
        /// <summary>
        /// This method performs any startup functionality 
        /// required for this object.
        /// </summary>
        private void Init()
        {
            // Create Xml Doc
            this.XmlDoc = new XmlDocument();
        }
        #endregion

        #region AppConfigFileName()
        /// <summary>
        /// This method returns the path to the 
        /// </summary>
        /// <returns></returns>
        private string AppConfigFileName()
        {
            // get fileName
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "System\\App.config";

            // return value
            return fileName;
        }
        #endregion

        #region LoadConfigDocument()
        /// <summary>
        /// This method loads the app.config doc
        /// </summary>
        /// <returns></returns>
        private static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
        #endregion

        #region GetConfigFilePath()
        /// <summary>
        /// this method returns the location of the app.config file.
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFilePath()
        {
            // path to the app.config file.
            string configFilePath = Environment.CurrentDirectory + "\\System\\app.config";

            // return value
            return configFilePath;
        }
        #endregion

        #region KeyExists(string strKey)
        /// <summary>
        /// Determines if a key exists within the App.config
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            // initial value
            bool keyExists = false;

            // Get appSettingsNode
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            // verify appSettingsNode exists
            if (appSettingsNode != null)
            {
                // Attempt to locate the requested setting.
                foreach (XmlNode childNode in appSettingsNode)
                {
                    // Get name of this key (in lowercase)
                    string name = childNode.Attributes["key"].Value.ToLower();

                    // if this is the correct key
                    if (name == key.ToLower())
                    {
                        // set keyExists to true
                        keyExists = true;

                        // break out of for loop
                        break;
                    }
                }
            }

            // return value
            return keyExists;
        }
        #endregion

        #region Read()
        /// <summary>
        /// This method reads the app.config file and decrypts the values
        /// to load the properties for this object.
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            // initial value
            bool readSuccess = false;

            try
            {
                // There are two options for how to read the app.config or web.config values:
                // 
                // The preferrered way is now a connectionstring. 
                // 
                // Either a ConnectionString will be set
                // 
                // OR
                // 
                // For a SQL Server Authentication:
                // 
                //     Windows Authentication: Server Name, Database Name and IntegratedSecurity (True or false)
                //
                //     SQL Server Authentication: there are 2 extra values for a UserName and Password.

                // get the value for useEncryption
                string useEncryption = ConfigurationHelper.ReadAppSetting("UseEncryption");

                // Parse the value
                this.UseEncryption = BooleanHelper.ParseBoolean(useEncryption, false, false);

                // if UseEncryption is true
                if (this.UseEncryption)
                {
                    // Set the EncryptionKey
                    this.EncryptionKey = ConfigurationHelper.ReadAppSetting("EncryptionKey");
                }
                else
                {
                    // erase
                    this.EncryptionKey = String.Empty;
                }

                // Set the ConnectionString
                this.ConnectionString = ConfigurationHelper.ReadAppSetting("ConnectionString", UseEncryption, EncryptionKey);

                // if the connection string does not exist
                if (!this.HasConnectionString)
                {
                    // legacy code left in, you can use to build a connection string, 
                    // but the preferred method is a connectionstring

                    // Set the DatabaseServer
                    this.DatabaseServer = ConfigurationHelper.ReadAppSetting("DatabaseServer", UseEncryption, EncryptionKey);

                    // Read the app setting for the database name
                    this.DatabaseName = ConfigurationHelper.ReadAppSetting("DatabaseName", UseEncryption, EncryptionKey);

                    // Set the value for integrated security
                    this.IntegratedSecurity = BooleanHelper.ParseBoolean(ConfigurationHelper.ReadAppSetting("IntegratedSecurity", UseEncryption, EncryptionKey), false, false);

                    // if integrated security is true
                    if (!this.IntegratedSecurity)
                    {
                        // Set the DatabaseUserName
                        this.DatabaseUserName = ConfigurationHelper.ReadAppSetting("DatabaseUserName", UseEncryption, EncryptionKey);

                        // Set the DatabasePassword 
                        this.DatabasePassword = ConfigurationHelper.ReadAppSetting("DatabasePassword", UseEncryption, EncryptionKey);
                    }
                }

                // verify required variables are here
                if (this.IsValid)
                {
                    // set readSuccess to true
                    readSuccess = true;
                }
            }
            catch (Exception error)
            {
                // If ErrorProcessor exists
                if (this.ErrorProcessor != null)
                {
                    // locals
                    string methodName = "Read";
                    string objectName = "DataTier.Net.ApplicationLogicComponent.ApplicationConfigurationManager";

                    // Log the current error
                    this.ErrorProcessor.LogError(methodName, objectName, error);
                }
            }

            // return value
            return readSuccess;
        }
        #endregion

        #region UpdateKey(string key, string newValue)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        public void UpdateKey(string key, string newValue)
        {
            if (!KeyExists(key))
            {
                throw new ArgumentNullException("Key", "<" + key + "> does not exist in the configuration. Update failed.");
            }

            // Select appSettingsNode
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            // verify appSettingsNode exists
            if (appSettingsNode != null)
            {
                // Attempt to locate the requested setting.
                foreach (XmlNode childNode in appSettingsNode)
                {
                    // if this is the correct key
                    if (childNode.Attributes["key"].Value.ToString().ToLower() == key.ToLower())
                    {
                        // update value of this attribute
                        childNode.Attributes["value"].Value = newValue;

                        // break out of for loop
                        break;
                    }
                }
            }

            // Save the app.config file
            string fileName = AppConfigFileName();

            // verify fileName exists
            if (File.Exists(fileName))
            {
                // Save the app.config file.
                xmlDoc.Save(fileName);

                // update the current configuration settings
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            }


        }
        #endregion

        #region SaveLoginInformation(string applicationUserName, string applicationPassword, bool savePassword)
        /// <summary>
        /// This method saves the current settings back to the app.config file.
        /// </summary>
        public void SaveLoginInformation(string applicationUserName, string applicationPassword, bool savePassword)
        {
            // first check if save password is true or not
            if (!savePassword)
            {
                // set password to null
                applicationPassword = null;
            }

            // Encrypt Each Property
            string encryptedPassword = CryptographyManager.EncryptString(applicationPassword);
            string encryptedUserName = CryptographyManager.EncryptString(applicationUserName);
            string encryptedSavePassword = CryptographyManager.EncryptString(savePassword.ToString());

            // Save Login Information
            this.UpdateKey("ApplicationPassword", encryptedPassword);
            this.UpdateKey("ApplicationUserName", encryptedUserName);
            this.UpdateKey("SavePassword", encryptedSavePassword);
        }
        #endregion

        #region Validate()
        /// <summary>
        /// This method returns true if the ConnectionString is set or the values for DatabaseServer,
        /// DatabaseName and optionally DatabaseUserName and Password  are set
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            // initial value
            bool valid = false;

            // if we have a connection string this object is valid
            if (this.HasConnectionString)
            {
                // set to true
                valid = true;
            }
            else
            {
                // locals
                bool hasServerName = (!String.IsNullOrEmpty(this.DatabaseServer));
                bool hasDatabaseName = (!String.IsNullOrEmpty(this.DatabaseName));

                // If integrated security is set to true
                if (this.IntegratedSecurity)
                {
                    // SQL Server Authentication

                    // this is valid if all of these are true
                    valid = ((hasServerName) && (hasDatabaseName));
                }
                else
                {
                    // SQL Server Authentication

                    // UserName & Password are required for SQL Server Authentication
                    bool hasUserName = (!String.IsNullOrEmpty(this.DatabaseUserName));
                    bool hasPassword = (!String.IsNullOrEmpty(this.DatabasePassword));

                    // this is valid if all of these are true
                    valid = ((hasServerName) && (hasUserName) && (hasDatabaseName) && (hasPassword));
                }
            }

            // return value
            return valid;
        }
        #endregion

        #endregion

        #region Properties

        #region ApplicationPassword
        /// <summary>
        /// This userToSubject's password.
        /// </summary>
        public string ApplicationPassword
        {
            get { return applicationPassword; }
            set { applicationPassword = value; }
        }
        #endregion

        #region ApplicationUserName
        /// <summary>
        /// This userToSubject's login name.
        /// </summary>
        public string ApplicationUserName
        {
            get { return applicationUserName; }
            set { applicationUserName = value; }
        }
        #endregion

        #region ConnectionString
        /// <summary>
        /// This property gets or sets the value for 'ConnectionString'.
        /// </summary>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        #endregion

        #region DatabaseName
        /// <summary>
        /// The name of the database to connect to.
        /// </summary>
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        #endregion

        #region DatabasePassword
        /// <summary>
        /// The password for the database.
        /// </summary>
        public string DatabasePassword
        {
            get { return databasePassword; }
            set { databasePassword = value; }
        }
        #endregion

        #region DatabasePath
        /// <summary>
        /// The database path when connecting to an Access databases.
        /// </summary>
        public string DatabasePath
        {
            get { return databasePath; }
            set { databasePath = value; }
        }
        #endregion

        #region DatabaseServer
        /// <summary>
        /// The server that this database resides on.
        /// </summary>
        public string DatabaseServer
        {
            get { return databaseServer; }
            set { databaseServer = value; }
        }
        #endregion

        #region DatabaseUserName
        /// <summary>
        /// The userToSubject name for this SQL login.
        /// </summary>
        public string DatabaseUserName
        {
            get { return databaseUserName; }
            set { databaseUserName = value; }
        }
        #endregion

        #region EncryptionKey
        /// <summary>
        /// This property gets or sets the value for 'EncryptionKey'.
        /// </summary>
        public string EncryptionKey
        {
            get { return encryptionKey; }
            set { encryptionKey = value; }
        }
        #endregion

        #region ErrorProcessor
        /// <summary>
        /// This property handles how errors will be "logged"
        /// within this application.
        /// </summary>
        public ErrorHandler ErrorProcessor
        {
            get { return errorProcessor; }
            set { errorProcessor = value; }
        }
        #endregion

        #region HasConnectionString
        /// <summary>
        /// This property returns true if the 'ConnectionString' exists.
        /// </summary>
        public bool HasConnectionString
        {
            get
            {
                // initial value
                bool hasConnectionString = (!String.IsNullOrEmpty(this.ConnectionString));

                // return value
                return hasConnectionString;
            }
        }
        #endregion

        #region IntegratedSecurity
        /// <summary>
        /// This property gets or sets the value for 'IntegratedSecurity'.
        /// </summary>
        public bool IntegratedSecurity
        {
            get { return integratedSecurity; }
            set { integratedSecurity = value; }
        }
        #endregion

        #region IsValid
        /// <summary>
        /// This property calls the 'Validation()' 
        /// method to test if all required fields 
        /// are filled in.
        /// </summary>
        public bool IsValid
        {
            get
            {
                // initial value
                bool isValid = this.Validate();

                // return value
                return isValid;
            }
        }
        #endregion

        #region LogAsSystemEvent
        /// <summary>
        /// Indicates if errors are logged as System Events.
        /// </summary>
        public bool LogAsSystemEvent
        {
            get { return logAsSystemEvent; }
            set { logAsSystemEvent = value; }
        }
        #endregion

        #region LogFileName
        /// <summary>
        /// The full path to the filename 
        /// errors should be logged to.
        /// </summary>
        public string LogFileName
        {
            get { return logFileName; }
            set { logFileName = value; }
        }
        #endregion

        #region LogToFile
        /// <summary>
        /// Indicates if errors should
        /// be logged to a file or not.
        /// </summary>
        public bool LogToFile
        {
            get { return logToFile; }
            set { logToFile = value; }
        }
        #endregion

        #region SavePassword
        /// <summary>
        /// Should the password be saved in the app.config file
        /// (encrypted of course).
        /// </summary>
        public bool SavePassword
        {
            get { return savePassword; }
            set { savePassword = value; }
        }
        #endregion

        #region UseEncryption
        /// <summary>
        /// This property gets or sets the value for 'UseEncryption'.
        /// </summary>
        public bool UseEncryption
        {
            get { return useEncryption; }
            set { useEncryption = value; }
        }
        #endregion

        #region XmlDoc
        /// <summary>
        /// The Xml document that opens the App.Config file.
        /// </summary>
        public XmlDocument XmlDoc
        {
            get { return xmlDoc; }
            set { xmlDoc = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}

