
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

    #region class MethodWriter
    /// <summary>
    /// This class is used for converting a 'Method' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MethodWriter : MethodWriterBase
    {

        #region Static Methods

            #region CreateFetchAllMethodsStoredProcedure(Method method)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllMethodsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Method_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllMethodsStoredProcedure' object.</returns>
            public static new FetchAllMethodsStoredProcedure CreateFetchAllMethodsStoredProcedure(Method method)
            {
                // Initial value
                FetchAllMethodsStoredProcedure fetchAllMethodsStoredProcedure = new FetchAllMethodsStoredProcedure();

                // If the method object exists
                if (method != null)
                {
                   if ((method.FetchAllForTable) && (method.HasTableId))
                   {
                        // change the procedureName
                        fetchAllMethodsStoredProcedure.ProcedureName = "Method_FetchAllForTable";

                        // create the @TableId parameter
                        fetchAllMethodsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@TableId", method.TableId);
                    }
                    // if method.LoadByProjectId is true
                    else if (method.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllMethodsStoredProcedure.ProcedureName = "Method_FetchAllByProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllMethodsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", method.ProjectId);
                    }
                }

                // return value
                return fetchAllMethodsStoredProcedure;
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
            public static new FindMethodStoredProcedure CreateFindMethodStoredProcedure(Method method)
            {
                // Initial Value
                FindMethodStoredProcedure findMethodStoredProcedure = null;

                // verify method exists
                if(method != null)
                {
                    // Instanciate findMethodStoredProcedure
                    findMethodStoredProcedure = new FindMethodStoredProcedure();

                    // if method.FindByName is true
                    if (method.FindByName)
                    {
                        // Change the procedure name
                        findMethodStoredProcedure.ProcedureName = "Method_FindByName";
                        
                        // Create the @Name parameter
                        findMethodStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Name", method.Name);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findMethodStoredProcedure.Parameters = CreatePrimaryKeyParameter(method);
                    }
                }

                // return value
                return findMethodStoredProcedure;
            }
            #endregion
        #endregion

    }
    #endregion

}
