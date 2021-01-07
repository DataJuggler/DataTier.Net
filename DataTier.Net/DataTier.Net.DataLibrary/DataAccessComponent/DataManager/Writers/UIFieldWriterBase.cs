

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

    #region class UIFieldWriterBase
    /// <summary>
    /// This class is used for converting a 'UIField' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UIFieldWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(UIField uIField)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='uIField'>The 'UIField' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(UIField uIField)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (uIField != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", uIField.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteUIFieldStoredProcedure(UIField uIField)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteUIField'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIField_Delete'.
            /// </summary>
            /// <param name="uIField">The 'UIField' to Delete.</param>
            /// <returns>An instance of a 'DeleteUIFieldStoredProcedure' object.</returns>
            public static DeleteUIFieldStoredProcedure CreateDeleteUIFieldStoredProcedure(UIField uIField)
            {
                // Initial Value
                DeleteUIFieldStoredProcedure deleteUIFieldStoredProcedure = new DeleteUIFieldStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteUIFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(uIField);

                // return value
                return deleteUIFieldStoredProcedure;
            }
            #endregion

            #region CreateFindUIFieldStoredProcedure(UIField uIField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindUIFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIField_Find'.
            /// </summary>
            /// <param name="uIField">The 'UIField' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindUIFieldStoredProcedure CreateFindUIFieldStoredProcedure(UIField uIField)
            {
                // Initial Value
                FindUIFieldStoredProcedure findUIFieldStoredProcedure = null;

                // verify uIField exists
                if(uIField != null)
                {
                    // Instanciate findUIFieldStoredProcedure
                    findUIFieldStoredProcedure = new FindUIFieldStoredProcedure();

                    // Now create parameters for this procedure
                    findUIFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(uIField);
                }

                // return value
                return findUIFieldStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(UIField uIField)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new uIField.
            /// </summary>
            /// <param name="uIField">The 'UIField' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(UIField uIField)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[10];
                SqlParameter param = null;

                // verify uIFieldexists
                if(uIField != null)
                {
                    // Create [Caption] parameter
                    param = new SqlParameter("@Caption", uIField.Caption);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [DataType] parameter
                    param = new SqlParameter("@DataType", uIField.DataType);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [DTNFieldId] parameter
                    param = new SqlParameter("@DTNFieldId", uIField.DTNFieldId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [FieldOrdinal] parameter
                    param = new SqlParameter("@FieldOrdinal", uIField.FieldOrdinal);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [MaxLength] parameter
                    param = new SqlParameter("@MaxLength", uIField.MaxLength);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [MaxRange] parameter
                    param = new SqlParameter("@MaxRange", uIField.MaxRange);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [MinLength] parameter
                    param = new SqlParameter("@MinLength", uIField.MinLength);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [MinRange] parameter
                    param = new SqlParameter("@MinRange", uIField.MinRange);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [Required] parameter
                    param = new SqlParameter("@Required", uIField.Required);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [UserInterfaceId] parameter
                    param = new SqlParameter("@UserInterfaceId", uIField.UserInterfaceId);

                    // set parameters[9]
                    parameters[9] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertUIFieldStoredProcedure(UIField uIField)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertUIFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIField_Insert'.
            /// </summary>
            /// <param name="uIField"The 'UIField' object to insert</param>
            /// <returns>An instance of a 'InsertUIFieldStoredProcedure' object.</returns>
            public static InsertUIFieldStoredProcedure CreateInsertUIFieldStoredProcedure(UIField uIField)
            {
                // Initial Value
                InsertUIFieldStoredProcedure insertUIFieldStoredProcedure = null;

                // verify uIField exists
                if(uIField != null)
                {
                    // Instanciate insertUIFieldStoredProcedure
                    insertUIFieldStoredProcedure = new InsertUIFieldStoredProcedure();

                    // Now create parameters for this procedure
                    insertUIFieldStoredProcedure.Parameters = CreateInsertParameters(uIField);
                }

                // return value
                return insertUIFieldStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(UIField uIField)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing uIField.
            /// </summary>
            /// <param name="uIField">The 'UIField' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(UIField uIField)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[11];
                SqlParameter param = null;

                // verify uIFieldexists
                if(uIField != null)
                {
                    // Create parameter for [Caption]
                    param = new SqlParameter("@Caption", uIField.Caption);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [DataType]
                    param = new SqlParameter("@DataType", uIField.DataType);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [DTNFieldId]
                    param = new SqlParameter("@DTNFieldId", uIField.DTNFieldId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [FieldOrdinal]
                    param = new SqlParameter("@FieldOrdinal", uIField.FieldOrdinal);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [MaxLength]
                    param = new SqlParameter("@MaxLength", uIField.MaxLength);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [MaxRange]
                    param = new SqlParameter("@MaxRange", uIField.MaxRange);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [MinLength]
                    param = new SqlParameter("@MinLength", uIField.MinLength);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [MinRange]
                    param = new SqlParameter("@MinRange", uIField.MinRange);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Required]
                    param = new SqlParameter("@Required", uIField.Required);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [UserInterfaceId]
                    param = new SqlParameter("@UserInterfaceId", uIField.UserInterfaceId);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", uIField.Id);
                    parameters[10] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateUIFieldStoredProcedure(UIField uIField)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateUIFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIField_Update'.
            /// </summary>
            /// <param name="uIField"The 'UIField' object to update</param>
            /// <returns>An instance of a 'UpdateUIFieldStoredProcedure</returns>
            public static UpdateUIFieldStoredProcedure CreateUpdateUIFieldStoredProcedure(UIField uIField)
            {
                // Initial Value
                UpdateUIFieldStoredProcedure updateUIFieldStoredProcedure = null;

                // verify uIField exists
                if(uIField != null)
                {
                    // Instanciate updateUIFieldStoredProcedure
                    updateUIFieldStoredProcedure = new UpdateUIFieldStoredProcedure();

                    // Now create parameters for this procedure
                    updateUIFieldStoredProcedure.Parameters = CreateUpdateParameters(uIField);
                }

                // return value
                return updateUIFieldStoredProcedure;
            }
            #endregion

            #region CreateFetchAllUIFieldsStoredProcedure(UIField uIField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllUIFieldsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIField_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllUIFieldsStoredProcedure' object.</returns>
            public static FetchAllUIFieldsStoredProcedure CreateFetchAllUIFieldsStoredProcedure(UIField uIField)
            {
                // Initial value
                FetchAllUIFieldsStoredProcedure fetchAllUIFieldsStoredProcedure = new FetchAllUIFieldsStoredProcedure();

                // return value
                return fetchAllUIFieldsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
