

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

    #region class ReferencesSetWriter
    /// <summary>
    /// This class is used for converting a 'ReferencesSet' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ReferencesSetWriter : ReferencesSetWriterBase
    {

        #region Static Methods

            #region CreateFetchAllReferencesSetsStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllReferencesSetsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllReferencesSetsStoredProcedure' object.</returns>
            public static new FetchAllReferencesSetsStoredProcedure CreateFetchAllReferencesSetsStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial value
                FetchAllReferencesSetsStoredProcedure fetchAllReferencesSetsStoredProcedure = new FetchAllReferencesSetsStoredProcedure();

                // If the referencesSet object exists
                if (referencesSet != null)
                {
                    // if FetchAllForProjectId is true
                    if (referencesSet.FetchAllForProjectId)
                    {
                        // Change the procedure name
                        fetchAllReferencesSetsStoredProcedure.ProcedureName = "ReferencesSet_FetchAllForProjectId";

                        // Create the @projectId parameter
                        fetchAllReferencesSetsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@projectId", referencesSet.ProjectId);
                    }
                }

                // return value
                return fetchAllReferencesSetsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
