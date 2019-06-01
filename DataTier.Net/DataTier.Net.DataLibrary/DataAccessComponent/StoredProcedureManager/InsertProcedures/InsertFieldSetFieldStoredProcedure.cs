

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

    #region class InsertFieldSetFieldStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'FieldSetField' object.
    /// </summary>
    public class InsertFieldSetFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertFieldSetFieldStoredProcedure' object.
        /// </summary>
        public InsertFieldSetFieldStoredProcedure()
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
                this.ProcedureName = "FieldSetField_Insert";

                // Set tableName
                this.TableName = "FieldSetField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
