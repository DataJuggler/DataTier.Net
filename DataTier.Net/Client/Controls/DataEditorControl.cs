

#region using statements

using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Net;
using DataTierClient.Forms;
using DataJuggler.Core.UltimateHelper;
using DataGateway;
using DataTierClient.ClientUtil;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Objects;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class DataEditorControl
    /// <summary>
    /// This control is used to manage tables, fields and code files, including 
    /// Methods, Custom Readers and Field Sets for the selected table.
    /// </summary>
    public partial class DataEditorControl : UserControl, ISaveCancelControl, ICheckChangedListener
    {
        
        #region Private Variables
        private Project project;
        private DTNTable selectedTable;
        private List<ExcludeInfo> originalValues;
        private bool loading;
        private bool userCancelled;
        private Gateway gateway;
        
        // button text
        private const string ManageCustomReadersButtonText = "Manage Readers";
        private const string ManageFieldSetsButtonText = "Manage Field Sets";
        private const string ManageMethodsButtonText = "Manage Methods";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DataEditorControl' object.
        /// </summary>
        public DataEditorControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region BlazorFeaturesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BlazorFeaturesButton' is clicked.
            /// </summary>
            private void BlazorFeaturesButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'BlazorServicesForm' object.
                BlazorServicesForm form = new BlazorServicesForm();

                // Setup the form
                form.Setup(this.Project, this.SelectedTable);

                // Show the form
                form.ShowDialog();

                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway();

                // reload the project in case it changed
                this.Project = gateway.FindProject(Project.ProjectId);
            }
            #endregion
            
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
            
            #region CreateMethodButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CreateMethodButton' is clicked.
            /// </summary>
            private void CreateMethodButton_Click(object sender, EventArgs e)
            {
                // Create a new method
                HandleCreateMethod();
            }
            #endregion
            
            #region FieldsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            /// <summary>
            /// event is fired when Fields List Box _ Item Check
            /// </summary>
            private void FieldsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                // do not check during loading
                if (!Loading)
                {
                    // get the tableName
                    int index = e.Index;
                    
                    // if the index is in range
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasFields) && (index < this.SelectedTable.Fields.Count))
                    {
                        // if not checked
                        if (e.NewValue == CheckState.Unchecked)
                        {
                            // Set Exclude to true 
                            this.SelectedTable.Fields[index].Exclude = true;
                        }
                        else
                        {
                            // Set Exclude to true 
                            this.SelectedTable.Fields[index].Exclude = false;
                        }
                    }
                    
                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region ManageFieldSetsButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ManageFieldSetsButton' is clicked.
            /// </summary>
            private void ManageFieldSetsButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'FieldSetEditorForm' object.
                FieldSetEditorForm form = new FieldSetEditorForm();

                // Setup the form
                form.Setup(this.SelectedTable, false, false, null);

                // Show the dialog
                form.ShowDialog();

                // Raise the even in case things were edited
                TablesListBox_SelectedIndexChanged(this, new EventArgs());
            }
            #endregion
            
            #region ManageMethodButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ManageMethodButton' is clicked.
            /// </summary>
            private void ManageMethodButton_Click(object sender, EventArgs e)
            {
                // If the SelectedTable object exists
                if (this.HasSelectedTable)
                {
                    // Create a new instance of a 'CustomMethodsEditorForm' object.
                    CustomMethodsEditorForm form = new CustomMethodsEditorForm();

                    // Setup the form
                    form.Setup(this.SelectedTable, this.SelectedTable.Methods);

                    // Show the form
                    form.ShowDialog();

                    // if Action is required
                    if (form.IsActionRequired)
                    {
                        // if the Add Button was clicked
                        if (form.ActionType == ActionTypeEnum.AddButtonClicked)
                        {
                            // Create a new method
                            HandleCreateMethod();
                        }
                        // if the Edit Button was clicked
                        else if (form.ActionType == ActionTypeEnum.EditButtonClicked)
                        {
                            // Edit the selected method
                            HandleCreateMethod(form.SelectedMethod);
                        }
                    }

                    // Raise the even in case things were edited
                    TablesListBox_SelectedIndexChanged(this, new EventArgs());
                }
            }
            #endregion
            
            #region ManageReadersButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ManageReadersButton' is clicked.
            /// </summary>
            private void ManageReadersButton_Click(object sender, EventArgs e)
            {  
                // Create a new instance of a 'CustomReadersEditorForm' object.
                CustomReadersEditorForm form = new CustomReadersEditorForm();

                // Setup the control
                form.Setup(this.Project, this.SelectedTable);

                // show the form
                form.ShowDialog();

                // Reload the table and display the buttons
                TablesListBox_SelectedIndexChanged(this, null);
            }
            #endregion
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // if the value for HasSelectedTable is true
                if ((HasSelectedTable) && (HasProject) && (Project.EnableBlazorFeatures) && (Project.BindingCallbackOption == BindingCallbackOptionEnum.Allow_Binding))
                {  
                    // set the value
                    if (SelectedTable.CreateBindingCallback != isChecked)
                    {
                        // Set the value
                        SelectedTable.CreateBindingCallback = isChecked;

                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway();

                        // save the selection
                        bool saved = gateway.SaveDTNTable(ref selectedTable);
                    }

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region RemoveTableButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RemoveTableButton' is clicked.
            /// </summary>
            private void RemoveTableButton_Click(object sender, EventArgs e)
            {
                // local
                bool deleteFiles = false;
                
                // Get the list of files to remove
                if ((this.HasProject) && (this.HasSelectedTable))
                {
                    // Create a new instance of a 'ProjectFileManager' object.
                    ProjectFileManager projectFileManager = new ProjectFileManager();
                    
                    // Create each file name
                    string readerFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\DataManager\Readers", this.SelectedTable.TableName + "Reader.cs");
                    string writerFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\DataManager\Writers", this.SelectedTable.TableName + "Writer.cs");
                    string writerBaseFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\DataManager\Writers", this.SelectedTable.TableName + "WriterBase.cs");
                    string dataManagerFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\DataManager", SelectedTable.TableName + "Manager.cs");
                    string deleteProcFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\DeleteProcedures", "Delete" + this.SelectedTable.TableName + "StoredProcedure.cs");
                    string fetchAllProcFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\FetchProcedures", "FetchAll" + PluralWordHelper.GetPluralName(this.SelectedTable.TableName, false) + "StoredProcedure.cs");
                    string findProcFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\FetchProcedures", "Find" + this.SelectedTable.TableName + "StoredProcedure.cs");
                    string insertProcFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\InsertProcedures", "Insert" + this.SelectedTable.TableName + "StoredProcedure.cs");
                    string updateProcFileName = Path.Combine(Project.ProjectFolder, @"DataAccessComponent\StoredProcedureManager\UpdateProcedures", "Update" + this.SelectedTable.TableName + "StoredProcedure.cs");
                    string controllerFileName = Path.Combine(Project.ProjectFolder, @"ApplicationLogicComponent\Controllers", this.SelectedTable.TableName + "Controller.cs");
                    string methodsFileName = Path.Combine(Project.ProjectFolder, @"ApplicationLogicComponent\DataOperations", this.SelectedTable.TableName + "Methods.cs");
                    string businessObjectFileName = Path.Combine(Project.ProjectFolder, @"ObjectLibrary\BusinessObjects", this.SelectedTable.TableName + ".business.cs");
                    string dataObjectFileName = Path.Combine(Project.ProjectFolder, @"ObjectLibrary\BusinessObjects", this.SelectedTable.TableName + ".data.cs");
                    string gatewayFileName = Path.Combine(Project.ProjectFolder, @"DataGateway", "Gateway.cs");
                    
                    // Create each ProjectFile
                    ProjectFile readerFile = new ProjectFile(readerFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile writerFile = new ProjectFile(writerFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile writerFileBase = new ProjectFile(writerBaseFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile dataManagerFile = new ProjectFile(dataManagerFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile deleteProcFile = new ProjectFile(deleteProcFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile fetchAllProcFile = new ProjectFile(fetchAllProcFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile findProcFile = new ProjectFile(findProcFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile insertProcFile = new ProjectFile(insertProcFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile updateProcFile = new ProjectFile(updateProcFileName, DataManager.ProjectTypeEnum.DAC);
                    ProjectFile controllerFile = new ProjectFile(controllerFileName, DataManager.ProjectTypeEnum.ALC);
                    ProjectFile methodsFile = new ProjectFile(methodsFileName, DataManager.ProjectTypeEnum.ALC);
                    ProjectFile businessObjectFile = new ProjectFile(businessObjectFileName, DataManager.ProjectTypeEnum.ObjectLibrary);
                    ProjectFile dataObjectFile = new ProjectFile(dataObjectFileName, DataManager.ProjectTypeEnum.ObjectLibrary);
                    ProjectFile gatewayFile = new ProjectFile(gatewayFileName, DataManager.ProjectTypeEnum.Gateway);
                    
                    // Now add each file to the ProjectFileManager
                    projectFileManager.Files.Add(readerFile);
                    projectFileManager.Files.Add(writerFile);
                    projectFileManager.Files.Add(writerFileBase);
                    projectFileManager.Files.Add(dataManagerFile);
                    projectFileManager.Files.Add(deleteProcFile);
                    projectFileManager.Files.Add(fetchAllProcFile);
                    projectFileManager.Files.Add(findProcFile);
                    projectFileManager.Files.Add(insertProcFile);
                    projectFileManager.Files.Add(updateProcFile);
                    projectFileManager.Files.Add(controllerFile);
                    projectFileManager.Files.Add(methodsFile);
                    projectFileManager.Files.Add(businessObjectFile);
                    projectFileManager.Files.Add(dataObjectFile);
                    projectFileManager.Files.Add(gatewayFile);
                    
                    // Now add the Gateway Method Names to be removed
                    projectFileManager.GatewayMethodNames.Add("Delete" + this.SelectedTable.TableName);
                    projectFileManager.GatewayMethodNames.Add("Find" + this.SelectedTable.TableName);
                    projectFileManager.GatewayMethodNames.Add("Load" + PluralWordHelper.GetPluralName(this.SelectedTable.TableName, false));
                    projectFileManager.GatewayMethodNames.Add("Save" + this.SelectedTable.TableName);

                    // load the methods for this project
                    List<Method> methods = gateway.LoadMethodsForTable(this.SelectedTable.TableId);

                    // If the methods collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(methods))
                    {
                        // Iterate the collection of Method objects
                        foreach (Method method in methods)
                        {
                            // add the custom methods for this table
                            projectFileManager.GatewayMethodNames.Add(method.Name);
                        }
                    }
                    
                    // Create a new instance of a 'ConfirmRemovalForm' object.
                    ConfirmRemovalForm confirmRemovalForm = new ConfirmRemovalForm();
                    
                    // Setup the Control
                    confirmRemovalForm.Setup(projectFileManager, this.Project.ProjectFolder);
                    
                    // Show the form
                    confirmRemovalForm.ShowDialog();
                    
                    // if the user confirmed the removal
                    if (!confirmRemovalForm.UserCancelled)
                    {
                        // Set the value for deleteFiles
                        deleteFiles = confirmRemovalForm.GetDeleteFiles();
                        
                        // reset the projectFileManager in case any Files or Methods were unchecked
                        projectFileManager = confirmRemovalForm.GetProjectFileManager();
                        
                        // Create a new instance of a 'VisualStudioProjectUpdateForm' object.
                        VisualStudioProjectUpdateForm updateForm = new VisualStudioProjectUpdateForm();
                        
                        // Setup the Form
                        updateForm.Setup(this.Project, projectFileManager.ActiveFiles, true);
                        
                        // show the form
                        updateForm.ShowDialog();
                        
                        // if the user did not cancel
                        if (!updateForm.UserCancelled)
                        {
                            // if the value for deleteFiles is true
                            if (deleteFiles)
                            {
                                // iterate the Active files
                                foreach (ProjectFile projectFile in projectFileManager.ActiveFiles)
                                {
                                    // if this is a Gateway file, do nothing
                                    if (projectFile.ProjectType == DataManager.ProjectTypeEnum.Gateway)
                                    {
                                        // if this is a Gateway file, do nothing
                                    }
                                    else
                                    {
                                        if (File.Exists(projectFile.FullFilePath))
                                        {
                                            // Delete this file
                                            File.Delete(projectFile.FullFilePath);
                                        }
                                        else
                                        {
                                            // find out why this file doesn't exist (for debugging only)
                                            string filePath = projectFile.FullFilePath;
                                            
                                            // breakpoint only
                                            filePath = filePath.Trim();
                                        }
                                    }
                                }  
                            }
                            
                            // Remove the methods from the gateway
                            GatewayHelper.RemoveMethods(gatewayFile.FullFilePath, projectFileManager.GatewayMethodNames);
                           
                            // create a message
                            string message = "Files have been removed and your project has been updated." + Environment.NewLine + Environment.NewLine + "Next You must uncheck the table or view to remove it, then click 'Save' and rebuild your project to complete the removal.";

                            // Show the Message
                            MessageBoxHelper.ShowMessage(message, "Table Code Removal Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            #endregion
            
            #region TablesListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            /// <summary>
            /// event is fired when Tables List Box _ Item Check
            /// </summary>
            private void TablesListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                // do not check during loading
                if (!Loading)
                {
                    // get the tableName
                    int index = e.Index;
                    
                    // if the index is in range
                    if ((this.HasTables) && (index < Tables.Count))
                    {
                        if (e.NewValue == CheckState.Unchecked)
                        {
                            // Set Exclude to true 
                            this.Tables[index].Exclude = true;
                        }
                        else
                        {
                            // Set Exclude to true 
                            this.Tables[index].Exclude = false;
                        }
                    }
                    
                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region TablesListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when a selection is made in the 'TablesListBox_'.
            /// </summary>
            private void TablesListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                if ((this.HasTables) && (this.TablesListBox.SelectedIndex >= 0) && (this.TablesListBox.SelectedIndex < this.Tables.Count))
                {
                    // set the table
                    DTNTable table = this.Tables[this.TablesListBox.SelectedIndex];

                    // check the box if checked
                    CreateBindingCallbackControl.Checked = table.CreateBindingCallback;

                    // if the tableId is set
                    if (table.TableId > 0)
                    {
                        // load the fields for this table
                        table.Fields = this.Gateway.LoadDTNFieldsForTable(table.TableId);

                        // Set the SelectedTable (this displays the fields)
                        this.SelectedTable = table;

                        // If the SelectedTable object exists
                        if (this.HasSelectedTable)
                        {
                            // Load the Methods
                            this.SelectedTable.Methods = this.Gateway.LoadMethodsForTable(this.SelectedTable.TableId);

                            // Load the CustomReaders
                            this.SelectedTable.CustomReaders = this.Gateway.LoadCustomReadersForTable(this.SelectedTable.TableId);

                            // Load the FieldSets
                            this.SelectedTable.FieldSets = this.Gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);
                        }
                    }
                }
                else
                {
                    // erase
                    this.SelectedTable = null;
                }

                // Display the button text with the counts for this table
                DisplayButtons();
                
                // Enable or disable controls
                UIEnable();    
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region DisplayButtons()
            /// <summary>
            /// This method Display Buttons
            /// </summary>
            public void DisplayButtons()
            {
                // Set the default text for each button
                this.ManageMethodButton.Text = ManageMethodsButtonText;
                this.ManageReadersButton.Text = ManageCustomReadersButtonText;
                this.ManageFieldSetsButton.Text = ManageFieldSetsButtonText;

                // if there are one or more Methods
                if (this.HasSelectedTableMethodsCount)
                {
                    // Append the Count
                    this.ManageMethodButton.Text += " (" + SelectedTableMethodsCount.ToString() + ")";
                }

                // if there are one or more Field Sets
                if (this.HasSelectedTableFieldSetsCount)
                {
                    // Append the Count
                    this.ManageFieldSetsButton.Text += " (" + SelectedTableFieldSetsCount.ToString() + ")";
                }

                // if there are one or more Custom Readers
                if (this.HasSelectedTableCustomReadersCount)
                {
                    // Append the Count
                    this.ManageReadersButton.Text += " (" + SelectedTableCustomReadersCount.ToString() + ")";
                }
            }
            #endregion
            
            #region DisplayFields()
            /// <summary>
            /// This method Display Fields
            /// </summary>
            public void DisplayFields()
            {
                // Clear
                this.FieldsListBox.Items.Clear();
                
                // if the SelectedTable.Fields exists
                if ((this.HasSelectedTable) && (this.SelectedTable.HasFields))
                {
                    // iterate the fields
                    foreach (DTNField field in this.SelectedTable.Fields)
                    {
                        // Add this field
                        this.FieldsListBox.Items.Add(field, !field.Exclude);
                    }
                }
            }
            #endregion
            
            #region DisplayTables()
            /// <summary>
            /// This method Display Tables
            /// </summary>
            public void DisplayTables()
            {
                // Set to true
                this.Loading = true;
                
                // Clear the list box
                this.TablesListBox.Items.Clear();
                
                // If the Tables collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(Tables))
                {
                    // Iterate the collection of DTNTable objects
                    foreach (DTNTable table in Tables)
                    {
                        // Add this item
                        this.TablesListBox.Items.Add(table, !table.Exclude);
                    }
                }
                
                // Set to false
                this.Loading = false;
                
                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region GetChangesSet()
            /// <summary>
            /// This method returns the Changes Set
            /// </summary>
            public ChangesSet GetChangesSet()
            {
                // initial value
                ChangesSet changesSet = null;
                
                // Get the currentValues
                List<ExcludeInfo> currentValues = ChangeManager.GetObjectValues(this.Tables);
                
                // get the changesSet
                changesSet = ChangeManager.GetChangesSet(this.OriginalValues, currentValues);

                // return value
                return changesSet;
            }
            #endregion
            
            #region HandleCreateMethod(Method selectedMethod = null)
            /// <summary>
            /// This method Handle Create Method
            /// </summary>
            public void HandleCreateMethod(Method selectedMethod = null)
            {
                // Create a new instance of a 'CustomMethodEditorForm' object.
                CustomMethodEditorForm form = new CustomMethodEditorForm();

                // Setup the Form
                form.Setup(this.SelectedTable, this.Project, selectedMethod);

                // Show the Form
                form.ShowDialog();

                // if the user did not cancel
                if ((!form.UserCancelled) && (form.HasMethodInfo) && (this.HasProject))
                {
                    // get the methodInfo
                    MethodInfo methodInfo = form.MethodInfo;

                    // create a second form
                    ConfirmChangesForm form2 = new ConfirmChangesForm();

                    // Setup form2
                    form2.Setup(methodInfo, this.Project);

                    // Show the form
                    form2.ShowDialog();

                    // if the user did not cancel (again)
                    if (!form2.UserCancelled)
                    {
                        // if a new custom reader was created, it mst be included in the project
                        if ((form2.CustomReaderMustBeIncluded) && (form2.HasProjectFileManager))
                        {
                            // set the projectFileManager
                            ProjectFileManager projectFileManager = form2.ProjectFileManager;

                            // create an instance of an UpdateForm.
                            VisualStudioProjectUpdateForm updateForm = new VisualStudioProjectUpdateForm();
                    
                            // setup the control
                            updateForm.Setup(this.Project, projectFileManager.Files);
                    
                            // show the form
                            updateForm.ShowDialog();
                        }

                        // Create the form3
                        NewStoredProcedureEditorForm form3 = new NewStoredProcedureEditorForm();

                        // setup the form
                        form3.Setup(methodInfo, this.Project, methodInfo.CustomReader, methodInfo.OrderByField, methodInfo.OrderByFieldSet);

                        // Show this form
                        form3.ShowDialog();
                    }
                }

                // Call the select tab
                TablesListBox_SelectedIndexChanged(this, new EventArgs());
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Setup the listener
                this.CreateBindingCallbackControl.CheckChangedListener = this;

                // default to true
                this.UserCancelled = true;
                
                // Create a new instance of a 'Gateway' object.
                this.Gateway = new Gateway();

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
                // If the ParentForm exists
                if (this.HasParentDataEditorForm)
                {
                    // Close Form
                    this.ParentDataEditorForm.Close();
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
                    
                    // If the ParentForm exists
                    if (this.HasParentDataEditorForm)
                    {
                        // Close Form
                        this.ParentDataEditorForm.Close();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion
            
            #region Setup(Project project)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(Project project)
            {
                // store the args
                this.Project = project;
                
                // Store original values
                if (HasProject)
                {
                    // Get the original values
                    this.OriginalValues = ChangeManager.GetObjectValues(project.Tables);
                }
                    
                // Display the tables
                DisplayTables();
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method handles which controls are enabled or visible and which are not.
            /// </summary>
            public void UIEnable()
            {
                // local
                bool showBlazorFeatures = ((HasProject) && (Project.BindingCallbackOption != BindingCallbackOptionEnum.No_Binding));
                bool showCreateBindingCallbackControl = ((HasProject) && (Project.BindingCallbackOption == BindingCallbackOptionEnum.Allow_Binding));

                // if there is a SelectedTable
                if ((this.HasSelectedTable) && (!this.SelectedTable.Exclude))
                {
                    // Display the Name
                    this.SelectedTableTextBox.Text = this.SelectedTable.TableName;
                    
                    // Show the buttons
                    this.RemoveTableButton.Visible = true;
                    this.CreateMethodButton.Visible = true;
                    this.ManageReadersButton.Visible = true;
                    this.ManageFieldSetsButton.Visible = true;
                    this.ManageMethodButton.Visible = true;
                    this.BlazorFeaturesButton.Visible = showBlazorFeatures;
                    this.CreateBindingCallbackControl.Visible = showCreateBindingCallbackControl;
                }
                else
                {
                    // Erase the Name
                    this.SelectedTableTextBox.Text = String.Empty;
                    
                    // Hide this buttons
                    this.RemoveTableButton.Visible = false;
                    this.CreateMethodButton.Visible = false;
                    this.ManageReadersButton.Visible = false;
                    this.ManageFieldSetsButton.Visible = false;
                    this.ManageMethodButton.Visible = false;
                    this.BlazorFeaturesButton.Visible = false;
                    this.CreateBindingCallbackControl.Visible = false;
                }
                
                // Not If Loading
                if (!this.Loading)
                {
                    // Get the currentValues
                    List<ExcludeInfo> currentValues = ChangeManager.GetObjectValues(this.Tables);
                
                    // has this object changed
                    bool hasObjectChanged = ChangeManager.HasObjectChanged(this.OriginalValues, currentValues);

                    // if the SaveCancelControl exists
                    if (this.SaveCancelControl != null)
                    {
                        // Enable the Save button if the object has changed
                        this.SaveCancelControl.EnableSaveButton(hasObjectChanged);
                    }
                }
            }

        #endregion

        #endregion

        #region Properties

            #region Gateway
            /// <summary>
            /// This property gets or sets the value for 'Gateway'.
            /// </summary>
            public Gateway Gateway
            {
                get { return gateway; }
                set { gateway = value; }
            }
            #endregion
            
            #region HasGateway
            /// <summary>
            /// This property returns true if this object has a 'Gateway'.
            /// </summary>
            public bool HasGateway
            {
                get
                {
                    // initial value
                    bool hasGateway = (this.Gateway != null);
                    
                    // return value
                    return hasGateway;
                }
            }
            #endregion
            
            #region HasParentDataEditorForm
            /// <summary>
            /// This property returns true if this object has a 'HasParentDataEditorForm'.
            /// </summary>
            public bool HasParentDataEditorForm
            {
                get
                {
                    // initial value
                    bool hasParentDataEditorForm = (this.ParentDataEditorForm != null);
                    
                    // return value
                    return hasParentDataEditorForm;
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
            
            #region HasSelectedTable
            /// <summary>
            /// This property returns true if this object has a 'SelectedTable'.
            /// </summary>
            public bool HasSelectedTable
            {
                get
                {
                    // initial value
                    bool hasSelectedTable = (this.SelectedTable != null);
                    
                    // return value
                    return hasSelectedTable;
                }
            }
            #endregion
            
            #region HasSelectedTableCustomReadersCount
            /// <summary>
            /// This property returns true if the 'SelectedTableCustomReadersCount' is set.
            /// </summary>
            public bool HasSelectedTableCustomReadersCount
            {
                get
                {
                    // initial value
                    bool hasSelectedTableCustomReadersCount = (this.SelectedTableCustomReadersCount > 0);
                    
                    // return value
                    return hasSelectedTableCustomReadersCount;
                }
            }
            #endregion
            
            #region HasSelectedTableFieldSetsCount
            /// <summary>
            /// This property returns true if the 'SelectedTableFieldSetsCount' is set.
            /// </summary>
            public bool HasSelectedTableFieldSetsCount
            {
                get
                {
                    // initial value
                    bool hasSelectedTableFieldSetsCount = (this.SelectedTableFieldSetsCount > 0);
                    
                    // return value
                    return hasSelectedTableFieldSetsCount;
                }
            }
            #endregion
            
            #region HasSelectedTableMethodsCount
            /// <summary>
            /// This property returns true if the 'SelectedTableMethodsCount' is set.
            /// </summary>
            public bool HasSelectedTableMethodsCount
            {
                get
                {
                    // initial value
                    bool hasSelectedTableMethodsCount = (this.SelectedTableMethodsCount > 0);
                    
                    // return value
                    return hasSelectedTableMethodsCount;
                }
            }
            #endregion
            
            #region HasTables
            /// <summary>
            /// This property returns true if this object has a 'Tables'.
            /// </summary>
            public bool HasTables
            {
                get
                {
                    // initial value
                    bool hasTables = (this.Tables != null);
                    
                    // return value
                    return hasTables;
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
            
            #region OriginalValues
            /// <summary>
            /// This property gets or sets the value for 'OriginalValues'.
            /// </summary>
            public List<ExcludeInfo> OriginalValues
            {
                get { return originalValues; }
                set { originalValues = value; }
            }
            #endregion
            
            #region ParentDataEditorForm
            /// <summary>
            /// This read only property returns the DataEditorForm parent
            /// </summary>
            public DataEditorForm ParentDataEditorForm
            {
                get
                {
                    // initial value
                    DataEditorForm parentDataEditorForm = this.ParentForm as DataEditorForm;
                    
                    // return value
                    return parentDataEditorForm;
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
            
            #region SelectedTable
            /// <summary>
            /// This property gets or sets the value for 'SelectedTable'.
            /// </summary>
            public DTNTable SelectedTable
            {
                get { return selectedTable; }
                set 
                {
                    selectedTable = value;
                    
                    // Display the Fields for the SelectedTable
                    DisplayFields();
                }
            }
            #endregion
            
            #region SelectedTableCustomReadersCount
            /// <summary>
            /// This read only property returns the number of CustomReaders for the SelectedTable, if any.
            /// </summary>
            public int SelectedTableCustomReadersCount
            {
                get
                {
                    // initial value
                    int methodsCount = 0;

                    // If the SelectedTable object exists and the CustomReaders object exists
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasCustomReaders))
                    {
                        // set the return value
                        methodsCount = this.SelectedTable.CustomReaders.Count;
                    }

                    // return value
                    return methodsCount;
                }
            }
            #endregion

            #region SelectedTableFieldSetsCount
            /// <summary>
            /// This read only property returns the number of FieldSets for the SelectedTable, if any.
            /// </summary>
            public int SelectedTableFieldSetsCount
            {
                get
                {
                    // initial value
                    int methodsCount = 0;

                    // If the SelectedTable object exists and the FieldSets object exists
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasFieldSets))
                    {
                        // set the return value
                        methodsCount = this.SelectedTable.FieldSets.Count;
                    }

                    // return value
                    return methodsCount;
                }
            }
            #endregion

            #region SelectedTableMethodsCount
            /// <summary>
            /// This read only property returns the number of Methods for the SelectedTable, if any.
            /// </summary>
            public int SelectedTableMethodsCount
            {
                get
                {
                    // initial value
                    int methodsCount = 0;

                    // If the SelectedTable object exists and the Methods object exists
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasMethods))
                    {
                        // set the return value
                        methodsCount = this.SelectedTable.Methods.Count;
                    }

                    // return value
                    return methodsCount;
                }
            }
            #endregion
            
            #region Tables
            /// <summary>
            /// This property gets or sets the value for 'Tables'.
            /// </summary>
            public List<DTNTable> Tables
            {
                get
                {
                    // initial value
                    List<DTNTable> tables = null;
                    
                    // if the Project.Tables exist
                    if (HasProject)
                    {
                        // set tables
                        tables = this.Project.Tables;
                    }
                    
                    // return value
                    return tables;
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
