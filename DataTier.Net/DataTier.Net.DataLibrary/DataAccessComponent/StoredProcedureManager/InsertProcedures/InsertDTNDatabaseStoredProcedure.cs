

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;

#endregion


namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertDTNDatabaseStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'DTNDatabase' object.
    /// </summary>
    public class InsertDTNDatabaseStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertDTNDatabaseStoredProcedure' object.
        /// </summary>
        public InsertDTNDatabaseStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "DTNDatabase_Insert";

                // Set tableName
                this.TableName = "DTNDatabase";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
