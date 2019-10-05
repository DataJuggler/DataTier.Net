

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

    #region class MethodWriterBase
    /// <summary>
    /// This class is used for converting a 'Method' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MethodWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Method method)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='method'>The 'Method' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Method method)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (method != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @MethodId = new SqlParameter("@MethodId", method.MethodId);

                    // Set parameters[0] to @MethodId
                    parameters[0] = @MethodId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteMethodStoredProcedure(Method method)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteMethod'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Method_Delete'.
            /// </summary>
            /// <param name="method">The 'Method' to Delete.</param>
            /// <returns>An instance of a 'DeleteMethodStoredProcedure' object.</returns>
            public static DeleteMethodStoredProcedure CreateDeleteMethodStoredProcedure(Method method)
            {
                // Initial Value
                DeleteMethodStoredProcedure deleteMethodStoredProcedure = new DeleteMethodStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteMethodStoredProcedure.Parameters = CreatePrimaryKeyParameter(method);

                // return value
                return deleteMethodStoredProcedure;
            }
            #endregion

            #region CreateFindMethodStoredProcedure(Method method)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindMethodStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Method_Find'.
            /// </summary>
            /// <param name="method">The 'Method' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindMethodStoredProcedure CreateFindMethodStoredProcedure(Method method)
            {
                // Initial Value
                FindMethodStoredProcedure findMethodStoredProcedure = null;

                // verify method exists
                if(method != null)
                {
                    // Instanciate findMethodStoredProcedure
                    findMethodStoredProcedure = new FindMethodStoredProcedure();

                    // Now create parameters for this procedure
                    findMethodStoredProcedure.Parameters = CreatePrimaryKeyParameter(method);
                }

                // return value
                return findMethodStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Method method)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new method.
            /// </summary>
            /// <param name="method">The 'Method' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Method method)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[20];
                SqlParameter param = null;

                // verify methodexists
                if(method != null)
                {
                    // Create [Active] parameter
                    param = new SqlParameter("@Active", method.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [CustomReaderId] parameter
                    param = new SqlParameter("@CustomReaderId", method.CustomReaderId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [MethodType] parameter
                    param = new SqlParameter("@MethodType", method.MethodType);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", method.Name);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [OrderByDescending] parameter
                    param = new SqlParameter("@OrderByDescending", method.OrderByDescending);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [OrderByFieldId] parameter
                    param = new SqlParameter("@OrderByFieldId", method.OrderByFieldId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [OrderByFieldSetId] parameter
                    param = new SqlParameter("@OrderByFieldSetId", method.OrderByFieldSetId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [OrderByType] parameter
                    param = new SqlParameter("@OrderByType", method.OrderByType);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [ParameterFieldId] parameter
                    param = new SqlParameter("@ParameterFieldId", method.ParameterFieldId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [Parameters] parameter
                    param = new SqlParameter("@Parameters", method.Parameters);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [ParametersFieldSetId] parameter
                    param = new SqlParameter("@ParametersFieldSetId", method.ParametersFieldSetId);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [ParameterType] parameter
                    param = new SqlParameter("@ParameterType", method.ParameterType);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create [ProcedureName] parameter
                    param = new SqlParameter("@ProcedureName", method.ProcedureName);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create [ProcedureText] parameter
                    param = new SqlParameter("@ProcedureText", method.ProcedureText);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", method.ProjectId);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create [PropertyName] parameter
                    param = new SqlParameter("@PropertyName", method.PropertyName);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create [TableId] parameter
                    param = new SqlParameter("@TableId", method.TableId);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create [TopRows] parameter
                    param = new SqlParameter("@TopRows", method.TopRows);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create [UpdateProcedureOnBuild] parameter
                    param = new SqlParameter("@UpdateProcedureOnBuild", method.UpdateProcedureOnBuild);

                    // set parameters[18]
                    parameters[18] = param;

                    // Create [UseCustomReader] parameter
                    param = new SqlParameter("@UseCustomReader", method.UseCustomReader);

                    // set parameters[19]
                    parameters[19] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertMethodStoredProcedure(Method method)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertMethodStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Method_Insert'.
            /// </summary>
            /// <param name="method"The 'Method' object to insert</param>
            /// <returns>An instance of a 'InsertMethodStoredProcedure' object.</returns>
            public static InsertMethodStoredProcedure CreateInsertMethodStoredProcedure(Method method)
            {
                // Initial Value
                InsertMethodStoredProcedure insertMethodStoredProcedure = null;

                // verify method exists
                if(method != null)
                {
                    // Instanciate insertMethodStoredProcedure
                    insertMethodStoredProcedure = new InsertMethodStoredProcedure();

                    // Now create parameters for this procedure
                    insertMethodStoredProcedure.Parameters = CreateInsertParameters(method);
                }

                // return value
                return insertMethodStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Method method)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing method.
            /// </summary>
            /// <param name="method">The 'Method' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Method method)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[21];
                SqlParameter param = null;

                // verify methodexists
                if(method != null)
                {
                    // Create parameter for [Active]
                    param = new SqlParameter("@Active", method.Active);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [CustomReaderId]
                    param = new SqlParameter("@CustomReaderId", method.CustomReaderId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [MethodType]
                    param = new SqlParameter("@MethodType", method.MethodType);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", method.Name);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [OrderByDescending]
                    param = new SqlParameter("@OrderByDescending", method.OrderByDescending);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [OrderByFieldId]
                    param = new SqlParameter("@OrderByFieldId", method.OrderByFieldId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [OrderByFieldSetId]
                    param = new SqlParameter("@OrderByFieldSetId", method.OrderByFieldSetId);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [OrderByType]
                    param = new SqlParameter("@OrderByType", method.OrderByType);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [ParameterFieldId]
                    param = new SqlParameter("@ParameterFieldId", method.ParameterFieldId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Parameters]
                    param = new SqlParameter("@Parameters", method.Parameters);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [ParametersFieldSetId]
                    param = new SqlParameter("@ParametersFieldSetId", method.ParametersFieldSetId);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [ParameterType]
                    param = new SqlParameter("@ParameterType", method.ParameterType);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [ProcedureName]
                    param = new SqlParameter("@ProcedureName", method.ProcedureName);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create parameter for [ProcedureText]
                    param = new SqlParameter("@ProcedureText", method.ProcedureText);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", method.ProjectId);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create parameter for [PropertyName]
                    param = new SqlParameter("@PropertyName", method.PropertyName);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", method.TableId);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create parameter for [TopRows]
                    param = new SqlParameter("@TopRows", method.TopRows);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create parameter for [UpdateProcedureOnBuild]
                    param = new SqlParameter("@UpdateProcedureOnBuild", method.UpdateProcedureOnBuild);

                    // set parameters[18]
                    parameters[18] = param;

                    // Create parameter for [UseCustomReader]
                    param = new SqlParameter("@UseCustomReader", method.UseCustomReader);

                    // set parameters[19]
                    parameters[19] = param;

                    // Create parameter for [MethodId]
                    param = new SqlParameter("@MethodId", method.MethodId);
                    parameters[20] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateMethodStoredProcedure(Method method)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateMethodStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Method_Update'.
            /// </summary>
            /// <param name="method"The 'Method' object to update</param>
            /// <returns>An instance of a 'UpdateMethodStoredProcedure</returns>
            public static UpdateMethodStoredProcedure CreateUpdateMethodStoredProcedure(Method method)
            {
                // Initial Value
                UpdateMethodStoredProcedure updateMethodStoredProcedure = null;

                // verify method exists
                if(method != null)
                {
                    // Instanciate updateMethodStoredProcedure
                    updateMethodStoredProcedure = new UpdateMethodStoredProcedure();

                    // Now create parameters for this procedure
                    updateMethodStoredProcedure.Parameters = CreateUpdateParameters(method);
                }

                // return value
                return updateMethodStoredProcedure;
            }
            #endregion

            #region CreateFetchAllMethodsStoredProcedure(Method method)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllMethodsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Method_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllMethodsStoredProcedure' object.</returns>
            public static FetchAllMethodsStoredProcedure CreateFetchAllMethodsStoredProcedure(Method method)
            {
                // Initial value
                FetchAllMethodsStoredProcedure fetchAllMethodsStoredProcedure = new FetchAllMethodsStoredProcedure();

                // return value
                return fetchAllMethodsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
