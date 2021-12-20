

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

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
