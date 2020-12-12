

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class DTNProcedureWriterBase
    /// <summary>
    /// This class is used for converting a 'DTNProcedure' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNProcedureWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(DTNProcedure dTNProcedure)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (dTNProcedure != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @ProcedureId = new SqlParameter("@ProcedureId", dTNProcedure.ProcedureId);

                    // Set parameters[0] to @ProcedureId
                    parameters[0] = @ProcedureId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDTNProcedure'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNProcedure_Delete'.
            /// </summary>
            /// <param name="dTNProcedure">The 'DTNProcedure' to Delete.</param>
            /// <returns>An instance of a 'DeleteDTNProcedureStoredProcedure' object.</returns>
            public static DeleteDTNProcedureStoredProcedure CreateDeleteDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            {
                // Initial Value
                DeleteDTNProcedureStoredProcedure deleteDTNProcedureStoredProcedure = new DeleteDTNProcedureStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteDTNProcedureStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNProcedure);

                // return value
                return deleteDTNProcedureStoredProcedure;
            }
            #endregion

            #region CreateFindDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindDTNProcedureStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNProcedure_Find'.
            /// </summary>
            /// <param name="dTNProcedure">The 'DTNProcedure' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindDTNProcedureStoredProcedure CreateFindDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            {
                // Initial Value
                FindDTNProcedureStoredProcedure findDTNProcedureStoredProcedure = null;

                // verify dTNProcedure exists
                if(dTNProcedure != null)
                {
                    // Instanciate findDTNProcedureStoredProcedure
                    findDTNProcedureStoredProcedure = new FindDTNProcedureStoredProcedure();

                    // Now create parameters for this procedure
                    findDTNProcedureStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNProcedure);
                }

                // return value
                return findDTNProcedureStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new dTNProcedure.
            /// </summary>
            /// <param name="dTNProcedure">The 'DTNProcedure' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(DTNProcedure dTNProcedure)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify dTNProcedureexists
                if(dTNProcedure != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", dTNProcedure.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", dTNProcedure.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", dTNProcedure.ProjectId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [TableId] parameter
                    param = new SqlParameter("@TableId", dTNProcedure.TableId);

                    // set parameters[3]
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertDTNProcedureStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNProcedure_Insert'.
            /// </summary>
            /// <param name="dTNProcedure"The 'DTNProcedure' object to insert</param>
            /// <returns>An instance of a 'InsertDTNProcedureStoredProcedure' object.</returns>
            public static InsertDTNProcedureStoredProcedure CreateInsertDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            {
                // Initial Value
                InsertDTNProcedureStoredProcedure insertDTNProcedureStoredProcedure = null;

                // verify dTNProcedure exists
                if(dTNProcedure != null)
                {
                    // Instanciate insertDTNProcedureStoredProcedure
                    insertDTNProcedureStoredProcedure = new InsertDTNProcedureStoredProcedure();

                    // Now create parameters for this procedure
                    insertDTNProcedureStoredProcedure.Parameters = CreateInsertParameters(dTNProcedure);
                }

                // return value
                return insertDTNProcedureStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing dTNProcedure.
            /// </summary>
            /// <param name="dTNProcedure">The 'DTNProcedure' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(DTNProcedure dTNProcedure)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify dTNProcedureexists
                if(dTNProcedure != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", dTNProcedure.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", dTNProcedure.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", dTNProcedure.ProjectId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", dTNProcedure.TableId);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [ProcedureId]
                    param = new SqlParameter("@ProcedureId", dTNProcedure.ProcedureId);
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateDTNProcedureStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNProcedure_Update'.
            /// </summary>
            /// <param name="dTNProcedure"The 'DTNProcedure' object to update</param>
            /// <returns>An instance of a 'UpdateDTNProcedureStoredProcedure</returns>
            public static UpdateDTNProcedureStoredProcedure CreateUpdateDTNProcedureStoredProcedure(DTNProcedure dTNProcedure)
            {
                // Initial Value
                UpdateDTNProcedureStoredProcedure updateDTNProcedureStoredProcedure = null;

                // verify dTNProcedure exists
                if(dTNProcedure != null)
                {
                    // Instanciate updateDTNProcedureStoredProcedure
                    updateDTNProcedureStoredProcedure = new UpdateDTNProcedureStoredProcedure();

                    // Now create parameters for this procedure
                    updateDTNProcedureStoredProcedure.Parameters = CreateUpdateParameters(dTNProcedure);
                }

                // return value
                return updateDTNProcedureStoredProcedure;
            }
            #endregion

            #region CreateFetchAllDTNProceduresStoredProcedure(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNProceduresStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNProcedure_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNProceduresStoredProcedure' object.</returns>
            public static FetchAllDTNProceduresStoredProcedure CreateFetchAllDTNProceduresStoredProcedure(DTNProcedure dTNProcedure)
            {
                // Initial value
                FetchAllDTNProceduresStoredProcedure fetchAllDTNProceduresStoredProcedure = new FetchAllDTNProceduresStoredProcedure();

                // return value
                return fetchAllDTNProceduresStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
