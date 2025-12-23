

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

    #region class FieldSetFieldViewWriterBase
    /// <summary>
    /// This class is used for converting a 'FieldSetFieldView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FieldSetFieldViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllFieldSetFieldViewsStoredProcedure(FieldSetFieldView fieldSetFieldView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFieldSetFieldViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FieldSetFieldView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFieldSetFieldViewsStoredProcedure' object.</returns>
            public static FetchAllFieldSetFieldViewsStoredProcedure CreateFetchAllFieldSetFieldViewsStoredProcedure(FieldSetFieldView fieldSetFieldView)
            {
                // Initial value
                FetchAllFieldSetFieldViewsStoredProcedure fetchAllFieldSetFieldViewsStoredProcedure = new FetchAllFieldSetFieldViewsStoredProcedure();

                // return value
                return fetchAllFieldSetFieldViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
