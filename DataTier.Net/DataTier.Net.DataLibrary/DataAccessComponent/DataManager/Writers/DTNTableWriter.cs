

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
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

                // If the dTNTable object exists
                if (dTNTable != null)
                {
                    // if FetchAllForProjectId is true and the ProjectId is set
                    if ((dTNTable.FetchAllForProjectId) && (dTNTable.HasProjectId))
                    {
                        // Set the ProcedureName
                        fetchAllDTNTablesStoredProcedure.ProcedureName = "DTNTable_FetchAllForProjectId";

                        // Set the Parameter for @ProjectID
                        fetchAllDTNTablesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", dTNTable.ProjectId);
                    }
                }

                // return value
                return fetchAllDTNTablesStoredProcedure;
            }
            #endregion

            #region CreateDeleteDTNTableStoredProcedure(DTNTable dTNTable)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDTNTable'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNTable_Delete'.
            /// </summary>
            /// <param name="dTNTable">The 'DTNTable' to Delete.</param>
            /// <returns>An instance of a 'DeleteDTNTableStoredProcedure' object.</returns>
            public static new DeleteDTNTableStoredProcedure CreateDeleteDTNTableStoredProcedure(DTNTable table)
            {
                // Initial Value
                DeleteDTNTableStoredProcedure deleteDTNTableStoredProcedure = new DeleteDTNTableStoredProcedure();

                // If the table object exists
                if (table != null)
                {
                    // if DeleteAllForProjectId is true and the ProjectId is set
                    if ((table.DeleteAllForProjectId) && (table.HasProjectId))
                    {
                        // change the procedureName
                        deleteDTNTableStoredProcedure.ProcedureName = "DTNTable_DeleteAllForProject";

                        // Set the @ProjectId parameter
                        deleteDTNTableStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", table.ProjectId);
                    }
                    else
                    {
                        // Now Create Parameters For The DeleteProc
                        deleteDTNTableStoredProcedure.Parameters = CreatePrimaryKeyParameter(table);
                    }
                }
                
                // return value
                return deleteDTNTableStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
