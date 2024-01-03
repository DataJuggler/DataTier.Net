

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
using DataJuggler.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ObjectLibrary.BusinessObjects;

#endregion

namespace DataTierClient.Builders
{

    #region class ControllerCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a data object reader 
    /// </summary>
	public class ControllerCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private string projectName;
        private string rootControllerPath;
        private string nameSpaceName;
        private DataJuggler.Net.ReferencesSet objectReferences;
        private Project selectedProject;
        #endregion

		#region Constructor
		/// <summary>
        /// Create a new instance of ControllerManagerCreator
        /// </summary>
        public ControllerCreator(List<DataTable> dataTablesArg, DataJuggler.Net.ReferencesSet objectReferencesArg, string rootControllerPathArg, string projectNameArg, string nameSpaceNameArg, ProjectFileManager fileManager, TargetFrameworkEnum targetFramework, Project selectedProject) : base(fileManager, false, false, targetFramework)
		{   
		    // Store args
		    DataTables = dataTablesArg;
		    ProjectName = projectNameArg;
		    NameSpaceName = nameSpaceNameArg;
		    RootControllerPath = rootControllerPathArg;
		    ObjectReferences = objectReferencesArg;
            SelectedProject = selectedProject;
		}
		#endregion

        #region Methods

            #region CreateController(DataTable dataTable)
            /// <summary>
            /// Creates the Controller.
            /// </summary>
            public bool CreateController(DataTable dataTable)
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
                    // Get the fileName for the Controller class
                    fileName = CreateFileName(dataTable);
                    
                    // Update Version 1.2.5 The Controllers Are Only
                    // Created if they do not already exist. This
                    // Allows For Customizations at the Root of the
                    // Data Tier.
                    if(!File.Exists(fileName))
                    {
						// Create Writer
						CreateFile(fileName, DataManager.ProjectTypeEnum.ALC);
					
						// Write References
						WriteReferences(ObjectReferences);

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
						string className = dataTable.ClassName + "Controller";
	                    
						// Write Region for this reader
						BeginRegion("class " + className);

						// Write Class Summmary
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
					}
					else
					{
						// set created to true
						created = true;
					}
                }
                
                // return value
                return created;
            }
            #endregion

            #region CreateControllers(List<DataTable> dataTables)
            /// <summary>
            /// Creates the Controller.
            /// </summary>
            public void CreateControllers(List<DataTable> dataTables)
            {
                // verify DataTable exist
                if (dataTables != null)
                {
                    // loop through data tables collection
                    foreach (DataTable dataTable in this.DataTables)
                    {
                        // Create Controller
                        CreateController(dataTable);
                    }
                }
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
                StringBuilder sb = new StringBuilder(this.RootControllerPath);

                // Append Backslash if need
                if(!this.RootControllerPath.EndsWith(@"\"))
                {
                    // Append Backslash
                    sb.Append(@"\");
                }
               
                // Add ClassName
                sb.Append(dataTable.ClassName);

                // Add The Word Reader
                sb.Append("Controller.cs");

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
            /// This method writes the summary for a controller object.
            /// </summary>
            /// <param name="dataTable"></z>
            private void WriteClassSummary(DataTable dataTable)
            {
                WriteLine("/// <summary>");
                WriteLine("/// This class controls a(n) '" + dataTable.ClassName + "' object.");
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
                WriteLine("/// Creates a new '" + dataTable.ClassName + "Controller' object.");
                WriteLine("/// </summary>");
                
                // Get Constructor Line
                string constructorLine = "public " + dataTable.ClassName + "Controller(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)";
                
                // Write constructorLine Line
                WriteLine(constructorLine);

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment SaveArguments
                WriteComment("Save Arguments");

                // Save Argument For ErrorProcessor
                WriteLine("this.ErrorProcessor = errorProcessorArg;");
                
                // Save Argument For DataManager
                WriteLine("this.AppController = appControllerArg;");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write endregion
                EndRegion();;
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteCreateObjectParameter(DataTable dataTable)
            /// <summary>
            /// This method writes the Create<ClassName>Method
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateObjectParameter(DataTable dataTable)
            {
                // Write Blank Line
                WriteLine();
            
                // Write the region
                BeginRegion("Create" + dataTable.ClassName + "Parameter");
                
                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates the parameter for a '" + dataTable.ClassName + "' data operation.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='" + dataTable.ClassName.ToLower() + "'>The '" + dataTable.ClassName + "' to use as the first");
                WriteLine("/// parameter (parameters[0]).</param>");
                WriteLine("/// <returns>A List<PolymorphicObject> collection.</returns>");
                
                // get method line
                string methodLine = "private static List<PolymorphicObject> Create" + dataTable.ClassName + "Parameter(" + dataTable.ClassName + " " + this.CapitalizeFirstChar(dataTable.ClassName, true) + ")";
                
                // Write method line
                WriteLine(methodLine);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment
                WriteComment("Initial Value");
                
                // create parameters
                string parameters = "List<PolymorphicObject> parameters = new List<PolymorphicObject>();";
                
                // WriteLine
                WriteLine(parameters);
                
                // Write Blank Line
                WriteLine();

                // Write Comment Create PolymorphicObject to hold the parameter
                WriteComment("Create PolymorphicObject to hold the parameter");
                
                // Now Create Parameter to hold the object
                WriteLine("PolymorphicObject parameter = new PolymorphicObject();");

                // Write Blank Line
                WriteLine();

                // Write Comment Set parameter.ObjectValue
                WriteComment("Set parameter.ObjectValue");
                
                // Write parameter.ObjectValue = <ClassName>;
                string parameterValue = "parameter.ObjectValue = " + this.CapitalizeFirstChar(dataTable.ClassName, true) + ";";
                
                // Write parameterValue
                WriteLine(parameterValue);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Add userParameter to parameters
                WriteComment("Add userParameter to parameters");
                
                // Write parameters.Add(parameter);
                WriteLine("parameters.Add(parameter);");
                
                // Write Blank Line
                WriteLine();
                
                // return value
                WriteComment("return value");
                
                // Write return value
                WriteLine("return parameters;");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write End Region
                EndRegion();
                
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
                string dataType = dataTable.ClassName;
                string methodName = "delete" + dataTable.ClassName + "Method";
                string parameterName = "temp" + dataType;

                // BeginRegion  #region Delete(<DataType> dataType>
                BeginRegion("Delete(" + dataType + " " + parameterName + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// Deletes a '" + dataTable.ClassName + "' from the database");
                WriteLine("/// This method calls the DataBridgeManager to execute the delete using the");

                // set the query
                string query = "procedure";

                // Write the line for the query
                WriteLine("/// " + query + " '" + dataTable.ClassName + "_Delete'.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='" + dataType.ToLower() + "'>The '" + dataType + "' to delete.</param>");
                
                // Write returns
                WriteLine("/// <returns>True if the delete is successful or false if not.</returns>");
                
                // Get classDeclaration
                string classDeclaration = "public bool Delete(" + dataType + " " + parameterName + ")";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment // locals
                WriteComment("locals");

                // Write Line For Delete
                WriteLine("bool deleted = false;");

                // Write Blank line
                WriteLine();

                // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                WriteComment("Get information for calling 'DataBridgeManager.PerformDataOperation' method.");

                // get methodName
                string methodNameLine = GetStringVariableLine("methodName", "Delete" + dataTable.ClassName);

                // Write MethodName
                WriteLine(methodNameLine);

                // get objectName
                string objectNameLine = GetStringVariableLine("objectName", "ApplicationLogicComponent.Controllers");

                // Write objectName
                WriteLine(objectNameLine);

                // Write Blank Line
                WriteLine();

                // Write try
                WriteLine("try");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment verify object exists before attemptintg to delete 
                WriteComment("verify temp" + this.CapitalizeFirstChar(dataType, true) + " exists before attemptintg to delete");

                // Write Line if parameterName != null)
                WriteLine("if(" + parameterName + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  Create Delegate For DataOperation
                WriteComment("Create Delegate For DataOperation");

                // get line for delegate
                string delegateLine = "ApplicationController.DataOperationMethod " + methodName + " = this.AppController.DataBridge.DataOperations." + dataTable.ClassName + "Methods.Delete" + dataTable.ClassName + ";";

                // Write delegateLine
                WriteLine(delegateLine);

                // Write Blank Line
                WriteLine();

                // Write Comment Create parameters for this method
                WriteComment("Create parameters for this method");

                // get line to create parameters
                string createParameterLine = "List<PolymorphicObject> parameters = Create" + dataTable.ClassName + "Parameter(" + parameterName + ");";

                // Write createParameterLine
                WriteLine(createParameterLine);

                // Write Blank Line
                WriteLine();

                // Write Comment  Perform DataOperation
                WriteComment("Perform DataOperation");

                // get performDataOperationLine
                string performDataOperationLine = "PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, " + methodName + ", parameters);";

                // Write performDataOperationLine
                WriteLine(performDataOperationLine);

                // Write Blank Line
                WriteLine();

                // Write Comment
                WriteComment("If return object exists");

                // Write if (returnObject != null)
                WriteLine("if (returnObject != null)");

                // Write Open Bracket (
                WriteOpenBracket(true);

                // Write Comment Test For True                
                WriteComment("Test For True");

                // Write line to test for true
                WriteLine("if (returnObject.Boolean.Value == NullableBooleanEnum.True)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Deleted
                WriteComment("Set Deleted To True");

                // Write line deleted = true;
                WriteLine("deleted = true;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write catch (Exception error)
                WriteLine("catch (Exception error)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  If ErrorProcessor exists
                WriteComment("If ErrorProcessor exists");

                // Write line to verify error processor exists
                WriteLine("if (this.ErrorProcessor != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Line To Log The Current Error
                WriteComment("Log the current error");

                // Write Line this.ErrorProcessor.LogError(methodName, objectName, error);
                WriteLine("this.ErrorProcessor.LogError(methodName, objectName, error);");
                
                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return deleted;
                WriteLine("return deleted;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Wrie EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteFetchAllMethod(DataTable dataTable)
            /// <summary>
            /// Write the FetchAll method
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteFetchAllMethod(DataTable dataTable)
            {
                // If the dataTable object exists
                if (NullHelper.Exists(dataTable))
                {
                    // Business Objects
                    string dataType = dataTable.ClassName;
                    string objectName = this.CapitalizeFirstChar(dataType, true);
                    string collectionDataType = "List<" + dataType + ">";
                    string variableName = dataType + "List";
                    string collectionObjectName = CapitalizeFirstChar(variableName, true);
                    string parameterName = "temp" + dataType;
                
                    // delegate 
                    string delegateMethodName = "fetchAllMethod";
                
                    // BeginRegion  FetchAll
                    BeginRegion("FetchAll(" + dataType + " " + parameterName + ")");
                
                    // set to procedure
                    string query = "procedure";
                
                    // Write Summary
                    WriteLine("/// <summary>");
                    WriteLine("/// This method fetches a collection of '" + dataType + "' objects.");
                    WriteLine("/// This method used the DataBridgeManager to execute the fetch all using the");
                    WriteLine("/// " + query + " '" + dataTable.ClassName + "_FetchAll'.</summary>");
                
                    // Add parameter and return values
                    WriteLine("/// <param name='" + parameterName +  "'>A temporary " + dataType + " for passing values.</param>");
                    WriteLine("/// <returns>A collection of '" + dataType + "' objects.</returns>");
                
                    // Get classDeclaration
                    string classDeclaration = "public " + collectionDataType + " FetchAll(" + dataType + " " + parameterName + ")";

                    // Write classDeclaration
                    WriteLine(classDeclaration);

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Comment Initial value
                    WriteComment("Initial value");

                    // Write Line For collection declaration
                    string initialValue = collectionDataType + " " + collectionObjectName + " = null;";

                    // Write initialValue
                    WriteLine(initialValue);

                    // Write Blank line
                    WriteLine();

                    // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                    WriteComment("Get information for calling 'DataBridgeManager.PerformDataOperation' method.");

                    // get methodName
                    string methodNameLine = GetStringVariableLine("methodName", "FetchAll");

                    // Write MethodName
                    WriteLine(methodNameLine);

                    // get objectName
                    string objectNameLine = GetStringVariableLine("objectName", "ApplicationLogicComponent.Controllers");

                    // Write objectName
                    WriteLine(objectNameLine);

                    // Write Blank Line
                    WriteLine();

                    // Write try
                    WriteLine("try");

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Comment Create Method
                    WriteComment("Create DataOperation Method");
                
                    // get line for delegate
                    string delegateLine = "ApplicationController.DataOperationMethod " + delegateMethodName + " = this.AppController.DataBridge.DataOperations." + dataTable.ClassName + "Methods.FetchAll;";

                    // Write delegateLine
                    WriteLine(delegateLine);

                    // Write Blank Line
                    WriteLine();

                    // Write Comment Create parameters for this method
                    WriteComment("Create parameters for this method");

                    // get line to create parameters
                    string createParameterLine = "List<PolymorphicObject> parameters = Create" + dataTable.ClassName + "Parameter(" + parameterName + ");";

                    // Write createParameterLine
                    WriteLine(createParameterLine);

                    // Write Blank Line
                    WriteLine();

                    // Write Comment  Perform DataOperation
                    WriteComment("Perform DataOperation");

                    // get performDataOperationLine
                    string performDataOperationLine = "PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);";

                    // Write performDataOperationLine
                    WriteLine(performDataOperationLine);

                    // Write Blank Line
                    WriteLine();

                    // Write Comment
                    WriteComment("If return object exists");

                    // Write if (returnObject != null)
                    WriteLine("if ((returnObject != null) && (returnObject.ObjectValue as " + collectionDataType + " != null))");

                    // Write Open Bracket (
                    WriteOpenBracket(true);

                    // Write Comment Set Return Object
                    WriteComment("Create Collection From ReturnObject.ObjectValue");
                
                    // Now Cast returnObject.ObjectValue as CollectionDataType
                    WriteLine(collectionObjectName + " = (" + collectionDataType + ") returnObject.ObjectValue;");
                
                    // Write CloseBracket
                    WriteCloseBracket(true);

                    // Write CloseBracket
                    WriteCloseBracket(true);

                    // Write catch (Exception error)
                    WriteLine("catch (Exception error)");

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Comment  If ErrorProcessor exists
                    WriteComment("If ErrorProcessor exists");

                    // Write line to verify error processor exists
                    WriteLine("if (this.ErrorProcessor != null)");

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Line To Log The Current Error
                    WriteComment("Log the current error");

                    // Write Line this.ErrorProcessor.LogError(methodName, objectName, error);
                    WriteLine("this.ErrorProcessor.LogError(methodName, objectName, error);");

                    // Write Close Bracket
                    WriteCloseBracket(true);

                    // Write Close Bracket
                    WriteCloseBracket(true);

                    // Write Blank Line
                    WriteLine();

                    // Write Comment For Return Value
                    WriteComment("return value");

                    // Write return deleted;
                    WriteLine("return " + collectionObjectName + ";");

                    // Write Close Bracket
                    WriteCloseBracket(true);

                    // Write EndRegion
                    EndRegion();

                    // Write Blank Line
                    WriteLine();
                }
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
                string dataType = dataTable.ClassName;
                string returnObjectName = this.CapitalizeFirstChar(dataType, true);
                string parameterName = "temp" + dataType;
                string delegateMethodName = "findMethod";
                
                // BeginRegion  #region Find(
                BeginRegion("Find(" + dataType + " temp" + dataType + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// Finds a '" + dataTable.ClassName + "' object by the primary key.");
                WriteLine("/// This method used the DataBridgeManager to execute the 'Find' using the");
                
                // local
                string query = "procedure";
                
                WriteLine("/// " + query + " '" + dataTable.ClassName + "_Find'</param>");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='" + parameterName + "'>A temporary " + dataType + " for passing values.</param>");
                WriteLine("/// <returns>A '" + dataType + "' object if found else a null '" + dataType + "'.</returns>");

                // Get classDeclaration
                string classDeclaration = "public " + dataType + " Find(" + dataType + " " + parameterName + ")";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial value
                WriteComment("Initial values");
               
                // Write Line For initial value
                string initialValue = dataType + " " + returnObjectName + " = null;";

                // Write initialValue
                WriteLine(initialValue);

                // Write Blank line
                WriteLine();

                // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                WriteComment("Get information for calling 'DataBridgeManager.PerformDataOperation' method.");

                // get methodName
                string methodNameLine = GetStringVariableLine("methodName", "Find");

                // Write MethodName
                WriteLine(methodNameLine);

                // get objectName
                string objectNameLine = GetStringVariableLine("objectName", "ApplicationLogicComponent.Controllers");

                // Write objectName
                WriteLine(objectNameLine);

                // Write Blank Line
                WriteLine();

                // Write try
                WriteLine("try");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment if data object exists
                WriteComment("If object exists");

                // Write Line if paramObject != null)
                WriteLine("if(" + parameterName + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create DataOperation
                WriteComment("Create DataOperation");
                
                // get line for delegate
                string delegateLine = "ApplicationController.DataOperationMethod " + delegateMethodName + " = this.AppController.DataBridge.DataOperations." + dataTable.ClassName + "Methods.Find" + dataTable.ClassName + ";";

                // Write delegateLine
                WriteLine(delegateLine);

                // Write Blank Line
                WriteLine();

                // Write Comment Create parameters for this method
                WriteComment("Create parameters for this method");

                // get line to create parameters
                string createParameterLine = "List<PolymorphicObject> parameters = Create" + dataTable.ClassName + "Parameter(" + parameterName + ");";

                // Write createParameterLine
                WriteLine(createParameterLine);
                
                // Write Blank Line
                WriteLine();

                // Write Comment  Perform DataOperation
                WriteComment("Perform DataOperation");

                // get performDataOperationLine
                string performDataOperationLine = "PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);";

                // Write performDataOperationLine
                WriteLine(performDataOperationLine);

                // Write Blank Line
                WriteLine();

                // Write Comment
                WriteComment("If return object exists");

                // Write if (returnObject != null)
                WriteLine("if ((returnObject != null) && (returnObject.ObjectValue as " + dataType + " != null))");

                // Write Open Bracket (
                WriteOpenBracket(true);

                // Write Comment Get ReturnObject
                WriteComment("Get ReturnObject");

                // line to get data object from return object.
                string returnObjectLine = returnObjectName + " = (" + dataType + ") returnObject.ObjectValue;";
                
                // Write dataObjectLine
                WriteLine(returnObjectLine);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write catch (Exception error)
                WriteLine("catch (Exception error)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  If ErrorProcessor exists
                WriteComment("If ErrorProcessor exists");

                // Write line to verify error processor exists
                WriteLine("if (this.ErrorProcessor != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Line To Log The Current Error
                WriteComment("Log the current error");

                // Write Line this.ErrorProcessor.LogError(methodName, objectName, error);
                WriteLine("this.ErrorProcessor.LogError(methodName, objectName, error);");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return deleted;
                WriteLine("return " + returnObjectName + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteInsertMethodIdentity(DataTable dataTable)
            /// <summary>
            /// This method writes the Insert method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteInsertMethodIdentity(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string returnObjectName = "newIdentity";
                string delegateMethodName = "insertMethod";
                string parameterName = this.CapitalizeFirstChar(dataType, true);

                // BeginRegion  #region Find(
                BeginRegion("Insert(" + dataType + " " + parameterName + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// Insert a '" + dataTable.ClassName + "' object into the database.");
                WriteLine("/// This method uses the DataBridgeManager to execute the 'Insert' using the");
              
                // local for query type
                string query = "procedure";
                
                // Complete the summary
                WriteLine("/// " + query + " '" + dataTable.ClassName + "_Insert'.</param>");
                WriteLine("/// </summary>");
                
                // Write parameter and return value
                WriteLine("/// <param name='" + parameterName + "'>The '" + dataType + "' object to insert.</param>");
                WriteLine("/// <returns>The id (int) of the new  '" + dataType + "' object that was inserted.</returns>");

                // Get classDeclaration
                string classDeclaration = "public int Insert(" + dataType + " " + parameterName + ")";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial value
                WriteComment("Initial values");

                // Write Line For initial value
                string initialValue = "int " + returnObjectName + " = -1;";

                // Write initialValue
                WriteLine(initialValue);

                // Write Blank line
                WriteLine();

                // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                WriteComment("Get information for calling 'DataBridgeManager.PerformDataOperation' method.");

                // get methodName
                string methodNameLine = GetStringVariableLine("methodName", "Insert");

                // Write MethodName
                WriteLine(methodNameLine);

                // get objectName
                string objectNameLine = GetStringVariableLine("objectName", "ApplicationLogicComponent.Controllers");

                // Write objectName
                WriteLine(objectNameLine);

                // Write Blank Line
                WriteLine();

                // Write try
                WriteLine("try");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment
                WriteComment("If " + dataType + "exists");

                // Write Line if Object != null)
                WriteLine("if(" + this.CapitalizeFirstChar(dataType, true) + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // get line for delegate
                string delegateLine = "ApplicationController.DataOperationMethod " + delegateMethodName + " = this.AppController.DataBridge.DataOperations." + dataTable.ClassName + "Methods.Insert" + dataTable.ClassName + ";";

                // Write delegateLine
                WriteLine(delegateLine);

                // Write Blank Line
                WriteLine();

                // Write Comment Create parameters for this method
                WriteComment("Create parameters for this method");

                // get line to create parameters
                string createParameterLine = "List<PolymorphicObject> parameters = Create" + dataTable.ClassName + "Parameter(" + this.CapitalizeFirstChar(dataType, true) + ");";

                // Write createParameterLine
                WriteLine(createParameterLine);
                
                // Write Blank Line
                WriteLine();

                // Write Comment  Perform DataOperation
                WriteComment("Perform DataOperation");

                // get performDataOperationLine
                string performDataOperationLine = "PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);";

                // Write performDataOperationLine
                WriteLine(performDataOperationLine);

                // Write Blank Line
                WriteLine();

                // Write Comment
                WriteComment("If return object exists");

                // Write if (returnObject != null)
                WriteLine("if (returnObject != null)");

                // Write Open Bracket (
                WriteOpenBracket(true);

                // Write Comment Set Return Object
                WriteComment("Set return value");

                // Get Line To Set Return Value
                string setReturnValue = returnObjectName + " = returnObject.IntegerValue;";

                // Write setReturnValue
                WriteLine(setReturnValue);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write CloseBracket
                WriteCloseBracket(true);

                // Write catch (Exception error)
                WriteLine("catch (Exception error)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  If ErrorProcessor exists
                WriteComment("If ErrorProcessor exists");

                // Write line to verify error processor exists
                WriteLine("if (this.ErrorProcessor != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Line To Log The Current Error
                WriteComment("Log the current error");

                // Write Line this.ErrorProcessor.LogError(methodName, objectName, error);
                WriteLine("this.ErrorProcessor.LogError(methodName, objectName, error);");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return deleted;
                WriteLine("return " + returnObjectName + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            } 
            #endregion

            #region WriteInsertMethodLookup(DataTable dataTable)
            /// <summary>
            /// This method writes the Insert method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteInsertMethodLookup(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string returnObjectName = "inserted";
                string delegateMethodName = "insertMethod";
                string parameterName = this.CapitalizeFirstChar(dataType, true);

                // BeginRegion  #region Find(
                BeginRegion("Insert(" + dataType + " " + parameterName + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// Insert a '" + dataTable.ClassName + "' object into the database.");
                WriteLine("/// This method uses the DataBridgeManager to execute the 'Insert' using the");
              
                // local for query type
                string query = "procedure";
                
                // Complete the summary
                WriteLine("/// " + query + " '" + dataTable.ClassName + "_Insert'.</param>");
                WriteLine("/// </summary>");
                
                // Write parameter and return value
                WriteLine("/// <param name='" + parameterName + "'>The '" + dataType + "' object to insert.</param>");
                WriteLine("/// <returns>True if successful or false if not.</returns>");

                // Get classDeclaration
                string classDeclaration = "public bool Insert(" + dataType + " " + parameterName + ")";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial value
                WriteComment("Initial values");

                // Write Line For initial value
                string initialValue = "bool " + returnObjectName + " = false;";

                // Write initialValue
                WriteLine(initialValue);

                // Write Blank line
                WriteLine();

                // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                WriteComment("Get information for calling 'DataBridgeManager.PerformDataOperation' method.");

                // get methodName
                string methodNameLine = GetStringVariableLine("methodName", "Insert");

                // Write MethodName
                WriteLine(methodNameLine);

                // get objectName
                string objectNameLine = GetStringVariableLine("objectName", "ApplicationLogicComponent.Controllers");

                // Write objectName
                WriteLine(objectNameLine);

                // Write Blank Line
                WriteLine();

                // Write try
                WriteLine("try");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment
                WriteComment("If " + dataType + "exists");

                // Write Line if Object != null)
                WriteLine("if(" + this.CapitalizeFirstChar(dataType, true) + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // get line for delegate
                string delegateLine = "ApplicationController.DataOperationMethod " + delegateMethodName + " = this.AppController.DataBridge.DataOperations." + dataTable.ClassName + "Methods.Insert" + dataTable.ClassName + ";";

                // Write delegateLine
                WriteLine(delegateLine);

                // Write Blank Line
                WriteLine();

                // Write Comment Create parameters for this method
                WriteComment("Create parameters for this method");

                // get line to create parameters
                string createParameterLine = "List<PolymorphicObject> parameters = Create" + dataTable.ClassName + "Parameter(" + this.CapitalizeFirstChar(dataType, true) + ");";

                // Write createParameterLine
                WriteLine(createParameterLine);
                
                // Write Blank Line
                WriteLine();

                // Write Comment  Perform DataOperation
                WriteComment("Perform DataOperation");

                // get performDataOperationLine
                string performDataOperationLine = "PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);";

                // Write performDataOperationLine
                WriteLine(performDataOperationLine);

                // Write Blank Line
                WriteLine();

                // Write a comment
                WriteComment("Set the return value to true");

                // Set the return value to true
                WriteLine(returnObjectName + " = true;");

                // Write CloseBracket
                WriteCloseBracket(true);
                
                // Write CloseBracket
                WriteCloseBracket(true);

                // Write catch (Exception error)
                WriteLine("catch (Exception error)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  If ErrorProcessor exists
                WriteComment("If ErrorProcessor exists");

                // Write line to verify error processor exists
                WriteLine("if (this.ErrorProcessor != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Set to false
                WriteComment("Set inserted to false");

                // Write the returnObjectName
                WriteLine(returnObjectName + " = false;");

                // Write Line To Log The Current Error
                WriteComment("Log the current error");

                // Write Line this.ErrorProcessor.LogError(methodName, objectName, error);
                WriteLine("this.ErrorProcessor.LogError(methodName, objectName, error);");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return deleted;
                WriteLine("return " + returnObjectName + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
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
                // If datatable exists
                if(dataTable != null)
                {
                    // Begin Region For Methods
                    BeginRegion("Methods");
                    
                    // Increase Indent
                    Indent++;
                    
                    // Write Create Object Parameter
                    WriteCreateObjectParameter(dataTable);

                    // If this table has a primary key and is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Write Delete Method
                        WriteDeleteMethod(dataTable);
                    }
                    
                    // Write FetchAllMethod
                    WriteFetchAllMethod(dataTable);

                    // If the dataTable has a primary key & this is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Write FindMethod
                        WriteFindMethod(dataTable);
                    }

                    // If the data table is not a view
                    if ((!dataTable.IsView) && (dataTable.HasPrimaryKey))
                    {  
                        // if this is an Identity column for the primary key
                        if (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber)
                        {
                            // Write Insert Method
                            WriteInsertMethodIdentity(dataTable);
                        }
                        else
                        {
                            // Write Insert Method for non Autonumber fields
                            WriteInsertMethodLookup(dataTable);
                        }
                    }

                    // If the dataTable has a primary key & this is not a view
                    if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                    {
                        // Write Save Method 
                        WriteSaveMethod(dataTable);

                        /// Write Update Method
                        WriteUpdateMethod(dataTable);

                        // Write Blank Line
                        WriteLine();
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

                // Write ErrorProcessor and ParentController
                WriteLine("private ErrorHandler errorProcessor;");
                WriteLine("private ApplicationController appController;");
                
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
                WriteProperty("AppController", "appController", "ApplicationController");
                
                // Write Property For ErrorProcessor
                WriteProperty("ErrorProcessor", "errorProcessor", "ErrorHandler");
                
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

            #region WriteSaveMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the Save Method
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteSaveMethod(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string returnObjectName = "saved";
                string parameterName = this.CapitalizeFirstChar(dataType, true);

                // BeginRegion  #region Find(
                BeginRegion("Save(ref " + dataType + " " + parameterName + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// Saves a '" + dataTable.ClassName + "' object into the database.");
                WriteLine("/// This method calls the 'Insert' or 'Update' method.");
                WriteLine("/// </summary>");

                WriteLine("/// <param name='" + parameterName + "'>The '" + dataType + "' object to save.</param>");
                WriteLine("/// <returns>True if successful or false if not.</returns>");
                
                // Get classDeclaration
                string classDeclaration = "public bool Save(ref " + dataType + " " + parameterName + ")";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial value
                WriteComment("Initial value");

                // Write Line For initial value
                string initialValue = "bool " + returnObjectName + " = false;";

                // Write initialValue
                WriteLine(initialValue);

                // Write Blank line
                WriteLine();

                // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                WriteComment("If the " + parameterName + " exists.");

                // Write Line if exists
                WriteLine("if(" + parameterName + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);
                
                // if this is an auto number field
                if (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber)
                {
                    // Write Comment Is This A New Record
                    WriteComment("Is this a new " + dataType);

                    // Write Line
                    WriteLine("if(" + parameterName + ".IsNew)");

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Comment Insert
                    WriteComment("Insert new " + dataType);

                    // Write line to insert new record
                    WriteLine("int newIdentity = this.Insert(" + parameterName + ");");

                    // Write Blank Line
                    WriteLine();

                    // Write Comment if insert was successful
                    WriteComment("if insert was successful");
                
                    // Write line if newIdentiy > 0
                    WriteLine("if(newIdentity > 0)");
                
                    // Write Open Bracket {
                    WriteOpenBracket(true);
                
                    // Write Comment  Update Identity
                    WriteComment("Update Identity");
                
                    // Write line to update the Identity
                    WriteLine(parameterName + ".UpdateIdentity(newIdentity);");

                    // Write Blank Line
                    WriteLine();

                    // Set return value
                    WriteComment("Set return value");

                    // Write line saved = true
                    WriteLine("saved = true;");

                    // Write }
                    WriteCloseBracket(true);

                    // Write }
                    WriteCloseBracket(true);

                    // Write Else
                    WriteLine("else");

                    // Write {
                    WriteOpenBracket(true);

                    // Write Comment Insert
                    WriteComment("Update " + dataType);

                    // Write line to insert new record
                    WriteLine(returnObjectName + " = this.Update(" + parameterName + ");");

                    // Write }
                    WriteCloseBracket(true);
                }
                else
                {
                    // Write a comment Since this is not an Autonumber field, we must attempt to look up this item before we decide to Insert or Update
                    WriteComment("Since this is not an Autonumber field, we must attempt to look up this item before we decide to Insert or Update");

                    // Write a blank line
                    WriteLine();

                    // Write Comment Look up this item to see if it already exists
                    WriteComment("Look up this item to see if it already exists");

                    // create the name of the tempObject
                    string tempObjectName = "temp" + dataTable.Name;

                    // Write the line to look up the temp object
                    WriteLine(dataTable.Name + " " + tempObjectName + " = this.Find(" + parameterName + ");");

                    // write a blank line
                    WriteLine();

                    // Write a comment to test if this object exists
                    WriteComment("Is this a new object ?");

                    // write out the line to test if this is a null object or not
                    WriteLine("bool isNew = (" + tempObjectName + " == null);");

                    // Write Blank line
                    WriteLine();

                    // Write a comment If this is a new object
                    WriteComment("If this is a new object");

                    // Write line to test for isNew
                    WriteLine("if (isNew)");

                    // Write the open bracket
                    WriteOpenBracket(true);

                    // Write Comment Perform the Insert
                    WriteComment("Perform the insert");

                    // now perform the insert
                    WriteLine("saved = this.Insert(" + parameterName + ");");

                    // Write a close bracket
                    WriteCloseBracket(true);

                    // Write a line for else
                    WriteLine("else");

                    // Write the open bracket
                    WriteOpenBracket(true);

                    // Write Comment Perform the Insert
                    WriteComment("Perform the update");

                    // now perform the insert
                    WriteLine("saved = this.Update(" + parameterName + ");");

                    // Write a close bracket
                    WriteCloseBracket(true);
                }

                // Write }
                WriteCloseBracket(true);

                // Write Blank line
                WriteLine();
                
                // Write Comment Return Value
                WriteComment("return value");
                
                // Write Return Value
                WriteLine("return " + returnObjectName + ";");
                
                // Decrease Indent
                Indent--;
                
                // Write }
                WriteCloseBracket();
                
                // Write EndRegion
                EndRegion();

                // Write Blank Line
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
                // get dataType
                string dataType = dataTable.ClassName;
                string returnObjectName = "saved";
                string delegateMethodName = "updateMethod";
                string parameterName = this.CapitalizeFirstChar(dataType, true);

                // BeginRegion  #region Find(
                BeginRegion("Update(" + dataType + " " + parameterName + ")");

                // Write Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method Updates a '" + dataTable.ClassName + "' object in the database.");
                WriteLine("/// This method used the DataBridgeManager to execute the 'Update' using the");

                // local for query type
                string query = "procedure";
                
                // Finish the summary.
                WriteLine("/// " + query + " '" + dataTable.ClassName + "_Update'.</param>");
                WriteLine("/// </summary>");

                // Add parameter and return values
                WriteLine("/// <param name='" + parameterName + "'>The '" + dataType + "' object to update.</param>");
                WriteLine("/// <returns>True if successful else false if not.</returns>");

                // Get classDeclaration
                string classDeclaration = "public bool Update(" + dataType + " " + this.CapitalizeFirstChar(dataType, true) + ")";

                // Write classDeclaration
                WriteLine(classDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial value
                WriteComment("Initial value");

                // Write Line For initial value
                string initialValue = "bool " + returnObjectName + " = false;";

                // Write initialValue
                WriteLine(initialValue);

                // Write Blank line
                WriteLine();

                // Write Comment Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                WriteComment("Get information for calling 'DataBridgeManager.PerformDataOperation' method.");

                // get methodName
                string methodNameLine = GetStringVariableLine("methodName", "Update");

                // Write MethodName
                WriteLine(methodNameLine);

                // get objectName
                string objectNameLine = GetStringVariableLine("objectName", "ApplicationLogicComponent.Controllers");

                // Write objectName
                WriteLine(objectNameLine);

                // Write Blank Line
                WriteLine();

                // Write try
                WriteLine("try");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Line if object != null)
                WriteLine("if(" + parameterName + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create Delegate
                WriteComment("Create Delegate");
                
                // get line for delegate
                string delegateLine = "ApplicationController.DataOperationMethod " + delegateMethodName + " = this.AppController.DataBridge.DataOperations." + dataTable.ClassName + "Methods.Update" + dataTable.ClassName + ";";

                // Write delegateLine
                WriteLine(delegateLine);

                // Write Blank Line
                WriteLine();

                // Write Comment Create parameters for this method
                WriteComment("Create parameters for this method");

                // get line to create parameters
                string createParameterLine = "List<PolymorphicObject> parameters = Create" + dataTable.ClassName + "Parameter(" + this.CapitalizeFirstChar(dataType, true) + ");";

                // Write createParameterLine
                WriteLine(createParameterLine);

                // Write Comment  Perform DataOperation
                WriteComment("Perform DataOperation");

                // get performDataOperationLine
                string performDataOperationLine = "PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);";

                // Write performDataOperationLine
                WriteLine(performDataOperationLine);

                // Write Blank Line
                WriteLine();

                // Write Comment
                WriteComment("If return object exists");

                // Write if (returnObject != null)
                WriteLine("if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))");

                // Write Open Bracket (
                WriteOpenBracket(true);

                // Write Comment Set Return Object
                WriteComment("Set saved to true");

                // Get Line To Set Return Value
                WriteLine("saved = true;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write CloseBracket
                WriteCloseBracket(true);

                // Write catch (Exception error)
                WriteLine("catch (Exception error)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment  If ErrorProcessor exists
                WriteComment("If ErrorProcessor exists");

                // Write line to verify error processor exists
                WriteLine("if (this.ErrorProcessor != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Line To Log The Current Error
                WriteComment("Log the current error");

                // Write Line this.ErrorProcessor.LogError(methodName, objectName, error);
                WriteLine("this.ErrorProcessor.LogError(methodName, objectName, error);");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment For Return Value
                WriteComment("return value");

                // Write return deleted;
                WriteLine("return " + returnObjectName + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();
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
            public DataJuggler.Net.ReferencesSet ObjectReferences
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

            #region SelectedProject
            /// <summary>
            /// This property gets or sets the value for 'SelectedProject'.
            /// </summary>
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
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
