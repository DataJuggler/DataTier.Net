

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

    #region class FindNotificationStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Notification' object.
    /// </summary>
    public class FindNotificationStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindNotificationStoredProcedure' object.
        /// </summary>
        public FindNotificationStoredProcedure()
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
                this.ProcedureName = "Notification_Find";

                // Set tableName
                this.TableName = "Notification";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
