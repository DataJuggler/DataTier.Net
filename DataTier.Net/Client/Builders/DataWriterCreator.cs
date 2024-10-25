

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using DataJuggler.Net;
using DataTier.Net.StoredProcedureGenerator;
using System.Text;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{

    #region class DataWriterCreator : CSharpClassWriter
    /// <summary>
    /// This class is used to create a data object reader 
    /// </summary>
	public class DataWriterCreator : CSharpClassWriter
	{

		#region Private Variables
        private List<DataTable> dataTables;
        private ReferencesSet objectReferences;
        private string rootDataWriterPath;
        private string nameSpaceName;
        private bool baseClassPass;
		#endregion

        #region Default Constructor
        /// <summary>
        /// Create a new instance of DataWriterCreator
        /// </summary>
        public DataWriterCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string rootDataWriterPathArg, string nameSpaceNameArg, ProjectFileManager fileManager, TargetFrameworkEnum targetFramework) : base(fileManager, false, false, targetFramework)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.NameSpaceName = nameSpaceNameArg;
		    this.ObjectReferences = objectReferencesArg;
		    this.RootDataWriterPath = rootDataWriterPathArg;
		}
		#endregion

        #region Methods

            #region CreateFileName(DataTable dataTable)
            /// <summary>
            /// Create the file name for this reader.
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            private string CreateFileName(DataTable dataTable)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(this.RootDataWriterPath);
                
                // If does not end with a backslash
                if(!this.RootDataWriterPath.EndsWith(@"\"))
                {
                    // Append Backslash
                    sb.Append(@"\");
                }
                
                // append the class name
                sb.Append(dataTable.ClassName);
                
                // Add The Word Writer
                sb.Append("Writer");
                
                // if this is the base class pass
                if(BaseClassPass)
                {
                    // append the word base if the base class pass
                    sb.Append("Base");
                }
                
                // Append .cs
                sb.Append(".cs");
                
                // return value
                return sb.ToString();
            } 
            #endregion

            #region CreateObjectWriter(DataTable dataTable)
            /// <summary>
            /// Create an object writer for the table passed in.
            /// </summary>
            public void CreateObjectWriter(DataTable dataTable)
            {
                try
                {
                    // locals
                    string fileName = null;
                    bool fileExists = false;
                    bool writeFile = false;

                    // Set Indent To 0
                    Indent = 0;

                    // verify DataTable exist
                    if (dataTable != null)
                    {
                        // Get the object writer file name
                        fileName = CreateFileName(dataTable);

                        // set write file
                        if (BaseClassPass)
                        {
                            // set write file to true
                            writeFile = true;
                        }
                        else
                        {
                            // if the file already exists and 
                            // this is not the BaseClassPass
                            fileExists = System.IO.File.Exists(fileName);

                            // if the file does not exist for the
                            // inherited class then write it.
                            if (!fileExists)
                            {
                                // set write file to true
                                writeFile = true;
                            }
                        }

                        // if this file should be written
                        if (writeFile)
                        {
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
                            WriteOpenBracket(true);

                            // Write Blank Line
                            WriteLine();

                            // Get ClassName
                            string className = dataTable.ClassName + "Writer";

                            // if this is the pass for the base class
                            if (this.BaseClassPass)
                            {
                                // set class name without base
                                className = className + "Base";
                            }

                            // Write Region for this reader
                            BeginRegion("class " + className);

                            // Write Object Writer Summary
                            WriteClassSummary(dataTable);

                            // get class line
                            string classLine = null;

                            // if this is the base class pass again
                            if (BaseClassPass)
                            {
                                // get class line
                                classLine = "public class " + className;
                            }
                            else
                            {
                                // get class line
                                classLine = "public class " + className + " : " + className + "Base";
                            }

                            // Write ClassLine
                            WriteLine(classLine);

                            // Write Open Brack
                            WriteOpenBracket(true);

                            // Write Blank Line
                            WriteLine();

                            // Begin Region Static Methods
                            BeginRegion("Static Methods");

                            // Increase Indent
                            Indent++;

                            // Write Static Methods
                            WriteStaticMethods(dataTable);

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

                            // Write Close Bracket
                            WriteCloseBracket(true);

                            // Close This File
                            this.Writer.Close();
                        }
                    }
                }
                catch (Exception error)
                {
                    // Set the failed reason
                    this.FailedReason = error.ToString();
                }
            }
            #endregion

            #region CreateObjectWriters()
            /// <summary>
            /// Create object readers
            /// </summary>
            public void CreateObjectWriters()
            {
                try
                {
                    // verify 
                    if (this.DataTables != null)
                    {
                        // loop through each table
                        foreach (DataTable dataTable in this.DataTables)
                        {
                            // First Create Base Class
                            this.BaseClassPass = true;

                            // Create an object writer base class for this table
                            CreateObjectWriter(dataTable);

                            // Now create object writers for the 
                            // inherited class
                            this.BaseClassPass = false;

                            // Create an object writer for this table
                            CreateObjectWriter(dataTable);
                        }
                    }
                }
                catch (Exception error)
                {
                    // Set the FailedReason
                    this.FailedReason = error.ToString();
                }
            }
            #endregion

            #region WriteAddCustomMethodsComment()
            /// <summary>
            /// This method writes the Add Custom Methods Comment
            /// To Place 
            /// </summary>
            private void WriteAddCustomMethodsComment()
            {
                // Write Blank Line
                WriteLine();
            
                WriteComment("*******************************************");
                WriteComment("Write any overrides or custom methods here.");
                WriteComment("*******************************************");

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteClassSummary(DataTable dataTable)
            /// <summary>
            /// This method writes the summary for the data object writer.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteClassSummary(DataTable dataTable)
            {
                WriteLine("/// <summary>");
                WriteLine("/// This class is used for converting a '" + dataTable.ClassName + "' object to");
                WriteLine("/// the SqlParameter[] to perform the CRUD methods.");
                WriteLine("/// </summary>");
            }
            #endregion
       
            #region WriteCreatePrimaryKeyParameterMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the WriteCreatePrimaryKeyParameterMethod
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreatePrimaryKeyParameterMethod(DataTable dataTable)
            {
                // local
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string parameterName = "@" + dataTable.PrimaryKey.FieldName;
                
                // Write Begin Region Method
                BeginRegion("CreatePrimaryKeyParameter(" + dataType + " " + dataObject + ")");
                
                // Write Method Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates the sql Parameter[] array");
                WriteLine("/// that holds the primary key value.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name='" + dataObject + "'>The '" + dataType + "' to get the primary key of.</param>");
                WriteLine("/// <returns>A SqlParameter[] array which contains the primary key value.");
                WriteLine("/// to delete.</returns>");
                
                // Write class declaration line
                WriteLine("internal static SqlParameter[] CreatePrimaryKeyParameter(" + dataType + " " + dataObject + ")");
                
                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Value");
                
                // Write The Initial Value For parameters
                WriteLine("SqlParameter[] parameters = new SqlParameter[1];");
                
                // Write Blank Line
                WriteLine();

                // Write Comment verify user exists
                WriteComment("verify user exists");
                
                // Write line to test if user exists
                WriteLine("if (" + dataObject + " != null)");
                
                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Create PrimaryKey parameter
                WriteComment("Create PrimaryKey Parameter");
                
                // Now Create Delete Parameter
                string parameterLine = "SqlParameter " + parameterName + " = new SqlParameter(" + (char) 34 + parameterName + (char) 34 + ", " + dataObject + "." + dataTable.PrimaryKey.FieldName + ");";
                WriteLine(parameterLine);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment
                WriteComment("Set parameters[0] to " + parameterName);
                
                // Now write line to set parameters[0]
                WriteLine("parameters[0] = " + parameterName + ";");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment
                WriteComment("return value");
                
                // Write return value
                WriteLine("return parameters;");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write EndRegion
                EndRegion();
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteCreateDeleteStoredProcedureMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the CreateDeleteStoredProcedureMethod.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateDeleteStoredProcedureMethod(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string procDataType = "Delete" + dataTable.ClassName + "StoredProcedure";
                string procInstance = this.CapitalizeFirstChar(procDataType, true);
                string parameterName = "@" + dataTable.PrimaryKey.FieldName;
                
                // Write Line
                BeginRegion("Create" + procDataType + "(" + dataType + " " + dataObject + ")");

                // Write method summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates an instance of an");
                WriteLine("/// 'Delete" + dataTable.ClassName + "'StoredProcedure' object and");
                WriteLine("/// creates the sql parameter[] array needed");

                // string query
                string query = "procedure";

                // Complete the summary
                WriteLine("/// to execute the " + query + " '" + dataTable.ClassName + "_Delete'.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name=" + (char) 34 + dataObject + (char) 34 + ">The '" + dataType + "' to Delete.</param>");
                WriteLine("/// <returns>An instance of a 'Delete" + dataTable.ClassName + "StoredProcedure' object.</returns>");
                
                // get class declaration line
                string classDeclaration = "public static " + procDataType + " Create" + procDataType + "(" + dataType + " " + dataObject + ")";
                
                // Write classDeclaration
                WriteLine(classDeclaration);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment Initial Value
                WriteComment("Initial Value");
                
                // Write line to instanciate Proc
                WriteLine(procDataType + " " + procInstance + " = new " + procDataType + "();");
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment Now Create Parameters For The Delete Proc
                WriteComment("Now Create Parameters For The DeleteProc");
                
                // Write Line To Create Parameters
                WriteLine(procInstance + ".Parameters = CreatePrimaryKeyParameter(" + dataObject + ");");
                
                // Write Blank Line
                WriteLine();
                
                // Write Comment return value
                WriteComment("return value");
                
                // Write Return Value
                WriteLine("return " + procInstance + ";");

                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write End Region
                EndRegion();
                
                // Write Line
                WriteLine();
            }
            #endregion

            #region WriteCreateFetchAllStoredProcedureMethod(DataTable dataTable)
            /// <summary>
            /// This method writes the CreateFetchAllStoredProcedureMethod.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateFetchAllStoredProcedureMethod(DataTable dataTable)
            {
                try
                {
                    // locals
                    string dataType = dataTable.ClassName;
                    string dataObject = this.CapitalizeFirstChar(dataType, true);
                    string className = dataTable.ClassName;
                    
                    // get the class name in plural for this method
                    className = PluralWordHelper.GetPluralName(className, false);

                    string procDataType = "FetchAll" + className + "StoredProcedure";
                    string procInstance = this.CapitalizeFirstChar(procDataType, true);

                    // Write Begin Region
                    BeginRegion("Create" + procDataType + "(" + dataType + " " + dataObject + ")");

                    // Write method summary
                    WriteLine("/// <summary>");
                    WriteLine("/// This method creates an instance of a");
                    WriteLine("/// 'FetchAll" + className + "StoredProcedure' object and");
                    WriteLine("/// creates the sql parameter[] array needed");

                    // string query
                    string query = "procedure";

                    // Complete the summary
                    WriteLine("/// to execute the " + query + " '" + dataTable.ClassName + "_FetchAll'.");
                    WriteLine("/// </summary>");
                    WriteLine("/// <returns>An instance of a(n) '" + procDataType + "' object.</returns>");

                    // get class declaration line
                    string classDeclaration = "public static " + procDataType + " Create" + procDataType + "(" + dataType + " " + dataObject + ")";

                    // Write class declaration
                    WriteLine(classDeclaration);

                    // Write Open Bracket
                    WriteOpenBracket(true);

                    // Write Comment Initial Value
                    WriteComment("Initial value");

                    // get initial value line
                    string initialValueLine = procDataType + " " + procInstance + " = new " + procDataType + "();";

                    // Write initialValueLine
                    WriteLine(initialValueLine);

                    // Write Blank Line
                    WriteLine();

                    // Write Comment Return Value
                    WriteComment("return value");

                    // Write return value
                    WriteLine("return " + procInstance + ";");

                    // Write Close Bracket
                    WriteCloseBracket(true);

                    // Write End Region 
                    EndRegion();

                    // Write Blank Line
                    WriteLine();
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // raise the error
                    throw error;
                }
            }
            #endregion

            #region WriteCreateFindStoredProcedureMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the Find Stored Procedure Method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateFindStoredProcedureMethod(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string className = dataTable.ClassName;
                string parameterName = "@" + dataTable.PrimaryKey.FieldName + ";";
                string procDataType = "Find" + className + "StoredProcedure";
                string procInstance = this.CapitalizeFirstChar(procDataType, true);
                
                // Write Region For This Method
                BeginRegion("Create" + procDataType + "(" + dataType + " " + dataObject + ")");

                // Write method summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates an instance of a");
                WriteLine("/// '" + procDataType + "' object and");
                WriteLine("/// creates the sql parameter[] array needed");

                // string query
                string query = "procedure";
                
                // Complete the summary
                WriteLine("/// to execute the " + query + " '" + dataTable.ClassName + "_Find'.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name=" + (char) 34 + dataObject + (char) 34 + ">The '" + dataType + "' to use to");
                WriteLine("/// get the primary key parameter.</param>");
                WriteLine("/// <returns>An instance of an FetchUserStoredProcedure</returns>");
                
                // get method declaration line
                string methodDeclaration = "public static " + procDataType + " Create" + procDataType + "(" + dataType + " " + dataObject + ")";

                // Write method declaration
                WriteLine(methodDeclaration);
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write Comment Initial Value
                WriteComment("Initial Value");
                
                // Write line to declare proc
                WriteLine(procDataType + " " + procInstance + " = null;");
                
                // Write Blank Line
                WriteLine();

                // Write Comment verify object exists
                WriteComment("verify " + dataObject + " exists");
                
                // Now write line to test if dataObject exists
                WriteLine("if(" + dataObject + " != null)");
                
                // Write Open Bracket
                WriteOpenBracket(true);
                
                // Write comment instanciate procedure
                WriteComment("Instanciate " + procInstance);
                
                // Now write line to instanciate procedure
                WriteLine(procInstance + " = new " + procDataType + "();");
                
                // Write blank line
                WriteLine();
                
                // Write Comment Now create parameters
                WriteComment("Now create parameters for this procedure");
                
                // Now create parameters
                WriteLine(procInstance + ".Parameters = CreatePrimaryKeyParameter(" + dataObject + ");");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write blank line
                WriteLine();
                
                // Write comment return value
                WriteComment("return value");
                
                // now write return value
                WriteLine("return " + procInstance + ";");
                
                // Write Close Bracket
                WriteCloseBracket(true);
                
                // Write EndRegion
                EndRegion();
                
                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteCreateInsertParameters(DataTable dataTable)
            /// <summary>
            /// This method creates the Insert Parameters
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateInsertParameters(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string procDataType = "Insert" + dataTable.ClassName + "StoredProcedure";
                string procInstance = this.CapitalizeFirstChar(procDataType, true);                
                bool writePrimaryKey = false;
                bool skipfield = false;
                int count = 0;

                // if the PrimaryKey exists and is an Identity column
                if ((dataTable.HasPrimaryKey) && (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber))
                {
                    // set the count
                    count = dataTable.Fields.Count - 1;
                }
                else
                {
                    // set the count
                    count = dataTable.Fields.Count;
                }
                
                // Begin Region
                BeginRegion("CreateInsertParameters(" + dataType + " " + dataObject + ")");

                // Write method summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates the sql Parameters[] needed for");
                WriteLine("/// inserting a new " + dataObject + ".");
                WriteLine("/// </summary>");
                WriteLine("/// <param name=" + (char)34 + dataObject + (char)34 + ">The '" + dataType + "' to insert.</param>");
                WriteLine("/// <returns></returns>");

                // get method declarationLine
                string methodDeclaration = "internal static SqlParameter[] CreateInsertParameters(" + dataType + " " + dataObject + ")";

                // write method declaration
                WriteLine(methodDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Values");

                // now write the declaration of SqlParameter[] parameters = SqlParameter[] parameters = new SqlParameter[count];
                WriteLine("SqlParameter[] parameters = new SqlParameter[" + count.ToString() + "];");
                WriteLine("SqlParameter param = null;");

                // Write Blank Line
                WriteLine();

                // Write Comment verify object exists
                WriteComment("verify " + dataObject + "exists");

                // now write line to verify object exists
                WriteLine("if(" + dataObject + " != null)");

                // Write open bracket
                WriteOpenBracket(true);

                // reset count to -1
                count = -1;

                // if the table has a primary key and the primaryKey.DataType is not an Identity column
                if ((dataTable.HasPrimaryKey) && (dataTable.PrimaryKey.DataType != DataManager.DataTypeEnum.Autonumber))
                {
                    // since this is not an Identity column, we must write out the primary key
                    writePrimaryKey = true;
                }

                // Create Each Parameter
                foreach (DataField field in dataTable.ActiveFields)
                {
                    // reset the value for skipField
                    skipfield = false;
                    
                    // if this is the primary key and writePrimaryKey is false
                    if ((field.PrimaryKey) && (!writePrimaryKey))
                    {
                        // the primary key should be skipped since this is an Identity column
                        skipfield = true;
                    }

                    // if this field should NOT be skipped
                    if (!skipfield)
                    {
                        // Increment Count
                        count++;

                        // Write a blank line between parameters after the first
                        // one.
                        if (count > 0)
                        {
                            // Write blank line
                            WriteLine();
                        }
                        
                        // if this is a dateTime
                        if (field.DataType == DataManager.DataTypeEnum.DateTime)
                        {
                            // Write the data parameter
                            WriteDateParameter(dataObject, field);
                        }
                        else
                        {
                            // Write Comment Create Parameter For [field]
                            WriteComment("Create [" + field.FieldName + "] parameter");
                        
                            // create a sql parameter for this field
                            string paramLine = "param = new SqlParameter(" + (char)34 + "@" + field.FieldName + (char)34 + ", " + dataObject + "." + field.FieldName + ");"; ;
                            
                            // Write paramLine
                            WriteLine(paramLine);
                            
                            // Write Blank Line
                            WriteLine();
                        }
                        
                         // Write Comment
                        WriteComment("set parameters[" + count.ToString() + "]");
                        
                        // Now add param to parameters
                        WriteLine("parameters[" + count.ToString() + "] = param;");
                    }
                }

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment
                WriteComment("return value");

                // Write return value
                WriteLine("return parameters;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteCreateInsertStoredProcedureMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the Insert Stored Procedure Method
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateInsertStoredProcedureMethod(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string className = dataTable.ClassName;
                string procDataType = "Insert" + className + "StoredProcedure";
                string procInstance = this.CapitalizeFirstChar(procDataType, true);

                // Begin Region For CreateInsertStoredProcedureMethod
                BeginRegion("Create" + procDataType + "(" + dataType + " " + dataObject + ")");

                // Write Class Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates an instance of an");
                WriteLine("/// '" + procDataType + "' object and");
                WriteLine("/// creates the sql parameter[] array needed");

                // string query
                string query = "procedure";

                WriteLine("/// to execute the " + query + " '" + className + "_Insert'.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name=" + (char)34 + dataObject + (char)34 + "The '" + dataType + "' object to insert</param>");
                WriteLine("/// <returns>An instance of a '" + procDataType + "' object.</returns>");

                // get method declaration line
                string methodDeclarationLine = "public static " + procDataType + " Create" + procDataType + "(" + dataType + " " + dataObject + ")";

                // write methodDeclarationLine
                WriteLine(methodDeclarationLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Value");

                // Declare Proc
                WriteLine(procDataType + " " + procInstance + " = null;");

                // Write blank line
                WriteLine();

                // Write Close Bracket
                // Write Comment verify object exists
                WriteComment("verify " + dataObject + " exists");

                // Now write line to test if dataObject exists
                WriteLine("if(" + dataObject + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write comment instanciate procedure
                WriteComment("Instanciate " + procInstance);

                // Now write line to instanciate procedure
                WriteLine(procInstance + " = new " + procDataType + "();");

                // Write blank line
                WriteLine();

                // Write Comment Now create parameters
                WriteComment("Now create parameters for this procedure");

                // Now create parameters
                WriteLine(procInstance + ".Parameters = CreateInsertParameters(" + dataObject + ");");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write blank line
                WriteLine();

                // Write comment return value
                WriteComment("return value");

                // now write return value
                WriteLine("return " + procInstance + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteCreateUpdateParameters(DataTable dataTable)
            /// <summary>
            /// This method writes the CreateUpdateParameters method.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateUpdateParameters(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string procDataType = "Update" + dataTable.ClassName + "StoredProcedure";
                string procInstance = this.CapitalizeFirstChar(procDataType, true);
                string parameterName = "@" + dataTable.PrimaryKey.FieldName;
                string paramLine = "";
                
                // the number fields in param array
                int count = dataTable.ActiveFields.Count;

                // Begin Region
                BeginRegion("CreateUpdateParameters(" + dataType + " " + dataObject + ")");

                // Write method summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates the sql Parameters[] needed for");
                WriteLine("/// update an existing " + dataObject + ".");
                WriteLine("/// </summary>");
                WriteLine("/// <param name=" + (char)34 + dataObject + (char)34 + ">The '" + dataType + "' to update.</param>");
                WriteLine("/// <returns></returns>");

                // get method declarationLine
                string methodDeclaration = "internal static SqlParameter[] CreateUpdateParameters(" + dataType + " " + dataObject + ")";

                // write method declaration
                WriteLine(methodDeclaration);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Values");

                // now write the declaration of SqlParameter[] parameters = SqlParameter[] parameters = new SqlParameter[count];
                WriteLine("SqlParameter[] parameters = new SqlParameter[" + count.ToString() + "];");
                WriteLine("SqlParameter param = null;");
                
                // Write blank line
                WriteLine();

                // Write Comment verify object exists
                WriteComment("verify " + dataObject + "exists");

                // now write line to verify object exists
                WriteLine("if(" + dataObject + " != null)");

                // Write open bracket
                WriteOpenBracket(true);

                // reset count 
                count = -1;

                // Create Each Parameter
                foreach (DataField field in dataTable.ActiveFields)
                {
                    // create a parameter for each field as long as it is not the primary key
                    if (!field.PrimaryKey)
                    {
                        // Increment Count
                        count++;
                        
                        // Write a blank line between parameters after the first
                        // one.
                        if(count > 0)
                        {
                            // Write blank line
                            WriteLine();
                        }
                        
                        // Write comment create parameter for [fieldName]
                        WriteComment("Create parameter for ["  + field.FieldName + "]");
                        
                        // if this is a dateTime
                        if (field.DataType == DataManager.DataTypeEnum.DateTime)
                        {   
                            // Write Date Parameter
                            WriteDateParameter(dataObject, field);
                        }
                        else
                        {
                            // This is not a date write out as usual

                            // create a sql parameter for this field
                            paramLine = "param = new SqlParameter(" + (char)34 + "@" + field.FieldName + (char)34 + ", " + dataObject + "." + field.FieldName + ");"; ;    
                            
                            // Write paramLine
                            WriteLine(paramLine);
                        }
                        
                        // Write Line
                        WriteLine();
                        
                        // Write Comment
                        WriteComment("set parameters[" + count.ToString() + "]");
                        
                        // Now add param to parameters
                        WriteLine("parameters[" + count.ToString() + "] = param;");
                    }
                }

                // Write a blank line between parameters after the first one.
                if (count > 0)
                {
                    // Write blank line
                    WriteLine();
                }

                // Increment Count
                count++;

                // Write comment create parameter for [fieldName]
                WriteComment("Create parameter for [" + dataTable.PrimaryKey.FieldName + "]");

                // create a sql parameter for this field
                paramLine = "param = new SqlParameter(" + (char)34 + "@" + dataTable.PrimaryKey.FieldName + (char)34 + ", " + dataObject + "." + dataTable.PrimaryKey.FieldName + ");"; ;

                // Write paramLine
                WriteLine(paramLine);

                // Now add param to parameters
                WriteLine("parameters[" + count.ToString() + "] = param;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write Blank Line
                WriteLine();

                // Write Comment
                WriteComment("return value");

                // Write return value
                WriteLine("return parameters;");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteCreateUpdateStoredProcedureMethod(DataTable dataTable)
            /// <summary>
            /// This method creates the CreateUpdateStoredProcedureMethod
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteCreateUpdateStoredProcedureMethod(DataTable dataTable)
            {
                // locals
                string dataType = dataTable.ClassName;
                string dataObject = this.CapitalizeFirstChar(dataType, true);
                string className = dataTable.ClassName;
                string parameterName = "@" + dataTable.PrimaryKey.FieldName + ";";
                string procDataType = "Update" + className + "StoredProcedure";
                string procInstance = this.CapitalizeFirstChar(procDataType, true);

                // Begin Region For CreateUpdateStoredProcedureMethod
                BeginRegion("Create" + procDataType + "(" + dataType + " " + dataObject + ")");

                // Write Class Summary
                WriteLine("/// <summary>");
                WriteLine("/// This method creates an instance of an");
                WriteLine("/// '" + procDataType + "' object and");
                WriteLine("/// creates the sql parameter[] array needed");

                // string query
                string query = "procedure";

                WriteLine("/// to execute the " + query + " '" + className + "_Update'.");
                WriteLine("/// </summary>");
                WriteLine("/// <param name=" + (char)34 + dataObject + (char)34 + "The '" + dataType + "' object to update</param>");
                WriteLine("/// <returns>An instance of a '" + procDataType + "</returns>");

                // get method declaration line
                string methodDeclarationLine = "public static " + procDataType + " Create" + procDataType + "(" + dataType + " " + dataObject + ")";

                // write methodDeclarationLine
                WriteLine(methodDeclarationLine);

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write Comment Initial Value
                WriteComment("Initial Value");

                // Declare Proc
                WriteLine(procDataType + " " + procInstance + " = null;");

                // Write blank line
                WriteLine();

                // Write Close Bracket
                // Write Comment verify object exists
                WriteComment("verify " + dataObject + " exists");

                // Now write line to test if dataObject exists
                WriteLine("if(" + dataObject + " != null)");

                // Write Open Bracket
                WriteOpenBracket(true);

                // Write comment instanciate procedure
                WriteComment("Instanciate " + procInstance);

                // Now write line to instanciate procedure
                WriteLine(procInstance + " = new " + procDataType + "();");

                // Write blank line
                WriteLine();

                // Write Comment Now create parameters
                WriteComment("Now create parameters for this procedure");

                // Now create parameters
                WriteLine(procInstance + ".Parameters = CreateUpdateParameters(" + dataObject + ");");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write blank line
                WriteLine();

                // Write comment return value
                WriteComment("return value");

                // now write return value
                WriteLine("return " + procInstance + ";");

                // Write Close Bracket
                WriteCloseBracket(true);

                // Write EndRegion
                EndRegion();

                // Write Blank Line
                WriteLine();
            }
            #endregion

            #region WriteDateParameter(DataField field)
            /// <summary>
            /// This method writes out the DateParameter.
            /// It handles dates as 1/1/1900 if they are null.
            /// </summary>
            /// <param name="field"></param>
            private void WriteDateParameter(string objectName, DataField field)
            {
                // if the field exists
                if ((field != null) && (field.DataType == DataManager.DataTypeEnum.DateTime))
                {
                    // get the object and fieldName
                    string objectAndFieldName = objectName + "." + field.FieldName;
                    
                    // Write Comment Create DateTime parameter
                    WriteComment("Create [" + field.FieldName + "] Parameter");
                    
                    // create a sql parameter for this field
                    string paramLine = "param = new SqlParameter(" + (char)34 + "@" + field.FieldName + (char)34 + ", SqlDbType.DateTime);";
                    WriteLine(paramLine);
                        
                    // Write Blank Line
                    WriteLine();
                    
                    // Write Comment 
                    WriteComment("If " + objectAndFieldName + " does not exist.");
                    
                    // Write line to test 
                    WriteLine("if (" + objectAndFieldName + ".Year < 1900)");
                    
                    // Write Open Bracket and increase Identity
                    WriteOpenBracket(true);
                    
                    // Write Comment
                    WriteComment("Set the value to 1/1/1900");
                    WriteLine("param.Value = new DateTime(1900, 1, 1);");
                    
                    // Write Close Bracket and decrease Identity
                    WriteCloseBracket(true);
                    
                    // Write else
                    WriteLine("else");
                    
                    // Write Open Bracket and increase Identity
                    WriteOpenBracket(true);
                    
                    // Write Comment Set the value of the object
                    WriteComment("Set the parameter value");
                    
                    // Set the value
                    WriteLine("param.Value = " + objectAndFieldName + ";");
                    
                    // Write Close Bracket
                    WriteCloseBracket(true);
                }
            } 
            #endregion

            #region WriteStaticMethods(DataTable dataTable)
            /// <summary>
            /// This method writes the static methods for this object.
            /// </summary>
            /// <param name="dataTable"></param>
            private void WriteStaticMethods(DataTable dataTable)
            {
                // If the data table exists
                if (dataTable != null)
                {
                    // If this is the base class pass
                    if (baseClassPass)
                    {
                        // The base class will contain all the static methods.

                        // Write Blank Line
                        WriteLine();

                        // For views do not create the other methods
                        if (dataTable.IsView)
                        {
                            // Write Create Fetch All Stored Procedure
                            WriteCreateFetchAllStoredProcedureMethod(dataTable);
                        }
                        else
                        {
                            // If the PrimaryKey exists
                            if (dataTable.HasPrimaryKey)
                            {
                                // Write CreateDeleteParameter
                                WriteCreatePrimaryKeyParameterMethod(dataTable);

                                // Write Create Delete Stored Procedure
                                WriteCreateDeleteStoredProcedureMethod(dataTable);

                                // Write the find method
                                WriteCreateFindStoredProcedureMethod(dataTable);
                            }

                            // Write Create Insert Parameters
                            WriteCreateInsertParameters(dataTable);

                            // Write Create Insert Stored Procedure Method
                            WriteCreateInsertStoredProcedureMethod(dataTable);

                            // If the table has a primary key
                            if (dataTable.HasPrimaryKey)
                            {
                                // Write Create Update Parameters
                                WriteCreateUpdateParameters(dataTable);

                                // Write Create Update Stored Procedure Method
                                WriteCreateUpdateStoredProcedureMethod(dataTable);
                            }

                            // Write Create Fetch All Stored Procedure
                            WriteCreateFetchAllStoredProcedureMethod(dataTable);
                        }
                    }
                    else
                    {
                        // The inherited class will only have a comment for 
                        // add custom methods or overries here.
                        WriteAddCustomMethodsComment();
                    }
                }
            }
            #endregion

        #endregion			
	
		#region Properties

            #region BaseClassPass
            /// <summary>
            /// This property is used to determine if this is
            /// writing the base class or the inherited 
            /// object writer.
            /// </summary>
            public bool BaseClassPass
            {
                get { return baseClassPass; }
                set { baseClassPass = value; }
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

            #region RootDataWriterPath
            /// <summary>
            /// The root path to create the file from.
            /// </summary>
            public string RootDataWriterPath
            {
                get { return rootDataWriterPath; }
                set { rootDataWriterPath = value; }
            } 
            #endregion
    		
		#endregion

	}
	#endregion	
	
}
