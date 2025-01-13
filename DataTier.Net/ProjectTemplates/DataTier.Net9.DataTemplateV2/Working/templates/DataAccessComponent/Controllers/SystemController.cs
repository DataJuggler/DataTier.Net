

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.Controllers;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
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
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a SystemController
        /// </summary>
        public SystemController(DataBridgeManager dataBridgeArg)
        {
            // set DataBridgeManager
            this.DataBridge = dataBridgeArg;
        }
        #endregion

        #region Methods

        #region TestDatabaseConnection(DataManager dataManager = null
        /// <summary>
        /// Tests the connection to the database
        /// </summary>
        internal static bool TestDatabaseConnection(DataManager dataManager = null)
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
                PolymorphicObject connectedObject = DataBridgeManager.PerformDataOperation(methodName, objectName, testDataConnection, parameters, dataManager);

                // If method returned "true" value.
                if (connectedObject.Boolean.Value == NullableBooleanEnum.True)
                {
                    // set connected to true.
                    connected = true;
                }
            }
            catch (Exception error)
            {  

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

        #endregion

    }
    #endregion

}