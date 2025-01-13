
#region using statements

using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.Data;
using DataAccessComponent.Logging;
using DataAccessComponent.Exceptions;
using DataAccessComponent.Controllers;

#endregion

namespace DataAccessComponent.Connection
{

    #region AuthenticationManager
    /// <summary>
    /// This class handles reading the app.config file,
    /// connecting to the database and validating the
    /// user's username / password.
    /// </summary>
    public class AuthenticationManager
    {

        #region Methods

            #region ConnectToDatabase(DataManager dataManager = null)
            /// <summary>
            /// This method reads the app.config file to 
            /// load the current configuration.
            /// </summary>
            /// <returns></returns>
            public static DataManager ConnectToDatabase(DataManager dataManager = null)
            {
                // locals
                string methodName = "ConnectToDatabase";
                string objectName = "AuthenticationManager";

                try
                {
                    // if doesn't exist
                    if (dataManager == null)
                    {
                        // Create a new DataManager
                        dataManager = new DataManager();
                    }

                    // If connection is not set 
                    if(String.IsNullOrEmpty(dataManager.DataConnector.ConnectionString))
                    {
                        // if the connectionName is set
                        if (TextHelper.Exists(dataManager.ConnectionName))
                        {
                            // Set the ConnectionString (requires DataJuggler.UltimateHelper version 7.1 or higher)
                            dataManager.DataConnector.ConnectionString = EnvironmentVariableHelper.GetEnvironmentVariableValue(dataManager.ConnectionName, EnvironmentVariableTarget.Machine);
                        }
                    }
                    
                    // check if database is already connected
                    if (dataManager.DataConnector.State == System.Data.ConnectionState.Open)
                    {
                        // close connection and reopen (there should not be any open connections here)
                        // I have been thinking of a bulk insert feature in the future, but that is not for this method
                        // To Do: Log Error 'Database Connection Was Already Open'
                        dataManager.DataConnector.Close();
                    }
                   
					// Open Connection
					dataManager.DataConnector.Open();
                }
                catch (Exception error)
                {
                    // Log this error
                    ErrorHandler.LogError(methodName, objectName, error);                    
                }

                // return value
                return dataManager;
            }
            #endregion

        #endregion

    }
    #endregion

}