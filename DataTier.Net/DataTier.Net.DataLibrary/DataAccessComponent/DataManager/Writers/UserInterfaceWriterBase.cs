

#region using statements

using System;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class UserInterfaceWriterBase
    /// <summary>
    /// This class is used for converting a 'UserInterface' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UserInterfaceWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(UserInterface userInterface)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='userInterface'>The 'UserInterface' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(UserInterface userInterface)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (userInterface != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", userInterface.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteUserInterfaceStoredProcedure(UserInterface userInterface)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteUserInterface'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UserInterface_Delete'.
            /// </summary>
            /// <param name="userInterface">The 'UserInterface' to Delete.</param>
            /// <returns>An instance of a 'DeleteUserInterfaceStoredProcedure' object.</returns>
            public static DeleteUserInterfaceStoredProcedure CreateDeleteUserInterfaceStoredProcedure(UserInterface userInterface)
            {
                // Initial Value
                DeleteUserInterfaceStoredProcedure deleteUserInterfaceStoredProcedure = new DeleteUserInterfaceStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteUserInterfaceStoredProcedure.Parameters = CreatePrimaryKeyParameter(userInterface);

                // return value
                return deleteUserInterfaceStoredProcedure;
            }
            #endregion

            #region CreateFindUserInterfaceStoredProcedure(UserInterface userInterface)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindUserInterfaceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UserInterface_Find'.
            /// </summary>
            /// <param name="userInterface">The 'UserInterface' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindUserInterfaceStoredProcedure CreateFindUserInterfaceStoredProcedure(UserInterface userInterface)
            {
                // Initial Value
                FindUserInterfaceStoredProcedure findUserInterfaceStoredProcedure = null;

                // verify userInterface exists
                if(userInterface != null)
                {
                    // Instanciate findUserInterfaceStoredProcedure
                    findUserInterfaceStoredProcedure = new FindUserInterfaceStoredProcedure();

                    // Now create parameters for this procedure
                    findUserInterfaceStoredProcedure.Parameters = CreatePrimaryKeyParameter(userInterface);
                }

                // return value
                return findUserInterfaceStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(UserInterface userInterface)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new userInterface.
            /// </summary>
            /// <param name="userInterface">The 'UserInterface' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(UserInterface userInterface)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify userInterfaceexists
                if(userInterface != null)
                {
                    // Create [DataSourceName] parameter
                    param = new SqlParameter("@DataSourceName", userInterface.DataSourceName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [DataSourceType] parameter
                    param = new SqlParameter("@DataSourceType", userInterface.DataSourceType);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", userInterface.Name);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Path] parameter
                    param = new SqlParameter("@Path", userInterface.Path);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", userInterface.ProjectId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [UIType] parameter
                    param = new SqlParameter("@UIType", userInterface.UIType);

                    // set parameters[5]
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertUserInterfaceStoredProcedure(UserInterface userInterface)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertUserInterfaceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UserInterface_Insert'.
            /// </summary>
            /// <param name="userInterface"The 'UserInterface' object to insert</param>
            /// <returns>An instance of a 'InsertUserInterfaceStoredProcedure' object.</returns>
            public static InsertUserInterfaceStoredProcedure CreateInsertUserInterfaceStoredProcedure(UserInterface userInterface)
            {
                // Initial Value
                InsertUserInterfaceStoredProcedure insertUserInterfaceStoredProcedure = null;

                // verify userInterface exists
                if(userInterface != null)
                {
                    // Instanciate insertUserInterfaceStoredProcedure
                    insertUserInterfaceStoredProcedure = new InsertUserInterfaceStoredProcedure();

                    // Now create parameters for this procedure
                    insertUserInterfaceStoredProcedure.Parameters = CreateInsertParameters(userInterface);
                }

                // return value
                return insertUserInterfaceStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(UserInterface userInterface)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing userInterface.
            /// </summary>
            /// <param name="userInterface">The 'UserInterface' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(UserInterface userInterface)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify userInterfaceexists
                if(userInterface != null)
                {
                    // Create parameter for [DataSourceName]
                    param = new SqlParameter("@DataSourceName", userInterface.DataSourceName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [DataSourceType]
                    param = new SqlParameter("@DataSourceType", userInterface.DataSourceType);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", userInterface.Name);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Path]
                    param = new SqlParameter("@Path", userInterface.Path);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", userInterface.ProjectId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [UIType]
                    param = new SqlParameter("@UIType", userInterface.UIType);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", userInterface.Id);
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateUserInterfaceStoredProcedure(UserInterface userInterface)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateUserInterfaceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UserInterface_Update'.
            /// </summary>
            /// <param name="userInterface"The 'UserInterface' object to update</param>
            /// <returns>An instance of a 'UpdateUserInterfaceStoredProcedure</returns>
            public static UpdateUserInterfaceStoredProcedure CreateUpdateUserInterfaceStoredProcedure(UserInterface userInterface)
            {
                // Initial Value
                UpdateUserInterfaceStoredProcedure updateUserInterfaceStoredProcedure = null;

                // verify userInterface exists
                if(userInterface != null)
                {
                    // Instanciate updateUserInterfaceStoredProcedure
                    updateUserInterfaceStoredProcedure = new UpdateUserInterfaceStoredProcedure();

                    // Now create parameters for this procedure
                    updateUserInterfaceStoredProcedure.Parameters = CreateUpdateParameters(userInterface);
                }

                // return value
                return updateUserInterfaceStoredProcedure;
            }
            #endregion

            #region CreateFetchAllUserInterfacesStoredProcedure(UserInterface userInterface)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllUserInterfacesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UserInterface_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllUserInterfacesStoredProcedure' object.</returns>
            public static FetchAllUserInterfacesStoredProcedure CreateFetchAllUserInterfacesStoredProcedure(UserInterface userInterface)
            {
                // Initial value
                FetchAllUserInterfacesStoredProcedure fetchAllUserInterfacesStoredProcedure = new FetchAllUserInterfacesStoredProcedure();

                // return value
                return fetchAllUserInterfacesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
