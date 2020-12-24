

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindUIFieldStoredProcedure
    /// <summary>
    /// This class is used to Find a 'UIField' object.
    /// </summary>
    public class FindUIFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindUIFieldStoredProcedure' object.
        /// </summary>
        public FindUIFieldStoredProcedure()
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
                this.ProcedureName = "UIField_Find";

                // Set tableName
                this.TableName = "UIField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
