

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataJuggler.Net;
using System.IO;
using System.Windows.Forms;
using DataTier.Net.StoredProcedureGenerator.Enumerations;

#endregion

namespace DataTier.Net.StoredProcedureGenerator
{

    #region class ProcedureWriter
    /// <summary>
    /// This class writes out the Insert, Find, Load, Update & Delete
    /// Procedures for all tables in a database
    /// </summary>
    public class ProcedureWriter
    {
        
        #region Private Variables
        private int indent;
        private StreamWriter writer;
        private bool textWriterMode;
        private StringBuilder textWriter;
        #endregion

        #region Constructor(bool textWriterMode = false)
        /// <summary>
        /// Creates a new instance of a ProcedureWriter
        /// </summary>
        public ProcedureWriter(bool textWriterMode = false)
        {
            // store the arg
            TextWriterMode = textWriterMode;

            // Perform initializaionts
            Init();
        }
        #endregion

        #region Methods

            #region AppendField(StringBuilder sb, DataField field, bool firstField)
            /// <summary>
            /// This method appends a field in the make of a FieldsList.
            /// </summary>
            /// <param name="sb"></param>
            /// <param name="field"></param>
            /// <param name="firstField"></param>
            private void AppendField(ref StringBuilder sb, DataField field, bool firstField)
            {
                // if this is the first field
                if (!firstField)
                {
                    sb.Append(",");
                }

                // set firstField to false so the commas are added
                firstField = false;

                // append open [
                sb.Append("[");

                // Append 
                sb.Append(field.FieldName);

                // Append Closing ]
                sb.Append("]");
            } 
            #endregion
        
            #region CreateActionMessage(string action, string procedureName, bool success)
            /// <summary>
            /// The message to show the user for the success or failure of an action.
            /// </summary>
            /// <param name="action">Drop or Create or Alter or whatever modification 
            /// is being performed.</param>
            /// <param name="procedureName">The proc name</param>
            /// <param name="success">Failed or success message</param>
            /// <returns></returns>
            private string CreateActionMessage(string action, string procedureName, bool success)
            {
                // Create String Builder
                StringBuilder sb = new StringBuilder("PRINT '<<< ");
                
                // locals
                string successMessage = " Suceeded On Procedure ";
                string failedMessage = " Failed On Procedure ";
                string message = null;
                
                // if successful
                if(success)
                {
                    // set message to successMessage
                    message = successMessage;
                }
                else
                {
                    // set message to failedMessage
                    message = failedMessage;
                }
                
                // Add Action
                sb.Append(action);
                
                // append message
                sb.Append(message);
                
                // append procedure name
                sb.Append(procedureName);
                
                // append end of string 
                sb.Append(" >>>'");
                
                // return value
                return sb.ToString();    
            } 
            #endregion

            #region CreateDeleteProc(DataTable dataTable)
            /// <summary>
            /// This method creates the delete procedure
            /// </summary>
            /// <param name="dataTable"></param>
            public void CreateDeleteProc(DataTable dataTable)
            {
                // Perform the Procedure Innitialization
                InitProcedure(dataTable, ProcedureTypeEnum.Delete);

                // Create InsertParams
                WritePrimaryKeyParameter(dataTable);

                // Write BeginProcedure
                WriteBeginProcedure();

                // Write Comment Begin Delete Statement
                WriteComment("Begin Delete Statement");

                // Write Procedure 
                WriteLine("Delete From [" + dataTable.Name + "]");
                
                // Write Blank Line
                WriteLine();

                // Write WhereClause
                WriteWhereClause(dataTable.PrimaryKey, ProcedureTypeEnum.Delete);

                // Write End Procedure
                WriteEndProcedure();
            }
            #endregion

            #region CreateDeleteProc(DataTable dataTable, string procedureName, DataField parameterField)
            /// <summary>
            /// This method creates the delete procedure
            /// </summary>
            /// <param name="dataTable">The table to create the Delete Procedure for.</param>
            /// <param name="procedureName">The name of the Delete Procedure to create</param>
            /// <param name="parameterField">The field to use as a parameter</param>
            public void CreateDeleteProc(DataTable dataTable, string procedureName, DataField parameterField)
            {
                // get the parameterName
                string parameterName = "";

                // Perform the Procedure Innitialization
                InitProcedure(dataTable, ProcedureTypeEnum.Delete, procedureName, parameterField);

                // Write the Field Parameter
                parameterName = WriteFieldParameter(parameterField);

                // problem with this is, parameterName above contains the dataType also
                // Example: @personId int

                // create a delimiter to parse on spaces only
                char[] delimiter = { ' ' };

                // get the words
                List<Word> words = WordParser.GetWords(parameterName, delimiter);

                // if there  are one or more words
                if (ListHelper.HasOneOrMoreItems(words))
                {
                    // now set the parameterName to the firstWord
                    parameterName = words[0].Text;
                }

                // Write BeginProcedure
                WriteBeginProcedure();

                // Write Comment Begin Delete Statement
                WriteComment("Begin Delete Statement");

                // Write Procedure 
                WriteLine("Delete From [" + dataTable.Name + "]");

                // Write Blank Line
                WriteLine();

                 // Write Comment Begin Delete Statement
                WriteComment("Write Where Clause");

                // set the WhereClause
                string whereClause = "Where [" + parameterField.FieldName + "] = " + parameterName;

                // Write the Where Clause
                WriteLine(whereClause);

                // Write Blank Line
                WriteLine();

                // Write End Procedure
                WriteEndProcedure();
            }
            #endregion

            #region CreateDeleteProc(DataTable dataTable, string procedureName, List<DataField> parameters
            /// <summary>
            /// This method creates the delete procedure
            /// </summary>
            /// <param name="dataTable">The table to create the Delete Procedure for.</param>
            /// <param name="procedureName">The name of the Delete Procedure to create</param>
            /// <param name="parameterField">The field to use as a parameter</param>
            public void CreateDeleteProc(DataTable dataTable, string procedureName, List<DataField> parameters)
            {
                // Perform the Procedure Innitialization
                InitProcedure(dataTable, ProcedureTypeEnum.Delete, procedureName, parameters);

                // Write the Field Parameters
                WriteFieldParameters(parameters);

                // Write BeginProcedure
                WriteBeginProcedure();

                // Write Comment Begin Delete Statement
                WriteComment("Begin Delete Statement");

                // Write Procedure 
                WriteLine("Delete From [" + dataTable.Name + "]");
                
                // Write Blank Line
                WriteLine();

                // Write End Procedure
                WriteEndProcedure();
            }
            #endregion

            #region CreateDropProcedure(string procedureName)
            /// <summary>
            /// This method creates the line needed to drop a procedure.
            /// The line is concatenation of Drop Procedure + ProcedureName
            /// </summary>
            /// <param name="procedureName">The procedure name to drop</param>
            /// <returns>A string in the format of Drop Procedure [dbo.Procedure]</returns>
            private string CreateDropProcedure(string procedureName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("Drop Procedure ");

                // append procedureName
                sb.Append(procedureName);

                // return value
                return sb.ToString();
            } 
            #endregion

            #region CreateEditFields(DataList<Fields> dataList, bool isInsert)
            /// <summary>
            /// This method creates a DataFields collection that will become
            /// the parameters for an insert or an update procedure.
            /// </summary>
            /// <param name="dataList">The fields collection to create a list of edit parameters.
            /// The ignore fields are not added and the PrimaryKey is not added
            /// for an insert procedure.</param>
            /// <param name="isInsert"></param>
            /// <returns></returns>
            public List<DataField> CreateEditFields(List<DataField> dataList, bool ignorePrimaryKey)
            {
                // Initial Value
                List<DataField> editParameters = new List<DataField>();

                // locals
                bool skipField = false;
                
                // if fields collection exists
                if (dataList != null)
                {
                    // loop through fields collection
                    for (int x = 0; x < dataList.Count; x++)
                    {
                        // Create dataField
                        DataField field = dataList[x];

                        // if the primary key should be ignored
                        skipField = ((ignorePrimaryKey) && (field.PrimaryKey));
                        
                        // if this field should not be skipped
                        if (!skipField)
                        {
                            // Add this field to edit fields
                            editParameters.Add(field);
                        }
                    }
                }
                
                // Return Value
                return editParameters;         
            }
            #endregion
   
            #region CreateFieldEqualsValuePair(DataField field, bool firstField, bool lastField)
            /// <summary>
            /// This method creates the field equals value pair to update a record.
            /// </summary>
            /// <param name="field">The field to </param>
            /// <param name="firstField"></param>
            /// <param name="lastField"></param>
            /// <returns></returns>
            public string CreateFieldEqualsValuePair(string fieldName, bool firstField, bool lastField)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();
                
                // if this is the first field
                if(firstField)
                {
                    // add the set
                    sb.Append("Set ");
                }
                
                // add open bracket
                sb.Append("[");
                
                // add fieldName
                sb.Append(fieldName);

                // add close bracket
                sb.Append("] = @");
                
                // add fieldname
                sb.Append(fieldName);
                
                // if this is not the last field
                if(!lastField)
                {
                    // add comma
                    sb.Append(",");
                }
                
                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateFieldList(DataTable dataTable, bool allFields, bool isSelectStatement, CustomReader customReader = null)
            /// <summary>
            /// This method builds a list of fields comma seperated
            /// enclosed in parentheses
            /// </summary>
            /// <param name="dataList"></param>
            /// <returns></returns>
            public string CreateFieldList(DataTable dataTable, bool allFields, bool isSelectStatement, CustomReader customReader = null)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("");

                // if this is a select statement
                if (isSelectStatement)
                {
                    // add Select
                    sb.Append("Select ");
                }
                else
                {
                    // Add Open Paren (
                    sb.Append("(");
                }
                
                // bool firstField
                bool firstField = true;
                
                // Get the dataList
                List<DataField> dataList = null;
                
                // if the customReader exists
                if ((NullHelper.Exists(customReader)) && (customReader.HasFieldSet) && (customReader.FieldSet.HasDataFields))
                {
                    // get the converted DataFields
                    dataList = customReader.FieldSet.DataFields;
                }
                else
                {
                    // if the data table exists
                    if ((dataTable != null) && (dataTable.ActiveFields != null))
                    {
                        // Get the fields collection
                        dataList = dataTable.ActiveFields;
                    }
                }
                
                // if fields collection exist
                if (dataList != null)
                {
                    // loop through each field
                    foreach (DataField field in dataList)
                    {
                        // if this is not the primary key
                        if ((!field.PrimaryKey) || (allFields))
                        {  
                            // Append This field
                            AppendField(ref sb, field, firstField);
                                    
                            // Set first field to false
                            firstField = false;
                        }
                    }
                }
                
                // if this is not a select statement
                if (!isSelectStatement)
                {
                    // Add closing )
                    sb.Append(")");
                }

                // set the return value
                string fieldsList = sb.ToString();

                // return value
                return fieldsList;
            }
            #endregion

            #region CreateFieldParam(DataField field, bool lastField)
            /// <summary>
            /// This method creates the parameter line for each field
            /// </summary>
            /// <param name="field">The field to create as a parameter</param>
            /// <param name="lastField">The last field is the only field
            /// that does not get a comma added after it.</param>
            /// <returns></returns>
            private string CreateFieldParam(DataField field, bool lastField)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("@");

                // add the parameter name
                sb.Append(field.FieldName);

                // Get DataType
                string dataType = ParseDataType(field);

                // Add space between field & datatype
                sb.Append(" ");

                // get data type
                sb.Append(dataType);

                // if this is not the last field
                if (!lastField)
                {
                    // add a comma
                    sb.Append(",");
                }

                // return value
                return sb.ToString();
            }
            #endregion
            
            #region CreateFile(string FilePath) void
            public void CreateFile(string FilePath)
            {
                // If File Exists Delete File
                if (File.Exists(FilePath))
                {
                    // Perform the delete
                    File.Delete(FilePath);
                }

                // Open StreamObject
                Writer = File.CreateText(FilePath);
            }
            #endregion

            #region CreateFindProc(DataTable dataTable, bool fetchAll, DataField parameterField = null, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null, bool orderByFieldDescending = false, int topRows = 0, bool useCustomWhere = false, string whereText = "")
            /// <summary>
            /// This method creates the find procedure.
            /// </summary>
            /// <param name="dataTable">The table to create the Find procedure for.</param>
            /// <param name="fetchAll">Pass in true for a FetchAll (Load) or false for a Find.</param>
            /// <param name="customReader">Should a custom reader be used for this method. If yes, the fields list comes from the Reader.</param>
            /// <param name="orderByField">The field to order by for a single field order by.</param>
            /// <param name="orderByFieldDescending">If using a seingle field orderby, you can optionally set the value to descending (desc) order.</param>
            /// <param name="orderByFieldSet">A field set to use for the Order By section.</param>
            /// <param name="parameterField">A field to use as the parameter for the procedure.</param>
            /// <param name="topRows">Optional, the number of rows to select.</param>
            /// <param name="useCustomWhere">If true, a Custom Where clause is created using the whereText that must be passed in with it.</param>
            /// <param name="whereText">The custom where clause to use if UseCustomWhere is true. Must start with the word Where.</param>
            public void CreateFindProc(DataTable dataTable, bool fetchAll, DataField parameterField = null, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null, bool orderByFieldDescending = false, int topRows = 0, bool useCustomWhere = false, string whereText = "")
            {
                // if this is a fetch all
                if(fetchAll)
                {
                    // Perform the Procedure Innitialization
                    InitProcedure(dataTable, ProcedureTypeEnum.FetchAll);
                    
                    // Write Blank Line
                    WriteLine();
                }
                else
                {
                    // Perform the Procedure Innitialization
                    InitProcedure(dataTable, ProcedureTypeEnum.Find);
                    
                    // Create Primary Key Param for Find 
                    WritePrimaryKeyParameter(dataTable);
                }

                // Write BeginProcedure
                WriteBeginProcedure();

                // Write Comment Begin Select Statement
                WriteComment("Begin Select Statement");

                // Write Select Fields
                string selectFields = CreateFieldList(dataTable, true, true, customReader);

                // If the value for topRows is greater than zero
                if (topRows > 0)
                {
                    // append Top (x) to the Select List so the top rows is returned (fixing bug where there wasn't a
                    // space between the number and the first field.
                    selectFields = selectFields.Replace("Select ", "Select Top " + topRows.ToString() + " "); 
                }
                
                // Write select fiels
                WriteLine(selectFields);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment From tableName
                WriteComment("From tableName");
                
                // Write Line
                WriteLine("From [" + dataTable.Name + "]");
                
                // if this is a find
                if ((!fetchAll) || (useCustomWhere))
                {
                    // Write Blank Line
                    WriteLine();
                
                    // Add the WhereClause
                    WriteWhereClause(dataTable.PrimaryKey, ProcedureTypeEnum.Find, useCustomWhere, whereText);
                }
                    
                // Write End Procedure
                WriteEndProcedure();
            }
            #endregion

            #region CreateFindProc(DataTable dataTable, bool fetchAll, string procedureName, DataField parameterField, CustomReader customReader = null, DataField orderByField = null, FieldSet orderByFieldSet = null, bool orderByFieldDescending = false, int topRows = 0, bool useCustomWhere = false, string whereText = "")
            /// <summary>
            /// This method creates the Find procedure for the table, procedureName and parameterField given. 
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="fetchAll">Is this a Find or a FetchAll procedure</param>
            /// <param name="procedureName">The name of the stored procedure to create</param>
            /// <param name="parameterField">If set, this overrides the PrimaryKey parameter</param>
            /// <param name="customReader">Optional parameter if creating a custom reader</param>
            /// <param name="orderByField">Optional parameter used to add an order by witih a single field</param>
            /// <param name="orderByFieldSet">Optional Parameter if an Order By field set is used</param>
            /// <param name="orderByFieldDescending">Optional parameter if a single field order by is in descending order.</param>
            /// <param name="topRows">Optional parameter to Select top (x) number of rows</param>
            /// <param name="useCustomWhere">Set to true to use a Custom Where clause instead of the default where text</param>
            /// <param name="whereText">The text to use for a Where clause, if UseCustomWhere is true</param>
            public void CreateFindProc(DataTable dataTable, bool fetchAll, string procedureName, DataField parameterField, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null, bool orderByFieldDescending = false, int topRows = 0, bool useCustomWhere = false, string whereText = "")
            {
                // If both objects exist
                if ((NullHelper.Exists(dataTable, parameterField)) && (TextHelper.Exists(procedureName)))
                {
                    // if this is a fetch all
                    if(fetchAll)
                    {
                        // Perform the Procedure Innitialization
                        InitProcedure(dataTable, ProcedureTypeEnum.FetchAll, procedureName, parameterField);

                        // If the parameterField object exists
                        if (NullHelper.Exists(parameterField))
                        {
                            // Create parameter for this field
                            WriteFieldParameter(parameterField);
                        }
                    
                        // Write Blank Line
                        WriteLine();
                    }
                    else
                    {
                        // if topRows exceeds the max of 1
                        if (topRows > 1)
                        {
                            //  A find method cannot return more than 1 record
                            topRows = 1;
                        }

                        // Perform the Procedure Innitialization
                        InitProcedure(dataTable, ProcedureTypeEnum.Find, procedureName, parameterField);
                    
                        // If the parameterField object exists
                        if (NullHelper.Exists(parameterField))
                        {
                            // Create parameter for this field
                            WriteFieldParameter(parameterField);
                        }
                    }

                    // Write BeginProcedure
                    WriteBeginProcedure();

                    // Write Comment Begin Select Statement
                    WriteComment("Begin Select Statement");

                    // Write Select Fields
                    string selectFields = CreateFieldList(dataTable, true, true, customReader);

                    // If the value for topRows is greater than zero
                    if (topRows > 0)
                    {
                        // append Top (x) to the Select List so the top rows is returned (fixing bug where there wasn't a
                        // space between the number and the first field.
                        selectFields = selectFields.Replace("Select ", "Select Top " + topRows.ToString() + " "); 
                    }
                
                    // Write select fiels
                    WriteLine(selectFields);
                
                    // Write Blank Line
                    WriteLine();
                
                    // Write Comment From tableName
                    WriteComment("From tableName");
                
                    // Write Line
                    WriteLine("From [" + dataTable.Name + "]");
                    
                    // Write Blank Line
                    WriteLine();

                    // if the value for fetchAll is true
                    if (fetchAll)
                    {
                        // Add the WhereClause
                        WriteWhereClause(parameterField, ProcedureTypeEnum.FetchAll);
                    }
                    else
                    {
                        // Add the WhereClause
                        WriteWhereClause(parameterField, ProcedureTypeEnum.Find);
                    }

                    // If the orderByField object exists
                    if (NullHelper.Exists(orderByField))
                    {
                        // Write the OrderByField
                        WriteOrderByField(orderByField, orderByFieldDescending);
                    }
                    // If the orderByFieldSet object exists
                    else if ((NullHelper.Exists(orderByFieldSet)) && (ListHelper.HasOneOrMoreItems(orderByFieldSet.Fields)))
                    {
                        // Write the OrderByFieldSet
                        WriteOrderByFieldSet(orderByFieldSet);
                    }
                    
                    // Write End Procedure
                    WriteEndProcedure();
                }
            }
            #endregion

            #region CreateFindProc(DataTable dataTable, bool fetchAll, string procedureName, List<DataField> parameters, CustomReader customReader = null, FieldSet orderByFieldSet = null, FieldSet orderByFieldSet = null)
            /// <summary>
            /// This method creates the Find procedure for the table, procedureName and parameterField given. 
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="fetchAll">Is this a Find or a FetchAll procedure</param>
            /// <param name="procedureName">The name of the stored procedure to create</param>
            /// <param name="orderByFieldSet">If set, this overrides the PrimaryKey parameter</param>
            public void CreateFindProc(DataTable dataTable, bool fetchAll, string procedureName, List<DataField> parameters, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null, bool orderByDescending = false, int topRows = 0)
            {
                // If all objects exist and the parameters collection has one or more items
                if ((NullHelper.Exists(dataTable)) && (TextHelper.Exists(procedureName)) && (ListHelper.HasOneOrMoreItems(parameters)))
                {
                    // if this is a fetch all
                    if(fetchAll)
                    {
                        // Perform the Procedure Innitialization
                        InitProcedure(dataTable, ProcedureTypeEnum.FetchAll, procedureName, parameters);
                    }
                    else
                    {
                        // Perform the Procedure Innitialization
                        InitProcedure(dataTable, ProcedureTypeEnum.Find, procedureName, parameters);
                    }

                    // Write out the field parameters
                    WriteFieldParameters(parameters);
                    
                    // Write Blank Line
                    WriteLine();

                    // Write BeginProcedure
                    WriteBeginProcedure();

                    // Write Comment Begin Select Statement
                    WriteComment("Begin Select Statement");

                    // Write Select Fields
                    string selectFields = CreateFieldList(dataTable, true, true, customReader);
                
                    // If the value for topRows is greater than zero
                    if (topRows > 0)
                    {
                        // append Top (x) to the Select List so the top rows is returned (fixing bug where there wasn't a
                        // space between the number and the first field.
                        selectFields = selectFields.Replace("Select ", "Select Top " + topRows.ToString() + " "); 
                    }

                    // Write select fiels
                    WriteLine(selectFields);
                
                    // Write Blank Line
                    WriteLine();
                
                    // Write Comment From tableName
                    WriteComment("From tableName");
                
                    // Write Line
                    WriteLine("From [" + dataTable.Name + "]");
                    
                    // Write Blank Line
                    WriteLine();

                    // if the value for fetchAll is true
                    if (fetchAll)
                    {
                        // Add the WhereClause
                        WriteWhereClause(parameters, ProcedureTypeEnum.FetchAll);
                    }
                    else
                    {
                        // Add the WhereClause
                        WriteWhereClause(parameters, ProcedureTypeEnum.Find);
                    }

                    // If the orderByField object exists
                    if (NullHelper.Exists(orderByField))
                    {
                        // Write the OrderByField
                        WriteOrderByField(orderByField);
                    }
                    // If the orderByFieldSet object exists
                    else if ((NullHelper.Exists(orderByFieldSet)) && (ListHelper.HasOneOrMoreItems(orderByFieldSet.Fields)))
                    {
                        // Write the OrderByFieldSet
                        WriteOrderByFieldSet(orderByFieldSet);
                    }
                    
                    // Write End Procedure
                    WriteEndProcedure();
                }
            }
            #endregion

            #region CreateIfProcExists(string procedureName)
            /// <summary>
            /// This method creates the line that checks if a stored proc already exists
            /// </summary>
            /// <param name="procedureName"></param>
            /// <returns></returns>
            private string CreateIfProcExists(string procedureName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();

                // Initialize String builder
                sb.Append("IF EXISTS (select * from syscomments where id = object_id ('");

                // Append Procure Name
                sb.Append(procedureName);

                // Append close single quote and closing braces
                sb.Append("'))");

                // return value
                return sb.ToString();
            }
            #endregion
            
            #region CreateIfObjectIDIsNotNull(string procedureName)
            /// <summary>
            /// This method creates the line "IF OBJECT_ID('[dbo.ProcedureName]') IS NOT NULL"
            /// </summary>
            /// <param name="procedureName">The procedure to create the line for</param>
            /// <returns>A string that will check if a proc still exists</returns>
            private string CreateIfObjectIDIsNotNull(string procedureName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("IF OBJECT_ID('dbo.");

                //  append procedure name
                sb.Append(procedureName);

                // append closing single quote and closing ) and IS NOT NULL
                sb.Append("') IS NOT NULL");

                // return value
                return sb.ToString();
            } 
            #endregion

            #region CreateInsertProc(DataTable dataTable)
            /// <summary>
            /// This method creates the insert procedure for a datatable.
            /// </summary>
            /// <param name="dataTable"></param>
            public void CreateInsertProc(DataTable dataTable)
            {
                // locals
                bool ignorePrimaryKey = false;
                bool allFields = false;

                // if this is an auto number field
                if ((dataTable.HasPrimaryKey) && (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber))
                {
                    // you must ignore the primary key on an insert if the primary key is an identity column
                    ignorePrimaryKey = true;
                }
                else
                {
                    // set allFields to true
                    allFields = true;
                }

                // Perform the Procedure Innitialization
                InitProcedure(dataTable, ProcedureTypeEnum.Insert);

                // Create InsertParams
                WriteEditParameters(dataTable.ActiveFields, ignorePrimaryKey);

                // Write BeginProcedure
                WriteBeginProcedure();

                // Write Comment For Begin Insert Statement
                WriteComment("Begin Insert Statement");

                // Write Procedure 
                WriteLine("Insert Into [" + dataTable.Name + "]");

                // Create FieldList
                string fieldList = CreateFieldList(dataTable, allFields, false);

                // Write fieldsList
                WriteLine(fieldList);

                // WriteLine 
                WriteLine();

                // Write Comment For Begin Insert Statement
                WriteComment("Begin Values List");

                // Create Values list
                string valuesList = CreateValuesList(dataTable.ActiveFields, ignorePrimaryKey);

                // write values list
                WriteLine(valuesList);

                // Update 12.27.2016: Only write the Selected Identity for Identity columns; this was causing an error
                if ((dataTable.HasPrimaryKey) && (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber))
                {
                    // Write return value
                    WriteInsertReturnValue();
                }

                // Write End Procedure
                WriteEndProcedure();
            }
            #endregion

            #region CreateProcedureDescription(DataTable dataTable, ProcedureTypeEnum procedureType, DataField parameterField = null, List<DataField> parameters = null)
            /// <summary>
            /// This procedure creates the comment description for a proc based upon
            /// the 'ProcedureType;
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="procedureType"></param>
            /// <param name="parameterField">A single field parameter.</param>
            /// <param name="parameters">A list of fields for a FieldSet parameters.</param>
            /// <returns></returns>
            private string CreateProcedureDescription(string tableName, ProcedureTypeEnum procedureType, DataField parameterField = null, List<DataField> parameters = null)
            {
                // initial value
                string description = null;
            
                // Get Procedure Type Name
                string procedureTypeName = procedureType.ToString();
                
                // Determine procedure type
                switch(procedureType)
                {
                    case ProcedureTypeEnum.Insert:
                    
                        // set description for an insert
                        description = procedureTypeName + " a new " + tableName;
                    
                        // required
                        break;

                    case ProcedureTypeEnum.Find:
                    case ProcedureTypeEnum.Update:
                    case ProcedureTypeEnum.Delete:

                        // set description 
                        description = procedureTypeName + " an existing " + tableName;
                    
                        // required
                        break;

                    case ProcedureTypeEnum.FetchAll:

                        // set description 
                        description = "Returns all " + tableName + " objects";

                        // required
                        break;
                }

                // If the parameterField object exists
                if ((NullHelper.Exists(parameterField)) && (procedureType != ProcedureTypeEnum.Insert))
                {
                    // update the description for the parameterField
                    description += " for the " + parameterField.FieldName + " given.";
                }
                else if (ListHelper.HasOneOrMoreItems(parameters))
                {
                    // set the fieldSetName
                    string fieldSetName = parameters[0].FieldSetName;

                    // update the description for the parameterField (by makes more sense here to me in most cases, but it is a comment, so change it if you want).
                    description += " by " + fieldSetName;
                }
                
                // return value;
                return description;
            }		  
            #endregion

            #region CreateProcedureName(DataTable dataTable, ProcedureTypeEnum procedureType)
            /// <summary>
            /// This method creates the procedure name based upon the table name and the OrocedureType
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="procedureType"></param>
            /// <returns></returns>
            private string CreateProcedureName(DataTable dataTable, ProcedureTypeEnum procedureType)
            {
                // initial value
                StringBuilder sb = new StringBuilder();

                // Append tableName
                sb.Append(dataTable.Name);

                // Append _
                sb.Append("_");

                // Append ProcedureType
                sb.Append(procedureType.ToString());

                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateStoredProcedures(List<DataTable> dataTables, string filePath, List<TextLine> additionalTextLines, string databaseName)
            /// <summary>
            /// This method creates the sql file needed to create 
            /// // the stored procedures for a collection of DataTables.
            /// </summary>
            public void CreateStoredProcedures(List<DataTable> dataTables, string filePath, List<TextLine> additionalTextLines, string databaseName)
            {
                try
                {
                    // if we are in TextWriterMode
                    if (TextWriterMode)
                    {
                        // Create a text Writer
                        TextWriter = new StringBuilder();
                    }
                    else
                    {
                        // Create the stream writer and open the text file
                        this.CreateFile(filePath);

                        // 5.2.2019: Putting back useDatabase statement
                        string useDatabase = "Use [" + databaseName + "]";
                        WriteLine(useDatabase);
                    }

                    // Write Stored procs for each data table in dataTables collection
                    foreach (DataTable dataTable in dataTables)
                    {
                        // Create table Procedures
                        CreateTableProcs(dataTable);
                    }

                    // if there are additionalTextLines
                    if (ListHelper.HasOneOrMoreItems(additionalTextLines))
                    {
                        // Write a blank line
                        WriteLine();

                        // Write a comment
                        WriteComment("Begin Custom Methods");

                        // Write a blank line
                        WriteLine();

                        // Iterate the collection of TextLine objects
                        foreach (TextLine textLine in additionalTextLines)
                        {
                            // Write out each additionalLine
                            WriteLine(textLine.Text);
                        }

                        // Write a blank line
                        WriteLine();

                        // Write a comment
                        WriteComment("End Custom Methods");
                    }

                    // Write a blank line
                    WriteLine();

                    // Write a comment
                    WriteComment("Thank you for using DataTier.Net.");

                    // Write a blank line
                    WriteLine();
                }
                catch 
                {
                   
                }
                
                // if the value for TextWriterMode is false
                if (!TextWriterMode)
                {
                    // Close File
                    CloseFile();
                }
            }
            #endregion

            #region CreateTableProcs(DataTable dataTable)
            /// <summary>
            /// This method creates the procecures for a data table.
            /// </summary>
            /// <param name="dataTable"></param>
            public void CreateTableProcs(DataTable dataTable)
            {
                // if the dataTable exists
                if ((dataTable != null) && (!dataTable.Exclude))
                {
                    // Only create the InsertProc if this table is not a view
                    if (dataTable.IsView)
                    {
                        // Create FetchAllProc
                        CreateFindProc(dataTable, true);
                    }
                    else
                    {
                        // Create Insert Proc      
                        CreateInsertProc(dataTable);

                        // if this table has a primary key
                        if (dataTable.HasPrimaryKey)
                        {
                            // Create Update Proc
                            CreateUpdateProc(dataTable);

                            // Create FindProc
                            CreateFindProc(dataTable, false);

                            // Create Delete Proc
                            CreateDeleteProc(dataTable);
                        }

                        // Create FetchAllProc
                        CreateFindProc(dataTable, true);
                    }
                }
            }
            #endregion

            #region CreateUpdateProc(DataTable dataTable)
            /// <summary>
            /// This method creates the update stored procedure a data table
            /// </summary>
            /// <param name="dataTable">The table to create the proc for.</param>
            public void CreateUpdateProc(DataTable dataTable)
            {
                // Perform the Procedure Innitialization
                InitProcedure(dataTable, ProcedureTypeEnum.Update);
                
                // Create UpdateParams
                WriteEditParameters(dataTable.ActiveFields, false);

                // Write BeginProcedure
                WriteBeginProcedure();

                // Write Comment Update This table
                WriteComment("Begin Update Statement");

                // Write Procedure 
                WriteLine("Update [" + dataTable.Name + "]");
                               
                // WriteSetFieldEqualsValue
                WriteFieldEqualsValuePairs(dataTable);
                
                // Write WhereClause
                WriteWhereClause(dataTable.PrimaryKey, ProcedureTypeEnum.Update);

                // Write End Procedure
                WriteEndProcedure();
            }
            #endregion

            #region CreateValuesList(DataList<Fields> dataList, bool ignorePrimaryKey)
            /// <summary>
            /// Create values list
            /// </summary>
            /// <param name="dataList"></param>
            /// <returns></returns>
            public string CreateValuesList(List<DataField> dataList, bool ignorePrimaryKey)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("Values(");
                
                // bool firstField
                bool firstField = true;
                bool skipField = false;
                
                // if the dataFields collection exists
                if(dataList != null)
                {
                    // loop through each field
                    foreach(DataField field in dataList)
                    {
                        // reset the value for skipField
                        skipField = false;
                        
                        // if ignorePrimaryKey is false and this field is the primary key
                        if ((ignorePrimaryKey) && (field.PrimaryKey))
                        {
                            // this field should be skipped
                            skipField = true;
                        }

                        // if this field should not be skipped
                        if (!skipField)
                        {  
                            // If this is not the first field
                            if(!firstField)
                            {
                                // Add Comma
                                sb.Append(", ");
                            }
                                
                            // set firstField to false so a comma gets added.
                            firstField = false;
                                
                            // Add @
                            sb.Append("@");
                                
                            // Add fieldName
                            sb.Append(field.FieldName);
                        }
                    }
                }  
                
                // Add Closing )
                sb.Append(")");    
                
                // return value
                return sb.ToString();          
            } 
            #endregion

            #region CloseFile()
            /// <summary>
            /// Closes the open file stream
            /// </summary>
            public void CloseFile()
            {
                // Close the open file stream
                Writer.Close();
            }
            #endregion

            #region FindFieldSetFieldView(List<FieldSetField> fields, int fieldId)
            /// <summary>
            /// This method returns the Field
            /// </summary>
            public static FieldSetFieldView FindFieldSetFieldView(List<FieldSetFieldView> fields, int fieldId)
            {
                // initial value
                FieldSetFieldView field = null;

                // If the fields collection exists and has one or more items
                if ((ListHelper.HasOneOrMoreItems(fields)) && (fieldId > 0))
                {
                    // Iterate the collection of DTNField objects
                    foreach (FieldSetFieldView tempField in fields)
                    {
                        // if this is the field being sought                        
                        if (tempField.FieldId == fieldId)
                        {
                            // set the return value                            
                            field = tempField;

                            // break;
                            break;
                        }
                    }
                }
                
                // return value
                return field;
            }
            #endregion

            #region IndentString(string StringToIndent) string
            /// <summary>
            /// This method indents a string based
            /// on the Indent property value
            /// </summary>
            /// <param name="StringToIndent"></param>
            /// <returns></returns>
			private string IndentString(string StringToIndent)
			{
				//Create String Builder
				StringBuilder sb = new StringBuilder();

				int NumberSpaces = Indent * 4;

				// PadLeft Spaces Up To Indent Number
				for(int x = 0;x < NumberSpaces;x++)
				{
					sb.Append(" ");
				}

				sb.Append(StringToIndent);

				return sb.ToString();
			}
			#endregion
	
	        #region Init()
            /// <summary>
            /// Perform any initializations needed for this object.
            /// </summary>
            private void Init()
            {  
                // if the value for TextWriterMode is true
                if (TextWriterMode)
                {
                    // Create a new instance of a 'StringBuilder' object.
                    TextWriter = new StringBuilder();
                }
            }            
            #endregion		
          
            #region InitProcedure(DataTable dataTable , ProcedureTypeEnum procedureType)
            /// <summary>
            /// This method creates the initialization for a new procedure
            /// </summary>
            /// <param name="dataTable"></param>
            private void InitProcedure(DataTable dataTable, ProcedureTypeEnum procedureType)
            {
                // Set Identity to zero
                indent = 0;

                // Create Procedure Name
                string procedureName = CreateProcedureName(dataTable, procedureType);
                
                // Write Procedure Header
                WriteProcedureHeader(procedureName, dataTable.Name, procedureType);

                // Write The sql To Check If The Proc Already Exists
                // And Drop The Proc If It Does
                WriteDeleteProcIfExists(procedureName);

                // Create Procedure Name
                WriteCreateProcedure(procedureName);
            }
            #endregion

            #region InitProcedure(DataTable dataTable, ProcedureTypeEnum procedureType, string procedureName, DataField parameterField)
            /// <summary>
            /// This method creates the initialization for a new procedure
            /// </summary>
            /// <param name="dataTable"></param>
            private void InitProcedure(DataTable dataTable, ProcedureTypeEnum procedureType, string procedureName, DataField parameterField)
            {
                // Set Identity to zero
                indent = 0;

                // Write Procedure Header
                WriteProcedureHeader(procedureName, dataTable.Name, procedureType, parameterField);

                // Write The sql To Check If The Proc Already Exists
                // And Drop The Proc If It Does
                WriteDeleteProcIfExists(procedureName);

                // Create Procedure Name
                WriteCreateProcedure(procedureName);
            }
            #endregion
          
            #region InitProcedure(DataTable dataTable, ProcedureTypeEnum procedureType, string procedureName, , List<DataField> parameters)
            /// <summary>
            /// This method creates the initialization for a new procedure
            /// </summary>
            /// <param name="dataTable"></param>
            private void InitProcedure(DataTable dataTable, ProcedureTypeEnum procedureType, string procedureName, List<DataField> parameters)
            {
                // Set Identity to zero
                indent = 0;

                // Write Procedure Header
                WriteProcedureHeader(procedureName, dataTable.Name, procedureType, null, parameters);

                // Write The sql To Check If The Proc Already Exists
                // And Drop The Proc If It Does
                WriteDeleteProcIfExists(procedureName);

                // Create Procedure Name
                WriteCreateProcedure(procedureName);
            }
            #endregion

            #region ParseDataType(DataManager.DataTypes dataTypes)
            /// <summary>
            /// This method parses the data type enum to a string
            /// for the sql parameter
            /// </summary>
            /// <param name="dataTypes"></param>
            /// <returns></returns>
            private string ParseDataType(DataField field)
            {
                // initial value
                string dataTypeString = null;
                
                // local
                int size = 0;
            
                // determine data type
                switch(field.DataType)
                {
                    case DataManager.DataTypeEnum.Autonumber:
                    case DataManager.DataTypeEnum.Integer:
                    case DataManager.DataTypeEnum.Enumeration:
                    
                        // Set DataType
                        dataTypeString = "int";
                    
                        // required
                        break;

                    case DataManager.DataTypeEnum.Binary:
                    
                        // Set size to max
                        size = field.Size;
                        
                        // if size > 8000
                        if(size > 4000)
                        {
                            // Set size to 4000
                            size = 4000;
                        }
                        
                        // Set datatype
                        dataTypeString = "varbinary(max)";
                        
                        // Required
                        break;

                    case DataManager.DataTypeEnum.String:

                        // Set size to max
                        size = field.Size;

                        // Set DataType
                        dataTypeString = "nvarchar(" + size.ToString() + ")";
                        
                        // if size > 4000
                        if(size > 4000)
                        {
                            // Set DataType
                            dataTypeString = "nvarchar(max)";
                        }
                        
                        // required
                        break;

                    case DataManager.DataTypeEnum.Guid:

                        // Set DataType
                        dataTypeString = "uniqueidentifier";

                        // required
                        break;

                    case DataManager.DataTypeEnum.DateTime:

                        // Set DataType
                        dataTypeString = "datetime";

                        // required
                        break;

                    case DataManager.DataTypeEnum.Boolean:

                            // Set DataType
                            dataTypeString = "bit";
                        
                            // required
                            break;

                    case DataManager.DataTypeEnum.Decimal:

                            // Set DataType
                            dataTypeString = field.CreateDecimalDataType();

                            // required
                            break;

                    case DataManager.DataTypeEnum.Currency:

                            // Set DataType
                            dataTypeString = "money";

                            // required
                            break;

                    case DataManager.DataTypeEnum.Double:

                            // Set DataType
                            dataTypeString = "float";

                            // required
                            break;
                }
                
                // return value
                return dataTypeString;
            }  
            #endregion

            #region WriteBeginProcedure()
            /// <summary>
            /// This method writes the AS and Begin & Set No Count Lines
            /// For All Procedures
            /// </summary>
            private void WriteBeginProcedure()
            {
                // Write AS
                WriteLine("AS");

                // Write Begin 
                WriteLine("BEGIN");

                // Increase Indent
                Indent++;

                // Write Blank Line
                WriteLine();

                // Write No Count
                WriteNoCount();

                // Write Blank Line
                WriteLine();
            } 
            #endregion

            #region WriteEndProcedure()
            /// <summary>
            /// This method is the end of the stored procedure
            /// </summary>
            private void WriteEndProcedure()
            {
                // Decrease Indent++;
                Indent--;

                // Write Blank Line
                WriteLine();

                // Write END 
                WriteLine("END");
            } 
            #endregion
            
            #region WriteComment()
            /// <summary>
            /// Writes a comment in the proc text
            /// </summary>
            /// <param name="CommentText"></param>
			private void WriteComment(string commentText)
			{
				// Write Line Containing Comment
				StringBuilder sb = new StringBuilder("-- ");
				
				// Add Comment Text
				sb.Append(commentText);
				
				// Get New Line
				string newLine = sb.ToString();
				
				// Write Line
				WriteLine(newLine);
			}
			#endregion

            #region WriteCreateProcedure(string procedureName)
            /// <summary>
            /// This method writes the line to create the procedure
            /// </summary>
            /// <param name="procedureName">The name of the procedure to add.</param>
            private void WriteCreateProcedure(string procedureName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("Create PROCEDURE ");

                // Append Procedure Name
                sb.Append(procedureName);

                // return value
                string procedureLine = sb.ToString();

                // Write procedureLine
                WriteLine(procedureLine);
            }		 
            #endregion

            #region WriteDeleteProcIfExists(string procedureName)
            /// <summary>
            /// This method writes the sql needed to check if
            /// a stored proc already exists, and if yes delete it.
            /// </summary>
            /// <param name="procedureName"></param>
            private void WriteDeleteProcIfExists(string procedureName)
            {
                // Write Blank Line
                WriteLine();
                
                // Write Comment Check if the procedure already exists
                WriteComment("Check if the procedure already exists");

                // Get If Exists Line
                string ifExists = CreateIfProcExists(procedureName);

                // If Exists Line
                WriteLine(ifExists);
                
                // Write Blank Line
                WriteLine();
                
                // Increase Indent
                indent++;
                
                // Write Comment Procedure Does Exist, Drop First
                WriteComment("Procedure Does Exist, Drop First");
	            
	            // Write Begin
	            WriteLine("BEGIN");

                // Write Blank Line
                WriteLine();

                // Increase Indent
                indent++;

                // Write Comment Execute Drop
                WriteComment("Execute Drop");
                
                // Get Drop Line
                string dropProcedure = CreateDropProcedure(procedureName);

                // Write drop procedure line
                WriteLine(dropProcedure);

                // Write Blank Line
                WriteLine();

                // Write Comment Test if procedure was dropped
                WriteComment("Test if procedure was dropped");

                // Create If ObjectId("[ProcedureName]") IsNotNull Line
                string ifObjectIDIsNotNull = CreateIfObjectIDIsNotNull(procedureName);

                // Write ifObjectIDIsNotNull
                WriteLine(ifObjectIDIsNotNull);

                // Write Blank Line
                WriteLine();

                // Increase Indent
                indent++;
                
                // Write Comment Drop Failed
                WriteComment("Print Line Drop Failed");

                // Get drop failed message
                string dropFailedMessage = CreateActionMessage("Drop", procedureName, false);

                // write drop failed message
                WriteLine(dropFailedMessage);

                // decrease Indent
                indent--;

                // Write Blank Line
                WriteLine();

                // Write Else
                WriteLine("Else");

                // Write Blank Line
                WriteLine();

                // Increase Indent
                indent++;

                // Write Comment Print Line Procedure Dropped
                WriteComment("Print Line Procedure Dropped");
                
                // Create Procedure Dropped Line
                string dropSuccessMessage = CreateActionMessage("Drop", procedureName, true);
                
                // Write Drop Failed Message
                WriteLine(dropSuccessMessage);

                // decrease Indent
                indent--;

                // decrease Indent
                indent--;

                // Write Blank Line
                WriteLine();

                // Write End
                WriteLine("End");
	          
                // Write Blank Line
                WriteLine();

                // decrease Indent
                indent--;
                
                // Write Go
                WriteLine("GO");

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteEditParameters(DataList<Fields> dataList, bool ignorePrimaryKey)
            /// <summary>
            /// This method writes the parameters for an Insert or an Update
            /// </summary>
            /// <param name="dataList"></param>
            /// </summary>
            /// <param name="dataList">The fields to create parameters from.</param>
            /// <param name="isInsert">Is this an update or an insert, inserts do not have a PrimaryKey param</param>
            private void WriteEditParameters(List<DataField> dataList, bool ignorePrimaryKey)
            {   
                // locals
                bool lastField = false;
                
                // Create DataFields That Will Become EditParameters 
                // This is intentionally using isInsert twice in the 
                // the call to CreateEditFields below. The first is
                // to make fields like ModifiedBy be ignored
                // The second ignores the primary key, but only 
                // on insert statements.
                List<DataField> editParameters = CreateEditFields(dataList, ignorePrimaryKey);
                
                // Begin Writing Now

                // Write Blank Line
                WriteLine();

                // Increase Indent
                Indent++;

                // Write Comment For The Start Of The Parameters
                WriteComment("Add the parameters for the stored procedure here");
                
                // Add Each field In Edit Param
                for(int x = 0; x < editParameters.Count; x++)
                {
                    // Create field
                    DataField field = editParameters[x];
                    
                    // is this the last field
                    lastField = (x == editParameters.Count - 1);
                    
                    // Create field Param
                    string fieldParam = CreateFieldParam(field, lastField);
                    
                    // Write FieldParam
                    WriteLine(fieldParam);
                }

                // Decrease Indent
                Indent--;
                
                // Write Blank 
                WriteLine();
            }
            #endregion

            #region WriteFieldEqualsValuePairs(DataTable dataTable)
            /// <summary>
            /// This method writes the values for an Update statement
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteFieldEqualsValuePairs(DataTable dataTable)
            {
                // locals
                bool firstField = true;
                bool ignorePrimaryKey = false;
            
                // Write Blank Line
                WriteLine();
                
                // verify dataTable exists and dataTable.DataFields exists
                if(dataTable != null)
                {
                    // if this dataTable has a primary key and the primary key is an identity column
                    if ((dataTable.HasPrimaryKey) && (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber))
                    {
                        // this primary key should be ignored
                        ignorePrimaryKey = true;
                    }

                    // Write Comment Update Each field
                    WriteComment("Update Each field");
                
                    // variable for first field
                    bool lastField = false;

                    // Create DataFields That Will Become EditParameters
                    List<DataField> fieldValuePairs = CreateEditFields(dataTable.ActiveFields, ignorePrimaryKey);
                
                    // verify fieldValuePairs was created
                    if(fieldValuePairs != null)
                    {
                        // loop through fields collection
                        for (int x = 0; x < fieldValuePairs.Count; x++)
                        {
                            // Create field
                            DataField field = fieldValuePairs[x];

                            // test if this is the last field
                            lastField = (x == (fieldValuePairs.Count - 1));
                            
                            // Get The Parameter For This field
                            string fieldEqualsValuePair = CreateFieldEqualsValuePair(field.FieldName, firstField, lastField);

                            // Write fieldParam
                            WriteLine(fieldEqualsValuePair);

                            // set firstField to false
                            firstField = false;
                        }
                    }
                }
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteFieldParameter(DataField dataField, bool appendComma = false)
            /// <summary>
            /// This method writes the parameter. This is
            /// used in custom methods for DataTier.Net
            /// </summary>
            /// <param name="dataList"></param>
            private string WriteFieldParameter(DataField dataField, bool appendComma = false)
            {  
                // initial value 
                string parameter = "";

                // check if dataField exists
                if(dataField != null)
                {
                    // Increase Indent
                    Indent++;
                    
                    // Write Blank Line
                    WriteLine();
                    
                    // Write Comment For The Start Of The Parameters
                    WriteComment("Create @" + dataField.FieldName + " Paramater");

                    // Get FieldParam
                    parameter = CreateFieldParam(dataField, true);

                    // if a comma should be added to the end
                    if (appendComma)
                    {
                        // append the comma
                        parameter += ",";
                    }
                    
                    // Write Parameter
                    WriteLine(parameter);

                    // Decrease Indent
                    Indent--;
                    
                    // Write Blank Line
                    WriteLine();
                }

                // return value
                return parameter;
            }  
            #endregion

            #region WriteFieldParameters(List<DataField> parameters)
            /// <summary>
            /// This method Write Field Parameters
            /// </summary>
            public void WriteFieldParameters(List<DataField> parameters)
            {
                // locals
                int count = 0;
                bool appendComma = false;

                // If the parameters collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(parameters))
                {
                    // Iterate the collection of DataField objects
                    foreach (DataField parameter in parameters)
                    {
                        // Increment the value for count
                        count++;

                        // set appendComma to true if this not the last parameter
                        appendComma = (count < parameters.Count);

                        // Create parameter for this field
                        WriteFieldParameter(parameter, appendComma);
                    }
                }
            }
            #endregion

            #region WritePrimaryKeyParameter(DataList<Fields> dataList)
            /// <summary>
            /// This method writes the primary key parameter. This is
            /// used in the Find and Delete procs.
            /// </summary>
            /// <param name="dataList"></param>
            private void WritePrimaryKeyParameter(DataTable dataTable)
            {
                // local
                DataField primaryKeyField = null;
                
                // verify dataTable exists and has a primary key
                if ((dataTable != null) && (dataTable.PrimaryKey != null))
                {
                    // set primary key
                    primaryKeyField = dataTable.PrimaryKey;
                }
                
                // check if primary key exists
                if(primaryKeyField != null)
                {
                    // Increase Indent
                    Indent++;
                    
                    // Write Blank Line
                    WriteLine();
                    
                    // Write Comment For The Start Of The Parameters
                    WriteComment("Primary Key Paramater");

                    // Get FieldParam
                    string primaryKeyParam = CreateFieldParam(primaryKeyField, true);
                    
                    // Write Parameter
                    WriteLine(primaryKeyParam);

                    // Decrease Indent
                    Indent--;
                    
                    // Write Blank Line
                    WriteLine();
                }
            }  
            #endregion
            
            #region WriteProcedureHeader(string procedureName, string tableName, ProcedureTypeEnum procedureType, DataField parameterField = null, List<DataField> parameters = null)
            /// <summary>
            /// This method creates the procedure header for any stored procedure.
            /// </summary>
            /// <param name="procedureName"></param>
            /// <param name="parameterField">A single field parameter, used for a Single Field parameter type.</param>
            /// <param name="parameters">A list of parameters, which is used when creating a procedure for a FieldSet</param>
            private void WriteProcedureHeader(string procedureName, string tableName, ProcedureTypeEnum procedureType, DataField parameterField = null, List<DataField> parameters = null)
            {
                // Write Blank Line Between This Proc And The Last (If Any)
                WriteLine();
                
                // Write set ANSI_NULLS ON
                WriteLine("set ANSI_NULLS ON");
                
                // Write set QUOTED_IDENTIFIER ON
                WriteLine("set QUOTED_IDENTIFIER ON");
                
                // Write Go
                WriteLine("Go");
                
                // Get Procedure Description
                string procedureDescription = CreateProcedureDescription(tableName, procedureType, parameterField, parameters);
                
                // Write Header Comment Line Seperator
                WriteComment("=========================================================");
                WriteComment("Procure Name: " + procedureName);
                WriteComment("Author:           Data Juggler - Data Tier.Net Procedure Generator");
                WriteComment("Create Date:   " + DateTime.Now.ToShortDateString());
                WriteComment("Description:    " + procedureDescription.Trim());
                
                // Write Header Comment Line Seperator
                WriteLine("-- =========================================================");
            }
            #endregion

            #region WriteInsertReturnValue()
            /// <summary>
            /// This method writes the return value for an 
            /// insert proc.
            /// </summary>
            private void WriteInsertReturnValue()
            {
                // Write Blank Line
                WriteLine();
                
                // Write Comment
                WriteComment("Return ID of new record");
                
                // Write Return Value
                WriteLine("SELECT SCOPE_IDENTITY()");               
            }
            #endregion

            #region WriteLine() + 4 overrides
					
				#region WriteLine(string text, bool newLine, bool skipText, bool skipIndent)
                /// <summary>
                /// This method is used to write to the StreamWriter (Writer) or the StringBuilder (TextWriter).
                /// </summary>
                /// <param name="text">The text to write</param>
                /// <param name="newLine">Should a new line character be added to the end.</param>
                /// <param name="skipText">Set this to true to only add a blank line.</param>
                /// <param name="skipIndent">By default the text is indented 4 spaces per Indent level. Set this to true to not indent.</param>
				internal void WriteLine(string text, bool newLine, bool skipText, bool skipIndent)
				{
					// string to hold linetext + Indent
					string lineText = null;

					// If Text Is Not Skipped
					if(!skipText)
					{
						// Set linetext to LineText incase skipIndent 
						lineText = text;

						// If SkipIndent Is False Do Not Indent String
						if(!skipIndent)
						{
							// string to hold Indent + text
							lineText = IndentString(text);
						}

                        // if the value for TextWriterMode is true
                        if ((TextWriterMode) && (HasTextWriter))
                        {
                            // Write to the StringBuilder
                            TextWriter.Append(lineText);
                        }
                        else if (HasWriter)
                        {
						    // Write The Current Line
						    Writer.Write(lineText);
                        }
					}

					// If NewLine 
					if(newLine)
					{
                        // Add a new line

                         // if the value for TextWriterMode is true
                        if ((TextWriterMode) && (HasTextWriter))
                        {
                            // Write to the StringBuilder
                            TextWriter.Append(Environment.NewLine);
                        }
                        else if (HasWriter)
                        {
						    // Write a new line character
						    Writer.Write(Writer.NewLine);
                        }

						
					}
				}
				#endregion

				#region WriteLine(string text,bool newLine, bool skipText)
				/// <summary>
				/// Indent Is Automatic With This Method
				/// </summary>
				/// <param name="text">The text to write.</param>
				/// <param name="newLine">Set this to true to append a new line character to the end.</param>
                /// <param name="skipText">Set this to true to only write a blank line</param>
				internal void WriteLine(string text, bool newLine, bool skipText)
				{
					// Call Write Line With These Parameters
					WriteLine(text, newLine, skipText, false);
				}
				#endregion		
			
				#region WriteLine(string text, bool newLine)
				/// <summary>
				/// Indent & SkipText Are Automatic
				/// </summary>
				/// <param name="text">The text to write.</param>
				/// <param name="newLine">Should a newLine character be added to the end.</param>
				internal void WriteLine(string text, bool newLine)
				{
					// Call WriteLine
					WriteLine(text, newLine, false, false);
				}
				#endregion

				#region WriteLine(string text)
				/// <summary>
				/// With this override, SkipText Is False, NewLine Is True, Indent Is True
				/// </summary>
				/// <param name="text">The text to write.</param>
				internal void WriteLine(string text)
				{
					// WriteLine
					WriteLine(text, true, false, false);
				}
				#endregion

				#region WriteLine() 
				/// <summary>
				/// Writes a blank line.
				/// </summary>
				internal void WriteLine()
				{
					WriteLine(null, true, true, false);
				}
				#endregion

			#endregion

            #region WriteNoCount()
            /// <summary>
            /// Thie method writes the no count, so that extra rows
            /// are not returned.
            /// </summary>
            private void WriteNoCount()
            {
                // Write No Count Info
                WriteComment("SET NOCOUNT ON added to prevent extra result sets from");
	            WriteComment("interfering with SELECT statements.");
	            WriteLine("SET NOCOUNT ON");
            } 
            #endregion

            #region WriteOrderByField(DTNField orderByField, bool descending = false)
            /// <summary>
            /// This method Write Order By Field
            /// </summary>
            public void WriteOrderByField(DTNField orderByField, bool descending = false)
            {   
                // If the orderByField object exists
                if (NullHelper.Exists(orderByField))
                {
                    // Write Blank Line
                    WriteLine();

                    // if descending
                    if (descending)
                    {
                        // Write Comment
                        WriteComment("Order by " + orderByField + " in descending order");

                        // Write the FieldName and desc
                        WriteLine("Order By [" + orderByField.FieldName + "] desc" );
                    }
                    else
                    {
                        // Write Comment
                        WriteComment("Order by " + orderByField);

                        // Write the FieldName
                        WriteLine("Order By [" + orderByField.FieldName + "]" );
                    }
                }
            }
            #endregion

            #region WriteOrderByFieldSet(FieldSet orderByFieldSet)
            /// <summary>
            /// This method Write Order By Field Set
            /// </summary>
            public void WriteOrderByFieldSet(FieldSet orderByFieldSet)
            {
                // If the orderByFieldSet object exists and has one or more fields
                if ((NullHelper.Exists(orderByFieldSet)) && (ListHelper.HasOneOrMoreItems(orderByFieldSet.Fields) && (orderByFieldSet.HasFieldSetFields)))
                {
                    // Write Blank Line
                    WriteLine();

                    // create a string builder
                    StringBuilder sb = new StringBuilder("Order By " );

                    // iterate the Fields
                    foreach (DTNField field in orderByFieldSet.Fields)
                    {
                        // Add this field
                        sb.Append("[" + field.FieldName + "]");

                        // attempt to find this field
                        FieldSetFieldView tempFieldSetField = FindFieldSetFieldView(orderByFieldSet.FieldSetFields, field.FieldId);

                        // if this field was found and is descending
                        if ((NullHelper.Exists(tempFieldSetField)) && (tempFieldSetField.OrderByDescending))
                        {
                            // append the word descending
                            sb.Append(" desc");
                        }

                        // Add a comma
                        sb.Append(",");
                    }

                    // set the temp
                    string temp = sb.ToString();

                    // set the orderBy string (trim off the last comma)
                    string orderBy = temp.Substring(0, temp.Length - 1);

                    // Set the Order By
                    WriteComment("Order By " + orderByFieldSet.Name);

                    // Write this line
                    WriteLine(orderBy);
                }
            }
            #endregion

            #region WriteWhereClause(DataField fieldName, ProcedureTypeEnum proceduteType, bool useCustomWhere = false, string whereText = "")
            /// <summary>
            /// This method writes the where clause for the primary key
            /// </summary>
            /// <param name="dataField"></param>
            private void WriteWhereClause(DataField fieldName, ProcedureTypeEnum proceduteType, bool useCustomWhere = false, string whereText = "")
            {
                // get procedure type name
                string procedureTypeName = proceduteType.ToString();

                // if this is a FetchAll
                if (proceduteType == ProcedureTypeEnum.FetchAll)
                {
                    // Write Comment 
                    WriteComment("Load Matching Records");
                }
                else
                {
                    // Write Comment 
                    WriteComment(procedureTypeName + " Matching Record");
                }
             
                // if useCustomWhere is true and the whereText exists and where text starts with the word where
                if ((useCustomWhere) && (TextHelper.Exists(whereText)) && (whereText.ToLower().StartsWith("where")))
                {
                    // write the custom whereText
                    WriteLine(whereText);
                }
                else
                {
                    // Create StringBuilder
                    StringBuilder sb = new StringBuilder("Where [");
                
                    // append field name
                    sb.Append(fieldName.FieldName);
                
                    // Append closing ]
                    sb.Append("] = @");

                    // append field name
                    sb.Append(fieldName.FieldName);

                     // get where clause
                    string whereClause = sb.ToString();
                
                    // write whereClause
                    WriteLine(whereClause);
                }
            } 
            #endregion
        
            #region WriteWhereClause(List<DataField> parameters, ProcedureTypeEnum proceduteType)
            /// <summary>
            /// This method writes the where clause for the primary key
            /// </summary>
            /// <param name="dataField"></param>
            private void WriteWhereClause(List<DataField> parameters, ProcedureTypeEnum proceduteType)
            {
                // locals
                string procedureTypeName = proceduteType.ToString();
                int count = 0;
                bool lastField = false;
                string and = " And ";

                // If the parameters collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(parameters))
                {
                    // if this is a FetchAll
                    if (proceduteType == ProcedureTypeEnum.FetchAll)
                    {
                        // Write Comment 
                        WriteComment("Load Matching Records");
                    }
                    else
                    {
                        // Write Comment 
                        WriteComment(procedureTypeName + " Matching Record");
                    }
             
                    // Create StringBuilder
                    StringBuilder sb = new StringBuilder("Where ");

                    // Iterate the collection of DataField objects
                    foreach (DataField parameter in parameters)
                    {
                        // parameter
                        count++;

                        // set the value for lastField if this is last field
                        lastField = (count == parameters.Count);

                        // Append an open brack
                        sb.Append("[");

                        // append field name
                        sb.Append(parameter.FieldName);
                
                        // Append closing ], equals sign and the @ symbol for this parameter
                        sb.Append("] = @");

                        // append field name
                        sb.Append(parameter.FieldName);

                        // if this is not the last field
                        if (!lastField)
                        {
                            // append the word And with spaces surrounding it
                            sb.Append(and);
                        }
                    }

                    // get where clause
                    string whereClause = sb.ToString();
                
                    // write whereClause
                    WriteLine(whereClause);
                }
            } 
            #endregion

        #endregion

        #region Properties

            #region HasTextWriter
            /// <summary>
            /// This property returns true if this object has a 'TextWriter'.
            /// </summary>
            public bool HasTextWriter
            {
                get
                {
                    // initial value
                    bool hasTextWriter = (this.TextWriter != null);
                    
                    // return value
                    return hasTextWriter;
                }
            }
            #endregion
            
            #region HasWriter
            /// <summary>
            /// This property returns true if this object has a 'Writer'.
            /// </summary>
            public bool HasWriter
            {
                get
                {
                    // initial value
                    bool hasWriter = (this.Writer != null);
                    
                    // return value
                    return hasWriter;
                }
            }
            #endregion
            
            #region Indent
			public int Indent
			{
				get
				{
					return indent;	
				}
				set
				{
					indent = value;
				}
			}
			#endregion

            #region TextWriterMode
            /// <summary>
            /// This property gets or sets the value for 'TextWriterMode'.
            /// </summary>
            public bool TextWriterMode
            {
                get { return textWriterMode; }
                set { textWriterMode = value; }
            }
            #endregion
        
            #region TextWriter
            /// <summary>
            /// This property gets or sets the value for 'TextWriter'.
            /// </summary>
            public StringBuilder TextWriter
            {
                get { return textWriter; }
                set { textWriter = value; }
            }
            #endregion

            #region Writer
            public StreamWriter Writer
            {
                get
                {
                    return writer;
                }
                set
                {
                    writer = value;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion
    
}
