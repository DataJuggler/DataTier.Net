
#region using statements

using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.Data;
using DataAccessComponent.Logging;
using DataAccessComponent.Exceptions;
using DataAccessComponent.Controllers;

#endregion

namespace DataAccessComponent.Connection
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
        private ErrorHandler errorProcessor;
        private ApplicationController parentController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a AuthenticationManager
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
                string objectName = "AuthenticationManager";

                try
                {   
                    // If connection is not set 
                    if(String.IsNullOrEmpty(dataManager.DataConnector.ConnectionString))
                    {
                        // if the connectionName is set
                        if (TextHelper.Exists(dataManager.ConnectionName))
                        {
                            // Set the ConnectionString (requires DataJuggler.UltimateHelper version 7.1 or higher)
                            dataManager.DataConnector.ConnectionString = EnvironmentVariableHelper.GetEnvironmentVariableValue(dataManager.ConnectionName, EnvironmentVariableTarget.User);
                        }
                    }
                    
                    // check if database is already connected
                    if (dataManager.DataConnector.State == System.Data.ConnectionState.Open)
                    {
                        // close connection and reopen (there should not be any open connections here)
                        // I have been thinking of a bulk insert feature in the future, but that is not for this method
                        // To Do: Log Error 'Database Connection Was Already Open'
                        dataManager.DataConnector.Close();
                    }
                   
					// Open Connection
					dataManager.DataConnector.Open();
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log this error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
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
               
            }
            #endregion

        #endregion

        #region Properties

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
