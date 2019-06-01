

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTier.Net.StoredProcedureGenerator.Enumerations
{

    #region ProcedureTypeEnum
    /// <summary>
    /// This are the choices for the type
    /// of procedure ths is, Insert, Update, Delete, Find, or FetchAll
    /// </summary>
    public enum ProcedureTypeEnum : int
    {
        NotSet = 0,
        Delete = 1,
        FetchAll = 2,
        Find = 3,
        Insert = 4,
        Update = 5
    }
    #endregion

}
