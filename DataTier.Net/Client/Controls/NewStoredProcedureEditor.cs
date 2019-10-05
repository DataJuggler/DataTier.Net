
#region using statements

using DataTierClient.Forms;
using DataTierClient.Controls.Interfaces;
using DataJuggler.Net.Sql;
using DataJuggler.Core.UltimateHelper;
using DataTierClient.ClientUtil;
using DataTier.Net.StoredProcedureGenerator;
using DataTierClient.Objects;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataGateway;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class NewStoredProcedureEditor : UserControl, ISaveCancelControl
    /// <summary>
    /// This control is used to create a stored procedure
    /// </summary>
    public partial class NewStoredProcedureEditor : UserControl, ISaveCancelControl
    {
        
        #region Private Variables
        private MethodInfo methodInfo;
        private InstallProcedureMethodEnum installProcedureMethod;
        private Project openProject;
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
                                MessageBoxHelper.ShowMessage("The stored procedure has been installed to your SQL Server.", "Procedure Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }                    
                        }
                    }
                    else if (installProcedureMethod == InstallProcedureMethodEnum.Manually)
                    {
                        // Set the text
                        Clipboard.SetText(ProcedureTextBox.Text);

                        // Show the message
                        MessageBoxHelper.ShowMessage("The stored procedure text has been copied to the clipboard.", "Procedure Copied");
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("ProcedureButton_Click", "NewStoredProcedureEditor", error);

                    // Show a message
                    MessageBoxHelper.ShowMessage("An error occurred installing your stored procedure", "Install Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Hide the Save button
                this.SaveCancelControl.SetupSaveButton("", 0, false, false);

                // Setup the Done button
                this.SaveCancelControl.SetupCancelButton("Done", 80);                
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

                        // Save this method
                        bool saved = gateway.SaveMethod(ref method);
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
                    // if the OrderByFieldSet object exists
                    if (NullHelper.Exists(orderByFieldSet))
                    {
                        // set the gateway
                        Gateway gateway = new Gateway();

                        // load the orderByFields
                        orderByFieldSet.FieldSetFields = gateway.LoadFieldSetFieldsForFieldSetId(orderByFieldSet.FieldSetId);
                    }

                    // Set the Name of the Table
                    this.SelectedTableControl.Text = this.MethodInfo.SelectedTable.TableName;
                  
                    // set the procedureName
                    this.ProcedureNameControl.Text = MethodInfo.ProcedureName;

                    // Check the button for Manual Update (user clicks Copy and goes to their SQL instance and executes).
                    this.ManualUpdateRadioButton.Checked = true;

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
                        }
                    }

                    // get the procedureText
                    string procedureText = writer.TextWriter.ToString();

                    // Remove any double blank lines
                    procedureText = CodeLineHelper.RemoveDoubleBlankLines(procedureText);

                    // display the procedure As Is for now.
                    this.ProcedureTextBox.Text = procedureText;
                }
            }
            #endregion
            
        #endregion

        #region Properties

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
            
        #endregion

    }
    #endregion

}
