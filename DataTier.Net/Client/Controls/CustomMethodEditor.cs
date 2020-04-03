
#region using statements

using System.ComponentModel;
using DataGateway;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
using DataTierClient.ClientUtil;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using DataTierClient.Objects;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using ObjectLibrary.Parsers;
using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class CustomMethodEditor
    /// <summary>
    /// This control is used to create a custom method.
    /// </summary>
    public partial class CustomMethodEditor : UserControl, ISelectedIndexListener, ICheckChangedListener, ISaveCancelControl, ITabButtonParent
    {
        
        #region Private Variables
        private DTNTable selectedTable;
        private Project selectedProject;
        private MethodInfo methodInfo;
        private Method selectedMethod;
        private DTNField selectedField;
        private FieldSet selectedFieldSet;
        private bool viewMode;
        private bool userCancelled;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomMethodEditor' object.
        /// </summary>
        public CustomMethodEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region CustomReaderControl_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Custom Reader Control _ Enabled Changed
            /// </summary>
            private void CustomReaderControl_EnabledChanged(object sender, EventArgs e)
            {
                // if the CustomReaderControl is now Enabled
                 if (CustomReaderControl.Enabled)
                {
                    this.CustomReaderControl.LabelColor = Color.Black;
                    this.EditReadersButton.Enabled = true;
                }
                else
                {
                    this.CustomReaderControl.LabelColor = Color.LightGray;
                    this.EditReadersButton.Enabled = false;
                }
            }
            #endregion

            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the ParentForm exists
                if (this.HasParentCustomMethodEditorForm)
                {
                    // Close Form
                    this.ParentCustomMethodEditorForm.Close();
                }
            }
            #endregion

            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // If the sender object exists
                if (NullHelper.Exists(sender))
                {
                    // if the senderName is CustomReaderControl
                    if (sender.Name == CustomReaderControl.Name)
                    {
                        // Enable the CustomReader control if isChecked is true
                        this.CustomReaderControl.Enabled = isChecked;
                        this.CustomReaderControl.Editable = isChecked;
                    }
                    // if DescendingCheckBox
                    else if (sender.Name == this.DescendingCheckBox.Name)
                    {
                        // set the value
                        this.SelectedMethod.OrderByDescending = isChecked;
                    }
                    // if CustomWhereCheckBox
                    else if (sender.Name == this.CustomWhereCheckBox.Name)
                    {
                        // Set UseCustomWhere
                        this.SelectedMethod.UseCustomWhere = isChecked;
                    }
                    else if (sender.Name == this.CustomWhereCheckBox.Name)
                    {
                        // Set the value
                        this.SelectedMethod.UseCustomWhere = isChecked;
                    }
                }
            }
            #endregion
            
            #region OnCustomReaderSelected(int selectedIndex)
            /// <summary>
            /// This event is fired when On Custom Reader Selected
            /// </summary>
            public void OnCustomReaderSelected(int selectedIndex)
            {   
                // if the value for HasSelectedTable is true
                if ((HasSelectedMethod) && (HasSelectedTable) && (SelectedTable.HasCustomReaders) && (selectedIndex < SelectedTable.CustomReaders.Count))
                {
                    // get the customReader
                    CustomReader customReader = SelectedTable.CustomReaders[selectedIndex];

                    // If the customReader object exists
                    if (NullHelper.Exists(customReader))
                    {
                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway();

                        // load the fieldSet
                        customReader.FieldSet = gateway.FindFieldSet(customReader.FieldSetId);

                        // if the fields exist
                        if (customReader.HasFieldSet)
                        {
                            // load the fields
                            customReader.FieldSet.Fields = FieldSetHelper.LoadFieldSetFields(customReader.FieldSetId);
                        }

                        // Set the CustomReader
                        SelectedMethod.CustomReader = customReader;

                        // Set the CustomReaderId
                        SelectedMethod.CustomReaderId = customReader.CustomReaderId;
                    }
                }

                // Capture the MethodInfo
                CaptureMethodInfo();

                // Enable Controls again
                UIEnable();
            }
            #endregion

            #region OnMethodTypeSelected(int selectedIndex)
            /// <summary>
            /// This method On Method Type Selected
            /// </summary>
            public void OnMethodTypeSelected(int selectedIndex)
            {  
                // if the value for ViewMode is true
                if (ViewMode)
                {
                    // Determine the action by the selectedIndex
                    switch (selectedIndex)
                    {
                        case 0:

                            // Load

                            // Enable the single field control
                            this.ParameterFieldControl.Editable = true;

                            // Disable the multiple fields control
                            this.ParameterFieldSetControl.Editable = false;

                            // Set the Text
                            this.MethodNameControl.Text = "Load" + PluralWordHelper.GetPluralName(this.SelectedTable.TableName, false) + "For";
                        
                            // Set the ProcedureName Text root
                            this.ProcedureNameControl.Text = this.SelectedTable.TableName + "_" + "FetchAllFor";
                        
                            // required
                            break;
                    }
                }
                else
                {
                    // Determine the action by the selectedIndex
                    switch (selectedIndex)
                    {

                        case 0:

                            // Delete

                            // Set the Text for the MethodName (it can be changed by the user if desired)
                            this.MethodNameControl.Text = "Delete" + this.SelectedTable.TableName + "By";
                        
                            // Set the ProcedureName Text root
                            this.ProcedureNameControl.Text = this.SelectedTable.TableName + "_" + "DeleteBy";

                            // You cannot update a Delete procedure, no need to is another way to put it.
                            this.UpdateOnBuildCheckbox.Checked = false;
                            this.UpdateOnBuildCheckbox.Editable = false;
                        
                            // required
                            break;
                    

                        case 1:

                            // Find

                            // Enable the single field control
                            this.ParameterFieldControl.Editable = true;

                            // Disable the multiple fields control
                            this.ParameterFieldSetControl.Editable = false;
                        
                            // Set the Text for the MethodName (it can be changed by the user if desired)
                            this.MethodNameControl.Text = "Find" + this.SelectedTable.TableName + "By";
                        
                            // Set the ProcedureName Text root
                            this.ProcedureNameControl.Text = this.SelectedTable.TableName + "_" + "FindBy";

                             // Set to editable in case Delete was previously selected
                            this.UpdateOnBuildCheckbox.Checked = true;
                            this.UpdateOnBuildCheckbox.Editable = true;
                        
                            // required
                            break;

                        case 2:

                            // Load

                            // Enable the single field control
                            this.ParameterFieldControl.Editable = true;

                            // Disable the multiple fields control
                            this.ParameterFieldSetControl.Editable = false;

                            // Set the Text
                            this.MethodNameControl.Text = "Load" + PluralWordHelper.GetPluralName(this.SelectedTable.TableName, false) + "For";
                        
                            // Set the ProcedureName Text root
                            this.ProcedureNameControl.Text = this.SelectedTable.TableName + "_" + "FetchAllFor";

                            // Set to editable in case Delete was previously selected
                            this.UpdateOnBuildCheckbox.Checked = true;
                            this.UpdateOnBuildCheckbox.Editable = true;
                        
                            // required
                            break;
                    }
                }

                // Set the first part of the PropertyName
                this.PropertyNameControl.Text = this.MethodTypeControl.ComboBoxText.Replace(" ", "");

                // Capture the MethodInfo
                CaptureMethodInfo();

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region OnOrderByTypeSelected(int selectedIndex)
            /// <summary>
            /// This event is fired when an Order By Type is selected.
            /// </summary>
            public void OnOrderByTypeSelected(int selectedIndex)
            {   
                // Capture the current MethodInfo
                CaptureMethodInfo();

                // if the MethodInfo exists
                if ((HasMethodInfo) && (HasSelectedTable))
                {
                    switch (selectedIndex)
                    {
                        case 0:

                            // Set to FieldSet
                            MethodInfo.OrderByType = OrderByTypeEnum.Field_Set;

                            // if the MethodInfo.CustomReader.FieldSet.Fields exists
                            if ((MethodInfo.HasCustomReader) && (MethodInfo.CustomReader.HasFieldSet) && (MethodInfo.CustomReader.FieldSet.HasFields))
                            {
                                // Load the Fields from the CustomReader.FieldSet.Fields
                                this.OrderByFieldControl.LoadItems(MethodInfo.CustomReader.FieldSet.Fields);
                            }
                            else
                            {  
                                // Load the Fields
                                this.OrderByFieldSetControl.LoadItems(this.SelectedTable.OrderByFieldSets);
                            }

                            // required
                            break;

                        case 1:

                            // Set to FieldSet
                            MethodInfo.OrderByType = OrderByTypeEnum.No_Order_By;

                            // required
                            break;

                         case 2:

                            // Set to FieldSet
                            MethodInfo.OrderByType = OrderByTypeEnum.Single_Field;

                            // if the MethodInfo.CustomReader.FieldSet.Fields exists
                            if ((MethodInfo.HasCustomReader) && (MethodInfo.CustomReader.HasFieldSet) && (MethodInfo.CustomReader.FieldSet.HasFields))
                            {
                                // Load the Fields from the CustomReader.FieldSet.Fields
                                this.OrderByFieldControl.LoadItems(MethodInfo.CustomReader.FieldSet.Fields);
                            }
                            else
                            {
                                // Load the Fields
                                this.OrderByFieldControl.LoadItems(this.SelectedTable.Fields);
                            }

                            // required
                            break;
                    }
                }

                // Enable Controls again
                UIEnable();
            }
            #endregion
            
            #region OnParameterFieldSelected(int selectedIndex, object selectedItem)
            /// <summary>
            /// This method On Parameter Field Selected
            /// </summary>
            public void OnParameterFieldSelected(int selectedIndex, object selectedItem)
            {
                // local
                UserResponseEnum response = UserResponseEnum.NoResponse;

                // only handle a field selected if the selected index is set
                if (selectedIndex >= 0)
                {
                    // local
                    DTNField field = null;

                    // if the SelectedTable.Fields exists and the selectedIndex is in range
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasFields) && (selectedIndex < this.SelectedTable.Fields.Count))
                    {
                        // get the Field at the SelectedIndex
                        field = this.SelectedTable.Fields[selectedIndex];
                    }

                    // If the field object exists
                    if (NullHelper.Exists(field))
                    { 
                        // if we already have a selected field
                        if (HasSelectedField)
                        {
                            // Remove the SelectedField and change the text the selected field changed
                            RemoveSelectedField();
                        }

                        // Set the selectedField
                        this.SelectedField = field;

                        // If the SelectedField exists and the Field is the PrimaryKey for this table
                        if ((this.HasSelectedField) && (this.SelectedField.PrimaryKey))
                        {
                            // get the users response
                            response = GetConfirmationToCreatePrimaryKeyProcedure();

                            // if cancel
                            if (response == UserResponseEnum.Cancelled)
                            {
                                // Remove the SelectedField
                                RemoveSelectedField();

                                // Erase the selection
                                this.ParameterFieldControl.SelectedIndex = -1;

                                // bail
                                return;
                            }
                        }

                        // Append the name of this field
                        this.MethodNameControl.Text += field.FieldName;
                   
                        // Append the name of this field
                        this.ProcedureNameControl.Text += field.FieldName;

                        // If the value for the property field.IsEnumeration is true
                        if (field.DataType.ToString().ToLower() == "enumeration")
                        {
                            // set the dataType and fieldName
                            this.ParametersControl.Text = EnumerationHelper.GetEnumerationDataType(field.FieldName, this.SelectedProject.Enumerations) + " " + CSharpClassWriter.CapitalizeFirstCharEx(field.FieldName, true);
                        }
                        else
                        {
                            // convert the DTN Field back to a DataField
                            DataField parameterField = DataConverter.ConvertDataField(field);

                            // Update for DateTime data type
                            string parameterFieldDataType = CSharpClassWriter.ConvertDataType(parameterField);

                            // set the dataType and fieldName
                            this.ParametersControl.Text = parameterFieldDataType + " " + CSharpClassWriter.CapitalizeFirstCharEx(field.FieldName, true);
                        }

                        // Set the first part of the PropertyName
                        this.PropertyNameControl.Text = this.MethodTypeControl.ComboBoxText.Replace(" ", "") + field.FieldName;
                    }
                }
            }
            #endregion

            #region OnParameterFieldSetSelected(int selectedIndex, object selectedItem)
            /// <summary>
            /// This method On Parameter Field Selected
            /// </summary>
            public void OnParameterFieldSetSelected(int selectedIndex, object selectedItem)
            {
                // cast the selectedItem as a FieldSet
                FieldSet fieldSet = null;

                // if the SelectedTable.FieldSets exists and the selectedIndex is in range
                if ((this.HasSelectedTable) && (this.SelectedTable.HasFieldSets) && (selectedIndex < this.SelectedTable.ParameterFieldSets.Count))
                {
                    // get the FieldSet at the SelectedIndex
                    fieldSet = this.SelectedTable.ParameterFieldSets[selectedIndex];
                }

                // If the field object exists
                if ((NullHelper.Exists(fieldSet)) && (HasSelectedProject))
                {
                    // if we already have a selected fieldSet
                    if (HasSelectedFieldSet)
                    {
                        // Remove the SelectedField and change the text the selected field changed
                        RemoveSelectedFieldSet();
                    }

                    // Set the selectedFieldSet
                    this.SelectedFieldSet = fieldSet;

                    // Append the name of this field
                    this.MethodNameControl.Text += fieldSet.Name;
                   
                    // Append the name of this field
                    this.ProcedureNameControl.Text += fieldSet.Name;

                    // collection of dataType and fieldSet variable names
                    string parametersText = "";

                    // load the fields
                    fieldSet.Fields = FieldSetHelper.LoadFieldSetFields(fieldSet.FieldSetId);

                    // get the parametersText
                    parametersText = FieldSetHelper.GetParametersText(ref fieldSet, this.SelectedProject.Enumerations);
                    
                    // display the parametersText
                    this.ParametersControl.Text = parametersText; 

                    // Set the first part of the PropertyName
                    this.PropertyNameControl.Text = this.MethodTypeControl.ComboBoxText.Replace(" ", "") + fieldSet.Name;
                }
            }
            #endregion
            
            #region OnParameterTypeSelected(int selectedIndex)
            /// <summary>
            /// This method On Parameter Type Selected
            /// </summary>
            public void OnParameterTypeSelected(int selectedIndex)
            {
                // Capture the MethodInfo
                CaptureMethodInfo();

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// This is Actually OnNext.
            /// </summary>
            public void OnSave()
            {
                try
                {
                    // Capture the Method properties
                    CaptureMethodInfo();

                    // User Did Not Cancel
                    this.UserCancelled = false;

                    // If the ParentForm exists
                    if (this.HasParentCustomMethodEditorForm)
                    {
                        // Close Form
                        this.ParentCustomMethodEditorForm.Close();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            /// <param name="selectedItem"></param>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // If the control object exists
                if ((control != null) && (HasSelectedTable))
                {
                    switch (control.Name)
                    {
                        case "MethodTypeControl":

                            // Handle the MethodType selected event
                            OnMethodTypeSelected(selectedIndex);

                            // required
                            break;

                        case "ParameterTypeControl":
    
                             // Handle the ParameterType selected event
                            OnParameterTypeSelected(selectedIndex);

                            // required
                            break;

                        case "ParameterFieldControl":
    
                            // A field was selected
                            OnParameterFieldSelected(selectedIndex, selectedItem);

                            // required
                            break;

                        case "ParameterFieldSetControl":
    
                           // A field was selected
                            OnParameterFieldSetSelected(selectedIndex, selectedItem);

                            // required
                            break;

                        case "CustomReaderControl":

                             // A custom reader was selected
                            OnCustomReaderSelected(selectedIndex);

                            // required
                            break;

                        case "OrderByTypeControl":

                             // The OrderByType was selected
                            OnOrderByTypeSelected(selectedIndex);

                            // required
                            break;
                    }
                }
            }
            #endregion
            
            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway();

                // if the SelectedTable exists
                if (this.HasSelectedTable)
                {
                    // determine action by the button text
                    switch (tabButton.Name)
                    {
                        case "EditParametersSetButton":

                            // Create a new instance of a 'FieldSetEditorForm' object.
                            FieldSetEditorForm form = new FieldSetEditorForm();

                            // Setup the Form
                            form.Setup(this.SelectedTable, true, true, this.SelectedFieldSet);

                            // Show the form
                            form.ShowDialog();

                            // Reload the Parameter Field Sets combo box
                            ReloadParameterFieldSets();

                            // required
                            break;

                        case "EditReadersButton":

                            // Create a new instance of a 'CustomReadersEditorForm' object.
                            CustomReadersEditorForm readersForm = new CustomReadersEditorForm();

                            // Edit the custom readers
                            readersForm.Setup(SelectedProject, SelectedTable, null);

                            // Show the form
                            readersForm.ShowDialog();
                           
                            // reload the CustomReaders
                            this.SelectedTable.CustomReaders = gateway.LoadCustomReadersForTable(this.SelectedTable.TableId);

                            // reload the CustomReaders
                            this.CustomReaderControl.LoadItems(this.SelectedTable.CustomReaders);

                            // required
                            break;

                        case "EditOrderByFieldSetsButton":

                            // Create the form
                            FieldSetEditorForm fieldSetEditorForm = new FieldSetEditorForm();

                            // Setup the control
                            fieldSetEditorForm.SetupForOrderByMode(this.SelectedTable);

                            // Show the form
                            fieldSetEditorForm.ShowDialog();

                            // load the FieldSets for the table
                            this.SelectedTable.FieldSets = gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);

                            // Reload the combo box
                            OrderByFieldSetControl.LoadItems(SelectedTable.OrderByFieldSets);

                            // required
                            break;
                    }
                }
            }
            #endregion

            #region ParameterFieldControl_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Parameter Field Control _ Enabled Changed
            /// </summary>
            private void ParameterFieldControl_EnabledChanged(object sender, EventArgs e)
            {
                if (ParameterFieldControl.Enabled)
                {
                    this.ParameterFieldControl.LabelColor = Color.Black;
                }
                else
                {
                    this.ParameterFieldControl.LabelColor = Color.LightGray;
                }
            }
            #endregion
            
            #region ParametersSetControl_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Parameters Set Control _ Enabled Changed
            /// </summary>
            private void ParametersSetControl_EnabledChanged(object sender, EventArgs e)
            {
                if (ParameterFieldSetControl.Enabled)
                {
                    this.ParameterFieldSetControl.LabelColor = Color.Black;
                    this.EditParametersSetButton.Enabled = true;
                }
                else
                {
                    this.ParameterFieldSetControl.LabelColor = Color.LightGray;
                    this.EditParametersSetButton.Enabled = false;
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region CaptureMethodInfo()
            /// <summary>
            /// This method Capture Method Info
            /// </summary>
            public void CaptureMethodInfo()
            {
                // If the SelectedMethod object exists
                if (this.HasSelectedMethod)
                {
                    // Create a new instance of a 'MethodInfo' object.
                    this.MethodInfo = new MethodInfo();

                    // Set the properties from this object

                    // Set the Text
                    MethodInfo.SelectedTable = this.SelectedTable;
                    MethodInfo.MethodName = this.MethodNameControl.Text;
                    MethodInfo.ProcedureName = this.ProcedureNameControl.Text;
                    MethodInfo.Parameters = this.ParametersControl.Text;
                    MethodInfo.PropertyName = this.PropertyNameControl.Text;
                    MethodInfo.UpdateOnBuild = this.UpdateOnBuildCheckbox.Checked;
                    MethodInfo.UseCustomReader = this.UseCustomReaderCheckBox.Checked;
                    MethodInfo.MethodId = this.SelectedMethod.MethodId;
                    MethodInfo.TopRows = this.TopRowsControl.IntValue;
                    MethodInfo.UseCustomWhere = CustomWhereCheckBox.Checked;
                    MethodInfo.WhereText = SelectedMethod.WhereText;

                    // if UseCustomReader is true and the SelectedMethod.CustomReader exists
                    if ((MethodInfo.UseCustomReader) && (SelectedMethod.HasCustomReader))
                    {
                        // Set the CustomReader
                        MethodInfo.CustomReader = SelectedMethod.CustomReader;
                    }

                    // if the SelectedMethodType exists
                    if (this.MethodTypeControl.HasSelectedObject)
                    {
                        // Parse the MethodType
                        MethodInfo.MethodType = Parser.ParseMethodType(this.MethodTypeControl.SelectedObject.ToString());
                    }
                    else
                    {
                        // Set to Unknown
                        MethodInfo.MethodType = MethodTypeEnum.Unknown;
                    }

                    // if the SelectedMethodType exists
                    if (this.ParameterTypeControl.HasSelectedObject)
                    {
                        // Set the ParameterType
                        MethodInfo.ParameterType = Parser.ParseParameterType(this.ParameterTypeControl.SelectedObject.ToString());
                    }
                    else
                    {
                        // Set the ParameterType
                        MethodInfo.ParameterType = ParameterTypeEnum.No_Parameters;
                    }

                    if (this.OrderByTypeControl.HasSelectedObject)
                    {
                        // Set the OrderByType
                        MethodInfo.OrderByType = Parser.ParseOrderByType(this.OrderByTypeControl.SelectedObject.ToString());
                    }
                    else
                    {
                        // Set to No Order By
                        MethodInfo.OrderByType = OrderByTypeEnum.No_Order_By;
                    }
                
                    // if this is a SingleField parameter
                    if (MethodInfo.ParameterType == ParameterTypeEnum.Single_Field)
                    {
                        // Show the ParameterFieldControl
                        this.ParameterFieldControl.Visible = true;

                        // Hide the FieldSetControl
                        this.ParameterFieldSetControl.Visible = false;
                        this.EditParametersSetButton.Visible = false;

                        // if a value is selected
                        if (this.ParameterFieldControl.SelectedIndex >= 0)
                        {
                            // Set the ParameterField
                            MethodInfo.ParameterField = this.SelectedTable.Fields[this.ParameterFieldControl.SelectedIndex];
                        }
                        else
                        {
                            // Set the ParameterField to nothing
                            MethodInfo.ParameterField = null;
                        }
                    }
                    else if (MethodInfo.ParameterType == ParameterTypeEnum.Field_Set)
                    {
                        // Show the ParameterFieldSetControl
                        this.ParameterFieldSetControl.Visible = true;
                        this.EditParametersSetButton.Visible = true;

                        // Hide the ParameterFieldControl
                        this.ParameterFieldControl.Visible = false;

                        // if a value is selected
                        if (this.ParameterFieldSetControl.SelectedIndex >= 0)
                        {
                            // Set the ParameterFieldSet
                            MethodInfo.ParameterFieldSet = this.SelectedTable.ParameterFieldSets[this.ParameterFieldSetControl.SelectedIndex];
                        }
                        else
                        {
                            // Set the ParameterFieldSet to nothing
                            MethodInfo.ParameterFieldSet = null;
                        }
                    }

                    // if this is a SingleField OrderByType
                    if (MethodInfo.OrderByType == OrderByTypeEnum.Single_Field)
                    {
                        // Show the OrderByFieldControl
                        this.OrderByFieldControl.Visible = true;

                        // Hide the FieldSetControl
                        this.OrderByFieldSetControl.Visible = false;
                        this.EditOrderByFieldSetsButton.Visible = false;

                        // if a value is selected
                        if (this.OrderByFieldControl.SelectedIndex >= 0)
                        {
                            // Set the OrderByField
                            MethodInfo.OrderByField = this.SelectedTable.Fields[this.OrderByFieldControl.SelectedIndex];
                            MethodInfo.OrderByDescending = DescendingCheckBox.Checked;
                        }
                        else
                        {
                            // Set the OrderByField to nothing & set OrderByDescending to false
                            MethodInfo.OrderByField = null;
                            MethodInfo.OrderByDescending = false;
                        }
                    }
                    else if (MethodInfo.OrderByType == OrderByTypeEnum.Field_Set)
                    {
                        // Show the OrderByFieldSetControl & button
                        this.OrderByFieldSetControl.Visible = true;
                        this.EditOrderByFieldSetsButton.Visible = true;

                        // Hide the OrderByFieldControl
                        this.OrderByFieldControl.Visible = false;

                        // if a value is selected
                        if (this.OrderByFieldSetControl.SelectedIndex >= 0)
                        {
                            // Set the OrderByFieldSet
                            MethodInfo.OrderByFieldSet = this.SelectedTable.OrderByFieldSets[this.OrderByFieldSetControl.SelectedIndex];
                        }
                        else
                        {
                            // Set the OrderByFieldSet to nothing
                            MethodInfo.OrderByFieldSet = null;
                        }
                    }
                }
            }
            #endregion
            
            #region DisplaySelectedMethod()
            /// <summary>
            /// This method Display Selected Method
            /// </summary>
            public void DisplaySelectedMethod()
            {
                // locals
                int methodTypeIndex = -1;
                int parameterTypeIndex = -1;
                int parameterFieldIndex = -1;
                int parameterFieldSetIndex = -1;
                DTNField parameterField = null;
                string methodName = "";
                string procedureName = "";
                string parameters = "";
                string propertyName = "";
                bool updateOnBuild = false;
                bool useCustomReader = false;
                int customReaderIndex = -1;
                int orderByTypeIndex = 1; // No Order By
                DTNField orderByField = null;
                int orderByFieldIndex = -1;
                int orderByFieldSetIndex = -1;
                bool descending = false;
                int topRows = 0;
                bool customWhere = false;

                // If the SelectedMethod object exists
                if (this.HasSelectedMethod)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // if the ParameterType is a Single Field
                    if (this.SelectedMethod.ParameterType == ParameterTypeEnum.Single_Field)
                    {
                        // verify the ParameterFieldId is set before going to the server
                        if (this.SelectedMethod.ParameterFieldId > 0)
                        {
                            // load the parameterField
                            parameterField = gateway.FindDTNField(this.SelectedMethod.ParameterFieldId);

                            // If the parameterField object exists
                            if (NullHelper.Exists(parameterField))
                            {
                                // find the Index of this field
                                parameterFieldIndex = ParameterFieldControl.FindItemIndexByValue(parameterField.FieldName);
                            }
                        }
                    }
                    else if (this.SelectedMethod.ParameterType == ParameterTypeEnum.Field_Set)
                    {
                        // verify the ParameterFieldSetId is set before going to the server
                        if (this.SelectedMethod.ParametersFieldSetId > 0)
                        {
                            // load the FieldSet
                            FieldSet fieldSet = gateway.FindFieldSet(this.selectedMethod.ParametersFieldSetId);

                            // If the fieldSet object exists
                            if (NullHelper.Exists(fieldSet))
                            {
                                // find the parameterFieldIndex
                                parameterFieldSetIndex = ParameterFieldSetControl.FindItemIndexByValue(fieldSet.Name);
                            }
                        }
                    }

                    // if the OrderByType is a Single Field
                    if (this.SelectedMethod.OrderByType == OrderByTypeEnum.Single_Field)
                    {
                        // Load the Fields
                        this.OrderByFieldControl.LoadItems(this.SelectedTable.Fields);

                        // verify the OrderByFieldId is set before going to the server
                        if (this.SelectedMethod.OrderByFieldId > 0)
                        {
                            // set the value for descending
                            descending = SelectedMethod.OrderByDescending;

                            // load the parameterField
                            orderByField = gateway.FindDTNField(this.SelectedMethod.OrderByFieldId);

                            // If the orderByField object exists
                            if (NullHelper.Exists(orderByField))
                            {
                                // find the Index of this field
                                orderByFieldIndex = OrderByFieldControl.FindItemIndexByValue(orderByField.FieldName);
                            }
                        }
                    }
                    else if (this.SelectedMethod.OrderByType == OrderByTypeEnum.Field_Set)
                    {
                        // Load the Fields
                        this.OrderByFieldSetControl.LoadItems(this.SelectedTable.OrderByFieldSets);

                        // verify the OrderByFieldSetId is set before going to the server
                        if (this.SelectedMethod.OrderByFieldSetId > 0)
                        {
                            // load the FieldSet
                            FieldSet fieldSet = gateway.FindFieldSet(this.selectedMethod.OrderByFieldSetId);

                            // If the fieldSet object exists
                            if (NullHelper.Exists(fieldSet))
                            {
                                // find the orderByFieldSetIndex
                                orderByFieldSetIndex = OrderByFieldSetControl.FindItemIndexByValue(fieldSet.Name);
                            }
                        }
                    }

                    // set the values
                    methodTypeIndex = MethodTypeControl.FindItemIndexByValue(this.SelectedMethod.MethodType.ToString().Replace("_", " "));

                    // Get the parameterTypeIndex
                    parameterTypeIndex = ParameterTypeControl.FindItemIndexByValue(this.SelectedMethod.ParameterType.ToString().Replace("_", " "));

                    // set the orderByTypeIndex
                    orderByTypeIndex = OrderByTypeControl.FindItemIndexByValue(this.SelectedMethod.OrderByType.ToString().Replace("_", " "));

                    // set the methodName
                    methodName = this.SelectedMethod.Name;

                    // set the procedureName
                    procedureName = this.SelectedMethod.ProcedureName;

                    // set the parameters
                    parameters = this.SelectedMethod.Parameters;

                    // set the propertyName
                    propertyName = this.SelectedMethod.PropertyName;

                    // set the value for topRows
                    topRows = SelectedMethod.TopRows;

                    // set the value for updateOnBuild
                    updateOnBuild = this.SelectedMethod.UpdateProcedureOnBuild;

                    // set the value for useCustomReader
                    useCustomReader = this.SelectedMethod.UseCustomReader;

                    // if useCustomReader is true
                    if ((useCustomReader) && (this.SelectedMethod.CustomReaderId > 0))
                    {
                        // load the customReader
                        CustomReader customReader = gateway.FindCustomReader(this.SelectedMethod.CustomReaderId);

                        // If the customReader object exists
                        if (NullHelper.Exists(customReader))
                        {
                            // load the customReaderIndex
                            customReaderIndex = this.CustomReaderControl.FindItemIndexByValue(customReader.ClassName);
                        }
                    }

                    // Is the customWhere checked
                    customWhere = this.SelectedMethod.UseCustomWhere;
                }

                // Display the values
                this.MethodTypeControl.SelectedIndex = methodTypeIndex;
                this.ParameterTypeControl.SelectedIndex = parameterTypeIndex;
                this.ParameterFieldControl.SelectedIndex = parameterFieldIndex;
                this.ParameterFieldSetControl.SelectedIndex = parameterFieldSetIndex;
                this.MethodNameControl.Text = methodName;
                this.ProcedureNameControl.Text = procedureName;
                this.ParametersControl.Text = parameters;
                this.PropertyNameControl.Text = propertyName;
                this.UseCustomReaderCheckBox.Checked = useCustomReader;
                this.OrderByTypeControl.SelectedIndex = orderByTypeIndex;
                this.OrderByFieldControl.SelectedIndex = orderByFieldIndex;
                this.DescendingCheckBox.Checked = descending;
                this.OrderByFieldSetControl.SelectedIndex = orderByFieldSetIndex;
                this.TopRowsControl.Text = topRows.ToString();
                this.CustomWhereCheckBox.Checked = customWhere;
                
                // if the value for useCustomReader is true
                if (useCustomReader)
                {
                    // set the index
                    this.CustomReaderControl.SelectedIndex = customReaderIndex;
                }
            }
            #endregion
            
            #region DisplaySelectedTable()
            /// <summary>
            /// This method Display Selected Table
            /// </summary>
            public void DisplaySelectedTable()
            {
                // Erase the text
                this.SelectedTableControl.Text = "";

                // If the SelectedTable object exists
                if (this.HasSelectedTable)
                {
                    // Display the Name
                    this.SelectedTableControl.Text = this.SelectedTable.TableName;
                }
            }
            #endregion
            
            #region GetConfirmationToCreatePrimaryKeyProcedure()
            /// <summary>
            /// This method Get Confirmation To Create Primary Key Procedure
            /// </summary>
            public UserResponseEnum GetConfirmationToCreatePrimaryKeyProcedure()
            {
                // initial value
                UserResponseEnum userResponse = UserResponseEnum.NoResponse;

                // Capture the MethodInfo object                        
                CaptureMethodInfo();

                // if the value for HasMethodInfo is true and this is a FindBy or a DeleteBy
                if ((HasMethodInfo) && ((MethodInfo.MethodType == MethodTypeEnum.Find_By) || (MethodInfo.MethodType == MethodTypeEnum.Delete_By)))
                {
                    // if the ParameterField object exists in the MethodInfo object
                    if ((MethodInfo.HasParameterField) && (MethodInfo.HasSelectedTable))
                    {
                        // set the procedureName
                        string procedureName = MethodInfo.SelectedTable.TableName + "_" + MethodInfo.MethodType.ToString().Replace("_By", "");

                        // Create a new instance of a 'DialogControlForm' object.
                        DialogControlForm dialogControlForm = new DialogControlForm();

                        // Setup the dialog control
                        dialogControlForm.Setup(MethodInfo.ParameterField.FieldName, MethodInfo.SelectedTable.TableName, procedureName, "Confirm Create Procedure For Primary Key?");

                        // Show a dialog to the user
                        dialogControlForm.ShowDialog();

                        // set the userResponse
                        userResponse = dialogControlForm.UserResponse;
                    }
                }

                // return value
                return userResponse;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Load the ComboBoxes
                this.MethodTypeControl.LoadItems(typeof(MethodTypeEnum));
                this.ParameterTypeControl.LoadItems(typeof(ParameterTypeEnum));

                // Disable the ParameterFieldControl until a selection is made
                this.ParameterFieldControl.Enabled = false;
                
                // Setup the Listeners
                this.MethodTypeControl.SelectedIndexListener = this;
                this.ParameterTypeControl.SelectedIndexListener = this;
                this.ParameterFieldControl.SelectedIndexListener = this;
                this.ParameterFieldSetControl.SelectedIndexListener = this;
                this.UseCustomReaderCheckBox.CheckChangedListener = this;
                this.CustomReaderControl.SelectedIndexListener = this;
                this.OrderByTypeControl.SelectedIndexListener = this;
                this.OrderByFieldControl.SelectedIndexListener = this;
                this.DescendingCheckBox.CheckChangedListener = this;
                this.OrderByFieldSetControl.SelectedIndexListener = this;
                this.CustomWhereCheckBox.CheckChangedListener = this;

                // Set both buttons
                this.EditParametersSetButton.ShowNotSelectedImageWhenDisabled = true;
                this.EditParametersSetButton.NotSelectedImage = Properties.Resources.DeepGray;
                this.EditParametersSetButton.SelectedImage = Properties.Resources.DeepBlue;
                this.EditReadersButton.ShowNotSelectedImageWhenDisabled = true;
                this.EditReadersButton.NotSelectedImage = Properties.Resources.DeepGray;
                this.EditReadersButton.SelectedImage = Properties.Resources.DeepBlue;
                this.EditOrderByFieldSetsButton.SelectedImage = Properties.Resources.DeepBlue;
                this.EditOrderByFieldSetsButton.NotSelectedImage = Properties.Resources.DeepGray;

                // Disable both buttons, and force the change
                this.EditReadersButton.Enabled = true;
                this.EditParametersSetButton.Enabled = true;
                this.EditReadersButton.Enabled = false;
                this.EditParametersSetButton.Enabled = false;

                // Remove the Unknown item
                this.MethodTypeControl.Items.RemoveAt(this.MethodTypeControl.Items.Count - 1);

                // Load the Order By Type Control
                OrderByTypeControl.LoadItems(typeof(OrderByTypeEnum));
                
                // Default to No order By
                OrderByTypeControl.SelectedIndex = 1;

                // Default to the user did cancel
                this.UserCancelled = true;

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region LoadAndDisplayFieldSets()
            /// <summary>
            /// This method Load And Display Field Sets
            /// </summary>
            public void LoadAndDisplayFieldSets()
            {
                // If the SelectedTable object exists
                if (this.HasSelectedTable)
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // reload the FieldsSets
                    this.SelectedTable.FieldSets = gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);

                    // load the ParamterFieldSets (FieldSets for a table with ParameterMode set to true
                    ParameterFieldSetControl.LoadItems(this.SelectedTable.ParameterFieldSets);
                }
            }
            #endregion

            #region ReloadParameterFieldSets()
            /// <summary>
            /// This method Reload Parameter Field Sets
            /// </summary>
            public void ReloadParameterFieldSets()
            {
                // clear the items
                this.ParameterFieldSetControl.Items.Clear();

                // if the SelectedTable eixsts and is not new.
                if ((this.HasSelectedTable) && (!SelectedTable.IsNew))
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // Load the Parameter FieldSets for the SelectedTable
                    this.SelectedTable.FieldSets = gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);

                    // load the FieldSets
                    this.ParameterFieldSetControl.LoadItems(this.SelectedTable.ParameterFieldSets);
                }
            }
            #endregion
            
            #region RemoveSelectedField()
            /// <summary>
            /// This method Remove Selected Field
            /// </summary>
            public void RemoveSelectedField()
            {
                // if a selected field exists
                if ((this.HasSelectedField) && (this.MethodNameControl.Text.EndsWith(SelectedField.FieldName)))
                {
                    // Remove the old field name
                    this.MethodNameControl.Text = this.MethodNameControl.Text.Replace(SelectedField.FieldName, "");
                    this.ProcedureNameControl.Text = this.ProcedureNameControl.Text.Replace(SelectedField.FieldName, "");
                }

                // Remove the old selection
                this.SelectedField = null;
            }
            #endregion
            
            #region RemoveSelectedFieldSet()
            /// <summary>
            /// This method Remove Selected Field Set
            /// </summary>
            public void RemoveSelectedFieldSet()
            {
                // if a selected field exists
                if ((this.HasSelectedFieldSet) && (this.MethodNameControl.Text.EndsWith(SelectedFieldSet.Name)))
                {
                    // Remove the old field name
                    this.MethodNameControl.Text = this.MethodNameControl.Text.Replace(SelectedFieldSet.Name, "");
                    this.ProcedureNameControl.Text = this.ProcedureNameControl.Text.Replace(SelectedFieldSet.Name, "");
                }
            }
            #endregion
            
            #region Setup(DTNTable table, Project selectedProject, Method selectedMethod = null)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(DTNTable table, Project selectedProject, Method selectedMethod = null)
            {
                // store the args
                this.SelectedTable = table;
                this.SelectedProject = selectedProject;
                this.SelectedMethod = selectedMethod;

                // If the SelectedMethod object does not exist
                if (!this.HasSelectedMethod)
                {
                    // Create a new instance of a 'Method' object.
                    this.SelectedMethod = new Method();
                }

                // if the SelectedTable exists
                if (this.HasSelectedTable)
                {
                    // Load the Fields
                    this.ParameterFieldControl.LoadItems(this.SelectedTable.Fields);

                    // Load the FieldSets
                    this.ParameterFieldSetControl.LoadItems(this.SelectedTable.ParameterFieldSets);

                    // if this table is a View
                    if (this.SelectedTable.IsView)
                    {
                        // Remove the Delete By and Find By
                        this.MethodTypeControl.Items.RemoveAt(1);
                        this.MethodTypeControl.Items.RemoveAt(0);

                        // Set the value for the property 'ViewMode' to true
                        ViewMode = true;
                    }

                    // Load the CustomReaders
                    this.CustomReaderControl.LoadItems(this.SelectedTable.CustomReaders);
                }

                // Change the text of the Save to Next-
                this.SaveCancelControl.SetupSaveButton("Next", 80);
                this.SaveCancelControl.EnableSaveButton(true);

                // If the SelectedMethod object exists
                if (this.HasSelectedMethod)
                {
                    // Display the SelectedMethod
                    DisplaySelectedMethod();
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method handles enabling what is enabled or not 
            /// </summary>
            public void UIEnable()
            {
                // local (default to true)
                bool enabled = true;
                bool orderByVisible = true;
                bool topRowsVisible = true;
                
                // If the MethodInfo object exists
                if (this.HasMethodInfo)
                {
                    // if Delete
                    if (MethodInfo.MethodType == MethodTypeEnum.Delete_By)
                    {
                        // remote the selection
                        this.UpdateOnBuildCheckbox.Checked = false;

                        // not enabled for Delete
                        enabled = false;

                         // set to true
                        orderByVisible = false;
                        topRowsVisible = false;
                    }
                    else
                    {
                        // remote the selection
                        this.UpdateOnBuildCheckbox.Checked = true;
                    }

                    // Enable if the ParamterType is FieldSet
                    this.ParameterFieldSetControl.Enabled = (MethodInfo.ParameterType == ParameterTypeEnum.Field_Set);
                    this.ParameterFieldSetControl.Editable = (MethodInfo.ParameterType == ParameterTypeEnum.Field_Set);

                    // Enable if the ParameterFieldControl if this is a Single Field parameter
                    this.ParameterFieldControl.Enabled = (MethodInfo.ParameterType == ParameterTypeEnum.Single_Field);
                    this.ParameterFieldControl.Editable = (MethodInfo.ParameterType == ParameterTypeEnum.Single_Field);

                    // Update 8.11.2019: The ParametersControl.LabelText needs to reflect the correct case, singular or plural
                    if (MethodInfo.ParameterType == ParameterTypeEnum.Field_Set)
                    {
                        // change to plural
                        ParametersControl.LabelText = "Parameters:";
                    }
                    else
                    {
                        // change to singular
                        ParametersControl.LabelText = "Parameter:";
                    }

                    // if Using a Custom Reader, the only order by available, is the ReaderFieldSet, and it has to also be
                    // an order by field set.
                    if ((MethodInfo.HasCustomReader) && (MethodInfo.CustomReader.HasFieldSet) && (MethodInfo.CustomReader.FieldSet.HasFields) && (MethodInfo.CustomReader.FieldSet.OrderByMode))
                    {
                        // Hide OrderByFieldControl
                        OrderByFieldControl.Visible = false;
                        DescendingCheckBox.Visible = false;

                        // Show the FieldSet and Button
                        OrderByFieldSetControl.Visible = true;
                        OrderByFieldSetControl.Editable = true;
                        OrderByFieldSetControl.Enabled = true;
                        EditOrderByFieldSetsButton.Visible = true;
                        EditOrderByFieldSetsButton.Enabled = true;    
                    }
                    else
                    { 
                        // if the value for orderByVisible is true
                        if (orderByVisible)
                        {
                            // Show OrderByTypeControl
                            OrderByTypeControl.Visible = true;

                            // Determine which Order By controls are visible
                            if (MethodInfo.OrderByType == OrderByTypeEnum.Single_Field)
                            {
                                // Hide the FieldSet and Button
                                OrderByFieldSetControl.Visible = false;
                                EditOrderByFieldSetsButton.Visible = false;
                                
                                // Show the Order By Field Control
                                OrderByFieldControl.Visible = true;
                                DescendingCheckBox.Visible = true;
                                OrderByFieldControl.Editable = true;
                            }
                            else if (MethodInfo.OrderByType == OrderByTypeEnum.Field_Set)
                            {
                                // Hide the OrderByField & DescendingCheckBox controls
                                OrderByFieldControl.Visible = false;
                                DescendingCheckBox.Visible = false;

                                // Show the FieldSet and Button
                                OrderByFieldSetControl.Editable = true;
                                OrderByFieldSetControl.Enabled = true;
                                EditOrderByFieldSetsButton.Visible = true;
                                EditOrderByFieldSetsButton.Enabled = true;
                            }
                            else
                            {
                                // this should never happen

                                // Hide all controls
                                OrderByFieldControl.Visible = false;
                                DescendingCheckBox.Visible = false;
                                OrderByFieldSetControl.Visible = false;
                                EditOrderByFieldSetsButton.Visible = false;
                            }
                        }
                        else
                        {
                            // Hide all controls
                            OrderByFieldControl.Visible = false;
                            DescendingCheckBox.Visible = false;
                            OrderByFieldSetControl.Visible = false;
                            OrderByTypeControl.Visible = false;
                            EditOrderByFieldSetsButton.Visible = false;
                        }
                    }
                }

                // if this table is a View, show the icon for IsViewIcon
                this.IsViewIcon.Visible = ((this.HasSelectedTable) && (this.SelectedTable.IsView));

                this.UpdateOnBuildCheckbox.Editable = enabled;
                this.UseCustomReaderCheckBox.Editable = enabled;
                this.CustomReaderControl.Editable = enabled;
                this.EditReadersButton.Enabled = enabled;
                this.TopRowsControl.Visible = topRowsVisible;

                // refresh everything
                Refresh();  
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
            
            #region HasParentCustomMethodEditorForm
            /// <summary>
            /// This property returns true if this object has a 'ParentCustomMethodEditorForm'.
            /// </summary>
            public bool HasParentCustomMethodEditorForm
            {
                get
                {
                    // initial value
                    bool hasParentCustomMethodEditorForm = (this.ParentCustomMethodEditorForm != null);
                    
                    // return value
                    return hasParentCustomMethodEditorForm;
                }
            }
            #endregion
            
            #region HasSelectedField
            /// <summary>
            /// This property returns true if this object has a 'SelectedField'.
            /// </summary>
            public bool HasSelectedField
            {
                get
                {
                    // initial value
                    bool hasSelectedField = (this.SelectedField != null);
                    
                    // return value
                    return hasSelectedField;
                }
            }
            #endregion
            
            #region HasSelectedFieldSet
            /// <summary>
            /// This property returns true if this object has a 'SelectedFieldSet'.
            /// </summary>
            public bool HasSelectedFieldSet
            {
                get
                {
                    // initial value
                    bool hasSelectedFieldSet = (this.SelectedFieldSet != null);
                    
                    // return value
                    return hasSelectedFieldSet;
                }
            }
            #endregion
            
            #region HasSelectedMethod
            /// <summary>
            /// This property returns true if this object has a 'SelectedMethod'.
            /// </summary>
            public bool HasSelectedMethod
            {
                get
                {
                    // initial value
                    bool hasSelectedMethod = (this.SelectedMethod != null);
                    
                    // return value
                    return hasSelectedMethod;
                }
            }
            #endregion
            
            #region HasSelectedProject
            /// <summary>
            /// This property returns true if this object has a 'SelectedProject'.
            /// </summary>
            public bool HasSelectedProject
            {
                get
                {
                    // initial value
                    bool hasSelectedProject = (this.SelectedProject != null);
                    
                    // return value
                    return hasSelectedProject;
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
            
            #region ParentCustomMethodEditorForm
            /// <summary>
            /// This read only property returns the ParentForm of this object, cast as a CustomMethodEditorForm.
            /// </summary>
            public CustomMethodEditorForm ParentCustomMethodEditorForm
            {
                get
                {
                    // initial value
                    CustomMethodEditorForm parentCustomMethodEditorForm = this.Parent as CustomMethodEditorForm;

                    // return value
                    return parentCustomMethodEditorForm;
                }
            }
            #endregion

            #region SelectedField
            /// <summary>
            /// This property gets or sets the value for 'SelectedField'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public DTNField SelectedField
            {
                get { return selectedField; }
                set { selectedField = value; }
            }
            #endregion
            
            #region SelectedFieldSet
            /// <summary>
            /// This property gets or sets the value for 'SelectedFieldSet'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public FieldSet SelectedFieldSet
            {
                get { return selectedFieldSet; }
                set { selectedFieldSet = value; }
            }
            #endregion
            
            #region SelectedMethod
            /// <summary>
            /// This property gets or sets the value for 'SelectedMethod'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public Method SelectedMethod
            {
                get { return selectedMethod; }
                set
                { 
                    selectedMethod = value; 
                }
            }
            #endregion
            
            #region SelectedProject
            /// <summary>
            /// This property gets or sets the value for 'SelectedProject'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
            }
            #endregion
            
            #region SelectedTable
            /// <summary>
            /// This property gets or sets the value for 'SelectedTable'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public DTNTable SelectedTable
            {
                get { return selectedTable; }
                set 
                {
                    selectedTable = value;

                    // Display the TableName
                    DisplaySelectedTable();
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
            
            #region ViewMode
            /// <summary>
            /// This property gets or sets the value for 'ViewMode'.
            /// </summary>
            public bool ViewMode
            {
                get { return viewMode; }
                set { viewMode = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
