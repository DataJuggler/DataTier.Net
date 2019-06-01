

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

    #region class CustomReaderWriter
    /// <summary>
    /// This class is used for converting a 'CustomReader' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class CustomReaderWriter : CustomReaderWriterBase
    {

        #region Static Methods

           #region CreateFetchAllCustomReadersStoredProcedure(CustomReader customReader)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllCustomReadersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'CustomReader_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllCustomReadersStoredProcedure' object.</returns>
            public static new FetchAllCustomReadersStoredProcedure CreateFetchAllCustomReadersStoredProcedure(CustomReader customReader)
            {
                // Initial value
                FetchAllCustomReadersStoredProcedure fetchAllCustomReadersStoredProcedure = new FetchAllCustomReadersStoredProcedure();

                // If the customReader object exists
                if (customReader != null)
                {
                    // if the TableId is set and FetchAllFortable is true
                    if ((customReader.HasTableId) && (customReader.FetchAllForTable))
                    {
                        // change the procedure name
                        fetchAllCustomReadersStoredProcedure.ProcedureName = "CustomReader_FetchAllForTable";

                        // create the @TableId parameter
                        fetchAllCustomReadersStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@TableId", customReader.TableId);
                    }
                }

                // return value
                return fetchAllCustomReadersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
