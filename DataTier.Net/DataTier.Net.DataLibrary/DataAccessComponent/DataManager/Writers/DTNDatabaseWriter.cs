
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

    #region class DTNDatabaseWriter
    /// <summary>
    /// This class is used for converting a 'DTNDatabase' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNDatabaseWriter : DTNDatabaseWriterBase
    {

        #region Static Methods

            #region CreateFetchAllDTNDatabasesStoredProcedure(DTNDatabase database)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNDatabasesUsersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNDatabase_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNDatabasesStoredProcedure' object.</returns>
            public new static FetchAllDTNDatabasesStoredProcedure CreateFetchAllDTNDatabasesStoredProcedure(DTNDatabase database)
            {
                // Initial value
                FetchAllDTNDatabasesStoredProcedure fetchAllDTNDatabasesStoredProcedure = new FetchAllDTNDatabasesStoredProcedure();

                // verify the database exists
                if ((database != null) && (database.ProjectId > 0))
                {
                    // set the procedure name
                    fetchAllDTNDatabasesStoredProcedure.ProcedureName = "DTNDatabase_FetchAllForProject";

                    // create the parameters
                    fetchAllDTNDatabasesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", database.ProjectId);
                }
                
                // return value
                return fetchAllDTNDatabasesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
