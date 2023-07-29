
#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.DataManager;
using ApplicationLogicComponent.Logging;
using ApplicationLogicComponent.Exceptions;
using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.Security;

#endregion

namespace ApplicationLogicComponent.Connection
{

    #region AuthenticationManager
    /// <summary>
    /// This class handles reading the app.config file,
    /// connecting to the database and validating the
    /// user's username / password.
    /// </summary>
    public class AuthenticationManager
    {

        #region Private Variables
        private ApplicationConfigurationManager configuration;
        private ErrorHandler errorProcessor;
        private ApplicationController parentController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a LoginManager
        /// </summary>
        public AuthenticationManager(ErrorHandler errorProcessorArg, ApplicationController parentControllerArg)
        {
            // Set Properties
            this.ErrorProcessor = errorProcessorArg;
            this.ParentController = parentControllerArg;

            // Perform Initializations
            Init();
        }
        #endregion

        #region Methods

        #region ConnectToDatabase(DataManager dataManager)
        /// <summary>
        /// This method reads the app.config file to 
        /// load the current configuration.
        /// </summary>
        /// <returns></returns>
        public void ConnectToDatabase(DataManager dataManager)
        {
            // locals
            string methodName = "ConnectToDatabase";
            string objectName = "LoginManager";

            // Create variable for a possible CustomException
            CustomException exception = null;

            try
            {
                // If connection is not set 
                if (String.IsNullOrEmpty(dataManager.DataConnector.ConnectionString))
                {
                    // Update: 3.1.2022: Shifting to EnvironmentVariables for release version. Might shift all, but legacy app.configs need to be kept (maybe)
                    dataManager.DataConnector.ConnectionString = EnvironmentVariableHelper.GetEnvironmentVariableValue("DataTierNetConnection", EnvironmentVariableTarget.User);
                }
                    
                // Test again, if the EnvironmentVariable is not set, use app.config
                if (String.IsNullOrEmpty(dataManager.DataConnector.ConnectionString))
                {  
                    // Read Configuration File
                    this.Configuration.Read();

                    // If the configuration is valid
                    if (this.Configuration.IsValid)
                    {
                        // if the ConnectionString exists
                        if (this.Configuration.HasConnectionString)
                        {
                            // Set the connection string using Integrated Secrity (Windows Authentication)
                            dataManager.DataConnector.ConnectionString = this.Configuration.ConnectionString;
                        }
                        else
                        {
                            // set the server
                            string serverName = this.Configuration.DatabaseServer;

                            // set the databaseName
                            string databaseName = this.Configuration.DatabaseName;

                            // If integrated security is set to true
                            if (this.Configuration.IntegratedSecurity)
                            {
                                // Set the connection string using Integrated Secrity (Windows Authentication)
                                dataManager.DataConnector.ConnectionString = dataManager.DataConnector.BuildConnectionString(serverName, databaseName);
                            }
                            else
                            {
                                // set the userName
                                string userName = this.Configuration.DatabaseUserName;

                                // set the password
                                string password = this.Configuration.DatabasePassword;

                                // build the connectionstring for Sql Server Authentication
                                dataManager.DataConnector.ConnectionString = dataManager.DataConnector.BuildConnectionString(serverName, databaseName, userName, password);
                            }
                        }
                    }
                }

                // check if database is already connected
                if (dataManager.DataConnector.State == System.Data.ConnectionState.Open)
                {
                    // close connection and reopen (there should not be any open connection here.
                    // To Do: Log Error 'Database Connection Was Already Open'
                    dataManager.DataConnector.Close();
                }

                // if the connection string has been set
                if (!String.IsNullOrEmpty(dataManager.DataConnector.ConnectionString))
                {
                    // Open Connection
                    dataManager.DataConnector.Open();
                }
            }
            catch (Exception error)
            {
                // If ErrorProcessor exists
                if (this.ErrorProcessor != null)
                {
                    // Only create a new configuration error if it does not already exist.
                    if (error as CustomException == null)
                    {
                        // If the configuration is not valid
                        if (!this.Configuration.IsValid)
                        {
                            // Create Instance of configurationError
                            exception = new InvalidConfigurationException(methodName, objectName, error);
                        }
                        else
                        {
                            // Create Instance of dataConnectionError
                            exception = new DataConnectionFailedException(methodName, objectName, error);
                        }
                    }

                    // Log this error
                    this.ErrorProcessor.LogError(methodName, objectName, exception);
                }
            }
        }
        #endregion

        #region Init()
        /// <summary>
        /// Perform Initializations
        /// </summary>
        private void Init()
        {
            // Create Configuration Object
            this.Configuration = new ApplicationConfigurationManager(this.ErrorProcessor);
        }
        #endregion

        #endregion

        #region Properties

        #region Configuration
        /// <summary>
        /// The current configuration settings.
        /// </summary>
        public ApplicationConfigurationManager Configuration
        {
            get { return configuration; }
            set { configuration = value; }
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

        #region ParentController
        /// <summary>
        /// This property is a reference to the parent that created this object.
        /// The need for this object is to be able to call the 
        /// </summary>
        public ApplicationController ParentController
        {
            get { return parentController; }
            set { parentController = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
