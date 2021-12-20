

#region using statements

using System;
using System.Collections.Generic;
using DataJuggler.Net;
using System.Text;
using System.IO;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{

    #region class ControllerManagerCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a Controller Manager object.
    /// </summary>
	public class ControllerManagerCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private string projectName;
        private string rootControllerPath;
        private string nameSpaceName;
        private ReferencesSet objectReferences;
        #endregion

		#region Constructor
		/// <summary>
        /// Create a new instance of ControllerManagerCreator
        /// </summary>
        public ControllerManagerCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootControllerPathArg, string projectNameArg, string nameSpaceNameArg, ProjectFileManager fileManager, TargetFrameworkEnum targetFramework) : base(fileManager, false, false, targetFramework)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.ProjectName = projectNameArg;
		    this.NameSpaceName = nameSpaceNameArg;
		    this.RootControllerPath = rootControllerPathArg;
		    this.ObjectReferences = objectReferencesArg;
		}
		#endregion

        #region Methods
        
            #region CreateControllerManager()
            /// <summary>
            /// Creates the ControllerManager.
            /// </summary>
            public bool CreateControllerManager(List<DataTable> dataTables)
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
                    CreateFile(fileName, DataManager.ProjectTypeEnum.ALC);
                    
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
                    string className = "ControllerManager";
                    
                    // Write Region for this reader
                    BeginRegion("class " + className);

                    // Write Object Reader Summary
                    WriteClassSummary();
                    
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
                        // set created to true
                        created = true;
                    }
                }
                
                // return value
                return created;
            }
            #endregion
            
            #region CreateControllerVariable(DataTable dataTable)
            /// <summary>
            /// This method creates the private variable for 
            /// a controller for a DataTable.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateControllerVariable(DataTable dataTable)
            {
                // Create String Builder
                StringBuilder sb = new StringBuilder("private ");

                // Get DataType
                string dataType = CreateDataType(dataTable, true);
               
                // Append DataType
                sb.Append(dataType);
                
                // Append Space Between DataType and variable name
                sb.Append(" ");
                
                // Append ClassName
                sb.Append(dataTable.ClassName.ToLower());

                // Append Controller
                sb.Append("Controller;");

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
                StringBuilder sb = new StringBuilder(this.RootControllerPath);

                // If the root data object reader path does not end with a back slash
                if (!this.RootControllerPath.EndsWith(@"\"))
                {
                    // Append Backslash
                    sb.Append(@"\");
                }

                // Add The Word ControllerManager
                sb.Append("ControllerManager.cs");

                // return value
                return sb.ToString();
            }
            #endregion

            #region CreateDataType(DataTable dataTable)
            /// <summary>
            /// This method creates the data type for each controller.
            /// UserController, ContactController, etc.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateDataType(DataTable dataTable, bool appendController)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder();
                
                // add dataTable.ClassName
                sb.Append(dataTable.ClassName);

                // if Append Controller
                if(appendController)
                {
                    // Append Controller
                    sb.Append("Controller");
                }
                
                // return value
                return sb.ToString();
            }  
            #endregion

            #region InstanciateController(DataTable dataTable)
            /// <summary>
            /// This method creates the line in the Init() method
            /// to instanciate a Child Controller
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string InstanciateController(DataTable dataTable)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("this.");
                
                // Append ClassName
                sb.Append(dataTable.ClassName);
                
                // Append Controller
                sb.Append("Controller = new ");
                
                // Append ClassName again
                sb.Append(dataTable.ClassName);

                // Append Controller();
                sb.Append("Controller(this.ErrorProcessor, this.AppController);");
                
                // return value
                return sb.ToString();
            }   
            #endregion

            #region WriteClassSummary(DataTable dataTable)
            /// <summary>
            /// This method writes the summary for the data object reader.
            /// </summary>
            /// <param name="dataTable"></z>
            private void WriteClassSummary()
            {
                WriteLine("/// <summary>");
                WriteLine("/// This class manages the child controllers for this application.");
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
                WriteLine("/// Creates a new Creates a new 'ControllerManager' object.");
                WriteLine("/// </summary>");
                
                // Get Constructor Line
                string constructorLine = "public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)";
                
                // Write constructorLine Line
                WriteLine(constructorLine);

                // Write Open Bracket
                WriteOpenBracket();

                // Increase Indent
                Indent++;
                
                // Write Comment SaveArguments
                WriteComment("Save Arguments");

                // Save Argument For ErrorProcessor
                WriteLine("this.ErrorProcessor = errorProcessorArg;");
                
                // Save Argument For DataManager
                WriteLine("this.AppController = appControllerArg;");
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Create Child Controllers
                WriteComment("Create Child Controllers");
                
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
                WriteLine("/// Create Child Controllers");
                WriteLine("/// </summary>");
                
                // Write the method declaration for the Init() method.
                WriteLine("private void Init()");
                
                // Write Open Bracket {
                WriteOpenBracket();
                
                // Increase Indent
                Indent++;

                // Write Comment Create Child Controllers
                WriteComment("Create Child Controllers");
                
                // now instanciate each controller
                if(this.DataTables != null)
                {
                    // loop through each data table
                    foreach(DataTable dataTable in this.DataTables)
                    {   
                        // Get the line to instanciate this object
                        string instanicateController = InstanciateController(dataTable);

                        // Write the line to instanciate this object
                        WriteLine(instanicateController);
                    }
                }
                
                // Decrease Indent
                Indent--;
                
                // Write Close Bracket }
                WriteCloseBracket();
                
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
                WriteLine("private ErrorHandler errorProcessor;");
                WriteLine("private ApplicationController appController;");

                // Write DataTable Private Variables
                if(this.DataTables != null)
                {
                    // loop through each DataTable
                    foreach(DataTable dataTable in this.DataTables)
                    { 
                        // Get Controller Private Variable For This DataTable
                        string controllerVariable = CreateControllerVariable(dataTable);
                        
                        // Write Controller Private Variable
                        WriteLine(controllerVariable);
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
                
                // Write Property For AppController
                WriteProperty("AppController", "appController", "ApplicationController");
                
                // Write Property For ErrorProcessor
                WriteProperty("ErrorProcessor", "errorProcessor", "ErrorHandler");
                
                // Now Create A Property For Each Controller
                if(this.DataTables != null)
                {
                    // loop through each table and create a controller for each table
                    foreach(DataTable dataTable in this.DataTables)
                    {
                        // get variables for each type
                        string propertyName = dataTable.ClassName + "Controller";
                        string variableName = dataTable.ClassName.ToLower() + "Controller";
                        string dataType = CreateDataType(dataTable, true);
                    
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

            #region RootControllerPath
            /// <summary>
            /// The root path to create the file from.
            /// </summary>
            public string RootControllerPath
            {
                get { return rootControllerPath; }
                set { rootControllerPath = value; }
            } 
            #endregion
    		
		#endregion

	}
	#endregion	
	
}
