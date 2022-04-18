

#region using statements

using System;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class ControlInfoDetailWriterBase
    /// <summary>
    /// This class is used for converting a 'ControlInfoDetail' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ControlInfoDetailWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='controlInfoDetail'>The 'ControlInfoDetail' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ControlInfoDetail controlInfoDetail)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (controlInfoDetail != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", controlInfoDetail.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteControlInfoDetail'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfoDetail_Delete'.
            /// </summary>
            /// <param name="controlInfoDetail">The 'ControlInfoDetail' to Delete.</param>
            /// <returns>An instance of a 'DeleteControlInfoDetailStoredProcedure' object.</returns>
            public static DeleteControlInfoDetailStoredProcedure CreateDeleteControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            {
                // Initial Value
                DeleteControlInfoDetailStoredProcedure deleteControlInfoDetailStoredProcedure = new DeleteControlInfoDetailStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteControlInfoDetailStoredProcedure.Parameters = CreatePrimaryKeyParameter(controlInfoDetail);

                // return value
                return deleteControlInfoDetailStoredProcedure;
            }
            #endregion

            #region CreateFindControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindControlInfoDetailStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfoDetail_Find'.
            /// </summary>
            /// <param name="controlInfoDetail">The 'ControlInfoDetail' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindControlInfoDetailStoredProcedure CreateFindControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            {
                // Initial Value
                FindControlInfoDetailStoredProcedure findControlInfoDetailStoredProcedure = null;

                // verify controlInfoDetail exists
                if(controlInfoDetail != null)
                {
                    // Instanciate findControlInfoDetailStoredProcedure
                    findControlInfoDetailStoredProcedure = new FindControlInfoDetailStoredProcedure();

                    // Now create parameters for this procedure
                    findControlInfoDetailStoredProcedure.Parameters = CreatePrimaryKeyParameter(controlInfoDetail);
                }

                // return value
                return findControlInfoDetailStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new controlInfoDetail.
            /// </summary>
            /// <param name="controlInfoDetail">The 'ControlInfoDetail' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ControlInfoDetail controlInfoDetail)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify controlInfoDetailexists
                if(controlInfoDetail != null)
                {
                    // Create [CodeText] parameter
                    param = new SqlParameter("@CodeText", controlInfoDetail.CodeText);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [DisplayOrder] parameter
                    param = new SqlParameter("@DisplayOrder", controlInfoDetail.DisplayOrder);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [UIControlId] parameter
                    param = new SqlParameter("@UIControlId", controlInfoDetail.UIControlId);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertControlInfoDetailStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfoDetail_Insert'.
            /// </summary>
            /// <param name="controlInfoDetail"The 'ControlInfoDetail' object to insert</param>
            /// <returns>An instance of a 'InsertControlInfoDetailStoredProcedure' object.</returns>
            public static InsertControlInfoDetailStoredProcedure CreateInsertControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            {
                // Initial Value
                InsertControlInfoDetailStoredProcedure insertControlInfoDetailStoredProcedure = null;

                // verify controlInfoDetail exists
                if(controlInfoDetail != null)
                {
                    // Instanciate insertControlInfoDetailStoredProcedure
                    insertControlInfoDetailStoredProcedure = new InsertControlInfoDetailStoredProcedure();

                    // Now create parameters for this procedure
                    insertControlInfoDetailStoredProcedure.Parameters = CreateInsertParameters(controlInfoDetail);
                }

                // return value
                return insertControlInfoDetailStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing controlInfoDetail.
            /// </summary>
            /// <param name="controlInfoDetail">The 'ControlInfoDetail' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ControlInfoDetail controlInfoDetail)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify controlInfoDetailexists
                if(controlInfoDetail != null)
                {
                    // Create parameter for [CodeText]
                    param = new SqlParameter("@CodeText", controlInfoDetail.CodeText);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [DisplayOrder]
                    param = new SqlParameter("@DisplayOrder", controlInfoDetail.DisplayOrder);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [UIControlId]
                    param = new SqlParameter("@UIControlId", controlInfoDetail.UIControlId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", controlInfoDetail.Id);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateControlInfoDetailStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfoDetail_Update'.
            /// </summary>
            /// <param name="controlInfoDetail"The 'ControlInfoDetail' object to update</param>
            /// <returns>An instance of a 'UpdateControlInfoDetailStoredProcedure</returns>
            public static UpdateControlInfoDetailStoredProcedure CreateUpdateControlInfoDetailStoredProcedure(ControlInfoDetail controlInfoDetail)
            {
                // Initial Value
                UpdateControlInfoDetailStoredProcedure updateControlInfoDetailStoredProcedure = null;

                // verify controlInfoDetail exists
                if(controlInfoDetail != null)
                {
                    // Instanciate updateControlInfoDetailStoredProcedure
                    updateControlInfoDetailStoredProcedure = new UpdateControlInfoDetailStoredProcedure();

                    // Now create parameters for this procedure
                    updateControlInfoDetailStoredProcedure.Parameters = CreateUpdateParameters(controlInfoDetail);
                }

                // return value
                return updateControlInfoDetailStoredProcedure;
            }
            #endregion

            #region CreateFetchAllControlInfoDetailsStoredProcedure(ControlInfoDetail controlInfoDetail)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllControlInfoDetailsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ControlInfoDetail_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllControlInfoDetailsStoredProcedure' object.</returns>
            public static FetchAllControlInfoDetailsStoredProcedure CreateFetchAllControlInfoDetailsStoredProcedure(ControlInfoDetail controlInfoDetail)
            {
                // Initial value
                FetchAllControlInfoDetailsStoredProcedure fetchAllControlInfoDetailsStoredProcedure = new FetchAllControlInfoDetailsStoredProcedure();

                // return value
                return fetchAllControlInfoDetailsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
