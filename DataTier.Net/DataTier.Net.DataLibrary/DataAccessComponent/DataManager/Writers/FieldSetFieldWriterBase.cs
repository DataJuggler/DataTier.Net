

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

    #region class FieldSetFieldWriterBase
    /// <summary>
    /// This class is used for converting a 'FieldSetField' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FieldSetFieldWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='fieldSetField'>The 'FieldSetField' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(FieldSetField fieldSetField)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (fieldSetField != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @FieldSetFieldId = new SqlParameter("@FieldSetFieldId", fieldSetField.FieldSetFieldId);

                    // Set parameters[0] to @FieldSetFieldId
                    parameters[0] = @FieldSetFieldId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteFieldSetField'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSetField_Delete'.
            /// </summary>
            /// <param name="fieldSetField">The 'FieldSetField' to Delete.</param>
            /// <returns>An instance of a 'DeleteFieldSetFieldStoredProcedure' object.</returns>
            public static DeleteFieldSetFieldStoredProcedure CreateDeleteFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            {
                // Initial Value
                DeleteFieldSetFieldStoredProcedure deleteFieldSetFieldStoredProcedure = new DeleteFieldSetFieldStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteFieldSetFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(fieldSetField);

                // return value
                return deleteFieldSetFieldStoredProcedure;
            }
            #endregion

            #region CreateFindFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindFieldSetFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSetField_Find'.
            /// </summary>
            /// <param name="fieldSetField">The 'FieldSetField' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindFieldSetFieldStoredProcedure CreateFindFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            {
                // Initial Value
                FindFieldSetFieldStoredProcedure findFieldSetFieldStoredProcedure = null;

                // verify fieldSetField exists
                if(fieldSetField != null)
                {
                    // Instanciate findFieldSetFieldStoredProcedure
                    findFieldSetFieldStoredProcedure = new FindFieldSetFieldStoredProcedure();

                    // Now create parameters for this procedure
                    findFieldSetFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(fieldSetField);
                }

                // return value
                return findFieldSetFieldStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new fieldSetField.
            /// </summary>
            /// <param name="fieldSetField">The 'FieldSetField' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(FieldSetField fieldSetField)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify fieldSetFieldexists
                if(fieldSetField != null)
                {
                    // Create [FieldId] parameter
                    param = new SqlParameter("@FieldId", fieldSetField.FieldId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [FieldOrdinal] parameter
                    param = new SqlParameter("@FieldOrdinal", fieldSetField.FieldOrdinal);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [FieldSetId] parameter
                    param = new SqlParameter("@FieldSetId", fieldSetField.FieldSetId);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertFieldSetFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSetField_Insert'.
            /// </summary>
            /// <param name="fieldSetField"The 'FieldSetField' object to insert</param>
            /// <returns>An instance of a 'InsertFieldSetFieldStoredProcedure' object.</returns>
            public static InsertFieldSetFieldStoredProcedure CreateInsertFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            {
                // Initial Value
                InsertFieldSetFieldStoredProcedure insertFieldSetFieldStoredProcedure = null;

                // verify fieldSetField exists
                if(fieldSetField != null)
                {
                    // Instanciate insertFieldSetFieldStoredProcedure
                    insertFieldSetFieldStoredProcedure = new InsertFieldSetFieldStoredProcedure();

                    // Now create parameters for this procedure
                    insertFieldSetFieldStoredProcedure.Parameters = CreateInsertParameters(fieldSetField);
                }

                // return value
                return insertFieldSetFieldStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing fieldSetField.
            /// </summary>
            /// <param name="fieldSetField">The 'FieldSetField' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(FieldSetField fieldSetField)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify fieldSetFieldexists
                if(fieldSetField != null)
                {
                    // Create parameter for [FieldId]
                    param = new SqlParameter("@FieldId", fieldSetField.FieldId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [FieldOrdinal]
                    param = new SqlParameter("@FieldOrdinal", fieldSetField.FieldOrdinal);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [FieldSetId]
                    param = new SqlParameter("@FieldSetId", fieldSetField.FieldSetId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [FieldSetFieldId]
                    param = new SqlParameter("@FieldSetFieldId", fieldSetField.FieldSetFieldId);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateFieldSetFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSetField_Update'.
            /// </summary>
            /// <param name="fieldSetField"The 'FieldSetField' object to update</param>
            /// <returns>An instance of a 'UpdateFieldSetFieldStoredProcedure</returns>
            public static UpdateFieldSetFieldStoredProcedure CreateUpdateFieldSetFieldStoredProcedure(FieldSetField fieldSetField)
            {
                // Initial Value
                UpdateFieldSetFieldStoredProcedure updateFieldSetFieldStoredProcedure = null;

                // verify fieldSetField exists
                if(fieldSetField != null)
                {
                    // Instanciate updateFieldSetFieldStoredProcedure
                    updateFieldSetFieldStoredProcedure = new UpdateFieldSetFieldStoredProcedure();

                    // Now create parameters for this procedure
                    updateFieldSetFieldStoredProcedure.Parameters = CreateUpdateParameters(fieldSetField);
                }

                // return value
                return updateFieldSetFieldStoredProcedure;
            }
            #endregion

            #region CreateFetchAllFieldSetFieldsStoredProcedure(FieldSetField fieldSetField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFieldSetFieldsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSetField_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFieldSetFieldsStoredProcedure' object.</returns>
            public static FetchAllFieldSetFieldsStoredProcedure CreateFetchAllFieldSetFieldsStoredProcedure(FieldSetField fieldSetField)
            {
                // Initial value
                FetchAllFieldSetFieldsStoredProcedure fetchAllFieldSetFieldsStoredProcedure = new FetchAllFieldSetFieldsStoredProcedure();

                // return value
                return fetchAllFieldSetFieldsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
