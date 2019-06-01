

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;

#endregion


namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateGitHubFollowerStoredProcedure
    /// <summary>
    /// This class is used to Update a 'GitHubFollower' object.
    /// </summary>
    public class UpdateGitHubFollowerStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateGitHubFollowerStoredProcedure' object.
        /// </summary>
        public UpdateGitHubFollowerStoredProcedure()
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
                this.ProcedureName = "GitHubFollower_Update";

                // Set tableName
                this.TableName = "GitHubFollower";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
