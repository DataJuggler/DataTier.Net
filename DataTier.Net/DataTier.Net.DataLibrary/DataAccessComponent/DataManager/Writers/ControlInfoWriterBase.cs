

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

    #region class ControlInfoWriterBase
    /// <summary>
    /// This class is used for converting a 'ControlInfo' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ControlInfoWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ControlInfo controlInfo)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='controlInfo'>The 'ControlInfo' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ControlInfo controlInfo)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (controlInfo != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", controlInfo.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteControlInfoStoredProcedure(ControlInfo controlInfo)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteControlInfo'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfo_Delete'.
            /// </summary>
            /// <param name="controlInfo">The 'ControlInfo' to Delete.</param>
            /// <returns>An instance of a 'DeleteControlInfoStoredProcedure' object.</returns>
            public static DeleteControlInfoStoredProcedure CreateDeleteControlInfoStoredProcedure(ControlInfo controlInfo)
            {
                // Initial Value
                DeleteControlInfoStoredProcedure deleteControlInfoStoredProcedure = new DeleteControlInfoStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteControlInfoStoredProcedure.Parameters = CreatePrimaryKeyParameter(controlInfo);

                // return value
                return deleteControlInfoStoredProcedure;
            }
            #endregion

            #region CreateFindControlInfoStoredProcedure(ControlInfo controlInfo)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindControlInfoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfo_Find'.
            /// </summary>
            /// <param name="controlInfo">The 'ControlInfo' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindControlInfoStoredProcedure CreateFindControlInfoStoredProcedure(ControlInfo controlInfo)
            {
                // Initial Value
                FindControlInfoStoredProcedure findControlInfoStoredProcedure = null;

                // verify controlInfo exists
                if(controlInfo != null)
                {
                    // Instanciate findControlInfoStoredProcedure
                    findControlInfoStoredProcedure = new FindControlInfoStoredProcedure();

                    // Now create parameters for this procedure
                    findControlInfoStoredProcedure.Parameters = CreatePrimaryKeyParameter(controlInfo);
                }

                // return value
                return findControlInfoStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ControlInfo controlInfo)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new controlInfo.
            /// </summary>
            /// <param name="controlInfo">The 'ControlInfo' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ControlInfo controlInfo)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify controlInfoexists
                if(controlInfo != null)
                {
                    // Create [Name] parameter
                    param = new SqlParameter("@Name", controlInfo.Name);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [PackageName] parameter
                    param = new SqlParameter("@PackageName", controlInfo.PackageName);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertControlInfoStoredProcedure(ControlInfo controlInfo)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertControlInfoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfo_Insert'.
            /// </summary>
            /// <param name="controlInfo"The 'ControlInfo' object to insert</param>
            /// <returns>An instance of a 'InsertControlInfoStoredProcedure' object.</returns>
            public static InsertControlInfoStoredProcedure CreateInsertControlInfoStoredProcedure(ControlInfo controlInfo)
            {
                // Initial Value
                InsertControlInfoStoredProcedure insertControlInfoStoredProcedure = null;

                // verify controlInfo exists
                if(controlInfo != null)
                {
                    // Instanciate insertControlInfoStoredProcedure
                    insertControlInfoStoredProcedure = new InsertControlInfoStoredProcedure();

                    // Now create parameters for this procedure
                    insertControlInfoStoredProcedure.Parameters = CreateInsertParameters(controlInfo);
                }

                // return value
                return insertControlInfoStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ControlInfo controlInfo)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing controlInfo.
            /// </summary>
            /// <param name="controlInfo">The 'ControlInfo' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ControlInfo controlInfo)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify controlInfoexists
                if(controlInfo != null)
                {
                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", controlInfo.Name);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [PackageName]
                    param = new SqlParameter("@PackageName", controlInfo.PackageName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", controlInfo.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateControlInfoStoredProcedure(ControlInfo controlInfo)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateControlInfoStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfo_Update'.
            /// </summary>
            /// <param name="controlInfo"The 'ControlInfo' object to update</param>
            /// <returns>An instance of a 'UpdateControlInfoStoredProcedure</returns>
            public static UpdateControlInfoStoredProcedure CreateUpdateControlInfoStoredProcedure(ControlInfo controlInfo)
            {
                // Initial Value
                UpdateControlInfoStoredProcedure updateControlInfoStoredProcedure = null;

                // verify controlInfo exists
                if(controlInfo != null)
                {
                    // Instanciate updateControlInfoStoredProcedure
                    updateControlInfoStoredProcedure = new UpdateControlInfoStoredProcedure();

                    // Now create parameters for this procedure
                    updateControlInfoStoredProcedure.Parameters = CreateUpdateParameters(controlInfo);
                }

                // return value
                return updateControlInfoStoredProcedure;
            }
            #endregion

            #region CreateFetchAllControlInfosStoredProcedure(ControlInfo controlInfo)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllControlInfosStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfo_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllControlInfosStoredProcedure' object.</returns>
            public static FetchAllControlInfosStoredProcedure CreateFetchAllControlInfosStoredProcedure(ControlInfo controlInfo)
            {
                // Initial value
                FetchAllControlInfosStoredProcedure fetchAllControlInfosStoredProcedure = new FetchAllControlInfosStoredProcedure();

                // return value
                return fetchAllControlInfosStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
