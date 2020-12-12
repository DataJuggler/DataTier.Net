

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

    #region class FieldSetWriterBase
    /// <summary>
    /// This class is used for converting a 'FieldSet' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FieldSetWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(FieldSet fieldSet)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='fieldSet'>The 'FieldSet' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(FieldSet fieldSet)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (fieldSet != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @FieldSetId = new SqlParameter("@FieldSetId", fieldSet.FieldSetId);

                    // Set parameters[0] to @FieldSetId
                    parameters[0] = @FieldSetId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteFieldSetStoredProcedure(FieldSet fieldSet)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteFieldSet'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSet_Delete'.
            /// </summary>
            /// <param name="fieldSet">The 'FieldSet' to Delete.</param>
            /// <returns>An instance of a 'DeleteFieldSetStoredProcedure' object.</returns>
            public static DeleteFieldSetStoredProcedure CreateDeleteFieldSetStoredProcedure(FieldSet fieldSet)
            {
                // Initial Value
                DeleteFieldSetStoredProcedure deleteFieldSetStoredProcedure = new DeleteFieldSetStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteFieldSetStoredProcedure.Parameters = CreatePrimaryKeyParameter(fieldSet);

                // return value
                return deleteFieldSetStoredProcedure;
            }
            #endregion

            #region CreateFindFieldSetStoredProcedure(FieldSet fieldSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindFieldSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSet_Find'.
            /// </summary>
            /// <param name="fieldSet">The 'FieldSet' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindFieldSetStoredProcedure CreateFindFieldSetStoredProcedure(FieldSet fieldSet)
            {
                // Initial Value
                FindFieldSetStoredProcedure findFieldSetStoredProcedure = null;

                // verify fieldSet exists
                if(fieldSet != null)
                {
                    // Instanciate findFieldSetStoredProcedure
                    findFieldSetStoredProcedure = new FindFieldSetStoredProcedure();

                    // Now create parameters for this procedure
                    findFieldSetStoredProcedure.Parameters = CreatePrimaryKeyParameter(fieldSet);
                }

                // return value
                return findFieldSetStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(FieldSet fieldSet)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new fieldSet.
            /// </summary>
            /// <param name="fieldSet">The 'FieldSet' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(FieldSet fieldSet)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify fieldSetexists
                if(fieldSet != null)
                {
                    // Create [DatabaseId] parameter
                    param = new SqlParameter("@DatabaseId", fieldSet.DatabaseId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", fieldSet.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [OrderByMode] parameter
                    param = new SqlParameter("@OrderByMode", fieldSet.OrderByMode);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [ParameterMode] parameter
                    param = new SqlParameter("@ParameterMode", fieldSet.ParameterMode);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", fieldSet.ProjectId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [ReaderMode] parameter
                    param = new SqlParameter("@ReaderMode", fieldSet.ReaderMode);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [TableId] parameter
                    param = new SqlParameter("@TableId", fieldSet.TableId);

                    // set parameters[6]
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertFieldSetStoredProcedure(FieldSet fieldSet)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertFieldSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSet_Insert'.
            /// </summary>
            /// <param name="fieldSet"The 'FieldSet' object to insert</param>
            /// <returns>An instance of a 'InsertFieldSetStoredProcedure' object.</returns>
            public static InsertFieldSetStoredProcedure CreateInsertFieldSetStoredProcedure(FieldSet fieldSet)
            {
                // Initial Value
                InsertFieldSetStoredProcedure insertFieldSetStoredProcedure = null;

                // verify fieldSet exists
                if(fieldSet != null)
                {
                    // Instanciate insertFieldSetStoredProcedure
                    insertFieldSetStoredProcedure = new InsertFieldSetStoredProcedure();

                    // Now create parameters for this procedure
                    insertFieldSetStoredProcedure.Parameters = CreateInsertParameters(fieldSet);
                }

                // return value
                return insertFieldSetStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(FieldSet fieldSet)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing fieldSet.
            /// </summary>
            /// <param name="fieldSet">The 'FieldSet' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(FieldSet fieldSet)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify fieldSetexists
                if(fieldSet != null)
                {
                    // Create parameter for [DatabaseId]
                    param = new SqlParameter("@DatabaseId", fieldSet.DatabaseId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", fieldSet.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [OrderByMode]
                    param = new SqlParameter("@OrderByMode", fieldSet.OrderByMode);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [ParameterMode]
                    param = new SqlParameter("@ParameterMode", fieldSet.ParameterMode);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", fieldSet.ProjectId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [ReaderMode]
                    param = new SqlParameter("@ReaderMode", fieldSet.ReaderMode);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", fieldSet.TableId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [FieldSetId]
                    param = new SqlParameter("@FieldSetId", fieldSet.FieldSetId);
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateFieldSetStoredProcedure(FieldSet fieldSet)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateFieldSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSet_Update'.
            /// </summary>
            /// <param name="fieldSet"The 'FieldSet' object to update</param>
            /// <returns>An instance of a 'UpdateFieldSetStoredProcedure</returns>
            public static UpdateFieldSetStoredProcedure CreateUpdateFieldSetStoredProcedure(FieldSet fieldSet)
            {
                // Initial Value
                UpdateFieldSetStoredProcedure updateFieldSetStoredProcedure = null;

                // verify fieldSet exists
                if(fieldSet != null)
                {
                    // Instanciate updateFieldSetStoredProcedure
                    updateFieldSetStoredProcedure = new UpdateFieldSetStoredProcedure();

                    // Now create parameters for this procedure
                    updateFieldSetStoredProcedure.Parameters = CreateUpdateParameters(fieldSet);
                }

                // return value
                return updateFieldSetStoredProcedure;
            }
            #endregion

            #region CreateFetchAllFieldSetsStoredProcedure(FieldSet fieldSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFieldSetsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSet_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFieldSetsStoredProcedure' object.</returns>
            public static FetchAllFieldSetsStoredProcedure CreateFetchAllFieldSetsStoredProcedure(FieldSet fieldSet)
            {
                // Initial value
                FetchAllFieldSetsStoredProcedure fetchAllFieldSetsStoredProcedure = new FetchAllFieldSetsStoredProcedure();

                // return value
                return fetchAllFieldSetsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
