

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

    #region class FetchAllNotificationsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Notification' objects.
    /// </summary>
    public class FetchAllNotificationsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllNotificationsStoredProcedure' object.
        /// </summary>
        public FetchAllNotificationsStoredProcedure()
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
                this.ProcedureName = "Notification_FetchAll";

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
