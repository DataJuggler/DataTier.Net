

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

    #region class FindNotificationHistoryStoredProcedure
    /// <summary>
    /// This class is used to Find a 'NotificationHistory' object.
    /// </summary>
    public class FindNotificationHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindNotificationHistoryStoredProcedure' object.
        /// </summary>
        public FindNotificationHistoryStoredProcedure()
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
                this.ProcedureName = "NotificationHistory_Find";

                // Set tableName
                this.TableName = "NotificationHistory";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
