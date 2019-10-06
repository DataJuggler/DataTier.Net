

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

    #region class AdminWriterBase
    /// <summary>
    /// This class is used for converting a 'Admin' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class AdminWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Admin admin)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='admin'>The 'Admin' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Admin admin)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (admin != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @AdminId = new SqlParameter("@AdminId", admin.AdminId);

                    // Set parameters[0] to @AdminId
                    parameters[0] = @AdminId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteAdmin'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Delete'.
            /// </summary>
            /// <param name="admin">The 'Admin' to Delete.</param>
            /// <returns>An instance of a 'DeleteAdminStoredProcedure' object.</returns>
            public static DeleteAdminStoredProcedure CreateDeleteAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                DeleteAdminStoredProcedure deleteAdminStoredProcedure = new DeleteAdminStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteAdminStoredProcedure.Parameters = CreatePrimaryKeyParameter(admin);

                // return value
                return deleteAdminStoredProcedure;
            }
            #endregion

            #region CreateFindAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindAdminStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Find'.
            /// </summary>
            /// <param name="admin">The 'Admin' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindAdminStoredProcedure CreateFindAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                FindAdminStoredProcedure findAdminStoredProcedure = null;

                // verify admin exists
                if(admin != null)
                {
                    // Instanciate findAdminStoredProcedure
                    findAdminStoredProcedure = new FindAdminStoredProcedure();

                    // Now create parameters for this procedure
                    findAdminStoredProcedure.Parameters = CreatePrimaryKeyParameter(admin);
                }

                // return value
                return findAdminStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Admin admin)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new admin.
            /// </summary>
            /// <param name="admin">The 'Admin' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Admin admin)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify adminexists
                if(admin != null)
                {
                    // Create [CheckForUpdates] parameter
                    param = new SqlParameter("@CheckForUpdates", admin.CheckForUpdates);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [CodeVersion] parameter
                    param = new SqlParameter("@CodeVersion", admin.CodeVersion);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [GitCommit] parameter
                    param = new SqlParameter("@GitCommit", admin.GitCommit);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [LastUpdated] Parameter
                    param = new SqlParameter("@LastUpdated", SqlDbType.DateTime);

                    // If admin.LastUpdated does not exist.
                    if ((admin.LastUpdated == null) || (admin.LastUpdated.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = admin.LastUpdated;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [SchemaHash] parameter
                    param = new SqlParameter("@SchemaHash", admin.SchemaHash);

                    // set parameters[4]
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertAdminStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Insert'.
            /// </summary>
            /// <param name="admin"The 'Admin' object to insert</param>
            /// <returns>An instance of a 'InsertAdminStoredProcedure' object.</returns>
            public static InsertAdminStoredProcedure CreateInsertAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                InsertAdminStoredProcedure insertAdminStoredProcedure = null;

                // verify admin exists
                if(admin != null)
                {
                    // Instanciate insertAdminStoredProcedure
                    insertAdminStoredProcedure = new InsertAdminStoredProcedure();

                    // Now create parameters for this procedure
                    insertAdminStoredProcedure.Parameters = CreateInsertParameters(admin);
                }

                // return value
                return insertAdminStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Admin admin)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing admin.
            /// </summary>
            /// <param name="admin">The 'Admin' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Admin admin)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify adminexists
                if(admin != null)
                {
                    // Create parameter for [CheckForUpdates]
                    param = new SqlParameter("@CheckForUpdates", admin.CheckForUpdates);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [CodeVersion]
                    param = new SqlParameter("@CodeVersion", admin.CodeVersion);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [GitCommit]
                    param = new SqlParameter("@GitCommit", admin.GitCommit);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [LastUpdated]
                    // Create [LastUpdated] Parameter
                    param = new SqlParameter("@LastUpdated", SqlDbType.DateTime);

                    // If admin.LastUpdated does not exist.
                    if ((admin.LastUpdated == null) || (admin.LastUpdated.Year < 1900))
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = admin.LastUpdated;
                    }


                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [SchemaHash]
                    param = new SqlParameter("@SchemaHash", admin.SchemaHash);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [AdminId]
                    param = new SqlParameter("@AdminId", admin.AdminId);
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateAdminStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Update'.
            /// </summary>
            /// <param name="admin"The 'Admin' object to update</param>
            /// <returns>An instance of a 'UpdateAdminStoredProcedure</returns>
            public static UpdateAdminStoredProcedure CreateUpdateAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                UpdateAdminStoredProcedure updateAdminStoredProcedure = null;

                // verify admin exists
                if(admin != null)
                {
                    // Instanciate updateAdminStoredProcedure
                    updateAdminStoredProcedure = new UpdateAdminStoredProcedure();

                    // Now create parameters for this procedure
                    updateAdminStoredProcedure.Parameters = CreateUpdateParameters(admin);
                }

                // return value
                return updateAdminStoredProcedure;
            }
            #endregion

            #region CreateFetchAllAdminsStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllAdminsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllAdminsStoredProcedure' object.</returns>
            public static FetchAllAdminsStoredProcedure CreateFetchAllAdminsStoredProcedure(Admin admin)
            {
                // Initial value
                FetchAllAdminsStoredProcedure fetchAllAdminsStoredProcedure = new FetchAllAdminsStoredProcedure();

                // return value
                return fetchAllAdminsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
