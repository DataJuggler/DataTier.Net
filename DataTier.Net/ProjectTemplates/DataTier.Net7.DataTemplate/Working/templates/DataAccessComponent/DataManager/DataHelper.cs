
#region using statements

using System;
using System.Data;
using DataAccessComponent.StoredProcedureManager;
using DataJuggler.Net7.Sql;

#endregion

namespace DataAccessComponent.DataManager
{

    #region class DataHelper
    /// <summary>
    /// This object uses the Microsoft Data ApplicationBlock
    /// to execute stored procedures.
    /// </summary>
    public class DataHelper
    {

        #region Constructor
        /// <summary>
        /// Creaetes a new instance of a 'DataHelper'.
        /// </summary>
        public DataHelper()
        {
        }
        #endregion

        #region Methods

        #region deleteRecord(StoredProcedure storedProcedure)
        /// <summary>
        /// This method uses the Microsoft.ApplicationBlocks.Data 
        /// Method to delete an existing record by executing
        /// a query that does not return anything. (ExecuteNonQuery).
        /// </summary>
        /// <param name="storedProcedure">The 'StoredProcedure' to execute.</param>
        /// <returns>True as long as there is not an error, false if there is.
        /// </returns>
        public bool DeleteRecord(StoredProcedure deleteStoredProcedure, DataConnector databaseConnector)
        {
            // initial value
            bool deleted = false;

            // Execute StoredProcedure
            SqlHelper.ExecuteNonQuery(databaseConnector.SqlConnector, CommandType.StoredProcedure, deleteStoredProcedure.ProcedureName, deleteStoredProcedure.Parameters);

            // set deleted to true
            deleted = true;

            // return value
            return deleted;
        }
        #endregion

        #region InsertRecord(StoredProcedure storedProcedure)
        /// <summary>
        /// This method uses the Microsoft.ApplicationBlocks.Data 
        /// Method to insert a new record.
        /// </summary>
        /// <param name="storedProcedure">The 'StoredProcedure' to execute.</param>
        /// <returns>The identity value of the new record if successful or 
        /// -1 if not.
        /// </returns>
        public int InsertRecord(StoredProcedure storedProcedure, DataConnector databaseConnector)
        {
            // initial value
            int identity = -1;

            // Execute StoredProcedure
            identity = Convert.ToInt32(SqlHelper.ExecuteScalar(databaseConnector.SqlConnector, CommandType.StoredProcedure, storedProcedure.ProcedureName, storedProcedure.Parameters));

            // return value
            return identity;
        }
        #endregion

        #region LoadDataSet(StoredProcedure storedProcedure)
        /// <summary>
        /// This method uses the Microsoft.ApplicationBlocks.Data 
        /// Method to fill a DataSet.
        /// </summary>
        /// <param name="storedProcedure">The 'StoredProcedure' to execute.</param>
        /// <returns>A DataSet if successful or null if not. Always test for null
        /// befure using the returned data set.</returns>
        public DataSet LoadDataSet(StoredProcedure storedProcedure, DataConnector databaseConnector)
        {
            // initial value
            DataSet dataSet = null;

            // Execute StoredProcedure
            dataSet = SqlHelper.ExecuteDataset(databaseConnector.SqlConnector, CommandType.StoredProcedure, storedProcedure.ProcedureName, storedProcedure.Parameters);

            // return value
            return dataSet;
        }
        #endregion

        #region ParseBoolean(object dataRowFieldValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into a boolean value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool ParseBoolean(object dataRowFieldValue, bool defaultValue)
        {
            // initial value
            bool booleanValue = defaultValue;

            try
            {
                // booleanValue = System.Boolean.Parse(dataRowFieldValue.ToString());

                // if the object is a boolean
                if (dataRowFieldValue is Boolean)
                {
                    // Cast as a bool 
                    booleanValue = (bool)dataRowFieldValue;
                }
            }
            catch
            {
                // set to default value
                booleanValue = defaultValue;
            }

            // return value
            return booleanValue;
        }
        #endregion

        #region ParseDate(object dataRowFieldValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into a 'DateTime' value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static DateTime ParseDate(object dataRowFieldValue)
        {
            // initial value
            DateTime dateValue = new DateTime(1900, 1, 1);

            try
            {
                // Parse Date
                // dateValue = System.DateTime.Parse(dataRowFieldValue.ToString());

                // if the object is a dateTime
                if (dataRowFieldValue is DateTime)
                {
                    // cast as a DateTime
                    dateValue = (DateTime)dataRowFieldValue;
                }
            }
            catch
            {
            }

            // return value
            return dateValue;
        }
        #endregion

        #region ParseGuid(object dataRowFieldValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into a Guid value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static Guid ParseGuid(object dataRowFieldValue)
        {
            // initial value
            Guid guidValue = Guid.Empty;

            try
            {
                // test for the is
                if (dataRowFieldValue is Guid)
                {
                    // Parse guidValue
                    guidValue = (Guid)dataRowFieldValue;
                }
            }
            catch
            {
            }

            // return value
            return guidValue;
        }
        #endregion

        #region ParseString(object dataRowFieldValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into a string value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string ParseString(object dataRowFieldValue)
        {
            // initial value
            string stringValue = null;

            try
            {
                // Parse stringValue
                stringValue = dataRowFieldValue.ToString().Trim();
            }
            catch
            {
            }

            // return value
            return stringValue;
        }
        #endregion

        #region ParseDouble(object dataRowFieldValue, double defaultValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into an integer value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static double ParseDouble(object dataRowFieldValue, double defaultValue)
        {
            // initial value
            double doubleValue = defaultValue;

            try
            {
                // if dataRowFieldValue can be cast as a Double (Faster then parsing a string)
                if (dataRowFieldValue is Single)
                {
                    // cast as a Single first
                    Single singleValue = (Single)dataRowFieldValue;

                    // cast as a Double now.
                    doubleValue = (Double)singleValue;
                }
                else if (dataRowFieldValue is Double)
                {
                    // cast a double
                    doubleValue = (Double)dataRowFieldValue;
                }
                else if (dataRowFieldValue is Decimal)
                {
                    // cast as a decimal
                    Decimal decimalValue = (Decimal)dataRowFieldValue;

                    // parse as a Double
                    doubleValue = (Double)decimalValue;
                }
            }
            catch
            {
                // set to default value
                doubleValue = defaultValue;
            }

            // return value
            return doubleValue;
        }
        #endregion

        #region ParseInteger(object dataRowFieldValue, int defaultValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into an integer value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static int ParseInteger(object dataRowFieldValue, int defaultValue)
        {
            // initial value
            int integerValue = defaultValue;

            try
            {
                // Parse integerValue
                // integerValue = System.Int32.Parse(dataRowFieldValue.ToString());

                // if this is an integer
                if (dataRowFieldValue is Int32)
                {
                    // set the integer value
                    integerValue = (int)dataRowFieldValue;
                }
            }
            catch
            {
                // set to default value
                integerValue = defaultValue;
            }

            // return value
            return integerValue;
        }
        #endregion

        #region ParseBinaryData(object dataRowFieldValue)
        /// <summary>
        /// This method parses the dataRowFieldValue passed in 
        /// into an integer value.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static byte[] ParseBinaryData(object dataRowFieldValue)
        {
            // initial value
            byte[] binaryData = null;

            try
            {
                // Parse integerValue
                binaryData = (byte[])dataRowFieldValue;
            }
            catch
            {
            }

            // return value
            return binaryData;
        }
        #endregion

        #region ReturnFirstRow(StoredProcedure storedProcedure)
        /// <summary>
        /// This method returns the first data row of the first data table
        /// in the data set passed in.
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public DataRow ReturnFirstRow(DataSet dataSet)
        {
            // Initial Value
            DataRow row = null;

            // if userDataSet exists
            if ((dataSet != null) && (dataSet.Tables != null) && (dataSet.Tables.Count > 0))
            {
                // test for rows
                if ((dataSet.Tables[0].Rows != null) && (dataSet.Tables[0].Rows.Count > 0))
                {
                    // Create DataRow from data set
                    row = dataSet.Tables[0].Rows[0];
                }
            }

            // Return Value
            return row;
        }
        #endregion

        #region ReturnFirstTable(DataSet dataSet)
        /// <summary>
        /// This method returns first data table
        /// in the data set passed in.
        /// </summary>
        /// <param name="dataSet">The 'DataSet' to return the first table of.</param>
        /// <returns>The first DataTable of the DataSet if it exists.</returns>
        public DataTable ReturnFirstTable(DataSet dataSet)
        {
            // Initial Value
            DataTable table = null;

            // if userDataSet exists
            if ((dataSet != null) && (dataSet.Tables != null) && (dataSet.Tables.Count > 0))
            {
                // Set table
                table = dataSet.Tables[0];
            }

            // Return Value
            return table;
        }
        #endregion

        #region UpdateRecord(StoredProcedure storedProcedure)
        /// <summary>
        /// This method uses the Microsoft.ApplicationBlocks.Data 
        /// Method to update an existing record by executing
        /// a query that does not return anything. (ExecuteNonQuery).
        /// </summary>
        /// <param name="storedProcedure">The 'StoredProcedure' to execute.</param>
        /// <returns>True as long as there is not an error, false if there is.
        /// </returns>
        public bool UpdateRecord(StoredProcedure storedProcedure, DataConnector databaseConnector)
        {
            // initial value
            bool saved = false;

            // Execute StoredProcedure
            SqlHelper.ExecuteNonQuery(databaseConnector.SqlConnector, CommandType.StoredProcedure, storedProcedure.ProcedureName, storedProcedure.Parameters);

            // set saved to true
            saved = true;

            // return value
            return saved;
        }
        #endregion

        #endregion

    }
    #endregion

}
