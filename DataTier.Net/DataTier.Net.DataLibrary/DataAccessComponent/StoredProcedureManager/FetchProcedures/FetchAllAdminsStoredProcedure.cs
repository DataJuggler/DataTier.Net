

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

    #region class FetchAllAdminsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Admin' objects.
    /// </summary>
    public class FetchAllAdminsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllAdminsStoredProcedure' object.
        /// </summary>
        public FetchAllAdminsStoredProcedure()
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
                this.ProcedureName = "Admin_FetchAll";

                // Set tableName
                this.TableName = "Admin";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
