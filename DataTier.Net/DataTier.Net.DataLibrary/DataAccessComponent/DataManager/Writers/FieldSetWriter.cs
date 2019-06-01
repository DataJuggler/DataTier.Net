

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

    #region class FieldSetWriter
    /// <summary>
    /// This class is used for converting a 'FieldSet' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FieldSetWriter : FieldSetWriterBase
    {

        #region Static Methods

            #region CreateFetchAllFieldSetsStoredProcedure(FieldSet fieldSet)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFieldSetsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSet_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFieldSetsStoredProcedure' object.</returns>
            public static new FetchAllFieldSetsStoredProcedure CreateFetchAllFieldSetsStoredProcedure(FieldSet fieldSet)
            {
                // Initial value
                FetchAllFieldSetsStoredProcedure fetchAllFieldSetsStoredProcedure = new FetchAllFieldSetsStoredProcedure();

                // If the fieldSet object exists
                if (fieldSet != null)
                {
                    // if FetchAllForTable is true and the TableId is set                    
                    if ((fieldSet.FetchAllForTable) && (fieldSet.HasTableId))
                    {
                        // if ParameterMode is true, only FieldSets set to ParameterMode = true will be shown
                        if (fieldSet.ParameterMode)
                        {
                            // change the ProcedureName
                            fetchAllFieldSetsStoredProcedure.ProcedureName = "FieldSet_FetchAllInParameterModeForTable";
                        }
                        else
                        {
                            // change the ProcedureName
                            fetchAllFieldSetsStoredProcedure.ProcedureName = "FieldSet_FetchAllForTable";
                        }

                        // Create the TableId parameter
                        fetchAllFieldSetsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@TableId", fieldSet.TableId);
                    }
                }

                // return value
                return fetchAllFieldSetsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
