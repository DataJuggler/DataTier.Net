

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Core.UltimateHelper;

#endregion

namespace DataTierClient.Controls
{

    #region class GridColumnBuilderControl
    /// <summary>
    /// This control is used to build a collection of Grid Columns to paste
    /// into the razor of a DataJuggler.Blazor.Components.Grid
    /// </summary>
    public partial class GridColumnBuilderControl : UserControl
    {
        
        #region Private Variables
        private DTNTable selectedTable;
        private DTNField selectedField;
        private const int DefaultColumnWidth = 48;
        private const int MinColumnWidth = 16;
        private bool loading;
        private const string GridColumn1 = "<GridColumn Parent=\"[Parent]\" Caption=\"[Caption]\" Name=\"[Name]\"";
        private const string GridColumn2 = "    Index=\"[Index]\" ColumnNumber=\"[ColumnNumber]\" Width=\"[Width]\" Height=\"[Height]\"";
        private const string GridColumn2B = "    LastColumn=\"true\"";
        private const string GridColumn3 = "    ClassName=\"[ClassName]\" Format=\"[Format]\" />";
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'GridColumnBuilderControl' object.
        /// </summary>
        public GridColumnBuilderControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region AssignAllButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AssignAllButton' is clicked.
            /// </summary>
            private void AssignAllButton_Click(object sender, EventArgs e)
            {
                // local
                DTNField field = null;

                // if the value for HasSelectedTable is true
                if (HasSelectedTable)
                {  
                    // iterate the objects
                    foreach (object item in AvailableFieldsListBox.Items)
                    {
                        // reset
                        field = null;

                        // if item is a field
                        if (item is DTNField tempField)
                        {
                            // Find this field
                            field = SelectedTable.Fields.FirstOrDefault(x => x.FieldId == tempField.FieldId);

                            // If the field object exists
                            if (NullHelper.Exists(field))
                            {
                                // Set to true
                                field.Assigned = true;
                            }
                        }
                    }
                    
                    // Redisplay the fields
                    DisplaySelectedTable();
                }
            }
            #endregion
            
            #region AssignedFieldsListBox_DrawItem(object sender, DrawItemEventArgs e)
            /// <summary>
            /// event is fired when Assigned Fields List Box _ Draw Item
            /// </summary>
            private void AssignedFieldsListBox_DrawItem(object sender, DrawItemEventArgs e)
            {
                // Only draw if the index is valid
                if (e.Index >= 0)
                {
                    ListBox listBox = (ListBox)sender;
                    DTNField field = (DTNField)listBox.Items[e.Index];

                    bool isSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
                    bool valid = (field.HasGridColumn) && field.GridColumn.Valid;

                    // Draw the background so selection highlights work
                    e.DrawBackground();

                    Color textColor = Color.Black;

                    if (isSelected)
                    {
                        textColor = SystemColors.HighlightText;
                    }
                    else if (!valid)
                    {
                        textColor = SystemColors.GrayText;
                    }

                    using (SolidBrush brush = new SolidBrush(textColor))
                    {
                        e.Graphics.DrawString(field.FieldName, e.Font, brush, e.Bounds);
                    }

                    // Draw the FocusRectangle
                    e.DrawFocusRectangle();
                }
            }
            #endregion
            
            #region AssignedFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when a selection is made in the 'AssignedFieldsListBox_'.
            /// </summary>
            private void AssignedFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if there is a SelectedField
                if (AssignedFieldsListBox.SelectedItem is DTNField tempField)
                {
                    // Set the SelectedField
                    SelectedField = tempField;                    
                }
                else
                {
                    // Set the SelectedField to null;
                    SelectedField = null;
                }

                // set the field
                if (HasSelectedField)
                {
                    // Display the SelectedField
                    DisplaySelectedField();
                }
            }
            #endregion
            
            #region AssignSelectedButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AssignSelectedButton' is clicked.
            /// </summary>
            private void AssignSelectedButton_Click(object sender, EventArgs e)
            {
                // local
                DTNField field = null;

                // if the value for HasSelectedTable is true
                if ((HasSelectedTable) && (AvailableFieldsListBox.SelectedItems.Count > 0))
                {  
                    // iterate the objects
                    foreach (object item in AvailableFieldsListBox.SelectedItems)
                    {
                        // reset
                        field = null;

                        // if item is a field
                        if (item is DTNField tempField)
                        {
                            // Find this field
                            field = SelectedTable.Fields.FirstOrDefault(x => x.FieldId == tempField.FieldId);

                            // If the field object exists
                            if (NullHelper.Exists(field))
                            {
                                // Set to true
                                field.Assigned = true;
                            }
                        }
                    }
                    
                    // Redisplay the fields
                    DisplaySelectedTable();
                }
            }
            #endregion
            
            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region CaptionTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Caption Text Box _ Text Changed
            /// </summary>
            private void CaptionTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.Caption = CaptionTextBox.Text;

                    // Set to true
                    Loading = true;

                    // Redraw
                    AssignedFieldsListBox.Invalidate();

                    // Set to false
                    Loading = false;

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region CreateGridColumnsButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CreateGridColumnsButton' is clicked.
            /// </summary>
            private void CreateGridColumnsButton_Click(object sender, EventArgs e)
            {
                // locals
                StringBuilder sb = new StringBuilder();
                int index = -1;
                string gridColumn = "";
                string gridColumns = "";
                DTNField field = null;  
                
                if (!TextHelper.Exists(ParentTextBox.Text))
                {
                    // Show a message
                    StatusLabel.Text = "Parent Is Required";
                    ParentTextBox.BackColor = Color.Salmon;
                    StatusLabel.Visible = true;
                    StatusTimer.Start();
                }
                else
                {
                    // if there are one or more fields assigned
                    if (AssignedFieldsListBox.Items.Count > 0)
                    {
                        // Create the gridColumns
                        string indent = TextHelper.Indent(4);

                        // Indent 8 spaces
                        sb.Append(indent);

                        // open node
                        sb.Append("<GridColumns>");

                        // Add a new line
                        sb.Append(Environment.NewLine);

                        // iterate the fields
                        foreach (object item in AssignedFieldsListBox.Items)
                        {  
                            // reset
                            field = null;

                            // if item is a field
                            if (item is DTNField tempField)
                            {
                                // Increment the value for index
                                index++;

                                // Find this field
                                field = SelectedTable.Fields.FirstOrDefault(x => x.FieldId == tempField.FieldId);

                                // If the field object exists
                                if (NullHelper.Exists(field))
                                {
                                    // Is this the lastColumn
                                    bool lastColumn = (index == AssignedFieldsListBox.Items.Count - 1);

                                    // Create the gridColumn
                                    gridColumn = CreateGridColumn(field, index, lastColumn);

                                    // Append this column
                                    sb.Append(gridColumn);

                                    // Add a new line
                                    sb.Append(Environment.NewLine);
                                }
                            }
                        }

                        // Indent 8 spaces
                        sb.Append(indent);

                        // open node
                        sb.Append("</GridColumns>");

                        // get the result
                        gridColumns = sb.ToString();

                        // Copy
                        Clipboard.SetText(gridColumns);

                        // Set the text
                        StatusLabel.Text = "Grid Columns Were Copied To The Clipboard.";
                        StatusLabel.Visible = true;
                        StatusTimer.Start();
                    }
                    else
                    {
                        // The button isn't enabled, so this will never fire. Just leaving this for 
                        // in case something went wrong.

                        // Set the text
                        StatusLabel.Text = "You must assign one or more fields.";
                        StatusLabel.Visible = true;
                        StatusTimer.Start();
                    }
                }
            }
            #endregion
            
            #region FontBoldCheckBox_CheckedChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Font Bold Check Box _ Checked Changed
            /// </summary>
            private void FontBoldCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.FontBold = FontBoldCheckBox.Checked;

                    // Set the ClassName
                    ClassNameTextBox.Text = SelectedField.GridColumn.ClassName;
                }    
            }
            #endregion
            
            #region FontNameTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Font Name Text Box _ Text Changed
            /// </summary>
            private void FontNameTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.FontName = FontNameTextBox.Text;

                    // Set the ClassName
                    ClassNameTextBox.Text = SelectedField.GridColumn.ClassName;
                }    
            }
            #endregion
            
            #region FontSizeTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Font Size Text Box _ Text Changed
            /// </summary>
            private void FontSizeTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.FontSize = NumericHelper.ParseInteger(FontSizeTextBox.Text, 0, -1);

                    // Set the ClassName
                    ClassNameTextBox.Text = SelectedField.GridColumn.ClassName;
                }    
            }
            #endregion
            
            #region FormatTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Format Text Box _ Text Changed
            /// </summary>
            private void FormatTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.Format = FormatTextBox.Text;
                }
            }
            #endregion
            
            #region HeightTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Height Text Box _ Text Changed
            /// </summary>
            private void HeightTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.Height = NumericHelper.ParseInteger(HeightTextBox.Text, 0, -1);

                    // Set the ClassName
                    ClassNameTextBox.Text = SelectedField.GridColumn.ClassName;
                }    
            }
            #endregion
            
            #region ParentTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Parent Text Box _ Text Changed
            /// </summary>
            private void ParentTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the length is set
                if (ParentTextBox.Text.Length > 0)
                {
                    // Switch back to white
                    ParentTextBox.BackColor = Color.White;
                }
            }
            #endregion
            
            #region RemoveAllButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RemoveAllButton' is clicked.
            /// </summary>
            private void RemoveAllButton_Click(object sender, EventArgs e)
            {
                // local
                DTNField field = null;

                // if the value for HasSelectedTable is true
                if (HasSelectedTable)
                {  
                    // iterate the objects
                    foreach (object item in AssignedFieldsListBox.Items)
                    {
                        // reset
                        field = null;

                        // if item is a field
                        if (item is DTNField tempField)
                        {
                            // Find this field
                            field = SelectedTable.Fields.FirstOrDefault(x => x.FieldId == tempField.FieldId);

                            // If the field object exists
                            if (NullHelper.Exists(field))
                            {
                                // Set to false
                                field.Assigned = false;
                            }
                        }
                    }
                    
                    // Redisplay the fields
                    DisplaySelectedTable();
                }
            }
            #endregion
            
            #region RemoveSelectedButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RemoveSelectedButton' is clicked.
            /// </summary>
            private void RemoveSelectedButton_Click(object sender, EventArgs e)
            {
                // local
                DTNField field = null;

                // if the value for HasSelectedTable is true
                if ((HasSelectedTable) && (AssignedFieldsListBox.SelectedItems.Count > 0))
                {  
                    // iterate the objects
                    foreach (object item in AssignedFieldsListBox.SelectedItems)
                    {
                        // reset
                        field = null;

                        // if item is a field
                        if (item is DTNField tempField)
                        {
                            // Find this field
                            field = SelectedTable.Fields.FirstOrDefault(x => x.FieldId == tempField.FieldId);

                            // If the field object exists
                            if (NullHelper.Exists(field))
                            {
                                // Set to false
                                field.Assigned = false;
                            }
                        }
                    }
                    
                    // Redisplay the fields
                    DisplaySelectedTable();
                }
            }
            #endregion
            
            #region StatusTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Status Timer _ Tick
            /// </summary>
            private void StatusTimer_Tick(object sender, EventArgs e)
            {
                // Stop the timer from firing again
                StatusTimer.Stop();

                // hide
                StatusLabel.Visible = false;
            }
            #endregion
            
            #region WidthTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Width Text Box _ Text Changed
            /// </summary>
            private void WidthTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the value for HasSelectedField is true
                if ((HasSelectedField) && (SelectedField.HasGridColumn))
                {
                    // Set the value
                    SelectedField.GridColumn.Width = NumericHelper.ParseInteger(WidthTextBox.Text, DefaultColumnWidth, DefaultColumnWidth);

                    // Set to true
                    Loading = true;

                    // Redraw
                    AssignedFieldsListBox.Invalidate();

                    // Set to false
                    Loading = false;

                    // Update the ClassName TextBox
                    ClassNameTextBox.Text = SelectedField.GridColumn.ClassName;

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
        #endregion

        #region Methods
            
            #region CreateGridColumn(DTNField field, int index, bool lastColumn)
            /// <summary>
            /// returns the Grid Column
            /// </summary>
            public string CreateGridColumn(DTNField field, int index, bool lastColumn)
            {
                // initial value
                string gridColumn = "";

                // locals
                string gridColumn1 = GridColumn1;
                string gridColumn2 = GridColumn2;
                string gridColumn3 = GridColumn3;

                /*
                GridColumn1
                [Parent]
                [Caption]
                [Name]

                GridColumn2
                [Index]
                [ColumnNumber]
                [Width]
                [Height]

                GridColumn2B
                (no tags)

                GridColumn3
                [ClassName]
                [Format]
            */


                // now collect all the values from this form
                string parent = ParentTextBox.Text;
                string caption = field.GridColumn.Caption;
                string name = field.FieldName;
                int columnNumber = index + 1;
                string width = field.GridColumn.Width.ToString();
                string height = field.GridColumn.Height.ToString();
                string className = field.GridColumn.ClassName;
                string format = field.GridColumn.Format;

                // now do the replacements for GridColumn1
                gridColumn1 = gridColumn1.Replace("[Parent]", parent);
                gridColumn1 = gridColumn1.Replace("[Caption]", caption);
                gridColumn1 = gridColumn1.Replace("[Name]", name);

                // now do the replacements for GridColumn2
                gridColumn2 = gridColumn2.Replace("[Index]", index.ToString());
                gridColumn2 = gridColumn2.Replace("[ColumnNumber]", columnNumber.ToString());
                gridColumn2 = gridColumn2.Replace("[Width]", width);
                gridColumn2 = gridColumn2.Replace("[Height]", height);

                // now do the replacements for GridColumn3
                gridColumn3 = gridColumn3.Replace("[ClassName]", className);
                gridColumn3 = gridColumn3.Replace("[Format]", format);

                // Get the indent
                string indent = TextHelper.Indent(8);

                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder();

                // Indent
                sb.Append(indent);

                // Now add the gridColumn1
                sb.Append(gridColumn1);

                // Return value
                sb.Append(Environment.NewLine);

                // Indent
                sb.Append(indent);

                // Now add the gridColumn2
                sb.Append(gridColumn2);

                // Return value
                sb.Append(Environment.NewLine);

                // if this is hte last column
                if (lastColumn)
                {
                    // Indent
                    sb.Append(indent);  

                    // Now add the gridColumn2
                    sb.Append(GridColumn2B);

                    // Return value
                    sb.Append(Environment.NewLine);
                }

                // Indent
                sb.Append(indent);

                // Now add the gridColumn3
                sb.Append(gridColumn3);

                // set the return value
                gridColumn = sb.ToString();
                
                // return value
                return gridColumn;
            }
            #endregion
            
            #region DisplayAssignedFields()
            /// <summary>
            /// Display Assigned Fields
            /// </summary>
            public void DisplayAssignedFields()
            {
                // Clear all items
                AvailableFieldsListBox.Items.Clear();

                // If the HasSelectedTable is true and the SelectedTable has fields
                if ((HasSelectedTable) && (SelectedTable.HasFields))
                {
                    // Iterate the collection of DTNField objects
                    foreach (DTNField field in SelectedTable.Fields)
                    {
                        // if Not assigned
                        if (!field.Assigned)
                        {
                            // Add this item
                            AvailableFieldsListBox.Items.Add(field);
                        }
                    }
                }
            }
            #endregion
            
            #region DisplayAvailableFields()
            /// <summary>
            /// Display Available Fields
            /// </summary>
            public void DisplayAvailableFields()
            {
                // Clear all items
                AssignedFieldsListBox.Items.Clear();

                // If the HasSelectedTable is true and the SelectedTable has fields
                if ((HasSelectedTable) && (SelectedTable.HasFields))
                {
                    // Iterate the collection of DTNField objects
                    foreach (DTNField field in SelectedTable.Fields)
                    {
                        // if assigned
                        if (field.Assigned)
                        {
                            // Add this item
                            AssignedFieldsListBox.Items.Add(field);
                        }
                    }
                }
            }
            #endregion
            
            #region DisplaySelectedField()
            /// <summary>
            /// Display Selected Field
            /// </summary>
            public void DisplaySelectedField()
            {
                // do not call this if we are loading
                if (!Loading)
                {
                    // declare the values
                    string caption = "";
                    string dataType = "";
                    int width = 0;
                    int height = 0;
                    string format = "";
                    string className = "";
                    bool fontBold = false;
                    string fieldName = "";

                    // if the value for HasSelectedField is true
                    if (HasSelectedField)
                    {
                        // if the Caption hasn't been set
                        if (!SelectedField.GridColumn.Initialized)
                        {
                            // capture hte values from this form
                            string fontName = FontNameTextBox.Text;
                            int fontSize = NumericHelper.ParseInteger(FontSizeTextBox.Text, 0, -1);
                            height = NumericHelper.ParseInteger(HeightTextBox.Text, 0, -1);
                            width = DefaultColumnWidth;

                            // Initialize the object
                            SelectedField.GridColumn.Initialize(SelectedField, fontName, fontSize, height, width);
                        }

                        // set the values
                        SelectedField.GridColumn.Parent = ParentTextBox.Text;
                        fieldName = SelectedField.GridColumn.FieldName;
                        caption = SelectedField.GridColumn.Caption;                        
                        dataType = SelectedField.GridColumn.DataType;
                        height = SelectedField.GridColumn.Height;
                        width = SelectedField.GridColumn.Width;
                        format = SelectedField.GridColumn.Format;
                        className = SelectedField.GridColumn.ClassName;
                        fontBold = SelectedField.GridColumn.FontBold;
                    }

                    // display the values
                    SelectedFieldTextBox.Text = fieldName;
                    CaptionTextBox.Text = caption;
                    DataTypeTextBox.Text = dataType;
                    WidthTextBox.Text = width.ToString();
                    FormatTextBox.Text = format;
                    ClassNameTextBox.Text = className;
                    FontBoldCheckBox.Checked = fontBold;
                }
            }
            #endregion
            
            #region DisplaySelectedTable()
            /// <summary>
            /// Display Selected Table
            /// </summary>
            public void DisplaySelectedTable()
            {
                // if the value for HasSelectedTable is true
                if (HasSelectedTable)
                {
                    // Display the Name
                    SelectedTableTextBox.Text = SelectedTable.TableName;

                    // Display the fields that aren't assigned
                    DisplayAvailableFields();

                    // Display the fields that are assigned
                    DisplayAssignedFields();
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Set the Text
                FontNameTextBox.Text = ConfigurationHelper.ReadAppSetting("FontName");
                FontSizeTextBox.Text = ConfigurationHelper.ReadAppSetting("FontSize");
                HeightTextBox.Text = ConfigurationHelper.ReadAppSetting("GridHeight");

                // Setup the custom draw mode
                AssignedFieldsListBox.DrawMode = DrawMode.OwnerDrawFixed;
                AssignedFieldsListBox.DrawItem += AssignedFieldsListBox_DrawItem;

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// UI Enable
            /// </summary>
            public void UIEnable()
            {
                // local
                bool enabled = false;

                // if the SelectedTable exists
                if ((HasSelectedTable) && (ListHelper.HasOneOrMoreItems(SelectedTable.Fields)))
                {
                    // reset to true
                    enabled = true;

                    // Iterate the collection of DTNField objects
                    foreach (DTNField field in SelectedTable.Fields)
                    {
                        // only factor in assigned fields
                        if (field.Assigned)
                        {
                            if ((!field.HasGridColumn) || (!field.GridColumn.Valid))
                            {
                                // not valid
                                enabled = false;

                                // break out of loop
                                break;
                            }
                        }
                    }
                }

                // Enable or Disable the button
                CreateGridColumnsButton.Enabled = enabled;
            }
            #endregion
            
        #endregion

        #region Properties

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
            
            #region SelectedField
            /// <summary>
            /// This property gets or sets the value for 'SelectedField'.
            /// </summary>
            public DTNField SelectedField
            {
                get { return selectedField; }
                set { selectedField = value; }
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
                    // Set the value
                    selectedTable = value;

                    // Display the selected table
                    DisplaySelectedTable();
                }
            }
        #endregion

        #endregion
    }
    #endregion

}
