
#region using statements

using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

#endregion

namespace DataAccessComponent.Data
{

    #region class DataConnector
    /// <summary>
    /// This class is a wrapper for the SQLDataConnector
    /// </summary>
    public class DataConnector
    {

        #region Private Variables
        private SqlConnection sqlConnector;
        #endregion

        #region Constructors

        #region Default Constructor
        /// <summary>
        /// Default Constructor for this object.
        /// </summary>
        public DataConnector()
        {
            // Initialization Method
            Init();
        }
        #endregion

        #endregion

        #region Methods

        #region BuildConnectionString(string ServerName, string DatabaseName)
        /// <summary>
        /// This method builds a connection string for the current configuration using Integrated Security (Windows Authentication)
        /// </summary>
        /// <param name="serverName">Server to connect to.</param>
        /// <param name="databaseName">Database to connect to</param>
        /// <returns></returns>
        public string BuildConnectionString(string serverName, string databaseName)
        {
            // Seed StringBuild with ServerName
            StringBuilder sb = new StringBuilder("Server=");

            // Append Server Name
            sb.Append(serverName);

            // Append Database=
            sb.Append(";Database=");

            // Append Database Name
            sb.Append(databaseName);

            // Append Trusted_Connection = True
            sb.Append(";Trusted_Connection=True");

            // Return Value
            return sb.ToString();
        }
        #endregion

        #region BuildConnectionString(string ServerName, string DatabaseName, string UserID, string Password)
        /// <summary>
        /// This method builds a connection string for the current configuration.
        /// </summary>
        /// <param name="serverName">Server to connect to.</param>
        /// <param name="databaseName">Database to connect to</param>
        /// <param name="userID">SQL UserName</param>
        /// <param name="password">The password for the SQL user</param>
        /// <returns></returns>
        public string BuildConnectionString(string serverName, string databaseName, string userID, string password)
        {
            // Seed StringBuild with ServerName
            StringBuilder sb = new StringBuilder("Server=");

            // Append Server Name
            sb.Append(serverName);

            // Append Database=
            sb.Append(";Database=");

            // Append Database Name
            sb.Append(databaseName);

            // Append UserId=
            sb.Append(";User ID=");

            // Append UserID
            sb.Append(userID);

            // Append Password
            sb.Append(";Password=");

            // Append Password Value
            sb.Append(password);

            // Append Trusted_Connection = False
            sb.Append(";Trusted_Connection=False");

            // Return Value
            return sb.ToString();

        }
        #endregion

        #region Close()
        /// <summary>
        /// This method closes the open database connection.
        /// </summary>
        public void Close()
        {
            // if the SqlConnector exists
            if (this.SqlConnector != null)
            {
                // Close SqlConnector
                this.SqlConnector.Close();
            }
        }
        #endregion

        #region Open()
        /// <summary>
        /// This method closes the open database connection.
        /// </summary>
        public void Open()
        {
            // if the SqlConnector exists
            if (this.SqlConnector != null)
            {
                // Close SqlConnector
                this.SqlConnector.Open();
            }
        }
        #endregion

        #region  Init()
        /// <summary>
        /// Perform any start up initiailzations
        /// needed for this component.
        /// </summary>
        private void Init()
        {
        }
        #endregion

        #endregion

        #region Properties

        #region Connected
        /// <summary>
        /// Does the DataConnector have an active
        /// connection to the database.
        /// </summary>
        public bool Connected
        {
            get
            {
                // initial value
                bool connected = false;

                // verify DatabaseConnection exists and the connection is open.
                if ((this.SqlConnector != null) && (this.SqlConnector.State == System.Data.ConnectionState.Open))
                {
                    // set connected to true
                    connected = true;
                }

                // return value
                return connected;
            }
        }
        #endregion

        #region ConnectionString
        /// <summary>
        /// The ConnectionString from the active connection.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                // initial value
                string connectionString = "";

                // if the SqlConnector exists
                if (this.SqlConnector != null)
                {
                    // Set connectionString
                    connectionString = this.SqlConnector.ConnectionString;
                }

                // return value
                return connectionString;
            }
            set
            {
                // if the SqlConnector does not exist
                if (this.SqlConnector == null)
                {
                    // Set connectionString
                    this.SqlConnector = new SqlConnection();
                }

                // Set connectionString
                this.SqlConnector.ConnectionString = value;
            }
        }
        #endregion

        #region SqlConnector
        /// <summary>
        /// Connection to use for connecting to SQL Databases.
        /// </summary>
        public SqlConnection SqlConnector
        {
            get { return sqlConnector; }
            set { sqlConnector = value; }
        }
        #endregion

        #region State
        /// <summary>
        /// The state of the current connection object.
        /// </summary>
        public ConnectionState State
        {
            get
            {
                // initial value
                ConnectionState state = ConnectionState.Closed;

                // if the SqlConnector exists
                if (this.SqlConnector != null)
                {
                    // Set state
                    state = this.SqlConnector.State;
                }

                // return value
                return state;
            }
        }
        #endregion

        #endregion

    }
    #endregion

}
