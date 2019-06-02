

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

    #region class InsertDTNProcedureStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'DTNProcedure' object.
    /// </summary>
    public class InsertDTNProcedureStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertDTNProcedureStoredProcedure' object.
        /// </summary>
        public InsertDTNProcedureStoredProcedure()
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
                this.ProcedureName = "DTNProcedure_Insert";

                // Set tableName
                this.TableName = "DTNProcedure";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
