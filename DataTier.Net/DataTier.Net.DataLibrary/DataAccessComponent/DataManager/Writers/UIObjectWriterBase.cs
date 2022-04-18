

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

    #region class UIObjectWriterBase
    /// <summary>
    /// This class is used for converting a 'UIObject' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UIObjectWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(UIObject uIObject)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='uIObject'>The 'UIObject' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(UIObject uIObject)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (uIObject != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", uIObject.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteUIObjectStoredProcedure(UIObject uIObject)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteUIObject'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIObject_Delete'.
            /// </summary>
            /// <param name="uIObject">The 'UIObject' to Delete.</param>
            /// <returns>An instance of a 'DeleteUIObjectStoredProcedure' object.</returns>
            public static DeleteUIObjectStoredProcedure CreateDeleteUIObjectStoredProcedure(UIObject uIObject)
            {
                // Initial Value
                DeleteUIObjectStoredProcedure deleteUIObjectStoredProcedure = new DeleteUIObjectStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteUIObjectStoredProcedure.Parameters = CreatePrimaryKeyParameter(uIObject);

                // return value
                return deleteUIObjectStoredProcedure;
            }
            #endregion

            #region CreateFindUIObjectStoredProcedure(UIObject uIObject)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindUIObjectStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIObject_Find'.
            /// </summary>
            /// <param name="uIObject">The 'UIObject' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindUIObjectStoredProcedure CreateFindUIObjectStoredProcedure(UIObject uIObject)
            {
                // Initial Value
                FindUIObjectStoredProcedure findUIObjectStoredProcedure = null;

                // verify uIObject exists
                if(uIObject != null)
                {
                    // Instanciate findUIObjectStoredProcedure
                    findUIObjectStoredProcedure = new FindUIObjectStoredProcedure();

                    // Now create parameters for this procedure
                    findUIObjectStoredProcedure.Parameters = CreatePrimaryKeyParameter(uIObject);
                }

                // return value
                return findUIObjectStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(UIObject uIObject)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new uIObject.
            /// </summary>
            /// <param name="uIObject">The 'UIObject' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(UIObject uIObject)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[11];
                SqlParameter param = null;

                // verify uIObjectexists
                if(uIObject != null)
                {
                    // Create [ControlType] parameter
                    param = new SqlParameter("@ControlType", uIObject.ControlType);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [DisplayOrder] parameter
                    param = new SqlParameter("@DisplayOrder", uIObject.DisplayOrder);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [FormType] parameter
                    param = new SqlParameter("@FormType", uIObject.FormType);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Height] parameter
                    param = new SqlParameter("@Height", uIObject.Height);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [IsControl] parameter
                    param = new SqlParameter("@IsControl", uIObject.IsControl);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [IsForm] parameter
                    param = new SqlParameter("@IsForm", uIObject.IsForm);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Left] parameter
                    param = new SqlParameter("@Left", uIObject.Left);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", uIObject.Name);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [ParentId] parameter
                    param = new SqlParameter("@ParentId", uIObject.ParentId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [Top] parameter
                    param = new SqlParameter("@Top", uIObject.Top);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [Width] parameter
                    param = new SqlParameter("@Width", uIObject.Width);

                    // set parameters[10]
                    parameters[10] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertUIObjectStoredProcedure(UIObject uIObject)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertUIObjectStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIObject_Insert'.
            /// </summary>
            /// <param name="uIObject"The 'UIObject' object to insert</param>
            /// <returns>An instance of a 'InsertUIObjectStoredProcedure' object.</returns>
            public static InsertUIObjectStoredProcedure CreateInsertUIObjectStoredProcedure(UIObject uIObject)
            {
                // Initial Value
                InsertUIObjectStoredProcedure insertUIObjectStoredProcedure = null;

                // verify uIObject exists
                if(uIObject != null)
                {
                    // Instanciate insertUIObjectStoredProcedure
                    insertUIObjectStoredProcedure = new InsertUIObjectStoredProcedure();

                    // Now create parameters for this procedure
                    insertUIObjectStoredProcedure.Parameters = CreateInsertParameters(uIObject);
                }

                // return value
                return insertUIObjectStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(UIObject uIObject)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing uIObject.
            /// </summary>
            /// <param name="uIObject">The 'UIObject' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(UIObject uIObject)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[12];
                SqlParameter param = null;

                // verify uIObjectexists
                if(uIObject != null)
                {
                    // Create parameter for [ControlType]
                    param = new SqlParameter("@ControlType", uIObject.ControlType);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [DisplayOrder]
                    param = new SqlParameter("@DisplayOrder", uIObject.DisplayOrder);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [FormType]
                    param = new SqlParameter("@FormType", uIObject.FormType);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Height]
                    param = new SqlParameter("@Height", uIObject.Height);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [IsControl]
                    param = new SqlParameter("@IsControl", uIObject.IsControl);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [IsForm]
                    param = new SqlParameter("@IsForm", uIObject.IsForm);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Left]
                    param = new SqlParameter("@Left", uIObject.Left);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", uIObject.Name);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [ParentId]
                    param = new SqlParameter("@ParentId", uIObject.ParentId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Top]
                    param = new SqlParameter("@Top", uIObject.Top);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [Width]
                    param = new SqlParameter("@Width", uIObject.Width);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", uIObject.Id);
                    parameters[11] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateUIObjectStoredProcedure(UIObject uIObject)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateUIObjectStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIObject_Update'.
            /// </summary>
            /// <param name="uIObject"The 'UIObject' object to update</param>
            /// <returns>An instance of a 'UpdateUIObjectStoredProcedure</returns>
            public static UpdateUIObjectStoredProcedure CreateUpdateUIObjectStoredProcedure(UIObject uIObject)
            {
                // Initial Value
                UpdateUIObjectStoredProcedure updateUIObjectStoredProcedure = null;

                // verify uIObject exists
                if(uIObject != null)
                {
                    // Instanciate updateUIObjectStoredProcedure
                    updateUIObjectStoredProcedure = new UpdateUIObjectStoredProcedure();

                    // Now create parameters for this procedure
                    updateUIObjectStoredProcedure.Parameters = CreateUpdateParameters(uIObject);
                }

                // return value
                return updateUIObjectStoredProcedure;
            }
            #endregion

            #region CreateFetchAllUIObjectsStoredProcedure(UIObject uIObject)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllUIObjectsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIObject_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllUIObjectsStoredProcedure' object.</returns>
            public static FetchAllUIObjectsStoredProcedure CreateFetchAllUIObjectsStoredProcedure(UIObject uIObject)
            {
                // Initial value
                FetchAllUIObjectsStoredProcedure fetchAllUIObjectsStoredProcedure = new FetchAllUIObjectsStoredProcedure();

                // return value
                return fetchAllUIObjectsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
