

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
        private string connectionName;
        private List<Exception> exceptions;
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
                Exceptions = new List<Exception>();
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

            #region Exceptions
            /// <summary>
            /// This property gets or sets the value for 'Exceptions'.
            /// </summary>
            public List<Exception> Exceptions
            {
                get { return exceptions; }
                set { exceptions = value; }
            }
            #endregion
            
            #region HasExceptions
            /// <summary>
            /// This property returns true if this object has an 'Exceptions'.
            /// </summary>
            public bool HasExceptions
            {
                get
                {
                    // initial value
                    bool hasExceptions = (Exceptions != null);

                    // return value
                    return hasExceptions;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}