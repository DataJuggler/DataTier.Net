
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

    #region class DTNDatabaseWriter
    /// <summary>
    /// This class is used for converting a 'DTNDatabase' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNDatabaseWriter : DTNDatabaseWriterBase
    {

        #region Static Methods

            #region CreateFetchAllDTNDatabasesStoredProcedure(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNDatabasesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNDatabasesStoredProcedure' object.</returns>
            public static new FetchAllDTNDatabasesStoredProcedure CreateFetchAllDTNDatabasesStoredProcedure(DTNDatabase dTNDatabase)
            {
                // Initial value
                FetchAllDTNDatabasesStoredProcedure fetchAllDTNDatabasesStoredProcedure = new FetchAllDTNDatabasesStoredProcedure();

                // if the dTNDatabase object exists
                if (dTNDatabase != null)
                {
                    // if LoadByProjectId is true
                    if (dTNDatabase.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllDTNDatabasesStoredProcedure.ProcedureName = "DTNDatabase_FetchAllForProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllDTNDatabasesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@projectId", dTNDatabase.ProjectId);
                    }
                }
                
                // return value
                return fetchAllDTNDatabasesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
