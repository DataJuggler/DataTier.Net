

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

    #region class NotificationHistoryWriterBase
    /// <summary>
    /// This class is used for converting a 'NotificationHistory' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class NotificationHistoryWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='notificationHistory'>The 'NotificationHistory' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(NotificationHistory notificationHistory)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (notificationHistory != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", notificationHistory.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteNotificationHistory'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'NotificationHistory_Delete'.
            /// </summary>
            /// <param name="notificationHistory">The 'NotificationHistory' to Delete.</param>
            /// <returns>An instance of a 'DeleteNotificationHistoryStoredProcedure' object.</returns>
            public static DeleteNotificationHistoryStoredProcedure CreateDeleteNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            {
                // Initial Value
                DeleteNotificationHistoryStoredProcedure deleteNotificationHistoryStoredProcedure = new DeleteNotificationHistoryStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteNotificationHistoryStoredProcedure.Parameters = CreatePrimaryKeyParameter(notificationHistory);

                // return value
                return deleteNotificationHistoryStoredProcedure;
            }
            #endregion

            #region CreateFindNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindNotificationHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'NotificationHistory_Find'.
            /// </summary>
            /// <param name="notificationHistory">The 'NotificationHistory' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindNotificationHistoryStoredProcedure CreateFindNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            {
                // Initial Value
                FindNotificationHistoryStoredProcedure findNotificationHistoryStoredProcedure = null;

                // verify notificationHistory exists
                if(notificationHistory != null)
                {
                    // Instanciate findNotificationHistoryStoredProcedure
                    findNotificationHistoryStoredProcedure = new FindNotificationHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    findNotificationHistoryStoredProcedure.Parameters = CreatePrimaryKeyParameter(notificationHistory);
                }

                // return value
                return findNotificationHistoryStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new notificationHistory.
            /// </summary>
            /// <param name="notificationHistory">The 'NotificationHistory' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(NotificationHistory notificationHistory)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify notificationHistoryexists
                if(notificationHistory != null)
                {
                    // Create [Delivered] parameter
                    param = new SqlParameter("@Delivered", notificationHistory.Delivered);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Id] parameter
                    param = new SqlParameter("@Id", notificationHistory.Id);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [NotificationId] parameter
                    param = new SqlParameter("@NotificationId", notificationHistory.NotificationId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [SendDate] Parameter
                    param = new SqlParameter("@SendDate", SqlDbType.DateTime);

                    // If notificationHistory.SendDate does not exist.
                    if ((notificationHistory.SendDate == null) || (notificationHistory.SendDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = notificationHistory.SendDate;
                    }

                    // set parameters[3]
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertNotificationHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'NotificationHistory_Insert'.
            /// </summary>
            /// <param name="notificationHistory"The 'NotificationHistory' object to insert</param>
            /// <returns>An instance of a 'InsertNotificationHistoryStoredProcedure' object.</returns>
            public static InsertNotificationHistoryStoredProcedure CreateInsertNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            {
                // Initial Value
                InsertNotificationHistoryStoredProcedure insertNotificationHistoryStoredProcedure = null;

                // verify notificationHistory exists
                if(notificationHistory != null)
                {
                    // Instanciate insertNotificationHistoryStoredProcedure
                    insertNotificationHistoryStoredProcedure = new InsertNotificationHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    insertNotificationHistoryStoredProcedure.Parameters = CreateInsertParameters(notificationHistory);
                }

                // return value
                return insertNotificationHistoryStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing notificationHistory.
            /// </summary>
            /// <param name="notificationHistory">The 'NotificationHistory' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(NotificationHistory notificationHistory)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify notificationHistoryexists
                if(notificationHistory != null)
                {
                    // Create parameter for [Delivered]
                    param = new SqlParameter("@Delivered", notificationHistory.Delivered);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [NotificationId]
                    param = new SqlParameter("@NotificationId", notificationHistory.NotificationId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [SendDate]
                    // Create [SendDate] Parameter
                    param = new SqlParameter("@SendDate", SqlDbType.DateTime);

                    // If notificationHistory.SendDate does not exist.
                    if ((notificationHistory.SendDate == null) || (notificationHistory.SendDate.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = notificationHistory.SendDate;
                    }


                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", notificationHistory.Id);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateNotificationHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'NotificationHistory_Update'.
            /// </summary>
            /// <param name="notificationHistory"The 'NotificationHistory' object to update</param>
            /// <returns>An instance of a 'UpdateNotificationHistoryStoredProcedure</returns>
            public static UpdateNotificationHistoryStoredProcedure CreateUpdateNotificationHistoryStoredProcedure(NotificationHistory notificationHistory)
            {
                // Initial Value
                UpdateNotificationHistoryStoredProcedure updateNotificationHistoryStoredProcedure = null;

                // verify notificationHistory exists
                if(notificationHistory != null)
                {
                    // Instanciate updateNotificationHistoryStoredProcedure
                    updateNotificationHistoryStoredProcedure = new UpdateNotificationHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    updateNotificationHistoryStoredProcedure.Parameters = CreateUpdateParameters(notificationHistory);
                }

                // return value
                return updateNotificationHistoryStoredProcedure;
            }
            #endregion

            #region CreateFetchAllNotificationHistorysStoredProcedure(NotificationHistory notificationHistory)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllNotificationHistorysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'NotificationHistory_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllNotificationHistorysStoredProcedure' object.</returns>
            public static FetchAllNotificationHistorysStoredProcedure CreateFetchAllNotificationHistorysStoredProcedure(NotificationHistory notificationHistory)
            {
                // Initial value
                FetchAllNotificationHistorysStoredProcedure fetchAllNotificationHistorysStoredProcedure = new FetchAllNotificationHistorysStoredProcedure();

                // return value
                return fetchAllNotificationHistorysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
