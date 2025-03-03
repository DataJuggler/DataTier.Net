

#region using statements

using DataGateway;
using DataJuggler.Net;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using DataTierClient.Builders;
using DataTierClient.ClientUtil;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using DataTierClient.Objects;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Controls
{

    #region class ConfirmChangesControl
    /// <summary>
    /// This control is used to get the user's confirmation before adding or
    /// changing files in their project, and to perform the updates.
    /// </summary>
    public partial class ConfirmChangesControl : UserControl, ISaveCancelControl
    {

        #region Private Variables
        private bool userCancelled;
        private bool loading;
        private MethodInfo methodInfo;
        private bool abortPrivateVariableInsert;
        private bool abortPropertyInsert;
        private bool abortGatewayInsert;
        private bool abortWriterInsert;
        private bool abortDataManagerInsert;
        private Project project;
        private ProjectFileManager projectFileManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ConfirmChangesControl' object.
        /// </summary>
        public ConfirmChangesControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region CodeItemsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            /// <summary>
            /// event is fired when Code Items List Box _ Item Check
            /// </summary>
            private void CodeItemsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                // if not loading            
                if (!this.Loading)
                {
                    // get the listBox
                    CheckedListBox listBox = sender as CheckedListBox;

                    // if the ListBox exists
                    if (NullHelper.Exists(listBox))
                    {
                        //// if Checked
                        //if (e.NewValue == CheckState.Checked)
                        //{
                        //    // Do not Exclude since this file is checked
                        //    this.ProjectFileManager.Files[e.Index].Exclude = false;
                        //}
                        //else if (e.NewValue == CheckState.Unchecked)
                        //{
                        //    // Exclude since this file is unchecked
                        //    this.ProjectFileManager.Files[e.Index].Exclude = true;
                        //}
                    }
                }
            }
            #endregion
            
            #region ConfirmUpdateButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ConfirmUpdateButton' is clicked.
            /// </summary>
            private void ConfirmUpdateButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // if the ProjectFolder exists and the MethodInfo exists and the MethodInfo.SelectedTable exists
                    if ((this.HasProjectFolder) && (this.HasMethodInfo) && (this.MethodInfo.HasSelectedTable))
                    {
                        // Clear ListBox
					    this.StatusListBox.Items.Clear();

					    // Add a column header
					    AddColumnHeader();

                        // Get the displayText
                        string displayText = "Updating Data Object...";

                        // Display Message
                        ListViewItem listItem = CreateStatusMessage(displayText);               

                        // update the data object
                        bool dataObjectUpdated = UpdateDataObject();

                        // if Aborted 
                        if (AbortDataObjectInsert)
                        {
                            // change the text
                            listItem.Text += " Property " + MethodInfo.PropertyName + " already exists. ";
                        }

                        // Update the status 
                        UpdateStatus(listItem, dataObjectUpdated);

                        // change the displayText
                        displayText = "Updating Data Writer...";

                         // Display Message
                        listItem = CreateStatusMessage(displayText);               

                        // update the data object
                        bool writerUpdated = UpdateWriter();

                        // if the value for AbortWriterInsert is true
                        if (AbortWriterInsert)
                        {
                            // change the text
                            listItem.Text += " The class " + MethodInfo.SelectedTable.ClassName + "Writer has already been updated. ";
                        }

                        // Update the status 
                        UpdateStatus(listItem, writerUpdated);

                        // if UseCustomReader is true && the CustomReader exist
                        if ((MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader))
                        {
                            // get the name of the data manager
                            string dataManager = MethodInfo.SelectedTable.ClassName + "Manager";

                            // change the displayText
                            displayText = "Updating " + dataManager + " to use custom reader " + MethodInfo.CustomReader.ReaderName + ".";

                             // Display Message
                            listItem = CreateStatusMessage(displayText);               

                            // update the data object
                            bool dataManagerUpdated = UpdateDataManager();

                            // if the value for AbortWriterInsert is true
                            if (abortDataManagerInsert)
                            {
                                // change the text
                                listItem.Text += MethodInfo.SelectedTable.ClassName + "Manager already handles this custom reader. ";

                                // Update the status 
                                UpdateStatus(listItem, true);
                            }
                            else
                            {
                                // Update the status 
                                UpdateStatus(listItem, dataManagerUpdated);
                            }
                        }

                        // if MethodInfo.CustomReader.FieldSet.Fields exists (pseudo code is such a great language)
                        if ((MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader) && (MethodInfo.CustomReader.HasFieldSet) && (MethodInfo.CustomReader.FieldSet.HasFields))
                        {
                            // change the displayText
                            displayText = "Creating custom reader " + MethodInfo.CustomReader.ReaderName + "...";

                            // Display Message
                            listItem = CreateStatusMessage(displayText);

                            // was a customReaderCreated
                            bool customReaderCreated = CreateCustomReader();

                            // Update the status 
                            UpdateStatus(listItem, customReaderCreated);
                        }

                        // change the displayText
                        displayText = "Updating Gateway...";

                         // Display Message
                        listItem = CreateStatusMessage(displayText);               

                        // update the data object
                        bool gatewayUpdated = UpdateGateway();

                        // if the insert was aborted
                        if (AbortGatewayInsert)
                        {
                            // Append a message
                            listItem.Text += " The method '" + MethodInfo.MethodName + "' already exists. ";
                        }

                        // Update the status 
                        UpdateStatus(listItem, gatewayUpdated);

                        // if all 3 files were updated
                        if (dataObjectUpdated && writerUpdated)
                        {
                            // now we need to insert a method into the methods table

                            // Update 1.21.2019 : To prevent duplicate methods with the same name from being created, 
                            //              now the method is attempted to be found, and if found the existing method
                            //              is updated instead of creating a duplicate.

                             // Create a new instance of a 'Gateway' object.
                            Gateway gateway = new Gateway();

                            // local
                            Method method = null;

                            // if the MethodId is set, use that
                            if (MethodInfo.MethodId > 0)
                            {
                                // use the MethodId
                                method = gateway.FindMethod(MethodInfo.MethodId);
                            }
                            else
                            {
                                // Find By Name
                                method = gateway.FindMethodByName(MethodInfo.MethodName);
                            }
                            
                            // if the method object does not exist
                            if (NullHelper.IsNull(method))
                            {
                                // Create a new instance of a 'Method' object.
                                method = new Method();
                            }

                            // set the properties for the method
                            method.Active = true;
                            method.MethodType = MethodInfo.MethodType;
                            method.Name = MethodInfo.MethodName;
                            
                            // if the ParameterField exists
                            if (MethodInfo.HasParameterField)
                            {
                                // set the ParameterFieldId
                                method.ParameterFieldId = MethodInfo.ParameterField.FieldId;
                            }
                            else if (MethodInfo.HasParameterFieldSet)
                            {
                                // set the ParameterFieldSetId
                                method.ParametersFieldSetId = MethodInfo.ParameterFieldSet.FieldSetId;
                            }
                        
                            // set the properties
                            method.ParameterType = MethodInfo.ParameterType;
                            method.OrderByType = MethodInfo.OrderByType;
                            method.ProcedureName = MethodInfo.ProcedureName;
                            method.PropertyName = MethodInfo.PropertyName;
                            method.ProjectId = MethodInfo.SelectedTable.ProjectId;
                            method.TableId = MethodInfo.SelectedTable.TableId;
                            method.UpdateProcedureOnBuild = MethodInfo.UpdateOnBuild;
                            method.Parameters = MethodInfo.Parameters;
                            method.TopRows = MethodInfo.TopRows;
                            method.UseCustomWhere = MethodInfo.UseCustomWhere;
                            
                            // if UseCustomWhere is true
                            if (method.UseCustomWhere)
                            {
                                // Use the Same WhereText
                                method.WhereText = MethodInfo.WhereText;
                            }
                            else
                            {
                                // Use Empty String
                                method.WhereText = "";
                            }

                            // if UseCustomReader is true and the CustomReader exists and the CustomReader.Id is set
                            if ((MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader) && (!MethodInfo.CustomReader.IsNew))
                            {
                                // set the properties for a CustomReader
                                method.UseCustomReader = MethodInfo.UseCustomReader;
                                method.CustomReaderId = MethodInfo.CustomReader.CustomReaderId;
                            }
                            else
                            {
                                // set the properties to NOT use a custom reader
                                method.UseCustomReader = false;
                                method.CustomReaderId = 0;
                            }

                            // if the OrderByField exists
                            if (MethodInfo.HasOrderByField)
                            {
                                // set the OrderByFieldId
                                method.OrderByFieldId = MethodInfo.OrderByField.FieldId;
                                method.OrderByDescending = MethodInfo.OrderByDescending;

                                // Erase FieldSetId
                                method.OrderByFieldSetId = 0;
                            }
                            else if (MethodInfo.HasOrderByFieldSet)
                            {
                                // erase OrderByFieldId & Descending
                                method.OrderByFieldId = 0;
                                method.OrderByDescending = false;

                                // set the OrderByFieldSetId
                                method.OrderByFieldSetId = MethodInfo.OrderByFieldSet.FieldSetId;
                            }
                            else
                            {
                                // erase OrderByFieldId & Descending
                                method.OrderByFieldId = 0;
                                method.OrderByDescending = false;

                                 // Erase FieldSetId
                                method.OrderByFieldSetId = 0;
                            }

                            // save the method
                            bool saved = gateway.SaveMethod(ref method);

                            // if the value for saved is true
                            if (saved)
                            {
                                // if the MethodInfo exists
                                if (HasMethodInfo)
                                {
                                    // This was causing a bug on the NewStoredProcedureEditorControl.
                                    MethodInfo.MethodId = method.MethodId;
                                }

                                // Enable the Next button
                                this.SaveCancelControl.EnableSaveButton(true);
                            }
                            else
                            {
                                // for debugging only
                                Exception exception = gateway.GetLastException();

                                // If the exception object exists
                                if (NullHelper.Exists(exception))
                                {
                                    // for debugging only
                                    string err = exception.ToString();
                                }

                                // show the user an error
                                MessageHelper.DisplayMessage("An unexpected error occurred saving this method.", "Database Save Failed");
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Show the user a message
                    MessageHelper.DisplayMessage("An error occurred updating your projects. Debug the error in the event ConfirmUpdate_Click", "Update Failed");
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region AddColumnHeader()
            /// <summary>
            /// This method adds a status item to the list box
            /// </summary>
            private void AddColumnHeader()
            {
                // Create listItem
                this.StatusListBox.Columns.Add("", this.StatusListBox.Width);
            } 
            #endregion

            #region BuildObjectReader(ref Exception error)
            /// <summary>
            /// This method builds the Object Readers
            /// </summary>
            private bool BuildObjectReader(ref Exception error)
            {
                // initial value
                bool success = false;
                
                try
                {
                    // if the Project exists and the MethodInfo.SelectedTable exists and the CustomReader.FieldSet.Fields exists
                    if ((this.HasProject) && (HasMethodInfo) && (MethodInfo.HasSelectedTable) && (MethodInfo.HasCustomReader) && (MethodInfo.CustomReader.HasFieldSet) && (MethodInfo.CustomReader.FieldSet.HasFields))
                    {   
                        // Create ClassBuilder
                        ClassBuilder classBuilder = new ClassBuilder(false);
                        
                        // load references
                        List<ProjectReference> references = this.Project.ReaderReferencesSet.References;
                        DataJuggler.Net.ReferencesSet convertedReferences = classBuilder.ConvertReferences(references, "ObjectReaders");

                        // convert the DTNTable to DataJuggler.Net.DataTable
                        DataTable dataTable = DataConverter.ConvertDataTable(methodInfo.SelectedTable, Project);

                        // If the dataTable object exists
                        if (NullHelper.Exists(dataTable))
                        {
                            // create the ProjectFileManager
                            this.ProjectFileManager = new ProjectFileManager();

                            // 12.19.2021
                            TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) Project.TargetFramework;

                            // Create writer
                            DataObjectReaderCreator writer = new DataObjectReaderCreator(dataTable, convertedReferences, Project.ReaderFolder, Project.ReaderNamespace, ProjectFileManager, targetFramework);
                        
                            // Write Class
                            MethodInfo.CustomReader.FieldSet.DataFields = writer.CreateObjectReader(dataTable, MethodInfo.CustomReader);

                            // set success to true
                            success = true;
                        }
                    }
                }
                catch (Exception exception)
                {   
                    // Set error
                    error = exception;
                
                    // set success to false
                    success = false;
                }
                
                // return value
                return success;
            }
            #endregion
        
            #region CreateCustomReader()
            /// <summary>
            /// This method returns the Custom Reader
            /// </summary>
            public bool CreateCustomReader()
            {
                // initial value
                bool createCustomReader = false;

                // local
                Exception exception = null;

                // build the object reader
                createCustomReader = BuildObjectReader(ref exception);

                // If the exception object exists
                if (NullHelper.Exists(exception))
                {   
                    // set to false
                    createCustomReader = false;
                }
                
                // return value
                return createCustomReader;
            }
            #endregion
            
            #region CreateStatusMessage(string statusMessage)
            /// <summary>
            /// This method creates the status message. This is to be 
            /// used before you call a build method. After the completion
            /// of a build method, call UpdateStatusMessage with the
            /// success or failure.
            /// </summary>
            /// <param name="statusMessage"></param>
            private ListViewItem CreateStatusMessage(string statusMessage)
            {
                // initial value
                ListViewItem listItem = this.StatusListBox.Items.Add(statusMessage);
                
                // Refresh
                this.Refresh();
                
                // return value
                return listItem;
            }
            #endregion
            
            #region GetChangeProcedureNameText(string indent2, string storedProcedureVariableName, string procedureName)
            /// <summary>
            /// This method returns the Change Procedure Name Text
            /// </summary>
            public string GetChangeProcedureNameText(string indent2, string storedProcedureVariableName, string procedureName)
            {
                // initial value
                string changeProcedureNameText = indent2 + storedProcedureVariableName + ".ProcedureName = \"" + procedureName + "\";";
                
                // return value
                return changeProcedureNameText;
            }
            #endregion
            
            #region GetDataManagerStoredProcedureVariableName()
            /// <summary>
            /// This method returns the Data Manager Stored Procedure Variable Name
            /// </summary>
            public string GetDataManagerStoredProcedureVariableName()
            {
                // initial value
                string storedProcedureVariableName = "";

                // if the value for HasMethodInfo is true
                if (HasMethodInfo)
                {
                    // if FindBy is true
                    if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                    {
                        // set the storedProcedureVariableName
                        storedProcedureVariableName = "find" + MethodInfo.SelectedTable.ClassName + "Proc";    
                    }
                    // if LoadBy is true
                    else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                    {
                        // set the storedProcedureVariableName
                        storedProcedureVariableName = "fetchAll" + PluralWordHelper.GetPluralName(MethodInfo.SelectedTable.ClassName, false) + "Proc";
                    }
                }
                
                // return value
                return storedProcedureVariableName;
            }
            #endregion
            
            #region GetFieldSetParameterLine(FieldSet parameters, string indent2, string storedProcedureVariableName, string variableName, ref bool abort)
            /// <summary>
            /// This method returns the Field Set Parameter Line
            /// </summary>
            public string GetFieldSetParameterLine(FieldSet parameters, string indent2, string storedProcedureVariableName, string variableName, ref bool abort)
            {
                // initial value
                string parameterLine = "";

                // locals
                DTNField parameter1 = null;
                DTNField parameter2 = null;
                DTNField parameter3 = null;
                DTNField parameter4 = null;

                // determine the parameters line to create by the number of parameters
                switch (parameters.Fields.Count)
                {
                    case 1:

                        // set the parameter
                        parameter1 = parameters.Fields[0];

                        // set the parameterLine
                        parameterLine = indent2 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + parameter1.FieldName + "\", " + variableName + "." + parameter1.FieldName + ");";

                        // required
                        break;

                    case 2:

                        // set the parameters
                        parameter1 = parameters.Fields[0];
                        parameter2 = parameters.Fields[1];

                        // set the parameterLine
                        parameterLine = indent2 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + parameter1.FieldName + "\", " + variableName + "." + parameter1.FieldName + ", " + "\"@" + parameter2.FieldName + "\", " + variableName + "." + parameter2.FieldName +  ");";

                        // required
                        break;

                    case 3:

                        // set the parameters
                        parameter1 = parameters.Fields[0];
                        parameter2 = parameters.Fields[1];
                        parameter3 = parameters.Fields[2];

                        // set the parameterLine
                        parameterLine = indent2 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + parameter1.FieldName + "\", " + variableName + "." + parameter1.FieldName + ", " + "\"@" + parameter2.FieldName + "\", " + variableName + "." + parameter2.FieldName +  ", " + "\"@" + parameter3.FieldName + "\", " + variableName + "." + parameter3.FieldName +  ")";

                        // required
                        break;

                    case 4:

                        // set the parameters
                        parameter1 = parameters.Fields[0];
                        parameter2 = parameters.Fields[1];
                        parameter3 = parameters.Fields[2];
                        parameter4 = parameters.Fields[3];

                        // set the parameterLine
                        parameterLine = indent2 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + parameter1.FieldName + "\", " + variableName + "." + parameter1.FieldName + ", " + "\"@" + parameter2.FieldName + "\", " + variableName + "." + parameter2.FieldName +  ", " + "\"@" + parameter3.FieldName + "\", " + variableName + "." + parameter3.FieldName + ", " + "\"@" + parameter4.FieldName + "\", " + variableName + "." + parameter4.FieldName + ")";

                        // required
                        break;

                    default:

                        // do not continue
                        abort = true;

                        // Invalid number of parameters
                        MessageHelper.DisplayMessage("The selected field set has an invalid number of parameters. 1 - 4 parameters are expected.", "Invalid Parameter Field Set");

                        // required
                        break;
                }

                // return value
                return parameterLine;
            }
            #endregion
            
            #region GetMethodDescription(MethodInfo methodInfo, string indent)
            /// <summary>
            /// This method returns the Method Description
            /// </summary>
            public string GetMethodDescription(MethodInfo methodInfo, string indent)
            {
                // initial value (in case something goes wrong
                string methodDescription = "/// [Enter Method Description Here]";

                try
                {
                    // if the methodInfo object exists
                    if ((NullHelper.Exists(methodInfo)) && (methodInfo.HasSelectedTable))
                    {
                        // if this is a Single Field parameter
                        if ((methodInfo.ParameterType == ParameterTypeEnum.Single_Field) && (methodInfo.HasParameterField))
                        {
                            // if this is a Delete
                            if (methodInfo.MethodType == MethodTypeEnum.Delete_By)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to delete '" + methodInfo.SelectedTable.ClassName + "' objects for the " + methodInfo.ParameterField.FieldName + " given.";
                            }
                            // if this is a Find
                            else if (methodInfo.MethodType == MethodTypeEnum.Find_By)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to find '" + methodInfo.SelectedTable.ClassName + "' objects for the " + methodInfo.ParameterField.FieldName + " given.";
                            }
                            else if (methodInfo.MethodType == MethodTypeEnum.Load_By)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to load '" + methodInfo.SelectedTable.ClassName + "' objects for the " + methodInfo.ParameterField.FieldName + " given.";
                            }
                            else if (methodInfo.MethodType == MethodTypeEnum.Update)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to update '" + methodInfo.SelectedTable.ClassName + "' objects for the " + methodInfo.ParameterField.FieldName + " given.";                                
                            }
                        }
                        else if ((methodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (methodInfo.HasParameterFieldSet))
                        {  
                            // if this is a Delete
                            if (methodInfo.MethodType == MethodTypeEnum.Delete_By)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to delete '" + methodInfo.SelectedTable.ClassName + "' objects by " + methodInfo.ParameterFieldSet.Name;
                            }
                            // if this is a Find
                            else if (methodInfo.MethodType == MethodTypeEnum.Find_By)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to find '" + methodInfo.SelectedTable.ClassName + "' objects by " + methodInfo.ParameterFieldSet.Name;
                            }
                            else if (methodInfo.MethodType == MethodTypeEnum.Load_By)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to load '" + methodInfo.SelectedTable.ClassName + "' objects by " + methodInfo.ParameterFieldSet.Name;
                            }
                            else if (methodInfo.MethodType == MethodTypeEnum.Update)
                            {
                                // set the methodDescription
                                methodDescription = indent + "/// This method is used to update '" + methodInfo.SelectedTable.ClassName + "' objects by the " + methodInfo.ParameterFieldSet.Name + " given.";                                
                            }
                        }
                        else
                        {
                            // Get the words
                            List<Word> words = GatewayHelper.GetWordsFromCapitalLetters(methodInfo.MethodName);
                            
                            // Format
                            methodDescription = indent + "/// " + GatewayHelper.GetStringFromCapitalLetters(methodInfo.MethodName);
                        }
                    }
                }
                catch (Exception error)
                {
                    // write to the console if in debug mode
                    DebugHelper.WriteDebugError("GetMethodDescription", this.Name, error);
                }
                
                // return value
                return methodDescription;
            }
            #endregion
            
            #region HandleChangeProcedureName(ref List<CodeLine> method, int spaces, string indent, string indent2, string variableName, int insertIndex, string storedProcedureVariableName, string openBracket, string closeBracket, bool useElfIf)
            /// <summary>
            /// This method Handle Change Procedure Name
            /// </summary>
            public int HandleChangeProcedureName(ref List<CodeLine> method, int spaces, string indent, string indent2, string variableName, int insertIndex, string storedProcedureVariableName, string openBracket, string closeBracket, bool useElseIf)
            {
                // locals
                string ifStatement = "";
                bool abort = false;
                FieldSet parameters = null;
                string parameterLine = "";
                DTNField parameter1 = null;
                
                // set the tag
                string tag = variableName;

                // set the ifStatementComment
                string ifStatementComment = TextHelper.Indent(spaces) + "// if " + variableName + "." + MethodInfo.PropertyName + " is true";
            
                // Insert a codeLine
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, ifStatementComment, insertIndex, tag);

                // if this is an addional if
                if (useElseIf)
                {
                    // now write out the if statement
                    ifStatement = indent + "else if (" + variableName + "." + MethodInfo.PropertyName +")";
                }
                else
                {
                    // now write out the if statement
                    ifStatement = indent + "if (" + variableName + "." + MethodInfo.PropertyName +")";
                }
                            
                // Insert a codeLine
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, ifStatement, insertIndex, tag);
            
                // Insert a codeLine
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, insertIndex, tag);

                // string for changeProcedureNameComment
                string changeProcedureNameComment = indent2 + "// Change the procedure name";

                // Insert a codeLine
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, changeProcedureNameComment, insertIndex, tag);

                // get the new procedureText
                string newProcedureNameText = GetChangeProcedureNameText(indent2, storedProcedureVariableName, MethodInfo.ProcedureName);

                // Insert a codeLine
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, newProcedureNameText, insertIndex, tag);

                // Insert a blank codeLine
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, indent2, insertIndex, tag);

                // if this is a SingleField Parameter
                if ((MethodInfo.ParameterType == ParameterTypeEnum.Single_Field) && (MethodInfo.HasParameterField))
                {
                    // set to parameter1
                    parameter1 = MethodInfo.ParameterField;

                    // string for change the procedureName
                    string createParametersComment = indent2 + "// Create the @" + parameter1.FieldName + " parameter";

                    // Insert a codeLine
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, createParametersComment, insertIndex, tag);

                    // set the parameterLine
                    parameterLine = indent2 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + parameter1.FieldName + "\", " + variableName + "." + parameter1.FieldName + ");";

                    // Insert a codeLine
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, parameterLine, insertIndex, tag);
                }
                else if ((methodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (methodInfo.HasParameterFieldSet) && (methodInfo.ParameterFieldSet.ParameterMode) && (methodInfo.ParameterFieldSet.HasFields))
                {
                    // set the fieldSet
                    parameters = methodInfo.ParameterFieldSet;

                    // string for change the procedureName
                    string createParametersComment = indent2 + "// Create the " + MethodInfo.ParameterFieldSet.Name + " field set parameters";

                    // Insert a codeLine
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, createParametersComment, insertIndex, tag);

                    // get the parameterLine
                    parameterLine = GetFieldSetParameterLine(parameters, indent2, storedProcedureVariableName, variableName, ref abort);

                    // if the value for abort is false
                    if ((!abort) && (TextHelper.Exists(parameterLine, tag)))
                    {
                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref method, parameterLine, insertIndex, tag);
                    }
                }
                
                // if the value for abort is false
                if (!abort)
                {
                    // if this is a FindBy method and UseCustomReader is true and the MethodInfo.CustomReader object exists
                    if (((MethodInfo.MethodType == MethodTypeEnum.Find_By) || (MethodInfo.MethodType == MethodTypeEnum.Load_By)) && (MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader))
                    {
                        // Insert the lines for using a CustomReader
                        insertIndex = HandleUseCustomReader(ref method, indent2, insertIndex, storedProcedureVariableName, tag);
                    }

                    // Insert a codeLine
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, insertIndex, tag);
                }
                else
                {
                    // do not insert
                    insertIndex = -1;
                }

                // return value
                return insertIndex;
            }
            #endregion
            
            #region HandleCopyAndModifyMethod(ref List<CodeLine> method, string storedProcedureVariableName)
            /// <summary>
            /// This method Handle Modify Method
            /// </summary>
            public void HandleCopyAndModifyMethod(ref List<CodeLine> method, string storedProcedureVariableName)
            {
                // locals
                int instanciateIndex = -1;
                int createParametersIndex = -1;
                int methodDeclarationIndex = -1;
                bool modified = false;
                CodeLine codeLine = null;
                string variableName = null;
                int spaces = 0;
                string indent;
                string indent2;
                string indent3 = "";
                string openBracket;
                string closeBracket;
                string openBracket2;
                string closeBracket2;
                string parameterLine;
                bool abort = false;
                int returnValueIndex = -1;
                List<CodeLine> createPrimaryKeyParameters = new List<CodeLine>();

                // If the MethodInfo object exists
                if ((this.HasMethodInfo) && (MethodInfo.HasSelectedTable) && (ListHelper.HasOneOrMoreItems(method)))
                {
                    // now create a codeLine
                    variableName = CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.SelectedTable.ClassName);

                    // get the instanciateIndex
                    instanciateIndex = CodeLineHelper.GetIndex(method, "// instanciate");

                    // If this is a Find By or Update By procedure
                    if ((MethodInfo.MethodType == MethodTypeEnum.Find_By) || (MethodInfo.MethodType == MethodTypeEnum.Update))
                    {
                        // set the createParametersIndex
                        createParametersIndex = CodeLineHelper.GetIndex(method, "// Now create parameters for this procedure");
                    }
                    // If this is a Delete By procedure
                    else if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                    {
                        // set the createParametersIndex
                        createParametersIndex = CodeLineHelper.GetIndex(method, "// Now Create Parameters For The DeleteProc");
                    }

                    // get the methodDeclarationIndex
                    methodDeclarationIndex = CodeLineHelper.GetIndex(method, "public static");

                    // if the instanciateIndex is more lines than expected, this has been modified
                    if (instanciateIndex > (createParametersIndex + 4))
                    {
                        // set to true
                        modified = true;
                    }

                    // if not modified (base method copied as is)
                    if (!modified)
                    {
                        // If the value for methodDeclarationIndex is greater than zero
                        if (methodDeclarationIndex > 0)
                        {
                            // get the codeLine
                            codeLine = method[methodDeclarationIndex];

                            // if the method declaration line does not have the new keyword yet
                            if (!codeLine.Text.Trim().StartsWith("public static new"))
                            {
                                // add the word new to the override
                                codeLine.Text = codeLine.Text.Replace("public static" , "public static new");
                            }
                        }
                            
                        // if the createParametersIndex is set and this is a Find By or a Delete By Proc
                        if ((createParametersIndex > 0) && ((MethodInfo.MethodType == MethodTypeEnum.Find_By) || (MethodInfo.MethodType == MethodTypeEnum.Delete_By)))
                        {
                            // add the comment and line that adds the PrimaryKey parameter 
                            // (this is needed for unmodified methods to move the Primary Key
                            createPrimaryKeyParameters.Add(method[createParametersIndex]);
                            createPrimaryKeyParameters.Add(method[createParametersIndex + 1]);

                            // set the codeLine
                            codeLine = method[createParametersIndex];

                            // get the spacesCount
                            spaces = TextHelper.GetSpacesCount(codeLine.Text);
                            
                            // set the indent to use
                            indent = TextHelper.Indent(spaces);

                            // set the open and close brackets
                            openBracket = indent + "{";
                            closeBracket = indent + "}";
                            
                            // get 4 extra spaces
                            indent2 = TextHelper.Indent(spaces + 8);

                            // Write out the test to change the procedureName                            
                            createParametersIndex = HandleChangeProcedureName(ref method, spaces, indent, indent2, variableName, createParametersIndex, storedProcedureVariableName, openBracket, closeBracket, false);

                            // if the createParametersIndex is set
                            if (createParametersIndex >= 1)
                            {
                                // if the line below is a blank line, a blank line was added before the "else" line and it needs to be 
                                // changed to a comment
                                if (method[createParametersIndex - 1].IsBlankLine)
                                {
                                    // remove this blank line
                                    method.RemoveAt(createParametersIndex - 1);

                                    // Decrement the value for createParametersIndex
                                    createParametersIndex--;
                                }
                            }

                            // now write out the else and move the Create parameters method
                            string elseStatement = indent + "else";

                            // Insert a codeLine
                            createParametersIndex = CodeLineHelper.InsertCodeLine(ref method, elseStatement, createParametersIndex);
                            
                            // Insert a codeLine
                            createParametersIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, createParametersIndex);

                            // Iterate the collection of CodeLine objects
                            foreach (CodeLine line in createPrimaryKeyParameters)
                            {
                                // Insert a codeLine with an extra 4 spaces
                                createParametersIndex = CodeLineHelper.InsertCodeLine(ref method, "    " + line.Text, createParametersIndex);
                            }

                            // Insert a codeLine
                            createParametersIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, createParametersIndex);
                            
                            // now we must take out the two existing lines for CreatePrimaryKey parameter that was just moved
                            if (method.Count > (createParametersIndex + 2))
                            {
                                // remove the existing two likes for CreatePrimaryKeyParameter and the comment
                                method.RemoveAt(createParametersIndex + 1);
                                method.RemoveAt(createParametersIndex);
                            }

                            // if this is a FindBy method and UseCustomReader is true and the MethodInfo.CustomReader object exists
                            if ((MethodInfo.MethodType == MethodTypeEnum.Find_By) && (MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader))
                            {
                                // Insert the lines for using a CustomReader
                                HandleUseCustomReader(ref method, indent3, createParametersIndex, storedProcedureVariableName);
                            }
                        }
                        // If a Load method
                        else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                        {
                            // get the first openBracketIndex
                            returnValueIndex = CodeLineHelper.GetIndex(method, "// return value");

                            // If the value for returnValueIndex is greater than zero
                            if (returnValueIndex > 0)
                            {
                                // get the codeLine
                                codeLine = method[returnValueIndex];

                                // get the spacesCount
                                spaces = TextHelper.GetSpacesCount(codeLine.Text);
                            
                                // set the indent to use
                                indent = TextHelper.Indent(spaces);

                                // get the next level of indention
                                indent2 = TextHelper.Indent(spaces + 4);

                                // set the text for the third level of indention
                                indent3 = TextHelper.Indent(spaces + 8);

                                // set the open and close brackets
                                openBracket = indent + "{";
                                closeBracket = indent + "}";

                                // set the open and close brackets for indention level 2
                                openBracket2 = indent2 + "{";
                                closeBracket2 = indent2 + "}";

                                // set the comment for the if statement
                                string ifParameterExistsComment = indent + "// if the " + variableName + " object exists";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, ifParameterExistsComment, returnValueIndex);

                                // now create the ifParameter exists
                                string ifParameterExists = indent + "if (" + variableName + " != null)";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, ifParameterExists, returnValueIndex);

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, returnValueIndex);

                                // Write comment If LoadBy[Field] is true
                                string ifLoadByFieldIsTrueComment = indent2 + "// if " + MethodInfo.PropertyName + " is true";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, ifLoadByFieldIsTrueComment, returnValueIndex);

                                // Write If LoadBy[Field] is true
                                string ifLoadByFieldIsTrue = indent2 + "if (" + variableName + "." + MethodInfo.PropertyName + ")";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, ifLoadByFieldIsTrue, returnValueIndex);

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket2, returnValueIndex);

                                // string for changeProcedureNameComment
                                string changeProcedureNameComment = indent3 + "// Change the procedure name";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, changeProcedureNameComment, returnValueIndex);

                                // now change the procedureName
                                string newProcedureNameText = indent3 + storedProcedureVariableName + ".ProcedureName = \"" + MethodInfo.ProcedureName + "\";";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, newProcedureNameText, returnValueIndex);

                                // Insert a blank codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, indent3, returnValueIndex);

                                // if this is a SingleField Parameter
                                if ((MethodInfo.ParameterType == ParameterTypeEnum.Single_Field) && (MethodInfo.HasParameterField))
                                {  
                                    // string for change the procedureName
                                    string createParameterComment = indent3 + "// Create the @" + MethodInfo.ParameterField.FieldName + " parameter";

                                    // Insert a codeLine
                                    returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, createParameterComment, returnValueIndex);

                                    // if a ParameterName is set use it
                                    if (MethodInfo.HasParameterName)
                                    {
                                        // set the parameterLine
                                        parameterLine = indent3 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + MethodInfo.ParameterName + "\", " + variableName + "." + MethodInfo.ParameterField.FieldName + ");";
                                    }
                                    else
                                    {
                                        // set the parameterLine
                                        parameterLine = indent3 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + MethodInfo.ParameterField.FieldName + "\", " + variableName + "." + MethodInfo.ParameterField.FieldName + ");";
                                    }

                                    // Insert a codeLine
                                    returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, parameterLine, returnValueIndex);
                                }
                                else if ((MethodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (MethodInfo.HasParameterFieldSet) && (MethodInfo.ParameterFieldSet.HasFields))
                                {
                                    // string for change the procedureName
                                    string createParametersComment = indent3 + "// Create the " + MethodInfo.ParameterFieldSet.Name + " field set parameters";

                                    // Insert a codeLine
                                    returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, createParametersComment, returnValueIndex);

                                    // get the parameterLine
                                    parameterLine = GetFieldSetParameterLine(MethodInfo.ParameterFieldSet, indent3, storedProcedureVariableName, variableName, ref abort);

                                    // Insert a codeLine
                                    returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, parameterLine, returnValueIndex);
                                }

                                // if UseCustomReader is true and the CustomReader object exists
                                if ((MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader))
                                {
                                    // Add the lines for UseCustomReader and setting the CustomReaderName
                                    HandleUseCustomReader(ref method, indent3, returnValueIndex, storedProcedureVariableName);
                                }

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket2, returnValueIndex);

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, returnValueIndex);

                                // Insert a blank codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, indent, returnValueIndex);
                            }
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                        {
                            // set this
                            spaces = 16;

                             // set the indent to use
                            indent = TextHelper.Indent(spaces);

                            // get the next level of indention
                            indent2 = TextHelper.Indent(spaces + 4);

                            // set the text for the third level of indention
                            indent3 = TextHelper.Indent(spaces + 8);

                            // set the open and close brackets
                            openBracket = indent2 + "{";
                            closeBracket = indent2 + "}";

                            // set the open and close brackets for indention level 2
                            openBracket2 = indent3 + "{";
                            closeBracket2 = indent3 + "}";

                            // if this is a SingleField Parameter
                            if ((MethodInfo.ParameterType == ParameterTypeEnum.Single_Field) && (MethodInfo.HasParameterField))
                            {
                                // Update Single Field & No Parameter has not been written yet. 

                                // string for change the procedureName
                                string createParameterComment = indent3 + "// Create the @" + MethodInfo.ParameterField.FieldName + " parameter";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, createParameterComment, returnValueIndex);

                                // set the parameterLine
                                parameterLine = indent3 + storedProcedureVariableName + ".Parameters = SqlParameterHelper.CreateSqlParameters(\"@" + MethodInfo.ParameterField.FieldName + "\", " + variableName + "." + MethodInfo.ParameterField.FieldName + ");";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, parameterLine, returnValueIndex);
                            }
                            else if ((MethodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (MethodInfo.HasParameterFieldSet) && (MethodInfo.ParameterFieldSet.HasFields))
                            {
                                // Write a blank link
                                returnValueIndex =  CodeLineHelper.InsertCodeLine(ref method, indent, createParametersIndex);

                                // Write Coment                                
                                string comment = indent2 + "// If the value for " + MethodInfo.PropertyName + " is true";

                                // Write the comment
                                returnValueIndex =  CodeLineHelper.InsertCodeLine(ref method, comment, returnValueIndex);

                                // build the string
                                string ifStatement = indent2 + "if (" + variableName + "." + MethodInfo.PropertyName + ")";

                                // Write the IfStatement
                                returnValueIndex =  CodeLineHelper.InsertCodeLine(ref method, ifStatement, returnValueIndex);

                                // Insert the open bracket
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, returnValueIndex);

                                // Write Comment Change ProcedureName

                                // Need 4 more spaces here                                
                                comment = indent3 + "// change procedure name";
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, comment, returnValueIndex);

                                  // now change the procedureName
                                string changeProcedureNameText = GetChangeProcedureNameText(indent3, storedProcedureVariableName, MethodInfo.ProcedureName);

                                // Insert the change procedureName
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, changeProcedureNameText, returnValueIndex);

                                // Write a blank line
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, indent3, returnValueIndex);

                                // string for change the procedureName
                                string createParametersComment = indent3 + "// Create the " + MethodInfo.ParameterFieldSet.Name + " field set parameters";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, createParametersComment, returnValueIndex);

                                // get the parameterLine
                                parameterLine = GetFieldSetParameterLine(MethodInfo.ParameterFieldSet, indent3, storedProcedureVariableName, variableName, ref abort);

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, parameterLine, returnValueIndex);

                                // Insert the close bracket
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, returnValueIndex);

                                // set the elseText
                                string elseText = indent2 + "else";

                                // Insert a codeLine
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, elseText, returnValueIndex);

                                // Insert the open bracket
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, returnValueIndex);

                                // get this line
                                string line = method[returnValueIndex].Text;

                                // Push the existing line four spaces to the right
                                method[returnValueIndex].Text = "    " + line;

                                // Move the line above it also                                
                                line = method[returnValueIndex + 1].Text;

                                // Push the existing line four spaces to the right
                                method[returnValueIndex + 1].Text = "    " + line;

                                // Insert the close bracket
                                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, returnValueIndex + 2);                               
                            }
                        }
                    }                    
                }
            }
            #endregion
            
            #region HandleCopyAndModifyMethodCall(ref List<CodeLine> codeLines, string baseWriterFile, string writerMethodName, string storedProcedureVariableName, string writerFile, bool isOverridesMessagePresent)
            /// <summary>
            /// This method Handle Copy And Modify Method Call
            /// </summary>
            public void HandleCopyAndModifyMethodCall(ref List<CodeLine> codeLines, string baseWriterFile, string writerMethodName, string storedProcedureVariableName, string writerFile, bool isOverridesMessagePresent)
            {
                // Here we must find the method for the base Writer method

                // local
                int index = -1;

                // Get the codeLines from the base writer file, so the method can be found from the base writer
                // and modify it to include the method being created.
                List<CodeLine> codeLines2 = CodeLineHelper.CreateCodeLines(baseWriterFile);

                // If the codeLines2 collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines2))
                {
                    // Get the CodeLines that make up the method from the #region to #endregion
                    List<CodeLine> method = CodeLineHelper.GetMethod(codeLines2, writerMethodName);

                    // add a blank line to below this method, and if it is an extra blank line 
                    // it will be removed when the file is written out.

                    // if the method was copied
                    if (ListHelper.HasOneOrMoreItems(method))
                    {
                        // get the firstLine from the method
                        CodeLine firstLine = method[0];

                        // get the spacesCount from the firstLine
                        int spacesCount = TextHelper.GetSpacesCount(firstLine.Text);

                        // Create the indent x # of spaces 
                        string indent = TextHelper.Indent(spacesCount);

                        // Create a new codeLine
                        CodeLine blankLine = new CodeLine(indent);

                        // Add this line
                        method.Add(blankLine);

                        // if the value for isOverridesMessagePresent is true
                        if (isOverridesMessagePresent)
                        {
                            // get the index
                            index = CodeLineHelper.RemoveOverridesMessage(codeLines);
                        }
                        else
                        {
                            // Get the insert in9dex for this method
                            index = CodeLineHelper.GetInsertIndexForMethod(codeLines, writerMethodName);
                        }

                        // if the where to insert is set
                        if (index > 0)
                        {
                            // First we must copy the method from the base class and 
                            // modify the Method to handle the new Procedure.
                            HandleCopyAndModifyMethod(ref method, storedProcedureVariableName);

                            // Insert the CodeLines for this method
                            CodeLineHelper.InsertCodeLines(ref codeLines, method, index);

                            // Write out the file text 
                            CodeLineHelper.WriteFileText(codeLines, writerFile, true);
                        }
                    }
                }
            }
            #endregion
            
            #region HandleIfUseCustomReader(ref List<CodeLine> method, ref List<Guid> codeIdsToRemove, string comment, string tag, string indent, string indent2, string indent3, string storedProcedureVariableName, int insertIndex)
            /// <summary>
            /// This method returns the If Use Custom Reader
            /// </summary>
            public int HandleIfUseCustomReader(ref List<CodeLine> method, ref List<Guid> codeIdsToRemove, string comment, string tag, string indent, string indent2, string indent3, string storedProcedureVariableName, int insertIndex)
            {
                // Here we must insert the comment and code for if (storedProcedure.UseCustomReader) 
                // And then use the CustomReader to load
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, comment, insertIndex, tag);

                // get the line for ifUseCustomReader - Example - if (person.LoadByCompany)
                string ifUseCustomReader = indent + "if (" + storedProcedureVariableName + ".UseCustomReader)";

                // insert the ifUseCustomReader line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, ifUseCustomReader, insertIndex, tag);

                // get the openBracket
                string openBracket = indent + "{";

                // insert the openBracket line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, insertIndex, tag);

                // Now write if CustomReaderName equals test and if true change the procedure name
                insertIndex = HandleUseCustomReaderByName(ref method, ref codeIdsToRemove, comment, tag, indent2, indent3, insertIndex, storedProcedureVariableName, false);

                // get the openBracket
                string closeBracket = indent + "}";

                // insert the closeBracket line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, insertIndex, tag);

                // get a blankLine
                string elseLine = indent + "else";

                // insert the elseLine line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, elseLine, insertIndex, tag);

                // insert the openBracket line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket, insertIndex, tag);

                // move the indent for this line
                codeIdsToRemove.Add(method[insertIndex].Id);
                method[insertIndex].Text = "    " + method[insertIndex].Text;
                method[insertIndex].Tag = tag;

                // Increment the value for insertIndex
                insertIndex++;

                // move the indent for this line
                codeIdsToRemove.Add(method[insertIndex].Id);
                method[insertIndex].Text = "    " + method[insertIndex].Text;
                method[insertIndex].Tag = tag;

                // Increment the value for insertIndex
                insertIndex++;

                // insert the closeBracket line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket, insertIndex, tag);

                // return value
                return insertIndex;
            }
            #endregion
            
            #region HandleInsertPrivateVariable(ref List<CodeLine codeLines)
            /// <summary>
            /// This method Handle Insert Private Variable
            /// </summary>
            public void HandleInsertPrivateVariable(ref List<CodeLine> codeLines)
            {
                // locals
                int insertIndex = -1;
                int spacesCount = 0;
                string temp = "";
                string code = "";
                int privateVariableIndex = -1;
                CodeLine codeLine;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // get the regionInfo
                    RegionInfo regionInfo = CodeLineHelper.GetPrivateVariablesRegionInfo(codeLines);

                    // If the regionInfo object exists
                    if (NullHelper.Exists(regionInfo))
                    {
                        // get the EndIndex
                        insertIndex = regionInfo.EndIndex;
                    }

                    // if the insertIndex is set
                    if (insertIndex > 0)
                    {
                        // get the endRegionText
                        string endRegionText = codeLines[insertIndex].Text;

                        // get the spacesCount
                        spacesCount = TextHelper.GetSpacesCount(endRegionText);

                        // get the code
                        temp = "private bool " + CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.PropertyName) + ";";

                        // Get the line to insert
                        code = TextHelper.Indent(spacesCount) + temp;

                        // get the index of this private variable if it already exists
                        privateVariableIndex = CodeLineHelper.GetIndex(codeLines, code, true);

                        // set abortPrivateVariableInsert to true if the index was found
                        abortPrivateVariableInsert = (privateVariableIndex > -1);

                        // if the value for abortPrivateVariableInsert is false
                        if (!abortPrivateVariableInsert)
                        {
                            // Create a codeLine
                            codeLine = new CodeLine(code);

                            // insert
                            codeLines.Insert(insertIndex, codeLine);
                        }
                    }
                }
            }
            #endregion
            
            #region HandleInsertProperty(ref List<CodeLine> codeLines)
            /// <summary>
            /// This method Handle Insert Property
            /// </summary>
            public void HandleInsertProperty(ref List<CodeLine> codeLines)
            {
                // locals
                string text = "";
                int insertIndex = -1;
                int spacesCount = 0;
                CodeLine codeLine = null;
                int existingPropertiesCount = 0;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // get the insertIndex
                    insertIndex = CodeLineHelper.GetInsertIndexForProperty(codeLines, MethodInfo.PropertyName, ref spacesCount, ref existingPropertiesCount);

                    // if the insertIndex was found
                    if (insertIndex > 1)
                    {
                        // local
                        CodeLine line = codeLines[insertIndex];

                        // if the line is not a blank line
                        if (!line.IsBlankLine)
                        {
                            // get the line above
                            CodeLine lineAbove = codeLines[insertIndex - 1];

                            // if the lineAbove is not blank
                            if (!lineAbove.IsBlankLine)
                            {
                                // Add a blank line after the property
                                text = "";

                                // create the codeLine
                                codeLine = new CodeLine(text);

                                // insert the codeLine
                                codeLines.Insert(insertIndex, codeLine);

                                // increment the value for InsertIndex
                                insertIndex++;
                            }
                        }

                        // get the text
                        text = TextHelper.Indent(spacesCount + 4) + "#region " + this.MethodInfo.PropertyName;

                        // get the index of this property
                        int propertyIndex = CodeLineHelper.GetIndex(codeLines, text, true);

                        // abort the property if the index was found
                        AbortPropertyInsert = propertyIndex > -1;

                        // if the Property does not already exist
                        if (!AbortPropertyInsert)
                        {
                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // get the text
                            text = TextHelper.Indent(spacesCount + 4) + "/// <summary>";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // get the text
                            text = TextHelper.Indent(spacesCount + 4) + "/// This property gets or sets the value for '" + MethodInfo.PropertyName + "'.";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // get the text
                            text = TextHelper.Indent(spacesCount + 4) + "/// </summary>";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // End Summary

                            // set the text for the MethodDeclarationLine
                            text = TextHelper.Indent(spacesCount + 4) + "public bool " + MethodInfo.PropertyName;

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // set the text for the MethodDeclarationLine
                            text = TextHelper.Indent(spacesCount + 4) + "{";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // get the text for the get
                            text = TextHelper.Indent(spacesCount + 8) + "get { return " + CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.PropertyName) + "; }";

                                // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // get the text for the set
                            text = TextHelper.Indent(spacesCount + 8) + "set { " + CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.PropertyName) + " = value; }";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // set the text for the close bracket
                            text = TextHelper.Indent(spacesCount + 4) + "}";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;
                            
                            // set the text for the endregion
                            text = TextHelper.Indent(spacesCount + 4) + "#endregion";

                            // create the codeLine
                            codeLine = new CodeLine(text);

                            // insert the codeLine
                            codeLines.Insert(insertIndex, codeLine);

                            // increment the value for InsertIndex
                            insertIndex++;

                            // if this line is not blank
                            if (!codeLines[insertIndex].IsBlankLine)
                            {
                                // Add a blank line after the property
                                text = "";

                                // create the codeLine
                                codeLine = new CodeLine(text);

                                // insert the codeLine
                                codeLines.Insert(insertIndex, codeLine);
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region HandleUpdateMethod(ref List<CodeLine> codeLines, string writerMethodName, string storedProcedureVariableName)
            /// <summary>
            /// This method Handle Update Method
            /// </summary>
            public void HandleUpdateMethod(ref List<CodeLine> codeLines, string writerMethodName, string storedProcedureVariableName, string writerFile)
            {
                // here we are updating a file that has already been copied from the base class, and the Create Stored Procedure method already exists

                // locals
                string variableName = "";
                int insertIndex = -1;
                List<CodeLine> method = null;
                CodeLine codeLine = null;
                int index = -1;
                int spaces = 0;
                string indent = "";
                string indent2 = "";
                Guid lineId = Guid.Empty;
                string openBracket = "";
                string closeBracket = "";
                List<CodeLine> createPrimaryKeyParameters = new List<CodeLine>();

                // set the variableName
                variableName = CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.SelectedTable.ClassName);

                // Get the CodeLines that make up the method from the #region to #endregion
                method = CodeLineHelper.GetMethod(codeLines, writerMethodName);

                // if this is a Find by stored procedure
                if ((methodInfo.MethodType == MethodTypeEnum.Find_By) || (methodInfo.MethodType == MethodTypeEnum.Delete_By))
                {
                    // the method has been modified. We only have to add an If statement to it
                    insertIndex = CodeLineHelper.GetIndex(method, "else", true);
            
                    // set the codeLine
                    codeLine = method[insertIndex];

                    // get the spacesCount
                    spaces = TextHelper.GetSpacesCount(codeLine.Text);
                            
                    // set the indent to use
                    indent = TextHelper.Indent(spaces);

                    // get 4 extra spaces
                    indent2 = TextHelper.Indent(spaces + 4);

                    // set the open and close brackets
                    openBracket = indent + "{";
                    closeBracket = indent + "}";

                    // get the changeProcedureNameText
                    string changeProcedureNameText = GetChangeProcedureNameText(indent2, storedProcedureVariableName, MethodInfo.ProcedureName);

                    // test if this line is already written
                    index = CodeLineHelper.GetIndex(method, changeProcedureNameText, true);

                    // AbortWriterInsert if the index was found
                    AbortWriterInsert = (index > -1);

                    // if not abort
                    if (!AbortWriterInsert)
                    {
                        // Add the new method
                        HandleChangeProcedureName(ref method, spaces, indent, indent2, variableName, insertIndex, storedProcedureVariableName, openBracket, closeBracket, true);

                        // create a subset of codeLines
                        List<CodeLine> subSet = new List<CodeLine>();

                        // iterate the method
                        foreach(CodeLine temp in method)
                        {
                            // if this one of the new lines created
                            if ((temp.HasTag) && (temp.Tag == variableName))
                            {
                                // add this line
                                subSet.Add(temp);
                            }
                        }

                        // get the insertIndex
                        insertIndex = CodeLineHelper.GetIndex(codeLines, codeLine.Id);

                        // get the insertIndex of the new line
                        CodeLineHelper.InsertCodeLines(ref codeLines, subSet, insertIndex);

                        // fixing space above the else line
                        
                        // Find the index of Else again
                        insertIndex = CodeLineHelper.GetIndex(method, "else", true);

                        // if the value for insertIndex is greater than 1
                        if (insertIndex > 1)
                        {
                            // if the line above the else is a blank line, remove it.
                            if (codeLines[insertIndex - 1].IsBlankLine)
                            {
                                // remove the blank line above the else statement
                                codeLines.RemoveAt(insertIndex - 1);
                            }
                        }

                        // Write out the file text 
                        CodeLineHelper.WriteFileText(codeLines, writerFile, true);
                    }
                }
                else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                {
                    // get the index of the last open bracket at the most indented level
                    insertIndex = CodeLineHelper.GetLastMostIndentedCloseBracketIndex(method);

                    // if the index was found
                    if (insertIndex >= 0)
                    {
                        // get the index
                        codeLine = method[insertIndex];

                        // get the id
                        lineId = codeLine.Id;

                        // get the spaces count
                        spaces = TextHelper.GetSpacesCount(codeLine.Text);

                        // indent this many spaces
                        indent = TextHelper.Indent(spaces);

                            // get 4 extra spaces
                        indent2 = TextHelper.Indent(spaces + 4);

                        // set the open and close brackets
                        openBracket = indent + "{";
                        closeBracket = indent + "}";

                        // get the changeProcedureNameText
                        string changeProcedureNameText = GetChangeProcedureNameText(indent2, storedProcedureVariableName, MethodInfo.ProcedureName);

                        // test if this line is already written
                        index = CodeLineHelper.GetIndex(method, changeProcedureNameText, true);

                        // AbortWriterInsert if the index was found
                        AbortWriterInsert = (index > -1);

                        // if not abort
                        if (!AbortWriterInsert)
                        {
                            // Add the new method
                            HandleChangeProcedureName(ref method, spaces, indent, indent2, variableName, insertIndex + 1, storedProcedureVariableName, openBracket, closeBracket, true);

                            // create a subset of codeLines
                            List<CodeLine> subSet = new List<CodeLine>();

                            // iterate the method
                            foreach(CodeLine temp in method)
                            {
                                // if this one of the new lines created
                                if ((temp.HasTag) && (temp.Tag == variableName))
                                {
                                    // add this line
                                    subSet.Add(temp);
                                }
                            }

                            // get the insertIndex
                            insertIndex = CodeLineHelper.GetIndex(codeLines, lineId);

                            // get the insertIndex of the new line
                            CodeLineHelper.InsertCodeLines(ref codeLines, subSet, insertIndex + 1);

                            // Write out the file text 
                            CodeLineHelper.WriteFileText(codeLines, writerFile, true);
                        }
                    }
                    else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                    {
                        // get the changeProcedureNameText
                        string changeProcedureNameText = GetChangeProcedureNameText(indent2, storedProcedureVariableName, MethodInfo.ProcedureName);

                        // test if this line is already written
                        index = CodeLineHelper.GetIndex(method, changeProcedureNameText, true);

                        // AbortWriterInsert if the index was found
                        AbortWriterInsert = (index > -1);
                    }
                }
            }
            #endregion
            
            #region HandleUseCustomReader(ref List<CodeLine> method, string indent3, int returnValueIndex, string storedProcedureVariableName, string tag = "")
            /// <summary>
            /// This method is used to Handle Using a Custom Reader.
            /// </summary>
            public int HandleUseCustomReader(ref List<CodeLine> method, string indent3, int returnValueIndex, string storedProcedureVariableName, string tag = "")
            {
                // Insert a blank codeLine
                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, indent3, returnValueIndex, tag);

                // Insert a comment for Set UseCustomReader to true
                string comment = indent3 + "// set UseCustomReader to true";
                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, comment, returnValueIndex, tag);

                    // set UseCustomReader = true
                string useCustomReaderLine = indent3 + storedProcedureVariableName + ".UseCustomReader = true;";
                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, useCustomReaderLine, returnValueIndex, tag);

                // Insert a blank codeLine
                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, indent3, returnValueIndex, tag);

                // set the comment to Set the CustomReaderName
                comment = indent3 + "// set the CustomReaderName";
                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, comment, returnValueIndex, tag);

                // line to set the procedureName
                string setProcedureName = indent3 + storedProcedureVariableName + ".CustomReaderName = \"" + MethodInfo.CustomReader.ReaderName + "\";";
                returnValueIndex = CodeLineHelper.InsertCodeLine(ref method, setProcedureName, returnValueIndex, tag);

                // return value
                return returnValueIndex;
            }
            #endregion

            #region HandleUseCustomReaderByName(ref List<CodeLine> method, ref List<Guid> codeIdsToRemove, string comment, string tag, string indent, string indent2, int insertIndex, string storedProcedureVariableName, bool useElseIf)
            /// <summary>
            /// This method returns the Use Custom Reader By Name
            /// </summary>
            public int HandleUseCustomReaderByName(ref List<CodeLine> method, ref List<Guid> codeIdsToRemove, string comment, string tag, string indent, string indent2, int insertIndex, string storedProcedureVariableName, bool useElseIf)
            {
                // test if this is the readerName specified comment
                string ifReaderNameComment = indent + "// if the CustomReaderName equals " + MethodInfo.CustomReader.ReaderName;

                // insert the ifReaderNameComment line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, ifReaderNameComment, insertIndex, tag);

                // test if this is the readerName specified
                string ifReaderName = indent + "if (" + storedProcedureVariableName + ".CustomReaderName == \"" + MethodInfo.CustomReader.ReaderName + "\")";

                // if the value for useElseIf is true
                if (useElseIf)
                {
                    // use else if instead
                    ifReaderName = ifReaderName.Replace("if (", "else if (");
                }

                // insert the ifReaderName line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, ifReaderName, insertIndex, tag);

                // set openBracket2
                string openBracket2 = indent + "{";

                // insert the openBracket2 line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, openBracket2, insertIndex, tag);

                if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                {
                    // write the load using reader comment
                    string loadComment = indent2 + "// Load using CustomReader " + MethodInfo.CustomReader.ReaderName;

                    // insert the loadComment line
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, loadComment, insertIndex, tag);
                                    
                    // load the collection
                    string load = indent2 + CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.SelectedTable.ClassName) + " = " + MethodInfo.CustomReader.ReaderName + ".Load(row);";

                    // insert the loadCollectionComment line
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, load, insertIndex, tag);
                }
                else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                {
                    // write the load collection using reader comment
                    string loadCollectionComment = indent2 + "// Load Collection using CustomReader " + MethodInfo.CustomReader.ReaderName;

                    // insert the loadCollectionComment line
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, loadCollectionComment, insertIndex, tag);
                                    
                    // load the collection
                    string loadCollection = indent2 + CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.SelectedTable.ClassName) + "Collection = " + MethodInfo.CustomReader.ReaderName + ".LoadCollection(table);";

                    // insert the loadCollectionComment line
                    insertIndex = CodeLineHelper.InsertCodeLine(ref method, loadCollection, insertIndex, tag);
                }

                    // set closeBracket2
                string closeBracket2 = indent + "}";

                // insert the closeBracket2 line
                insertIndex = CodeLineHelper.InsertCodeLine(ref method, closeBracket2, insertIndex, tag);
                
                // return value
                return insertIndex;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to the user did cancel
                this.UserCancelled = true;
            }
            #endregion
            
            #region IsWriterMethodPresent(List<CodeLine> codeLines, string writerMethodName)
            /// <summary>
            /// This method returns the Writer Method Present
            /// </summary>
            public bool IsWriterMethodPresent(List<CodeLine> codeLines, string writerMethodName)
            {
                // initial value
                bool isWriterMethodPresent = false;

                // verify the text exists
                if (TextHelper.Exists(writerMethodName))
                {
                    // local
                    string regionName = "#region " + writerMethodName;

                    // attempt to get the index
                    int index = CodeLineHelper.GetIndex(codeLines, regionName);

                    // set the return value to true if the index was found
                    isWriterMethodPresent = (index >= 0);
                }
                
                // return value
                return isWriterMethodPresent;
            }
            #endregion
            
            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the ParentForm exists
                if (this.HasParentConfirmChangesForm)
                {
                    // Close Form
                    this.ParentConfirmChangesForm.Close();
                }
            }
            #endregion
            
            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// </summary>
            public void OnSave()
            {
                try
                {  
                    // User Did Not Cancel
                    this.UserCancelled = false;

                   // If the ParentConfirmChangesForm object exists
                   if (this.HasParentConfirmChangesForm)
                   {
                        // Close
                        this.ParentConfirmChangesForm.Close();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

            #region Setup(MethodInfo methodInfo, Project project)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Setup(MethodInfo methodInfo, Project project)
            {
                // Set this to true
                this.Loading = true;

                // locals
                string updateText = "";
                string updateText2 = "";
                string updateText3 = "";
                string updateText4 = "";
                string writerMethodName = "";

                // store the args
                this.MethodInfo = methodInfo;
                this.Project = project;
                
                // Set the projectRootPath
                this.ProjectFolderLabel.Text = "Project Folder: " + ProjectFolder;                    

                // Remove everything
                this.CodeItemsListBox.Items.Clear();

                // If the MethodInfo object exists
                if ((this.HasMethodInfo) && (MethodInfo.HasSelectedTable))
                {
                    // get the dataObjectsFolder
                    string gatewayPath = @"DataGateway\Gateway.cs";

                    // if the Template Version is 2
                    if (Project.TemplateVersion == 2)
                    {
                        // V2 inside DataAccessComponent
                        gatewayPath = @"DataAccessComponent\DataGateway\Gateway.cs";
                    }

                    // get the filePath
                    string filePath = @"ObjectLibrary\BusinessObjects\" + MethodInfo.SelectedTable.ClassName + ".business.cs";
                    string writerFile = @"DataAccessComponent\DataManager\Writers\" + MethodInfo.SelectedTable.ClassName + "Writer.cs";

                    // if Version 2
                    if (Project.TemplateVersion == 2)
                    {
                        // Use the Data folder
                        writerFile = @"DataAccessComponent\Data\Writers\" + MethodInfo.SelectedTable.ClassName + "Writer.cs";
                    }
                    
                    switch (MethodInfo.MethodType)
                    {
                        case MethodTypeEnum.Find_By:
                        
                            // set the writerMethodName
                            writerMethodName = "CreateFind" + MethodInfo.SelectedTable.ClassName + "StoredProcedure";

                            // required
                            break;

                        case MethodTypeEnum.Load_By:
                        
                            // set the writerMethodName
                            writerMethodName = "FetchAll" + PluralWordHelper.GetPluralName(MethodInfo.SelectedTable.ClassName, false) + "StoredProcedure";

                            // required
                            break;
                    }

                    // set the updateText
                    updateText = filePath + " - variable: bool " + CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.PropertyName);
                    updateText2 = filePath + " - property: bool " + MethodInfo.PropertyName;
                    updateText3 = writerFile + " - override: " + writerMethodName;
                    updateText4 = gatewayPath + " - add method: " + MethodInfo.MethodName + "(" + MethodInfo.Parameters + ")";
                    

                    // Add each item
                    this.CodeItemsListBox.Items.Add(updateText, true);
                    this.CodeItemsListBox.Items.Add(updateText2, true);
                    this.CodeItemsListBox.Items.Add(updateText3, true);
                    this.CodeItemsListBox.Items.Add(updateText4, true);

                    // if the MethodInfo object exists
                    if ((MethodInfo.UseCustomReader) && (MethodInfo.HasCustomReader))
                    {
                        // get the customReaderFile
                        string customReaderFile = @"DataAccessComponent\DataManager\Readers\" + MethodInfo.CustomReader.ClassName + ".cs";
                        string updateText5 = customReaderFile + " - add custom reader: " + MethodInfo.CustomReader.ReaderName;

                        // set the dataManagerFile
                        string dataManagerFile = @"DataAccessComponent\DataManager\" + MethodInfo.SelectedTable.ClassName + "Manager.cs";

                        // if Version 2
                        if (TemplateVersion == 2)
                        {
                            // Now called Data folder
                            customReaderFile = @"DataAccessComponent\Data\Readers\" + MethodInfo.CustomReader.ClassName + ".cs";
                        }

                        // local used to display the updated Method for the DataManager
                        string updateText6 = "";

                        // If LoadBy
                        if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                        {
                            // Get the text displaying the MethodName to update the DataManager
                            updateText6 = dataManagerFile + " modify method FetchAll" + PluralWordHelper.GetPluralName(MethodInfo.SelectedTable.ClassName, false) + " to use the custom reader.";
                        }
                        // If FindBy
                        else if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                        {
                            // Get the text displaying the MethodName to update the DataManager
                            updateText6 = dataManagerFile + " modify method Find" + MethodInfo.SelectedTable.ClassName + " to use the custom reader.";
                        }

                        // Add these items
                        this.CodeItemsListBox.Items.Add(updateText5, true);
                        this.CodeItemsListBox.Items.Add(updateText6, true);
                    }
                }

                // Setup the SaveButton
                this.SaveCancelControl.SetupSaveButton("Next", 80);

                // turn off loading
                this.Loading = false;
            }
            #endregion

            #region UpdateDataManager()
            /// <summary>
            /// This method Updates the Data Manager
            /// </summary>
            public bool UpdateDataManager()
            {
                // initial value
                bool updated = false;

                // locals
                List<CodeLine> codeLines = null;
                string methodName = "";
                string baseMethodName = "";
                List<CodeLine> method = null;
                int insertIndex = -1;
                string comment = "";
                string indent = "";
                string indent2 = "";
                string indent3 = "";
                int index = -1;
                CodeLine codeLine = null;
                string tag = "";
                List<Guid> codeIdsToRemove = new List<Guid>();
                string storedProcedureVariableName = "";
                
                // if the value for HasProjectFolder is true
                if ((HasProjectFolder) && (HasMethodInfo) && (MethodInfo.HasSelectedTable))
                {
                    // set the writerFile path
                    string dataManagerFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\DataManager", MethodInfo.SelectedTable.ClassName + "Manager.cs");

                    // if new Templates
                    if (TemplateVersion == 2)
                    {
                        // Change the path to the Data folder
                        dataManagerFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\Data", MethodInfo.SelectedTable.ClassName + "Manager.cs");    
                    }

                    // if the file exists
                    if (File.Exists(dataManagerFile))
                    {
                        // locals
                        methodName = MethodInfo.MethodName;
                    
                        // get the index of the wordBy
                        int byIndex = methodInfo.MethodName.IndexOf("By");
                    
                        // if the word By was present
                        if (byIndex > 0)
                        {
                            // set the baseMethodName
                            baseMethodName = methodName.Substring(0, byIndex);

                            // if a LoadBy Method
                            if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                            {
                                // replace to FetchAll. Example: LoadBoats, FetchAllBoats
                                baseMethodName = baseMethodName.Replace("Load", "FetchAll");
                            }
                        }

                        // If the baseMethodName string exists
                        if (TextHelper.Exists(baseMethodName))
                        {
                            // create the codeLines
                            codeLines = CodeLineHelper.CreateCodeLines(dataManagerFile);

                            // get the method that makes up the Find or Load method
                            method = CodeLineHelper.GetMethod(codeLines, baseMethodName);
                        }
                    }

                    // if the method was found
                    if (ListHelper.HasOneOrMoreItems(method))
                    {
                        // set the tag
                        tag = MethodInfo.MethodName;

                        // a different insert index is needed based upon the MethodType
                        if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                        {
                            // set the comment 
                            comment = "// Load " + MethodInfo.SelectedTable.ClassName;
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                        {
                            // set the comment 
                            comment = "// Load Collection";
                        }

                        // get the comment
                        insertIndex = CodeLineHelper.GetIndex(method, comment);

                        // if the insertIndex was foud
                        if (insertIndex > 0) 
                        {
                            // set the codeLine
                            codeLine = method[insertIndex];

                            // get the indent of the current line
                            indent = TextHelper.Indent(TextHelper.GetSpacesCount(method[insertIndex].Text));

                            // Add 4 extra spaces
                            indent2 = indent + TextHelper.Indent(4);

                            // Add 4 extra spaces again
                            indent3 = indent2 + TextHelper.Indent(4);

                            // we must test if this comment already exists
                            comment = indent + "// if UseCustomReader is true";

                            // set the storedProcedureVariableName
                            storedProcedureVariableName = GetDataManagerStoredProcedureVariableName();

                            // test if this index already exists
                            index = CodeLineHelper.GetIndex(method, comment);

                            // if the index was found
                            if (index > 0)
                            {
                                // this means the if UseCustomReader comment is already present.

                                // here alreadyExists is checking if this custom reader name already exists in this method
                                bool alreadyExists = CodeLineHelper.Contains(method, MethodInfo.CustomReader.ReaderName);
                                
                                // if already exists
                                if (alreadyExists)
                                {
                                    // set to true
                                    this.AbortDataManagerInsert = true;

                                    // no reason to update
                                    updated = false;
                                }
                                else
                                {
                                    // here we must right an else if for the custom reader name
                                    insertIndex = CodeLineHelper.GetLastMostIndentedCloseBracketIndex(method);

                                    // if the insertIndex was found
                                    if (insertIndex >= 0)
                                    {
                                        // reset the codeLine
                                        codeLine = method[insertIndex];

                                        // set the indent
                                        indent = TextHelper.Indent(TextHelper.GetSpacesCount(codeLine.Text));

                                        // set indent2
                                        indent2 = indent + TextHelper.Indent(4);

                                        // Add the code to handle using a custom stored procedure if the name matches
                                        HandleUseCustomReaderByName(ref method, ref codeIdsToRemove, comment, tag, indent, indent2, insertIndex + 1, storedProcedureVariableName, true);

                                        // get the insertIndex
                                        insertIndex = CodeLineHelper.GetIndex(codeLines, codeLine.Id) + 1;
                                    }
                                }
                            }
                            else
                            {
                                // Move the current Load object or Load collection method inside an if statement
                                // that determines if UseCustomReader is true or not.
                                HandleIfUseCustomReader(ref method, ref codeIdsToRemove,comment, tag, indent, indent2, indent3, storedProcedureVariableName, insertIndex);

                                // get the insertIndex
                                insertIndex = CodeLineHelper.GetIndex(codeLines, codeLine.Id);
                            }

                            // create a subset of codeLines
                            List<CodeLine> subSet = new List<CodeLine>();

                            // iterate the method
                            foreach(CodeLine temp in method)
                            {
                                // if this one of the new lines created
                                if ((temp.HasTag) && (temp.Tag == tag))
                                {
                                    // add this line
                                    subSet.Add(temp);
                                }
                            }

                            // before getting the insert index, we need to remove any Ids that need to be removed
                            if (ListHelper.HasOneOrMoreItems(codeIdsToRemove))
                            {
                                foreach (Guid codeId in codeIdsToRemove)
                                {
                                    // get the insertIndex
                                    index = CodeLineHelper.GetIndex(codeLines, codeId);

                                    // if the index was found
                                    if (index >= 0)
                                    {
                                        // remove this item
                                        codeLines.RemoveAt(index);
                                    }
                                }
                            }

                            // if the insertIndex was found
                            if ((insertIndex >= 0) && (ListHelper.HasOneOrMoreItems(subSet)))
                            {
                                // get the insertIndex of the new line
                                CodeLineHelper.InsertCodeLines(ref codeLines, subSet, insertIndex);

                                // write out the file text
                                CodeLineHelper.WriteFileText(codeLines, dataManagerFile, true);

                                // set the return value to true
                                updated = true;
                            }
                        }
                    }
                }

                // return value
                return updated;
            }
            #endregion
            
            #region UpdateDataObject()
            /// <summary>
            /// This method updates the data object file.
            /// Example: ProjectFolder\ObjectLibrary\BusinessObjects\Person.business.cs.
            /// </summary>
            public bool UpdateDataObject()
            {
                // initial value
                bool updated = false;
                
                // get the dataObjectFile
                string dataObject = Path.Combine(ProjectFolder,  @"ObjectLibrary\BusinessObjects", MethodInfo.SelectedTable.ClassName + ".business.cs");

                // if the file exists
                if ((File.Exists(dataObject)) && (this.HasMethodInfo))
                {
                    // read all the text of the file
                    string text = File.ReadAllText(dataObject);

                    // get the textLines
                    List<TextLine> textLines = TextHelper.GetTextLines(text);

                    // create the codeLines
                    List<CodeLine> codeLines = CodeLineHelper.CreateCodeLines(textLines);

                    // If the codeLines collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(codeLines))
                    {
                        // Handle the inserting the private variable
                        HandleInsertPrivateVariable(ref codeLines);

                        // Insert the property if it doesn't exist
                        HandleInsertProperty(ref codeLines);

                        // if the value for AbortDataObjectInsert is false
                        if (!AbortDataObjectInsert)
                        {
                            // Write out the file text 
                            CodeLineHelper.WriteFileText(codeLines, dataObject, true);
                        }
                    }

                    // the dataObject was updated
                    updated = true; 
                }
                
                // return value
                return updated;
            }
            #endregion

            #region UpdateGateway()
            /// <summary>
            /// This method updates the data object file.
            /// Example: ProjectFolder\DataGateway\Gateway.cs.
            /// </summary>
            public bool UpdateGateway()
            {
               // initial value
                bool updated = false;

                // get the gatewayFile
                string gatewayFile = Path.Combine(ProjectFolder,  @"DataGateway\Gateway.cs");

                 // if version 2
                if (Project.TemplateVersion == 2)
                {
                    // use the Data folder
                    gatewayFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\DataGateway\Gateway.cs");
                }

                // local
                CodeLine codeLine = null;
                int spaces = 0;
                string indent = "        ";
                string indent2 = "            ";
                string methodReturnValue = "";
                string tempVariableName = "";
                string parameterFieldDataType = "";
                string initialValue = "";
                string methodDescription = "";
                string methodDeclaration = "";
                string performAction = "";
                string parametersList = "";
                string parameter = "";
                FieldSet parameterFieldSet = null;
                string parameter2 = "";
                string parameter3 = "";
                string parameter4 = "";
                string setParameterFieldValueComment = "";
                string setParameterFieldValue = "";

                // if the file exists
                bool fileExists = File.Exists(gatewayFile);

                if ((fileExists) && (MethodInfo != null) && (MethodInfo.HasSelectedTable))
                {
                    // convert the DTN Field back to a DataField
                    DataField parameterField = DataConverter.ConvertDataField(MethodInfo.ParameterField);

                    // Update for DateTime data type
                    parameterFieldDataType = CSharpClassWriter.ConvertDataType(parameterField);

                    // if this is a Delete By procedure
                    if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                    {
                        // set the methodReturnValue
                        methodReturnValue = "deleted";
                    }
                    else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                    {
                        // set the methodReturnValue
                        methodReturnValue = "saved";
                    }
                    else
                    {
                        // set the variableName
                        methodReturnValue = CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.SelectedTable.ClassName);

                        // if this is a Load method
                        if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                        {
                            // get the initialValue
                            methodReturnValue = PluralWordHelper.GetPluralName(methodReturnValue, true);
                        }
                    }

                    // This is the same regardless of ParameterType
                    parametersList = MethodInfo.Parameters;

                    // if this a SingleField procedure and the ParameterField exists
                    if ((MethodInfo.ParameterType == ParameterTypeEnum.Single_Field) && (MethodInfo.HasParameterField))
                    {                        
                        // Get the parametersList from the MethodInfo object instead
                        parametersList = MethodInfo.Parameters;

                        // get the words
                        List<Word> words = TextHelper.GetWords(parametersList);

                        if (ListHelper.HasXOrMoreItems(words, 2))
                        {
                            // set the parameter
                            parameter = words[1].Text;
                        }
                        else
                        {
                            // set the parameter
                            parameter = CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.ParameterField.FieldName);
                        }
                    }
                    else if ((MethodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (MethodInfo.HasParameterFieldSet) && (MethodInfo.ParameterFieldSet.HasFields))
                    {
                        // set the parameterFieldSet
                        parameterFieldSet = MethodInfo.ParameterFieldSet;

                        // if there is at least one field
                        if (parameterFieldSet.Fields.Count > 0)
                        {
                            // get the lowercase of the first field fieldName
                            parameter = CSharpClassWriter.LowerCaseFirstCharEx(parameterFieldSet.Fields[0].FieldName);
                        }

                        // if there is at least one field
                        if (parameterFieldSet.Fields.Count > 1)
                        {
                            // get the lowercase of the second field fieldName
                            parameter2 = CSharpClassWriter.LowerCaseFirstCharEx(parameterFieldSet.Fields[1].FieldName);
                        }

                        // if there are 3 fields
                        if (parameterFieldSet.Fields.Count > 2)
                        {
                            // get the lowercase of the third field fieldName
                            parameter3 = CSharpClassWriter.LowerCaseFirstCharEx(parameterFieldSet.Fields[2].FieldName);
                        }

                        // if there are 4 fields
                        if (parameterFieldSet.Fields.Count > 3)
                        {
                            // get the lowercase of the 4th field fieldName
                            parameter4 = CSharpClassWriter.LowerCaseFirstCharEx(parameterFieldSet.Fields[3].FieldName);
                        }
                    }

                    // get the temp object variableName
                    tempVariableName = "temp" + MethodInfo.SelectedTable.ClassName;

                    // get the codeFile
                    List<CodeLine> codeLines = CodeLineHelper.CreateCodeLines(gatewayFile);

                    // Get the insertIndex
                    int insertIndex = CodeLineHelper.GetInsertIndexForMethod(codeLines, MethodInfo.MethodName);

                    // If the value for insertIndex is greater than zero
                    if (insertIndex > 0)
                    {
                        // set the codeLine
                        codeLine = codeLines[insertIndex];

                        // set the spaces
                        spaces = TextHelper.GetSpacesCount(codeLine.Text);

                        // set the indent
                        indent = TextHelper.Indent(spaces);

                        // set the indent2
                        indent2 = TextHelper.Indent(spaces + 4);
                    }

                    // get the regionText
                    string regionText = indent + "#region " + MethodInfo.MethodName + "(" + parametersList + ")";

                    // get the methodRegionIndex
                    int methodRegionIndex = CodeLineHelper.GetIndex(codeLines, regionText, true);

                    // set the value for AbortGatewayInsert if the index was found
                    AbortGatewayInsert = (methodRegionIndex > -1);

                    // if the value for AbortGatewayInsert is false
                    if (!AbortGatewayInsert)
                    {
                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, regionText, insertIndex);

                        // write out the comments for the method
                        string openSummary = indent + "/// <summary>";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, openSummary, insertIndex);

                        // get the method description by the MethodInfo.MethodType & MethodInfo.ParameterType
                        methodDescription = GetMethodDescription(methodInfo, indent);

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, methodDescription, insertIndex);

                        // write out the comments for the method
                        string closeSummary = indent + "/// </summary>";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, closeSummary, insertIndex);

                        // if this is a Delete
                        if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                        {
                            // set the methodDescription
                            methodDeclaration = indent + "public bool " + MethodInfo.MethodName + "(" + MethodInfo.Parameters + ")";
                        }
                        // if this is a Find
                        else if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                        {
                            // set the methodDeclaration
                            methodDeclaration = indent + "public " + MethodInfo.SelectedTable.ClassName + " " + MethodInfo.MethodName + "(" + MethodInfo.Parameters + ")";
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                        {
                            // set the methodDeclaration
                            methodDeclaration = indent + "public List<" + MethodInfo.SelectedTable.ClassName + "> " + MethodInfo.MethodName + "(" + MethodInfo.Parameters + ")";
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                        {
                            // set the methodDeclaration
                            methodDeclaration = indent + "public bool " + MethodInfo.MethodName + "(" + MethodInfo.Parameters + ")";
                        }

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, methodDeclaration, insertIndex);

                        // set the openBracket
                        string openBracket = indent + "{";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, openBracket, insertIndex);

                        // write out the initialValueComment
                        string initialValueComment = indent2 + "// initial value";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, initialValueComment, insertIndex);

                        if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                        {
                            // get the initialValue
                            initialValue = indent2 + "bool deleted = false;";    
                        }
                        // if this is a Find
                        else if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                        {
                            // get the initialValue
                            initialValue = indent2 + MethodInfo.SelectedTable.ClassName + " " + methodReturnValue + " = null;";    
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)                        
                        {
                            // get the initialValue
                            initialValue = indent2 + "List<" + MethodInfo.SelectedTable.ClassName + "> " + methodReturnValue + " = null;";    
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                        {
                            // set the initialValue
                            initialValue = indent2 + "bool " + methodReturnValue + " = false;";
                        }

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, initialValue, insertIndex);

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);

                        // attemp to find the PrimaryKey
                        DTNField primaryKey = Gateway.FindPrimaryKey(methodInfo.SelectedTable);

                        // set the createTempObjectComment
                        string createTempObjectComment = indent2 + "// Create a temp " + MethodInfo.SelectedTable.ClassName + " object";

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, createTempObjectComment, insertIndex);

                        // set the createTempObject
                        string createTempObject = indent2 + MethodInfo.SelectedTable.ClassName +  " " + tempVariableName + " = new " + MethodInfo.SelectedTable.ClassName + "();";

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, createTempObject, insertIndex);

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);

                        // set the value for setPropertyValueComment
                        string setPropertyValueComment = indent2 + "// Set the value for " + MethodInfo.PropertyName + " to true";

                        // write out the setPropertyValueComment
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setPropertyValueComment, insertIndex);

                        // set the value for setPropertyValue
                        string setPropertyValue = indent2 + tempVariableName + "." + MethodInfo.PropertyName + " = true;";

                        // write out the setPropertyValue
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setPropertyValue, insertIndex);

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);

                        // if this is a SingleField parameter
                        if (MethodInfo.ParameterType == ParameterTypeEnum.Single_Field)
                        {
                            if (MethodInfo.ParameterField.FieldName != parameter)
                            {
                                // set the comment
                                setParameterFieldValueComment = indent2 + "// Using " + MethodInfo.ParameterField.FieldName + " As " + parameter;
                            }
                            else
                            {
                                // set the comment
                                setParameterFieldValueComment = indent2 + "// Set the value for " + MethodInfo.ParameterField.FieldName;
                            }

                            // write out a blank line
                            insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setParameterFieldValueComment, insertIndex);

                            // if this is a Primary Key field
                            if ((MethodInfo.ParameterField.PrimaryKey) && (MethodInfo.ParameterField.DataType == DataTypeEnum.Autonumber))
                            {
                                // set the value
                                setParameterFieldValue = indent2 + tempVariableName + ".UpdateIdentity(" + parameter + ");";
                            }
                            else
                            {
                                // set the value
                                setParameterFieldValue = indent2 + tempVariableName + "." + MethodInfo.ParameterField.FieldName + " = " + parameter + ";";
                            }

                            // write out a blank line
                            insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setParameterFieldValue, insertIndex);

                            // write out a blank line
                            insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);
                        }
                        else if ((MethodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (MethodInfo.HasParameterFieldSet) && (MethodInfo.ParameterFieldSet.HasFields))
                        {
                            // local
                            int fieldNumber = -1;

                            // iterate the fields in the fieldSet
                            foreach (DTNField field in MethodInfo.ParameterFieldSet.Fields)
                            {
                                // Increment the value for fieldNumber
                                fieldNumber++;

                                // set the fieldName for this parameter
                                string fieldName = MethodInfo.ParameterFieldSet.Fields[fieldNumber].FieldName;

                                // set the comment
                                setParameterFieldValueComment = indent2 + "// Set the value for " + CSharpClassWriter.CapitalizeFirstCharEx(fieldName);

                                // write out a blank line
                                insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setParameterFieldValueComment, insertIndex);

                                switch(fieldNumber)
                                {
                                    case 0:

                                        // do nothing here, parameter is already set 
                                        
                                        // required
                                        break;

                                    case 1:

                                        // switching out the parameter
                                        parameter = parameter2;

                                        // required
                                        break;

                                    case 2:

                                        // switching out the parameter
                                        parameter = parameter3;

                                        // required
                                        break;

                                    case 3:
                                    
                                        // switching out the parameter
                                        parameter = parameter4;

                                        // required
                                        break;
                                    
                                }

                                // set the comment
                                setParameterFieldValue = indent2 + tempVariableName + "." + fieldName + " = " + parameter + ";";

                                // write out a blank line
                                insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setParameterFieldValue, insertIndex);

                                // write out a blank line
                                insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);
                            }

                            if ((MethodInfo.MethodType == MethodTypeEnum.Update) && (primaryKey.DataType == DataTypeEnum.Autonumber))
                            {
                                // write out a comment
                                string setMaxIdComment = indent2 + "// set Id to max int value so an Update occurs, not an Insert";
                                insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setMaxIdComment, insertIndex);

                                // set the comment                                
                                setParameterFieldValue = indent2 + tempVariableName + ".UpdateIdentity(Int32.MaxValue);";

                                // write out the line to UpdateIdentity
                                insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, setParameterFieldValue, insertIndex);

                                // write out a blank line
                                insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);
                            }                            
                        }

                        // set the action
                        string action = CSharpClassWriter.LowerCaseFirstCharEx(MethodInfo.MethodName.Substring(0, 4));

                        // if this is a Delete
                        if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                        {
                            // change the action to fix the comment
                            action = "delete";
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                        {
                            action = "save";
                        }

                        // set the performActionComment
                        string performActionComment = indent2 + "// Perform the " + action;

                            // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, performActionComment, insertIndex);

                            // if this is a Find or a Delete
                        if ((MethodInfo.MethodType == MethodTypeEnum.Find_By) || (MethodInfo.MethodType == MethodTypeEnum.Delete_By))
                        {
                            // set the performAction
                            performAction = indent2 + methodReturnValue + " = " + MethodInfo.BaseMethodName + "(0, " + tempVariableName + ");";
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                        {
                            // set the performAction
                            performAction = indent2 + methodReturnValue + " = " + MethodInfo.BaseMethodName + "(" + tempVariableName + ");";
                        }
                        else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                        {
                            // ensure it is Save not Update here
                            string methodName = MethodInfo.BaseMethodName.Replace("Update", "Save");

                            // set the performAction
                            performAction = indent2 + methodReturnValue + " = " + methodName + "(ref " + tempVariableName + ");";
                        }
                        
                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, performAction, insertIndex);

                        // write out a blank line
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent2, insertIndex);

                        // write out the returnValueComment
                        string returnValueComment = indent2 + "// return value";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, returnValueComment, insertIndex);

                        // set the returnValue
                        string returnValue = indent2 + "return " + methodReturnValue + ";";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, returnValue, insertIndex);

                        // set the closeBracket
                        string closeBracket = indent + "}";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, closeBracket, insertIndex);

                        // set the endRegionText
                        string endRegionText = indent + "#endregion";

                        // Insert a codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, endRegionText, insertIndex);

                        // Insert a blank codeLine
                        insertIndex = CodeLineHelper.InsertCodeLine(ref codeLines, indent, insertIndex);

                        // Write out the codeLines
                        CodeLineHelper.WriteFileText(codeLines, gatewayFile, true);

                        // the gateway file was updated
                        updated = true;                        
                    }
                    else
                    {
                        // Update: 1.28.2025: The Gateway already has this method, so no need to abort
                        updated = true;
                    }
                }
                
                // return value
                return updated;
            }
            #endregion
            
            #region UpdateStatus(ListViewItem listItem, bool success)
            /// <summary>
            /// This method updates the status message.
            /// </summary>
            /// <param name="listItem"></param>
            /// <param name="success"></param>
            private void UpdateStatus(ListViewItem listItem, bool success)
            {
                // if the listItem exists
                if (listItem != null)
                {   
                    // if successfull
                    if (success)
                    {
                        // use success
                        listItem.ImageIndex = 0;

                        // Update Text
                        listItem.Text += "Done.";

                        // if no space between the period and Done
                        if (listItem.Text.Contains(".Done"))
                        {
                            // Set the Text
                            listItem.Text = listItem.Text.Replace(".Done", ". Done");
                        }   
                    }
                    else
                    {
                        // use error
                        listItem.ImageIndex = 1;

                        // Update Text
                        listItem.Text = listItem.Text + "Failed.";
                    }

                    // refresh
                    this.Refresh();
                }
            }
            #endregion        
            
            #region UpdateWriter()
            /// <summary>
            /// This method updates the Writer class.
            /// Example: ProjectFolder\DataAccessComponent\Data\PersonWriter.cs.
            /// </summary>
            public bool UpdateWriter()
            {
                // initial value
                bool updated = false;

                // locals
                string methodName = "";
                string baseMethodName = "";
                string writerMethodName = "";
                
                // If the MethodInfo object exists
                if ((this.HasMethodInfo) && (MethodInfo.HasSelectedTable))
                {
                    // locals
                    methodName = MethodInfo.MethodName;
                    
                    // Update 10.20: Chaning the way the baseMethodName is set
                    if (MethodInfo.MethodType == MethodTypeEnum.Find_By)
                    {
                        // set the baseMethodName
                        baseMethodName = "Find" + MethodInfo.SelectedTable.TableName;
                    }
                    else if (MethodInfo.MethodType == MethodTypeEnum.Load_By)
                    {
                        // set the baseMethodName
                        baseMethodName = "Load" + PluralWordHelper.GetPluralName(MethodInfo.SelectedTable.TableName, false);
                    }
                    else if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                    {
                        // set the baseMethodName
                        baseMethodName = "Delete" + MethodInfo.SelectedTable.TableName;
                    }
                    else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                    {
                        // set the baseMethodName
                        baseMethodName = "Update" + MethodInfo.SelectedTable.TableName;
                    }

                    // set the BaseMethodName (needed in the Gateway)
                    MethodInfo.BaseMethodName = baseMethodName;

                    // set the baseMethodName to look for
                    writerMethodName = "Create" + baseMethodName + "StoredProcedure";

                    // if this is a Load procedure
                    if (baseMethodName.StartsWith("Load"))
                    {
                        // set the baseMethodName to look for
                        writerMethodName = writerMethodName.Replace("Load", "FetchAll");
                    }

                    // set the variable name used in the method
                    MethodInfo.StoredProcedureVariableName = CSharpClassWriter.LowerCaseFirstCharEx(baseMethodName.Replace("Load", "FetchAll")) + "StoredProcedure";

                    // set the writerFile path
                    string writerFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\DataManager\Writers\", MethodInfo.SelectedTable.ClassName + "Writer.cs");

                    // set the baseWriterFile path
                    string baseWriterFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\DataManager\Writers\", MethodInfo.SelectedTable.ClassName + "WriterBase.cs");

                    // if the new structure
                    if (Project.TemplateVersion == 2)
                    {
                        // Change to Data folder
                        writerFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\Data\Writers\", MethodInfo.SelectedTable.ClassName + "Writer.cs");
                        baseWriterFile = Path.Combine(ProjectFolder,  @"DataAccessComponent\Data\Writers\", MethodInfo.SelectedTable.ClassName + "WriterBase.cs");
                    }

                    // if the file exists
                    if (File.Exists(writerFile))
                    {
                        // create the codeLines
                        List<CodeLine> codeLines = CodeLineHelper.CreateCodeLines(writerFile);

                        // If the codeLines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(codeLines))
                        {
                            // first we must determine if the write overrides message is present in the file
                            bool isOverridesMessagePresent = CodeLineHelper.IsOverridesWarningPresent(codeLines);

                            // if the overridesMessage is present
                            if (isOverridesMessagePresent)
                            {
                                // Handle copying and modifying the method
                                HandleCopyAndModifyMethodCall(ref codeLines, baseWriterFile, writerMethodName, MethodInfo.StoredProcedureVariableName, writerFile, isOverridesMessagePresent);
                            }
                            else if (IsWriterMethodPresent(codeLines, writerMethodName))
                            {
                                // Handle updating the method
                                HandleUpdateMethod(ref codeLines, writerMethodName, MethodInfo.StoredProcedureVariableName, writerFile);
                            }
                            else
                            {
                                // This means the overrides message is not present, but another method type was created earlier.
                                // Example, first a Find By is copied and then a Load By is created.
                                
                                // Handle copying and modifying the method
                                HandleCopyAndModifyMethodCall(ref codeLines, baseWriterFile, writerMethodName, MethodInfo.StoredProcedureVariableName, writerFile, isOverridesMessagePresent);                                
                            }
                        }

                        // update the dataObject
                        updated = true; 
                    }
                }
                
                // return value
                return updated;
            }
            #endregion
            
        #endregion

        #region Properties

            #region AbortDataManagerInsert
            /// <summary>
            /// This property gets or sets the value for 'AbortDataManagerInsert'.
            /// </summary>
            public bool AbortDataManagerInsert
            {
                get { return abortDataManagerInsert; }
                set { abortDataManagerInsert = value; }
            }
            #endregion
            
            #region AbortDataObjectInsert
            /// <summary>
            /// This read only property returns true if both 
            /// AbortPropertyInsert && AbortPrivateVariableInsert
            /// value is true.
            /// </summary>
            public bool AbortDataObjectInsert
            {
                get
                {
                    // initial value
                    bool abortedDataObjectInsert = ((AbortPropertyInsert && AbortPrivateVariableInsert));
                    
                    // return value
                    return abortedDataObjectInsert;
                }
            }
            #endregion
            
            #region AbortGatewayInsert
            /// <summary>
            /// This property gets or sets the value for 'AbortGatewayInsert'.
            /// </summary>
            public bool AbortGatewayInsert
            {
                get { return abortGatewayInsert; }
                set { abortGatewayInsert = value; }
            }
            #endregion
            
            #region AbortPrivateVariableInsert
            /// <summary>
            /// This property gets or sets the value for 'AbortPrivateVariableInsert'.
            /// </summary>
            public bool AbortPrivateVariableInsert
            {
                get { return abortPrivateVariableInsert; }
                set { abortPrivateVariableInsert = value; }
            }
            #endregion
            
            #region AbortPropertyInsert
            /// <summary>
            /// This property gets or sets the value for 'AbortPropertyInsert'.
            /// </summary>
            public bool AbortPropertyInsert
            {
                get { return abortPropertyInsert; }
                set { abortPropertyInsert = value; }
            }
            #endregion
            
            #region AbortWriterInsert
            /// <summary>
            /// This property gets or sets the value for 'AbortWriterInsert'.
            /// </summary>
            public bool AbortWriterInsert
            {
                get { return abortWriterInsert; }
                set { abortWriterInsert = value; }
            }
            #endregion
            
            #region CustomReaderMustBeIncluded
            /// <summary>
            /// This read only property returns the value for 'CustomReaderMustBeIncluded'.
            /// </summary>
            public bool CustomReaderMustBeIncluded
            {
                get
                {
                    // initial value
                    bool customReaderMustBeIncluded = false;

                    // if the ProjectFileManager.Files.Count is greater than zero
                    if ((HasProjectFileManager) && (projectFileManager.HasFiles) && (projectFileManager.Files.Count > 0))
                    {   
                        // set the return value
                        customReaderMustBeIncluded = true;
                    }
                    
                    // return value
                    return customReaderMustBeIncluded;
                }
            }
            #endregion
            
            #region HasMethodInfo
            /// <summary>
            /// This property returns true if this object has a 'MethodInfo'.
            /// </summary>
            public bool HasMethodInfo
            {
                get
                {
                    // initial value
                    bool hasMethodInfo = (this.MethodInfo != null);
                    
                    // return value
                    return hasMethodInfo;
                }
            }
            #endregion
            
            #region HasParentConfirmChangesForm
            /// <summary>
            /// This property returns true if this object has a 'ParentConfirmChangesForm'.
            /// </summary>
            public bool HasParentConfirmChangesForm
            {
                get
                {
                    // initial value
                    bool hasParentConfirmChangesForm = (this.ParentConfirmChangesForm != null);
                    
                    // return value
                    return hasParentConfirmChangesForm;
                }
            }
            #endregion
            
            #region HasProject
            /// <summary>
            /// This property returns true if this object has a 'Project'.
            /// </summary>
            public bool HasProject
            {
                get
                {
                    // initial value
                    bool hasProject = (this.Project != null);
                    
                    // return value
                    return hasProject;
                }
            }
            #endregion
            
            #region HasProjectFileManager
            /// <summary>
            /// This property returns true if this object has a 'ProjectFileManager'.
            /// </summary>
            public bool HasProjectFileManager
            {
                get
                {
                    // initial value
                    bool hasProjectFileManager = (this.ProjectFileManager != null);
                    
                    // return value
                    return hasProjectFileManager;
                }
            }
            #endregion
            
            #region HasProjectFolder
            /// <summary>
            /// This property returns true if the 'ProjectRootPath' exists.
            /// </summary>
            public bool HasProjectFolder
            {
                get
                {
                    // initial value
                    bool hasProjectFolder = (!String.IsNullOrEmpty(this.ProjectFolder));
                    
                    // return value
                    return hasProjectFolder;
                }
            }
            #endregion
            
            #region Loading
            /// <summary>
            /// This property gets or sets the value for 'Loading'.
            /// </summary>
            public bool Loading
            {
                get { return loading; }
                set { loading = value; }
            }
            #endregion
            
            #region MethodInfo
            /// <summary>
            /// This property gets or sets the value for 'MethodInfo'.
            /// </summary>
            public MethodInfo MethodInfo
            {
                get { return methodInfo; }
                set { methodInfo = value; }
            }
            #endregion
            
            #region ParentConfirmChangesForm
            /// <summary>
            /// This read only property returns the value for 'ParentConfirmRemovalForm'.
            /// </summary>
            public ConfirmChangesForm ParentConfirmChangesForm
            {
                get
                {
                    // initial value
                    ConfirmChangesForm parentConfirmChangesForm = this.ParentForm as ConfirmChangesForm;
                    
                    // return value
                    return parentConfirmChangesForm;
                }
            }
            #endregion

            #region Project
            /// <summary>
            /// This property gets or sets the value for 'Project'.
            /// </summary>
            public Project Project
            {
                get { return project; }
                set { project = value; }
            }
            #endregion
            
            #region ProjectFileManager
            /// <summary>
            /// This property gets or sets the value for 'ProjectFileManager'.
            /// </summary>
            public ProjectFileManager ProjectFileManager
            {
                get { return projectFileManager; }
                set { projectFileManager = value; }
            }
            #endregion
            
            #region ProjectFolder
            /// <summary>
            /// This property gets or sets the value for 'ProjectFolder'.
            /// </summary>
            public string ProjectFolder
            {
                get 
                { 
                    // initial value
                    string projectFolder = "";

                    // if the value for HasProject is true
                    if (HasProject)
                    {
                        // set the return value
                        projectFolder = Project.ProjectFolder;
                    }

                    // return value
                    return projectFolder;
                }
            }
            #endregion

            #region TemplateVersion
            /// <summary>
            /// This read only property returns the TempateVersion from the SelectedProject
            /// </summary>
            public int TemplateVersion
            {
                get
                {
                    // initial value
                    int templateVersion = 2;

                    // if the value for HasProject is true
                    if (HasProject)
                    {
                        // set the return value
                        templateVersion = Project.TemplateVersion;
                    }

                    // return value
                    return templateVersion;
                }
            }
            #endregion

            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
