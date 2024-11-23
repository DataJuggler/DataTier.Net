
#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using ObjectLibrary.Enumerations;
using DataJuggler.NET9.Enumerations;

#endregion

namespace DataAccessComponent.StoredProcedureManager
{

    #region class StoredProcedure
    /// <summary>
    /// This class is a base class that all
    /// DataTier.Net Stored Procedures will inherit from.
    /// </summary>
    public class StoredProcedure
    {

        #region Private Variables
        private SqlParameter[] parameters;
        private string procedureName;
        private StoredProcedureTypeEnum storedProcedureType;
        private string tableName;
        private bool useCustomReader;
        private string customReaderName;
        #endregion

        #region Default Constructor
        /// <summary>
        /// Creates a new StoredProcedure instance.
        /// </summary>
        public StoredProcedure()
        {
            
        }
        #endregion

        #region Methods

        #region ToString()
        /// <summary>
        /// This method forces the ProcedureName to be displayed.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ProcedureName;
        }
        #endregion

        #endregion

        #region Properties

        #region CustomReaderName
        /// <summary>
        /// This property gets or sets the value for 'CustomReaderName'.
        /// </summary>
        public string CustomReaderName
        {
            get { return customReaderName; }
            set { customReaderName = value; }
        }
        #endregion

        #region Parameters
        /// <summary>
        /// An array of stored procedure parameters
        /// </summary>
        public SqlParameter[] Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
            }
        }
        #endregion

        #region ProcedureName
        /// <summary>
        /// The name of this stored procedure
        /// </summary>
        public string ProcedureName
        {
            get
            {
                return this.procedureName;
            }
            set
            {
                this.procedureName = value;
            }
        }
        #endregion

        #region StoredProcedureType
        /// <summary>
        /// Type of stored procedure: Find, FetchAll, Insert
        /// Delete or Update.
        /// </summary>
        public StoredProcedureTypeEnum StoredProcedureType
        {
            get
            {
                return this.storedProcedureType;
            }
            set
            {
                this.storedProcedureType = value;
            }
        }
        #endregion

        #region TableName
        /// <summary>
        /// The name of the database table this procedure
        /// modifies
        /// </summary>
        public string TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }
        #endregion

        #region UseCustomReader
        /// <summary>
        /// This property gets or sets the value for 'UseCustomReader'.
        /// </summary>
        public bool UseCustomReader
        {
            get { return useCustomReader; }
            set { useCustomReader = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
