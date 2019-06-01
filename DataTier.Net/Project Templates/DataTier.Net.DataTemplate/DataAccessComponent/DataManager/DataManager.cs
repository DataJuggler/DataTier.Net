

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
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager()
        {
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

        #region DataConnector
        public DataConnector DataConnector
        {
            get { return dataConnector; }
            set { dataConnector = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
