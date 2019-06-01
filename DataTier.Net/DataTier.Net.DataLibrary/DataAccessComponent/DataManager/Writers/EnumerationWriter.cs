
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
            /// 'FetchAllEnumerationsUsersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Enumeration_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllEnumerationsStoredProcedure' object.</returns>
            public new static FetchAllEnumerationsStoredProcedure CreateFetchAllEnumerationsStoredProcedure(Enumeration enumeration)
            {
                // Initial value
                FetchAllEnumerationsStoredProcedure fetchAllEnumerationsStoredProcedure = new FetchAllEnumerationsStoredProcedure();
                
                // if the ProjectId is set
                if ((enumeration != null) && (enumeration.ProjectId > 0))
                {
                    // set the procedure name
                    fetchAllEnumerationsStoredProcedure.ProcedureName = "Enumeration_FetchAllForProject";
                    
                    // Create the parameters
                    fetchAllEnumerationsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", enumeration.ProjectId);
                }

                // return value
                return fetchAllEnumerationsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
