

#region using statements

using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Win.Controls.Objects;
using DataJuggler.Win.Controls.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class LabelComboBoxControl : UserControl, IFieldValueControl
    /// <summary>
    /// This control is used to display a Label and a ComboBox for selecting
    /// </summary>
    public partial class LabelComboBoxControl : UserControl, IFieldValueControl
    {

        #region Private Variables
        private int labelWidth;
        private string labelText;
        private string comboBoxText;
        private bool editable;
        private ContentAlignment labelTextAlign;
        private ISelectedIndexListener selectedIndexListener;
        private string source;
        private List<object> list;
        private bool sorted;
        private Font labelFont;
        private Font comboBoxFont;
        private int selectedIndex;
        private int labelTopMargin;
        private int labelBottomMargin;
        private int comboBoxLeftMargin;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LabelComboBoxControl' object.
        /// </summary>
        public LabelComboBoxControl()
        {
            // Create controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events

            #region ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
            /// <summary>
            /// The SelectedIndex has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                // if the SelectedIndexListener exists
                if (this.SelectedIndexListener != null)
                {
                    // notify the listener
                    this.SelectedIndexListener.OnSelectedIndexChanged(this, this.ComboBox.SelectedIndex, this.ComboBox.SelectedItem);
                }
            } 
            #endregion
            
        #endregion

        #region Methods

            #region Activate()
            /// <summary>
            /// Set focus to the text bo
            /// </summary>
            internal void Activate()
            {
                
            } 
            #endregion

            #region Clear()
            /// <summary>
            /// Clear the items in this control
            /// </summary>
            public void Clear()
            {
                // erase the selected index
                this.ComboBox.Items.Clear();
                this.ComboBox.SelectedIndex = -1;
            }
            #endregion

            #region DisplayList()
            /// <summary>
            /// Display the list
            /// </summary>
            public void DisplayList()
            {
                // clear the combo box
                this.ComboBox.Items.Clear();
                
                // if the list exists
                if (this.List != null)
                {
                    // load the lists
                    foreach (object item in this.List)
                    {
                        // add the list
                        this.ComboBox.Items.Add(item);
                    }
                }                
            } 
            #endregion

            #region FindItemIndexByValue(string itemValue, bool allowPartialMatch = false)
            /// <summary>
            /// This method finds an item by the ID value.
            /// </summary>
            public int FindItemIndexByValue(string itemValue, bool allowPartialMatch = false)
            {
                // initial value
                int index = -1;

                // locals
                string listItemValue = "";
                string itemSearchValue = "";
                
                // verify we have an itemValue
                if ((!String.IsNullOrEmpty(itemValue)) && (this.ComboBox.Items.Count > 0))
                {
                    // get a lowercase value and replace out any underscores
                    itemSearchValue = itemValue.ToLower().Replace("_", " ");

                    // if there are one or more items
                    if (ListHelper.HasOneOrMoreItems(this.ComboBox.Items))
                    {   
                        // iterate the items 
                        for (int x = 0; x < this.ComboBox.Items.Count; x++)
                        {
                            // get the item at the specified index
                            object item = this.ComboBox.Items[x];

                            // if the item exists
                            if ((item != null) && (!String.IsNullOrEmpty(item.ToString())))
                            {
                                // get the displayName
                                string displayName = item.ToString().ToLower().Replace("_", " ");

                                // if this is the item being sought
                                if (displayName == itemSearchValue)
                                {
                                    // set the selected index value
                                    index = x;

                                    // break out of loop
                                    break;
                                }

                                // if a partial match is ok
                                if (allowPartialMatch)
                                {
                                    // if this is the item being sought
                                    if (listItemValue.Contains(itemSearchValue))
                                    {
                                        // set the selected index value
                                        index = x;

                                        // break out of loop
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                // return value
                return index;
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            private void Init()
            {
                // default to sorted
                this.Sorted = true;
                
                // set the default label width
                this.LabelWidth = 80;
                
                // default to editable
                this.Editable = true;
                
                // set the default TextAlign
                this.LabelTextAlign = ContentAlignment.MiddleRight;

                // set to 1
                this.ComboBoxLeftMargin = 1;
            }
            #endregion

            #region LoadItems(Type enumType)
            /// <summary>
            /// This method loads a combobox with the enum values
            /// </summary>
            public void LoadItems(Type enumType)
            {
                // locals
                string[] names = null;
                Array values = null;
                string itemValue = "";
                int index = -1;
                string formattedName = "";

                // clear the list
                this.ComboBox.Items.Clear();

                // verifyh the object is an emum
                if (enumType.IsEnum)
                {
                    // get the names from the enum
                    names = Enum.GetNames(enumType);
                    values = Enum.GetValues(enumType);

                    // if there are one or more names
                    if ((names != null) && (names.Length > 0) && (values != null) && (values.Length == names.Length))
                    {
                        // iterate the names
                        foreach (string name in names)
                        {
                            // increment index
                            index++;

                            // set the itemValue
                            itemValue = values.GetValue(index).ToString();

                            // replace out any underscores with spaces
                            formattedName = name.Replace("_", " ");

                            // add this item
                            this.ComboBox.Items.Add(formattedName);
                        }
                    }
                }
            }
            #endregion

            #region LoadItems<T>(List<T> items, bool addEmptyRowAtTop = false)
            /// <summary>
            /// This method loads a list of any type 
            /// </summary>
            public void LoadItems<T>(List<T> items, bool addEmptyRowAtTop = false)
            {
                // clear the list
                this.ComboBox.Items.Clear();

                // if the list exists
                if ((items != null) && (items.Count > 0))
                {
                    // if addEmptyRowAtTop is true
                    if (addEmptyRowAtTop)
                    {
                        // add this item
                        this.ComboBox.Items.Add("");
                    }

                    // iterate the list
                    foreach (object item in items)
                    {
                        // if the item exists
                        if (item != null)
                        {
                            // set the value
                            IPrimaryKey primaryKey = item as IPrimaryKey;

                            // if the object is a PrimaryKey object
                            if (primaryKey != null)
                            {
                                // create a list item
                                Item listItem = new Item(item.ToString(), primaryKey.PrimaryKeyValue.ToString());

                                // add this item
                                this.ComboBox.Items.Add(listItem);
                            }
                            else
                            {
                                // add this item
                                this.ComboBox.Items.Add(item.ToString());
                            }
                        }
                    }
                }
            }
            #endregion

            #region SelectItemByValue(string itemValue)
            /// <summary>
            /// This method searches all of the items in the ComboBox
            /// and if the value matches that item is selected
            /// </summary>
            internal void SelectItemByValue(string itemValue)
            {
                // local
                int indexToSelect = -1;

                // if the combo box has one or more items
                if (this.ComboBox.Items.Count > 0)
                {
                    // find the index of the item to select
                    indexToSelect = FindItemIndexByValue(itemValue);

                    // set the SelectedIndex
                    this.ComboBox.SelectedIndex = indexToSelect;
                }
            }
            #endregion

            #region LoadItems(List<Item> items)
            /// <summary>
            /// This method loads the combobox with the list of items
            /// </summary>
            public void LoadItems(List<Item> items)
            {
                // clear the the combobox
                this.ComboBox.Items.Clear();

                // if the items collection
                if (ListHelper.HasOneOrMoreItems(items))
                {
                    // iterate the items
                    foreach (Item item in items)
                    {
                        // add this item
                        this.ComboBox.Items.Add(item);
                    }
                }
            }
            #endregion

            #region SetFocusToComboBox()
            /// <summary>
            /// This method sets focus to the ComboBox
            /// </summary>
            public void SetFocusToComboBox()
            {
                // Set Focus to the ComboBox
                this.ComboBox.Focus();
            }
            #endregion
            
            #region Setup(string labelText, int selectedIndex)
            /// <summary>
            /// This method prepares this control to be shown.
            /// </summary>
            /// <param name="labelText"></param>
            /// <param name="textBoxText"></param>
            public void Setup(string labelText, int selectedIndex)
            {
                // set the properties
                this.LabelText = labelText;
                this.ComboBox.SelectedIndex = selectedIndex;
            } 
            #endregion

            #region UIControl()
            /// <summary>
            /// This method determines if the Textbox is enabled or not based upon the value
            /// of Editable and Updateable.
            /// </summary>
            private void UIEnable()
            {
                // enabled or not
                bool enabled = this.Editable;
                
                // enable the text box if enabled
                this.ComboBox.Enabled = enabled;
            }  
            #endregion

        #endregion

        #region Properties

            #region ComboBoxControl
            /// <summary>
            /// This property returns the ComboBox
            /// </summary>
            public ComboBox ComboBoxControl
            {
                get
                {
                    // return the ComboBox
                    return this.ComboBox;
                }
            }
            #endregion

            #region ComboBoxLeftMargin
            /// <summary>
            /// This property gets or sets the value for 'ComboBoxLeftMargin'.
            /// </summary>
            public int ComboBoxLeftMargin
            {
                get { return comboBoxLeftMargin; }
                set 
                { 
                    // set the value
                    comboBoxLeftMargin = value;

                    // set the width
                    this.ComboBoxLeftMarginPanel.Width = value;
                }
            }
            #endregion
            
            #region ComoboBoxFont
            /// <summary>
            /// This property gets or sets the value for 'ComoboBoxFont'.
            /// </summary>
            public Font ComoboBoxFont
            {
                get { return comboBoxFont; }
                set
                {
                    // set the value
                    comboBoxFont = value;

                    // if the font exists
                    if (this.HasComboBoxFont)
                    {
                        // Set the Font for the combo box
                        this.ComboBox.Font = comboBoxFont;
                    }
                }
            }
            #endregion
            
            #region ComboBoxText
            /// <summary>
            /// The Text for the ComboBox
            /// </summary>
            public string ComboBoxText
            {
                get
                {
                    // if the ComboBox exists
                    if (this.ComboBox != null)
                    {
                        // set the value
                        this.comboBoxText = this.ComboBox.Text;
                    }

                    // return value
                    return comboBoxText;
                }
                set
                {
                    // set the value
                    comboBoxText = value;

                    // if the ComboBox exists
                    if (this.ComboBox != null)
                    {
                        /// set the ComboBox text
                        this.ComboBox.Text = value;
                    }
                }
            }
            #endregion

            #region Editable
            /// <summary>
            /// When this is true the LabelTextBox is enabled.
            /// </summary>
            public bool Editable
            {
                get { return editable; }
                set 
                { 
                    // set the value
                    editable = value;
                    
                    // enable controls based upon this value
                    UIEnable(); 
                }
            } 
            #endregion

            #region FieldLabel
            /// <summary>
            /// This property returns the label from this control.
            /// </summary>
            public Label FieldLabel
            {
                get
                {
                    // return the Label from this control.
                    return this.Label;
                }
            }
            #endregion

            #region HasComboBoxControl
            /// <summary>
            /// This property returns true if this object has a 'ComboBoxControl'.
            /// </summary>
            public bool HasComboBoxControl
            {
                get
                {
                    // initial value
                    bool hasComboBoxControl = (this.ComboBoxControl != null);
                    
                    // return value
                    return hasComboBoxControl;
                }
            }
            #endregion
            
            #region HasComboBoxFont
            /// <summary>
            /// This property returns true if this object has a 'ComoboBoxFont'.
            /// </summary>
            public bool HasComboBoxFont
            {
                get
                {
                    // initial value
                    bool hasComoboBoxFont = (this.ComoboBoxFont != null);
                    
                    // return value
                    return hasComoboBoxFont;
                }
            }
            #endregion
            
            #region HasItems
            /// <summary>
            /// This property returns true if this object has an 'Items'.
            /// </summary>
            public bool HasItems
            {
                get
                {
                    // initial value
                    bool hasItems = (this.Items != null);
                    
                    // return value
                    return hasItems;
                }
            }
            #endregion
            
            #region HasLabelFont
            /// <summary>
            /// This property returns true if this object has a 'LabelFont'.
            /// </summary>
            public bool HasLabelFont
            {
                get
                {
                    // initial value
                    bool hasLabelFont = (this.LabelFont != null);
                    
                    // return value
                    return hasLabelFont;
                }
            }
            #endregion
         
            #region HasSelectedObject
            /// <summary>
            /// This property returns true if this object has a 'SelectedObject'.
            /// </summary>
            public bool HasSelectedObject
            {
                get
                {
                    // initial value
                    bool hasSelectedObject = (this.SelectedObject != null);
                    
                    // return value
                    return hasSelectedObject;
                }
            }
            #endregion
            
            #region Items
            /// <summary>
            /// This property gets or sets the value for 'Items'.
            /// </summary>
            public ComboBox.ObjectCollection Items
            {
                get
                {
                    // return the items
                    return this.ComboBox.Items;
                }
            }
            #endregion
            
            #region LabelBottomMargin
            /// <summary>
            /// This property gets or sets the value for 'LabelBottomMargin'.
            /// </summary>
            public int LabelBottomMargin
            {
                get { return labelBottomMargin; }
                set
                { 
                    //  set the value
                    labelBottomMargin = value;

                    // set the bottom margin value
                    this.LabelBottomMarginPanel.Height = value;
                }
            }
            #endregion

            #region LabelColor
            /// <summary>
            /// This property gets or sets the value for 'LabelColor'.
            /// </summary>
            public Color LabelColor
            {
                get
                {
                    // initial value
                    Color color = Color.Black;

                    // if the control exists
                    if (Label != null)
                    {
                        // set the return value
                        color = (Color)Label.ForeColor;
                    }

                    // return value
                    return color;
                }
                set
                {
                    // if the control exists
                    if (Label != null)
                    {
                        // set the value
                        Label.ForeColor = value;
                    }
                }
            }
            #endregion
            
            #region LabelFont
            /// <summary>
            /// This property gets or sets the value for 'LabelFont'.
            /// </summary>
            public Font LabelFont
            {
                get { return labelFont; }
                set
                {
                    // set the value
                    labelFont = value;

                    // if the LabelFont exists
                    if (this.HasLabelFont)
                    {
                        // set the font for the label
                        this.Label.Font = labelFont;
                    }
                }
            }
            #endregion
            
            #region LabelText
            /// <summary>
            /// This property gets or sets the LabelText.
            /// </summary>
            public string LabelText
            {
                get { return labelText; }
                set 
                { 
                    // set the value
                    labelText = value; 
                    
                    // if the Label exists
                    if (this.Label != null)
                    {
                        // set the Label text
                        this.Label.Text = value;
                    }
                }
            } 
            #endregion

            #region LabelTextAlign
            /// <summary>
            /// Set the TextAlign for the label.
            /// </summary>
            public ContentAlignment LabelTextAlign
            {
                get { return labelTextAlign; }
                set 
                {   
                    // set the value
                    labelTextAlign = value; 
                    
                    if (this.Label != null)
                    {
                        // set the value
                        this.Label.TextAlign = value;
                    }
                }
            } 
            #endregion

            #region LabelTopMargin
            /// <summary>
            /// This property gets or sets the value for 'LabelTopMargin'.
            /// </summary>
            public int LabelTopMargin
            {
                get { return labelTopMargin; }
                set 
                { 
                    // set the labelTopMargin
                    labelTopMargin = value;

                    // set the value
                    this.LabelTopMarginPanel.Height = value;
                }
            }
            #endregion
            
            #region LabelWidth
            /// <summary>
            /// The LabelWidth
            /// </summary>
            public int LabelWidth
            {
                get { return labelWidth; }
                set
                {
                    // set the label width
                    labelWidth = value;

                    // if the LeftPanel exists
                    if (this.LeftPanel != null)
                    {
                        // set the label width
                        this.LeftPanel.Width = value;
                    }
                }
            }
            #endregion

            #region List
            /// <summary>
            /// This property gets or sets the value for 'List'.
            /// </summary>
            public List<object> List
            {
                get { return list; }
                set { list = value; }
            }
            #endregion
          
            #region SelectedIndex
            /// <summary>
            /// This property gets or sets the value for 'SelectedIndex'.
            /// </summary>
            public int SelectedIndex
            {
                get 
                {
                    // if the ComboBox exists
                    if (this.HasComboBoxControl)
                    {
                        // set the value
                        selectedIndex = this.ComboBox.SelectedIndex;
                    }

                    // return value
                    return selectedIndex;
                }
                set
                {
                    // set the value
                    selectedIndex = value;

                    // if the ComboBox exists
                    if (this.HasComboBoxControl)
                    {
                        // set the value
                        this.ComboBox.SelectedIndex = value;
                    }
                }
            }
            #endregion
            
            #region SelectedIndexListener
            /// <summary>
            /// The listener for the ComboBox SelectedIndex changed event.
            /// </summary>
            public ISelectedIndexListener SelectedIndexListener
            {
                get { return selectedIndexListener; }
                set { selectedIndexListener = value; }
            } 
            #endregion

            #region SelectedObject
            /// <summary>
            /// The SElectedObject from the ComboBox
            /// </summary>
            public object SelectedObject
            {
                get
                {
                    // initial value
                    object selectedObject = null;
                    
                    // if the ComboBox exists
                    if (this.ComboBox != null)
                    {
                        // set the return value
                        selectedObject = this.ComboBox.SelectedItem;
                    }

                    // return value
                    return selectedObject;
                }
            } 
            #endregion

            #region Sorted
            /// <summary>
            /// Should the combo box be sorted.
            /// </summary>
            public bool Sorted
            {
                get { return sorted; }
                set 
                { 
                    // set the value
                    sorted = value; 
                    
                    // if the ComboBox exists
                    if (this.ComboBox != null)
                    {
                        // set the value
                        this.ComboBox.Sorted = value;
                    }
                }
            } 
            #endregion

            #region Source
            /// <summary>
            /// The StoredProcedure that loads this object.
            /// </summary>
            public string Source
            {
                get { return source; }
                set { source = value; }
            } 
            #endregion

        #endregion
        
    } 
    #endregion

}
