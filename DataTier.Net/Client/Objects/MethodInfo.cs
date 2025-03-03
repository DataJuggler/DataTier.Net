

#region using statements

using DataTier.Net;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
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
        private bool useCustomWhere;
        private string whereText;
        private string procedureText;
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
            
            #region HasParameterName
            /// <summary>
            /// This property returns true if the 'ParameterName' exists.
            /// </summary>
            public bool HasParameterName
            {
                get
                {
                    // initial value
                    bool hasParameterName = (!String.IsNullOrEmpty(this.ParameterName));
                    
                    // return value
                    return hasParameterName;
                }
            }
            #endregion
            
            #region HasWhereText
            /// <summary>
            /// This property returns true if the 'WhereText' exists.
            /// </summary>
            public bool HasWhereText
            {
                get
                {
                    // initial value
                    bool hasWhereText = (!String.IsNullOrEmpty(this.WhereText));
                    
                    // return value
                    return hasWhereText;
                }
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
            
            #region HasProcedureText
            /// <summary>
            /// This property returns true if the 'ProcedureText' exists.
            /// </summary>
            public bool HasProcedureText
            {
                get
                {
                    // initial value
                    bool hasProcedureText = (!String.IsNullOrEmpty(this.ProcedureText));
                    
                    // return value
                    return hasProcedureText;
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
            
            #region ParameterName
            /// <summary>
            /// This read only property is used to return a parameter name when used in place of a SingleField
            /// Method. This allows you to 
            /// </summary>
            public string ParameterName
            {
                get
                {
                    // initial value
                    string parameterName = "";

                    // return the value
                    if (TextHelper.Exists(Parameters))
                    {
                        // get the words
                        List<Word> words = TextHelper.GetWords(Parameters);

                        // If the words collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(words))
                        {
                            // if there are exactly two
                            if (words.Count == 2)
                            {
                                // Set the return value
                                parameterName = words[1].Text;
                            }
                        }
                    }

                    // return value
                    return parameterName;
                }            
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

            #region ProcedureText
            /// <summary>
            /// This property gets or sets the value for 'ProcedureText'.
            /// </summary>
            public string ProcedureText
            {
                get { return procedureText; }
                set { procedureText = value; }
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

            #region UseCustomWhere
            /// <summary>
            /// This property gets or sets the value for 'UseCustomWhere'.
            /// </summary>
            public bool UseCustomWhere
            {
                get { return useCustomWhere; }
                set { useCustomWhere = value; }
            }
            #endregion
         
            #region WhereText
            /// <summary>
            /// This property gets or sets the value for 'WhereText'.
            /// </summary>
            public string WhereText
            {
                get { return whereText; }
                set { whereText = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
