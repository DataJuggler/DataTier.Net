

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using DataAccessComponent.Logging;

#endregion


namespace DataAccessComponent.Data
{

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private ErrorHandler errorHandler;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager(string connectionName = "")
        {
            // Store the ConnectionName arg
            this.ConnectionName = connectionName;

            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create the ErrorHandler
                this.ErrorHandler = new ErrorHandler();
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region ConnectionName
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region ErrorHandler
            /// <summary>
            /// This property gets or sets the value for 'ErrorHandler'.
            /// </summary>
            public ErrorHandler ErrorHandler
            {
                get { return errorHandler; }
                set { errorHandler = value; }
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