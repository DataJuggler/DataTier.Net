

#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace DataAccessComponent.Reflection
{

    #region enum FieldDataTypeEnum
    /// <summary>
    /// This enumeration is the choices for 'DataType'
    /// for a 'RequiredField'. This makes generating
    /// the validation possible.
    /// </summary>
    public enum FieldDataTypeEnum : int
    {
        NotSet = 0,
        String = 1,
        Integer = 2,
        MustBeTrueBoolean = 3
    }
    #endregion

}
