

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
            /// 'FetchAllProjectReferencesUsersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllProjectReferencesStoredProcedure' object.</returns>
            public static new FetchAllProjectReferencesStoredProcedure CreateFetchAllProjectReferencesStoredProcedure(ProjectReference projectReference)
            {
                // Initial value
                FetchAllProjectReferencesStoredProcedure fetchAllProjectReferencesStoredProcedure = new FetchAllProjectReferencesStoredProcedure();

                // if the projectReference exists
                if ((projectReference != null) && (projectReference.ReferencesSetId > 0))
                {
                    // set the procedure name
                    fetchAllProjectReferencesStoredProcedure.ProcedureName = "ProjectReference_FetchAllForReferencesSet";

                    // create the ReferencesSetID parameter
                    fetchAllProjectReferencesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ReferencesSetID", projectReference.ReferencesSetId);
                }

                // return value
                return fetchAllProjectReferencesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
