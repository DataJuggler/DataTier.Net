

#region using statements

using DataAccessComponent.Connection;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using System;
using System.Collections.Generic;
using DataAccessComponent.Logging;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ApplicationController
    /// <summary>
    /// This class controls program flow and 
    /// application status.
    /// </summary>
    public class ApplicationController
    {

        #region Private Variables
        private string connectionString;
        private bool connectionTested;        
        private AuthenticationManager loginManager;        
        private SystemController systemController;
        private DataBridgeManager dataBridge;
        private Exception exception;
        private string connectionName;
        #endregion

        #region Constructors

            #region Default Constructor
            /// <summary>
            /// Creates a new ApplicationController object.
            /// </summary>
            public ApplicationController(string connectionName = "")
            {
                // store the arg
                ConnectionName = connectionName;

                // Perform Initializations
                Init();
            }
            #endregion

        #endregion

        #region Delegates
        /// <summary>
        /// Delegate (method pointer) to the ShowUserMethod located in the client application.
        /// </summary>
        /// <param name="exception"></param>
        public delegate PolymorphicObject DataOperationMethod(List<PolymorphicObject> parameters, DataConnector dataConnector);
        public delegate PolymorphicObject DataOperationMethodEx(List<PolymorphicObject> parameters, DataConnector dataConnector);
        #endregion

        #region Methods

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            public DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the DataBridge exists
                if (HasDataBridge)
                {
                    // return the DataConnector from the DataBridge
                    dataConnector = DataBridge.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region bool TestDatabaseConnection(ref Exception error, DataManager dataManager)
            /// <summary>
            /// Connect to the database
            /// </summary>
            public bool TestDatabaseConnection(ref Exception error, DataManager dataManager)
            {
                // Initial value
                ConnectionTested = false;

                try
                {
                    // Test Data Connection
                    ConnectionTested = SystemController.TestDatabaseConnection(dataManager);
                }
                catch (Exception exception)
                {
                    // Log the error
                    dataManager.ErrorHandler.LogError("TestDatabaseConnection", "ApplicationController", exception);
                }

                // return value
                return ConnectionTested;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform any initializations needed.
            /// </summary>
            private void Init()
            {
                // Create AuthenticationManager
                LoginManager = new AuthenticationManager();

                // Create DataBridgeManager object (needed for child controllers).
                DataBridge = new DataBridgeManager(LoginManager, ConnectionName);

                // Create System Controller
                SystemController = new SystemController(DataBridge);
            }
            #endregion

        #endregion

        #region Properties

            #region AuthenticationManager
            /// <summary>
            /// This class handles reading the app.config file,
            /// connecting to the database and validating the
            /// user's username / password. 
            /// </summary>
            public AuthenticationManager LoginManager
            {
                get { return loginManager; }
                set { loginManager = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region ConnectionString
            /// <summary>
            /// The connection string to use to 
            /// connect to the database.
            /// </summary>
            public string ConnectionString
            {
                get { return connectionString; }
                set { connectionString = value; }
            }
            #endregion

            #region ConnectionTested
            /// <summary>
            /// Did this dataase connection pass the connection
            /// test during startup initialization.
            /// </summary>
            public bool ConnectionTested
            {
                get { return connectionTested; }
                set { connectionTested = value; }
            }
            #endregion

            #region DataBridge
            /// <summary>
            /// This object is the gateway to the data.
            /// </summary>
            public DataBridgeManager DataBridge
            {
                get { return dataBridge; }
                set { dataBridge = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// This read only property returns the value of DataManager from the object DataBridge.
            /// </summary>
            public DataManager DataManager
            {

                get
                {
                    // initial value
                    DataManager dataManager = null;

                    // if DataBridge exists
                    if (DataBridge != null)
                    {
                        // set the return value
                        dataManager = DataBridge.DataManager;
                    }

                    // return value
                    return dataManager;
                }
            }
            #endregion

            #region Exception
            /// <summary>
            /// The last exception from the App Controller when executing
            /// a data operation.
            /// </summary>
            public Exception Exception
            {
                get
                {
                    // initial value
                    if (exception == null)
                    {
                        // Set the exception
                        exception = DataBridge.Exception;
                    }

                    // return value
                    return exception;
                }
                set
                {
                    // set the value
                    exception = value;

                    // Set the Databride exception
                    DataBridge.Exception = value;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion

            #region HasDataBridge
            /// <summary>
            /// This property returns true if this object has a 'DataBridge'.
            /// </summary>
            public bool HasDataBridge
            {
                get
                {
                    // initial value
                    bool hasDataBridge = (DataBridge != null);
                    
                    // return value
                    return hasDataBridge;
                }
            }
            #endregion

            #region HasDataManager
            /// <summary>
            /// This property returns true if this object has a 'DataManager'.
            /// </summary>
            public bool HasDataManager
            {
                get
                {
                    // initial value
                    bool hasDataManager = (DataManager != null);

                    // return value
                    return hasDataManager;
                }
            }
            #endregion

            #region SystemController
            /// <summary>
            /// The System Controller For This App.
            /// This is not a code generated controller.
            /// </summary>
            public SystemController SystemController
            {
                get { return systemController; }
                set { systemController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}