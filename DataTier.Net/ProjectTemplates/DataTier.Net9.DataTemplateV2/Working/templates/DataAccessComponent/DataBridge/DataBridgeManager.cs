
#region using statements

using DataAccessComponent.Connection;
using DataAccessComponent.Controllers;
using DataAccessComponent.Data;
using DataAccessComponent.DataOperations;
using System;
using System.Collections.Generic;

#endregion

namespace DataAccessComponent.DataBridge
{

    #region DataBridgeManager
    /// <summary>
    /// This class is the only object that will open & close data connections.
    /// In fact, the only place in the application where the data connection
    /// is opened is in the PerformDataOperation() method in this object.
    /// This object requires that a delagate (method pointer) be passed
    /// in that will perform the data operation using the open connection
    /// </summary>
    public class DataBridgeManager
    {

        #region Private Variables
        private DataOperationsManager dataOperations;
        private DataManager dataManager;        
        private AuthenticationManager loginManager;
        private Exception exception;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a DataBridgeManager object.
        /// </summary>
        public DataBridgeManager(AuthenticationManager loginManagerArg, string connectionName)
        {
            // Set Properties
            LoginManager = loginManagerArg;
            ConnectionName = connectionName;

            // Perform Initializations
            Init();
        }
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

                // if the DataManager exists
                if (HasDataManager)
                {
                    // return the DataConnector from the DataManager
                    dataConnector = DataManager.DataConnector;
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform any initializations needed.
            /// </summary>
            private void Init()
            {
                // Create DataManager(s)
                DataManager = new DataManager(ConnectionName);

                // Create DataOperations
                DataOperations = new DataOperationsManager(DataManager);
            }
            #endregion

            #region PerformDataOperation(string methodName, string objectName, ApplicationController.DataOperationMethod dataMethod, List<PolymorphicObject> parameters, DataManager dataManaget)
            /// <summary>
            /// Performs an operation that required a connection to the database.
            /// This method uses a delegate to execute the method so that this is the 
            /// only place in the application a connection to the database is opened.
            /// </summary>
            internal static PolymorphicObject PerformDataOperation(string methodName, string objectName, ApplicationController.DataOperationMethod dataMethod, List<PolymorphicObject> parameters, DataManager dataManager)
            {
                // Initial Value
                PolymorphicObject returnObject = null;

                try
                {
                    // Connect To Database 
                    dataManager = AuthenticationManager.ConnectToDatabase(dataManager);

                    // if connected
                    if (dataManager.DataConnector.Connected)
                    {
                        // verify dataMethod exists 
                        if (dataMethod != null)
                        {
                            // Invoke Method
                            returnObject = dataMethod(parameters, dataManager.DataConnector);
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }
                catch (Exception error)
                {
                                  
                }
                finally
                {
                    // Close Connection To Database
                    dataManager.DataConnector.Close();
                }

                // return value
                return returnObject;
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

            #region DataManager
            /// <summary>
            /// This object controls all data access
            /// in this application.
            /// </summary>
            public DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

            #region DataOperations
            /// <summary>
            /// This object contains all of the stored procedure
            /// methods to execute. All of these methods must meet 
            /// the format of the delegate in DataBridgeManager.DataOperationsManager
            /// </summary>
            public DataOperationsManager DataOperations
            {
                get { return dataOperations; }
                set { dataOperations = value; }
            }
            #endregion

            #region Exception
            /// <summary>
            /// The last exception that occurred (if any) from executing
            /// a data operation.
            /// </summary>
            public Exception Exception
            {
                get { return exception; }
                set { exception = value; }
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

        #endregion

    }
    #endregion

}