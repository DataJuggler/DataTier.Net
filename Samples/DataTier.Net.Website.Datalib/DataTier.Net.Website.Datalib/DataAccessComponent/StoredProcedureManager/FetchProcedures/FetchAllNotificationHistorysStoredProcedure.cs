

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

    #region class FetchAllNotificationHistorysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'NotificationHistory' objects.
    /// </summary>
    public class FetchAllNotificationHistorysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllNotificationHistorysStoredProcedure' object.
        /// </summary>
        public FetchAllNotificationHistorysStoredProcedure()
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
                this.ProcedureName = "NotificationHistory_FetchAll";

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
