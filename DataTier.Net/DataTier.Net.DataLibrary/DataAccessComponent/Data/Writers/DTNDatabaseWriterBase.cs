

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


namespace DataAccessComponent.Data.Writers
{

    #region class DTNDatabaseWriterBase
    /// <summary>
    /// This class is used for converting a 'DTNDatabase' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNDatabaseWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(DTNDatabase dTNDatabase)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (dTNDatabase != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @DatabaseId = new SqlParameter("@DatabaseId", dTNDatabase.DatabaseId);

                    // Set parameters[0] to @DatabaseId
                    parameters[0] = @DatabaseId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDTNDatabase'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_Delete'.
            /// </summary>
            /// <param name="dTNDatabase">The 'DTNDatabase' to Delete.</param>
            /// <returns>An instance of a 'DeleteDTNDatabaseStoredProcedure' object.</returns>
            public static DeleteDTNDatabaseStoredProcedure CreateDeleteDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            {
                // Initial Value
                DeleteDTNDatabaseStoredProcedure deleteDTNDatabaseStoredProcedure = new DeleteDTNDatabaseStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteDTNDatabaseStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNDatabase);

                // return value
                return deleteDTNDatabaseStoredProcedure;
            }
            #endregion

            #region CreateFindDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindDTNDatabaseStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_Find'.
            /// </summary>
            /// <param name="dTNDatabase">The 'DTNDatabase' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindDTNDatabaseStoredProcedure CreateFindDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            {
                // Initial Value
                FindDTNDatabaseStoredProcedure findDTNDatabaseStoredProcedure = null;

                // verify dTNDatabase exists
                if(dTNDatabase != null)
                {
                    // Instanciate findDTNDatabaseStoredProcedure
                    findDTNDatabaseStoredProcedure = new FindDTNDatabaseStoredProcedure();

                    // Now create parameters for this procedure
                    findDTNDatabaseStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNDatabase);
                }

                // return value
                return findDTNDatabaseStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new dTNDatabase.
            /// </summary>
            /// <param name="dTNDatabase">The 'DTNDatabase' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(DTNDatabase dTNDatabase)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[11];
                SqlParameter param = null;

                // verify dTNDatabaseexists
                if(dTNDatabase != null)
                {
                    // Create [AuthenticationType] parameter
                    param = new SqlParameter("@AuthenticationType", dTNDatabase.AuthenticationType);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ConnectionString] parameter
                    param = new SqlParameter("@ConnectionString", dTNDatabase.ConnectionString);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [DatabaseName] parameter
                    param = new SqlParameter("@DatabaseName", dTNDatabase.DatabaseName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [DatabaseType] parameter
                    param = new SqlParameter("@DatabaseType", dTNDatabase.DatabaseType);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [DBPassword] parameter
                    param = new SqlParameter("@DBPassword", dTNDatabase.DBPassword);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [Exclude] parameter
                    param = new SqlParameter("@Exclude", dTNDatabase.Exclude);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Path] parameter
                    param = new SqlParameter("@Path", dTNDatabase.Path);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", dTNDatabase.ProjectId);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [Serializable] parameter
                    param = new SqlParameter("@Serializable", dTNDatabase.Serializable);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [ServerName] parameter
                    param = new SqlParameter("@ServerName", dTNDatabase.ServerName);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [UserId] parameter
                    param = new SqlParameter("@UserId", dTNDatabase.UserId);

                    // set parameters[10]
                    parameters[10] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertDTNDatabaseStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_Insert'.
            /// </summary>
            /// <param name="dTNDatabase"The 'DTNDatabase' object to insert</param>
            /// <returns>An instance of a 'InsertDTNDatabaseStoredProcedure' object.</returns>
            public static InsertDTNDatabaseStoredProcedure CreateInsertDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            {
                // Initial Value
                InsertDTNDatabaseStoredProcedure insertDTNDatabaseStoredProcedure = null;

                // verify dTNDatabase exists
                if(dTNDatabase != null)
                {
                    // Instanciate insertDTNDatabaseStoredProcedure
                    insertDTNDatabaseStoredProcedure = new InsertDTNDatabaseStoredProcedure();

                    // Now create parameters for this procedure
                    insertDTNDatabaseStoredProcedure.Parameters = CreateInsertParameters(dTNDatabase);
                }

                // return value
                return insertDTNDatabaseStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing dTNDatabase.
            /// </summary>
            /// <param name="dTNDatabase">The 'DTNDatabase' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(DTNDatabase dTNDatabase)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[12];
                SqlParameter param = null;

                // verify dTNDatabaseexists
                if(dTNDatabase != null)
                {
                    // Create parameter for [AuthenticationType]
                    param = new SqlParameter("@AuthenticationType", dTNDatabase.AuthenticationType);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ConnectionString]
                    param = new SqlParameter("@ConnectionString", dTNDatabase.ConnectionString);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [DatabaseName]
                    param = new SqlParameter("@DatabaseName", dTNDatabase.DatabaseName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [DatabaseType]
                    param = new SqlParameter("@DatabaseType", dTNDatabase.DatabaseType);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [DBPassword]
                    param = new SqlParameter("@DBPassword", dTNDatabase.DBPassword);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Exclude]
                    param = new SqlParameter("@Exclude", dTNDatabase.Exclude);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Path]
                    param = new SqlParameter("@Path", dTNDatabase.Path);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", dTNDatabase.ProjectId);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Serializable]
                    param = new SqlParameter("@Serializable", dTNDatabase.Serializable);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [ServerName]
                    param = new SqlParameter("@ServerName", dTNDatabase.ServerName);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [UserId]
                    param = new SqlParameter("@UserId", dTNDatabase.UserId);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [DatabaseId]
                    param = new SqlParameter("@DatabaseId", dTNDatabase.DatabaseId);
                    parameters[11] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateDTNDatabaseStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_Update'.
            /// </summary>
            /// <param name="dTNDatabase"The 'DTNDatabase' object to update</param>
            /// <returns>An instance of a 'UpdateDTNDatabaseStoredProcedure</returns>
            public static UpdateDTNDatabaseStoredProcedure CreateUpdateDTNDatabaseStoredProcedure(DTNDatabase dTNDatabase)
            {
                // Initial Value
                UpdateDTNDatabaseStoredProcedure updateDTNDatabaseStoredProcedure = null;

                // verify dTNDatabase exists
                if(dTNDatabase != null)
                {
                    // Instanciate updateDTNDatabaseStoredProcedure
                    updateDTNDatabaseStoredProcedure = new UpdateDTNDatabaseStoredProcedure();

                    // Now create parameters for this procedure
                    updateDTNDatabaseStoredProcedure.Parameters = CreateUpdateParameters(dTNDatabase);
                }

                // return value
                return updateDTNDatabaseStoredProcedure;
            }
            #endregion

            #region CreateFetchAllDTNDatabasesStoredProcedure(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNDatabasesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNDatabasesStoredProcedure' object.</returns>
            public static FetchAllDTNDatabasesStoredProcedure CreateFetchAllDTNDatabasesStoredProcedure(DTNDatabase dTNDatabase)
            {
                // Initial value
                FetchAllDTNDatabasesStoredProcedure fetchAllDTNDatabasesStoredProcedure = new FetchAllDTNDatabasesStoredProcedure();

                // return value
                return fetchAllDTNDatabasesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
