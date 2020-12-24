

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertUserInterfaceStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'UserInterface' object.
    /// </summary>
    public class InsertUserInterfaceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertUserInterfaceStoredProcedure' object.
        /// </summary>
        public InsertUserInterfaceStoredProcedure()
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
                this.ProcedureName = "UserInterface_Insert";

                // Set tableName
                this.TableName = "UserInterface";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
