

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

    #region class InsertNotificationStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Notification' object.
    /// </summary>
    public class InsertNotificationStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertNotificationStoredProcedure' object.
        /// </summary>
        public InsertNotificationStoredProcedure()
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
                this.ProcedureName = "Notification_Insert";

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
