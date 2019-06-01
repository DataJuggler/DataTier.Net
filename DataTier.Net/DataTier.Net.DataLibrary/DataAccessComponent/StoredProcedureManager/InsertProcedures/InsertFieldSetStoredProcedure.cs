

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

    #region class InsertFieldSetStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'FieldSet' object.
    /// </summary>
    public class InsertFieldSetStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertFieldSetStoredProcedure' object.
        /// </summary>
        public InsertFieldSetStoredProcedure()
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
                this.ProcedureName = "FieldSet_Insert";

                // Set tableName
                this.TableName = "FieldSet";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
