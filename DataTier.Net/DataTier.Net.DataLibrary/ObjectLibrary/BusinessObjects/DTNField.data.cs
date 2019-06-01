

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNField
    public partial class DTNField
    {

        #region Private Variables
        private AccessModeEnum accessMode;
        private string caption;
        private int databaseId;
        private DataTypeEnum dataType;
        private int decimalPlaces;
        private string defaultValue;
        private string enumDataTypeName;
        private bool exclude;
        private int fieldId;
        private string fieldName;
        private int fieldOrdinal;
        private int fieldSize;
        private bool isEnumeration;
        private int isNullable;
        private bool primaryKey;
        private int projectId;
        private bool required;
        private ScopeEnum scope;
        private int tableId;
        private bool delete;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.fieldId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region AccessModeEnum AccessMode
            public AccessModeEnum AccessMode
            {
                get
                {
                    return accessMode;
                }
                set
                {
                    accessMode = value;
                }
            }
            #endregion

            #region string Caption
            public string Caption
            {
                get
                {
                    return caption;
                }
                set
                {
                    caption = value;
                }
            }
            #endregion

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

            #region bool Exclude
            public bool Exclude
            {
                get
                {
                    return exclude;
                }
                set
                {
                    exclude = value;
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

            #region bool Delete
            public bool Delete
            {
                get
                {
                    return delete;
                }
                set
                {
                    delete = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.FieldId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
