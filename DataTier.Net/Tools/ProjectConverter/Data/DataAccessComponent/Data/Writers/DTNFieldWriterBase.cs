

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

    #region class DTNFieldWriterBase
    /// <summary>
    /// This class is used for converting a 'DTNField' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNFieldWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(DTNField dTNField)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='dTNField'>The 'DTNField' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(DTNField dTNField)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (dTNField != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @FieldId = new SqlParameter("@FieldId", dTNField.FieldId);

                    // Set parameters[0] to @FieldId
                    parameters[0] = @FieldId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteDTNFieldStoredProcedure(DTNField dTNField)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDTNField'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNField_Delete'.
            /// </summary>
            /// <param name="dTNField">The 'DTNField' to Delete.</param>
            /// <returns>An instance of a 'DeleteDTNFieldStoredProcedure' object.</returns>
            public static DeleteDTNFieldStoredProcedure CreateDeleteDTNFieldStoredProcedure(DTNField dTNField)
            {
                // Initial Value
                DeleteDTNFieldStoredProcedure deleteDTNFieldStoredProcedure = new DeleteDTNFieldStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteDTNFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNField);

                // return value
                return deleteDTNFieldStoredProcedure;
            }
            #endregion

            #region CreateFindDTNFieldStoredProcedure(DTNField dTNField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindDTNFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNField_Find'.
            /// </summary>
            /// <param name="dTNField">The 'DTNField' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindDTNFieldStoredProcedure CreateFindDTNFieldStoredProcedure(DTNField dTNField)
            {
                // Initial Value
                FindDTNFieldStoredProcedure findDTNFieldStoredProcedure = null;

                // verify dTNField exists
                if(dTNField != null)
                {
                    // Instanciate findDTNFieldStoredProcedure
                    findDTNFieldStoredProcedure = new FindDTNFieldStoredProcedure();

                    // Now create parameters for this procedure
                    findDTNFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNField);
                }

                // return value
                return findDTNFieldStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(DTNField dTNField)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new dTNField.
            /// </summary>
            /// <param name="dTNField">The 'DTNField' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(DTNField dTNField)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[18];
                SqlParameter param = null;

                // verify dTNFieldexists
                if(dTNField != null)
                {
                    // Create [AccessMode] parameter
                    param = new SqlParameter("@AccessMode", dTNField.AccessMode);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Caption] parameter
                    param = new SqlParameter("@Caption", dTNField.Caption);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [DatabaseId] parameter
                    param = new SqlParameter("@DatabaseId", dTNField.DatabaseId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [DataType] parameter
                    param = new SqlParameter("@DataType", dTNField.DataType);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [DecimalPlaces] parameter
                    param = new SqlParameter("@DecimalPlaces", dTNField.DecimalPlaces);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [DefaultValue] parameter
                    param = new SqlParameter("@DefaultValue", dTNField.DefaultValue);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [EnumDataTypeName] parameter
                    param = new SqlParameter("@EnumDataTypeName", dTNField.EnumDataTypeName);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Exclude] parameter
                    param = new SqlParameter("@Exclude", dTNField.Exclude);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [FieldName] parameter
                    param = new SqlParameter("@FieldName", dTNField.FieldName);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [FieldOrdinal] parameter
                    param = new SqlParameter("@FieldOrdinal", dTNField.FieldOrdinal);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [FieldSize] parameter
                    param = new SqlParameter("@FieldSize", dTNField.FieldSize);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [IsEnumeration] parameter
                    param = new SqlParameter("@IsEnumeration", dTNField.IsEnumeration);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create [IsNullable] parameter
                    param = new SqlParameter("@IsNullable", dTNField.IsNullable);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create [PrimaryKey] parameter
                    param = new SqlParameter("@PrimaryKey", dTNField.PrimaryKey);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", dTNField.ProjectId);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create [Required] parameter
                    param = new SqlParameter("@Required", dTNField.Required);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create [Scope] parameter
                    param = new SqlParameter("@Scope", dTNField.Scope);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create [TableId] parameter
                    param = new SqlParameter("@TableId", dTNField.TableId);

                    // set parameters[17]
                    parameters[17] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertDTNFieldStoredProcedure(DTNField dTNField)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertDTNFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNField_Insert'.
            /// </summary>
            /// <param name="dTNField"The 'DTNField' object to insert</param>
            /// <returns>An instance of a 'InsertDTNFieldStoredProcedure' object.</returns>
            public static InsertDTNFieldStoredProcedure CreateInsertDTNFieldStoredProcedure(DTNField dTNField)
            {
                // Initial Value
                InsertDTNFieldStoredProcedure insertDTNFieldStoredProcedure = null;

                // verify dTNField exists
                if(dTNField != null)
                {
                    // Instanciate insertDTNFieldStoredProcedure
                    insertDTNFieldStoredProcedure = new InsertDTNFieldStoredProcedure();

                    // Now create parameters for this procedure
                    insertDTNFieldStoredProcedure.Parameters = CreateInsertParameters(dTNField);
                }

                // return value
                return insertDTNFieldStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(DTNField dTNField)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing dTNField.
            /// </summary>
            /// <param name="dTNField">The 'DTNField' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(DTNField dTNField)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[19];
                SqlParameter param = null;

                // verify dTNFieldexists
                if(dTNField != null)
                {
                    // Create parameter for [AccessMode]
                    param = new SqlParameter("@AccessMode", dTNField.AccessMode);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Caption]
                    param = new SqlParameter("@Caption", dTNField.Caption);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [DatabaseId]
                    param = new SqlParameter("@DatabaseId", dTNField.DatabaseId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [DataType]
                    param = new SqlParameter("@DataType", dTNField.DataType);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [DecimalPlaces]
                    param = new SqlParameter("@DecimalPlaces", dTNField.DecimalPlaces);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [DefaultValue]
                    param = new SqlParameter("@DefaultValue", dTNField.DefaultValue);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [EnumDataTypeName]
                    param = new SqlParameter("@EnumDataTypeName", dTNField.EnumDataTypeName);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Exclude]
                    param = new SqlParameter("@Exclude", dTNField.Exclude);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [FieldName]
                    param = new SqlParameter("@FieldName", dTNField.FieldName);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [FieldOrdinal]
                    param = new SqlParameter("@FieldOrdinal", dTNField.FieldOrdinal);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [FieldSize]
                    param = new SqlParameter("@FieldSize", dTNField.FieldSize);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [IsEnumeration]
                    param = new SqlParameter("@IsEnumeration", dTNField.IsEnumeration);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [IsNullable]
                    param = new SqlParameter("@IsNullable", dTNField.IsNullable);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create parameter for [PrimaryKey]
                    param = new SqlParameter("@PrimaryKey", dTNField.PrimaryKey);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", dTNField.ProjectId);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create parameter for [Required]
                    param = new SqlParameter("@Required", dTNField.Required);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create parameter for [Scope]
                    param = new SqlParameter("@Scope", dTNField.Scope);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", dTNField.TableId);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create parameter for [FieldId]
                    param = new SqlParameter("@FieldId", dTNField.FieldId);
                    parameters[18] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateDTNFieldStoredProcedure(DTNField dTNField)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateDTNFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNField_Update'.
            /// </summary>
            /// <param name="dTNField"The 'DTNField' object to update</param>
            /// <returns>An instance of a 'UpdateDTNFieldStoredProcedure</returns>
            public static UpdateDTNFieldStoredProcedure CreateUpdateDTNFieldStoredProcedure(DTNField dTNField)
            {
                // Initial Value
                UpdateDTNFieldStoredProcedure updateDTNFieldStoredProcedure = null;

                // verify dTNField exists
                if(dTNField != null)
                {
                    // Instanciate updateDTNFieldStoredProcedure
                    updateDTNFieldStoredProcedure = new UpdateDTNFieldStoredProcedure();

                    // Now create parameters for this procedure
                    updateDTNFieldStoredProcedure.Parameters = CreateUpdateParameters(dTNField);
                }

                // return value
                return updateDTNFieldStoredProcedure;
            }
            #endregion

            #region CreateFetchAllDTNFieldsStoredProcedure(DTNField dTNField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNFieldsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNField_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNFieldsStoredProcedure' object.</returns>
            public static FetchAllDTNFieldsStoredProcedure CreateFetchAllDTNFieldsStoredProcedure(DTNField dTNField)
            {
                // Initial value
                FetchAllDTNFieldsStoredProcedure fetchAllDTNFieldsStoredProcedure = new FetchAllDTNFieldsStoredProcedure();

                // return value
                return fetchAllDTNFieldsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
