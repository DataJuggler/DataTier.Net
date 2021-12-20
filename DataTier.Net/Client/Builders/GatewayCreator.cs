

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataJuggler.Net;
using System.IO;
using DataTierClient.Objects;
using DataTierClient.ClientUtil;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{

    #region class GatewayCreator
    /// <summary>
    /// This class is used to create the Gateway and the methods for each table:
    /// Delete, Find, Load (Collection), and Save.
    /// </summary>
    public class GatewayCreator : CSharpClassWriter
    {
        
        #region Private Variables
        private List<DataTable> dataTables;
        private string projectName;
        private string gatewayPath;
        private string nameSpaceName;
        private ReferencesSet objectReferences;
        #endregion

        #region Constructor
		/// <summary>
        /// Create a new instance of GatewayCreator
        /// </summary>
        public GatewayCreator(List<DataTable> dataTablesArg, ReferencesSet objectReferencesArg, string gatewayPathArg, string projectNameArg, string nameSpaceNameArg, ProjectFileManager fileManager, TargetFrameworkEnum targetFramework) : base(fileManager, false, false, targetFramework)
		{   
		    // Set Properties
		    this.DataTables = dataTablesArg;
		    this.ProjectName = projectNameArg;
		    this.NameSpaceName = nameSpaceNameArg;
		    this.GatewayPath = gatewayPathArg;
		    this.ObjectReferences = objectReferencesArg;
		}
		#endregion

        #region Methods

            #region CreateGatewayMethods()
            /// <summary>
            /// This method Create Gateway Methods
            /// </summary>
            internal void CreateGatewayMethods()
            {
                // if the GatewayPath exists
                if ((this.HasGatewayPath) && (File.Exists(this.GatewayPath)) && (this.DataTables != null))
                {
                    // set the text of the existing Gateway
                    string gatewayText = File.ReadAllText(this.GatewayPath);
                    
                    // get the lines from the existing gateway
                    List<TextLine> lines = WordParser.GetTextLines(gatewayText);

                    // if there are lines we can proceed
                    if (ListHelper.HasOneOrMoreItems(lines))
                    {
                        // Write the backup of the orginal file
                        WriteBackupFile(this.GatewayPath);

                        // iterate the DataTables
                        foreach (DataTable dataTable in this.DataTables)
                        {
                            // Update 12.19.2012: if there is a primary key & not a view 
                            if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                            {
                                // write the Delete method
                                WriteDeleteMethod(dataTable, lines);

                                // write the Find method
                                WriteFindMethod(dataTable, lines);
                            }
                            
                            // Always write the load method
                            WriteLoadMethod(dataTable, lines);

                            // Update 12.19.2012: if there is a primary key & not a view 
                            if ((dataTable.HasPrimaryKey) && (!dataTable.IsView))
                            {
                                // write the Save method
                                WriteSaveMethod(dataTable, lines);
                            }
                        }

                        // overwrite the existing file on save
                        WriteGatewayFile(lines);
                    }
                    else
                    {
                        // raise an exception so the build fails
                        throw new Exception("Could not load existing Gateway file.");
                    }
                }
                else
                {
                    // if the DataTables do not exist
                    if (this.DataTables == null)
                    {
                        // raise an exception so the build fails
                        throw new Exception("The DataTables collection does not exist.");
                    }
                    else
                    {
                        // raise an exception so the build fails
                        throw new Exception("The gateway file '" + this.GatewayPath + "' could not be found.");
                    }
                }
            }
            #endregion
            
            #region FindMethodInsertIndex(string methodName, List<TextLine> lines)
            /// <summary>
            /// This method finds the Insert Index for the methodName given.
            /// </summary>
            private int FindMethodInsertIndex(string methodName, List<TextLine> lines)
            {
                // initial value
                int index = -1;
                int tempIndex = -1;
                int methodsIndex = -1;

                try
                {
                    // locals
                    bool methodsRegionStarted = false;
                    int openRegionsCount = 0;

                    // if the methodName exists and there is at least one line
                    if ((TextHelper.Exists(methodName)) && (ListHelper.HasOneOrMoreItems(lines)))
                    {
                        // Iterate the items in the collection
                        foreach (TextLine textLine in lines)
                        {
                            // increment
                            tempIndex++;

                            // if the words do not exist
                            if (textLine.Words == null)
                            {
                                // load the words
                                textLine.Words = WordParser.GetWords(textLine.Text);
                            }

                            // create a codeLine
                            CodeLine codeLine = new CodeLine(textLine);

                            // if this is a region
                            if (codeLine.IsRegion)
                            {
                                // if we have not reached the methods region
                                if (!methodsRegionStarted)
                                {
                                    // if this is the methods region
                                    if (codeLine.Text.Contains("Methods"))
                                    {
                                        // has started
                                        methodsRegionStarted = true;

                                        // set the methodsIndex
                                        methodsIndex = tempIndex;

                                        // default to 2 plus the Methods index
                                        index = tempIndex + 2;

                                        // set to 1
                                        openRegionsCount = 1;
                                    }
                                }
                                else
                                {
                                    // increment the openRegionsCount
                                    openRegionsCount++;

                                    // set the methodName
                                    string tempMethodName = codeLine.Text.Trim().Substring(7).Trim();

                                    // set the stringCompare
                                    int stringCompare = String.Compare(methodName, tempMethodName);

                                    // if the method name exists exactly
                                    if (stringCompare == 0)
                                    {
                                        // this method already exists, set to -1
                                        index = -1;

                                        // break out of loop
                                        break;
                                    }
                                    else
                                    { 
                                        // this is the insertIndex
                                        index = tempIndex;

                                        // if this is the insert index
                                        if (stringCompare < 0)
                                        {
                                            // break out of loop
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (codeLine.IsEndRegion)
                            {
                                // if we have reached the methods region
                                if (methodsRegionStarted)
                                {
                                    // decrement the openRegionsCount
                                    openRegionsCount--;

                                    // if we have reached the end of the Methods region
                                    if (openRegionsCount == 0)
                                    {
                                        // this is the insertIndex
                                        index = tempIndex;

                                        // break out of loop
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // Feel free to take this out, but the example below demonstrates how to not create some Gateway Methods
                // if extra or unneeded methods are being created.
                // One of my current work projects has a table with a composite primary key, and DataTier.Net attempts to create
                // two methods for Find & Delete. Here I handle the extra methods so my projects will compile after build.
                switch (methodName)
                {
                    case "FindAspNetUserRoles(string roleId, AspNetUserRoles tempAspNetUserRoles = null)":
                    case "DeleteAspNetUserRoles(string roleId, AspNetUserRoles tempAspNetUserRoles = null)":

                        // set the index to negative one
                        index = -1;

                        // required
                        break;
                }
             

                // return value
                return index;
            }
            #endregion
            
            #region WriteBackupFile(string gatewayPath)
            /// <summary>
            /// This method returns the Backup File
            /// </summary>
            private bool WriteBackupFile(string gatewayPath)
            {
                // initial value
                bool saved = false;

                try
                {
                    // if the file exists
                    if ((TextHelper.Exists(gatewayPath)) && (File.Exists(gatewayPath)))
                    {
                        // get the copyFileName
                        // Update for .Net Core, now this has to be cs.backup instead of backup.cs, because
                        // .Net Core and file nesting will make the file appear in the project.
                        string copyFileName = gatewayPath.Substring(0, gatewayPath.Length - 3) + ".cs.backup";

                        // make a copy of the file
                        File.Copy(gatewayPath, copyFileName, true);

                        // delete the existing file
                        File.Delete(gatewayPath);

                        // success
                        saved = true;
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // not copied
                    saved = false;
                }

                // return value
                return saved;
            }
            #endregion
            
            #region WriteDeleteMethod(DataTable dataTable, List<TextLine> lines)
            /// <summary>
            /// This method writes out the Delete Method
            /// </summary>
            private void WriteDeleteMethod(DataTable dataTable, List<TextLine> lines)
            {
                // if the dataTable exists and the lines collection exists
                if ((dataTable != null) && (ListHelper.HasOneOrMoreItems(lines)))
                {
                    // local
                    string variableName = TextHelper.CapitalizeFirstChar(dataTable.PrimaryKey.FieldName, true);

                    // set the methodName
                    string methodName = "";
                    
                    if ((dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Integer) || (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber))
                    {
                        // set the methodName
                        methodName = "Delete" + dataTable.Name + "(int " + variableName + ", " + dataTable.ClassName + " temp" + dataTable.ClassName + " = null)";
                    }
                    else
                    {
                        // set the methodName
                        methodName = "Delete" + dataTable.Name + "(string " + variableName + ", " + dataTable.ClassName + " temp" + dataTable.ClassName + " = null)";
                    }
                 
                    // find the insertIndex
                    int insertIndex = FindMethodInsertIndex(methodName, lines);

                    // locals
                    string param1String = "            /// <param name=\"" + variableName + "\">Delete the " + dataTable.ClassName + " with this " + variableName + "</param>";
                    string param2String = "            /// <param name=\"" + "temp" + dataTable.Name + "\">Pass in a temp" + dataTable.ClassName + " to perform a custom delete.</param>";

                    // if the insertIndex was found
                    if (insertIndex > 0)
                    {
                        // set the textLine
                        TextLine beginregion = new TextLine("            #region " + methodName);
                        TextLine summary = new TextLine("            /// <summary>");
                        TextLine summaryDescription = new TextLine("            /// This method is used to delete " + dataTable.Name + " objects.");
                        TextLine endSummary = new TextLine("            /// </summary>");
                        TextLine param1 = new TextLine(param1String);
                        TextLine param2 = new TextLine(param2String);
                        TextLine methodDeclarationLine = new TextLine("            public bool " + methodName);
                        TextLine openBracket = new TextLine("            {");
                        TextLine initialValueComment = new TextLine("                // initial value");
                        TextLine initialValue = new TextLine("                bool deleted = false;");
                        TextLine blankLine = new TextLine("        ");
                        TextLine validationTestComment = new TextLine("                // if the AppController exists");
                        TextLine validationTest = new TextLine("                if (this.HasAppController)");
                        TextLine openBracket2 = new TextLine("                {");
                        TextLine openBracket3 = new TextLine("                    {");
                        TextLine returnValueComment = new TextLine("                // return value");
                        TextLine returnValue = new TextLine("                return deleted;");
                        TextLine closeBracket = new TextLine("            }");
                        TextLine closeBracket2 = new TextLine("                }");
                        TextLine closeBracket3 = new TextLine("                    }");
                        TextLine endRegion = new TextLine("            #endregion");
                        TextLine createTempObjectComment = new TextLine("                        // create a temp " + TextHelper.CapitalizeFirstChar(dataTable.Name, false));
                        TextLine createTempObject = new TextLine("                        temp" + dataTable.ClassName + " = new " + dataTable.ClassName + "();");
                        TextLine ifTempObjectDoesNotExistComment = new TextLine("                    // if the temp" + dataTable.ClassName + " does not exist");
                        TextLine ifTempObjectDoesNotExist = new TextLine("                    if (temp" + dataTable.ClassName + " == null)");
                        TextLine ifPrimaryKeyIsSetComment = new TextLine("                    // if the " + variableName + " is set");
                        TextLine ifPrimaryKeyIsSet = null; 
                        TextLine setPrimaryKeyComment = new TextLine("                        // set the primary key");
                        TextLine setPrimaryKey = new TextLine("                        temp" + dataTable.ClassName + ".UpdateIdentity(" + variableName + ");");
                        TextLine performDeleteComment = new TextLine("                    // perform the delete");
                        TextLine performDelete = new TextLine("                    deleted = this.AppController.ControllerManager." + dataTable.Name + "Controller.Delete(temp" + dataTable.ClassName + ");");

                        // if this is an integer or an Identity column
                        if ((dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber) || (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Integer))
                        {
                            // write out the test as an integer
                            ifPrimaryKeyIsSet = new TextLine("                    if (" + variableName + " > 0)");
                        }
                        else
                        {
                            // write out the test as an integer
                            ifPrimaryKeyIsSet = new TextLine("                    if (!String.IsNullOrEmpty(" + variableName + "))");
                        }    
                        
                        // insert a line
                        lines.Insert(insertIndex, beginregion);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, summary);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, summaryDescription);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, endSummary);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, param1);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, param2);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, methodDeclarationLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, openBracket);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, initialValueComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, initialValue);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, validationTestComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, validationTest);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, openBracket2);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, ifTempObjectDoesNotExistComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, ifTempObjectDoesNotExist);

                        // increment
                        insertIndex++;
                        
                        // insert a line
                        lines.Insert(insertIndex, openBracket3);
                        
                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, createTempObjectComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, createTempObject);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, closeBracket3);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // increment
                        insertIndex++;

                        // write the primary key comment
                        lines.Insert(insertIndex, ifPrimaryKeyIsSetComment);

                        // increment
                        insertIndex++;

                        // write the primary key comment
                        lines.Insert(insertIndex, ifPrimaryKeyIsSet);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, openBracket3);

                        // increment
                        insertIndex++;

                        // write the primary key comment
                        lines.Insert(insertIndex, setPrimaryKeyComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, setPrimaryKey);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, closeBracket3);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // write the primary key comment
                        lines.Insert(insertIndex, performDeleteComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, performDelete);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, closeBracket2);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);
  
                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, returnValueComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, returnValue);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, closeBracket);

                        // increment
                        insertIndex++;
                        
                        // insert a line
                        lines.Insert(insertIndex, endRegion);
                    }
                }
            }
            #endregion
            
            #region WriteFindMethod(DataTable dataTable, List<TextLine> lines)
            /// <summary>
            /// This method writes out the Find Method
            /// </summary>
            private void WriteFindMethod(DataTable dataTable, List<TextLine> lines)
            {
                try
                {
                    // if the dataTable exists and the lines collection exists
                    if ((dataTable != null) && (ListHelper.HasOneOrMoreItems(lines)))
                    {
                        // locals
                        string variableName = TextHelper.CapitalizeFirstChar(dataTable.PrimaryKey.FieldName, true);
                        string objectName = TextHelper.CapitalizeFirstChar(dataTable.ClassName, true);

                        // set the methodName
                        string methodName = "";

                        // if this is an integer or Autonumber Identity field
                        if ((dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber) || (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Integer))
                        {
                            // set the methodName
                            methodName = "Find" + dataTable.Name + "(int " + variableName + ", " + dataTable.ClassName + " temp" + dataTable.ClassName + " = null)";
                        }
                        else
                        {
                            // set the methodName
                            methodName = "Find" + dataTable.Name + "(string " + variableName + ", " + dataTable.ClassName + " temp" + dataTable.ClassName + " = null)";
                        }

                        // find the insertIndex
                        int insertIndex = FindMethodInsertIndex(methodName, lines);

                        // locals
                        string param1String = "            /// <param name=\"" + variableName + "\">Find the " + dataTable.ClassName + " with this " + variableName + "</param>";
                        string param2String = "            /// <param name=\"" + "temp" + dataTable.Name + "\">Pass in a temp" + dataTable.ClassName + " to perform a custom find.</param>";

                        // if the insertIndex was found
                        if (insertIndex > 0)
                        {
                            // set the textLine
                            TextLine beginregion = new TextLine("            #region " + methodName);
                            TextLine summary = new TextLine("            /// <summary>");
                            TextLine summaryDescription = new TextLine("            /// This method is used to find '" + dataTable.ClassName + "' objects.");
                            TextLine endSummary = new TextLine("            /// </summary>");
                            TextLine param1 = new TextLine(param1String);
                            TextLine param2 = new TextLine(param2String);
                            TextLine methodDeclarationLine = new TextLine("            public " + dataTable.ClassName + " " + methodName);
                            TextLine openBracket = new TextLine("            {");
                            TextLine initialValueComment = new TextLine("                // initial value");
                            TextLine initialValue = new TextLine("                " + dataTable.ClassName + " " + objectName + " = null;");
                            TextLine blankLine = new TextLine();
                            TextLine validationTestComment = new TextLine("                // if the AppController exists");
                            TextLine validationTest = new TextLine("                if (this.HasAppController)");
                            TextLine openBracket2 = new TextLine("                {");
                            TextLine closeBracket = new TextLine("            }");
                            TextLine closeBracket2 = new TextLine("                }");
                            TextLine openBracket3 = new TextLine("                    {");
                            TextLine closeBracket3 = new TextLine("                    }");
                            TextLine endRegion = new TextLine("            #endregion");
                            TextLine createTempObjectComment = new TextLine("                        // create a temp " + TextHelper.CapitalizeFirstChar(dataTable.Name, false));
                            TextLine createTempObject = new TextLine("                        temp" + dataTable.ClassName + " = new " + dataTable.ClassName + "();");
                            TextLine ifTempObjectDoesNotExistComment = new TextLine("                    // if the temp" + dataTable.ClassName + " does not exist");
                            TextLine ifTempObjectDoesNotExist = new TextLine("                    if (temp" + dataTable.ClassName + " == null)");
                            TextLine ifPrimaryKeyIsSetComment = new TextLine("                    // if the " + variableName + " is set");
                            TextLine ifPrimaryKeyIsSet = null;
                            TextLine setPrimaryKeyComment = new TextLine("                        // set the primary key");
                            TextLine setPrimaryKey = new TextLine("                        temp" + dataTable.ClassName + ".UpdateIdentity(" + variableName + ");");
                            TextLine performFindComment = new TextLine("                    // perform the find");
                            TextLine performFind = new TextLine("                    " + objectName + " = this.AppController.ControllerManager." + dataTable.Name + "Controller.Find(temp" + dataTable.ClassName + ");");
                            TextLine returnValueComment = new TextLine("                // return value");
                            TextLine returnValue = new TextLine("                return " + objectName + ";");

                            // if this is an integer or identity column
                            if ((dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Autonumber) || (dataTable.PrimaryKey.DataType == DataManager.DataTypeEnum.Integer))
                            {
                                // create the line that tests if the primary key is set
                                ifPrimaryKeyIsSet = new TextLine("                    if (" + variableName + " > 0)");
                            }
                            else
                            {
                                // create the line that tests if the primary key is set
                                ifPrimaryKeyIsSet = new TextLine("                    if (!String.IsNullOrEmpty(" + variableName + "))");
                            }

                            // insert a line
                            lines.Insert(insertIndex, beginregion);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, summary);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, summaryDescription);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, endSummary);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, param1);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, param2);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, methodDeclarationLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, openBracket);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, initialValueComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, initialValue);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, validationTestComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, validationTest);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, openBracket2);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, ifTempObjectDoesNotExistComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, ifTempObjectDoesNotExist);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, openBracket3);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, createTempObjectComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, createTempObject);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, closeBracket3);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // increment
                            insertIndex++;

                            // write the primary key comment
                            lines.Insert(insertIndex, ifPrimaryKeyIsSetComment);

                            // increment
                            insertIndex++;

                            // write the primary key comment
                            lines.Insert(insertIndex, ifPrimaryKeyIsSet);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, openBracket3);

                            // increment
                            insertIndex++;

                            // write the primary key comment
                            lines.Insert(insertIndex, setPrimaryKeyComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, setPrimaryKey);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, closeBracket3);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // write the primary key comment
                            lines.Insert(insertIndex, performFindComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, performFind);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, closeBracket2);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, returnValueComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, returnValue);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, closeBracket);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, endRegion);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion
            
            #region WriteGatewayFile(List<TextLine> lines)
            /// <summary>
            /// This method returns a list of Gateway File
            /// </summary>
            private void WriteGatewayFile(List<TextLine> lines)
            {
                // locals
                int counter = 0;
                int blankLineCount = 0;

                // if the lines exist
                if (ListHelper.HasOneOrMoreItems(lines))
                {
                    // create a StringBuilder  
                    StringBuilder sb = new StringBuilder();

                    // Iterate the items in the collection
                    foreach (TextLine textLine in lines)
                    {
                        // increment
                        counter++;

                        // replace out the new line text
                        string text = textLine.Text + Environment.NewLine;

                        // get the text
                        string temp = text.Trim();

                        // if the text exists
                        if (TextHelper.Exists(temp))
                        {
                            // reset
                            blankLineCount = 0;

                            // if ends with a new line
                            if (text.EndsWith(Environment.NewLine))
                            {
                                // append the line
                                sb.Append(text);
                            }
                            else if (text.EndsWith(@"\n"))
                            {
                                // append the line
                                sb.Append(text);
                            }
                            else if (text.EndsWith(@"\r"))
                            {
                                // append the line
                                sb.Append(text);
                            }
                            else
                            {
                                // append the line
                                sb.Append(text + Environment.NewLine);
                            }
                        }
                        else
                        {
                            // increment
                            blankLineCount++;

                            // if the counter exists
                            if (counter > 2)
                            {
                                // if the blankLineCount < 2
                                if (blankLineCount < 2)
                                {
                                    // if ends with a new line
                                    if (text.EndsWith(Environment.NewLine))
                                    {
                                        // append the line
                                        sb.Append(text);
                                    }
                                    else
                                    {
                                        // append the line
                                        sb.Append(text + Environment.NewLine);
                                    }
                                }
                            }
                            else
                            {
                                // if ends with a new line
                                if (text.EndsWith(Environment.NewLine))
                                {
                                    // append the line
                                    sb.Append(text);
                                }
                                else
                                {
                                    // append the line
                                    sb.Append(text + Environment.NewLine);
                                }
                            }
                        }
                    }                    

                    // get the documentText
                    string documentText = sb.ToString();

                    // append all the text to the file
                    File.AppendAllText(this.GatewayPath, documentText);
                }
            }
            #endregion
            
            #region WriteLoadMethod(DataTable dataTable, List<TextLine> lines)
            /// <summary>
            /// This method writes out the Load Method
            /// </summary>
            private void WriteLoadMethod(DataTable dataTable, List<TextLine> lines)
            {
                // if the dataTable exists and the lines collection exists
                if ((dataTable != null) && (ListHelper.HasOneOrMoreItems(lines)))
                {
                    // locals
                    string objectName = PluralWordHelper.GetPluralName(dataTable.ClassName, false);
                    string collectionName = PluralWordHelper.GetPluralName(dataTable.ClassName, true);
                    
                    // set the methodName
                    string methodName = "Load" + objectName + "(" + dataTable.ClassName + " temp" + dataTable.ClassName + " = null)";

                    // find the insertIndex
                    int insertIndex = FindMethodInsertIndex(methodName, lines);

                    // if the insertIndex was found
                    if (insertIndex > 0)
                    {
                        // set the textLine
                        TextLine beginregion = new TextLine("            #region " + methodName);
                        TextLine summary = new TextLine("            /// <summary>");
                        TextLine summaryDescription = new TextLine("            /// This method loads a collection of '" + dataTable.ClassName + "' objects.");
                        TextLine endSummary = new TextLine("            /// </summary>");
                        TextLine methodDeclarationLine = new TextLine("            public List<" + dataTable.ClassName + "> " + methodName);
                        TextLine openBracket = new TextLine("            {");
                        TextLine initialValueComment = new TextLine("                // initial value");
                        TextLine initialValue = new TextLine("                List<" + dataTable.ClassName + "> " + collectionName + " = null;");
                        TextLine blankLine = new TextLine();
                        TextLine validationTestComment = new TextLine("                // if the AppController exists");
                        TextLine validationTest = new TextLine("                if (this.HasAppController)");
                        TextLine openBracket2 = new TextLine("                {");
                        TextLine closeBracket = new TextLine("            }");
                        TextLine closeBracket2 = new TextLine("                }");
                        TextLine endRegion = new TextLine("            #endregion");
                        TextLine performLoadComment = new TextLine("                    // perform the load");
                        TextLine performLoad = new TextLine("                    " + collectionName + " = this.AppController.ControllerManager." + dataTable.Name + "Controller.FetchAll(temp" + dataTable.ClassName + ");");
                        TextLine returnValueComment = new TextLine("                // return value");
                        TextLine returnValue = new TextLine("                return " + collectionName + ";");
                       
                        // insert a line
                        lines.Insert(insertIndex, beginregion);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, summary);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, summaryDescription);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, endSummary);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, methodDeclarationLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, openBracket);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, initialValueComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, initialValue);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, validationTestComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, validationTest);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, openBracket2);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // write the load comment
                        lines.Insert(insertIndex, performLoadComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, performLoad);

                        // increment
                        insertIndex++;
    
                        // insert a line
                        lines.Insert(insertIndex, closeBracket2);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, returnValueComment);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, returnValue);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, closeBracket);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, endRegion);

                        // increment
                        insertIndex++;

                        // insert a line
                        lines.Insert(insertIndex, blankLine);
                    }
                }
            }
            #endregion
            
            #region WriteSaveMethod(DataTable dataTable, List<TextLine> lines)
            /// <summary>
            /// This method returns a list of Save Method
            /// </summary>
            private void WriteSaveMethod(DataTable dataTable, List<TextLine> lines)
            {
                try
                {
                    // if the dataTable exists and the lines collection exists
                    if ((dataTable != null) && (ListHelper.HasOneOrMoreItems(lines)))
                    {
                        // locals
                        string objectName = TextHelper.CapitalizeFirstChar(dataTable.ClassName, true);

                        // set the methodName
                        string methodName = "Save" + dataTable.Name + "(ref " + dataTable.ClassName + " " + objectName + ")";

                        // find the insertIndex
                        int insertIndex = FindMethodInsertIndex(methodName, lines);

                        // locals
                        string param1String = "            /// <param name=\"" + objectName + "\">The " + dataTable.ClassName + " to save.</param>";
                        
                        // if the insertIndex was found
                        if (insertIndex > 0)
                        {
                            // set the textLine
                            TextLine beginregion = new TextLine("            #region " + methodName);
                            TextLine summary = new TextLine("            /// <summary>");
                            TextLine summaryDescription = new TextLine("            /// This method is used to save '" + dataTable.ClassName + "' objects.");
                            TextLine endSummary = new TextLine("            /// </summary>");
                            TextLine param1 = new TextLine(param1String);
                            TextLine methodDeclarationLine = new TextLine("            public bool "+ methodName);
                            TextLine openBracket = new TextLine("            {");
                            TextLine initialValueComment = new TextLine("                // initial value");
                            TextLine initialValue = new TextLine("                bool saved = false;");
                            TextLine blankLine = new TextLine();
                            TextLine validationTestComment = new TextLine("                // if the AppController exists");
                            TextLine validationTest = new TextLine("                if (this.HasAppController)");
                            TextLine openBracket2 = new TextLine("                {");
                            TextLine closeBracket = new TextLine("            }");
                            TextLine closeBracket2 = new TextLine("                }");
                            TextLine openBracket3 = new TextLine("                    {");
                            TextLine closeBracket3 = new TextLine("                    }");
                            TextLine endRegion = new TextLine("            #endregion");
                            TextLine performSaveComment = new TextLine("                    // perform the save");
                            TextLine performSave = new TextLine("                    saved = this.AppController.ControllerManager." + dataTable.Name + "Controller.Save(ref " + objectName + ");");
                            TextLine returnValueComment = new TextLine("                // return value");
                            TextLine returnValue = new TextLine("                return saved;");

                            // insert a line
                            lines.Insert(insertIndex, beginregion);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, summary);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, summaryDescription);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, endSummary);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, param1);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, methodDeclarationLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, openBracket);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, initialValueComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, initialValue);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, validationTestComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, validationTest);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, openBracket2);

                            // increment
                            insertIndex++;

                            // write the primary key comment
                            lines.Insert(insertIndex, performSaveComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, performSave);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, closeBracket2);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, returnValueComment);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, returnValue);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, closeBracket);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, endRegion);

                            // increment
                            insertIndex++;

                            // insert a line
                            lines.Insert(insertIndex, blankLine);
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
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

            #region GatewayPath
            /// <summary>
            /// This property gets or sets the value for 'GatewayPath'.
            /// </summary>
            public string GatewayPath
            {
                get { return gatewayPath; }
                set { gatewayPath = value; }
            }
            #endregion
            
            #region HasGatewayPath
            /// <summary>
            /// This property returns true if the 'GatewayPath' exists.
            /// </summary>
            public bool HasGatewayPath
            {
                get
                {
                    // initial value
                    bool hasGatewayPath = (!String.IsNullOrEmpty(this.GatewayPath));
                    
                    // return value
                    return hasGatewayPath;
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

		#endregion

    }
    #endregion

}
