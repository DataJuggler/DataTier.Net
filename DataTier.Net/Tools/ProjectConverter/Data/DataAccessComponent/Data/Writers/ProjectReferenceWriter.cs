
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

    #region class ProjectReferenceWriter
    /// <summary>
    /// This class is used for converting a 'ProjectReference' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ProjectReferenceWriter : ProjectReferenceWriterBase
    {

        #region Static Methods

            #region CreateFetchAllProjectReferencesStoredProcedure(ProjectReference projectReference)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllProjectReferencesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllProjectReferencesStoredProcedure' object.</returns>
            public static new FetchAllProjectReferencesStoredProcedure CreateFetchAllProjectReferencesStoredProcedure(ProjectReference projectReference)
            {
                // Initial value
                FetchAllProjectReferencesStoredProcedure fetchAllProjectReferencesStoredProcedure = new FetchAllProjectReferencesStoredProcedure();

                // if the projectReference object exists
                if (projectReference != null)
                {
                    // if LoadByReferencesSetId is true
                    if (projectReference.LoadByReferencesSetId)
                    {
                        // Change the procedure name
                        fetchAllProjectReferencesStoredProcedure.ProcedureName = "ProjectReference_FetchAllForReferencesSetId";
                        
                        // Create the @ReferencesSetId parameter
                        fetchAllProjectReferencesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ReferencesSetId", projectReference.ReferencesSetId);
                    }
                }
                
                // return value
                return fetchAllProjectReferencesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
