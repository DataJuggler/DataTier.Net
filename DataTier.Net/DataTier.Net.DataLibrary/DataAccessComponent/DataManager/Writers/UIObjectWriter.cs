

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

    #region class UIObjectWriter
    /// <summary>
    /// This class is used for converting a 'UIObject' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UIObjectWriter : UIObjectWriterBase
    {

        #region Static Methods

            // *******************************************
            // Write any overrides or custom methods here.
            // *******************************************

        #endregion

    }
    #endregion

}
