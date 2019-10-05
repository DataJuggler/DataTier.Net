

#region using statements

using DataTier.Net;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class MethodInfo
    /// <summary>
    /// This class is used to hold the Method properties when creating a new method.
    /// </summary>
    public class MethodInfo
    {

        #region Private Variables
        private DTNTable selectedTable;
        private MethodTypeEnum methodType;
        private ParameterTypeEnum parameterType;
        private DTNField parameterField;
        private DTNField orderByField;
        private FieldSet orderByFieldSet;
        private FieldSet parameterFieldSet;
        private OrderByTypeEnum orderByType;
        private bool orderByDescending;
        private string methodName;
        private string baseMethodName;
        private string procedureName;
        private string parameters;
        private string propertyName;
        private string propertyDataType;
        private bool useCustomReader;
        private CustomReader customReader;
        private bool updateOnBuild;
        private int methodId;
        private string storedProcedureVariableName;
        private int topRows;
        #endregion

        #region Properties

            #region BaseMethodName
            /// <summary>
            /// This property gets or sets the value for 'BaseMethodName'.
            /// </summary>
            public string BaseMethodName
            {
                get { return baseMethodName; }
                set { baseMethodName = value; }
            }
            #endregion
            
            #region CustomReader
            /// <summary>
            /// This property gets or sets the value for 'CustomReader'.
            /// </summary>
            public CustomReader CustomReader
            {
                get { return customReader; }
                set { customReader = value; }
            }
            #endregion
            
            #region HasCustomReader
            /// <summary>
            /// This property returns true if this object has a 'CustomReader'.
            /// </summary>
            public bool HasCustomReader
            {
                get
                {
                    // initial value
                    bool hasCustomReader = (this.CustomReader != null);
                    
                    // return value
                    return hasCustomReader;
                }
            }
            #endregion
            
            #region HasOrderByField
            /// <summary>
            /// This property returns true if this object has an 'OrderByField'.
            /// </summary>
            public bool HasOrderByField
            {
                get
                {
                    // initial value
                    bool hasOrderByField = (this.OrderByField != null);
                    
                    // return value
                    return hasOrderByField;
                }
            }
            #endregion
            
            #region HasOrderByFieldSet
            /// <summary>
            /// This property returns true if this object has an 'OrderByFieldSet'.
            /// </summary>
            public bool HasOrderByFieldSet
            {
                get
                {
                    // initial value
                    bool hasOrderByFieldSet = (this.OrderByFieldSet != null);
                    
                    // return value
                    return hasOrderByFieldSet;
                }
            }
            #endregion
            
            #region HasParameterField
            /// <summary>
            /// This property returns true if this object has a 'ParameterField'.
            /// </summary>
            public bool HasParameterField
            {
                get
                {
                    // initial value
                    bool hasParameterField = (this.ParameterField != null);
                    
                    // return value
                    return hasParameterField;
                }
            }
            #endregion
            
            #region HasParameterFieldSet
            /// <summary>
            /// This property returns true if this object has a 'ParameterFieldSet'.
            /// </summary>
            public bool HasParameterFieldSet
            {
                get
                {
                    // initial value
                    bool hasParameterFieldSet = (this.ParameterFieldSet != null);
                    
                    // return value
                    return hasParameterFieldSet;
                }
            }
            #endregion
            
            #region HasSelectedTable
            /// <summary>
            /// This property returns true if this object has a 'SelectedTable'.
            /// </summary>
            public bool HasSelectedTable
            {
                get
                {
                    // initial value
                    bool hasSelectedTable = (this.SelectedTable != null);
                    
                    // return value
                    return hasSelectedTable;
                }
            }
            #endregion
            
            #region HasStoredProcedureVariableName
            /// <summary>
            /// This property returns true if the 'StoredProcedureVariableName' exists.
            /// </summary>
            public bool HasStoredProcedureVariableName
            {
                get
                {
                    // initial value
                    bool hasStoredProcedureVariableName = (!String.IsNullOrEmpty(this.StoredProcedureVariableName));
                    
                    // return value
                    return hasStoredProcedureVariableName;
                }
            }
            #endregion
            
            #region MethodId
            /// <summary>
            /// This property gets or sets the value for 'MethodId'.
            /// </summary>
            public int MethodId
            {
                get { return methodId; }
                set { methodId = value; }
            }
            #endregion
            
            #region MethodName
            /// <summary>
            /// This property gets or sets the value for 'MethodName'.
            /// </summary>
            public string MethodName
            {
                get { return methodName; }
                set { methodName = value; }
            }
            #endregion
            
            #region MethodType
            /// <summary>
            /// This property gets or sets the value for 'MethodType'.
            /// </summary>
            public MethodTypeEnum MethodType
            {
                get { return methodType; }
                set { methodType = value; }
            }
            #endregion
            
            #region OrderByDescending
            /// <summary>
            /// This property gets or sets the value for 'OrderByDescending'.
            /// </summary>
            public bool OrderByDescending
            {
                get { return orderByDescending; }
                set { orderByDescending = value; }
            }
            #endregion
            
            #region OrderByField
            /// <summary>
            /// This property gets or sets the value for 'OrderByField'.
            /// </summary>
            public DTNField OrderByField
            {
                get { return orderByField; }
                set { orderByField = value; }
            }
            #endregion
            
            #region OrderByFieldSet
            /// <summary>
            /// This property gets or sets the value for 'OrderByFieldSet'.
            /// </summary>
            public FieldSet OrderByFieldSet
            {
                get { return orderByFieldSet; }
                set { orderByFieldSet = value; }
            }
            #endregion
            
            #region OrderByType
            /// <summary>
            /// This property gets or sets the value for 'OrderByType'.
            /// </summary>
            public OrderByTypeEnum OrderByType
            {
                get { return orderByType; }
                set { orderByType = value; }
            }
            #endregion
            
            #region ParameterField
            /// <summary>
            /// This property gets or sets the value for 'ParameterField'.
            /// </summary>
            public DTNField ParameterField
            {
                get { return parameterField; }
                set { parameterField = value; }
            }
            #endregion
            
            #region ParameterFieldSet
            /// <summary>
            /// This property gets or sets the value for 'ParameterFieldSet'.
            /// </summary>
            public FieldSet ParameterFieldSet
            {
                get { return parameterFieldSet; }
                set { parameterFieldSet = value; }
            }
            #endregion
            
            #region Parameters
            /// <summary>
            /// This property gets or sets the value for 'Parameters'.
            /// </summary>
            public string Parameters
            {
                get { return parameters; }
                set { parameters = value; }
            }
            #endregion
            
            #region ParameterType
            /// <summary>
            /// This property gets or sets the value for 'ParameterType'.
            /// </summary>
            public ParameterTypeEnum ParameterType
            {
                get { return parameterType; }
                set { parameterType = value; }
            }
            #endregion
            
            #region ProcedureName
            /// <summary>
            /// This property gets or sets the value for 'ProcedureName'.
            /// </summary>
            public string ProcedureName
            {
                get { return procedureName; }
                set { procedureName = value; }
            }
            #endregion
            
            #region PropertyDataType
            /// <summary>
            /// This property gets or sets the value for 'PropertyDataType'.
            /// </summary>
            public string PropertyDataType
            {
                get { return propertyDataType; }
                set { propertyDataType = value; }
            }
            #endregion
            
            #region PropertyName
            /// <summary>
            /// This property gets or sets the value for 'PropertyName'.
            /// </summary>
            public string PropertyName
            {
                get { return propertyName; }
                set { propertyName = value; }
            }
            #endregion
            
            #region SelectedTable
            /// <summary>
            /// This property gets or sets the value for 'SelectedTable'.
            /// </summary>
            public DTNTable SelectedTable
            {
                get { return selectedTable; }
                set { selectedTable = value; }
            }
            #endregion
            
            #region StoredProcedureVariableName
            /// <summary>
            /// This property gets or sets the value for 'StoredProcedureVariableName'.
            /// </summary>
            public string StoredProcedureVariableName
            {
                get { return storedProcedureVariableName; }
                set { storedProcedureVariableName = value; }
            }
            #endregion
            
            #region TopRows
            /// <summary>
            /// This property gets or sets the value for 'TopRows'.
            /// </summary>
            public int TopRows
            {
                get { return topRows; }
                set { topRows = value; }
            }
            #endregion
            
            #region UpdateOnBuild
            /// <summary>
            /// This property gets or sets the value for 'UpdateOnBuild'.
            /// </summary>
            public bool UpdateOnBuild
            {
                get { return updateOnBuild; }
                set { updateOnBuild = value; }
            }
            #endregion
            
            #region UseCustomReader
            /// <summary>
            /// This property gets or sets the value for 'UseCustomReader'.
            /// </summary>
            public bool UseCustomReader
            {
                get { return useCustomReader; }
                set { useCustomReader = value; }
            }
            #endregion
         
        #endregion

    }
    #endregion

}
