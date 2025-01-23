
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

    #region class ProjectReferencesViewWriter
    /// <summary>
    /// This class is used for converting a 'ProjectReferencesView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ProjectReferencesViewWriter : ProjectReferencesViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllProjectReferencesViewsStoredProcedure(ProjectReferencesView projectReferencesView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllProjectReferencesViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReferencesView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllProjectReferencesViewsStoredProcedure' object.</returns>
            public static new FetchAllProjectReferencesViewsStoredProcedure CreateFetchAllProjectReferencesViewsStoredProcedure(ProjectReferencesView projectReferencesView)
            {
                // Initial value
                FetchAllProjectReferencesViewsStoredProcedure fetchAllProjectReferencesViewsStoredProcedure = new FetchAllProjectReferencesViewsStoredProcedure();

                // if the projectReferencesView object exists
                if (projectReferencesView != null)
                {
                    // if LoadByProjectId is true
                    if (projectReferencesView.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllProjectReferencesViewsStoredProcedure.ProcedureName = "ProjectReferencesView_FetchAllForProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllProjectReferencesViewsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", projectReferencesView.ProjectId);
                    }
                }
                
                // return value
                return fetchAllProjectReferencesViewsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
