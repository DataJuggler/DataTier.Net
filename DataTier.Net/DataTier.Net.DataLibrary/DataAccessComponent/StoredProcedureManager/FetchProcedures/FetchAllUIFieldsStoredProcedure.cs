

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

    #region class FetchAllUIFieldsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'UIField' objects.
    /// </summary>
    public class FetchAllUIFieldsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllUIFieldsStoredProcedure' object.
        /// </summary>
        public FetchAllUIFieldsStoredProcedure()
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
                this.ProcedureName = "UIField_FetchAll";

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
