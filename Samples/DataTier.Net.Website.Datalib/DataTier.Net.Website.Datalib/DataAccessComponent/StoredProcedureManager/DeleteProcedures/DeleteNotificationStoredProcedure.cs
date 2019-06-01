

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataJuggler.Net;
using System;

#endregion


namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteNotificationStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Notification' object.
    /// </summary>
    public class DeleteNotificationStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteNotificationStoredProcedure' object.
        /// </summary>
        public DeleteNotificationStoredProcedure()
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
                this.ProcedureName = "Notification_Delete";

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
