

#region using statements

using System;
using System.Data;

#endregion

namespace $safeprojectname$.DataManager
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
        #endregion

        #region Constructor(string connectionName = "")
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        /// <param name="connectionName">The name of the environment variable to use to read the 
        /// connection string. For Dot Net Core / Blazor projects this must be set.
        /// For backwards compatibility the connection string can still be set in an app.config or web.config for now.
        /// By the full release of Dot Net 5 (Late 2020 ?), I am leaning towards removing the configuration reading code
        /// and require the environment variable method.</param>
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
        }
        #endregion

        #endregion

        #region Properties

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
            
            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
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
            
            #region HasDataConnector
            /// <summary>
            /// This property returns true if this object has a 'DataConnector'.
            /// </summary>
            public bool HasDataConnector
            {
                get
                {
                    // initial value
                    bool hasDataConnector = (this.DataConnector != null);
                    
                    // return value
                    return hasDataConnector;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
