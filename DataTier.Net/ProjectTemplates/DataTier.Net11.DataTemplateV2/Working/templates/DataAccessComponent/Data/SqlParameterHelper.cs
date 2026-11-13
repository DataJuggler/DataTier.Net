

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

#endregion

namespace DataAccessComponent.Data
{

    #region SqlParameterHelper
    /// <summary>
    /// This class is used to create SqlParameter[] arrays
    /// for calling stored procedures to save having to 
    /// create methods for each call (the way I did it for years.)
    /// </summary>
    public class SqlParameterHelper
    {

        #region CreateSqlParameters(string parameterName, object parameterValue);
        /// <summary>
        /// Create a SqlParameter.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter[] CreateSqlParameters(string parameterName, object parameterValue)
        {
            // Initial Value
            SqlParameter[] parameters = new SqlParameter[1];

            // Create Parameter
            SqlParameter sqlParameter = new SqlParameter(parameterName, parameterValue);

            // Set parameters[0] to sqlParameter
            parameters[0] = sqlParameter;

            // return value
            return parameters;
        }
        #endregion

        #region CreateSqlParameters(string parameterName, object parameterValue, string parameterName2, object parameterValue2)
        /// <summary>
        /// Create the SqlParameters for exactly 2 parameters.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="parameterName2"></param>
        /// <param name="parameterValue2"></param>
        /// <returns></returns>
        public static SqlParameter[] CreateSqlParameters(string parameterName, object parameterValue, string parameterName2, object parameterValue2)
        {
            // Initial Value
            SqlParameter[] parameters = new SqlParameter[2];

            // Create Parameter
            SqlParameter sqlParameter = new SqlParameter(parameterName, parameterValue);

            // Set parameters[0] to sqlParameter
            parameters[0] = sqlParameter;

            // Create Parameter 2
            SqlParameter sqlParameter2 = new SqlParameter(parameterName2, parameterValue2);

            // Set parameters[1] to sqlParameter2
            parameters[1] = sqlParameter2;

            // return value
            return parameters;
        }
        #endregion

        #region CreateSqlParameters(string parameterName, object parameterValue, string parameterName2, object parameterValue2, string parameterName3, object parameterValue3)
        /// <summary>
        /// Create the SqlParameters for exactly 3 parameters.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="parameterName2"></param>
        /// <param name="parameterValue2"></param>
        /// <param name="parameterName3"></param>
        /// <param name="parameterValue3"></param>
        /// <returns></returns>
        public static SqlParameter[] CreateSqlParameters(string parameterName, object parameterValue, string parameterName2, object parameterValue2, string parameterName3, object parameterValue3)
        {
            // Initial Value
            SqlParameter[] parameters = new SqlParameter[3];

            // Create Parameter
            SqlParameter sqlParameter = new SqlParameter(parameterName, parameterValue);

            // Set parameters[0] to sqlParameter
            parameters[0] = sqlParameter;

            // Create Parameter 2
            SqlParameter sqlParameter2 = new SqlParameter(parameterName2, parameterValue2);

            // Set parameters[1] to sqlParameter2
            parameters[1] = sqlParameter2;

            // Create Parameter 3
            SqlParameter sqlParameter3 = new SqlParameter(parameterName3, parameterValue3);

            // Set parameters[2] to sqlParameter3
            parameters[2] = sqlParameter3;

            // return value
            return parameters;
        }
        #endregion

        #region CreateSqlParameters(string parameterName, object parameterValue, string parameterName2, object parameterValue2, string parameterName3, object parameterValue3, string parameterName4, object parameterValue4)
        /// <summary>
        /// Create the SqlParameters for exactly 4 parameters.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="parameterName2"></param>
        /// <param name="parameterValue2"></param>
        /// <param name="parameterName3"></param>
        /// <param name="parameterValue3"></param>
        /// <param name="parameterName4"></param>
        /// <param name="parameterValue4"></param>
        /// <returns></returns>
        public static SqlParameter[] CreateSqlParameters(string parameterName, object parameterValue, string parameterName2, object parameterValue2, string parameterName3, object parameterValue3, string parameterName4, object parameterValue4)
        {
            // Initial Value
            SqlParameter[] parameters = new SqlParameter[4];

            // Create Parameter
            SqlParameter sqlParameter = new SqlParameter(parameterName, parameterValue);

            // Set parameters[0] to sqlParameter
            parameters[0] = sqlParameter;

            // Create Parameter 2
            SqlParameter sqlParameter2 = new SqlParameter(parameterName2, parameterValue2);

            // Set parameters[1] to sqlParameter2
            parameters[1] = sqlParameter2;

            // Create Parameter 3
            SqlParameter sqlParameter3 = new SqlParameter(parameterName3, parameterValue3);

            // Set parameters[2] to sqlParameter3
            parameters[2] = sqlParameter3;

            // Create Parameter 4
            SqlParameter sqlParameter4 = new SqlParameter(parameterName4, parameterValue4);

            // Set parameters[3] to sqlParameter4
            parameters[3] = sqlParameter4;

            // return value
            return parameters;
        }
        #endregion

    }
    #endregion

}
