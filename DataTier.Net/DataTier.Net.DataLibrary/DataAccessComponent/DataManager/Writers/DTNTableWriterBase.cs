

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

    #region class DTNTableWriterBase
    /// <summary>
    /// This class is used for converting a 'DTNTable' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNTableWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(DTNTable dTNTable)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(DTNTable dTNTable)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (dTNTable != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @TableId = new SqlParameter("@TableId", dTNTable.TableId);

                    // Set parameters[0] to @TableId
                    parameters[0] = @TableId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteDTNTableStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDTNTable'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_Delete'.
            /// </summary>
            /// <param name="dTNTable">The 'DTNTable' to Delete.</param>
            /// <returns>An instance of a 'DeleteDTNTableStoredProcedure' object.</returns>
            public static DeleteDTNTableStoredProcedure CreateDeleteDTNTableStoredProcedure(DTNTable dTNTable)
            {
                // Initial Value
                DeleteDTNTableStoredProcedure deleteDTNTableStoredProcedure = new DeleteDTNTableStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteDTNTableStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNTable);

                // return value
                return deleteDTNTableStoredProcedure;
            }
            #endregion

            #region CreateFindDTNTableStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindDTNTableStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_Find'.
            /// </summary>
            /// <param name="dTNTable">The 'DTNTable' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindDTNTableStoredProcedure CreateFindDTNTableStoredProcedure(DTNTable dTNTable)
            {
                // Initial Value
                FindDTNTableStoredProcedure findDTNTableStoredProcedure = null;

                // verify dTNTable exists
                if(dTNTable != null)
                {
                    // Instanciate findDTNTableStoredProcedure
                    findDTNTableStoredProcedure = new FindDTNTableStoredProcedure();

                    // Now create parameters for this procedure
                    findDTNTableStoredProcedure.Parameters = CreatePrimaryKeyParameter(dTNTable);
                }

                // return value
                return findDTNTableStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(DTNTable dTNTable)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new dTNTable.
            /// </summary>
            /// <param name="dTNTable">The 'DTNTable' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(DTNTable dTNTable)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify dTNTableexists
                if(dTNTable != null)
                {
                    // Create [ClassFileName] parameter
                    param = new SqlParameter("@ClassFileName", dTNTable.ClassFileName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ClassName] parameter
                    param = new SqlParameter("@ClassName", dTNTable.ClassName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [DatabaseId] parameter
                    param = new SqlParameter("@DatabaseId", dTNTable.DatabaseId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Exclude] parameter
                    param = new SqlParameter("@Exclude", dTNTable.Exclude);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [IsView] parameter
                    param = new SqlParameter("@IsView", dTNTable.IsView);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [ProjectId] parameter
                    param = new SqlParameter("@ProjectId", dTNTable.ProjectId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Scope] parameter
                    param = new SqlParameter("@Scope", dTNTable.Scope);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Serializable] parameter
                    param = new SqlParameter("@Serializable", dTNTable.Serializable);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [TableName] parameter
                    param = new SqlParameter("@TableName", dTNTable.TableName);

                    // set parameters[8]
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertDTNTableStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertDTNTableStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_Insert'.
            /// </summary>
            /// <param name="dTNTable"The 'DTNTable' object to insert</param>
            /// <returns>An instance of a 'InsertDTNTableStoredProcedure' object.</returns>
            public static InsertDTNTableStoredProcedure CreateInsertDTNTableStoredProcedure(DTNTable dTNTable)
            {
                // Initial Value
                InsertDTNTableStoredProcedure insertDTNTableStoredProcedure = null;

                // verify dTNTable exists
                if(dTNTable != null)
                {
                    // Instanciate insertDTNTableStoredProcedure
                    insertDTNTableStoredProcedure = new InsertDTNTableStoredProcedure();

                    // Now create parameters for this procedure
                    insertDTNTableStoredProcedure.Parameters = CreateInsertParameters(dTNTable);
                }

                // return value
                return insertDTNTableStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(DTNTable dTNTable)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing dTNTable.
            /// </summary>
            /// <param name="dTNTable">The 'DTNTable' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(DTNTable dTNTable)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[10];
                SqlParameter param = null;

                // verify dTNTableexists
                if(dTNTable != null)
                {
                    // Create parameter for [ClassFileName]
                    param = new SqlParameter("@ClassFileName", dTNTable.ClassFileName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ClassName]
                    param = new SqlParameter("@ClassName", dTNTable.ClassName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [DatabaseId]
                    param = new SqlParameter("@DatabaseId", dTNTable.DatabaseId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Exclude]
                    param = new SqlParameter("@Exclude", dTNTable.Exclude);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [IsView]
                    param = new SqlParameter("@IsView", dTNTable.IsView);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", dTNTable.ProjectId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Scope]
                    param = new SqlParameter("@Scope", dTNTable.Scope);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Serializable]
                    param = new SqlParameter("@Serializable", dTNTable.Serializable);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [TableName]
                    param = new SqlParameter("@TableName", dTNTable.TableName);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [TableId]
                    param = new SqlParameter("@TableId", dTNTable.TableId);
                    parameters[9] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateDTNTableStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateDTNTableStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_Update'.
            /// </summary>
            /// <param name="dTNTable"The 'DTNTable' object to update</param>
            /// <returns>An instance of a 'UpdateDTNTableStoredProcedure</returns>
            public static UpdateDTNTableStoredProcedure CreateUpdateDTNTableStoredProcedure(DTNTable dTNTable)
            {
                // Initial Value
                UpdateDTNTableStoredProcedure updateDTNTableStoredProcedure = null;

                // verify dTNTable exists
                if(dTNTable != null)
                {
                    // Instanciate updateDTNTableStoredProcedure
                    updateDTNTableStoredProcedure = new UpdateDTNTableStoredProcedure();

                    // Now create parameters for this procedure
                    updateDTNTableStoredProcedure.Parameters = CreateUpdateParameters(dTNTable);
                }

                // return value
                return updateDTNTableStoredProcedure;
            }
            #endregion

            #region CreateFetchAllDTNTablesStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNTablesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNTablesStoredProcedure' object.</returns>
            public static FetchAllDTNTablesStoredProcedure CreateFetchAllDTNTablesStoredProcedure(DTNTable dTNTable)
            {
                // Initial value
                FetchAllDTNTablesStoredProcedure fetchAllDTNTablesStoredProcedure = new FetchAllDTNTablesStoredProcedure();

                // return value
                return fetchAllDTNTablesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
