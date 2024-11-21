
#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using DataTierClient.Forms;
using DataTierClient.Controls.Interfaces;
using DataJuggler.Net.Sql;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataTierClient.ClientUtil;
using DataTier.Net.StoredProcedureGenerator;
using DataTierClient.Objects;
using DataTierClient.Xml.Writers;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataGateway;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class NewStoredProcedureEditor : UserControl, ISaveCancelControl
    /// <summary>
    /// This control is used to create a stored procedure
    /// </summary>
    public partial class NewStoredProcedureEditor : UserControl, ISaveCancelControl, ICheckChangedListener
    {
        
        #region Private Variables
        private MethodInfo methodInfo;
        private InstallProcedureMethodEnum installProcedureMethod;
        private Project openProject;
        private bool customWhere;
        private string fullProcedureText;
        private string storedXml;
        private List<TextLine> linesAfterOrderBy;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NewStoredProcedureEditor' object.
        /// </summary>
        public NewStoredProcedureEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region Button_Enter(object sender, System.EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, System.EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, System.EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, System.EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region ManualUpdateRadioButton_CheckedChanged(object sender, System.EventArgs e)
            /// <summary>
            /// event is fired when Manual Update Radio Button _ Checked Changed
            /// </summary>
            private void ManualUpdateRadioButton_CheckedChanged(object sender, System.EventArgs e)
            {
                // Set to Manual mode
                this.InstallProcedureMethod = InstallProcedureMethodEnum.Manually;

                // Change the text
                this.ProcedureButton.Text = "Copy Procedure";
            }
            #endregion
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // if the value for HasMethodInfo is true
                if (HasMethodInfo)
                {
                    // set the value which toggles the panel
                    MethodInfo.UseCustomWhere = isChecked;

                    // Enable the Save button if there are changes
                    UIEnable();

                    // set this value because the WherePanel shjows or hides based upon it
                    this.CustomWhere = isChecked;
                }
            }
            #endregion
            
            #region ProcedureButton_Click(object sender, System.EventArgs e)
            /// <summary>
            /// event is fired when the 'ProcedureButton' is clicked.
            /// </summary>
            private void ProcedureButton_Click(object sender, System.EventArgs e)
            {
                // locals
                string procedureText = "";
                string ifExistsText = "";
                string temp = "";

                try
                {
                    // Call Save
                    OnSave();

                    // if Install Procedure is Install and the Open Project exists
                    if ((InstallProcedureMethod == InstallProcedureMethodEnum.Install) && (this.HasOpenProject))
                    {
                        // create the SqlConnection
                        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();

                        // set the index
                        int index = this.ProcedureTextBox.Text.ToLower().IndexOf("-- check if the procedure already exists");

                        // if index
                        if (index > 0)
                        {
                            // set the temp
                            temp = this.ProcedureTextBox.Text.Substring(index).Trim();

                            // set the index2
                            int index2 = temp.ToLower().IndexOf("go" + Environment.NewLine);

                            // if the index2 was set
                            if (index2 > 0)
                            {
                                // set the ifExistsText
                                ifExistsText = temp.Substring(0, index2).Trim();
                            }
                        }

                        // Get the text
                        temp = this.ProcedureTextBox.Text.Replace("GO", "").Replace("Go", "");

                        // If the temp string exists
                        if (TextHelper.Exists(temp))
                        {
                            // Get the index
                            index = temp.ToLower().IndexOf("create procedure");

                            // if the index was found
                            if (index >= 0)
                            {
                                // get the procedureText
                                procedureText = temp.Substring(index);
                            }

                            // if the Databases collection exists and there is exactly 1 database
                            if ((this.OpenProject.HasDatabases) && (this.OpenProject.Databases.Count == 1))
                            {
                                // set the ConnectionString
                                connection.ConnectionString = this.OpenProject.Databases[0].ConnectionString;

                                // open
                                connection.Open();

                                // Excecute the procedureText
                                SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, ifExistsText);

                                // Excecute the procedureText
                                SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, procedureText);

                                // close
                                connection.Close();

                                // Show the message
                                MessageHelper.DisplayMessage("The stored procedure has been installed to your SQL Server.", "Procedure Installed");
                            }                    
                        }
                    }
                    else if (installProcedureMethod == InstallProcedureMethodEnum.Manually)
                    {
                        // Set the text
                        Clipboard.SetText(ProcedureTextBox.Text);

                        // Show the message
                        MessageHelper.DisplayMessage("The stored procedure text has been copied to the clipboard.", "Procedure Copied");
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("ProcedureButton_Click", "NewStoredProcedureEditor", error);

                    // Show a message
                    MessageHelper.DisplayMessage("An error occurred installing your stored procedure", "Install Error");
                }
            }
            #endregion
            
            #region ProcedureTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Procedure Text Box _ Text Changed
            /// </summary>
            private void ProcedureTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasMethodInfo is true
                if (HasMethodInfo)
                {
                    // Set the full text
                    MethodInfo.ProcedureText = ProcedureTextBox.Text;

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region UpdateMyDatabaseRadioButton_CheckedChanged(object sender, System.EventArgs e)
            /// <summary>
            /// event is fired when Update My Database Radio Button _ Checked Changed
            /// </summary>
            private void UpdateMyDatabaseRadioButton_CheckedChanged(object sender, System.EventArgs e)
            {
                // Set to Install
                this.InstallProcedureMethod = InstallProcedureMethodEnum.Install;

                // Change the text
                this.ProcedureButton.Text = "Install Procedure";
            }
            #endregion
            
            #region WhereTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Where Text Box _ Text Changed
            /// </summary>
            private void WhereTextBox_TextChanged(object sender, EventArgs e)
            {
                // locals
                bool whereStarted = false;
                bool whereFinished = false;

                // if the MethodInfo object exists
                if (HasMethodInfo)
                {
                    // Get the new text
                    string whereText = WhereTextBox.Text;

                    // set the value in the MethodInfo object
                    MethodInfo.WhereText = whereText + Environment.NewLine;

                    // get the procedureText
                    string procedureText = ProcedureTextBox.Text;

                     // now the existing where text must be replaced
                    int whereIndex = procedureText.ToLower().IndexOf("where [");
    
                    // if the whereIndex was found
                    if (whereIndex >= 0)
                    {
                        // get all the lines after the where
                        string temp = procedureText.Substring(whereIndex);

                        // get the textLines after this whereIndex
                        List<TextLine> endProcedureTextLines = TextHelper.GetTextLines(temp);
                        List<TextLine> linesAfterOrderBy = new List<TextLine>();
                        string postWhereText = "";
                        
                        // if there are one or more items
                        if (ListHelper.HasOneOrMoreItems(endProcedureTextLines))
                        {   
                            // Iterate the collection of TextLine objects
                            foreach (TextLine textLine in endProcedureTextLines)
                            {
                                // if where has not been encountered yet
                                if (!whereStarted)
                                {
                                    // if this is not the where line
                                    if (textLine.Text.TrimStart().ToLower().StartsWith("where ["))
                                    {
                                        // where has Started
                                        whereStarted = true;
                                    }
                                }
                                else if (!whereFinished)
                                {
                                    // if the Text exists
                                    if (!TextHelper.Exists(textLine.Text))
                                    {
                                        // where has finished
                                        whereFinished = true;

                                         // Add this line
                                        linesAfterOrderBy.Add(textLine);
                                    }
                                    else if (textLine.Text.TrimStart().ToLower().StartsWith("order by"))
                                    {
                                        // Add this line
                                        linesAfterOrderBy.Add(textLine);
                                    }
                                    else if (textLine.Text.TrimStart().ToLower().StartsWith("end"))
                                    {
                                        // Add this line
                                        linesAfterOrderBy.Add(textLine);
                                    }
                                }
                                else
                                {
                                    // Add this line
                                    linesAfterOrderBy.Add(textLine);
                                }
                            }
                        }

                        // if there are NOT any lines after order by
                        if ((ListHelper.HasOneOrMoreItems(linesAfterOrderBy)) && (HasLinesAfterOrderBy))
                        {
                            // use the linesAftterOrderBy previously stored
                            linesAfterOrderBy = this.LinesAfterOrderBy;
                        }

                        // if there are any lines after order by
                        if (ListHelper.HasOneOrMoreItems(linesAfterOrderBy))
                        {
                            // store the linesAfterOrderBy, because sometimes typing goes too fast 
                            // for the parsing to keep up (I think)
                            this.LinesAfterOrderBy = linesAfterOrderBy;

                            // Create a new instance of a 'StringBuilder' object.
                            StringBuilder sb = new StringBuilder();

                            // Iterate the collection of TextLine objects
                            foreach (TextLine textLine in linesAfterOrderBy)
                            {
                                // Add this item
                                sb.Append(textLine.Text);
                                sb.Append(Environment.NewLine);
                            }

                            // set the postWhereText
                            postWhereText = sb.ToString();
                        }

                        // set the new ProcedureText
                        procedureText = procedureText.Substring(0, whereIndex) + MethodInfo.WhereText + postWhereText;

                        // set the updated text
                        this.ProcedureTextBox.Text = procedureText;
                    }

                    // Show the save button if there are any changes
                    UIEnable();
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Hide the Save button
                this.SaveCancelControl.SetupSaveButton("Save", 80, true, false);

                // Setup the Done button
                this.SaveCancelControl.SetupCancelButton("Done", 80);         
                
                // Setup the listener
                this.CustomWhereCheckBox.CheckChangedListener = this;
            }
            #endregion
            
            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the ParentNewProcedureEditorForm object exists
                if (this.HasParentNewProcedureEditorForm) 
                {   
                    // Close the Parent Form
                    this.ParentNewProcedureEditorForm.Close();
                }
            }
            #endregion
            
            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// </summary>
            public void OnSave()
            {
                // If the MethodInfo object exists
                if (this.HasMethodInfo)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // find the Method
                    Method method = gateway.FindMethod(this.MethodInfo.MethodId);

                    // if the method was found
                    if (NullHelper.Exists(method))
                    {
                        // Set the text
                        method.ProcedureText = this.ProcedureTextBox.Text;

                        // Make sure the value is still the same
                        method.UseCustomWhere = CustomWhereCheckBox.Checked;

                        // Save the current Text
                        method.WhereText = WhereTextBox.Text;

                        // Save this method
                        bool saved = gateway.SaveMethod(ref method);

                        // if saved
                        if (saved)
                        {
                            // create a new 
                            MethodsWriter methodsWriter = new MethodsWriter();

                            // get the StoredXml
                            StoredXml = methodsWriter.ExportMethodInfo(this.MethodInfo);

                            // Enable controls
                            UIEnable();
                        }
                    }
                }
            }
            #endregion

            #region Setup(MethodInfo methodInfo, Project openProject, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null)
            /// <summary>
            /// This method prepares this control to be shown
            /// </summary>
            public void Setup(MethodInfo methodInfo, Project openProject, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null)
            {
                // store the args
                this.MethodInfo = methodInfo;
                this.OpenProject = openProject;

                // locals
                DataJuggler.Net.DataField parameter = null;
                List<DataJuggler.Net.DataField> parameters = null;
                ProcedureWriter writer = null;

                // If the MethodInfo object exists
                if (this.HasMethodInfo)
                {  
                    // create a new 
                    MethodsWriter methodsWriter = new MethodsWriter();

                    // get the StoredXml
                    StoredXml = methodsWriter.ExportMethodInfo(this.MethodInfo);

                    // if the OrderByFieldSet object exists
                    if (NullHelper.Exists(orderByFieldSet))
                    {
                        // set the gateway
                        Gateway gateway = new Gateway();

                        // load the orderByFields
                        orderByFieldSet.FieldSetFields = gateway.LoadFieldSetFieldViewsByFieldSetId(orderByFieldSet.FieldSetId);
                    }

                    // Set the Name of the Table
                    this.SelectedTableControl.Text = this.MethodInfo.SelectedTable.TableName;
                  
                    // set the procedureName
                    this.ProcedureNameControl.Text = MethodInfo.ProcedureName;

                    // Check the button for Manual Update (user clicks Copy and goes to their SQL instance and executes).
                    this.ManualUpdateRadioButton.Checked = true;

                    // Check the box if UseCustomReader is true
                    this.CustomWhereCheckBox.Checked = MethodInfo.UseCustomWhere;

                    // Set the CustomWhereText (if any)
                    this.WhereTextBox.Text = MethodInfo.WhereText;

                    // convert the table
                    DataJuggler.Net.DataTable table = DataConverter.ConvertDataTable(MethodInfo.SelectedTable, this.OpenProject);

                    // if this is a Single Field Parameter and the Parameter Field exists
                    if ((MethodInfo.ParameterType == ParameterTypeEnum.Single_Field) && (MethodInfo.HasParameterField))
                    {
                        // convert the field from a DTNField to a DataJuggler.Net.DataField 
                        parameter = DataConverter.ConvertDataField(MethodInfo.ParameterField);
                    
                        // Create a new instance of a 'ProcedureWriter' object (in TextWriter mode).
                        writer = new ProcedureWriter(true);

                        // if this is a FindByField method
                        if (writer.HasTextWriter) 
                        {
                            // If Delete By is the Method Type
                            if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                            {
                                // Write out the Delete Proc
                                writer.CreateDeleteProc(table, MethodInfo.ProcedureName, parameter);
                            }
                            // If Find By is the Method Type
                            if (MethodInfo.MethodType == MethodTypeEnum.Find_By) 
                            {  
                                // create a find procedure
                                writer.CreateFindProc(table, false, MethodInfo.ProcedureName, parameter, customReader, orderByField, orderByFieldSet, methodInfo.OrderByDescending, methodInfo.TopRows);
                            }
                            // if Load By is the Method Type
                            else if (MethodInfo.MethodType == MethodTypeEnum.Load_By) 
                            {
                                // If the orderByField object exists
                                if (NullHelper.Exists(orderByFieldSet))
                                {
                                    // if there are not any fields loaded
                                    if (!ListHelper.HasOneOrMoreItems(orderByFieldSet.Fields))
                                    {
                                        // load the Fields
                                        orderByFieldSet.Fields = FieldSetHelper.LoadFieldSetFields(orderByFieldSet.FieldSetId);
                                    }
                                }

                                // create a find procedure
                                writer.CreateFindProc(table, true, MethodInfo.ProcedureName, parameter, customReader, orderByField, orderByFieldSet, methodInfo.OrderByDescending, methodInfo.TopRows);
                            }
                            else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                            {   
                                // Update a single field (you have to write some of this yourself)
                                writer.CreateUpdateProc(table, MethodInfo.ProcedureName, parameter);
                            }
                        }
                    }
                    else if ((MethodInfo.ParameterType == ParameterTypeEnum.Field_Set) && (MethodInfo.HasParameterFieldSet) && (MethodInfo.ParameterFieldSet.HasFields))
                    {   
                        // convert the DTNFields to DataFields
                        parameters = DataConverter.ConvertDataFields(MethodInfo.ParameterFieldSet.Fields);

                        // If the parameters collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(parameters))
                        {
                            // set the FieldSetName so the description writes the method description correctly
                            parameters[0].FieldSetName = MethodInfo.ParameterFieldSet.Name;
                        }

                        // Create a new instance of a 'ProcedureWriter' object (in TextWriter mode).
                        writer = new ProcedureWriter(true);

                        // if this is a FindByField method
                        if (writer.HasTextWriter) 
                        {
                            // If Delete By is the Method Type
                            if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                            {
                                // Write out the Delete Proc
                                writer.CreateDeleteProc(table, MethodInfo.ProcedureName, parameters);
                            }
                            // If Find By is the Method Type
                            if (MethodInfo.MethodType == MethodTypeEnum.Find_By) 
                            {
                                // create a find procedure
                                writer.CreateFindProc(table, false, MethodInfo.ProcedureName, parameters, MethodInfo.CustomReader, orderByField, orderByFieldSet);
                            }
                            // if Load By is the Method Type
                            else if (MethodInfo.MethodType == MethodTypeEnum.Load_By) 
                            {
                                // create a find procedure
                                writer.CreateFindProc(table, true, MethodInfo.ProcedureName, parameters, MethodInfo.CustomReader, orderByField, orderByFieldSet);
                            }
                            else if (MethodInfo.MethodType == MethodTypeEnum.Update)
                            {
                                // create a find procedure
                                writer.CreateUpdateProc(table, MethodInfo.ProcedureName, parameters);
                            }
                        }
                    }
                    else if ((MethodInfo.ParameterType == ParameterTypeEnum.No_Parameters))
                    {
                        // Create a new instance of a 'ProcedureWriter' object (in TextWriter mode).
                        writer = new ProcedureWriter(true);

                        // if this is a FindByField method
                        if (writer.HasTextWriter) 
                        {
                            // If Delete By is the Method Type
                            if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                            {
                                // Write out the Delete Proc
                                writer.CreateDeleteProc(table, MethodInfo.ProcedureName, parameters);
                            }
                            // If Find By is the Method Type
                            if (MethodInfo.MethodType == MethodTypeEnum.Find_By) 
                            {
                                // create a find procedure
                                writer.CreateFindProc(table, false, MethodInfo.ProcedureName, parameters, MethodInfo.CustomReader, orderByField, orderByFieldSet);
                            }
                            // if Load By is the Method Type
                            else if (MethodInfo.MethodType == MethodTypeEnum.Load_By) 
                            {
                                // create a find procedure
                                writer.CreateFindProc(table, true, MethodInfo.ProcedureName, parameters, MethodInfo.CustomReader, orderByField, orderByFieldSet);
                            }
                             // if Load By is the Method Type
                            else if (MethodInfo.MethodType == MethodTypeEnum.Update) 
                            {
                                // create an update procedure
                                writer.CreateUpdateProc(table, MethodInfo.ProcedureName, parameters);
                            }
                        }
                    }

                    // if the writer exists
                    if (NullHelper.Exists(writer))
                    {
                        // get the procedureText
                        string procedureText = writer.TextWriter.ToString();

                        // Show the Where Panel if CustomWhere is true
                        WherePanel.Visible = MethodInfo.UseCustomWhere;

                        // if CustomWhere
                        if (MethodInfo.UseCustomWhere)
                        {
                            // now the existing where text must be replaced
                            int whereIndex = procedureText.ToLower().IndexOf("where [");

                            // if the WhereText does not exist yet
                            if ((!MethodInfo.HasWhereText) && (whereIndex > 0))
                            {
                                // Set the text as it is now
                                string whereText = procedureText.Substring(whereIndex);

                                // If the whereText string exists
                                if (TextHelper.Exists(whereText))
                                {
                                    // get the textLines
                                    List<TextLine> textLines = TextHelper.GetTextLines(whereText);

                                    // If the textLines collection exists and has one or more items
                                    if (ListHelper.HasOneOrMoreItems(textLines))
                                    {
                                        // Create a new instance of a 'StringBuilder' object.
                                        StringBuilder sb = new StringBuilder();

                                        // add each textLine of the Where Clause except the last one
                                        foreach (TextLine textLine in textLines)
                                        {
                                            // if this is the End line
                                            if (!textLine.Text.ToLower().StartsWith("end"))
                                            {
                                                // Add this line
                                                sb.Append(textLine.Text);
                                            }
                                        }

                                        // Get the Where Clause
                                        MethodInfo.WhereText = sb.ToString().Trim();
                                    }
                                }
                            }

                            // Set the WhereText
                            WhereTextBox.Text = MethodInfo.WhereText;
                        
                            // if the whereIndex was found
                            if (whereIndex >= 0)
                            {
                                // if the WhereText does not already exist
                                if (!TextHelper.Exists(MethodInfo.WhereText))
                                {
                                    // Set the default WhereText
                                    MethodInfo.WhereText = procedureText.Substring(whereIndex);
                                }

                                // set the new ProcedureText
                                procedureText = procedureText.Substring(0, whereIndex) + MethodInfo.WhereText + Environment.NewLine + Environment.NewLine + "END";                        
                            }
                        }

                         // Remove any double blank lines
                        procedureText = CodeLineHelper.RemoveDoubleBlankLines(procedureText);

                        // display the procedure As Is for now.
                        this.ProcedureTextBox.Text = procedureText;
                    }
                }
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                // local
                bool hasChanges = false;

                // if the MethodInfo exists
                if ((HasMethodInfo) && (HasStoredXml))
                {
                    // Create a new instance of a 'MethodsWriter' object.
                    MethodsWriter writer = new MethodsWriter();

                    // get the currentXml
                    string currentXml = writer.ExportMethodInfo(this.MethodInfo);

                    // set the value
                    hasChanges = !TextHelper.IsEqual(currentXml, StoredXml);

                    // for debugging only is why this is broken out

                    // if there are changes
                    if (hasChanges)
                    {
                        // Enable the save button if there are changes
                        this.SaveCancelControl.EnableSaveButton(hasChanges);
                    }
                    else
                    {
                        // Enable the save button if there are changes
                        this.SaveCancelControl.EnableSaveButton(hasChanges);
                    }
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region CustomWhere
            /// <summary>
            /// This property gets or sets the value for 'CustomWhere'.
            /// </summary>
            public bool CustomWhere
            {
                get { return customWhere; }
                set 
                { 
                    // set the value
                    customWhere = value;

                    // Show or hide the panel
                    this.WherePanel.Visible = customWhere;
                }
            }
            #endregion
            
            #region FullProcedureText
            /// <summary>
            /// This property gets or sets the value for 'FullProcedureText'.
            /// </summary>
            public string FullProcedureText
            {
                get { return fullProcedureText; }
                set { fullProcedureText = value; }
            }
            #endregion
            
            #region HasLinesAfterOrderBy
            /// <summary>
            /// This property returns true if this object has a 'LinesAfterOrderBy'.
            /// </summary>
            public bool HasLinesAfterOrderBy
            {
                get
                {
                    // initial value
                    bool hasLinesAfterOrderBy = (this.LinesAfterOrderBy != null);
                    
                    // return value
                    return hasLinesAfterOrderBy;
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
            
            #region HasOpenProject
            /// <summary>
            /// This property returns true if this object has an 'OpenProject'.
            /// </summary>
            public bool HasOpenProject
            {
                get
                {
                    // initial value
                    bool hasOpenProject = (this.OpenProject != null);
                    
                    // return value
                    return hasOpenProject;
                }
            }
            #endregion
            
            #region HasParentNewProcedureEditorForm
            /// <summary>
            /// This property returns true if this object has a 'ParentNewProcedureEditorForm'.
            /// </summary>
            public bool HasParentNewProcedureEditorForm
            {
                get
                {
                    // initial value
                    bool hasParentNewProcedureEditorForm = (this.ParentNewProcedureEditorForm != null);
                    
                    // return value
                    return hasParentNewProcedureEditorForm;
                }
            }
            #endregion
            
            #region HasStoredXml
            /// <summary>
            /// This property returns true if the 'StoredXml' exists.
            /// </summary>
            public bool HasStoredXml
            {
                get
                {
                    // initial value
                    bool hasStoredXml = (!String.IsNullOrEmpty(this.StoredXml));
                    
                    // return value
                    return hasStoredXml;
                }
            }
            #endregion
            
            #region InstallProcedureMethod
            /// <summary>
            /// This property gets or sets the value for 'InstallProcedureMethod'.
            /// </summary>
            public InstallProcedureMethodEnum InstallProcedureMethod
            {
                get { return installProcedureMethod; }
                set { installProcedureMethod = value; }
            }
            #endregion
            
            #region LinesAfterOrderBy
            /// <summary>
            /// This property gets or sets the value for 'LinesAfterOrderBy'.
            /// </summary>
            public List<TextLine> LinesAfterOrderBy
            {
                get { return linesAfterOrderBy; }
                set { linesAfterOrderBy = value; }
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

            #region OpenProject
            /// <summary>
            /// This property gets or sets the value for 'OpenProject'.
            /// </summary>
            public Project OpenProject
            {
                get { return openProject; }
                set { openProject = value; }
            }
            #endregion
            
            #region ParentNewProcedureEditorForm
            /// <summary>
            /// This read only property returns the ParentForm cast as a 'NewProcedureEditorForm'.
            /// </summary>
            public NewStoredProcedureEditorForm ParentNewProcedureEditorForm
            {
                get
                {
                    // initial value
                    NewStoredProcedureEditorForm parent = this.ParentForm as NewStoredProcedureEditorForm;
                    
                    // return value
                    return parent;
                }
            }
        #endregion

            #region StoredXml
            /// <summary>
            /// This property gets or sets the value for 'StoredXml'.
            /// </summary>
            public string StoredXml
            {
                get { return storedXml; }
                set { storedXml = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
