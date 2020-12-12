

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using DataJuggler.Net;
using System.Text;
using System.IO;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{

    #region class StoredProcedureObjectCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a DataOperationsManagerCreator
    /// </summary>
	public class StoredProcedureObjectCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private string rootStoredProceduresPath;
        private string nameSpaceName;
        private ReferencesSet objectReferences;
        #endregion

		#region Constructor
		/// <summary>
        /// Create a new instance of ControllerManagerCreator
        /// </summary>
        public StoredProcedureObjectCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootStoredProceduresPathArg, string nameSpaceNameArg, ProjectFileManager fileManager, bool dotNet5Project) : base(fileManager, false, dotNet5Project)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.NameSpaceName = nameSpaceNameArg;
            this.RootStoredProceduresPath = rootStoredProceduresPathArg;
		    this.ObjectReferences = objectReferencesArg;
		}
		#endregion

        #region Methods

            #region CreateStoredProcedureObjects(List<DataTable> dataTables)
            /// <summary>
            /// Creates All The StoredProcedure Objects.
            /// </summary>
            public void CreateStoredProcedureObjects(List<DataTable> dataTables)
            {   
                // Set Indent To 0
                Indent = 0;
                
                // verify DataTable exist
                if (dataTables != null)
                {   
                    // Create StoredProcedureObjects for each table
                    foreach(DataTable dataTable in this.DataTables)
                    {
                        // If the data table is a view
                        if (dataTable.IsView)
                        {
                            // Create FetchAllProc
                            CreateFetchAllProc(dataTable);
                        }
                        else
                        {
                            
                            // Create FetchAllProc
                            CreateFetchAllProc(dataTable);

                            // Create InsertProc
                            CreateInsertProc(dataTable);

                            // if the table has a primary key
                            if (dataTable.HasPrimaryKey)
                            {
                                // Create FindProc
                                CreateFindProc(dataTable);
                                
                                // Create Delete Proc
                                CreateDeleteProc(dataTable);
                                
                                // Create UpdateProc
                                CreateUpdateProc(dataTable);
                            }
                        }
                    }
                }
            }
            #endregion

            #region CreateDeleteProc(DataTable dataTable)
            /// <summary>
            /// This method creates the DeleteStoredProcedureObject
            /// for a data table.
            /// </summary>
            private void CreateDeleteProc(DataTable dataTable)
            {   
                // procType
                StoredProcedureTypes procType = StoredProcedureTypes.Delete;
                
                // Create StroredProcedure
                CreateStoredProcedure(dataTable, procType);
            }
            #endregion

            #region CreateFetchAllProc(DataTable dataTable)
            /// <summary>
            /// This method creates the FetchAll proc for a DataTabe
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateFetchAllProc(DataTable dataTable)
            {
                // procType
                StoredProcedureTypes procType = StoredProcedureTypes.FetchAll;

                // Create StroredProcedure
                CreateStoredProcedure(dataTable, procType);
            }
            #endregion

            #region CreateFileName(DataTable dataTable)
            /// <summary>
            /// Create the file name for this reader.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateFileName(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(this.RootStoredProceduresPath);

                // If does not end with backslash
                if (!this.RootStoredProceduresPath.EndsWith(@"\"))
                {
                    // Append Backslash \
                    sb.Append(@"\");
                }

                // determine folder to add
                string procFolder = GetProcFolder(procType, false, true);

                // append procFold
                sb.Append(procFolder);

                // Append the word for proc type (Delete, FetchAll, Find, etc.)
                sb.Append(procType.ToString());

                // set the clas name
                string className = dataTable.ClassName;
                
                // if this is a fetch all (a collection is retured)
                if (procType == StoredProcedureTypes.FetchAll)
                {
                    // get the class name in plural 
                    className = PluralWordHelper.GetPluralName(dataTable.ClassName, false);
                }
                
                // Apend the class name
                sb.Append(className);
                
                // Add The Word DataOperationsManager
                sb.Append("StoredProcedure.cs");

                // return value
                return sb.ToString();
            }
            #endregion
            
            #region CreateFindProc(DataTable dataTable)
            /// <summary>
            /// This method creates the Find stored procedure object
            /// for a DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateFindProc(DataTable dataTable)
            {
                // procType
                StoredProcedureTypes procType = StoredProcedureTypes.Find;

                // Create StroredProcedure
                CreateStoredProcedure(dataTable, procType);
            }
            #endregion

            #region CreateInsertProc(DataTable dataTable)
            /// <summary>
            /// This method creates the insert proc for a data table.
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateInsertProc(DataTable dataTable)
            {
                // procType
                StoredProcedureTypes procType = StoredProcedureTypes.Insert;

                // Create StroredProcedure
                CreateStoredProcedure(dataTable, procType);
            } 
            #endregion

            #region CreateStoredProcedure(DataTable dataTable, StoredProcedureTypes procType)
            /// <summary>
            /// This method creates all the stored procedures
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="procType"></param>
            private void CreateStoredProcedure(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Indent = 0
                Indent = 0;
            
                // Create file name for a delete
                string fileName = CreateFileName(dataTable, procType);

                // if there is an _ in file name replace it.
                fileName = fileName.Replace("_", "");
                
                // Create file
                CreateFile(fileName, DataManager.ProjectTypeEnum.DAC);

                // Write References
                WriteReferences(this.ObjectReferences);

                // Write Blank Line
                WriteLine();

                // Write NameSpace
                StringBuilder sb = new StringBuilder("namespace ");
                sb.Append(this.NameSpaceName);
                
                // get prod folder
                string procFolder = GetProcFolder(procType, true, false);
                sb.Append(procFolder);
                
                string nameSpace = sb.ToString();
                WriteLine(nameSpace);

                // Write Open Brack
                WriteOpenBracket(true);

                // Write Blank Line
                WriteLine();

                // Get ClassName
                string className = GetClassName(dataTable, procType);

                // Write Region for this reader
                BeginRegion("class " + className);

                // Write Object Reader Summary
                WriteClassSummary(dataTable, procType);

                // get class line
                string classLine = "public class " + className + " : StoredProcedure";

                // Write class line
                WriteLine(classLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Private Variables
                WritePrivateVariables(dataTable, procType);

                // Write Constructor
                WriteConstructor(dataTable, procType);

                // Write Methods
                WriteMethods(dataTable, procType);

                // Write Properties
                WriteProperties(dataTable, procType);

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
            #endregion

            #region CreateUpdateProc(DataTable dataTable)
            /// <summary>
            /// This method creates the update procedure for
            /// this DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            private void CreateUpdateProc(DataTable dataTable)
            {
                // procType
                StoredProcedureTypes procType = StoredProcedureTypes.Update;

                // Create StroredProcedure
                CreateStoredProcedure(dataTable, procType);
            }
            #endregion

            #region GetClassName(DataTable dataTable, StoredProcedureTypes procType)
            /// <summary>
            /// This method gets the name of this class.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <param name="procType"></param>
            /// <returns></returns>
            private string GetClassName(DataTable dataTable, StoredProcedureTypes procType)
            {
                // create StringBuilder
                StringBuilder sb = new StringBuilder(procType.ToString());
                
                // set the class name
                string className = dataTable.ClassName;
                
                // if this is a fetch all proc
                if (procType == StoredProcedureTypes.FetchAll)
                {
                    // get the plural name
                    className = PluralWordHelper.GetPluralName(className, false);
                }

                // Append table name
                sb.Append(className);
                
                // append the words stored procedure
                sb.Append("StoredProcedure");
                
                // set the return value
                className = sb.ToString();
                
                // return value
                return className;              
            }
            #endregion

            #region GetProcFolder(StoredProcedureTypes procType)
            /// <summary>
            /// This method gets the folder to place this proc in.
            /// </summary>
            /// <param name="procType"></param>
            /// <returns></returns>
            private string GetProcFolder(StoredProcedureTypes procType, bool addPrecedingDot, bool addBackslashToEnd)
            {
                // Get StringBuilder
                StringBuilder sb = new StringBuilder();
                
                // if AddDot.
                if(addPrecedingDot)
                {
                    // Add Dot.
                    sb.Append(".");
                }
               
                // local
                string procFolder = null;
                
                // determine procFolder by data type
                switch(procType)
                {
                    case StoredProcedureTypes.Delete:
                    
                        // set procFolder to Delete
                        procFolder = "Delete";
                        
                        // required
                        break;
                        
                    case StoredProcedureTypes.FetchAll:
                    case StoredProcedureTypes.Find:

                        // set procFolder to Fetch
                        procFolder = "Fetch";
                        
                        // required
                        break;
                        
                    case StoredProcedureTypes.Insert:

                        // set procFolder to Insert
                        procFolder = "Insert";
                        
                        // required
                        break;

                    case StoredProcedureTypes.Update:

                        // set procFolder to Insert
                        procFolder = "Update";

                        // required
                        break;
                }
                
                // return value
                sb.Append(procFolder);
                
                // Now Append Procedures
                sb.Append("Procedures");
                
                if(addBackslashToEnd)
                {
                    // append back slash
                    sb.Append(@"\");
                }
                
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

            #region WriteClassSummary(DataTable dataTable,StoredProcedureTypes procType)
            /// <summary>
            /// This method writes the summary for the stored proecedure object.
            /// </summary>
            /// <param name="dataTable"></z>
            private void WriteClassSummary(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Write summary for this class
                WriteLine("/// <summary>");
                
                // if this is a fetch all proc
                if(procType == StoredProcedureTypes.FetchAll)
                {
                    WriteLine("/// This class is used to " + procType + " '" + dataTable.ClassName + "' objects.");
                }
                else
                {
                    WriteLine("/// This class is used to " + procType + " a '" + dataTable.ClassName + "' object.");
                }
                WriteLine("/// </summary>");
            }
            #endregion

            #region WriteConstructor(DataTable dataTable)
            /// <summary>
            /// This method writes the constructor for this object.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteConstructor(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Begin Region Static Methods
                BeginRegion("Constructor");
                
                // get className
                string className = GetClassName(dataTable, procType);
                
                // Write Constructor Summary
                WriteLine("/// <summary>");
                WriteLine("/// Create a new instance of a '" + className + "' object.");
                WriteLine("/// </summary>");
                
                // Get Constructor Line
                string constructorLine = "public " + className + "()";
                
                // Write constructorLine Line
                WriteLine(constructorLine);

                // Write Open Bracket
                WriteOpenBracket(true);
                
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
            private void WriteInitMethod(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Begin Region For The Init Method
                BeginRegion("Init()");
                
                // Write The Summary For The Init Method
                WriteLine("/// <summary>");
                WriteLine("/// Set Procedure Properties");
                WriteLine("/// </summary>");
                
                // Write the method declaration for the Init() method.
                WriteLine("private void Init()");
                
                // Write Open Bracket {
                WriteOpenBracket(true);

                // Write Comment Create Child Controllers
                WriteComment("Set Properties For This Proc");

                // Write Blank Line
                WriteLine();
                
                // local
                string temp = null;

                // if the dataTable exists
                if (dataTable != null)
                {
                    // Write Comment Set ProcedureName
                    WriteComment("Set ProcedureName");

                    // Set ProcedureName
                    string procedureName = dataTable.ClassName + "_" + procType.ToString();
                    temp = GetStringVariableLine("ProcedureName", procedureName, true);

                    // Write procedureName
                    WriteLine(temp);

                    // Write Blank Line
                    WriteLine();

                    // Write Comment Set tableName
                    WriteComment("Set tableName");

                    // get line to set table name
                    string tableName = GetStringVariableLine("TableName", dataTable.ClassName, true);

                    // Write tableName
                    WriteLine(tableName);
                }
                
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
            /// Write the methods region and the Init method.
            /// </summary>
            private void WriteMethods(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Begin Region For Methods
                BeginRegion("Methods");
                
                // Increase Indent
                Indent++;
                
                // Write Blank Line
                WriteLine();
                
                // Write Out The Init method
                WriteInitMethod(dataTable, procType);
                
                // Decrease Indent
                Indent--;
                
                // End Region 
                EndRegion();
                
                // Write Blank Line
                WriteLine();
            }       
            #endregion

            #region WritePrivateVariables()
            /// <summary>
            /// This method writes the private variables for a 
            /// ControllerManager.
            /// </summary>
            private void WritePrivateVariables(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Begin Region Static Methods
                BeginRegion("Private Variables");
                
                // Write line
                EndRegion();;
                
                // Write Blank Line
                WriteLine();
            }
            #endregion
       
            #region WriteProperties()
            /// <summary>
            /// This method writes the properties for each
            /// DataController and the ErrorProcessor and
            /// DataManager objects.
            /// </summary>
            private void WriteProperties(DataTable dataTable, StoredProcedureTypes procType)
            {
                // Write Region For Properties
                BeginRegion("Properties");

                // Write Blank Line
                WriteLine();

                // Increase Indent
                Indent++;
               
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

            #region RootDataOperationsPath
            /// <summary>
            /// The root path to create the file from.
            /// </summary>
            public string RootStoredProceduresPath
            {
                get { return rootStoredProceduresPath; }
                set { rootStoredProceduresPath = value; }
            } 
            #endregion
    		
		#endregion

	}
	#endregion	
	
}
