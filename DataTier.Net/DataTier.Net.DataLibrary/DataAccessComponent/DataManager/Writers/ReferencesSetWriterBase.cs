

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

    #region class ReferencesSetWriterBase
    /// <summary>
    /// This class is used for converting a 'ReferencesSet' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ReferencesSetWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='referencesSet'>The 'ReferencesSet' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ReferencesSet referencesSet)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (referencesSet != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @ReferencesSetId = new SqlParameter("@ReferencesSetId", referencesSet.ReferencesSetId);

                    // Set parameters[0] to @ReferencesSetId
                    parameters[0] = @ReferencesSetId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteReferencesSetStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteReferencesSet'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_Delete'.
            /// </summary>
            /// <param name="referencesSet">The 'ReferencesSet' to Delete.</param>
            /// <returns>An instance of a 'DeleteReferencesSetStoredProcedure' object.</returns>
            public static DeleteReferencesSetStoredProcedure CreateDeleteReferencesSetStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial Value
                DeleteReferencesSetStoredProcedure deleteReferencesSetStoredProcedure = new DeleteReferencesSetStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteReferencesSetStoredProcedure.Parameters = CreatePrimaryKeyParameter(referencesSet);

                // return value
                return deleteReferencesSetStoredProcedure;
            }
            #endregion

            #region CreateFindReferencesSetStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindReferencesSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_Find'.
            /// </summary>
            /// <param name="referencesSet">The 'ReferencesSet' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindReferencesSetStoredProcedure CreateFindReferencesSetStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial Value
                FindReferencesSetStoredProcedure findReferencesSetStoredProcedure = null;

                // verify referencesSet exists
                if(referencesSet != null)
                {
                    // Instanciate findReferencesSetStoredProcedure
                    findReferencesSetStoredProcedure = new FindReferencesSetStoredProcedure();

                    // Now create parameters for this procedure
                    findReferencesSetStoredProcedure.Parameters = CreatePrimaryKeyParameter(referencesSet);
                }

                // return value
                return findReferencesSetStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new referencesSet.
            /// </summary>
            /// <param name="referencesSet">The 'ReferencesSet' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ReferencesSet referencesSet)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify referencesSetexists
                if(referencesSet != null)
                {
                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", referencesSet.ProjectId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ReferencesSetName] parameter
                    param = new SqlParameter("@ReferencesSetName", referencesSet.ReferencesSetName);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertReferencesSetStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertReferencesSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_Insert'.
            /// </summary>
            /// <param name="referencesSet"The 'ReferencesSet' object to insert</param>
            /// <returns>An instance of a 'InsertReferencesSetStoredProcedure' object.</returns>
            public static InsertReferencesSetStoredProcedure CreateInsertReferencesSetStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial Value
                InsertReferencesSetStoredProcedure insertReferencesSetStoredProcedure = null;

                // verify referencesSet exists
                if(referencesSet != null)
                {
                    // Instanciate insertReferencesSetStoredProcedure
                    insertReferencesSetStoredProcedure = new InsertReferencesSetStoredProcedure();

                    // Now create parameters for this procedure
                    insertReferencesSetStoredProcedure.Parameters = CreateInsertParameters(referencesSet);
                }

                // return value
                return insertReferencesSetStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing referencesSet.
            /// </summary>
            /// <param name="referencesSet">The 'ReferencesSet' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ReferencesSet referencesSet)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify referencesSetexists
                if(referencesSet != null)
                {
                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", referencesSet.ProjectId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ReferencesSetName]
                    param = new SqlParameter("@ReferencesSetName", referencesSet.ReferencesSetName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ReferencesSetId]
                    param = new SqlParameter("@ReferencesSetId", referencesSet.ReferencesSetId);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateReferencesSetStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateReferencesSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_Update'.
            /// </summary>
            /// <param name="referencesSet"The 'ReferencesSet' object to update</param>
            /// <returns>An instance of a 'UpdateReferencesSetStoredProcedure</returns>
            public static UpdateReferencesSetStoredProcedure CreateUpdateReferencesSetStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial Value
                UpdateReferencesSetStoredProcedure updateReferencesSetStoredProcedure = null;

                // verify referencesSet exists
                if(referencesSet != null)
                {
                    // Instanciate updateReferencesSetStoredProcedure
                    updateReferencesSetStoredProcedure = new UpdateReferencesSetStoredProcedure();

                    // Now create parameters for this procedure
                    updateReferencesSetStoredProcedure.Parameters = CreateUpdateParameters(referencesSet);
                }

                // return value
                return updateReferencesSetStoredProcedure;
            }
            #endregion

            #region CreateFetchAllReferencesSetsStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllReferencesSetsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllReferencesSetsStoredProcedure' object.</returns>
            public static FetchAllReferencesSetsStoredProcedure CreateFetchAllReferencesSetsStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial value
                FetchAllReferencesSetsStoredProcedure fetchAllReferencesSetsStoredProcedure = new FetchAllReferencesSetsStoredProcedure();

                // return value
                return fetchAllReferencesSetsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
