

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

    #region class GitHubFollowerWriterBase
    /// <summary>
    /// This class is used for converting a 'GitHubFollower' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class GitHubFollowerWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='gitHubFollower'>The 'GitHubFollower' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(GitHubFollower gitHubFollower)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (gitHubFollower != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", gitHubFollower.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteGitHubFollower'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'GitHubFollower_Delete'.
            /// </summary>
            /// <param name="gitHubFollower">The 'GitHubFollower' to Delete.</param>
            /// <returns>An instance of a 'DeleteGitHubFollowerStoredProcedure' object.</returns>
            public static DeleteGitHubFollowerStoredProcedure CreateDeleteGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            {
                // Initial Value
                DeleteGitHubFollowerStoredProcedure deleteGitHubFollowerStoredProcedure = new DeleteGitHubFollowerStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteGitHubFollowerStoredProcedure.Parameters = CreatePrimaryKeyParameter(gitHubFollower);

                // return value
                return deleteGitHubFollowerStoredProcedure;
            }
            #endregion

            #region CreateFindGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindGitHubFollowerStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'GitHubFollower_Find'.
            /// </summary>
            /// <param name="gitHubFollower">The 'GitHubFollower' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindGitHubFollowerStoredProcedure CreateFindGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            {
                // Initial Value
                FindGitHubFollowerStoredProcedure findGitHubFollowerStoredProcedure = null;

                // verify gitHubFollower exists
                if(gitHubFollower != null)
                {
                    // Instanciate findGitHubFollowerStoredProcedure
                    findGitHubFollowerStoredProcedure = new FindGitHubFollowerStoredProcedure();

                    // Now create parameters for this procedure
                    findGitHubFollowerStoredProcedure.Parameters = CreatePrimaryKeyParameter(gitHubFollower);
                }

                // return value
                return findGitHubFollowerStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new gitHubFollower.
            /// </summary>
            /// <param name="gitHubFollower">The 'GitHubFollower' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(GitHubFollower gitHubFollower)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify gitHubFollowerexists
                if(gitHubFollower != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", gitHubFollower.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [EmailAddress] parameter
                    param = new SqlParameter("@EmailAddress", gitHubFollower.EmailAddress);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [FollowerName] parameter
                    param = new SqlParameter("@FollowerName", gitHubFollower.FollowerName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [FollowerSince] Parameter
                    param = new SqlParameter("@FollowerSince", SqlDbType.DateTime);

                    // If gitHubFollower.FollowerSince does not exist.
                    if ((gitHubFollower.FollowerSince == null) || (gitHubFollower.FollowerSince.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = gitHubFollower.FollowerSince;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [NotificationId] parameter
                    param = new SqlParameter("@NotificationId", gitHubFollower.NotificationId);

                    // set parameters[4]
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertGitHubFollowerStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'GitHubFollower_Insert'.
            /// </summary>
            /// <param name="gitHubFollower"The 'GitHubFollower' object to insert</param>
            /// <returns>An instance of a 'InsertGitHubFollowerStoredProcedure' object.</returns>
            public static InsertGitHubFollowerStoredProcedure CreateInsertGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            {
                // Initial Value
                InsertGitHubFollowerStoredProcedure insertGitHubFollowerStoredProcedure = null;

                // verify gitHubFollower exists
                if(gitHubFollower != null)
                {
                    // Instanciate insertGitHubFollowerStoredProcedure
                    insertGitHubFollowerStoredProcedure = new InsertGitHubFollowerStoredProcedure();

                    // Now create parameters for this procedure
                    insertGitHubFollowerStoredProcedure.Parameters = CreateInsertParameters(gitHubFollower);
                }

                // return value
                return insertGitHubFollowerStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing gitHubFollower.
            /// </summary>
            /// <param name="gitHubFollower">The 'GitHubFollower' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(GitHubFollower gitHubFollower)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify gitHubFollowerexists
                if(gitHubFollower != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", gitHubFollower.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [EmailAddress]
                    param = new SqlParameter("@EmailAddress", gitHubFollower.EmailAddress);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [FollowerName]
                    param = new SqlParameter("@FollowerName", gitHubFollower.FollowerName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [FollowerSince]
                    // Create [FollowerSince] Parameter
                    param = new SqlParameter("@FollowerSince", SqlDbType.DateTime);

                    // If gitHubFollower.FollowerSince does not exist.
                    if ((gitHubFollower.FollowerSince == null) || (gitHubFollower.FollowerSince.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = gitHubFollower.FollowerSince;
                    }


                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [NotificationId]
                    param = new SqlParameter("@NotificationId", gitHubFollower.NotificationId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", gitHubFollower.Id);
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateGitHubFollowerStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'GitHubFollower_Update'.
            /// </summary>
            /// <param name="gitHubFollower"The 'GitHubFollower' object to update</param>
            /// <returns>An instance of a 'UpdateGitHubFollowerStoredProcedure</returns>
            public static UpdateGitHubFollowerStoredProcedure CreateUpdateGitHubFollowerStoredProcedure(GitHubFollower gitHubFollower)
            {
                // Initial Value
                UpdateGitHubFollowerStoredProcedure updateGitHubFollowerStoredProcedure = null;

                // verify gitHubFollower exists
                if(gitHubFollower != null)
                {
                    // Instanciate updateGitHubFollowerStoredProcedure
                    updateGitHubFollowerStoredProcedure = new UpdateGitHubFollowerStoredProcedure();

                    // Now create parameters for this procedure
                    updateGitHubFollowerStoredProcedure.Parameters = CreateUpdateParameters(gitHubFollower);
                }

                // return value
                return updateGitHubFollowerStoredProcedure;
            }
            #endregion

            #region CreateFetchAllGitHubFollowersStoredProcedure(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllGitHubFollowersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'GitHubFollower_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllGitHubFollowersStoredProcedure' object.</returns>
            public static FetchAllGitHubFollowersStoredProcedure CreateFetchAllGitHubFollowersStoredProcedure(GitHubFollower gitHubFollower)
            {
                // Initial value
                FetchAllGitHubFollowersStoredProcedure fetchAllGitHubFollowersStoredProcedure = new FetchAllGitHubFollowersStoredProcedure();

                // return value
                return fetchAllGitHubFollowersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
