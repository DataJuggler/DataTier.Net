
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

    #region class EnumerationWriter
    /// <summary>
    /// This class is used for converting a 'Enumeration' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class EnumerationWriter : EnumerationWriterBase
    {

        #region Static Methods

            #region CreateFetchAllEnumerationsStoredProcedure(Enumeration enumeration)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllEnumerationsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllEnumerationsStoredProcedure' object.</returns>
            public static new FetchAllEnumerationsStoredProcedure CreateFetchAllEnumerationsStoredProcedure(Enumeration enumeration)
            {
                // Initial value
                FetchAllEnumerationsStoredProcedure fetchAllEnumerationsStoredProcedure = new FetchAllEnumerationsStoredProcedure();

                // if the enumeration object exists
                if (enumeration != null)
                {
                    // if LoadByProjectId is true
                    if (enumeration.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllEnumerationsStoredProcedure.ProcedureName = "Enumeration_FetchAllForProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllEnumerationsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@projectId", enumeration.ProjectId);
                    }
                }
                
                // return value
                return fetchAllEnumerationsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
