

#region using statements

using dataObjects = ObjectLibrary.BusinessObjects;
using DataJuggler.Core.UltimateHelper;
using System;
using DataJuggler.Net;
using DataTier.Net.StoredProcedureGenerator;
using System.Text;
using System.Collections.Generic;
using DataTierClient.ClientUtil;

#endregion

namespace DataTierClient.Builders
{

    #region class DataObjectReaderCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a data object reader 
    /// </summary>
	public class DataObjectReaderCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private DataTable dataTable;
        private ReferencesSet objectReferences;
        private string rootDataObjectReaderPath;
        private string nameSpaceName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of DataObjectReaderCreator
        /// </summary>
        public DataObjectReaderCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootDataObjectPathArg, string nameSpaceNameArg, ProjectFileManager fileManager) : base(fileManager, false)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.NameSpaceName = nameSpaceNameArg;
		    this.ObjectReferences = objectReferencesArg;
		    this.RootDataObjectReaderPath = rootDataObjectPathArg;
		}
		#endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of DataObjectReaderCreator
        /// </summary>
        public DataObjectReaderCreator(DataTable dataTableArg, ReferencesSet objectReferencesArg, string rootDataObjectPathArg, string nameSpaceNameArg, ProjectFileManager fileManager) : base(fileManager, false)
		{   
		    // Set Properties
		    this.DataTable = dataTableArg;
		    this.NameSpaceName = nameSpaceNameArg;
		    this.ObjectReferences = objectReferencesArg;
		    this.RootDataObjectReaderPath = rootDataObjectPathArg;
		}
		#endregion

        #region Methods

            #region CreateCollectionObjectLine(string collectionReturnType, string returnVariableName)
            /// <summary>
            /// This method creates the line:
            /// UserDataObjectCollection userDataObjectCollection = new UserDataObjectCollection();
            /// for example
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateCollectionObjectLine(string collectionReturnType, string returnVariableName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();
                
                // append className
                sb.Append(collectionReturnType);
                
                // append a space
                sb.Append(" ");
                
                // append className
                sb.Append(returnVariableName);

                // Add =
                sb.Append(" = new ");

                // add className again
                sb.Append(collectionReturnType);
                
                // Add Collection();
                sb.Append("();");

                // return value
                return sb.ToString();    
            }
            #endregion

            #region CreateFieldValueParser(DataField field, string fieldName, string defaultValue, bool addExtraClosingParen)
            /// <summary>
            /// Creates the line to parse the value from the data row 
            /// ItemArray
            /// </summary>
            /// <param name="field"></param>
            /// <returns></returns>
            private string CreateFieldValueParser(DataField field, string fieldName, string defaultValue, bool addExtraClosingParen)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();
                
                // Append Parse
                sb.Append("DataHelper.Parse");
                
                // Get DataType
                string dataType = ParseDataType(field);
                
                // Add DataType
                sb.Append(dataType);
                
                // Add Open (
                sb.Append("(");
                
                // append line to get the the field value from the dataRow.ItemArray[
                sb.Append("dataRow.ItemArray[");
                
                // now append field name
                sb.Append(fieldName);
                
                // now append closing ]
                sb.Append("]");
                
                // if there is a default value
                if(!String.IsNullOrEmpty(defaultValue))
                {
                    // append a comma
                    sb.Append(", ");
                    
                    // append default value
                    sb.Append(defaultValue);
                }

                // if add extra closing )
                if (addExtraClosingParen)
                {
                    // add the extra paren
                    // this is for the UpdateIdentityMethod needs this.
                    sb.Append(")");
                }
                 
                // now append Closing ) and semi colon
                sb.Append(");");
                
                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateFileName(DataTable dataTable, dataObjects.CustomReader customReader = null)
            /// <summary>
            /// Create the file name for this reader.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateFileName(DataTable dataTable, dataObjects.CustomReader customReader = null)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();

                // Append RootDataObjectReaderPath
                sb.Append(this.RootDataObjectReaderPath);
                            
                // If the root data object reader path does not end with a back slash
                if(!this.RootDataObjectReaderPath.EndsWith(@"\"))
                {
                    // Append Backslash
                    sb.Append(@"\");
                }

                // If the customReader object exists
                if (NullHelper.Exists(customReader))
                {
                     // Add ClassName
                    sb.Append(customReader.ReaderName);

                    // append .cs extension
                    sb.Append(".cs");
                }
                else
                {
                    // Add ClassName
                    sb.Append(dataTable.ClassName.Replace("_", ""));
                
                    // Add The Word Reader
                    sb.Append("Reader.cs");
                }
                
                // return value
                return sb.ToString();
            } 
            #endregion

            #region CreateObjectLine(DataTable dataTable)
            /// <summary>
            /// This method creates the line:
            /// UserDataObject userDataObject = new UserDataObject();
            /// for example
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateObjectLine(DataTable dataTable)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();
            
                // Get ClassName
                string className = GetClassName(dataTable);
                
                // append className
                sb.Append(className);

                // Append
                sb.Append(" ");

                // append className
                sb.Append(CapitalizeFirstChar(className, true));
                
                // Add =
                sb.Append(" = new ");
                
                // add className again
                sb.Append(className);
                
                // Add ();
                sb.Append("();");
                
                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateObjectReader(DataTable dataTable, dataObjects.CustomReader customReader = null)
            /// <summary>
            /// Create an object reader for the table passed in.
            /// </summary>
            public List<DataField> CreateObjectReader(DataTable dataTable, dataObjects.CustomReader customReader = null)
            {
                // initial value
                List<DataField> dataFields = null;

                // Set Indent To 0
                Indent = 0;
            
                // verify DataTable exist
                if (dataTable != null)
                {
                    // Get DataWatcherFileName
                    string fileName = CreateFileName(dataTable, customReader);
                    
                    // Create Writer
                    CreateFile(fileName, DataManager.ProjectTypeEnum.DAC);
                    
                    // Write References
                    WriteReferences(this.ObjectReferences);

                    // Write Blank Line
                    WriteLine();
                    
                    // Write NameSpace
                    string nameSpace = "namespace " + this.NameSpaceName;
                    WriteLine(nameSpace);
                    
                    // Write Open Brack
                    WriteOpenBracket();
                    
                    // Write Blank Line
                    WriteLine();
                    
                    // Increase Indent
                    Indent++;
                    
                    // Get ClassName
                    string className = dataTable.ClassName + "Reader";

                    // If the customReader object exists
                    if (NullHelper.Exists(customReader))
                    {
                        // set the className
                        className = customReader.ClassName;
                    }
                    
                    // Write Region for this reader
                    BeginRegion("class " + className);

                    // Write Object Reader Summary
                    WriteClassSummary(dataTable, customReader);
                    
                    // get class line
                    string classLine = "public class " + className;
                    
                    // Write ClassLine
                    WriteLine(classLine);
                    
                    // Write Open Brack
                    WriteOpenBracket();
                    
                    // Write Blank Line
                    WriteLine();

                    // Increase Indent
                    Indent++;
                    
                    // Begin Region Static Methods
                    BeginRegion("Static Methods");
                    
                    // Increase Indent
                    Indent++;

                    // Write Load Method
                    dataFields = WriteLoadMethod(dataTable, customReader);
                    
                    // Write LoadCollectionMethod
                    WriteLoadCollectionMethod(dataTable);

                    // Decrease Indent
                    Indent--;
                    
                    // Write line
                    WriteLine("#endregion");

                    // Write Blank Line
                    WriteLine();
         
                    // Decrease Indent
                    Indent--;
                    
                    // Write Close Bracket
                    WriteLine("}");
                    
                    // Write EndRegion
                    WriteLine("#endregion");

                    // Write Blank Line
                    WriteLine();
                    
                    // Decrease Indent
                    Indent--;

                    // Write Close Bracket
                    WriteLine("}");
                    
                    // Close This File
                    this.Writer.Close();
                }

                // return value
                return dataFields;
            }
            #endregion

            #region CreateObjectReaders()
            /// <summary>
            /// Create object readers
            /// </summary>
            public void CreateObjectReaders()
            {
                // verify 
                if (this.DataTables != null)
                {
                    // loop through each table
                    foreach (DataTable dataTable in this.DataTables)
                    {
                        // Create an object reader for this table
                        CreateObjectReader(dataTable);
                    }
                }
            }
            #endregion

            #region CreateLoadFieldLine(DataField field, string objectName)
            /// <summary>
            /// This metohd creats the line to load a field
            /// </summary>
            /// <param name="field"></param>
            /// <returns></returns>
            private string CreateLoadFieldLine(DataField field, string objectName)
            {
                // initial value
                string parser = "";

                // Get fieldName
                string fieldName = this.CapitalizeFirstChar(field.FieldName, true) + "field";
                
                // local for default value
                string defaultValue = null;
                
                // determine by the dataType if we need a default value
                switch(field.DataType)
                {
                    // if this is a numeric value
                    case DataManager.DataTypeEnum.Enumeration:
                    case DataManager.DataTypeEnum.Integer:
                    case DataManager.DataTypeEnum.Autonumber:
                    case DataManager.DataTypeEnum.Decimal:
                    case DataManager.DataTypeEnum.Currency:
                    case DataManager.DataTypeEnum.Double:

                        // set default value
                        defaultValue = "0";
                        
                        // required
                        break;

                    case DataManager.DataTypeEnum.Boolean:

                        // set default value to false
                        defaultValue = "false";

                        // required
                        break;
                }
                
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(objectName);
                
                // Append .
                sb.Append(".");
                
                // add this field name
                sb.Append(field.FieldName);
                
                // Add =
                sb.Append(" = ");

                // if this field is an enumeration
                if (field.IsEnumeration)
                {
                    // Add the open paren
                    sb.Append("(");

                    // add the enumeration name
                    sb.Append(field.EnumDataTypeName);

                    // add the closing 
                    sb.Append(") ");

                    // Add the ParseInteger
                    sb.Append("DataHelper.ParseInteger(");
                
                    // append line to get the the field value from the dataRow.ItemArray[
                    sb.Append("dataRow.ItemArray[");
                
                    // now append field name
                    sb.Append(fieldName);
                
                    // now append closing ]
                    sb.Append("]");
                
                    // if there is a default value
                    if(!String.IsNullOrEmpty(defaultValue))
                    {
                        // append a comma
                        sb.Append(", ");
                    
                        // append default value
                        sb.Append(defaultValue);
                    }

                    // Add the close paren and closing semi colon
                    sb.Append(");");
                }
                else
                {
                    // Get FieldValueParser
                    string fieldValueParser = CreateFieldValueParser(field, fieldName, defaultValue, false);
                
                    // append 
                    sb.Append(fieldValueParser);
                }

                // set the return value
                parser = sb.ToString();
               
                // return value
                return parser;
            }
            #endregion

            #region ParseDataType(DataField field)
            /// <summary>
            /// This method is used to determine which HelperMethod
            /// is needed to be called to get the field value.
            /// </summary>
            /// <param name="field"></param>
            /// <returns></returns>
            private string ParseDataType(DataField field)
            {
                // initial value
                string dataType = null;

                // is this field an Enumeration
                if (field.IsEnumeration)
                {
                    // set the return value
                    dataType = field.EnumDataTypeName;
                }
                else
                {
                    // determine action by the data type
                    switch(field.DataType)
                    {
                        case DataManager.DataTypeEnum.Boolean:
                    
                            // set dataType to Boolean
                            dataType = "Boolean";
                        
                            // Required
                            break;

                        case DataManager.DataTypeEnum.Binary:
                    
                            // Set data type to byte
                            dataType = "BinaryData";

                            // Required
                            break;

                        case DataManager.DataTypeEnum.Autonumber:
                        case DataManager.DataTypeEnum.Integer:


                            // set dataType to Integer
                            dataType = "Integer";

                            // Required
                            break;

                        case DataManager.DataTypeEnum.String:

                            // set dataType to String
                            dataType = "String";

                            // Required
                            break;

                        case DataManager.DataTypeEnum.DateTime:

                            // set dataType to Date
                            dataType = "Date";

                            // Required
                            break;

                        case DataManager.DataTypeEnum.Double:
                        case DataManager.DataTypeEnum.Decimal:
                        case DataManager.DataTypeEnum.Currency:
                    
                            // set dataType to Double
                            dataType = "Double";

                            // Required
                            break;

                        case DataManager.DataTypeEnum.Guid:

                            // set dataType to Guid
                            dataType = "Guid";

                            // Required
                            break;   
                    }
                }
                
                // return value
                return dataType;
            }
            #endregion

            #region WriteClassSummary(DataTable dataTable, dataObjects.CustomReader = null)
            /// <summary>
            /// This method writes the summary for the data object reader.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteClassSummary(DataTable dataTable, dataObjects.CustomReader customReader = null)
            {
                // write the open summary tag
                WriteLine("/// <summary>");

                WriteLine("/// This class loads a single '" + dataTable.ClassName + "' object or a list of type <" + dataTable.ClassName + ">.");
                
                // write the closing summary
                WriteLine("/// </summary>");
            }
            #endregion

            #region WriteFieldIntegerLine(DataField field)
            /// <summary>
            /// This method writes the field integer line.
            /// This field is the ordinal reference for a field
            /// when reading from the data reader.
            /// </summary>
            /// <param name="field"></param>
            private void WriteFieldIntegerLine(DataField field, int ordinalPosition)
            {
                // verify the DataField exists
                if(field != null)
                {
                    // create this fieldLine
                    string fieldLine = "int " + this.CapitalizeFirstChar(field.FieldName, true) + "field = " + ordinalPosition.ToString() + ";";

                    // Write fieldLine
                    WriteLine(fieldLine);
                }
            }  
            #endregion

            #region WriteFieldIntegers(DataTable dataTable, dataObjects.CustomReader customReader = null)
            /// <summary>
            /// This method writes the field integers for this data table.
            /// </summary>
            /// <param name="dataTable"></param>
            private List<DataField> WriteFieldIntegers(DataTable dataTable, dataObjects.CustomReader customReader = null)
            {
                // update to handle CustomReaders: Now the list of DataFields is set from either the
                // CustomReader.FieldSet or the DataTabe.ActiveFields
                List<DataField> fields = null;

                // Write Blank line
                WriteLine();

                // Write Comment Create field Integers
                WriteComment("Create field Integers");
                
                // local for ordinalPosition
                int ordinalPosition = 0;

                // if the customReader exists and has a FieldSet
                if ((NullHelper.Exists(customReader)) && (customReader.HasFieldSet) && (customReader.FieldSet.HasFields))
                {
                    // convert the CustomReader fields to DataField objects
                    fields = DataConverter.ConvertDataFields(customReader.FieldSet.Fields);
                }
                // if dataTable exists
                else  if(dataTable != null)
                {
                    // only use the ActiveFields to ignore unwanted fields
                    fields = dataTable.ActiveFields;
                }
                    
                // If the fields collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(fields))
                {
                    // loop through each field
                    for(int x = 0; x < fields.Count; x++)
                    {
                        // Get The Current field
                        DataField field = fields[x];
                        
                        // Set OrdinalPosition
                        ordinalPosition = x;
                        
                        // Write the fieldLine for this field
                        WriteFieldIntegerLine(field, ordinalPosition);
                    }
                
                    // Write Blank Line
                    WriteLine();
                }

                // return value
                return fields;
            }
            #endregion

            #region WriteLoadCollectionMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the LoadCollection method for a DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteLoadCollectionMethod(DataTable dataTable)
            {
                // Write Blank Line
                WriteLine();

                // Write BeginRegion
                BeginRegion("LoadCollection(DataTable dataTable)");

                // Write Load Collection Summary
                WriteLoadCollectionSummary(dataTable);
                
                // get objectName
                string className = dataTable.ClassName;
                
                // get collection return type
                string collectionReturnType = "List<" + className + ">";
                
                // if there is a conflict with this class name
                if (ConflictHelper.CheckForConflict(className))
                {
                    // resolve the conflict
                    collectionReturnType = ConflictHelper.ResolveConflict(collectionReturnType, dataTable.ObjectNameSpaceName);
                }
                
                // get the return variable name
                string returnVariableName = CapitalizeFirstChar(className, true);

                // fix any pluralization issues
                returnVariableName = PluralWordHelper.GetPluralName(className, true);

                // Create loadMethodLine
                string loadMethodLine = "public static " + collectionReturnType + " LoadCollection(DataTable dataTable)";
                
                // Write LoadMethodLine
                WriteLine(loadMethodLine);

                // Write Open Bracket
                WriteOpenBracket();

                // Increase Indent
                Indent++;

                // Write Comment For Initial Value
                WriteComment("Initial Value");

                // Create Object Line
                string objectLine = CreateCollectionObjectLine(collectionReturnType, returnVariableName);

                // Write Object Line
                WriteLine(objectLine);
                
                // Write Blank Line
                WriteLine();

                // Write try
                WriteLine("try");

                // Write Open Bracket
                WriteOpenBracket();

                // Increase Indent
                Indent++;

                // Write Comment Load Each row In dataTable
                WriteComment("Load Each row In DataTable");
                
                // Now Write For Each Line
                WriteLine("foreach (DataRow row in dataTable.Rows)");
                
                // Write Open Bracket
                WriteOpenBracket();
                
                // Incrase Indent
                Indent++;
                
                // Write the comment to create object from data row
                WriteComment("Create '" + dataTable.ClassName + "' from rows");
                
                // get the single variable name
                string singleVariableName = CapitalizeFirstChar(className, true);
                
                // if this object ends in "s" it can't be singular
                if (singleVariableName.EndsWith("s"))
                {
                    // remove the last s
                    singleVariableName = singleVariableName.Substring(0, singleVariableName.Length -1);
                }
                
                // Write Line To Load This Object
                string line = dataTable.ClassName + " " + singleVariableName + " = Load(row);";
                
                // write this line
                WriteLine(line);
                
                // Write Blank Line
                WriteLine();

                // Write Comment add this object to collection
                WriteComment("Add this object to collection");
                
                // Write addToCollection Line
                string addToCollection = returnVariableName + ".Add(" + singleVariableName + ");";
                
                // write line
                WriteLine(addToCollection);
                
                // Decrease Indent
                Indent--;
                
                // Write Close Bracket
                WriteLine("}");
                
                // Decrease Indent
                Indent--;
                
                // Write Close Bracket
                WriteLine("}");
                
                // Write catch
                WriteLine("catch");
                
                // Write Open Bracket
                WriteOpenBracket();
                
                // Write Close Bracket
                WriteLine("}");

                // Write Blank Line
                WriteLine();

                // write Comment For Return Value
                WriteComment("return value");

                // Write Return Value
                string returnValue = "return " + returnVariableName + ";";
                WriteLine(returnValue);

                // Decrease Indent
                Indent--;
                
                // Write Close Bracket
                WriteLine("}");

                // Write end Region
                WriteLine("#endregion");
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteLoadCollectionSummary(DataTable dataTable)
            /// <summary>
            /// This method writes the summary for the LoadCollection
            /// method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteLoadCollectionSummary(DataTable dataTable)
            {
                WriteLine("/// <summary>");
                WriteLine("/// This method loads a collection of '" + dataTable.ClassName + "' objects.");
                WriteLine("/// from the dataTable.Rows object passed in.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>");
                WriteLine("/// <returns>A " + dataTable.ClassName + " Collection.</returns>");
            }
            #endregion

            #region WriteLoadMethod(DataTable dataTable, dataObjects.CustomReader customReader = null)
            /// <summary>
            /// This method writes the Load method for a DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            private List<DataField> WriteLoadMethod(DataTable dataTable, dataObjects.CustomReader customReader = null)
            {
                 // update to handle CustomReaders: Now the list of DataFields is set from either the
                // CustomReader.FieldSet or the DataTabe.ActiveFields
                List<DataField> fields = null;

                // If the data table exists
                if (dataTable != null)
                {
                    // Write Blank Line
                    WriteLine();

                    // Write BeginRegion
                    BeginRegion("Load(DataRow dataRow)");

                    // Write Load Method Summary
                    WriteLoadMethodSummary(dataTable);

                    // Create loadMethodLine
                    string loadMethodLine = "public static " + GetClassName(dataTable) + " Load(DataRow dataRow)";

                    // Write LoadMethodLine
                    WriteLine(loadMethodLine);

                    // Write Open Bracket
                    WriteOpenBracket();

                    // Increase Indent
                    Indent++;

                    // Write Comment For Initial Value
                    WriteComment("Initial Value");

                    // Create Object Line
                    string objectLine = CreateObjectLine(dataTable);

                    // Write Object Line
                    WriteLine(objectLine);

                    // Write field Integers
                    fields = WriteFieldIntegers(dataTable, customReader);

                    // Write try
                    WriteLine("try");

                    // Write Open Bracket
                    WriteOpenBracket();

                    // Increase Indent
                    Indent++;

                    // Write Comment Load Each field
                    WriteComment("Load Each field");

                    // create objectName
                    string objectName = CapitalizeFirstChar(GetClassName(dataTable), true);

                    // variable for each field to load
                    string loadField = null;

                    // If the fields collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(fields))
                    {
                        // add each field
                        foreach (DataField field in fields)
                        {
                            // do not write the primary key
                            if ((!field.PrimaryKey) || (dataTable.IsView))
                            {
                                // load this field
                                loadField = CreateLoadFieldLine(field, objectName);

                                // Write Line To LoadF This field
                                WriteLine(loadField);
                            }
                            else
                            {
                                // Now Write Update Identity Method
                                WriteUpdateIdentity(dataTable, objectName);
                            }
                        }
                    }

                    // Decrease Indent
                    Indent--;

                    // Write Close Bracket
                    WriteLine("}");

                    // Write catch
                    WriteLine("catch");

                    // Write Open Bracket
                    WriteOpenBracket();

                    // Write Close Bracket
                    WriteLine("}");

                    // Write Blank Line
                    WriteLine();

                    // write Comment For Return Value
                    WriteComment("return value");

                    // Write Return Value
                    string returnValue = "return " + objectName + ";";
                    WriteLine(returnValue);

                    // Decrease Indent
                    Indent--;

                    // Write Close Bracket
                    WriteLine("}");

                    // Write endregion
                    WriteLine("#endregion");
                }

                // return value
                return fields;
            }
            #endregion

            #region WriteLoadMethodSummary(DataTable dataTable)
            /// <summary>
            /// This method writes the summary for the LoadMethod
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteLoadMethodSummary(DataTable dataTable)
            {
                // Begin Writing Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method loads a '" + dataTable.ClassName + "' object");
                WriteLine("/// from the dataRow passed in.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='dataRow'>The 'DataRow' to load from.</param>");
                WriteLine("/// <returns>A '" + dataTable.Name + "' DataObject.</returns>");
            }
            #endregion

            #region WriteUpdateIdentity(DataTable dataTable)
            /// <summary>
            /// This method writes the UpdateIdentiy call
            /// to update the primary key.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteUpdateIdentity(DataTable dataTable, string objectName)
            {   
                 // if this data table has a primary key
                 if(dataTable.HasPrimaryKey)
                 {
                    // local
                    int index = 0;
                    
                    // Find the index of the primary key
                    foreach(DataField field in dataTable.ActiveFields)
                    {
                        // if this field is this the same field.
                        if((field.PrimaryKey) && (field.FieldName == dataTable.PrimaryKey.FieldName))
                        {
                            // break out of loop
                            break;
                        }
                        
                        // Increment Index
                        index++;
                    }
                    
                     // Create StringBuilder
                     StringBuilder sb = new StringBuilder(objectName);

                     // append .UpdateIdentity(
                     sb.Append(".UpdateIdentity(");
                     
                     // get field name
                     string fieldName = this.CapitalizeFirstChar(dataTable.PrimaryKey.FieldName, true) + "field";

                    // parse the primary key
                    string primaryKeyParser = "";

                    // if this is an Integer or AutoNumber primary key
                    if ((dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Integer) || (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber))
                    {
                        // Create the primary key with a default value of 0
                        primaryKeyParser = CreateFieldValueParser(dataTable.PrimaryKey, fieldName, "0", true);
                    }
                    else
                    {
                        // Create the UpdateIdentity method without a default value of 0 passed for integers
                        primaryKeyParser = CreateFieldValueParser(dataTable.PrimaryKey, fieldName, "", true);
                    }
                    
                    // append load field
                    sb.Append(primaryKeyParser);
                     
                    // get update Identity line
                    string updateIdentityLine = sb.ToString();
                    
                    // writeLine
                    WriteLine(updateIdentityLine);
                 }
            }
            #endregion

        #endregion			
	
		#region Properties

            #region DataTable
            /// <summary>
            /// The collection of data tables to create readers for.
            /// </summary>
            public DataTable DataTable            
            {
                get { return dataTable; }
                set { dataTable = value; }
            }  
            #endregion

            #region DataTables
            /// <summary>
            /// The collection of data tables to create readers for.
            /// </summary>
            public List<DataTable> DataTables
            {
                get { return dataTables; }
                set { dataTables = value; }
            }  
            #endregion

            #region HasDataTable
            /// <summary>
            /// This property returns true if this object has a 'DataTable'.
            /// </summary>
            public bool HasDataTable
            {
                get
                {
                    // initial value
                    bool hasDataTable = (this.DataTable != null);
                    
                    // return value
                    return hasDataTable;
                }
            }
            #endregion
            
            #region NameSpaceName
            /// <summary>
            /// The namespace to use for this project.
            /// </summary>
            public string NameSpaceName
            {
                get { return nameSpaceName; }
                set { nameSpaceName = value; }
            }
            #endregion

            #region ObjectReferences
            /// <summary>
            /// The using statements to use
            /// </summary>
            public ReferencesSet ObjectReferences
            {
                get { return objectReferences; }
                set { objectReferences = value; }
            }
            #endregion

            #region RootDataObjectReaderPath
            /// <summary>
            /// The root path to create the file from.
            /// </summary>
            public string RootDataObjectReaderPath
            {
                get { return rootDataObjectReaderPath; }
                set { rootDataObjectReaderPath = value; }
            } 
            #endregion
    		
		#endregion

	}
	#endregion	
	
}
