

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

    #region class InsertNotificationHistoryStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'NotificationHistory' object.
    /// </summary>
    public class InsertNotificationHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertNotificationHistoryStoredProcedure' object.
        /// </summary>
        public InsertNotificationHistoryStoredProcedure()
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
                this.ProcedureName = "NotificationHistory_Insert";

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
