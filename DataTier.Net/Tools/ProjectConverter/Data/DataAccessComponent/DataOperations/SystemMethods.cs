
#region using statements

using DataAccessComponent.DataBridge;
using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.StoredProcedureManager;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataAccessComponent.DataOperations
{

    #region class SystemMethods
    /// <summary>
    /// This class contains a collection of methods used by the 
    /// system.
    /// </summary>
    public class SystemMethods
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a 'SystemMethods' object.
        /// </summary>
        public SystemMethods()
        {
        }
        #endregion

        #region Methods

            #region ExecuteNonQuery(List<PolymorphicObject> parameters, DataConnector dataConnector)
             /// <summary>
             /// This method is used to execute a query that does not return a value.
             /// To call this method, you must set following:
             /// </summary>
             /// <param name="parameters">The parameters must be set to call this method.
             /// 1. 'ProcedureName' - The String value must be set for this parameter.
             /// 2. 'SqlParameters' (Optional) - If the stored procedure to be called requires parameters
             /// then you must pass in the SqlParameters[] array as this parameter.
             /// It does not matter the order of these parameters.
             /// </param>
             /// <param name="dataConnector">The database connection to use to execute this procedure.</param>
             /// A successful will call will set returnValue.Boolean to true (executed)
             /// In the event the procedure does not execute (returnValue.Boolean = false)
             /// check the following:
             /// returnValue.Name   = 'Error" - Will be set to error
             /// returnValue.Text   = Will be set to the Exception.ToString();
             /// returnValue.Object = Will Contain the Exception that occurred.
            public PolymorphicObject ExecuteNonQuery(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // Set to false
                returnValue.Boolean = new NullableBoolean(false);

                // locals
                bool executed = false;

                try
                {
                    // If the data connection is connected
                    if ((dataConnector != null) && (dataConnector.Connected == true))
                    {
                        // Create a StoredProcedure
                        StoredProcedure storedProcedure = new StoredProcedure();
                        
                        // Create a StoredProcedure object
                        storedProcedure.ProcedureName = FindProcedureName(parameters);

                        // Set the Parameters for the StoredProcedure
                        storedProcedure.Parameters = FindSqlParameters(parameters);

                        // if the ProcedureName is set
                        if (!String.IsNullOrEmpty(storedProcedure.ProcedureName))
                        {
                            // Perform an update
                            executed = DataHelper.UpdateRecord(storedProcedure, dataConnector);

                            // set the return value
                            returnValue.Boolean = new NullableBoolean(executed);
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Set the text of the 
                    returnValue.Name = "Error";

                    // Set the text for the returnValue
                    returnValue.Text = err;

                    // set the return value
                    returnValue.ObjectValue = error;
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindProcedureName(List<PolymorphicObject> parameters)
            /// <summary>
            /// This method returns a list of Procedure Name
            /// </summary>
            private static string FindProcedureName(List<PolymorphicObject> parameters)
            {
                // initial value
                string procedureName = "";

                // if the parameters exist
                if (parameters != null)
                {
                    // iterate the parameters
                    foreach (PolymorphicObject item in parameters)
                    {
                        // if the name of the param is SqlParameters
                        if (item.Name == "ProcedureName")
                        {
                            // set the return value
                            procedureName = item.Text;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return procedureName;
            }
            #endregion

            #region FindSqlParameters(List<PolymorphicObject> parameters)
            /// <summary>
            /// This method returns a list of Sql Parameters
            /// </summary>
            private static SqlParameter[] FindSqlParameters(List<PolymorphicObject> parameters)
            {
                // initial value
                SqlParameter[] sqlParameters = null;

                // if the parameters collection exists
                if (parameters != null)
                {
                    // iterate the parameters
                    foreach (PolymorphicObject item in parameters)
                    {
                        // if the name of the param is SqlParameters
                        if (item.Name == "SqlParameters")
                        {
                            // set the return value
                            sqlParameters = item.ObjectValue as SqlParameter[];

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return sqlParameters;
            }
            #endregion

            #region TestDataConnection()
            /// <summary>
            /// Tests the connection to the database
            /// </summary>
            internal static PolymorphicObject TestDataConnection(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // Create returnObject.Boolean
                returnObject.Boolean = new NullableBoolean();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Set Boolean To True
                    returnObject.Boolean.Value = NullableBooleanEnum.True;
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
