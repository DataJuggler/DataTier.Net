
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

    #region class FieldSetFieldViewWriter
    /// <summary>
    /// This class is used for converting a 'FieldSetFieldView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FieldSetFieldViewWriter : FieldSetFieldViewWriterBase
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
            public static new FetchAllFieldSetFieldViewsStoredProcedure CreateFetchAllFieldSetFieldViewsStoredProcedure(FieldSetFieldView fieldSetFieldView)
            {
                // Initial value
                FetchAllFieldSetFieldViewsStoredProcedure fetchAllFieldSetFieldViewsStoredProcedure = new FetchAllFieldSetFieldViewsStoredProcedure();

                // if the fieldSetFieldView object exists
                if (fieldSetFieldView != null)
                {
                    // if LoadByFieldSetId is true
                    if (fieldSetFieldView.LoadByFieldSetId)
                    {
                        // Change the procedure name
                        fetchAllFieldSetFieldViewsStoredProcedure.ProcedureName = "FieldSetFieldView_FetchAllForFieldSetId";
                        
                        // Create the @FieldSetId parameter
                        fetchAllFieldSetFieldViewsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@fieldSetId", fieldSetFieldView.FieldSetId);
                    }
                }
                
                // return value
                return fetchAllFieldSetFieldViewsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
