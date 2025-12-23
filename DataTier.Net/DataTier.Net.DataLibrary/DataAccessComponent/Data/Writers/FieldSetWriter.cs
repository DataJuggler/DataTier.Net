
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

                // if the fieldSet object exists
                if (fieldSet != null)
                {
                    // if LoadByTableId is true
                    if (fieldSet.LoadByTableId)
                    {
                        // Change the procedure name
                        fetchAllFieldSetsStoredProcedure.ProcedureName = "FieldSet_FetchAllForTableId";
                        
                        // Create the @TableId parameter
                        fetchAllFieldSetsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@tableId", fieldSet.TableId);
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
