

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using System;
using DataJuggler.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using DataTierClient.ClientUtil;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{

    #region class ObjectManagerCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create the ObjectManager Classes
    /// </summary>
	public class ObjectManagerCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private string rootDataManagerPath;
        private string nameSpaceName;
        private ReferencesSet objectReferences;
        #endregion

		#region Constructor
		/// <summary>
        /// Create a new instance of ControllerManagerCreator
        /// </summary>
        public ObjectManagerCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootDataManagerPathArg, string nameSpaceNameArg, ProjectFileManager fileManager, TargetFrameworkEnum targetFramework) : base(fileManager, false, false, targetFramework)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.NameSpaceName = nameSpaceNameArg;
            this.RootDataManagerPath = rootDataManagerPathArg;
		    this.ObjectReferences = objectReferencesArg;
		}
		#endregion

        #region Methods

            #region CreateDataManager(DataTable dataTable)
            /// <summary>
            /// This method creates a DataManager for this table.
            /// </summary>
            /// <param name="dataTable">The table to create the DataManager for.</param>
            private void CreateDataManager(DataTable dataTable)
            {
                // Indent = 0
                Indent = 0;

                // Get the file name to see if it already exists
                string fileName = CreateFileName(dataTable);

                // Only create if the file does not already exist
                if (!File.Exists(fileName))
                {
                    // Create file
                    CreateFile(fileName, DataManager.ProjectTypeEnum.DAC);

                    // Write References
                    WriteReferences(this.ObjectReferences);

                    // Write Blank Line
                    WriteLine();

                    // Write namespace
                    string nameSpace = "namespace " + this.NameSpaceName;
                    WriteLine(nameSpace);

                    // Write Open Brack
                    WriteOpenBracket(true);

                    // Write Blank Line
                    WriteLine();

                    // Get ClassName
                    string className = dataTable.ClassName + "Manager";

                    // Write Region for this reader
                    BeginRegion("class " + className);

                    // Write Object Reader Summary
                    WriteClassSummary(dataTable);

                    // get class line
                    string classLine = "public class " + className;

                    // Write class line
                    WriteLine(classLine);

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Blank Line
                    WriteLine();

                    // Write Private Variables
                    WritePrivateVariables(dataTable);

                    // Write Constructor
                    WriteConstructor(dataTable);

                    // Write Methods
                    WriteMethods(dataTable);

                    // Write Properties
                    WriteProperties(dataTable);

                    // write Close Bracket
                    WriteCloseBracket(true);

                    // Write endregion
                    EndRegion();

                    // Write Blank Line
                    WriteLine();

                    // write Close Bracket
                    WriteCloseBracket(true);

                    // Close This File
                    this.Writer.Close();
                }
            } 
            #endregion

            #region CreateObjectManagers(List<DataTable> dataTables)
            /// <summary>
            /// Creates All The ObjectManager Objects.
            /// </summary>
            public void CreateObjectManagers(List<DataTable> dataTables)
            {   
                // Set Indent To 0
                Indent = 0;
                
                // verify DataTable exist
                if (dataTables != null)
                {   
                    // Create the DataManager object for each table
                    foreach(DataTable dataTable in this.DataTables)
                    {
                        // Create Data Object Manager for this table
                        CreateDataManager(dataTable);
                    }
                }
            }
            #endregion

            #region CreateDeleteMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the Delete method.
            /// for a data table.
            /// </summary>
            private void CreateDeleteMethod(DataTable dataTable)
            {   
                // Write Blank line
                WriteLine();
                
                // Begin Region 
                BeginRegion("Delete" + dataTable.ClassName + "()");
                
                // Write Delete Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method deletes a '" + dataTable.ClassName + "' object.");
                WriteLine("/// </summary>");
                WriteLine("/// <returns>True if successful false if not.</returns>");
                WriteLine("/// </summary>");
                
                // get class declaration line
                string classLine = "public static bool Delete#Object#(Delete#Object#StoredProcedure delete#Object#Proc, DataConnector databaseConnector)";
                classLine = classLine.Replace("#Object#", dataTable.ClassName);
                
                // Write class line
                WriteLine(classLine);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment
                WriteComment("Initial Value");
                
                // Write line to set initial value
                WriteLine("bool deleted = false;");
                
                // Write Blank Line
                WriteLine();

                // Write Comment  Verify database connection is connected
                WriteComment("Verify database connection is connected");
                                
                // get line to test connection
                string ifConnected = "if ((databaseConnector != null) && (databaseConnector.Connected))";
                
                // Write ifConnected
                WriteLine(ifConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Execute Non Query
                WriteComment("Execute Non Query");
                
                // get line to execute delete
                string deleteLine = "deleted = DataHelper.DeleteRecord(delete" + dataTable.ClassName + "Proc, databaseConnector);";
                
                // Write deleteLine
                WriteLine(deleteLine);

                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Return Value
                WriteComment("return value");
                
                // Write Return Value
                WriteLine("return deleted;");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write EndRegion for DeleteMethod
                EndRegion();
            }
            #endregion

            #region CreateFetchAllMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the FetchAll proc for a DataTabe
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="nameSpace"></param>
            private void CreateFetchAllMethod(DataTable dataTable)
            {   
                // get dataType variable
                string dataType = "List<" + dataTable.ClassName + ">";

                // local
                string variableName = dataTable.ClassName + "Collection";

                // create the name for the data object (must be set before the conflict is fixed)
                string dataObject = this.CapitalizeFirstChar(variableName, true);
                
                // if there is a conflict with this name
                if (ConflictHelper.CheckForConflict(dataTable.ClassName))
                {
                    // fix the conflict
                    dataType = ConflictHelper.ResolveConflict(dataType, dataTable.ObjectNameSpaceName);
                }
                
                // get a variable for className
                string className = PluralWordHelper.GetPluralName(dataTable.ClassName, false);
                
                // local
                string queryType = "procedure";
                
                // get procName & procType
                string procName = "fetchAll" + className + "Proc";
                string procType = "FetchAll" + className + "StoredProcedure";

                // Write Blank Line
                WriteLine();

                // Begin Region 
                BeginRegion("FetchAll" + className + "()");

                // Write FetchAll Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method fetches a  '" + dataType + "' object.");
                WriteLine("/// This method uses the '" + className + "_FetchAll' " + queryType + ".");
                WriteLine("/// </summary>");
                WriteLine("/// <returns>A '" + dataType + "'</returns>");
                WriteLine("/// </summary>");

                // get class declaration line
                string classLine = "public static " + dataType + " FetchAll" + className + "(" + procType + " " + procName + ", DataConnector databaseConnector)";
                
                // Write class line
                WriteLine(classLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Value");
                
                // Write line to set initial value
                string initialValue = dataType + " " + dataObject + " = null;";
                WriteLine(initialValue);

                // Write Blank Line
                WriteLine();

                // Write Comment  Verify database connection is connected
                WriteComment("Verify database connection is connected");

                // get line to test connection
                string ifConnected = "if ((databaseConnector != null) && (databaseConnector.Connected))";

                // Write ifConnected
                WriteLine(ifConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment First Get Dataset
                WriteComment("First Get Dataset");

                // get line to get data set
                string dataSetName = "all" + className + "DataSet";
                string dataSetLine = "DataSet " + dataSetName + " = DataHelper.LoadDataSet(" + procName + ", databaseConnector);";
                
                // Write set dataSetLine
                WriteLine(dataSetLine);

                // Write Blank Line
                WriteLine();
                
                // Write Comment Verify DataSet Exists
                WriteComment("Verify DataSet Exists");
                
                // line to test if DataSet exists
                string ifDataSetExists = "if(" + dataSetName + " != null)";
                WriteLine(ifDataSetExists);
                
                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Get DataTable From DataSet
                WriteComment("Get DataTable From DataSet");
                
                // get line to get first table out of data set
                string dataTableLine = "DataTable table = DataHelper.ReturnFirstTable(" + dataSetName + ");";
                WriteLine(dataTableLine);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment if table exists
                WriteComment("if table exists");
                
                // now write line to test if table exists
                WriteLine("if(table != null)");
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment Load Collection
                WriteComment("Load Collection");
                
                // get reader name
                string readerName = dataTable.ClassName + "Reader";
                
                // get line to load collection
                string loadCollection = dataObject + " = " + readerName + ".LoadCollection(table);" ;
                
                // Write loadCollection
                WriteLine(loadCollection);
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // WRite Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Return Value
                WriteComment("return value");

                // Write Return Value
                WriteLine("return " + dataObject + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion for DeleteMethod
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region CreateFindMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the Find stored procedure object
            /// for a DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateFindMethod(DataTable dataTable)
            { 
                // get dataType variable
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);

                // get a variable for className
                string className = dataTable.ClassName;
                
                // set queryType
                string queryType = "procedure";
                
                // get procName & procType
                string procName = "find" + className + "Proc";
                string procType = "Find" + className + "StoredProcedure";

                // Begin Region 
                BeginRegion("Find" + className + "()");

                // Write FetchAll Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method finds a  '" + dataType + "' object.");
                WriteLine("/// This method uses the '" + dataTable.ClassName + "_Find' " + queryType + ".");
                WriteLine("/// </summary>");
                WriteLine("/// <returns>A '" + dataType + "' object.</returns>");
                WriteLine("/// </summary>");

                // get class declaration line
                string classLine = "public static " + dataType + " Find" + className + "(" + procType +" " +  procName + ", DataConnector databaseConnector)";

                // Write class line
                WriteLine(classLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Value");

                // Write line to set initial value
                string initialValue = dataType + " " + dataObject + " = null;";
                WriteLine(initialValue);

                // Write Blank Line
                WriteLine();

                // Write Comment  Verify database connection is connected
                WriteComment("Verify database connection is connected");

                // get line to test connection
                string ifConnected = "if ((databaseConnector != null) && (databaseConnector.Connected))";

                // Write ifConnected
                WriteLine(ifConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment First Get Dataset
                WriteComment("First Get Dataset");

                // get line to get data set
                string dataSetName = this.CapitalizeFirstChar(className, true) + "DataSet";
                string dataSetLine = "DataSet " + dataSetName + " = DataHelper.LoadDataSet(" + procName + ", databaseConnector);";

                // Write set dataSetLine
                WriteLine(dataSetLine);

                // Write Blank Line
                WriteLine();

                // Write Comment Verify DataSet Exists
                WriteComment("Verify DataSet Exists");

                // line to test if DataSet exists
                string ifDataSetExists = "if(" + dataSetName + " != null)";
                WriteLine(ifDataSetExists);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Get DataTable From DataSet
                WriteComment("Get DataTable From DataSet");

                // get line to get first table out of data set
                string dataRowLine = "DataRow row = DataHelper.ReturnFirstRow(" + dataSetName + ");";
                WriteLine(dataRowLine);

                // Write Blank Line
                WriteLine();

                // Write Comment if row exists
                WriteComment("if row exists");

                // now write line to test if row exists
                WriteLine("if(row != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Load Collection
                WriteComment("Load " + dataType);

                // get reader name
                string readerName = dataTable.ClassName + "Reader";

                // get line to load object
                string loadObject = dataObject + " = " + readerName + ".Load(row);";

                // Write load Object
                WriteLine(loadObject);

                // Write Close Bracket
                WriteCloseBracket(true);

                // WRite Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Return Value
                WriteComment("return value");

                // Write Return Value
                WriteLine("return " + dataObject + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion for DeleteMethod
                EndRegion();

                // Write Blank Line
                WriteLine();
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
                StringBuilder sb = new StringBuilder(this.RootDataManagerPath);
                
                // If does not end with a backslash \
                if(!this.RootDataManagerPath.EndsWith(@"\"))
                {
                    // Append Backslash \
                    sb.Append(@"\");
                }
                
                // Apend the class name
                sb.Append(dataTable.ClassName);
                
                // Add The Word Manager.cs
                sb.Append("Manager.cs");

                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateInsertMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the insert proc
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateInsertMethod(DataTable dataTable)
            {
                // Begin Region 
                BeginRegion("Insert" + dataTable.ClassName + "()");

                // set queryType
                string queryType = "procedure";

                // Write Delete Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method inserts a '" + dataTable.ClassName + "' object.");
                WriteLine("/// This method uses the '" + dataTable.ClassName + "_Insert' " + queryType + ".");
                WriteLine("/// </summary>");
                WriteLine("/// <returns>The identity value of the new record.</returns>");
                WriteLine("/// </summary>");

                // get class declaration line
                string classLine = "public static int Insert#Object#(Insert#Object#StoredProcedure insert#Object#Proc, DataConnector databaseConnector)";
                classLine = classLine.Replace("#Object#", dataTable.ClassName);

                // Write class line
                WriteLine(classLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment
                WriteComment("Initial Value");

                // Write line to set initial value
                WriteLine("int newIdentity = -1;");

                // Write Blank Line
                WriteLine();

                // Write Comment  Verify database connection is connected
                WriteComment("Verify database connection is connected");

                // get line to test connection
                string ifConnected = "if ((databaseConnector != null) && (databaseConnector.Connected))";

                // Write ifConnected
                WriteLine(ifConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Execute Non Query
                WriteComment("Execute Non Query");

                // get line to execute delete
                string insertLine = "newIdentity = DataHelper.InsertRecord(insert" + dataTable.ClassName + "Proc, databaseConnector);";
                
                // Write line to insert
                WriteLine(insertLine);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Return Value
                WriteComment("return value");

                // Write Return Value
                WriteLine("return newIdentity;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion for DeleteMethod
                EndRegion();

                // Write Blank Line
                WriteLine();
            } 
            #endregion

            #region CreateUpdateMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the update method for
            /// this DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateUpdateMethod(DataTable dataTable)
            {
                // Begin Region 
                BeginRegion("Update" + dataTable.ClassName + "()");

                // set queryType
                string queryType = "procedure";

                // Write Delete Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method updates a '" + dataTable.ClassName + "'.");
                WriteLine("/// This method uses the '" + dataTable.ClassName + "_Update' " + queryType + ".");
                WriteLine("/// </summary>");
                WriteLine("/// <returns>True if successful false if not.</returns>");
                WriteLine("/// </summary>");

                // get class declaration line
                string classLine = "public static bool Update#Object#(Update#Object#StoredProcedure update#Object#Proc, DataConnector databaseConnector)";
                classLine = classLine.Replace("#Object#", dataTable.ClassName);

                // Write class line
                WriteLine(classLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment
                WriteComment("Initial Value");

                // Write line to set initial value
                WriteLine("bool saved = false;");

                // Write Blank Line
                WriteLine();

                // Write Comment  Verify database connection is connected
                WriteComment("Verify database connection is connected");

                // get line to test connection
                string ifConnected = "if ((databaseConnector != null) && (databaseConnector.Connected))";

                // Write ifConnected
                WriteLine(ifConnected);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Execute Update.
                WriteComment("Execute Update.");

                // get line to execute delete
                string updateLine = "saved = DataHelper.UpdateRecord(update" + dataTable.ClassName + "Proc, databaseConnector);";

                // Write updateLine
                WriteLine(updateLine);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment Return Value
                WriteComment("return value");

                // Write Return Value
                WriteLine("return saved;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion for Update
                EndRegion();

                // Write Blank Line
                WriteLine();
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
            private string GetStringVariableLine(string variableName, string variableValue, bool addThis)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();
                
                // if add this
                if(addThis)
                {
                    sb.Append("this.");
                }
                else
                {
                    // append string declaration
                    sb.Append("string ");
                }

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
            /// This method writes the summary for the data object manager.
            /// </summary>
            /// <param name="dataTable"></z>
            private void WriteClassSummary(DataTable dataTable)
            {
                // Write summary for this class
                WriteLine("/// <summary>");
                WriteLine("/// This class is used to manage a '" + dataTable.ClassName + "' object.");
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
                
                // get className
                string className = dataTable.ClassName + "Manager";
                
                // Write Constructor Summary
                WriteLine("/// <summary>");
                WriteLine("/// Create a new instance of a '" + className + "' object.");
                WriteLine("/// </summary>");
                
                // Get Constructor Line
                string constructorLine = "public " + className + "(DataManager dataManagerArg)";
                
                // Write constructorLine Line
                WriteLine(constructorLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Set DataManager
                WriteComment("Set DataManager");
                
                // Now Write line to set DataManager
                WriteLine("this.DataManager = dataManagerArg;");
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Create Child Controllers
                WriteComment("Perform Initialization");
                
                // Write Call to Init Method
                WriteLine("Init();");
                
                // Decrease Indent
                Indent--;
                
                // Write Close Bracket
                WriteCloseBracket();
                
                // Write endregion
                EndRegion();;
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteInitMethod()
            /// <summary>
            /// This method writes the Init method which
            /// instanicates each child controller
            /// </summary>
            private void WriteInitMethod(DataTable dataTable)
            {
                // Begin Region For The Init Method
                BeginRegion("Init()");
                
                // Write The Summary For The Init Method
                WriteLine("/// <summary>");
                WriteLine("/// Perorm Initialization For This Object");
                WriteLine("/// </summary>");
                
                // Write the method declaration for the Init() method.
                WriteLine("private void Init()");
                
                // Write Open Bracket {
                WriteOpenBracket(true);

                // Write Comment Create DataHelper object
                WriteComment("Create DataHelper object");
                
                // Instanciate DataHelper
                WriteLine("this.DataHelper = new DataHelper();");
                
                // Write Close Bracket }
                WriteCloseBracket(true);
                
                // End Region
                EndRegion();
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteMethods(dataTable dataTable)
            /// <summary>
            /// /// <summary>
            /// Write the methods for the class being created.
            /// </summary>
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="nameSpaceName">Only need for tables with ambigous names.</param>
            private void WriteMethods(DataTable dataTable)
            {
                // if the dataTable exists
                if (dataTable != null)
                {
                    // Begin Region For Methods
                    BeginRegion("Methods");

                    // Increase Indent
                    Indent++;

                    // if the data table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Create The DeleteMethod
                        CreateDeleteMethod(dataTable);
                    }

                    // Create FetchAllMethod
                    CreateFetchAllMethod(dataTable);

                    // if the data table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Create FindMethod
                        CreateFindMethod(dataTable);
                    }

                    // Write The Init method
                    WriteInitMethod(dataTable);

                    // if the data table has a primary key and is not a view
                    if (!dataTable.IsView)
                    {
                        // Create InsertMethod
                        CreateInsertMethod(dataTable);
                    }

                    // if the data table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Create Update Method
                        CreateUpdateMethod(dataTable);
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

            #region WritePrivateVariables(DataTable dataTable)
            /// <summary>
            /// This method writes the private variables for a 
            /// DataObjectMangaer
            /// </summary>
            private void WritePrivateVariables(DataTable dataTable)
            {
                // Begin Region Static Methods
                BeginRegion("Private Variables");

                // Write the private variables for a DataManager
                WriteLine("private DataManager dataManager;");
                WriteLine("private DataHelper dataHelper;");

                // Write line
                EndRegion();
                
                // Write Blank Line
                WriteLine();
            }
            #endregion
       
            #region WriteProperties()
            /// <summary>
            /// This method writes the properties for each
            /// DataManager and DataHelper objects.
            /// </summary>
            private void WriteProperties(DataTable dataTable)
            {
                // Write Region For Properties
                BeginRegion("Properties");

                // Write Blank Line
                WriteLine();

                // Increase Indent
                Indent++;
                
                // Write Property For DataHelper
                BeginRegion("DataHelper");

                // Write the summary for the DataHelper
                WriteLine("/// <summary>");
                WriteLine("/// This object uses the Microsoft Data");
                WriteLine("/// Application Block to execute stored");
                WriteLine("/// procedures.");
                WriteLine("/// </summary>");
                
                // Write the property declaration line
                WriteLine("internal DataHelper DataHelper");
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Get & Set accessors
                WriteLine("get { return dataHelper; }");
                WriteLine("set { dataHelper = value; }");
                
                // WRite Close Bracket
                WriteCloseBracket(true);
                
                // End Region For DataHelper Property
                EndRegion();

                // Write Blank Line
                WriteLine();

                // Write Property For DataManager
                BeginRegion("DataManager");

                // Write the summary for the DataManager
                WriteLine("/// <summary>");
                WriteLine("/// A reference to this objects parent.");
                WriteLine("/// </summary>");

                // Write the property declaration line
                WriteLine("internal DataManager DataManager");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Get & Set accessors
                WriteLine("get { return dataManager; }");
                WriteLine("set { dataManager = value; }");

                // WRite Close Bracket
                WriteCloseBracket(true);

                // End Region For DataManager Property
                EndRegion();

                // Write Blank Line
                WriteLine();

                // Decrease Indent
                Indent--;
                
                // End Properties Region
                EndRegion();

                // Write Blank Line After Properties Region
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

            #region RootDataManagerPath
            /// <summary>
            /// The root path to create the file from.
            /// </summary>
            public string RootDataManagerPath
            {
                get { return rootDataManagerPath; }
                set { rootDataManagerPath = value; }
            } 
            #endregion
    		
		#endregion

	}
	#endregion	
	
}
