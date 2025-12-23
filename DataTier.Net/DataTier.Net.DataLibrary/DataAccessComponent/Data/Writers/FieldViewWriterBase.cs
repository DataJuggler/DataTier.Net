

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


namespace DataAccessComponent.Data.Writers
{

    #region class FieldViewWriterBase
    /// <summary>
    /// This class is used for converting a 'FieldView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FieldViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllFieldViewsStoredProcedure(FieldView fieldView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFieldViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFieldViewsStoredProcedure' object.</returns>
            public static FetchAllFieldViewsStoredProcedure CreateFetchAllFieldViewsStoredProcedure(FieldView fieldView)
            {
                // Initial value
                FetchAllFieldViewsStoredProcedure fetchAllFieldViewsStoredProcedure = new FetchAllFieldViewsStoredProcedure();

                // return value
                return fetchAllFieldViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
