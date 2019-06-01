

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;

#endregion


namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllDTNTablesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'DTNTable' objects.
    /// </summary>
    public class FetchAllDTNTablesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllDTNTablesStoredProcedure' object.
        /// </summary>
        public FetchAllDTNTablesStoredProcedure()
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
                this.ProcedureName = "DTNTable_FetchAll";

                // Set tableName
                this.TableName = "DTNTable";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
