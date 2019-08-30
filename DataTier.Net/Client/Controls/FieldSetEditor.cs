

#region using statements

using DataGateway;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataTierClient.ClientUtil;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using DataTierClient.Objects;
using DataTierClient.Xml.Writers;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class FieldSetEditor
    /// <summary>
    /// This class is used to edit field sets.
    /// Field Sets can either be for parameters, or for Custom Readers.
    /// </summary>
    public partial class FieldSetEditor : UserControl, ICheckChangedListener, ITabButtonParent, ISaveCancelControl, ITextChanged
    {
        
        #region Private Variables
        private bool parameterMode;
        private bool parameterModeReadOnly;
        private bool orderByModeReadOnly;
        private bool readerModeReadOnly;
        private DTNTable selectedTable;
        private FieldSet selectedFieldSet;
        private EditModeEnum editMode;
        private string failedReason;
        private string storedXml;
        private int savedCount;
        private bool loading;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FieldSetEditor' object.
        /// </summary>
        public FieldSetEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region FieldSetsListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when a selection is made in the 'FieldSetsListBox_'.
            /// </summary>
            private void FieldSetsListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if not currently loading
                if (!this.Loading)
                {
                    // local
                    int index = this.FieldSetsListBox.SelectedIndex;

                    // If the SelectedTable object exists
                    if ((index >= 0) && (this.HasSelectedTable) && (this.SelectedTable.HasFieldSets))
                    {
                        // Set the selectedFieldSet
                        this.SelectedFieldSet = this.SelectedTable.FieldSets[index];

                        // if we have a selected field set
                        if ((this.HasSelectedFieldSet) && (!this.SelectedFieldSet.IsNew))
                        {
                            // Create a new instance of a 'Gateway' object.
                            Gateway gateway = new Gateway();

                            // Load the FieldSetFields for this table
                            this.SelectedFieldSet.Fields = FieldSetHelper.LoadFieldSetFields(this.SelectedFieldSet.FieldSetId);
                        }

                        // Display the selectedFieldSet
                        DisplaySelectedFieldSet();
                    }

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region FieldsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            /// <summary>
            /// event is fired when Fields List Box _ Item Check
            /// </summary>
            private void FieldsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                // locals
                bool isChecked = false;
                ColumnInfo columnInfo = null;

                // do not Capture when Loading
                if (!this.Loading)
                {
                    // If the SelectedFieldSet object exists
                    if (this.HasSelectedFieldSet)
                    {
                        // if it is now checked
                        if (e.NewValue == CheckState.Checked)
                        {
                            // toggle to true
                            isChecked = true;
                        }

                        // Create a new instance of a 'ColumnInfo' object.
                        columnInfo = new ColumnInfo(e.Index, isChecked);    
                    }

                    // Capture the SelectedFieldSet
                    CaptureSelectedFieldSet(columnInfo);

                    // Enable controls
                    UIEnable();

                    // If the selectedFieldSet exists and OrderByMode is true
                    if ((HasSelectedFieldSet) && (SelectedFieldSet.OrderByMode))
                    {
                        // Load the fields
                        this.SelectedFieldSet.Fields = FieldSetHelper.LoadFieldSetFields(SelectedFieldSet.FieldSetFields, SelectedFieldSet.Fields);

                        // Redisplay the Fields
                        OrderByControl.DisplayFields();
                    }
                }
            }
            #endregion
            
            #region FieldsListBox_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// event is fired when Fields List Box _ Key Down
            /// </summary>
            internal void FieldsListBox_KeyDown(object sender, KeyEventArgs e)
            {
                // if the SelectedTable exists
                if (this.HasSelectedTable)
                {
                    // if Control A was pressed
                    if ((e.Control) && (e.KeyCode == Keys.A))
                    {
                        // Handle Select All
                        HandleSelectAll();
                    }
                    else if ((e.Control) && (e.KeyCode == Keys.N))
                    {
                        // Handle Select None
                        HandleSelectNone();
                    }
                }
            }
            #endregion
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // If the SelectedFieldSet object exists
                if (this.HasSelectedFieldSet)
                {
                    switch (sender.Name)
                    {
                        case "ParameterModeCheckBox":

                            // set the new value
                            this.SelectedFieldSet.ParameterMode = isChecked;        

                            // Set ParameterMode if isChecked is true
                            this.ParameterMode = isChecked;

                            // required
                            break;

                        case "OrderByModeCheckBox":

                            // set the new value
                            this.SelectedFieldSet.OrderByMode = isChecked;        
                            
                            // required
                            break;

                        case "ReaderModeCheckBox":

                            // set the new value
                            this.SelectedFieldSet.ReaderMode = isChecked;        
                            
                            // required
                            break;
                    }
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region OnTextChanged(LabelTextBoxControl sender, string text);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnTextChanged(Control control, string text)
            {
                // cast the sender as a LabelTextBoxControl
                LabelTextBoxControl sender = control as LabelTextBoxControl;

                // If the SelectedFieldSet object exists
                if (this.HasSelectedFieldSet)
                {
                    // Set the name
                    this.SelectedFieldSet.Name = text;
                }

                // Enable controls
                UIEnable();
            }
            #endregion

        #endregion

        #region Methods

            #region CaptureSelectedFieldSet(ColumnInfo columnInfo = null)
            /// <summary>
            /// This method Capture Selected Field Set
            /// </summary>
            public void CaptureSelectedFieldSet(ColumnInfo columnInfo = null)
            {
                // locals
                int fieldOrdinal = -1;
                bool isChecked = false;

                // If the SelectedFieldSet object exists
                if ((this.HasSelectedFieldSet) && (this.HasSelectedTable))
                {
                    // these fields are redundand, but it saves extra lookups
                    this.selectedFieldSet.DatabaseId = this.SelectedTable.DatabaseId;
                    this.SelectedFieldSet.ProjectId = this.SelectedTable.ProjectId;

                    // Store the values
                    this.SelectedFieldSet.TableId = this.SelectedTable.TableId;
                    this.SelectedFieldSet.Name = this.FieldSetNameControl.Text;
                    this.SelectedFieldSet.ParameterMode = this.ParameterModeCheckBox.Checked;
                    this.SelectedFieldSet.OrderByMode = this.OrderByModeCheckBox.Checked;
                    this.SelectedFieldSet.ReaderMode = this.ReaderModeCheckBox.Checked;

                    // Create a new collection of 'DTNField' objects.
                    this.SelectedFieldSet.Fields = new List<DTNField>();
                    this.SelectedFieldSet.FieldSetFields = new List<FieldSetField>();
                    
                    // iterate the fields
                    for (int x = 0; x < this.FieldsListBox.Items.Count; x++)
                    {
                        // If the columnInfo object exists
                        if ((NullHelper.Exists(columnInfo)) && (columnInfo.Index == x))
                        {
                            // these seem to be different than 
                            isChecked = columnInfo.Selected;    
                        }
                        else
                        {
                            // is this item checked
                            isChecked = FieldsListBox.GetItemChecked(x);
                        }

                        // if this item is checked
                        if (isChecked)
                        {
                            // Increment the value for fieldOrdinal
                            fieldOrdinal++;

                            // get this field
                            DTNField field = this.SelectedTable.Fields[x];

                            // Create the FieldSetField
                            FieldSetField fieldSetField = new FieldSetField();

                            // Set the properties
                            fieldSetField.FieldId = field.FieldId;
                            fieldSetField.FieldOrdinal = fieldOrdinal;
                            fieldSetField.FieldSetId = this.SelectedFieldSet.FieldSetId;

                            // if we are in OrderByMode
                            if (SelectedFieldSet.OrderByMode)
                            {
                                // Set the FieldOrdinal
                                fieldSetField.FieldOrdinal = OrderByControl.FindFieldOrdinal(field.FieldName);
                            }

                            // Get the FieldSetIndex
                            int index = GetFieldIndex(field.FieldId, true);
                            
                            // if the index was not found
                            if (index < 0)
                            {
                                // Add this field
                                this.SelectedFieldSet.FieldSetFields.Add(fieldSetField);
                            }
                        }
                    }

                    // update the count
                    int count = this.SelectedFieldSet.FieldSetFields.Count;
                    this.SelectedFieldsCountLabel.Text = count.ToString();
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
                        // only add active fields on this screen
                        if (!field.Exclude)
                        {
                            // Add this field
                            this.FieldsListBox.Items.Add(field, false);
                        }
                    }
                }
            }
            #endregion

            #region DisplayFieldSetFields()
            /// <summary>
            /// This method Display Field Set Fields
            /// </summary>
            public void DisplayFieldSetFields()
            {
                try
                {
                    // Set loading to true
                    this.Loading = true;

                    // selected count
                    int count = 0;
                    
                    // If the SelectedFieldSet.FieldSetFields exists
                    if ((HasSelectedFieldSet) && (SelectedFieldSet.HasFields) && (this.SelectedFieldSet.Fields.Count > 0))
                    {
                        // Clear all selections
                        HandleSelectNone();

                        // iterate the FieldSetFields
                        foreach (DTNField field in this.SelectedFieldSet.Fields)
                        {
                            // Get the field index for the field given
                            int index = GetFieldIndex(field.FieldId);

                            // if the index was found and is in range
                            if ((index >= 0) && (index < this.FieldsListBox.Items.Count))
                            {
                                // Increment the value for count
                                count++;

                                // check this field
                                this.FieldsListBox.SetItemCheckState(index, CheckState.Checked);
                            }
                        }

                        // display the total
                        this.SelectedFieldsCountLabel.Text = count.ToString();
                    }
                    else
                    {
                        // Clear all selections
                        HandleSelectNone();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("DisplayFieldSetFields", this.Name, error);
                }
                finally
                {
                    // set Loading to false
                    this.Loading = false;
                }
            }
            #endregion
            
            #region DisplayFieldSets(int fieldSetIdToSelect = -1)
            /// <summary>
            /// This method Display Field Sets.
            /// </summary>
            /// <param name="fieldSetIdToSelect">If a fieldSetId is passed in, the index
            /// is attempted to be found and then the selected index is set.</param>
            public void DisplayFieldSets(int fieldSetIdToSelect = -1)
            {
                try
                {
                    // set to true
                    this.Loading = true;

                    // locals
                    int index = -1;
                    int selectedIndex = index;
                
                    // clear the list box
                    this.FieldSetsListBox.Items.Clear();

                    // If the SelectedTable object exists
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasFieldSets))
                    {  
                        // iterate the FieldSets                    
                        foreach(FieldSet fieldSet in this.SelectedTable.FieldSets)
                        {
                            // Increment the value for index
                            index++;

                            // Add this item
                            this.FieldSetsListBox.Items.Add(fieldSet);
                        
                            // if this is the item to select
                            if (fieldSet.FieldSetId == fieldSetIdToSelect)
                            {
                                // set the selectedIndex
                                selectedIndex = index;
                            }
                        }

                        // Set the selected index
                        this.FieldSetsListBox.SelectedIndex = selectedIndex;

                        // Display the Selected FieldSet
                        DisplaySelectedFieldSet();
                    }
                }
                catch (Exception error)
                {
                    // write to the debug window for now
                    DebugHelper.WriteDebugError("DisplayFieldSets", this.Name, error);
                }
                finally
                {
                    // set to false
                    this.Loading = false;
                }
            }
            #endregion
                
            #region DisplaySelectedFieldSet()
            /// <summary>
            /// This method Display Selected Field Set
            /// </summary>
            public void DisplaySelectedFieldSet()
            {
                try
                {
                    // Set Loading to true so the fields do not get added when checked
                    this.Loading = true;

                    // locals
                    string name = "";
                    bool parameterMode = false;
                    bool orderByMode = false;
                    bool readerMode = false;

                    // If the SelectedFieldSet object exists
                    if (this.HasSelectedFieldSet)
                    {
                        // set the values
                        name = this.SelectedFieldSet.Name;
                        parameterMode = this.SelectedFieldSet.ParameterMode;
                        orderByMode = this.SelectedFieldSet.OrderByMode;
                        readerMode = this.SelectedFieldSet.ReaderMode;

                        // if the value for orderByMode is true
                        if (orderByMode)
                        {
                            // Set the FieldSet
                            this.OrderByControl.DisplayFields();
                        }
                    }

                    // if Read Only Parameter Mode, then this can't be changed
                    if (ParameterModeReadOnly)
                    {
                        // set it back to false
                        parameterMode = true;
                    }

                    // Check the fields selected for this field set
                    DisplayFieldSetFields();

                    // display the values
                    this.FieldSetNameControl.Text = name;

                    // if we are not in paremterModeReadOnly mode.
                    if (!parameterModeReadOnly)
                    {
                        // Check the box if in ParameterMode
                        this.ParameterModeCheckBox.Checked = parameterMode;
                    }
                    
                    // if we are not in Order By Mode Read Only
                    if (!OrderByModeReadOnly)
                    {
                        // Check the box if in orderByMode
                        this.OrderByModeCheckBox.Checked = orderByMode;
                    }

                    // probably needs Read Only also, but not now
                    this.ReaderModeCheckBox.Checked = readerMode;
                }
                catch (Exception error)
                {
                    // For debugging only for now
                    DebugHelper.WriteDebugError("DisplaySelectedFieldSet", this.Name, error);
                }
                finally
                {
                    // Set Loading to false
                    this.Loading = false;
                }

                // refresh everything
                this.Refresh();
            }
            #endregion
            
            #region EnableModeImages()
            /// <summary>
            /// This method Enable Mode Images
            /// </summary>
            public void EnableModeImages()
            {
                // locals
                bool showParameterMode = false;
                bool showOrderByMode = false;
                bool showReaderMode = false;
                int count = 0;
                Point location1 = new Point(0, 0);
                Point location2 = new Point(194, 0);
                Point location3 = new Point(388, 0);
                List<PictureBox> visibleImages = null;

                // if the value for HasSelectedFieldSet is true
                if (HasSelectedFieldSet)
                {
                    // set each value
                    showParameterMode = SelectedFieldSet.ParameterMode;
                    showOrderByMode = SelectedFieldSet.OrderByMode;
                    showReaderMode = SelectedFieldSet.ReaderMode;
                }
                else
                {
                    // if the value for ParameterModeReadOnly is true
                    if (ParameterModeReadOnly)
                    {
                        // Show the ParameterMode Image
                        showParameterMode = true;
                    }

                    // if the value for OrderByModeReadOnly is true
                    if (OrderByModeReadOnly)
                    {   
                        // Show the OrderByMode Image
                        showOrderByMode = true;
                    }
                }

                // get the visible images
                visibleImages = GetVisibleImages();
                
                // If the visibleImages collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(visibleImages))
                {  
                    // Iterate the collection of PictureBox objects
                    foreach (PictureBox pictureBox in visibleImages)
                    {
                        // determine the control location by the count
                        if (count == 0)      
                        {
                            // set the Location
                            pictureBox.Location = location1;
                        }
                        else if (count == 1)
                        {
                            // set the Location
                            pictureBox.Location = location2;
                        }
                        else if (count == 2)
                        {
                            // set the Location
                            pictureBox.Location = location3;
                        }

                        // Increment the value for count
                        count++;    
                    }
                }
                

                // show each image
                this.ParameterModeImage.Visible = showParameterMode;
                this.OrderByImage.Visible = showOrderByMode;
                this.ReaderModeImage.Visible = showReaderMode;

                // if the value for HasSelectedFieldSet is true
                if (HasSelectedFieldSet)
                {
                    // if the value for showReaderMode is true
                    if (showReaderMode)
                    {
                        // Display the fields
                        this.OrderByControl.DisplayFields();
                    }

                    // Show or hide the controls
                    this.OrderByControl.Visible = showReaderMode;
                    this.OrderByLabel.Visible = showReaderMode;
                }
                else
                {
                    // Show the OrderByControl
                    this.OrderByControl.Visible = false;
                    this.OrderByLabel.Visible = false;
                }

                // Refresh everything
                this.Refresh();
            }
            #endregion
            
            #region GetFieldIndex(int fieldId, bool lookInFieldSetFields = false)
            /// <summary>
            /// This method Get Field Index of the SelectedTable.Fields
            /// </summary>
            public int GetFieldIndex(int fieldId, bool lookInFieldSetFields = false)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the SelectedFieldSet object exists
                if (this.HasSelectedFieldSet)
                {
                    // if the value for lookInFieldSetFields is true
                    if ((lookInFieldSetFields) && (this.SelectedFieldSet.HasFieldSetFields))
                    {  
                        // iterate the fields for this table
                        foreach (FieldSetField field in this.SelectedFieldSet.FieldSetFields)
                        {
                            // Increment the value for tempIndex
                            tempIndex++;

                            // if this is the Field being sought
                            if (field.FieldId == fieldId)
                            {
                                // set the return value
                                index = tempIndex;

                                // break out of this loop
                                break;
                            }
                        }
                    }
                    else if ((this.HasSelectedTable) &&  (this.SelectedTable.HasFields))
                    {
                        // iterate the fields for this table
                        foreach (DTNField field in this.SelectedTable.Fields)
                        {
                            // Increment the value for tempIndex
                            tempIndex++;

                            // if this is the Field being sought
                            if (field.FieldId == fieldId)
                            {
                                // set the return value
                                index = tempIndex;

                                // break out of this loop
                                break;
                            }
                        }
                    }
                }

                // return value
                return index;
            }
            #endregion
            
            #region GetFieldSetIndex(string name)
            /// <summary>
            /// This method returns the Field Set Index
            /// </summary>
            /// <param name="name">The name of the FieldSet to search for.</param>
            public int GetFieldSetIndex(string name)
            {
                // initial value
                int fieldSetIndex = -1;

                // local
                int index = -1;

                // if the SelectedTable.FieldSets exist
                if ((this.HasSelectedTable) && (this.SelectedTable.HasFieldSets))
                {
                    // iterate the FieldSets
                    foreach (FieldSet fieldSet in this.SelectedTable.FieldSets)
                    {
                        // Increment the value for index
                        index++;

                        // if this is the item being sought
                        if (fieldSet.Name == name)
                        {
                            // set the return value
                            fieldSetIndex = index;

                            // break out of this loop
                            break;
                        }
                    }
                }
                
                // return value
                return fieldSetIndex;
            }
            #endregion
            
            #region GetVisibleImages()
            /// <summary>
            /// This method returns a list of Visible Images
            /// </summary>
            public List<PictureBox> GetVisibleImages()
            {
                // initial value
                List<PictureBox> visibleImages = new List<PictureBox>();

                // if the value for HasSelectedFieldSet is true
                if (HasSelectedFieldSet)
                {
                    // if ParameterMode is true or ParameterModeReadOnly is true
                    if ((SelectedFieldSet.ParameterMode) || (ParameterModeReadOnly))
                    {
                        // Add this image
                        visibleImages.Add(ParameterModeImage);
                    }

                    // if OrderbyMode is true or OrderByModeReadOnly is true
                    if ((SelectedFieldSet.OrderByMode) || (OrderByModeReadOnly))
                    {  
                        // Add this image
                        visibleImages.Add(OrderByImage);
                    }

                    // if OrderbyMode is true or ReaderModeReadOnly is true
                    if ((SelectedFieldSet.ReaderMode) || (ReaderModeReadOnly))
                    {
                        // Add this image
                        visibleImages.Add(ReaderModeImage);
                    }
                }
                else if (ParameterModeReadOnly)
                {
                    // Add this image
                    visibleImages.Add(ParameterModeImage);
                }
                else if (OrderByModeReadOnly)
                {
                    // Add this image
                    visibleImages.Add(OrderByImage);
                }

                // return value
                return visibleImages;
            }
            #endregion
            
            #region HandleSave()
            /// <summary>
            /// This method Handle Save
            /// </summary>
            public void HandleSave()
            {
                // If the 'SelectedTable' object and the 'SelectedFieldSet' objects both exist.
                if ((this.HasSelectedTable) && (this.HasSelectedFieldSet))
                {
                    // locals
                    bool tempSaved = false;
                    string errorMessage = "";
                    Exception error = null;
                    bool isNew = this.SelectedFieldSet.IsNew;

                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // perform the save
                    bool saved = gateway.SaveFieldSet(ref selectedFieldSet);

                    // if the value for saved is true and now the FieldSetId is set
                    if ((saved) && (!this.SelectedFieldSet.IsNew))
                    {
                        // Increment the value for SavedCount
                        SavedCount++;

                        // if the value for wasNew is true and the FieldSets collection exists
                        if ((isNew) && (this.SelectedFieldSet.HasFieldSetFields))
                        {  
                            // iterate the FieldSetFields
                            foreach (FieldSetField field in this.SelectedFieldSet.FieldSetFields)
                            {
                                // Update the FieldSetId
                                field.FieldSetId = this.SelectedFieldSet.FieldSetId;      
                            }
                        }

                        // perform the delete
                        bool deleted = gateway.DeleteFieldSetFieldsForFieldSetId(this.SelectedFieldSet.FieldSetId);

                        // make sure the delete was successful
                        if (deleted)
                        {
                            // iterate the FieldSetFields
                            foreach (FieldSetField field in this.SelectedFieldSet.FieldSetFields)
                            {
                                // clone this field
                                FieldSetField tempField = field.Clone();

                                // make sure a new record is inserted since a delete was just executed
                                tempField.UpdateIdentity(0);

                                // save this field
                                tempSaved = gateway.SaveFieldSetField(ref tempField);

                                // if the value for tempSaved is false
                                if (!tempSaved)
                                {
                                    // get the last exception (for debugging only)
                                    error = gateway.GetLastException();

                                    // Set the error text
                                    errorMessage = "An error occurred saving this FieldSet.Fields";

                                    // set saved to false
                                    saved = false;
                                }
                                else
                                {
                                    // Increment the value for SavedCount
                                    SavedCount++;
                                }
                            }
                        }
                    }
                    else
                    {  
                        // get the last exception (for debugging only)
                        error = gateway.GetLastException();

                        // Set the error text
                        errorMessage = "An error occurred saving this FieldSet";
                    }

                    // if the value for saved is true
                    if (saved)
                    {
                        // reload the FieldSets
                        this.SelectedTable.FieldSets = gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);

                        // redisplay the FieldSets
                        DisplayFieldSets(this.SelectedFieldSet.FieldSetId);

                        // Show the Saved message
                        ShowStatusMessage(true, "Saved.");

                        // Call cancel to exit EditMode
                        OnCancel();

                        // Call this to update the current display (mainly the Fields count)
                        FieldSetsListBox_SelectedIndexChanged(this, new EventArgs());
                    }
                    else
                    {
                        // Set the FailedReason
                        this.FailedReason = errorMessage;

                        // Show the error
                        ShowStatusMessage(false, errorMessage);
                    }
                }
            }
            #endregion
            
            #region HandleSelectAll()
            /// <summary>
            /// This method Handle Select All
            /// </summary>
            public void HandleSelectAll()
            {
                // if the value for ParameterMode is false or there are only four fields in this table.
                if ((!ParameterMode) || (this.FieldsListBox.Items.Count <= 4))
                {
                    // Toggle to false temporarily
                    FieldsListBox.CheckOnClick = false;

                    // Change to None
                    FieldsListBox.SelectionMode = SelectionMode.None;

                    // Clear all selections
                    FieldsListBox.SelectedItems.Clear();

                    // iterate the Fields
                    for(int x = 0; x < FieldsListBox.Items.Count; x++)
                    {
                        // Check all the items
                        FieldsListBox.SetItemCheckState(x, CheckState.Checked);
                    }

                    // Toggle to false temporarily
                    FieldsListBox.CheckOnClick = true;

                    // Change back to One
                    FieldsListBox.SelectionMode = SelectionMode.One;
                }
                else
                {
                    // inform the user that in ParameterMode, manual selectections are required
                    MessageBoxHelper.ShowMessage("In ParameterMode, you must manually select up to four fields.", "Invalid Selection");
                }
            }
            #endregion
            
            #region HandleSelectNone()
            /// <summary>
            /// This method Handle Select None
            /// </summary>
            public void HandleSelectNone()
            {
                // Toggle to false temporarily
                FieldsListBox.CheckOnClick = false;

                // Change to None
                FieldsListBox.SelectionMode = SelectionMode.None;

                // Clear all selections
                FieldsListBox.SelectedItems.Clear();

                // iterate the Fields
                for(int x = 0; x < FieldsListBox.Items.Count; x++)
                {
                    // Check all the items
                    FieldsListBox.SetItemCheckState(x, CheckState.Unchecked);
                }

                // Toggle to false temporarily
                FieldsListBox.CheckOnClick = true;

                // Change back to One
                FieldsListBox.SelectionMode = SelectionMode.One;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Setup this listeners
                this.ParameterModeCheckBox.CheckChangedListener = this;
                this.OrderByModeCheckBox.CheckChangedListener = this;
                this.ReaderModeCheckBox.CheckChangedListener = this;

                // Setup this listener
                this.FieldSetNameControl.OnTextChangedListener = this;

                // Change the Cancel button text to Done
                this.SaveCancelControl.SetupCancelButton("Done", 80, true, true);
                
                // Hide the Save button on this control
                this.SaveCancelControl.SetupSaveButton("", 0, false, false);
            }
            #endregion

            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the value for the property this.IsInEditMode is true
                if (this.IsInEditMode)
                {
                    // if the SelectedFieldSet exists and the SelectedFieldSet is new (has not been saved)
                    if ((this.HasSelectedFieldSet) && (this.SelectedFieldSet.IsNew))
                    {
                        // if this is the only field set
                        if (this.SelectedTable.FieldSets.Count == 1)
                        {
                            // easy to delete
                            this.SelectedTable.FieldSets = new List<FieldSet>();
                        }
                        else if (this.SelectedTable.FieldSets.Count > 1)
                        {
                            // get the fieldSetIndex
                            int fieldSetIndex = GetFieldSetIndex(this.SelectedFieldSet.Name);

                            // if the fieldSetIndex is set and in range
                            if ((fieldSetIndex >= 0) && (fieldSetIndex < this.SelectedTable.FieldSets.Count))
                            {
                                // remove this item
                                this.SelectedTable.FieldSets.RemoveAt(fieldSetIndex);
                            }
                        }

                        // redisplay the fieldSets
                        DisplayFieldSets();
                    }

                    // Exit EditMode
                    this.EditMode = EditModeEnum.Unknown;

                    // erase the SelectedFieldSet
                    this.SelectedFieldSet = null;

                    // Display the SelectedFieldSet (erase current values)
                    DisplaySelectedFieldSet();

                    // Enable or disable controls
                    UIEnable();

                    // Raise this event so the selected item is reselected
                    FieldSetsListBox_SelectedIndexChanged(this, new EventArgs());
                }
                else
                {
                    // If the ParentForm exists
                    if (this.HasParentFieldSetEditorForm)
                    {
                        // Close Form
                        this.ParentFieldSetEditorForm.Close();
                    }
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
                    // Capture all the values and fields for the selected field set
                    CaptureSelectedFieldSet();

                    // bool validate the fieldSet
                    bool isValid = ValidateFieldSet();

                    // if the value for isValid is false
                    if (!isValid)
                    {
                        // Show the error message
                        ShowStatusMessage(false, this.FailedReason);
                    }
                    else
                    {
                        // Handle the save
                        HandleSave();
                    }
                }
                catch (Exception error2)
                {
                    // for debugging only
                    string err = error2.ToString();
                }

                // refresh everything
                this.Refresh();
                Application.DoEvents();
            }
            #endregion

            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // determine action by the button text
                switch (tabButton.ButtonText)
                {
                    case "Add":

                        // Create a new FieldSet
                        this.SelectedFieldSet = new FieldSet();

                        // if read only
                        if (this.ParameterModeReadOnly)
                        {
                            // Set this to true
                            this.SelectedFieldSet.ParameterMode = true;
                        }
                        else if (this.ParameterMode)
                        {
                            // Set this to true
                            this.SelectedFieldSet.ParameterMode = true;
                        }

                        // if the SelectedTable.FieldSets exist
                        if ((this.HasSelectedTable) && (this.SelectedTable.HasFieldSets))
                        {
                            // Add this items
                            this.SelectedTable.FieldSets.Add(this.SelectedFieldSet);
                        }

                        // Add a temp name
                        this.SelectedFieldSet.Name = "<New Field Set>";

                        // Display the FieldSets
                        DisplayFieldSets(0);

                        // Set the EditMode
                        this.EditMode = EditModeEnum.AddNew;

                        // Enable the controls on this form
                        UIEnable();

                        // Set Focus to the TextBox
                        this.FieldSetNameControl.SetFocusToTextBox();

                        // required
                        break;
                        
                    case "Edit":

                        // if there is a SelectedFieldSet
                        if (this.HasSelectedFieldSet)
                        {
                            // Create a new instance of a 'FieldSetsWriter' object.
                            FieldSetsWriter writer = new FieldSetsWriter();

                            // Serialize this object
                            this.StoredXml = writer.ExportFieldSet(this.SelectedFieldSet);
                        }

                        // Change the EditMode
                        this.EditMode = EditModeEnum.Edit;

                        // Enable the controls now that we are in EditMode.
                        UIEnable();

                        // required
                        break;

                    case "Delete":

                        // local
                        bool confirmed = false;

                        // If the SelectedFieldSet object exists
                        if (this.HasSelectedFieldSet)
                        {
                            // Set the message and title
                            string message = "Are you sure you wish to delete the selected FieldSet? This action cannot be undone.";
                            string title = "Confirm Delete";

                            // Get Dialog Result
                            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            // if user choose 'Yes'
                            if (result == DialogResult.Yes)
                            {
                                // user confirmed the delete
                                confirmed = true;
                            }

                            // if the value for confirmed is true
                            if (confirmed)
                            {
                                // Create a new instance of a 'Gateway' object.
                                Gateway gateway = new Gateway();

                                // perform the delete
                                bool deleted = gateway.DeleteFieldSet(this.SelectedFieldSet.FieldSetId);

                                // if deleted
                                if (deleted)
                                {
                                    // erase the selected object
                                    this.SelectedFieldSet = null;

                                    // reload the field sets
                                    this.SelectedTable.FieldSets = gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);

                                    // Redisplay the SelectedFieldSets
                                    this.DisplayFieldSets();
                                }
                            }
                        }

                        // required
                        break;
                }

                // Enable the controls
                UIEnable();
            }
            #endregion

            #region Refresh()
            /// <summary>
            /// This method refreshes this control, and the call to DoEvents forces it to happen 
            /// </summary>
            public override void Refresh()
            {
                // Refresh everything
                base.Refresh();
                Application.DoEvents();
            }
            #endregion
            
            #region Setup(DTNTable table, bool parameterMode, bool parameterModeReadOnly = false, FieldSet fieldSet = null)
            /// <summary>
            /// This method prepares this control to be shown.
            /// </summary>
            public void Setup(DTNTable table, bool parameterMode, bool parameterModeReadOnly = false, FieldSet fieldSet = null)
            {
                // Store the args
                this.SelectedTable = table;
                this.ParameterMode = parameterMode;
                this.ParameterModeReadOnly = parameterModeReadOnly;
                this.SelectedFieldSet = fieldSet;

                // Check or uncheck the checkbox
                this.ParameterModeCheckBox.Checked = parameterMode;

                // If the SelectedTable object exists
                if (this.HasSelectedTable)
                {
                    // Display the Table
                    this.TableControl.Text = this.SelectedTable.ClassName;

                    // Display the fields
                    DisplayFields();

                    // if the FieldSets exist
                    if (this.SelectedTable.HasFieldSets)
                    {
                        // Display the FieldSets
                        DisplayFieldSets();    
                    }
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region SetupForOrderByMode(DTNTable table, FieldSet fieldSet = null)
            /// <summary>
            /// This method prepares this control to be shown.
            /// </summary>
            public void SetupForOrderByMode(DTNTable table, FieldSet fieldSet = null)
            {
                // Store the args
                this.SelectedTable = table;
                this.OrderByModeCheckBox.Checked = true;
                this.ParameterMode = false;
                this.ParameterModeCheckBox.Checked = false;
                this.OrderByModeReadOnly = true;
                this.SelectedFieldSet = fieldSet;
                
                // If the SelectedTable object exists
                if (this.HasSelectedTable)
                {
                    // Display the Table
                    this.TableControl.Text = this.SelectedTable.ClassName;

                    // Display the fields
                    DisplayFields();

                    // if the FieldSets exist
                    if (this.SelectedTable.HasFieldSets)
                    {
                        // Display the FieldSets
                        DisplayFieldSets();    
                    }
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region ShowStatusMessage(bool success, string message, string labelText = "", bool visible = true)
            /// <summary>
            /// This method Shows the Status Message
            /// </summary>
            public void ShowStatusMessage(bool success, string message, string labelText = "", bool visible = true)
            {  
                // Show the Validation error
                this.ValidationLabel.Text = message;

                // Show or hide the validationLabel 
                this.ValidationLabel.Visible = visible;

                // if the value for success is true
                if (success)
                {  
                    // If the labelText string exists
                    if (TextHelper.Exists(labelText))
                    {
                        // Set the labelText
                        this.ValidationLabel.LabelText = labelText;
                    }
                    else
                    {
                        // Set the labelText
                        this.ValidationLabel.LabelText = "Status:";
                    }

                    // Set the color to Navy
                    this.ValidationLabel.ValueLabelColor = Color.Navy;
                    this.ValidationLabel.LabelColor = Color.Navy;
                }
                else
                {  
                    // If the labelText string exists
                    if (TextHelper.Exists(labelText))
                    {
                        // Set the labelText
                        this.ValidationLabel.LabelText = labelText;
                    }
                    else
                    {
                        // Set the labelText
                        this.ValidationLabel.LabelText = "Error:";
                    }

                     // Set the color to Firebrick
                    this.ValidationLabel.ValueLabelColor = Color.Firebrick;
                    this.ValidationLabel.LabelColor = Color.Firebrick;
                }
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                // Enable the images for ParameterMode, OrderByMode and / or ReaderMode
                EnableModeImages();

                // if we do not have a table, do not allow anything
                if (this.HasSelectedTable)
                { 
                    // Show the image if in ParameterMode
                    this.ParameterModeCheckBox.Editable = !this.ParameterModeReadOnly;
                    this.OrderByModeCheckBox.Editable = !this.OrderByModeReadOnly;
                    this.EditPanel.Enabled = this.IsInEditMode;
                    this.SaveCancelControl2.Visible = this.IsInEditMode;
                    this.EditModeImage.Visible = this.IsInEditMode;

                    // If the value for the property this.IsInEditMode is true
                    if (this.IsInEditMode)
                    {
                        // Do not allow FieldSets to be clicked on 
                        this.FieldSetsListBox.Enabled = false;
                        this.FieldsListBox.Enabled = true;

                        // Disable all the buttons while in EditMode
                        this.AddButton.Enabled = false;
                        this.EditButton.Enabled = false;
                        this.DeleteButton.Enabled = false;

                        // not enabled during edit mode
                        this.SaveCancelControl.SetupCancelButton("Done", 80, true, false);

                        // Enable the SetNameControl
                        this.FieldSetNameControl.Editable = true;
                        this.ParameterModeCheckBox.Editable = !this.ParameterModeReadOnly;

                        // if we are in AddNew mode
                        if (this.EditMode == EditModeEnum.AddNew)
                        {
                            // Enable the Save button
                            this.SaveCancelControl2.EnableSaveButton(true);
                        }
                        else if (this.EditMode == EditModeEnum.Edit)
                        {
                            // If the 'SelectedFieldSet' object and the 'SerializedFieldSet' objects both exist.
                            if ((this.HasSelectedFieldSet) && (this.HasStoredXml))
                            {
                                // get the current xml

                                // Create a new instance of a 'FieldSetsWriter' object.
                                FieldSetsWriter writer = new FieldSetsWriter();

                                // Export the FieldSet as Xml
                                string selectedFieldSetXml = writer.ExportFieldSet(this.SelectedFieldSet);

                                // Determine if there are changes or not in the xml files
                                bool hasChanges = !TextHelper.IsEqual(StoredXml, selectedFieldSetXml);
                            
                                // Enable the Save button if there are changes
                                this.SaveCancelControl2.EnableSaveButton(hasChanges);
                            }
                            else
                            {
                                // Disable the Save button
                                this.SaveCancelControl2.EnableSaveButton(false);
                            }
                        }
                    }
                    else
                    {
                        // Allow the FieldSets to be edited
                        this.FieldSetsListBox.Enabled = true;

                        // Do not allow Fields to be unchecked or checked unless in EditMode.
                        this.FieldsListBox.Enabled = false;

                        // Always show the Add button 
                        this.AddButton.Enabled = true;

                        // only show the Edit and Delete buttons if there is a SelectedFielSet
                        this.EditButton.Enabled = (this.HasSelectedFieldSet);
                        this.DeleteButton.Enabled = (this.HasSelectedFieldSet);

                        // Enabled when not in edit mode
                        this.SaveCancelControl.SetupCancelButton("Done", 80, true, true);
                    }

                    // local
                    int selectedFieldsCount = 0;

                    // if the SelectedFieldSet.FieldSetFields exist
                    if ((this.HasSelectedFieldSet) && (this.SelectedFieldSet.HasFieldSetFields) && (this.SelectedFieldSet.FieldSetFields.Count > 0))
                    {  
                        // use the FieldSetFields Count
                        selectedFieldsCount = this.SelectedFieldSet.FieldSetFields.Count;
                    }
                    else if ((this.HasSelectedFieldSet) && (this.SelectedFieldSet.HasFields) && (this.SelectedFieldSet.Fields.Count > 0))
                    {
                        // use the Fields Count
                        selectedFieldsCount = this.SelectedFieldSet.Fields.Count;
                    }

                    // Display the value
                    this.SelectedFieldsCountLabel.Text = selectedFieldsCount.ToString();

                    // Show or hide the control
                    OrderByControl.Visible = ((HasSelectedFieldSet) && (SelectedFieldSet.OrderByMode));
                }
                else
                {
                    // Do not allow any editing
                    this.AddButton.Enabled = false;
                    this.EditButton.Enabled = false;
                    this.DeleteButton.Enabled = false;
                    this.FieldSetsListBox.Enabled = false;
                }
            }
            #endregion
            
            #region ValidateFieldSet()
            /// <summary>
            /// This method Validate Field Set
            /// </summary>
            public bool ValidateFieldSet()
            {
                // initial value
                bool isValid = false;

                // If the 'SelectedFieldSet' object and the 'SelectedTable' objects both exist.
                if ((this.HasSelectedFieldSet) && (this.HasSelectedTable))
                {
                    // if the Fields collection does not exist                    
                    if (!this.SelectedFieldSet.HasFields)
                    {
                        // set the FailedReason
                        this.FailedReason = "System Error: The SelectedFieldSet.Fields does not exist.";
                    }
                    else if (this.SelectedFieldSet.FieldSetFields.Count < 1)
                    {
                        // set the FailedReason
                        this.FailedReason = "You must select one or more fields to create a Field Set.";
                    }
                    else if ((this.ParameterMode) && (this.SelectedFieldSet.FieldSetFields.Count > 4))
                    {
                        // set the FailedReason
                        this.FailedReason = "In Parameter Mode there is a maximum of four fields allowed.";
                    }
                    else if (!TextHelper.Exists(this.SelectedFieldSet.Name))
                    {
                        // set the FailedReason
                        this.FailedReason = "You must give the Field Set a name.";

                        // Set focus for the user
                        this.FieldSetNameControl.SetFocusToTextBox();
                    }
                    else
                    {
                        // set to true
                        isValid = true;
                    }
                }
                else if (!this.HasSelectedFieldSet)
                {
                    // set the FailedReason
                    this.FailedReason = "System Error: The SelectedFieldSet does not exist.";
                }
                else if (!this.HasSelectedTable)
                {
                    // set the FailedReason
                    this.FailedReason = "System Error: The SelectedTable does not exist.";
                }

                // return value
                return isValid;
            }
            #endregion
            
        #endregion

        #region Properties

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

            #region EditMode
            /// <summary>
            /// This property gets or sets the value for 'EditMode'.
            /// </summary>
            public EditModeEnum EditMode
            {
                get { return editMode; }
                set 
                {
                    // set EditMode
                    editMode = value;

                    // Erase the SelectedField
                    this.OrderByControl.SelectedField = null;

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region FailedReason
            /// <summary>
            /// This property gets or sets the value for 'FailedReason'.
            /// </summary>
            public string FailedReason
            {
                get { return failedReason; }
                set { failedReason = value; }
            }
            #endregion
            
            #region HasFailedReason
            /// <summary>
            /// This property returns true if the 'FailedReason' exists.
            /// </summary>
            public bool HasFailedReason
            {
                get
                {
                    // initial value
                    bool hasFailedReason = (!String.IsNullOrEmpty(this.FailedReason));
                    
                    // return value
                    return hasFailedReason;
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

            #region HaveFieldSetsBeenModified
            /// <summary>
            /// This property returns true if the 'SavedCount' is set.
            /// </summary>
            public bool HaveFieldSetsBeenModified
            {
                get
                {
                    // initial value
                    bool hasSavedCount = (this.SavedCount > 0);
                    
                    // return value
                    return hasSavedCount;
                }
            }
            #endregion
            
            #region IsInEditMode
            /// <summary>
            /// This property returns true if this object is currently in AddNew or Edit more.
            /// </summary>
            public bool IsInEditMode
            {
                get
                {
                    // initial value
                    bool isInEditMode = (this.EditMode != EditModeEnum.Unknown);
                    
                    // return value
                    return isInEditMode;
                }
            }
            #endregion
            
            #region HasParentFieldSetEditorForm
            /// <summary>
            /// This property returns true if this object has a 'ParentFieldSetEditorForm'.
            /// </summary>
            public bool HasParentFieldSetEditorForm
            {
                get
                {
                    // initial value
                    bool hasParentFieldSetEditorForm = (this.ParentFieldSetEditorForm != null);
                    
                    // return value
                    return hasParentFieldSetEditorForm;
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
            
            #region OrderByModeReadOnly
            /// <summary>
            /// This property gets or sets the value for 'OrderByModeReadOnly'.
            /// </summary>
            public bool OrderByModeReadOnly
            {
                get { return orderByModeReadOnly; }
                set { orderByModeReadOnly = value; }
            }
            #endregion
            
            #region ParameterMode
            /// <summary>
            /// This property gets or sets the value for 'ParameterMode'.
            /// </summary>
            public bool ParameterMode
            {
                get { return parameterMode; }
                set 
                { 
                    // set the value
                    parameterMode = value;

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region ParameterModeReadOnly
            /// <summary>
            /// This property gets or sets the value for 'ParameterModeReadOnly'.
            /// </summary>
            public bool ParameterModeReadOnly
            {
                get { return parameterModeReadOnly; }
                set { parameterModeReadOnly = value; }
            }
            #endregion

            #region ParentFieldSetEditorForm
            /// <summary>
            /// This read only property returns the value for 'ParentFieldSetEditorForm'.
            /// </summary>
            public FieldSetEditorForm ParentFieldSetEditorForm
            {
                get
                {
                    // initial value
                    FieldSetEditorForm fieldSetEditorForm = this.ParentForm as FieldSetEditorForm;
                    
                    // return value
                    return fieldSetEditorForm;
                }
            }
            #endregion
            
            #region ReaderModeReadOnly
            /// <summary>
            /// This property gets or sets the value for 'ReaderModeReadOnly'.
            /// </summary>
            public bool ReaderModeReadOnly
            {
                get { return readerModeReadOnly; }
                set { readerModeReadOnly = value; }
            }
            #endregion
            
            #region SavedCount
            /// <summary>
            /// This property gets or sets the value for 'SavedCount'.
            /// </summary>
            public int SavedCount
            {
                get { return savedCount; }
                set { savedCount = value; }
            }
            #endregion
            
            #region SelectedFieldSet
            /// <summary>
            /// This property gets or sets the value for 'SelectedFieldSet'.
            /// </summary>
            public FieldSet SelectedFieldSet
            {
                get { return selectedFieldSet; }
                set { selectedFieldSet = value; }
            }
            #endregion
            
            #region SelectedTable
            /// <summary>
            /// This property gets or sets the value for 'SelectedTable'.
            /// </summary>
            public DTNTable SelectedTable
            {
                get { return selectedTable; }
                set { selectedTable = value; }
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
