

#region using statements

using System;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DataJuggler.Core.UltimateHelper;

#endregion


namespace DataTierClient.ClientUtil
{
    
    
    #region class SQLSMOHelper
    /// <summary>
    /// This utility gets all sql Servers or all databases
    /// on the network.
    /// </summary>
    public class SQLSMOHelper
    {

        #region GetDatabases(string serverName, ComboBox comboBox, string connectionString = "")
        /// <summary>
        /// This method gets a list of databases for the selected server.
        /// </summary>
        /// <returns></returns>
        public static void GetDatabases(string serverName, ComboBox comboBox, string connectionString = "")
        {
            // locals
            string databaseName = "";
            Server server = null;

            try
            {
                // if the comboBox exists
                if(comboBox != null)
                {
                    // set text
                    comboBox.Text = "<Loading...>";
                    
                    // Referesh
                    comboBox.Refresh();
                
                    // If the connectionString string exists
                    if (TextHelper.Exists(connectionString))
                    {
                        // e.g. "Server=myServer;Database=master;User Id=myUser;Password=myPass;"
                        SqlConnection sqlConn = new SqlConnection(connectionString);
                        ServerConnection serverConnection = new ServerConnection(sqlConn);

                        // connect
                        server = new Server(serverConnection);
                    }
                    else
                    {
                         // get the local server first
                        server = new Server(serverName);
                    }

                    // loop through each database
                    foreach(Database database in server.Databases)
                    {
                        // if the database is not a system object
                        if(!database.IsSystemObject)
                        {
                            // get the database name
                            databaseName = database.Name;
                            
                            // Add this databaseName
                            comboBox.Items.Add(databaseName);
                        }
                    }

                    // set text
                    comboBox.Text = "";

                    // Referesh
                    comboBox.Refresh();
                }
            }
            catch (Exception error)
            {
                // raise the error
                throw error;
            }
        }
        #endregion

        #region GetSQLServers()
        /// <summary>
        /// This method gets a list of all available SQLServers.
        /// </summary>
        /// <returns></returns>
        public static void GetSQLServers(ListBox listBox)
        {   
            // local
            string serverName = "";
        
            try
            {
                // get the local server first
                Server server = new Server();

                // set serverName
                serverName = server.Name;
                
                // if the list box exists
                if (listBox != null)
                {
                    // add the servername
                    listBox.Items.Add(serverName);
                }
                
                // initial value
                DataTable dataTableSQLServers = SmoApplication.EnumAvailableSqlServers();

                // Loop through each row
                foreach (DataRow dataRowServer in dataTableSQLServers.Rows)
                {
                    // set serverName
                    serverName = dataRowServer["Server"].ToString();

                    // if their are multipe instances get them here
                    if (dataRowServer["Instance"] != null && dataRowServer["Instance"].ToString().Length > 0)
                    {
                        // add instance name to serverName
                        serverName += @"\" + dataRowServer["Instance"].ToString();
                    }
                    
                    // if the listBox exists
                    if(listBox != null)
                    {
                        // get the index
                        int index = listBox.Items.IndexOf(serverName);
                        
                        // if index was found
                        if(index < 0)
                        {
                            // Add this item
                            listBox.Items.Add(serverName);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // raise the error
                throw error;
            }
        }
        #endregion
        
    }
    #endregion 
    
}
