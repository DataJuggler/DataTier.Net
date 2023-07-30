

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.DataManager;
using ApplicationLogicComponent.Logging;
using ApplicationLogicComponent.Connection;
using ApplicationLogicComponent.Exceptions;
using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Controllers;
using ObjectLibrary.BusinessObjects;

#endregion


namespace ApplicationLogicComponent.Controllers
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
        private ErrorHandler errorProcessor;
        private AuthenticationManager loginManager;
        private ControllerManager controllerManager;
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
                this.ConnectionName = connectionName;

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
                if (this.HasDataBridge)
                {
                    // return the DataConnector from the DataBridge
                    dataConnector = this.DataBridge.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region bool TestDatabaseConnection(ref Exception error)
            /// <summary>
            /// Connect to the database
            /// </summary>
            public bool TestDatabaseConnection(ref Exception error)
            {
                // Initial value
                this.ConnectionTested = false;

                try
                {
                    // Test Data Connection
                    this.ConnectionTested = this.SystemController.TestDatabaseConnection();
                }
                catch (Exception exception)
                {
                    // Set the error
                    error = exception;
                }

                // return value
                return this.ConnectionTested;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform any initializations needed.
            /// </summary>
            private void Init()
            {
                // Create Error Processor
                this.ErrorProcessor = new ErrorHandler();

                // Create AuthenticationManager
                this.LoginManager = new AuthenticationManager(this.ErrorProcessor, this);

                // Create DataBridgeManager object (needed for child controllers).
                this.DataBridge = new DataBridgeManager(this.LoginManager, this.ErrorProcessor, this.ConnectionName);

                // Create ControllerManager
                this.ControllerManager = new ControllerManager(this.ErrorProcessor, this);

                // Create System Controller
                this.SystemController = new SystemController(this.DataBridge, this.ErrorProcessor);
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

            #region ControllerManager
            /// <summary>
            /// This object manages all of the 
            /// object controllers.
            /// </summary>
            public ControllerManager ControllerManager
            {
                get { return controllerManager; }
                set { controllerManager = value; }
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
                    if (this.exception == null)
                    {
                        // Set the exception
                        exception = this.DataBridge.Exception;
                    }

                    // return value
                    return exception;
                }
                set
                {
                    // set the value
                    exception = value;

                    // Set the Databride exception
                    this.DataBridge.Exception = value;
                }
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
            #endregion\

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
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
                    bool hasDataBridge = (this.DataBridge != null);
                    
                    // return value
                    return hasDataBridge;
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
