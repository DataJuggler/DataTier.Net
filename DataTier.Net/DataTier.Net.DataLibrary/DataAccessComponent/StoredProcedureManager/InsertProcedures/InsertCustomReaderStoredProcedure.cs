

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

    #region class InsertCustomReaderStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'CustomReader' object.
    /// </summary>
    public class InsertCustomReaderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertCustomReaderStoredProcedure' object.
        /// </summary>
        public InsertCustomReaderStoredProcedure()
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
                this.ProcedureName = "CustomReader_Insert";

                // Set tableName
                this.TableName = "CustomReader";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
