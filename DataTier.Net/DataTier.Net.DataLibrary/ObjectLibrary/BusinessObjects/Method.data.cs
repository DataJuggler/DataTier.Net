

#region using statements

using System;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Method
    public partial class Method
    {

        #region Private Variables
        private bool active;
        private int customReaderId;
        private int methodId;
        private MethodTypeEnum methodType;
        private string name;
        private bool orderByDescending;
        private int orderByFieldId;
        private int orderByFieldSetId;
        private OrderByTypeEnum orderByType;
        private int parameterFieldId;
        private string parameters;
        private int parametersFieldSetId;
        private ParameterTypeEnum parameterType;
        private string procedureName;
        private string procedureText;
        private int projectId;
        private string propertyName;
        private int tableId;
        private int topRows;
        private bool updateProcedureOnBuild;
        private bool useCustomReader;
        private bool useCustomWhere;
        private string whereText;
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

                // Active

                // If Active is true
                if (Active)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // CustomReaderId

                sb.Append(CustomReaderId);

                // Add a comma
                sb.Append(comma);

                // MethodType

                sb.Append(MethodType);

                // Add a comma
                sb.Append(comma);

                // Name

                sb.Append(singleQuote);
                sb.Append(Name);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // OrderByDescending

                // If OrderByDescending is true
                if (OrderByDescending)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // OrderByFieldId

                sb.Append(OrderByFieldId);

                // Add a comma
                sb.Append(comma);

                // OrderByFieldSetId

                sb.Append(OrderByFieldSetId);

                // Add a comma
                sb.Append(comma);

                // OrderByType

                sb.Append(OrderByType);

                // Add a comma
                sb.Append(comma);

                // ParameterFieldId

                sb.Append(ParameterFieldId);

                // Add a comma
                sb.Append(comma);

                // Parameters

                sb.Append(singleQuote);
                sb.Append(Parameters);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ParametersFieldSetId

                sb.Append(ParametersFieldSetId);

                // Add a comma
                sb.Append(comma);

                // ParameterType

                sb.Append(ParameterType);

                // Add a comma
                sb.Append(comma);

                // ProcedureName

                sb.Append(singleQuote);
                sb.Append(ProcedureName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ProcedureText

                sb.Append(singleQuote);
                sb.Append(ProcedureText);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ProjectId

                sb.Append(ProjectId);

                // Add a comma
                sb.Append(comma);

                // PropertyName

                sb.Append(singleQuote);
                sb.Append(PropertyName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // TableId

                sb.Append(TableId);

                // Add a comma
                sb.Append(comma);

                // TopRows

                sb.Append(TopRows);

                // Add a comma
                sb.Append(comma);

                // UpdateProcedureOnBuild

                // If UpdateProcedureOnBuild is true
                if (UpdateProcedureOnBuild)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // UseCustomReader

                // If UseCustomReader is true
                if (UseCustomReader)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // UseCustomWhere

                // If UseCustomWhere is true
                if (UseCustomWhere)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // WhereText

                sb.Append(singleQuote);
                sb.Append(WhereText);
                sb.Append(singleQuote);

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
                string insertSQL = "INSERT INTO [Method] (Active,CustomReaderId,MethodType,Name,OrderByDescending,OrderByFieldId,OrderByFieldSetId,OrderByType,ParameterFieldId,Parameters,ParametersFieldSetId,ParameterType,ProcedureName,ProcedureText,ProjectId,PropertyName,TableId,TopRows,UpdateProcedureOnBuild,UseCustomReader,UseCustomWhere,WhereText) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "Active":

                        // set the value
                        value = this.Active;

                        // required
                        break;

                    case "CustomReaderId":

                        // set the value
                        value = this.CustomReaderId;

                        // required
                        break;

                    case "MethodId":

                        // set the value
                        value = this.MethodId;

                        // required
                        break;

                    case "MethodType":

                        // set the value
                        value = this.MethodType;

                        // required
                        break;

                    case "Name":

                        // set the value
                        value = this.Name;

                        // required
                        break;

                    case "OrderByDescending":

                        // set the value
                        value = this.OrderByDescending;

                        // required
                        break;

                    case "OrderByFieldId":

                        // set the value
                        value = this.OrderByFieldId;

                        // required
                        break;

                    case "OrderByFieldSetId":

                        // set the value
                        value = this.OrderByFieldSetId;

                        // required
                        break;

                    case "OrderByType":

                        // set the value
                        value = this.OrderByType;

                        // required
                        break;

                    case "ParameterFieldId":

                        // set the value
                        value = this.ParameterFieldId;

                        // required
                        break;

                    case "Parameters":

                        // set the value
                        value = this.Parameters;

                        // required
                        break;

                    case "ParametersFieldSetId":

                        // set the value
                        value = this.ParametersFieldSetId;

                        // required
                        break;

                    case "ParameterType":

                        // set the value
                        value = this.ParameterType;

                        // required
                        break;

                    case "ProcedureName":

                        // set the value
                        value = this.ProcedureName;

                        // required
                        break;

                    case "ProcedureText":

                        // set the value
                        value = this.ProcedureText;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "PropertyName":

                        // set the value
                        value = this.PropertyName;

                        // required
                        break;

                    case "TableId":

                        // set the value
                        value = this.TableId;

                        // required
                        break;

                    case "TopRows":

                        // set the value
                        value = this.TopRows;

                        // required
                        break;

                    case "UpdateProcedureOnBuild":

                        // set the value
                        value = this.UpdateProcedureOnBuild;

                        // required
                        break;

                    case "UseCustomReader":

                        // set the value
                        value = this.UseCustomReader;

                        // required
                        break;

                    case "UseCustomWhere":

                        // set the value
                        value = this.UseCustomWhere;

                        // required
                        break;

                    case "WhereText":

                        // set the value
                        value = this.WhereText;

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
                this.methodId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region bool Active
            public bool Active
            {
                get
                {
                    return active;
                }
                set
                {
                    active = value;
                }
            }
            #endregion

            #region int CustomReaderId
            public int CustomReaderId
            {
                get
                {
                    return customReaderId;
                }
                set
                {
                    customReaderId = value;
                }
            }
            #endregion

            #region int MethodId
            public int MethodId
            {
                get
                {
                    return methodId;
                }
            }
            #endregion

            #region MethodTypeEnum MethodType
            public MethodTypeEnum MethodType
            {
                get
                {
                    return methodType;
                }
                set
                {
                    methodType = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
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

            #region int OrderByFieldId
            public int OrderByFieldId
            {
                get
                {
                    return orderByFieldId;
                }
                set
                {
                    orderByFieldId = value;
                }
            }
            #endregion

            #region int OrderByFieldSetId
            public int OrderByFieldSetId
            {
                get
                {
                    return orderByFieldSetId;
                }
                set
                {
                    orderByFieldSetId = value;
                }
            }
            #endregion

            #region OrderByTypeEnum OrderByType
            public OrderByTypeEnum OrderByType
            {
                get
                {
                    return orderByType;
                }
                set
                {
                    orderByType = value;
                }
            }
            #endregion

            #region int ParameterFieldId
            public int ParameterFieldId
            {
                get
                {
                    return parameterFieldId;
                }
                set
                {
                    parameterFieldId = value;
                }
            }
            #endregion

            #region string Parameters
            public string Parameters
            {
                get
                {
                    return parameters;
                }
                set
                {
                    parameters = value;
                }
            }
            #endregion

            #region int ParametersFieldSetId
            public int ParametersFieldSetId
            {
                get
                {
                    return parametersFieldSetId;
                }
                set
                {
                    parametersFieldSetId = value;
                }
            }
            #endregion

            #region ParameterTypeEnum ParameterType
            public ParameterTypeEnum ParameterType
            {
                get
                {
                    return parameterType;
                }
                set
                {
                    parameterType = value;
                }
            }
            #endregion

            #region string ProcedureName
            public string ProcedureName
            {
                get
                {
                    return procedureName;
                }
                set
                {
                    procedureName = value;
                }
            }
            #endregion

            #region string ProcedureText
            public string ProcedureText
            {
                get
                {
                    return procedureText;
                }
                set
                {
                    procedureText = value;
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

            #region string PropertyName
            public string PropertyName
            {
                get
                {
                    return propertyName;
                }
                set
                {
                    propertyName = value;
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

            #region int TopRows
            public int TopRows
            {
                get
                {
                    return topRows;
                }
                set
                {
                    topRows = value;
                }
            }
            #endregion

            #region bool UpdateProcedureOnBuild
            public bool UpdateProcedureOnBuild
            {
                get
                {
                    return updateProcedureOnBuild;
                }
                set
                {
                    updateProcedureOnBuild = value;
                }
            }
            #endregion

            #region bool UseCustomReader
            public bool UseCustomReader
            {
                get
                {
                    return useCustomReader;
                }
                set
                {
                    useCustomReader = value;
                }
            }
            #endregion

            #region bool UseCustomWhere
            public bool UseCustomWhere
            {
                get
                {
                    return useCustomWhere;
                }
                set
                {
                    useCustomWhere = value;
                }
            }
            #endregion

            #region string WhereText
            public string WhereText
            {
                get
                {
                    return whereText;
                }
                set
                {
                    whereText = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.MethodId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
