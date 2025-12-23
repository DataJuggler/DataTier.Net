
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using System.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion

namespace DataAccessComponent.Data.Writers
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

                // if the method object exists
                if (method != null)
                {
                    // if LoadByTableId is true
                    if (method.LoadByTableId)
                    {
                        // Change the procedure name
                        fetchAllMethodsStoredProcedure.ProcedureName = "Method_FetchAllForTableId";
                        
                        // Create the @TableId parameter
                        fetchAllMethodsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@tableId", method.TableId);
                    }
                    // if method.LoadByProjectId is true
                    else if (method.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllMethodsStoredProcedure.ProcedureName = "Method_FetchAllForProjectId";
                        
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
