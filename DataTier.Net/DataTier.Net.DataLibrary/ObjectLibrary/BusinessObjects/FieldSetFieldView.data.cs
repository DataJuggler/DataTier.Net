

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSetFieldView
    public partial class FieldSetFieldView
    {

        #region Private Variables
        private int databaseId;
        private DataTypeEnum dataType;
        private int decimalPlaces;
        private string defaultValue;
        private string enumDataTypeName;
        private int fieldId;
        private string fieldName;
        private int fieldOrdinal;
        private int fieldSetFieldId;
        private int fieldSetId;
        private string fieldSetName;
        private int fieldSize;
        private bool isEnumeration;
        private int isNullable;
        private bool orderByDescending;
        private bool parameterMode;
        private bool primaryKey;
        private int projectId;
        private bool required;
        private ScopeEnum scope;
        private int tableId;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int DatabaseId
            public int DatabaseId
            {
                get
                {
                    return databaseId;
                }
                set
                {
                    databaseId = value;
                }
            }
            #endregion

            #region DataTypeEnum DataType
            public DataTypeEnum DataType
            {
                get
                {
                    return dataType;
                }
                set
                {
                    dataType = value;
                }
            }
            #endregion

            #region int DecimalPlaces
            public int DecimalPlaces
            {
                get
                {
                    return decimalPlaces;
                }
                set
                {
                    decimalPlaces = value;
                }
            }
            #endregion

            #region string DefaultValue
            public string DefaultValue
            {
                get
                {
                    return defaultValue;
                }
                set
                {
                    defaultValue = value;
                }
            }
            #endregion

            #region string EnumDataTypeName
            public string EnumDataTypeName
            {
                get
                {
                    return enumDataTypeName;
                }
                set
                {
                    enumDataTypeName = value;
                }
            }
            #endregion

            #region int FieldId
            public int FieldId
            {
                get
                {
                    return fieldId;
                }
                set
                {
                    fieldId = value;
                }
            }
            #endregion

            #region string FieldName
            public string FieldName
            {
                get
                {
                    return fieldName;
                }
                set
                {
                    fieldName = value;
                }
            }
            #endregion

            #region int FieldOrdinal
            public int FieldOrdinal
            {
                get
                {
                    return fieldOrdinal;
                }
                set
                {
                    fieldOrdinal = value;
                }
            }
            #endregion

            #region int FieldSetFieldId
            public int FieldSetFieldId
            {
                get
                {
                    return fieldSetFieldId;
                }
                set
                {
                    fieldSetFieldId = value;
                }
            }
            #endregion

            #region int FieldSetId
            public int FieldSetId
            {
                get
                {
                    return fieldSetId;
                }
                set
                {
                    fieldSetId = value;
                }
            }
            #endregion

            #region string FieldSetName
            public string FieldSetName
            {
                get
                {
                    return fieldSetName;
                }
                set
                {
                    fieldSetName = value;
                }
            }
            #endregion

            #region int FieldSize
            public int FieldSize
            {
                get
                {
                    return fieldSize;
                }
                set
                {
                    fieldSize = value;
                }
            }
            #endregion

            #region bool IsEnumeration
            public bool IsEnumeration
            {
                get
                {
                    return isEnumeration;
                }
                set
                {
                    isEnumeration = value;
                }
            }
            #endregion

            #region int IsNullable
            public int IsNullable
            {
                get
                {
                    return isNullable;
                }
                set
                {
                    isNullable = value;
                }
            }
            #endregion

            #region bool OrderByDescending
            public bool OrderByDescending
            {
                get
                {
                    return orderByDescending;
                }
                set
                {
                    orderByDescending = value;
                }
            }
            #endregion

            #region bool ParameterMode
            public bool ParameterMode
            {
                get
                {
                    return parameterMode;
                }
                set
                {
                    parameterMode = value;
                }
            }
            #endregion

            #region bool PrimaryKey
            public bool PrimaryKey
            {
                get
                {
                    return primaryKey;
                }
                set
                {
                    primaryKey = value;
                }
            }
            #endregion

            #region int ProjectId
            public int ProjectId
            {
                get
                {
                    return projectId;
                }
                set
                {
                    projectId = value;
                }
            }
            #endregion

            #region bool Required
            public bool Required
            {
                get
                {
                    return required;
                }
                set
                {
                    required = value;
                }
            }
            #endregion

            #region ScopeEnum Scope
            public ScopeEnum Scope
            {
                get
                {
                    return scope;
                }
                set
                {
                    scope = value;
                }
            }
            #endregion

            #region int TableId
            public int TableId
            {
                get
                {
                    return tableId;
                }
                set
                {
                    tableId = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
