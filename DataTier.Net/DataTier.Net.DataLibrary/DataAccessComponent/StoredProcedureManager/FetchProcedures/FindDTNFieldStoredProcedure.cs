

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

    #region class FindDTNFieldStoredProcedure
    /// <summary>
    /// This class is used to Find a 'DTNField' object.
    /// </summary>
    public class FindDTNFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindDTNFieldStoredProcedure' object.
        /// </summary>
        public FindDTNFieldStoredProcedure()
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
                this.ProcedureName = "DTNField_Find";

                // Set tableName
                this.TableName = "DTNField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
