

#region using statements

using System;
using System.Collections.Generic;
using DataJuggler.Net;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using System.Text;
using System.IO;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{

    #region class DataManagerCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a DataOperationsManagerCreator
    /// </summary>
	public class DataManagerCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private string projectName;
        private string rootDataManagerPath;
        private string nameSpaceName;
        private ReferencesSet objectReferences;
        #endregion

		#region Constructor
		/// <summary>
        /// Create a new instance of DataManagerCreator
        /// </summary>
        public DataManagerCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootDataManagerPathArg, string projectNameArg, string nameSpaceNameArg, ProjectFileManager fileManager, TargetFrameworkEnum targetFramework) : base(fileManager, false, false, targetFramework)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.ProjectName = projectNameArg;
		    this.NameSpaceName = nameSpaceNameArg;
            this.RootDataManagerPath = rootDataManagerPathArg;
		    this.ObjectReferences = objectReferencesArg;
		}
		#endregion

        #region Methods
        
            #region CreateDataManager()
            /// <summary>
            /// Creates the DataOperationsManager.
            /// </summary>
            public bool CreateDataManager(List<DataTable> dataTables)
            {
                // Initial Value
                bool created = false;
                
                // Set Indent To 0
                Indent = 0;

                // file name variable
                string fileName = null;
                
                // verify DataTable exist
                if (dataTables != null)
                {
                    // Get DataWatcherFileName
                    fileName = CreateFileName();
                    
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
                    string className = "DataManager";
                    
                    // Write Region for this reader
                    BeginRegion("class " + className);

                    // Write Object Reader Summary
                    WriteClassSummary();
                    
                    // get class line
                    string classLine = "public class " + className;
                    
                    // Write ClassLine
                    WriteLine(classLine);
                    
                    // Write Open Bracket
                    WriteOpenBracket(true);
                    
                    // Write Blank Line
                    WriteLine();
                    
                    // Write The Private Variables Region
                    WritePrivateVariables();

                    // Write Constructor
                    WriteConstructor();
                    
                    // Write Methods
                    WriteMethods();
                    
                    // Write Properties
                    WriteProperties();
                    
                    // Decrease Indent
                    Indent--;
                    
                    // Write Close Bracket
                    WriteCloseBracket();
                    
                    // Write EndRegion For Class
                    EndRegion();
                    
                    // Write Blank Line
                    WriteLine();

                    // Decrease Indent
                    Indent--;

                    // Write Close Bracket
                    WriteCloseBracket();
                    
                    // Close This File
                    this.Writer.Close();
                }
                
                // if file name is not null 
                if(!String.IsNullOrEmpty(fileName))
                {
                    // if file exists on hard drive
                    if(File.Exists(fileName))
                    {
                        // get the text
                        string text = File.ReadAllText(fileName);

                        // if the text exists
                        if (TextHelper.Exists(text))
                        {
                            // get the lines from this file text
                            List<TextLine> lines = TextHelper.GetTextLines(text);

                            // If there are not multiple lines, this was not created
                            created = ListHelper.HasOneOrMoreItems(lines);
                        }
                    }
                }
                
                // return value
                return created;
            }
            #endregion

            #region CreateMethodVariable(DataTable dataTable)
            /// <summary>
            /// This method creates the private variable for 
            /// a variable for this data operation method for a DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateMethodVariable(DataTable dataTable)
            {
                // Create String Builder
                StringBuilder sb = new StringBuilder("private ");

                // Get DataType
                string dataType = CreateDataType(dataTable);
               
                // Append DataType
                sb.Append(dataType);
                
                // Append Space Between DataType and variable name
                sb.Append(" ");
                
                // Append ClassName
                sb.Append(dataTable.ClassName.ToLower());

                // Append Methods
                sb.Append("Manager;");

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
            private string CreateFileName()
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(this.RootDataManagerPath);

                // if the RootDataManager 
                if(!this.RootDataManagerPath.EndsWith(@"\"))
                {
                    // Append 
                    sb.Append(@"\");
                }
              
                // Add The Word DataOperationsManager
                sb.Append("DataManager.cs");

                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateDataType(DataTable dataTable)
            /// <summary>
            /// This method creates the data type for each type of method
            /// UserMethods, ContactMethods, etc.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateDataType(DataTable dataTable)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(dataTable.ClassName);
                
                // Append Manager
                sb.Append("Manager");
                
                // return value
                return sb.ToString();
            }  
            #endregion

            #region InstanciateMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the line in the Init() method
            /// to instanciate a Child DataOperation Method
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string InstanciateMethod(DataTable dataTable)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("this.");
                
                // Append ClassName
                sb.Append(dataTable.ClassName);
                
                // Append Controller
                sb.Append("Manager = new ");

                // Append ClassName
                sb.Append(dataTable.ClassName);
                
                // Append Manager
                sb.Append("Manager(this);");
                
                // return value
                return sb.ToString();
            }   
            #endregion

            #region WriteClassSummary(DataTable dataTable)
            /// <summary>
            /// This method writes the summary for the data manager.
            /// </summary>
            /// <param name="dataTable"></z>
            private void WriteClassSummary()
            {
                WriteLine("/// <summary>");
                WriteLine("/// This class manages data operations for this project.");
                WriteLine("/// </summary>");
            }
            #endregion

            #region WriteConstructor(DataTable dataTable)
            /// <summary>
            /// This method writes the constructor for this object.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteConstructor()
            {
                // Begin Region Static Methods
                BeginRegion("Constructor");
                
                // Write Constructor Summary
                WriteLine("/// <summary>");
                WriteLine("/// Creates a new instance of a(n) 'DataManager' object.");
                WriteLine("/// </summary>");
                
                // Get Constructor Line
                string constructorLine = "public DataManager(string connectionName = \"\")";
                
                // Write constructorLine Line
                WriteLine(constructorLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write comment
                WriteComment("Store the ConnectionName arg");

                // Write line to store the arg
                WriteLine("this.ConnectionName = connectionName;");

                // Write a blank line
                WriteLine();
                
                // Write Comment Perform Initializations For This Object.
                WriteComment("Perform Initializations For This Object.");
                
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
            private void WriteInitMethod()
            {
                // Begin Region For The Init Method
                BeginRegion("Init()");
                
                // Write The Summary For The Init Method
                WriteLine("/// <summary>");
                WriteLine("/// Perform Initializations For This Object.");
                WriteLine("/// Create the DataConnector and the Child Object Managers.");
                WriteLine("/// </summary>");
                
                // Write the method declaration for the Init() method.
                WriteLine("private void Init()");
                
                // Write Open Bracket {
                WriteOpenBracket(true);

                // Write Comment Create New DataConnector.
                WriteComment("Create New DataConnector");
                
                // Instanciate DataConnector
                WriteLine("this.DataConnector = new DataConnector();");
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Create Child Object Managers
                WriteComment("Create Child Object Managers");
                
                // now instanciate each controller
                if(this.DataTables != null)
                {
                    // loop through each data table
                    foreach(DataTable dataTable in this.DataTables)
                    {
                        // Get the line to instanciate this object
                        string instanciateMethod = null;
                        
                        // Get the line to instanciate this object
                        instanciateMethod = InstanciateMethod(dataTable);

                        // Write the line to instanciate this object
                        WriteLine(instanciateMethod);
                    }
                }
                
                // Write Close Bracket }
                WriteCloseBracket(true);
                
                // End Region
                EndRegion();
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteMethods()
            /// <summary>
            /// Write the methods region and the Init method.
            /// </summary>
            private void WriteMethods()
            {
                // Begin Region For Methods
                BeginRegion("Methods");
                
                // Increase Indent
                Indent++;
                
                // Write Blank Line
                WriteLine();
                
                // Write Out The Init method
                WriteInitMethod();
                
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
            private void WritePrivateVariables()
            {
                // Begin Region Static Methods
                BeginRegion("Private Variables");

                // Write ErrorProcessor and ParentController
                WriteLine("private DataConnector dataConnector;");

                // Update 8.22.2019 - Version 1.3.0: Dot Net Core / Blazor compatibility
                WriteLine("private string connectionName;");
                
                // Write DataTable Private Variables
                if(this.DataTables != null)
                {
                    // Get methodVariable Private Variable For This DataTable
                    string methodVariable = null;
                    
                    // loop through each DataTable
                    foreach(DataTable dataTable in this.DataTables)
                    {
                        // Get methodVariable Private Variable For This DataTable
                        methodVariable = CreateMethodVariable(dataTable);

                        // Write methodVariable
                        WriteLine(methodVariable);
                    }
                }

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
                WriteOpenBracket();
                
                // Increase Indent
                Indent++;
                
                // creaete the get for the property
                string getProperty = "get { return " + variableName + "; }";
                
                // Write getProperty
                WriteLine(getProperty);
                
                // Create the setter for this property
                string setProperty = "set { " + variableName + " = value; }";
                
                // Write setProperty
                WriteLine(setProperty);
                
                // Decrease Indent
                Indent--;
                
                // Write Close Bracket
                WriteCloseBracket();
                
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

                // Write Property For DataConnector
                WriteProperty("DataConnector", "dataConnector", "DataConnector");

                // Update 8.22.2019 - Version 1.3.0: Dot Net Core / Blazor compatibility
                // Write Property For ConnectionName
                WriteProperty("ConnectionName", "connectionName", "string");
                
                // Now Create A Property For Each Controller
                if(this.DataTables != null)
                {
                    // loop through each table and create a controller for each table
                    foreach(DataTable dataTable in this.DataTables)
                    {   
                        // get variables for each type
                        string propertyName = dataTable.ClassName + "Manager";
                        string variableName = dataTable.ClassName.ToLower() + "Manager";
                        string dataType = CreateDataType(dataTable);
                    
                        // Now Creaete Property For This Data
                        WriteProperty(propertyName, variableName, dataType);
                    }
                }
                
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

            #region ProjectName
            /// <summary>
            /// This is the name of the project
            /// and will be included in the names
            /// of the controllers.
            /// </summary>
            public string ProjectName
            {
                get { return projectName; }
                set { projectName = value; }
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
