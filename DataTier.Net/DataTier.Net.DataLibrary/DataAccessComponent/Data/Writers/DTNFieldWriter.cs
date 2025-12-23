
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

    #region class DTNFieldWriter
    /// <summary>
    /// This class is used for converting a 'DTNField' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DTNFieldWriter : DTNFieldWriterBase
    {

        #region Static Methods

            #region CreateFetchAllDTNFieldsStoredProcedure(DTNField dTNField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDTNFieldsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DTNField_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDTNFieldsStoredProcedure' object.</returns>
            public static new FetchAllDTNFieldsStoredProcedure CreateFetchAllDTNFieldsStoredProcedure(DTNField dTNField)
            {
                // Initial value
                FetchAllDTNFieldsStoredProcedure fetchAllDTNFieldsStoredProcedure = new FetchAllDTNFieldsStoredProcedure();

                // if the dTNField object exists
                if (dTNField != null)
                {
                    // if LoadByTableId is true
                    if (dTNField.LoadByTableId)
                    {
                        // Change the procedure name
                        fetchAllDTNFieldsStoredProcedure.ProcedureName = "DTNField_FetchAllForTableId";
                        
                        // Create the @TableId parameter
                        fetchAllDTNFieldsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@tableId", dTNField.TableId);
                    }
                }
                
                // return value
                return fetchAllDTNFieldsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
