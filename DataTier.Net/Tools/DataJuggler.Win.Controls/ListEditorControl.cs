

#region using statements

using DataJuggler.Win.Controls.Enumerations;
using System.Collections.Generic;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class ListEditorControl
    /// <summary>
    /// This control is used to make it easy to edit lists of objects.
    /// </summary>
    public partial class ListEditorControl : UserControl, ISaveCancelHost
    {
        
        #region Private Variables
        private List<object> list;
        private IListEditorHost parentListEditorHost;
        private bool sorted;
        private SaveCancelControl saveControl;
        private bool showSelectedControlPanel;
        private int listEditorWidth;
        private int widthFullControl;
        private int topMargin;
        private int bottomMargin;
        private bool showBackgroundImage;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ListEditorControl' object.
        /// </summary>
        public ListEditorControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events()
        
            #region AddButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'AddButton' is clicked.
            /// </summary>
            private void AddButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentListEditorHost is true
                if (HasParentListEditorHost)
                {
                    // Add a new item
                    ParentListEditorHost.Add();
                }
            }
            #endregion
            
            #region Button_EnableChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enable Changed
            /// </summary>
            private void Button_EnableChanged(object sender, EventArgs e)
            {
                // cast the sender as a button
                Button button = sender as Button;

                // if the cast was successful
                if (NullHelper.Exists(button))
                {
                    // If the value for the property button.Enabled is true
                    if (button.Enabled)
                    {       
                        // Use the enabled image
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth640;
                        button.ForeColor = Color.Black;
                    }
                    else
                    {
                        button.BackgroundImage = Properties.Resources.WoodButtonWidth640Disabled;
                        button.ForeColor = Color.DimGray;
                    }
                }

                // update the UI
                Refresh();
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
            
            #region DeleteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DeleteButton' is clicked.
            /// </summary>
            private void DeleteButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentListEditorHost is true
                if (HasParentListEditorHost)
                {
                    // Delete the selected item 
                    ParentListEditorHost.Delete();
                }

                // Enable controls
                UIEnable();
            }
            #endregion
            
            #region EditButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'EditButton' is clicked.
            /// </summary>
            private void EditButton_Click(object sender, EventArgs e)
            {
                // if the value for HasParentListEditorHost is true
                if (HasParentListEditorHost)
                {
                    // Edit the selected item
                    ParentListEditorHost.Edit();
                }
            }
            #endregion
            
            #region ListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when a selection is made in the 'ListBox_'.
            /// </summary>
            private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
            {  
                // if the SelectedItem exists
                if (ListBox.SelectedItem != null)
                {
                    // get the text of the SelectedItem from the listbox
                    string itemName = ListBox.SelectedItem.ToString();

                    // Get the SelectedItem
                    object selectedItem = FindSelectedItem(itemName);

                    // if the value for HasParentListEditorHost is true
                    if ((HasParentListEditorHost) && (NullHelper.Exists(selectedItem)))
                    {
                        // An item was selected in the list
                        ParentListEditorHost.ItemSelected(selectedItem);
                    }

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region AddEditControl(UserControl control)
            /// <summary>
            /// This method Add Edit Control
            /// </summary>
            public void AddEditControl(UserControl control)
            { 
                // Set the Dock to the top
                control.Dock = DockStyle.Top;
             
                // If the control object exists
                if (NullHelper.Exists(control))
                {
                    // add this control
                    EditControlPanel.Controls.Add(control);
                }

                // Create the SaveControl
                SaveControl = new SaveCancelControl();

                // Add this control
                SavePanel.Controls.Add(SaveControl);
            }
            #endregion
            
            #region Clear()
            /// <summary>
            /// This method Clear
            /// </summary>
            public void Clear()
            {
                // remove all items
                ListBox.Items.Clear();

                // clear everything
                List = null;

                // if the ListEditorHost exists
                if (HasParentListEditorHost)
                {
                    // Clear the control
                    ParentListEditorHost.Clear();  
                }
            }
            #endregion
            
            #region DisplayList()
            /// <summary>
            /// This method Display List
            /// </summary>
            public void DisplayList()
            {
                // If the List collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(List))
                {
                    // Iterate the collection of object objects
                    foreach (object item in List)
                    {
                        // add this item
                        ListBox.Items.Add(item);
                    }
                }
            }
            #endregion
            
            #region FindItemIndex(object item)
            /// <summary>
            /// This method returns the Item Index
            /// </summary>
            public int FindItemIndex(object item)
            {
                // initial value
                int itemIndex = -1;

                // local
                int tempIndex = -1;

                // if the item exists
                if (NullHelper.Exists(item))
                {
                    // iterate the items in the list
                    foreach (object listItem in ListBox.Items)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if the two items are equal
                        if (TextHelper.IsEqual(listItem.ToString(), item.ToString()))
                        {
                            // set the return value
                            itemIndex = tempIndex;

                            // exit this foreach loop
                            break;
                        }
                    }
                }
                
                // return value
                return itemIndex;
            }
            #endregion
            
            #region FindSelectedItem(string itemName)
            /// <summary>
            /// This method returns the Selected Item
            /// </summary>
            public object FindSelectedItem(string itemName)
            {
                // initial value
                object selectedItem = null;

                // if the list exists
                if ((HasList) && (TextHelper.Exists(itemName)))
                {
                    // Iterate the collection of object objects
                    foreach (object item in List)
                    {
                        // if the Text matches
                        if (TextHelper.IsEqual(item.ToString(), itemName))
                        {
                            // set the item
                            selectedItem = item;
                            
                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return selectedItem;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to fill
                this.Dock = DockStyle.Fill;

                // Default to sorted
                Sorted = true;

                // default to not show it
                ShowSelectedControlPanel = false;

                // Default Widths
                ListEditorWidth = 320;
                WidthFullControl = 720;

                // Set the value so the Background (again) so whatever is stored in InitializeComponent isn't permanent
                this.ShowBackgroundImage = this.ShowBackgroundImage;

                // Enable or disable controls based upon if there is a SelectedItem or not
                UIEnable();
            }
            #endregion
           
            #region LoadAndDisplayList(object itemToSelect = null)
            /// <summary>
            /// This method Load And Display List
            /// </summary>
            public void LoadAndDisplayList(object itemToSelect = null)
            {
                // get the name of this item
                string name = "";
                
                // if the itemToSelect exists
                if (NullHelper.Exists(itemToSelect))
                {
                    // set the name
                    name = itemToSelect.ToString();
                }

                // Clear
                Clear();

                // local
                int index = -1;

                // if the ParentListEditorHost exists
                if (HasParentListEditorHost)
                {
                    // load the list of items
                    List = ParentListEditorHost.LoadList();
                    
                    // Display the List
                    DisplayList();
                }

                // If the name string exists
                if (TextHelper.Exists(name))
                {
                    // find the index
                    index = FindItemIndex(name);

                    // Set the SelectedIndex
                    ListBox.SelectedIndex = index;

                    // if the SelectedIndex was found
                    if (ListBox.SelectedIndex >= 0)
                    {
                        // Set Focus to the ListBox so the selected item highlights (trying)
                        ListBox.Focus();
                    }
                }
            }
            #endregion
            
            #region OnCancel()
            /// <summary>
            /// method On Cancel
            /// </summary>
            public void OnCancel()
            {
                // local
                bool clearRequired = (EditMode == EditModeEnum.Add);

                // if the value for HasParentListEditorHost is true
                if (HasParentListEditorHost)
                {
                    // Cancel the current edit
                    ParentListEditorHost.Cancel();

                    // if the value for clearRequired is true
                    if (clearRequired)
                    {
                        // Set to -1
                        ListBox.SelectedIndex = -1;
                    }

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region OnSave(bool close)
            /// <summary>
            /// method returns the Save
            /// </summary>
            public bool OnSave(bool close)
            {
                // initial value
                bool saved = false;

                // if the value for HasParentListEditorHost is true
                if (HasParentListEditorHost)
                {
                    // Save the current edit
                    saved = ParentListEditorHost.Save();

                    // if saved
                    if (saved)
                    {
                        // Load and display the list
                        LoadAndDisplayList(SelectedItem);
                    }
                }

                // Enable or disable controls
                UIEnable();

                // return value
                return saved;
            }
            #endregion
            
            #region SetAllItemsLabelText(string labelText)
            /// <summary>
            /// This method Set All Items Label Text
            /// </summary>
            public void SetAllItemsLabelText(string labelText)
            {
                // set the text of the label
                AllItemsLabel.Text = labelText;
            }
            #endregion
            
            #region SetSelectedItemLabelText(string labelText)
            /// <summary>
            /// This method Set Selected Item Label Text
            /// </summary>
            public void SetSelectedItemLabelText(string labelText)
            {
                // Set the Text
                this.SelectedItemLabel.Text = labelText;
            }
            #endregion
            
            #region Start(UserControl userControl, IListEditorHost parentHost)
            /// <summary>
            /// This method is used to start this application.
            /// This method calls Load from the parent host
            /// </summary>
            public void Start(UserControl userControl, IListEditorHost parentHost)
            {
                // store the arg
                ParentListEditorHost = parentHost;

                // add the userControl to the PanelExtender
                AddEditControl(userControl);

                // Load and display the list
                LoadAndDisplayList();
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method returns the Enable
            /// </summary>
            public void UIEnable()
            {
                // Enable or Disable the buttons basedupon if there is a SelectedItem or not
                EditButton.Enabled = HasSelectedItem;
                DeleteButton.Enabled = HasSelectedItem;

                // If both the property ShowSelectedControlPanel and HasSelectedItem are true
                SelectedControlPanel.Visible = ((ShowSelectedControlPanel) && (HasSelectedItem));

                // if the SelectedControlPanel is not visible
                if (!SelectedControlPanel.Visible)
                {
                    // Set the Width
                    this.Width = ListEditorWidth;
                }
                else
                {
                    this.Width = WidthFullControl;
                }

                if (ShowSelectedControlPanel)
                {
                    // If we have a SelectedItem, show the SelectedControlPanel
                    SelectedControlPanel.Visible = HasSelectedItem;
                }
                else
                {
                    SelectedControlPanel.Visible = false;
                }

                // if the SaveControl exists
                if (HasSaveControl)
                {
                    // Show the SaveControl if the SelectedItem exists and we are editing
                    SaveControl.Visible = ((HasSelectedItem) && (IsEditing));
                }

                // if the SelectedItem exists
                if (HasSelectedItem)
                {
                    // If we are currently editing, the controls are disabled
                    AddButton.Enabled = !IsEditing;
                    EditButton.Enabled = !IsEditing;
                    DeleteButton.Enabled = !IsEditing;
                }
                else
                {
                    // AddButton
                    AddButton.Enabled = true;

                    // Cannot be enabled if not editing
                    EditButton.Enabled = false;
                    DeleteButton.Enabled = false;
                }
            }
            #endregion

        #endregion

        #region Properties

            #region AllItemsLabelColor
            /// <summary>
            /// This property gets or sets the value for 'AllItemsLabelColor'.
            /// </summary>
            public Color AllItemsLabelColor
            {
                get
                {
                    // initial value
                    Color allItemsLabelColor = Color.Black;
            
                    // if the control exists
                    if (AllItemsLabel != null)
                    {
                        // set the return value
                        allItemsLabelColor = (Color) AllItemsLabel.ForeColor;
                    }
            
                    // return value
                    return allItemsLabelColor;
                }
                set
                {
                    // if the control exists
                    if (AllItemsLabel != null)
                    {        
                        // set the value
                        AllItemsLabel.ForeColor = value;
                    }
                }
            }
            #endregion
            
            #region AllItemsLabelText
            /// <summary>
            /// This property gets or sets the value for 'AllItemsLabelText'.
            /// </summary>
            public string AllItemsLabelText
            {
                get
                {
                    // initial value
                    string allItemsLabelText = "";
            
                    // if the control exists
                    if (AllItemsLabel != null)
                    {
                        // set the return value
                        allItemsLabelText = (string) AllItemsLabel.Text;
                    }
            
                    // return value
                    return allItemsLabelText;
                }
                set
                {
                    // if the control exists
                    if (AllItemsLabel != null)
                    {        
                        // set the value
                        AllItemsLabel.Text = value;
                    }
                }
            }
            #endregion

            #region BottomMargin
            /// <summary>
            /// This property gets or sets the value for 'BottomMargin'.
            /// </summary>
            public int BottomMargin
            {
                get 
                { 
                    // if the BottomMarginPanel exists
                    if (BottomMarginPanel != null)
                    {
                        // set the return value
                        bottomMargin = BottomMarginPanel.Height;
                    }

                    // return value
                    return bottomMargin; 
                }
                set 
                { 
                    // set the value
                    bottomMargin = value;

                    // if the BottomMarginPanel exists
                    if (BottomMarginPanel != null)
                    {
                        // set the height of the control
                        BottomMarginPanel.Height = value;
                    }
                }
            }
            #endregion
            
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
                get 
                { 
                    // initial value
                    EditModeEnum editMode = EditModeEnum.ReadOnly;

                    // if the value for HasParentListEditorHost is true
                    if (HasParentListEditorHost)
                    {
                        // set the return value
                        editMode = ParentListEditorHost.EditMode;
                    }

                    // return value
                    return editMode;
                }
            }
            #endregion

            #region HasSaveControl
            /// <summary>
            /// This property returns true if this object has a 'SaveControl'.
            /// </summary>
            public bool HasSaveControl
            {
                get
                {
                    // initial value
                    bool hasSaveControl = (this.SaveControl != null);
                    
                    // return value
                    return hasSaveControl;
                }
            }
            #endregion
            
            #region IsEditing
            /// <summary>
            /// If EditMode is not equal to ReadOnly
            /// </summary>
            public bool IsEditing
            {
                get
                {
                    // initial value
                    bool isEditing = (EditMode != EditModeEnum.ReadOnly);

                    // return value
                    return isEditing;
                }
            }
            #endregion
            
            #region HasList
            /// <summary>
            /// This property returns true if this object has a 'List'.
            /// </summary>
            public bool HasList
            {
                get
                {
                    // initial value
                    bool hasList = (this.List != null);
                    
                    // return value
                    return hasList;
                }
            }
            #endregion
            
            #region HasParentListEditorHost
            /// <summary>
            /// This property returns true if this object has a 'ParentListEditorHost'.
            /// </summary>
            public bool HasParentListEditorHost
            {
                get
                {
                    // initial value
                    bool hasParentListEditorHost = (this.ParentListEditorHost != null);
                    
                    // return value
                    return hasParentListEditorHost;
                }
            }
            #endregion
            
            #region HasSelectedItem
            /// <summary>
            /// This property returns true if this object has a 'SelectedItem'.
            /// </summary>
            public bool HasSelectedItem
            {
                get
                {
                    // initial value
                    bool hasSelectedItem = (this.SelectedItem != null);
                    
                    // return value
                    return hasSelectedItem;
                }
            }
            #endregion
            
            #region LeftMargin
            /// <summary>
            /// This property gets or sets the value for 'LeftMargin'.
            /// </summary>
            public int LeftMargin
            {
                get
                {
                    // initial value
                    int leftMargin = 0;

                    // if the control exists
                    if (LeftMarginPanel != null)
                    {
                        // set the return value
                        leftMargin = (int) LeftMarginPanel.Width;
                    }

                    // return value
                    return leftMargin;
                }
                set
                {
                    // if the control exists
                    if (LeftMarginPanel != null)
                    {        
                        // set the value
                        LeftMarginPanel.Width = value;
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
            
            #region ListEditorWidth
            /// <summary>
            /// This property gets or sets the value for 'ListEditorWidth'.
            /// </summary>
            public int ListEditorWidth
            {
                get { return listEditorWidth; }
                set 
                { 
                    listEditorWidth = value;

                    // Enable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region ParentListEditorHost
            /// <summary>
            /// This property gets or sets the value for 'ParentListEditorHost'.
            /// </summary>
            public IListEditorHost ParentListEditorHost
            {
                get { return parentListEditorHost; }
                set { parentListEditorHost = value; }
            }
            #endregion
            
            #region RightMargin
            /// <summary>
            /// This property gets or sets the value for 'RightMargin'.
            /// </summary>
            public int RightMargin
            {
                get
                {
                    // initial value
                    int rightMargin = 0;

                    // if the control exists
                    if (SeperatorPanel != null)
                    {
                        // set the return value
                        rightMargin = (int) SeperatorPanel.Width;
                    }

                    // return value
                    return rightMargin;
                }
                set
                {
                    // if the control exists
                    if (SeperatorPanel != null)
                    {        
                        // set the value
                        SeperatorPanel.Width = value;
                    }
                }
            }
            #endregion
            
            #region SaveControl
            /// <summary>
            /// This property gets or sets the value for 'SaveControl'.
            /// </summary>
            public SaveCancelControl SaveControl
            {
                get { return saveControl; }
                set { saveControl = value; }
            }
            #endregion
            
            #region SelectedItem
            /// <summary>
            /// This read only property returns the 'SelectedItem' from the ParentListEditorHost if it exists
            /// </summary>
            public object SelectedItem
            {
                get 
                { 
                    // initial value
                    object selectedItem = null;

                    // if the ParentListEditorHost exists
                    if (HasParentListEditorHost)
                    {
                        // Set the item
                        selectedItem = ParentListEditorHost.SelectedItem;
                    }

                    // return value
                    return selectedItem;
                }            
            }
            #endregion

            #region ShowAllItemsLabel
            /// <summary>
            /// This property gets or sets the value for 'ShowAllItemsLabel'.
            /// </summary>
            public bool ShowAllItemsLabel
            {
                get
                {
                    // initial value
                    bool showAllItemsLabel = true;

                    // if the control exists
                    if (AllItemsLabel != null)
                    {
                        // set the return value
                        showAllItemsLabel = (bool) AllItemsLabel.Visible;
                    }

                    // return value
                    return showAllItemsLabel;
                }
                set
                {
                    // if the control exists
                    if (AllItemsLabel != null)
                    {        
                        // set the value
                        AllItemsLabel.Visible = value;
                    }
                }
            }
            #endregion
            
            #region ShowBackgroundImage
            /// <summary>
            /// This property gets or sets the value for 'ShowBackgroundImage'.
            /// </summary>
            public bool ShowBackgroundImage
            {
                get { return showBackgroundImage; }
                set 
                { 
                    // set the value
                    showBackgroundImage = value;

                    // if the value for showBackgroundImage is FALSE
                    if (!showBackgroundImage)
                    {
                        // erase the BackgroundImage
                        this.BackgroundImage = null;
                    }
                    else
                    {
                        // To Do: Add a theme some day
                        this.BackgroundImage = Properties.Resources.Deep_Black;
                    }
                }
            }
            #endregion
            
            #region ShowSelectedControlPanel
            /// <summary>
            /// This property gets or sets the value for 'ShowSelectedControlPanel'.
            /// </summary>
            public bool ShowSelectedControlPanel
            {
                get { return showSelectedControlPanel; }
                set 
                { 
                    showSelectedControlPanel = value;

                    // Enable controls
                    UIEnable();
                }
            }
            #endregion
            
            #region Sorted
            /// <summary>
            /// This property gets or sets the value for 'Sorted'.
            /// This gets and sets the value for ListBox.Sorted.
            /// </summary>
            public bool Sorted
            {
                get 
                { 
                    // set the value for sorted
                    sorted = false;
                    
                    // if the ListBox exists
                    if (ListBox != null)
                    {
                        // return the value
                        sorted = ListBox.Sorted;
                    }
                    
                    // return value
                    return sorted;
                }
                set 
                { 
                    // set the value
                    sorted = value;

                    // if the ListBox exists
                    if (ListBox != null)
                    {
                        // set  the value for sorted
                        ListBox.Sorted = sorted;
                    }
                }
            }
        #endregion

            #region TopMargin
            /// <summary>
            /// This property gets or sets the value for 'TopMargin'.
            /// </summary>
            public int TopMargin
            {
                get 
                { 
                    // if the TopMarginPanel exists
                    if (TopMarginPanel != null)
                    {
                        // set the return value
                        topMargin = TopMarginPanel.Height;
                    }

                    // return value
                    return topMargin; 
                }
                set 
                { 
                    // set the value
                    topMargin = value;

                    // if the TopMarginPanel exists
                    if (TopMarginPanel != null)
                    {
                        // set the height of the control
                        TopMarginPanel.Height = value;
                    }
                }
            }
            #endregion
            
            #region WidthFullControl
            /// <summary>
            /// This property gets or sets the value for 'WidthFullControl'.
            /// </summary>
            public int WidthFullControl
            {
                get { return widthFullControl; }
                set 
                { 
                    // set the width
                    widthFullControl = value;

                    // Enable or disable controls
                    UIEnable();
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
