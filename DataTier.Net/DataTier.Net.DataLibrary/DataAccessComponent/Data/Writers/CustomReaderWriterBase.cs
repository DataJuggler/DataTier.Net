

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

    #region class CustomReaderWriterBase
    /// <summary>
    /// This class is used for converting a 'CustomReader' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class CustomReaderWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(CustomReader customReader)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='customReader'>The 'CustomReader' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(CustomReader customReader)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (customReader != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @CustomReaderId = new SqlParameter("@CustomReaderId", customReader.CustomReaderId);

                    // Set parameters[0] to @CustomReaderId
                    parameters[0] = @CustomReaderId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteCustomReaderStoredProcedure(CustomReader customReader)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteCustomReader'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'CustomReader_Delete'.
            /// </summary>
            /// <param name="customReader">The 'CustomReader' to Delete.</param>
            /// <returns>An instance of a 'DeleteCustomReaderStoredProcedure' object.</returns>
            public static DeleteCustomReaderStoredProcedure CreateDeleteCustomReaderStoredProcedure(CustomReader customReader)
            {
                // Initial Value
                DeleteCustomReaderStoredProcedure deleteCustomReaderStoredProcedure = new DeleteCustomReaderStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteCustomReaderStoredProcedure.Parameters = CreatePrimaryKeyParameter(customReader);

                // return value
                return deleteCustomReaderStoredProcedure;
            }
            #endregion

            #region CreateFindCustomReaderStoredProcedure(CustomReader customReader)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindCustomReaderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'CustomReader_Find'.
            /// </summary>
            /// <param name="customReader">The 'CustomReader' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindCustomReaderStoredProcedure CreateFindCustomReaderStoredProcedure(CustomReader customReader)
            {
                // Initial Value
                FindCustomReaderStoredProcedure findCustomReaderStoredProcedure = null;

                // verify customReader exists
                if(customReader != null)
                {
                    // Instanciate findCustomReaderStoredProcedure
                    findCustomReaderStoredProcedure = new FindCustomReaderStoredProcedure();

                    // Now create parameters for this procedure
                    findCustomReaderStoredProcedure.Parameters = CreatePrimaryKeyParameter(customReader);
                }

                // return value
                return findCustomReaderStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(CustomReader customReader)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new customReader.
            /// </summary>
            /// <param name="customReader">The 'CustomReader' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(CustomReader customReader)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify customReaderexists
                if(customReader != null)
                {
                    // Create [ClassName] parameter
                    param = new SqlParameter("@ClassName", customReader.ClassName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [FieldSetId] parameter
                    param = new SqlParameter("@FieldSetId", customReader.FieldSetId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [FileName] parameter
                    param = new SqlParameter("@FileName", customReader.FileName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [ReaderName] parameter
                    param = new SqlParameter("@ReaderName", customReader.ReaderName);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [TableId] parameter
                    param = new SqlParameter("@TableId", customReader.TableId);

                    // set parameters[4]
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertCustomReaderStoredProcedure(CustomReader customReader)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertCustomReaderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'CustomReader_Insert'.
            /// </summary>
            /// <param name="customReader"The 'CustomReader' object to insert</param>
            /// <returns>An instance of a 'InsertCustomReaderStoredProcedure' object.</returns>
            public static InsertCustomReaderStoredProcedure CreateInsertCustomReaderStoredProcedure(CustomReader customReader)
            {
                // Initial Value
                InsertCustomReaderStoredProcedure insertCustomReaderStoredProcedure = null;

                // verify customReader exists
                if(customReader != null)
                {
                    // Instanciate insertCustomReaderStoredProcedure
                    insertCustomReaderStoredProcedure = new InsertCustomReaderStoredProcedure();

                    // Now create parameters for this procedure
                    insertCustomReaderStoredProcedure.Parameters = CreateInsertParameters(customReader);
                }

                // return value
                return insertCustomReaderStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(CustomReader customReader)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing customReader.
            /// </summary>
            /// <param name="customReader">The 'CustomReader' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(CustomReader customReader)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify customReaderexists
                if(customReader != null)
                {
                    // Create parameter for [ClassName]
                    param = new SqlParameter("@ClassName", customReader.ClassName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [FieldSetId]
                    param = new SqlParameter("@FieldSetId", customReader.FieldSetId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [FileName]
                    param = new SqlParameter("@FileName", customReader.FileName);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [ReaderName]
                    param = new SqlParameter("@ReaderName", customReader.ReaderName);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", customReader.TableId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [CustomReaderId]
                    param = new SqlParameter("@CustomReaderId", customReader.CustomReaderId);
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateCustomReaderStoredProcedure(CustomReader customReader)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateCustomReaderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'CustomReader_Update'.
            /// </summary>
            /// <param name="customReader"The 'CustomReader' object to update</param>
            /// <returns>An instance of a 'UpdateCustomReaderStoredProcedure</returns>
            public static UpdateCustomReaderStoredProcedure CreateUpdateCustomReaderStoredProcedure(CustomReader customReader)
            {
                // Initial Value
                UpdateCustomReaderStoredProcedure updateCustomReaderStoredProcedure = null;

                // verify customReader exists
                if(customReader != null)
                {
                    // Instanciate updateCustomReaderStoredProcedure
                    updateCustomReaderStoredProcedure = new UpdateCustomReaderStoredProcedure();

                    // Now create parameters for this procedure
                    updateCustomReaderStoredProcedure.Parameters = CreateUpdateParameters(customReader);
                }

                // return value
                return updateCustomReaderStoredProcedure;
            }
            #endregion

            #region CreateFetchAllCustomReadersStoredProcedure(CustomReader customReader)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllCustomReadersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'CustomReader_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllCustomReadersStoredProcedure' object.</returns>
            public static FetchAllCustomReadersStoredProcedure CreateFetchAllCustomReadersStoredProcedure(CustomReader customReader)
            {
                // Initial value
                FetchAllCustomReadersStoredProcedure fetchAllCustomReadersStoredProcedure = new FetchAllCustomReadersStoredProcedure();

                // return value
                return fetchAllCustomReadersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
