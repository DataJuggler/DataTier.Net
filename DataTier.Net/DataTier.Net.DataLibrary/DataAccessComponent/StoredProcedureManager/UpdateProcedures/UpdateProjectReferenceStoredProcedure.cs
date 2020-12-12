

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateProjectReferenceStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ProjectReference' object.
    /// </summary>
    public class UpdateProjectReferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateProjectReferenceStoredProcedure' object.
        /// </summary>
        public UpdateProjectReferenceStoredProcedure()
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
                this.ProcedureName = "ProjectReference_Update";

                // Set tableName
                this.TableName = "ProjectReference";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
