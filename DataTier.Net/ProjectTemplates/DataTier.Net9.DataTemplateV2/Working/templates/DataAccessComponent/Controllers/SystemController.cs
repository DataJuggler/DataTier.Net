

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.Controllers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using DataAccessComponent.Exceptions;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class SystemController
    /// <summary>
    /// This class controls 'System' methods.
    /// </summary>
    public class SystemController
    {

        #region Private Variables
        private DataBridgeManager dataBridge;
        private ErrorHandler errorProcessor;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a SystemController
        /// </summary>
        public SystemController(DataBridgeManager dataBridgeArg, ErrorHandler errorProcessorArg)
        {
            // set DataBridgeManager
            this.DataBridge = dataBridgeArg;

            // Set Error Handler
            this.ErrorProcessor = errorProcessorArg;
        }
        #endregion

        #region Methods

        #region TestDatabaseConnection()
        /// <summary>
        /// Tests the connection to the database
        /// </summary>
        internal bool TestDatabaseConnection()
        {
            // initial value
            bool connected = false;

            // locals
            string methodName = "TestDatabaseConnection";
            string objectName = "DataAccessComponent.Controller.System.SystemController";

            try
            {
                // Create Delegate For DataOperation
                ApplicationController.DataOperationMethod testDataConnection = SystemMethods.TestDataConnection;

                // Create null parameters object (not needed for this, but you have to have it to call the method).
                List<PolymorphicObject> parameters = null;

                // Perform DataOperation
                PolymorphicObject connectedObject = this.DataBridge.PerformDataOperation(methodName, objectName, testDataConnection, parameters);

                // If method returned "true" value.
                if (connectedObject.Boolean.Value == NullableBooleanEnum.True)
                {
                    // set connected to true.
                    connected = true;
                }
            }
            catch (Exception error)
            {
                // If ErrorProcessor exists
                if (this.ErrorProcessor != null)
                {
                    // Create Error
                    DataConnectionFailedException dataConnectionError = new DataConnectionFailedException(methodName, objectName, error);

                    // Log the current error
                    this.ErrorProcessor.LogError(methodName, objectName, dataConnectionError);
                }

            }

            // return value
            return connected;
        }
        #endregion

        #endregion

        #region Properties

        #region DataBridgeManager
        /// <summary>
        /// This object is the gateway to the data.
        /// </summary>
        public DataBridgeManager DataBridge
        {
            get { return dataBridge; }
            set { dataBridge = value; }
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

        #endregion

    }
    #endregion

}
