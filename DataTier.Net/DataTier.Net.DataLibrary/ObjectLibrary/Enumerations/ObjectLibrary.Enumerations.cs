

#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace ObjectLibrary.Enumerations
{  

    #region AccessModeEnum
    /// <summary>
    /// Type of Access
    /// </summary>
    public enum AccessModeEnum : int
    {
        ReadOnly = 0,
        WriteOnly = 1,
        ReadWrite = 2
    }
    #endregion

    #region ActionTypeEnum
    /// <summary>
    /// Used to determine what was selected from a dialog.
    /// </summary>
    public enum ActionTypeEnum : int
    {
        NoAction = 0,
        AddButtonClicked = 1,
        EditButtonClicked = 2
    }
    #endregion

    #region DataTypeEnum
    public enum DataTypeEnum : int
    {
        NotSupported = 0,
        Autonumber = 3,
        Currency = 6,
        DateTime = 7,
        Double = 5,
        Integer = 2,
        Percentage = 4,
        String = 130,
        YesNo = 11,
        Decimal = 12,
        DataTable = 10000,
        Binary = 10001,
        Boolean = 10002,
        Guid = 10003,
        Custom = 10004,
        Enumeration = 10005
    }
    #endregion

    #region EditModeEnum
    /// <summary>
    /// This enumeration is used to determine
    /// if we are inserting or updating.
    /// </summary>
    public enum EditModeEnum : int
    {
        Unknown = 0,    
        AddNew = 1,
        Edit = 2
    }
    #endregion

    #region InstallProcedureMethodEnum : int
    /// <summary>
    /// This enum is used for the method of how a procedure will be installed
    /// </summary>
    public enum InstallProcedureMethodEnum : int
    {
        Unknown = 0,
        Manually = 1,
        Install = 2
    }
    #endregion

    #region MethodTypeEnum
    /// <summary>
    /// This enumeration is for the type of Method.
    /// The method creator supports Find By Field(s), Load By Field(s)
    /// </summary>
    public enum MethodTypeEnum : int
    {
        Unknown = 0,
        Delete_By = -1,
        Find_By = 1,
        Load_By = 2
    }
    #endregion

    #region OrderByTypeEnum
    /// <summary>
    /// This enumeration is for the type of Order By Field or Order By Fields
    /// </summary>
    public enum OrderByTypeEnum : int
    {
        No_Order_By = 0,
        Single_Field = 1,
        Field_Set = 2
    }
    #endregion

    #region ParameterTypeEnum
    /// <summary>
    /// This enumeration is for the type of parameter or parameters.
    /// </summary>
    public enum ParameterTypeEnum : int
    {
        No_Parameters = 0,
        Single_Field = 1,
        Field_Set = 2
    }
    #endregion

    #region ScopeEnum
    public enum ScopeEnum : int
    {
        Private = 0,
        Protected = 1,
        Internal = 2,
        Public = 3
    }
    #endregion

    #region SQLAuthenticationTypeEnum : int
    /// <summary>
    /// This enumeration is used to determine
    /// if we are inserting or updating.
    /// </summary>
    public enum SQLAuthenticationTypeEnum : int
    {
        WindowsAuthentication = 0,
        SQLServerAuthentication = 1
    }
    #endregion

    #region UserResponseEnum
    /// <summary>
    /// This enumeration is for the types of responses a user can have from the DialogControl. 
    /// </summary>
    public enum UserResponseEnum : int
    {
        NoResponse = 0,
        Confirmed = 1,
        Cancelled = -1
    }
    #endregion

}
