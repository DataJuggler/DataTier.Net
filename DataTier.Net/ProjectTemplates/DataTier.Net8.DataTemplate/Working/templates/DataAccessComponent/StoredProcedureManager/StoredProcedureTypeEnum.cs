

#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion


namespace DataAccessComponent.StoredProcedureManager
{

    #region enum StoredProcedureTypeEnum : int
    /// <summary>
    /// The choices for type of stored procedure;
    /// Fetch, Insert, Update.
    /// </summary>
    public enum StoredProcedureTypeEnum : int
    {
        NotSet = 0,
        Fetch = 1,
        Insert = 2,
        Update = 3
    }
    #endregion

}
