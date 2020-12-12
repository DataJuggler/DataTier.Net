

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using DataJuggler.Net;
using System.Text;
using System.IO;

#endregion

namespace DataTierClient.Builders
{

    #region class DataOperationMethodCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a data operations method.
    /// </summary>
	public class DataOperationMethodCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private string rootDataOperationsPath;
        private string nameSpaceName;
        private ReferencesSet objectReferences;
        #endregion

		#region Constructor
		/// <summary>
        /// Create a new instance of ControllerManagerCreator
        /// </summary>
        public DataOperationMethodCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootDataOperationsPathArg, string nameSpaceNameArg, ProjectFileManager fileManager, bool dotNet5Project) : base(fileManager, false, false, dotNet5Project)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.NameSpaceName = nameSpaceNameArg;
            this.rootDataOperationsPath = rootDataOperationsPathArg;
		    this.ObjectReferences = objectReferencesArg;
		}
		#endregion

        #region Methods

            #region CreateDataOperationMethod(DataTable dataTable)
            /// <summary>
            /// Creates the Controller.
            /// </summary>
            public bool CreateDataOperationMethod(DataTable dataTable)
            {
                // Initial Value
                bool created = false;
                
                // Set Indent To 0
                Indent = 0;

                // file name variable
                string fileName = null;
                
                // verify DataTable exist
                if (dataTable != null)
                {   
                    // Get DataWatcherFileName
                    fileName = CreateFileName(dataTable);
                    
                    // update 7-29-2010: Only if file doesn't exist
                    if (!File.Exists(fileName))
                    {
                        // Create Writer
                        CreateFile(fileName, DataManager.ProjectTypeEnum.ALC);
                        
                        // Write References
                        WriteReferences(this.ObjectReferences);

                        // Write Blank Line
                        WriteLine();
                        
                        // Write NameSpace
                        string nameSpace = "namespace " + this.NameSpaceName;
                        WriteLine(nameSpace);
                        
                        // Write Open Brack
                        WriteOpenBracket(true);
                        
                        // Write Blank Line
                        WriteLine();
                        
                        // Get ClassName
                        string className = dataTable.ClassName + "Methods";
                        
                        // Write Region for this reader
                        BeginRegion("class " + className);

                        // Write Object Reader Summary
                        WriteClassSummary(dataTable);
                        
                        // get class line
                        string classLine = "public class " + className;
                        
                        // Write ClassLine
                        WriteLine(classLine);
                        
                        // Write Open Brack
                        WriteOpenBracket(true);
                        
                        // Write Blank Line
                        WriteLine();
                        
                        // Write The Private Variables Region
                        WritePrivateVariables();

                        // Write Constructor
                        WriteConstructor(dataTable);
                        
                        // Write Methods
                        WriteMethods(dataTable);
                        
                        // Write Properties
                        WriteProperties();
                        
                        // Write Close Bracket
                        WriteCloseBracket(true);
                        
                        // Write EndRegion For Class
                        EndRegion();
                        
                        // Write Blank Line
                        WriteLine();

                        // Write Close Bracket
                        WriteCloseBracket(true);
                        
                        // Close This File
                        this.Writer.Close();
                    }
                }
                
                // if file name is not null 
                if(!String.IsNullOrEmpty(fileName))
                {
                    // if file exists on hard drive
                    if(File.Exists(fileName))
                    {
                        // set created to true
                        created = true;
                    }
                }
                
                // return value
                return created;
            }
            #endregion

            #region CreateDataOperationMethods(List<DataTable> dataTables)
            /// <summary>
            /// Creates the Controller.
            /// </summary>
            public void CreateDataOperationMethods(List<DataTable> dataTables)
            {
                // verify DataTable exist
                if (dataTables != null)
                {
                    // loop through data tables collection
                    foreach (DataTable dataTable in this.DataTables)
                    {
                        // Create DataOperationMethod
                        CreateDataOperationMethod(dataTable);
                    }
                } 
            }
            #endregion
  
            #region CreateExceptionText()
            /// <summary>
            /// Thlis method zcreates the Exception text
            /// </summary>
            /// <returns></returns>
            private string CreateExceptionText()
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("throw new Exception(");
                
                // Append Quote
                sb.Append('"');
                
                // Append "The database connection is not available."
                sb.Append("The database connection is not available.");

                // Append Quote
                sb.Append('"');
                
                // Append )
                sb.Append(");");
                
                // return value
                return sb.ToString();
            }
            #endregion
  
            #region CreateFileName(DataTable dataTable)
            /// <summary>
            /// Create the file name for this reader.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateFileName(DataTable dataTable)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(this.RootDataOperationsPath);
                
                // if does not end in \
                if(!this.RootDataOperationsPath.EndsWith(@"\"))
                {
                    // Append \
                    sb.Append(@"\");
                }

                // Add ClassName
                sb.Append(dataTable.ClassName);

                // Add The Word Methods
                sb.Append("Methods.cs");

                // return value
                return sb.ToString();
            }
            #endregion

            #region GetStringVariableLine(string variableName, string variableValue)
            /// <summary>
            /// /// <summary>
            /// This method creates the line to write a string variable
            /// </summary>
            /// <param name="p"></param>
            /// <returns></returns>
            /// </summary>
            /// <param name="variableName"></param>
            /// <param name="variableValue"></param>
            /// <returns></returns>
            private string GetStringVariableLine(string variableName, string variableValue)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("string ");
                
                // append 
                sb.Append(variableName);
                
                // Append Equals
                sb.Append(" = ");
                
                // Append Quote
                sb.Append('"');
                
                // Append variableValue
                sb.Append(variableValue);

                // Append Quote
                sb.Append('"');
                
                // append ;
                sb.Append(";");
                
                // return value
                return sb.ToString();
            } 
            #endregion

            #region WriteClassSummary(DataTable dataTable)
            /// <summary>
            /// This method writes the summary for a data object method.
            /// </summary>
            /// <param name="dataTable"></z>
            private void WriteClassSummary(DataTable dataTable)
            {
                WriteLine("/// <summary>");
                WriteLine("/// This class contains methods for modifying a '" + dataTable.ClassName + "' object.");
                WriteLine("/// </summary>");
            }
            #endregion

            #region WriteConstructor(DataTable dataTable)
            /// <summary>
            /// This method writes the constructor for this object.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteConstructor(DataTable dataTable)
            {
                // Begin Region Static Methods
                BeginRegion("Constructor");
                
                // Write Constructor Summary
                WriteLine("/// <summary>");
                WriteLine("/// Creates a new Creates a new '" + dataTable.ClassName + "Methods' object.");
                WriteLine("/// </summary>");
                
                // Get Constructor Line
                string constructorLine = "public " + dataTable.ClassName + "Methods(DataManager dataManagerArg)";
                
                // Write constructorLine Line
                WriteLine(constructorLine);

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment SaveArguments
                WriteComment("Save Argument");
                
                // Save Argument For DataManager
                WriteLine("this.DataManager = dataManagerArg;");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write endregion
                EndRegion();;
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteDeleteMethod(DataTable dataTable)
            /// <summary>
            /// Write the Delete method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteDeleteMethod(DataTable dataTable)
            {
                // locals
                string className = dataTable.ClassName;
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string procName = "delete" + dataType + "Proc";

                // Write Blank Line
                WriteLine();
                
                // BeginRegion  #region Delete(<DataType> dataType>
                BeginRegion("Delete" + className + "(" + className + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method deletes a '" + dataTable.ClassName + "' object.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='List<PolymorphicObject>'>The '" + dataTable.ClassName + "' to delete.");
                WriteLine("/// <returns>A PolymorphicObject object with a Boolean value.");
                
                // Get classDeclaration
                string classDeclaration = "internal PolymorphicObject Delete" + dataTable.ClassName + "(List<PolymorphicObject> parameters, DataConnector dataConnector)";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment // locals
                WriteComment("Initial Value");

                // Write Line For Delete
                WriteLine("PolymorphicObject returnObject = new PolymorphicObject();");

                // Write Blank Line
                WriteLine();
 
                // Write Code Here For Performing Data Operation

                // Write Comment If the data connection is connected
                WriteComment("If the data connection is connected");
                
                // Get line to test for data connection
                string ifDataConnected = "if ((dataConnector != null) && (dataConnector.Connected == true))";

                // Write ifDataConnected
                WriteLine(ifDataConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Delete StoredProcedure
                WriteComment("Create Delete StoredProcedure");
                
                // Create Delete Stored Procedure
                string storedProcedureDeclaration = "Delete" + dataTable.ClassName + "StoredProcedure " + procName + " = null;";
                
                // Write deleteProc
                WriteLine(storedProcedureDeclaration);
                
                // Write Blank Line
                WriteLine();

                // Write Comment verify the first parameters is a(n) '"<Object>'.
                WriteComment("verify the first parameters is a(n) '" + dataTable.ClassName + "'.");
                
                // get verify line
                string verifyParameter = "if (parameters[0].ObjectValue as " + dataTable.ClassName + " != null)";

                // write verifyParameter
                WriteLine(verifyParameter);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment Create Object
                WriteComment("Create " + dataTable.ClassName);
                
                // create data object from parameters[0]
                string setObjectParameter = dataType + " " + this.CapitalizeFirstChar(dataType, true) + " = (" + dataType + ") parameters[0].ObjectValue;";

                // Write setObjectParameter
                WriteLine(setObjectParameter);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment verify data object exists
                WriteComment("verify " + dataObject + " exists");
                
                // get line to verify data object exists
                string ifExists = "if(" + dataObject + " != null)";
                
                // Write ifExists line
                WriteLine(ifExists);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comments For Creating Proc
                WriteComment("Now create delete" + className + "Proc from " + className + "Writer");
                WriteComment("The DataWriter converts the '" + dataType + "'");
                WriteComment("to the SqlParameter[] array needed to delete a '" + dataType + "'.");
                
                // Create Proc
                string procLine = procName + " = " + className + "Writer.CreateDelete" + className + "StoredProcedure(" + dataObject + ");";
                
                // Write procLine
                WriteLine(procLine);
                
                 // Write Close Bracket
                WriteCloseBracket(true);
                
                 // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Verify proc exists
                WriteComment("Verify " + procName + " exists");
                
                // get line for if procedure exists
                string ifProcExists = "if(" + procName + " != null)";
                
                // Write ifProcExists
                WriteLine(ifProcExists);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment  Execute Delete Stored Procedure
                WriteComment("Execute Delete Stored Procedure");
                
                // get line to execute proc
                string executeProc = "bool deleted = this.DataManager." + className + "Manager.Delete" + className + "(" + procName + ", dataConnector);";
                
                // Write line to execute proc
                WriteLine(executeProc);
                
                // Write blank line
                WriteLine();
                
                // Write comment  Create returnObject.Boolean
                WriteComment("Create returnObject.Boolean");
                
                // get line to create return object
                string createReturnObject = "returnObject.Boolean = new NullableBoolean();";

                // Write createReturnObject
                WriteLine(createReturnObject);
                
                // Write Blank line
                WriteLine();
                
                // Write comment if delete was successful
                WriteComment("If delete was successful");
                
                // Write line to test if deleted
                WriteLine("if(deleted)");
                
                // Write OpenBracket
                WriteOpenBracket(true);
                
                // Write Comment Set returnObject.Boolean.Value to true
                WriteComment("Set returnObject.Boolean.Value to true");
                
                // now set the value to true
                WriteLine("returnObject.Boolean.Value = NullableBooleanEnum.True;");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write else
                WriteLine("else");
                
                // Write OpenBracket
                WriteOpenBracket(true);

                // Write Comment Set returnObject.Boolean.Value to false
                WriteComment("Set returnObject.Boolean.Value to false");
                
                 // now set the value to false
                WriteLine("returnObject.Boolean.Value = NullableBooleanEnum.False;");
                
                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write CloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write else
                WriteLine("else");
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Raise Error DataConnect Not Available
                WriteComment("Raise Error Data Connection Not Available");
                
                // now raise the error
                // get exception text
                string exceptionText = CreateExceptionText();
                WriteLine(exceptionText);
                
                // WriteCloseBracket
                WriteCloseBracket(true);
                 
                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return value;
                WriteLine("return returnObject;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Wrie EndRegion
                EndRegion();
            }
            #endregion

            #region WriteFetchAllMethod(DataTable dataTable)
            /// <summary>
            /// Write the FetchAll method
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteFetchAllMethod(DataTable dataTable)
            {
                // locals
                string className = dataTable.ClassName;
                string dataType = dataTable.ClassName;
                string collectionDataType = "List<" + dataType + ">";
                string variableName = dataType + "List";
                string dataObject = this.CapitalizeFirstChar(variableName, true);
                string dataObjectCollection = dataObject + "Collection";
                string procName = "fetchAllProc";
                string procClassName = null;
                
                // get the correct plural of the word;
                className = PluralWordHelper.GetPluralName(className, false);
                procClassName = "FetchAll" + className + "StoredProcedure";
                                
                // BeginRegion  #region Delete(<DataType> dataType>
                BeginRegion("FetchAll()");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method fetches all '" + dataType + "' objects.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='List<PolymorphicObject>'>The '" + dataTable.ClassName + "' to delete.");
                WriteLine("/// <returns>A PolymorphicObject object with all  '" + className + "' objects.");
                
                // Get classDeclaration
                string classDeclaration = "internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment // locals
                WriteComment("Initial Value");

                // Write Line For FetchAll
                WriteLine("PolymorphicObject returnObject = new PolymorphicObject();");

                // Write Blank Line
                WriteLine();

                // variables for logging an error if it occurs
                WriteComment("locals");
                
                // local for data object collection
                WriteLine(collectionDataType + " " + dataObjectCollection + " =  null;");
                
                // Write Blank Line
                WriteLine();

                // Write Comment Create FetchAll StoredProcedure
                WriteComment("Create FetchAll StoredProcedure");

                // Create FetchAll Stored Procedure
                string storedProcedureDeclaration = procClassName + " " + procName + " = null;";

                // Write deleteProc
                WriteLine(storedProcedureDeclaration);

                // Write Blank Line
                WriteLine();

                // Write Comment If the data connection is connected
                WriteComment("If the data connection is connected");
                
                // Get line to test for data connection
                string ifDataConnected = "if ((dataConnector != null) && (dataConnector.Connected == true))";

                // Write ifDataConnected
                WriteLine(ifDataConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Object
                WriteComment("Get " + dataType + "Parameter");

                // Write Comment Declare parameter
                WriteComment("Declare Parameter");
                
                // Now get line to declare parameter
                string paramVariable = "param" + dataType;
                string initialValue = dataType + " " + paramVariable + " = null;";
                
                // Write initialValue
                WriteLine(initialValue);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment verify the first parameters is a(n) '"<Object>'.
                WriteComment("verify the first parameters is a(n) '" + dataTable.ClassName + "'.");

                // get verify line
                string verifyParameter = "if (parameters[0].ObjectValue as " + dataTable.ClassName + " != null)";

                // write verifyParameter
                WriteLine(verifyParameter);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Parameter
                WriteComment("Get " + dataType + "Parameter");

                // create data object from parameters[0]
                string setObjectParameter = paramVariable + " = (" + dataType + ") parameters[0].ObjectValue;";

                // Write setObjectParameter
                WriteLine(setObjectParameter);

                // Update 5.7.2014: Took out the extra line that has been bugging me for 4 years
                
                // Write Close Bracket
                WriteCloseBracket(true);

                // Update 5.7.2014: Add the line here after the close bracket
                WriteLine();

                // Write Comments For FetchAll Proc
                WriteComment("Now create FetchAll" + className + "Proc from " + dataTable.ClassName + "Writer");
                
                // Create Proc
                string procLine = procName + " = " + dataTable.ClassName + "Writer.CreateFetchAll" + className + "StoredProcedure(" + paramVariable + ");";
                
                // Write procLine
                WriteLine(procLine);
                
                 // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Verify proc exists
                WriteComment("Verify " + procName + " exists");
                
                // get line for if procedure exists
                string ifProcExists = "if(" + procName + "!= null)";
                
                // Write ifProcExists
                WriteLine(ifProcExists);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment  Execute FetchAll Stored Procedure
                WriteComment("Execute FetchAll Stored Procedure");
                
                // get line to execute proc
                string executeProc = dataObjectCollection + " = this.DataManager." + dataTable.ClassName + "Manager.FetchAll" + className + "(" + procName + ", dataConnector);";
                
                // Write line to execute proc
                WriteLine(executeProc);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment if dataObject exists
                WriteComment("if dataObjectCollection exists");
                
                // get line to test if dataObject exists
                string ifObjectExists = "if(" + dataObjectCollection + " != null)";
                
                // Write ifObjectExists
                WriteLine(ifObjectExists);
                
                // Write Open Bracket
                WriteOpenBracket(true);

                // Write comment set returnObject.ObjectValue
                WriteComment("set returnObject.ObjectValue");
                
                // get line to set return object
                WriteLine("returnObject.ObjectValue = " + dataObjectCollection + ";");

                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write else
                WriteLine("else");
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Raise Error DataConnect Not Available
                WriteComment("Raise Error Data Connection Not Available");
                
                // now raise the error
                // get exception text
                string exceptionText = CreateExceptionText();
                WriteLine(exceptionText);
                
                // WriteCloseBracket
                WriteCloseBracket(true);
                
                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return value;
                WriteLine("return returnObject;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Wrie EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            } 
            #endregion

            #region WriteFindMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the Find method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteFindMethod(DataTable dataTable)
            {
                // locals
                string className = dataTable.ClassName;
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string procName = "find" + dataType + "Proc";

                // BeginRegion  #region Find(<DataType> dataType>
                BeginRegion("Find" + className + "(" + className + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method finds a '" + dataTable.ClassName + "' object.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='List<PolymorphicObject>'>The '" + dataTable.ClassName + "' to delete.");
                WriteLine("/// <returns>A PolymorphicObject object with a Boolean value.");

                // Get classDeclaration
                string classDeclaration = "internal PolymorphicObject Find" + dataTable.ClassName + "(List<PolymorphicObject> parameters, DataConnector dataConnector)";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Value");

                // Write Line For Find
                WriteLine("PolymorphicObject returnObject = new PolymorphicObject();");

                // Write Blank Line
                WriteLine();
                
                // variables for logging an error if it occurs
                WriteComment("locals");
                
                // Create dataObject
                string dataObjectLine = dataType + " " + dataObject + " = null;";
                
                // Write dataObjectLine
                WriteLine(dataObjectLine);
                
                // Write Blank Line
                WriteLine();

                // Write Comment If the data connection is connected
                WriteComment("If the data connection is connected");

                // Get line to test for data connection
                string ifDataConnected = "if ((dataConnector != null) && (dataConnector.Connected == true))";

                // Write ifDataConnected
                WriteLine(ifDataConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Find StoredProcedure
                WriteComment("Create Find StoredProcedure");

                // Create Find Stored Procedure
                string storedProcedureDeclaration = "Find" + dataTable.ClassName + "StoredProcedure " + procName + " = null;";

                // Write deleteProc
                WriteLine(storedProcedureDeclaration);

                // Write Blank Line
                WriteLine();

                // Write Comment verify the first parameters is a(n) '"<Object>'.
                WriteComment("verify the first parameters is a '" + dataTable.ClassName + "'.");

                // get verify line
                string verifyParameter = "if (parameters[0].ObjectValue as " + dataTable.ClassName + " != null)";

                // write verifyParameter
                WriteLine(verifyParameter);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Parameter
                WriteComment("Get " + dataType + "Parameter");

                // create data object from parameters[0]
                string paramVariable = "param" + dataType;
                string setObjectParameter = dataType + " " + paramVariable + " = (" + dataType + ") parameters[0].ObjectValue;";

                // Write setObjectParameter
                WriteLine(setObjectParameter);

                // Write Blank Line
                WriteLine();

                // Write Comment verify data object exists
                WriteComment("verify " + paramVariable + " exists");

                // get line to verify data object exists
                string ifExists = "if(" + paramVariable + " != null)";

                // Write ifExists line
                WriteLine(ifExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comments For Creating Proc
                WriteComment("Now create find" + className + "Proc from " + className + "Writer");
                WriteComment("The DataWriter converts the '" + dataType + "'");
                WriteComment("to the SqlParameter[] array needed to find a '" + dataType + "'.");

                // Create Proc
                string procLine = procName + " = " + dataTable.ClassName + "Writer.CreateFind" + dataTable.ClassName + "StoredProcedure(" + paramVariable + ");";

                // Write procLine
                WriteLine(procLine);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Verify proc exists
                WriteComment("Verify " + procName + " exists");

                // get line for if procedure exists
                string ifProcExists = "if(" + procName + " != null)";

                // Write ifProcExists
                WriteLine(ifProcExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  Execute Find Stored Procedure
                WriteComment("Execute Find Stored Procedure");

                // get line to create return object
                string createReturnObject = dataObject + " = this.DataManager." + dataTable.ClassName + "Manager.Find" + className + "(" + procName + ", dataConnector);";

                // Write createReturnObject
                WriteLine(createReturnObject);

                // Write Blank Line
                WriteLine();

                // Write Comment if dataObject exists
                WriteComment("if dataObject exists");

                // get line to test if dataObject exists
                string ifObjectExists = "if(" + dataObject + " != null)";

                // Write ifObjectExists
                WriteLine(ifObjectExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write comment set returnObject.ObjectValue
                WriteComment("set returnObject.ObjectValue");

                // get line to set return object
                WriteLine("returnObject.ObjectValue = " + dataObject + ";");

                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write CloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write else
                WriteLine("else");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Raise Error DataConnect Not Available
                WriteComment("Raise Error Data Connection Not Available");

                // now raise the error
                // get exception text
                string exceptionText = CreateExceptionText();
                WriteLine(exceptionText);

                // WriteCloseBracket
                WriteCloseBracket(true);

                // WriteCloseBracket
                WriteCloseBracket(true);
                
                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return value;
                WriteLine("return returnObject;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Wrie EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteInsertMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the Insert method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteInsertMethod(DataTable dataTable)
            {
                // locals
                string className = dataTable.ClassName;
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataTable.ClassName, true);
                string procName = "insert" + dataType + "Proc";

                // BeginRegion  #region Insert(<DataType> dataType>
                BeginRegion("Insert" + className + " (" + className + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method inserts a '" + dataTable.ClassName + "' object.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='List<PolymorphicObject>'>The '" + dataTable.ClassName + "' to insert.");
                WriteLine("/// <returns>A PolymorphicObject object with a Boolean value.");

                // Get classDeclaration
                string classDeclaration = "internal PolymorphicObject Insert" + dataTable.ClassName + "(List<PolymorphicObject> parameters, DataConnector dataConnector)";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment // locals
                WriteComment("Initial Value");

                // Write Line For Insert
                WriteLine("PolymorphicObject returnObject = new PolymorphicObject();");

                // Write Blank Line
                WriteLine();

                // variables for logging an error if it occurs
                WriteComment("locals");

                // Create dataObject
                string dataObjectLine = dataType + " " + dataObject + " = null;";

                // Write dataObjectLine
                WriteLine(dataObjectLine);

                // Write Blank Line
                WriteLine();

                // Write Comment If the data connection is connected
                WriteComment("If the data connection is connected");

                // Get line to test for data connection
                string ifDataConnected = "if ((dataConnector != null) && (dataConnector.Connected == true))";

                // Write ifDataConnected
                WriteLine(ifDataConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Insert StoredProcedure
                WriteComment("Create Insert StoredProcedure");

                // Create Insert Stored Procedure
                string storedProcedureDeclaration = "Insert" + dataTable.ClassName + "StoredProcedure " + procName + " = null;";

                // Write deleteProc
                WriteLine(storedProcedureDeclaration);

                // Write Blank Line
                WriteLine();

                // Write Comment verify the first parameters is a(n) '"<Object>'.
                WriteComment("verify the first parameters is a(n) '" + dataTable.ClassName + "'.");

                // get verify line
                string verifyParameter = "if (parameters[0].ObjectValue as " + dataTable.ClassName + " != null)";

                // write verifyParameter
                WriteLine(verifyParameter);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Parameter
                WriteComment("Create " + dataTable.ClassName + " Parameter");

                // create data object from parameters[0]
                string setObjectParameter = dataObject + " = (" + dataType + ") parameters[0].ObjectValue;";

                // Write setObjectParameter
                WriteLine(setObjectParameter);

                // Write Blank Line
                WriteLine();

                // Write Comment verify data object exists
                WriteComment("verify " + dataObject + " exists");

                // get line to verify data object exists
                string ifExists = "if(" + dataObject + " != null)";

                // Write ifExists line
                WriteLine(ifExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comments For Creating Proc
                WriteComment("Now create insert" + className + "Proc from " + className + "Writer");
                WriteComment("The DataWriter converts the '" + dataType + "'");
                WriteComment("to the SqlParameter[] array needed to insert a '" + dataType + "'.");

                // Create Proc
                string procLine = procName + " = " + className + "Writer.CreateInsert" + className + "StoredProcedure(" + dataObject + ");";

                // Write procLine
                WriteLine(procLine);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Verify proc exists
                WriteComment("Verify " + procName + " exists");

                // get line for if procedure exists
                string ifProcExists = "if(" + procName + " != null)";

                // Write ifProcExists
                WriteLine(ifProcExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  Execute Insert Stored Procedure
                WriteComment("Execute Insert Stored Procedure");

                // get line to execute proc
                string executeProc = "returnObject.IntegerValue = this.DataManager." + className + "Manager.Insert" + className + "(" + procName + ", dataConnector);";

                // Write line to execute proc
                WriteLine(executeProc);

                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write blank line
                WriteLine();

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write else
                WriteLine("else");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Raise Error DataConnect Not Available
                WriteComment("Raise Error Data Connection Not Available");

                // now raise the error
                // get exception text
                string exceptionText = CreateExceptionText();
                WriteLine(exceptionText);

                // WriteCloseBracket
                WriteCloseBracket(true);

                // WriteCloseBracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return value;
                WriteLine("return returnObject;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Wrie EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            } 
            #endregion
          
            #region WriteMethods()
            /// <summary>
            /// Write the methods region and the Init method.
            /// </summary>
            private void WriteMethods(DataTable dataTable)
            {
                if (dataTable != null)
                {
                    // Begin Region For Methods
                    BeginRegion("Methods");

                    // Increase Indent
                    Indent++;

                    // If this table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Write Delete Method
                        WriteDeleteMethod(dataTable);
                    }

                    // Write Blank Line
                    WriteLine();

                    // Write FetchAllMethod
                    WriteFetchAllMethod(dataTable);

                    // If this table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Write FindMethod
                        WriteFindMethod(dataTable);
                    }

                    // if the dataTable is not a view
                    if(!dataTable.IsView)
                    {
                        // Write Insert Method
                        WriteInsertMethod(dataTable);
                    }

                    // If this table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        /// Write Update Method
                        WriteUpdateMethod(dataTable);
                    }

                    // Decrease Indent
                    Indent--;

                    // End Region 
                    EndRegion();

                    // Write Blank Line
                    WriteLine();
                }
            }
            #endregion

            #region WritePrivateVariables()
            /// <summary>
            /// This method writes the private variables for a 
            /// ControllerManager.
            /// </summary>
            private void WritePrivateVariables()
            {
                // Begin Region Static Methods
                BeginRegion("Private Variables");

                // Write DataManager
                WriteLine("private DataManager dataManager;");
                
                // Write line
                EndRegion();;
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteProperty()
            /// <summary>
            /// This method writes a property for the
            /// property name, variable name, and datatype 
            /// given.
            /// </summary>
            private void WriteProperty(string propertyName, string variableName, string dataType)
            {
                // Write Blank Line
                WriteLine();
                
                // Begin Region
                BeginRegion(propertyName);
                
                // get property line
                string propertyLine = "public " + dataType + " " + propertyName;
                
                // Write Property Line
                WriteLine(propertyLine);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // creaete the get for the property
                string getProperty = "get { return " + variableName + "; }";
                
                // Write getProperty
                WriteLine(getProperty);
                
                // Create the setter for this property
                string setProperty = "set { " + variableName + " = value; }";
                
                // Write setProperty
                WriteLine(setProperty);
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write end region
                EndRegion();
            }
            #endregion

            #region WriteProperties()
            /// <summary>
            /// This method writes the properties for each
            /// DataController and the ErrorProcessor and
            /// DataManager objects.
            /// </summary>
            private void WriteProperties()
            {
                // Write Region For Properties
                BeginRegion("Properties");
                
                // Increase Indent
                Indent++;
                
                // Write Property For AppController
                WriteProperty("DataManager ", "dataManager", "DataManager");
                
                // Write Blank Line After last Property
                WriteLine();
                
                // Decrease Indent
                Indent--;
                
                // End Properties Region
                EndRegion();

                // Write Blank Line After Properties Region
                WriteLine();
            } 
            #endregion

            #region WriteUpdateMethod(DataTable dataTable)
            /// <summary>
            /// Write UpdateMethod
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteUpdateMethod(DataTable dataTable)
            {
                // locals
                string className = dataTable.ClassName;
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataTable.ClassName, true);
                string procName = "update" + dataType + "Proc";

                // BeginRegion  #region Update(<DataType> dataType>
                BeginRegion("Update" + className + " (" + className + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method updates a '" + dataTable.ClassName + "' object.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='List<PolymorphicObject>'>The '" + dataTable.ClassName + "' to update.");
                WriteLine("/// <returns>A PolymorphicObject object with a value.");

                // Get classDeclaration
                string classDeclaration = "internal PolymorphicObject Update" + dataTable.ClassName + "(List<PolymorphicObject> parameters, DataConnector dataConnector)";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment // locals
                WriteComment("Initial Value");

                // Write Line For Update
                WriteLine("PolymorphicObject returnObject = new PolymorphicObject();");

                // Write Blank Line
                WriteLine();

                // variables for logging an error if it occurs
                WriteComment("locals");

                // Create dataObject
                string dataObjectLine = dataType + " " + dataObject + " = null;";

                // Write dataObjectLine
                WriteLine(dataObjectLine);

                // Write Blank Line
                WriteLine();

                // Write Comment If the data connection is connected
                WriteComment("If the data connection is connected");

                // Get line to test for data connection
                string ifDataConnected = "if ((dataConnector != null) && (dataConnector.Connected == true))";

                // Write ifDataConnected
                WriteLine(ifDataConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Update StoredProcedure
                WriteComment("Create Update StoredProcedure");

                // Create Update Stored Procedure
                string storedProcedureDeclaration = "Update" + dataTable.ClassName + "StoredProcedure " + procName + " = null;";

                // Write deleteProc
                WriteLine(storedProcedureDeclaration);

                // Write Blank Line
                WriteLine();

                // Write Comment verify the first parameters is a(n) '"<Object>'.
                WriteComment("verify the first parameters is a(n) '" + dataTable.ClassName + "'.");

                // get verify line
                string verifyParameter = "if (parameters[0].ObjectValue as " + dataTable.ClassName + " != null)";

                // write verifyParameter
                WriteLine(verifyParameter);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Paremter
                WriteComment("Create " + dataTable.ClassName + " Parameter");

                // create data object from parameters[0]
                string setObjectParameter = dataObject + " = (" + dataType + ") parameters[0].ObjectValue;";

                // Write setObjectParameter
                WriteLine(setObjectParameter);

                // Write Blank Line
                WriteLine();

                // Write Comment verify data object exists
                WriteComment("verify " + dataObject + " exists");

                // get line to verify data object exists
                string ifExists = "if(" + dataObject + " != null)";

                // Write ifExists line
                WriteLine(ifExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comments For Creating Proc
                WriteComment("Now create update" + className + "Proc from " + className + "Writer");
                WriteComment("The DataWriter converts the '" + dataType + "'");
                WriteComment("to the SqlParameter[] array needed to update a '" + dataType + "'.");

                // Create Proc
                string procLine = procName + " = " + className + "Writer.CreateUpdate" + className + "StoredProcedure(" + dataObject + ");";

                // Write procLine
                WriteLine(procLine);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Verify proc exists
                WriteComment("Verify " + procName + " exists");

                // get line for if procedure exists
                string ifProcExists = "if(" + procName + " != null)";

                // Write ifProcExists
                WriteLine(ifProcExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  Execute Update Stored Procedure
                WriteComment("Execute Update Stored Procedure");

                // get line to execute proc
                string executeProc = "bool saved = this.DataManager." + className + "Manager.Update" + className + "(" + procName + ", dataConnector);";

                // Write line to execute proc
                WriteLine(executeProc);

                // Write blank line
                WriteLine();

                // Write comment  Create returnObject.Boolean
                WriteComment("Create returnObject.Boolean");

                // get line to create return object
                string createReturnObject = "returnObject.Boolean = new NullableBoolean();";

                // Write createReturnObject
                WriteLine(createReturnObject);

                // Write Blank line
                WriteLine();

                // Write comment if deleted was successful
                WriteComment("If save was successful");

                // Write line to test if saved
                WriteLine("if(saved)");

                // Write OpenBracket
                WriteOpenBracket(true);

                // Write Comment Set returnObject.Boolean.Value to true
                WriteComment("Set returnObject.Boolean.Value to true");

                // now set the value to true
                WriteLine("returnObject.Boolean.Value = NullableBooleanEnum.True;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write else
                WriteLine("else");

                // Write OpenBracket
                WriteOpenBracket(true);

                // Write Comment Set returnObject.Boolean.Value to false
                WriteComment("Set returnObject.Boolean.Value to false");

                // now set the value to false
                WriteLine("returnObject.Boolean.Value = NullableBooleanEnum.False;");

                // Write CloseBracket
                WriteCloseBracket(true);                

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write else
                WriteLine("else");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Raise Error DataConnect Not Available
                WriteComment("Raise Error Data Connection Not Available");

                // now raise the error
                // get exception text
                string exceptionText = CreateExceptionText();
                WriteLine(exceptionText);

                // WriteCloseBracket
                WriteCloseBracket(true);

                // WriteCloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return value;
                WriteLine("return returnObject;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Wrie EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion
        
        #endregion			
	
		#region Properties

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
            /// The references set to use for this class
            /// </summary>
            public ReferencesSet ObjectReferences
            {
                get { return objectReferences; }
                set { objectReferences = value; }
            }
            #endregion

            #region RootDataOperationsPath
            /// <summary>
            /// The root path to create the file in.
            /// </summary>
            public string RootDataOperationsPath
            {
                get { return rootDataOperationsPath; }
                set { rootDataOperationsPath = value; }
            } 
            #endregion
    		
		#endregion

	}
	#endregion	
	
}
