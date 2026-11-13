

#region using statements

using System;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using System.Data;
using Microsoft.Data.SqlClient;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class BuildExcludesWriterBase
    /// <summary>
    /// This class is used for converting a 'BuildExcludes' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class BuildExcludesWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='buildExcludes'>The 'BuildExcludes' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(BuildExcludes buildExcludes)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (buildExcludes != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", buildExcludes.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteBuildExcludes'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_Delete'.
            /// </summary>
            /// <param name="buildExcludes">The 'BuildExcludes' to Delete.</param>
            /// <returns>An instance of a 'DeleteBuildExcludesStoredProcedure' object.</returns>
            public static DeleteBuildExcludesStoredProcedure CreateDeleteBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial Value
                DeleteBuildExcludesStoredProcedure deleteBuildExcludesStoredProcedure = new DeleteBuildExcludesStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteBuildExcludesStoredProcedure.Parameters = CreatePrimaryKeyParameter(buildExcludes);

                // return value
                return deleteBuildExcludesStoredProcedure;
            }
            #endregion

            #region CreateFindBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindBuildExcludesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_Find'.
            /// </summary>
            /// <param name="buildExcludes">The 'BuildExcludes' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindBuildExcludesStoredProcedure CreateFindBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial Value
                FindBuildExcludesStoredProcedure findBuildExcludesStoredProcedure = null;

                // verify buildExcludes exists
                if(buildExcludes != null)
                {
                    // Instanciate findBuildExcludesStoredProcedure
                    findBuildExcludesStoredProcedure = new FindBuildExcludesStoredProcedure();

                    // Now create parameters for this procedure
                    findBuildExcludesStoredProcedure.Parameters = CreatePrimaryKeyParameter(buildExcludes);
                }

                // return value
                return findBuildExcludesStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new buildExcludes.
            /// </summary>
            /// <param name="buildExcludes">The 'BuildExcludes' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(BuildExcludes buildExcludes)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify buildExcludesexists
                if(buildExcludes != null)
                {
                    // Create [DatabaseId] parameter
                    param = new SqlParameter("@DatabaseId", buildExcludes.DatabaseId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ExcludeDelete] parameter
                    param = new SqlParameter("@ExcludeDelete", buildExcludes.ExcludeDelete);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [ExcludeFetchAll] parameter
                    param = new SqlParameter("@ExcludeFetchAll", buildExcludes.ExcludeFetchAll);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [ExcludeFind] parameter
                    param = new SqlParameter("@ExcludeFind", buildExcludes.ExcludeFind);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [ExcludeInsert] parameter
                    param = new SqlParameter("@ExcludeInsert", buildExcludes.ExcludeInsert);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [ExcludeUpdate] parameter
                    param = new SqlParameter("@ExcludeUpdate", buildExcludes.ExcludeUpdate);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", buildExcludes.ProjectId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [TableId] parameter
                    param = new SqlParameter("@TableId", buildExcludes.TableId);

                    // set parameters[7]
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertBuildExcludesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_Insert'.
            /// </summary>
            /// <param name="buildExcludes"The 'BuildExcludes' object to insert</param>
            /// <returns>An instance of a 'InsertBuildExcludesStoredProcedure' object.</returns>
            public static InsertBuildExcludesStoredProcedure CreateInsertBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial Value
                InsertBuildExcludesStoredProcedure insertBuildExcludesStoredProcedure = null;

                // verify buildExcludes exists
                if(buildExcludes != null)
                {
                    // Instanciate insertBuildExcludesStoredProcedure
                    insertBuildExcludesStoredProcedure = new InsertBuildExcludesStoredProcedure();

                    // Now create parameters for this procedure
                    insertBuildExcludesStoredProcedure.Parameters = CreateInsertParameters(buildExcludes);
                }

                // return value
                return insertBuildExcludesStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing buildExcludes.
            /// </summary>
            /// <param name="buildExcludes">The 'BuildExcludes' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(BuildExcludes buildExcludes)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify buildExcludesexists
                if(buildExcludes != null)
                {
                    // Create parameter for [DatabaseId]
                    param = new SqlParameter("@DatabaseId", buildExcludes.DatabaseId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ExcludeDelete]
                    param = new SqlParameter("@ExcludeDelete", buildExcludes.ExcludeDelete);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ExcludeFetchAll]
                    param = new SqlParameter("@ExcludeFetchAll", buildExcludes.ExcludeFetchAll);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [ExcludeFind]
                    param = new SqlParameter("@ExcludeFind", buildExcludes.ExcludeFind);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [ExcludeInsert]
                    param = new SqlParameter("@ExcludeInsert", buildExcludes.ExcludeInsert);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [ExcludeUpdate]
                    param = new SqlParameter("@ExcludeUpdate", buildExcludes.ExcludeUpdate);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", buildExcludes.ProjectId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", buildExcludes.TableId);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", buildExcludes.Id);
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateBuildExcludesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_Update'.
            /// </summary>
            /// <param name="buildExcludes"The 'BuildExcludes' object to update</param>
            /// <returns>An instance of a 'UpdateBuildExcludesStoredProcedure</returns>
            public static UpdateBuildExcludesStoredProcedure CreateUpdateBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial Value
                UpdateBuildExcludesStoredProcedure updateBuildExcludesStoredProcedure = null;

                // verify buildExcludes exists
                if(buildExcludes != null)
                {
                    // Instanciate updateBuildExcludesStoredProcedure
                    updateBuildExcludesStoredProcedure = new UpdateBuildExcludesStoredProcedure();

                    // Now create parameters for this procedure
                    updateBuildExcludesStoredProcedure.Parameters = CreateUpdateParameters(buildExcludes);
                }

                // return value
                return updateBuildExcludesStoredProcedure;
            }
            #endregion

            #region CreateFetchAllBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllBuildExcludesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllBuildExcludesStoredProcedure' object.</returns>
            public static FetchAllBuildExcludesStoredProcedure CreateFetchAllBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial value
                FetchAllBuildExcludesStoredProcedure fetchAllBuildExcludesStoredProcedure = new FetchAllBuildExcludesStoredProcedure();

                // return value
                return fetchAllBuildExcludesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
