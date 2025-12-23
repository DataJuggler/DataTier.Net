
#region using statements

using DataAccessComponent.Controllers;
using DataAccessComponent.Data;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

#endregion

namespace DataAccessComponent.DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method, create a custom method
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;        
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName)
        {
            // store the ConnectionName
            ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.Data.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // if the value for HasErrorHandler is true
                if ((HasErrorHandler) && (ErrorHandler.HasExceptions))
                {
                    // return the Exception from the AppController
                    exception = AppController.DataManager.ErrorHandler.Exceptions.LastOrDefault();

                    // Set to null after the exception is retrieved so it does not return again
                    AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region TestDatabaseConnection(ref Exception error)
            /// <summary>
            /// returns the Database Connection
            /// </summary>
            public bool TestDatabaseConnection(ref Exception error)
            {
                // initial value
                bool connected = false;

                // If the this object does not have a HasAppController property
                if (!this.HasAppController)
                {
                    // Create the Controller
                    this.AppController = new ApplicationController(this.ConnectionName);
                }

                // If the AppController object exists
                if ((this.HasAppController) && (!this.AppController.HasConnectionName))
                {
                    // Set the ConnectionName
                    this.AppController.ConnectionName = this.ConnectionName;
                }

                // perform the test
                connected = this.AppController.TestDatabaseConnection(ref error, this.DataManager);

                // return value
                return connected;
            }
            #endregion
            
        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
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
            /// This read only property returns the value of DataManager from the object AppController.
            /// </summary>
            public DataManager DataManager
            {

                get
                {
                    // initial value
                    DataManager dataManager = null;

                    // if AppController exists
                    if (HasAppController)
                    {
                        // set the return value
                        dataManager = AppController.DataManager;
                    }

                    // return value
                    return dataManager;
                }
            }
            #endregion

            #region ErrorHandler
            /// <summary>
            /// This read only property returns the value of ErrorHandler from the object DataManager.
            /// </summary>
            public ErrorHandler ErrorHandler
            {

                get
                {
                    // initial value
                    ErrorHandler errorHandler = null;

                    // if DataManager exists
                    if (HasDataManager)
                    {
                        // set the return value
                        errorHandler = DataManager.ErrorHandler;
                    }

                    // return value
                    return errorHandler;
                }
            }
            #endregion

            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
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
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
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
            
            #region HasErrorHandler
            /// <summary>
            /// This property returns true if this object has an 'ErrorHandler'.
            /// </summary>
            public bool HasErrorHandler
            {
                get
                {
                    // initial value
                    bool hasErrorHandler = (ErrorHandler != null);

                    // return value
                    return hasErrorHandler;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}