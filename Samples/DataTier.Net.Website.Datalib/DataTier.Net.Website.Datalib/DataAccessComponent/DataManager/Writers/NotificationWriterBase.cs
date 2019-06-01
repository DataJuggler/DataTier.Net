

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

    #region class NotificationWriterBase
    /// <summary>
    /// This class is used for converting a 'Notification' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class NotificationWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Notification notification)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='notification'>The 'Notification' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Notification notification)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (notification != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", notification.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteNotificationStoredProcedure(Notification notification)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteNotification'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Notification_Delete'.
            /// </summary>
            /// <param name="notification">The 'Notification' to Delete.</param>
            /// <returns>An instance of a 'DeleteNotificationStoredProcedure' object.</returns>
            public static DeleteNotificationStoredProcedure CreateDeleteNotificationStoredProcedure(Notification notification)
            {
                // Initial Value
                DeleteNotificationStoredProcedure deleteNotificationStoredProcedure = new DeleteNotificationStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteNotificationStoredProcedure.Parameters = CreatePrimaryKeyParameter(notification);

                // return value
                return deleteNotificationStoredProcedure;
            }
            #endregion

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
            public static FindNotificationStoredProcedure CreateFindNotificationStoredProcedure(Notification notification)
            {
                // Initial Value
                FindNotificationStoredProcedure findNotificationStoredProcedure = null;

                // verify notification exists
                if(notification != null)
                {
                    // Instanciate findNotificationStoredProcedure
                    findNotificationStoredProcedure = new FindNotificationStoredProcedure();

                    // Now create parameters for this procedure
                    findNotificationStoredProcedure.Parameters = CreatePrimaryKeyParameter(notification);
                }

                // return value
                return findNotificationStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Notification notification)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new notification.
            /// </summary>
            /// <param name="notification">The 'Notification' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Notification notification)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify notificationexists
                if(notification != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", notification.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If notification.CreatedDate does not exist.
                    if ((notification.CreatedDate == null) || (notification.CreatedDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = notification.CreatedDate;
                    }

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [EmailAddress] parameter
                    param = new SqlParameter("@EmailAddress", notification.EmailAddress);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [GitHubUserName] parameter
                    param = new SqlParameter("@GitHubUserName", notification.GitHubUserName);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [LastSentDate] parameter
                    param = new SqlParameter("@LastSentDate", notification.LastSentDate);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [NotificationType] parameter
                    param = new SqlParameter("@NotificationType", notification.NotificationType);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Verified] parameter
                    param = new SqlParameter("@Verified", notification.Verified);

                    // set parameters[6]
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertNotificationStoredProcedure(Notification notification)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertNotificationStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Notification_Insert'.
            /// </summary>
            /// <param name="notification"The 'Notification' object to insert</param>
            /// <returns>An instance of a 'InsertNotificationStoredProcedure' object.</returns>
            public static InsertNotificationStoredProcedure CreateInsertNotificationStoredProcedure(Notification notification)
            {
                // Initial Value
                InsertNotificationStoredProcedure insertNotificationStoredProcedure = null;

                // verify notification exists
                if(notification != null)
                {
                    // Instanciate insertNotificationStoredProcedure
                    insertNotificationStoredProcedure = new InsertNotificationStoredProcedure();

                    // Now create parameters for this procedure
                    insertNotificationStoredProcedure.Parameters = CreateInsertParameters(notification);
                }

                // return value
                return insertNotificationStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Notification notification)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing notification.
            /// </summary>
            /// <param name="notification">The 'Notification' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Notification notification)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify notificationexists
                if(notification != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", notification.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If notification.CreatedDate does not exist.
                    if ((notification.CreatedDate == null) || (notification.CreatedDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = notification.CreatedDate;
                    }


                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [EmailAddress]
                    param = new SqlParameter("@EmailAddress", notification.EmailAddress);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [GitHubUserName]
                    param = new SqlParameter("@GitHubUserName", notification.GitHubUserName);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [LastSentDate]
                    param = new SqlParameter("@LastSentDate", notification.LastSentDate);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [NotificationType]
                    param = new SqlParameter("@NotificationType", notification.NotificationType);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Verified]
                    param = new SqlParameter("@Verified", notification.Verified);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", notification.Id);
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateNotificationStoredProcedure(Notification notification)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateNotificationStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Notification_Update'.
            /// </summary>
            /// <param name="notification"The 'Notification' object to update</param>
            /// <returns>An instance of a 'UpdateNotificationStoredProcedure</returns>
            public static UpdateNotificationStoredProcedure CreateUpdateNotificationStoredProcedure(Notification notification)
            {
                // Initial Value
                UpdateNotificationStoredProcedure updateNotificationStoredProcedure = null;

                // verify notification exists
                if(notification != null)
                {
                    // Instanciate updateNotificationStoredProcedure
                    updateNotificationStoredProcedure = new UpdateNotificationStoredProcedure();

                    // Now create parameters for this procedure
                    updateNotificationStoredProcedure.Parameters = CreateUpdateParameters(notification);
                }

                // return value
                return updateNotificationStoredProcedure;
            }
            #endregion

            #region CreateFetchAllNotificationsStoredProcedure(Notification notification)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllNotificationsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Notification_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllNotificationsStoredProcedure' object.</returns>
            public static FetchAllNotificationsStoredProcedure CreateFetchAllNotificationsStoredProcedure(Notification notification)
            {
                // Initial value
                FetchAllNotificationsStoredProcedure fetchAllNotificationsStoredProcedure = new FetchAllNotificationsStoredProcedure();

                // return value
                return fetchAllNotificationsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
