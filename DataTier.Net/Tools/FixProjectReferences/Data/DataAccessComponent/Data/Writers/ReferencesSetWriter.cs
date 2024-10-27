
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

                // if the referencesSet object exists
                if (referencesSet != null)
                {
                    // if LoadByProjectId is true
                    if (referencesSet.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllReferencesSetsStoredProcedure.ProcedureName = "ReferencesSet_FetchAllForProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllReferencesSetsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", referencesSet.ProjectId);
                    }
                }
                
                // return value
                return fetchAllReferencesSetsStoredProcedure;
            }
            #endregion
            
            #region CreateFindReferencesSetStoredProcedure(ReferencesSet referencesSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindReferencesSetStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ReferencesSet_Find'.
            /// </summary>
            /// <param name="referencesSet">The 'ReferencesSet' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindReferencesSetStoredProcedure CreateFindReferencesSetStoredProcedure(ReferencesSet referencesSet)
            {
                // Initial Value
                FindReferencesSetStoredProcedure findReferencesSetStoredProcedure = null;

                // verify referencesSet exists
                if(referencesSet != null)
                {
                    // Instantiate findReferencesSetStoredProcedure
                    findReferencesSetStoredProcedure = new FindReferencesSetStoredProcedure();

                    // Now create parameters for this procedure
                    findReferencesSetStoredProcedure.Parameters = CreatePrimaryKeyParameter(referencesSet);                    
                }

                // return value
                return findReferencesSetStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
