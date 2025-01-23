

namespace DataAccessComponent.Connection
{

    #region class ConnectionConstants
    /// <summary>
    /// This class is used to hold the constants for the System Environment Variable
    /// </summary>
    public static class ConnectionConstants
    {

        #region Private Variables & Constants
        /// <summary>
        /// Create a connection string and then create a system enivornment variable.
        /// Set the value of the System Environement Variable to the connectionstring.
        /// </summary>
        public const string Name = "DataTierNetConnection";
        
        // Set this Env Variable to Enable Logging Errors To A File
        public const string LogFileName = "[Change To Environment Variable Holding path To Log Errors]";
        
        // Set this to enable System Events
        public const string LogEventResourceName = "[Change To Environment Variable Holding event resource name to Log Errors as System Events]";
        #endregion

    }
    #endregion

}