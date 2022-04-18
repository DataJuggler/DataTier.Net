

#region using statements

using System;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class ProjectReferencesViewWriterBase
    /// <summary>
    /// This class is used for converting a 'ProjectReferencesView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ProjectReferencesViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllProjectReferencesViewsStoredProcedure(ProjectReferencesView projectReferencesView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllProjectReferencesViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReferencesView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllProjectReferencesViewsStoredProcedure' object.</returns>
            public static FetchAllProjectReferencesViewsStoredProcedure CreateFetchAllProjectReferencesViewsStoredProcedure(ProjectReferencesView projectReferencesView)
            {
                // Initial value
                FetchAllProjectReferencesViewsStoredProcedure fetchAllProjectReferencesViewsStoredProcedure = new FetchAllProjectReferencesViewsStoredProcedure();

                // return value
                return fetchAllProjectReferencesViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
