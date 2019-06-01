
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace DataAccessComponent.DataManager.Writers
{

    #region class NotificationWriter
    /// <summary>
    /// This class is used for converting a 'Notification' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class NotificationWriter : NotificationWriterBase
    {

        #region Static Methods

            #region CreateFindNotificationStoredProcedure(Notification notification)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindNotificationStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Notification_Find'.
            /// </summary>
            /// <param name="notification">The 'Notification' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindNotificationStoredProcedure CreateFindNotificationStoredProcedure(Notification notification)
            {
                // Initial Value
                FindNotificationStoredProcedure findNotificationStoredProcedure = null;

                // verify notification exists
                if(notification != null)
                {
                    // Instanciate findNotificationStoredProcedure
                    findNotificationStoredProcedure = new FindNotificationStoredProcedure();

                    // if notification.FindBy is true
                    if (notification.FindBy)
                    {
                        // Change the procedure name
                        findNotificationStoredProcedure.ProcedureName = "Notification_FindBy";
                        
                        // Create the @EmailAddress parameter
                        findNotificationStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@EmailAddress", notification.EmailAddress);
                    }
                    // if notification.FindByEmailAddress is true
                    else if (notification.FindByEmailAddress)
                    {
                        // Change the procedure name
                        findNotificationStoredProcedure.ProcedureName = "Notification_FindByEmailAddress";
                        
                        // Create the @EmailAddress parameter
                        findNotificationStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@EmailAddress", notification.EmailAddress);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findNotificationStoredProcedure.Parameters = CreatePrimaryKeyParameter(notification);
                    }
                }

                // return value
                return findNotificationStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
