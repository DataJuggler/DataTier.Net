

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
            public static new FetchAllDTNFieldsStoredProcedure CreateFetchAllDTNFieldsStoredProcedure(DTNField field)
            {
                // Initial value
                FetchAllDTNFieldsStoredProcedure fetchAllDTNFieldsStoredProcedure = new FetchAllDTNFieldsStoredProcedure();

                // If the dTNField object exists
                if (field != null)
                {
                    // if FetchAllForTable is true and the TableId is set
                    if ((field.FetchAllForTable) && (field.HasTableId))
                    {
                        // change the procedure name
                        fetchAllDTNFieldsStoredProcedure.ProcedureName = "DTNField_FetchAllForTableId";

                        // create the @TableId parameter
                        fetchAllDTNFieldsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@TableId", field.TableId);
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
