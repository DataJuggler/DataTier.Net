

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class EnumerationWriterBase
    /// <summary>
    /// This class is used for converting a 'Enumeration' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class EnumerationWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Enumeration enumeration)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Enumeration enumeration)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (enumeration != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @EnumerationId = new SqlParameter("@EnumerationId", enumeration.EnumerationId);

                    // Set parameters[0] to @EnumerationId
                    parameters[0] = @EnumerationId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteEnumerationStoredProcedure(Enumeration enumeration)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteEnumeration'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_Delete'.
            /// </summary>
            /// <param name="enumeration">The 'Enumeration' to Delete.</param>
            /// <returns>An instance of a 'DeleteEnumerationStoredProcedure' object.</returns>
            public static DeleteEnumerationStoredProcedure CreateDeleteEnumerationStoredProcedure(Enumeration enumeration)
            {
                // Initial Value
                DeleteEnumerationStoredProcedure deleteEnumerationStoredProcedure = new DeleteEnumerationStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteEnumerationStoredProcedure.Parameters = CreatePrimaryKeyParameter(enumeration);

                // return value
                return deleteEnumerationStoredProcedure;
            }
            #endregion

            #region CreateFindEnumerationStoredProcedure(Enumeration enumeration)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindEnumerationStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_Find'.
            /// </summary>
            /// <param name="enumeration">The 'Enumeration' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindEnumerationStoredProcedure CreateFindEnumerationStoredProcedure(Enumeration enumeration)
            {
                // Initial Value
                FindEnumerationStoredProcedure findEnumerationStoredProcedure = null;

                // verify enumeration exists
                if(enumeration != null)
                {
                    // Instanciate findEnumerationStoredProcedure
                    findEnumerationStoredProcedure = new FindEnumerationStoredProcedure();

                    // Now create parameters for this procedure
                    findEnumerationStoredProcedure.Parameters = CreatePrimaryKeyParameter(enumeration);
                }

                // return value
                return findEnumerationStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Enumeration enumeration)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new enumeration.
            /// </summary>
            /// <param name="enumeration">The 'Enumeration' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Enumeration enumeration)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify enumerationexists
                if(enumeration != null)
                {
                    // Create [EnumerationName] parameter
                    param = new SqlParameter("@EnumerationName", enumeration.EnumerationName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [FieldName] parameter
                    param = new SqlParameter("@FieldName", enumeration.FieldName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", enumeration.ProjectId);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertEnumerationStoredProcedure(Enumeration enumeration)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertEnumerationStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_Insert'.
            /// </summary>
            /// <param name="enumeration"The 'Enumeration' object to insert</param>
            /// <returns>An instance of a 'InsertEnumerationStoredProcedure' object.</returns>
            public static InsertEnumerationStoredProcedure CreateInsertEnumerationStoredProcedure(Enumeration enumeration)
            {
                // Initial Value
                InsertEnumerationStoredProcedure insertEnumerationStoredProcedure = null;

                // verify enumeration exists
                if(enumeration != null)
                {
                    // Instanciate insertEnumerationStoredProcedure
                    insertEnumerationStoredProcedure = new InsertEnumerationStoredProcedure();

                    // Now create parameters for this procedure
                    insertEnumerationStoredProcedure.Parameters = CreateInsertParameters(enumeration);
                }

                // return value
                return insertEnumerationStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Enumeration enumeration)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing enumeration.
            /// </summary>
            /// <param name="enumeration">The 'Enumeration' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Enumeration enumeration)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify enumerationexists
                if(enumeration != null)
                {
                    // Create parameter for [EnumerationName]
                    param = new SqlParameter("@EnumerationName", enumeration.EnumerationName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [FieldName]
                    param = new SqlParameter("@FieldName", enumeration.FieldName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", enumeration.ProjectId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [EnumerationId]
                    param = new SqlParameter("@EnumerationId", enumeration.EnumerationId);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateEnumerationStoredProcedure(Enumeration enumeration)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateEnumerationStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_Update'.
            /// </summary>
            /// <param name="enumeration"The 'Enumeration' object to update</param>
            /// <returns>An instance of a 'UpdateEnumerationStoredProcedure</returns>
            public static UpdateEnumerationStoredProcedure CreateUpdateEnumerationStoredProcedure(Enumeration enumeration)
            {
                // Initial Value
                UpdateEnumerationStoredProcedure updateEnumerationStoredProcedure = null;

                // verify enumeration exists
                if(enumeration != null)
                {
                    // Instanciate updateEnumerationStoredProcedure
                    updateEnumerationStoredProcedure = new UpdateEnumerationStoredProcedure();

                    // Now create parameters for this procedure
                    updateEnumerationStoredProcedure.Parameters = CreateUpdateParameters(enumeration);
                }

                // return value
                return updateEnumerationStoredProcedure;
            }
            #endregion

            #region CreateFetchAllEnumerationsStoredProcedure(Enumeration enumeration)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllEnumerationsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllEnumerationsStoredProcedure' object.</returns>
            public static FetchAllEnumerationsStoredProcedure CreateFetchAllEnumerationsStoredProcedure(Enumeration enumeration)
            {
                // Initial value
                FetchAllEnumerationsStoredProcedure fetchAllEnumerationsStoredProcedure = new FetchAllEnumerationsStoredProcedure();

                // return value
                return fetchAllEnumerationsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
