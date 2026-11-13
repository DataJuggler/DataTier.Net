
#region using statements

using System;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using System.Data;
using Microsoft.Data.SqlClient;

#endregion

namespace DataAccessComponent.Data.Writers
{

    #region class BuildExcludesWriter
    /// <summary>
    /// This class is used for converting a 'BuildExcludes' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class BuildExcludesWriter : BuildExcludesWriterBase
    {

        #region Static Methods

            #region CreateFetchAllBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllBuildExcludesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllBuildExcludesStoredProcedure' object.</returns>
            public static new FetchAllBuildExcludesStoredProcedure CreateFetchAllBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial value
                FetchAllBuildExcludesStoredProcedure fetchAllBuildExcludesStoredProcedure = new FetchAllBuildExcludesStoredProcedure();

                // if the buildExcludes object exists
                if (buildExcludes != null)
                {
                    // if LoadByProjectId is true
                    if (buildExcludes.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllBuildExcludesStoredProcedure.ProcedureName = "BuildExcludes_FetchAllForProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllBuildExcludesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@projectId", buildExcludes.ProjectId);
                    }
                }
                
                // return value
                return fetchAllBuildExcludesStoredProcedure;
            }
            #endregion
            
            #region CreateFindBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindBuildExcludesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'BuildExcludes_Find'.
            /// </summary>
            /// <param name="buildExcludes">The 'BuildExcludes' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindBuildExcludesStoredProcedure CreateFindBuildExcludesStoredProcedure(BuildExcludes buildExcludes)
            {
                // Initial Value
                FindBuildExcludesStoredProcedure findBuildExcludesStoredProcedure = null;

                // verify buildExcludes exists
                if(buildExcludes != null)
                {
                    // Instanciate findBuildExcludesStoredProcedure
                    findBuildExcludesStoredProcedure = new FindBuildExcludesStoredProcedure();

                    // if buildExcludes.FindByTableId is true
                    if (buildExcludes.FindByTableId)
                    {
                        // Change the procedure name
                        findBuildExcludesStoredProcedure.ProcedureName = "BuildExcludes_FindByTableId";
                        
                        // Create the @TableId parameter
                        findBuildExcludesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@TableId", buildExcludes.TableId);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findBuildExcludesStoredProcedure.Parameters = CreatePrimaryKeyParameter(buildExcludes);
                    }
                }

                // return value
                return findBuildExcludesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
