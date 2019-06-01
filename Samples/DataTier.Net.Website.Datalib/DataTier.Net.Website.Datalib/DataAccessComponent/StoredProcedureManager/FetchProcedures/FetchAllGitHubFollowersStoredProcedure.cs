

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

    #region class FetchAllGitHubFollowersStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'GitHubFollower' objects.
    /// </summary>
    public class FetchAllGitHubFollowersStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllGitHubFollowersStoredProcedure' object.
        /// </summary>
        public FetchAllGitHubFollowersStoredProcedure()
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
                this.ProcedureName = "GitHubFollower_FetchAll";

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
