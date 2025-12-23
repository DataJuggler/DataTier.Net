

#region using statements

using DataJuggler.Net.Enumerations;
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
        #endregion

        #region Methods

            #region CreateValuesList
            // <summary>
            // This method creates the ValuesList for an Insert SQL Statement.'
            // </summary>
            public string CreateValuesList()
            {
                // initial value
                string valuesList = "";

                // locals
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string comma = ",";
                string singleQuote = "'";

                // AccessMode

                sb.Append(AccessMode);

                // Add a comma
                sb.Append(comma);

                // Caption

                sb.Append(singleQuote);
                sb.Append(Caption);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DatabaseId

                sb.Append(DatabaseId);

                // Add a comma
                sb.Append(comma);

                // DataType

                sb.Append(DataType);

                // Add a comma
                sb.Append(comma);

                // DecimalPlaces

                sb.Append(DecimalPlaces);

                // Add a comma
                sb.Append(comma);

                // DefaultValue

                sb.Append(singleQuote);
                sb.Append(DefaultValue);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // EnumDataTypeName

                sb.Append(singleQuote);
                sb.Append(EnumDataTypeName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // Exclude

                // If Exclude is true
                if (Exclude)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // FieldName

                sb.Append(singleQuote);
                sb.Append(FieldName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // FieldOrdinal

                sb.Append(FieldOrdinal);

                // Add a comma
                sb.Append(comma);

                // FieldSize

                sb.Append(FieldSize);

                // Add a comma
                sb.Append(comma);

                // IsEnumeration

                // If IsEnumeration is true
                if (IsEnumeration)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // IsNullable

                sb.Append(IsNullable);

                // Add a comma
                sb.Append(comma);

                // PrimaryKey

                // If PrimaryKey is true
                if (PrimaryKey)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // ProjectId

                sb.Append(ProjectId);

                // Add a comma
                sb.Append(comma);

                // Required

                // If Required is true
                if (Required)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // Scope

                sb.Append(Scope);

                // Add a comma
                sb.Append(comma);

                // TableId

                sb.Append(TableId);

                // Set the return value
                valuesList = sb.ToString();

                // Return Value
                return valuesList;
            }
            #endregion

            #region GenerateInsertSQL
            // <summary>
            // This method generates a SQL Insert statement for ah object loaded.'
            // </summary>
            public string GenerateInsertSQL()
            {
                // local
                string valuesList = CreateValuesList();

                // Set the return Value
                string insertSQL = "INSERT INTO [DTNField] (AccessMode,Caption,DatabaseId,DataType,DecimalPlaces,DefaultValue,EnumDataTypeName,Exclude,FieldName,FieldOrdinal,FieldSize,IsEnumeration,IsNullable,PrimaryKey,ProjectId,Required,Scope,TableId) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

                // Return Value
                return insertSQL;
            }
            #endregion

            #region GetValue(string fieldName)
            // <summary>
            // This method returns the value for the fieldName given
            // </summary>
            public object GetValue(string fieldName)
            {
                // initial value
                object value = "";

                // // Determine the action by the fieldName
                switch (fieldName)
                {
                    case "AccessMode":

                        // set the value
                        value = this.AccessMode;

                        // required
                        break;

                    case "Caption":

                        // set the value
                        value = this.Caption;

                        // required
                        break;

                    case "DatabaseId":

                        // set the value
                        value = this.DatabaseId;

                        // required
                        break;

                    case "DataType":

                        // set the value
                        value = this.DataType;

                        // required
                        break;

                    case "DecimalPlaces":

                        // set the value
                        value = this.DecimalPlaces;

                        // required
                        break;

                    case "DefaultValue":

                        // set the value
                        value = this.DefaultValue;

                        // required
                        break;

                    case "EnumDataTypeName":

                        // set the value
                        value = this.EnumDataTypeName;

                        // required
                        break;

                    case "Exclude":

                        // set the value
                        value = this.Exclude;

                        // required
                        break;

                    case "FieldId":

                        // set the value
                        value = this.FieldId;

                        // required
                        break;

                    case "FieldName":

                        // set the value
                        value = this.FieldName;

                        // required
                        break;

                    case "FieldOrdinal":

                        // set the value
                        value = this.FieldOrdinal;

                        // required
                        break;

                    case "FieldSize":

                        // set the value
                        value = this.FieldSize;

                        // required
                        break;

                    case "IsEnumeration":

                        // set the value
                        value = this.IsEnumeration;

                        // required
                        break;

                    case "IsNullable":

                        // set the value
                        value = this.IsNullable;

                        // required
                        break;

                    case "PrimaryKey":

                        // set the value
                        value = this.PrimaryKey;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "Required":

                        // set the value
                        value = this.Required;

                        // required
                        break;

                    case "Scope":

                        // set the value
                        value = this.Scope;

                        // required
                        break;

                    case "TableId":

                        // set the value
                        value = this.TableId;

                        // required
                        break;

                }

                // return value
                return value;
            }
            #endregion

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
