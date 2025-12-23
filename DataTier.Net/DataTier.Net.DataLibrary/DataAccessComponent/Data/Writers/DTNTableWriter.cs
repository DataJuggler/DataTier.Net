
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

    #region class DTNTableWriter
    /// <summary>
    /// This class is used for converting a 'DTNTable' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNTableWriter : DTNTableWriterBase
    {

        #region Static Methods

            #region CreateFetchAllDTNTablesStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNTablesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNTablesStoredProcedure' object.</returns>
            public static new FetchAllDTNTablesStoredProcedure CreateFetchAllDTNTablesStoredProcedure(DTNTable dTNTable)
            {
                // Initial value
                FetchAllDTNTablesStoredProcedure fetchAllDTNTablesStoredProcedure = new FetchAllDTNTablesStoredProcedure();

                // if the dTNTable object exists
                if (dTNTable != null)
                {
                    // if LoadByProjectId is true
                    if (dTNTable.LoadByProjectId)
                    {
                        // Change the procedure name
                        fetchAllDTNTablesStoredProcedure.ProcedureName = "DTNTable_FetchAllForProjectId";
                        
                        // Create the @ProjectId parameter
                        fetchAllDTNTablesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@projectId", dTNTable.ProjectId);
                    }
                }
                
                // return value
                return fetchAllDTNTablesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
