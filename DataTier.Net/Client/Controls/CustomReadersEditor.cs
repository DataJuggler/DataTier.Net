

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Xml.Writers;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataGateway;
using DataTierClient.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTierClient.ClientUtil;

#endregion

namespace DataTierClient.Controls
{

    #region class CustomReadersEditor
    /// <summary>
    /// This control is used to edit a reader.
    /// </summary>
    public partial class CustomReadersEditor : UserControl, ISelectedIndexListener, ITabButtonParent, ITextChanged, ISaveCancelControl
    {
        
        #region Private Variables
        private DTNTable selectedTable;
        private CustomReader selectedReader;
        private string storedReader;
        private ActionTypeEnum actionType;
        private Project openProject;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomReadersEditor' object.
        /// </summary>
        public CustomReadersEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region EditFieldSetsButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Edit Field Sets Button _ Enabled Changed
            /// </summary>
            private void EditFieldSetsButton_EnabledChanged(object sender, EventArgs e)
            {

        }
        #endregion

            #region ReadersListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when a selection is made in the 'ReadersListBox_'.
            /// </summary>
            private void ReadersListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // set the index
                int index = ReadersListBox.SelectedIndex;

                // if the SelectedTable.CustomReaders collection exists and the index is in range
                if ((HasSelectedTable) && (SelectedTable.HasCustomReaders) && (index >= 0) && (index < SelectedTable.CustomReaders.Count))
                {
                    // Set the SelectedReader
                    SelectedReader = SelectedTable.CustomReaders[index];

                    // Display the custom reader
                    DisplaySelectedCustomReader();
                }

                // Handle the controls
                UIEnable();
            }
            #endregion

            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If Editing In Progress
                if (EditingInProgress)
                {
                    // if adding a new one, you must cancel
                    if (ActionType == ActionTypeEnum.AddButtonClicked)
                    {
                        // Erase everything
                        Clear();
                    }

                    // Exit editing
                    ActionType = ActionTypeEnum.NoAction;

                    // Enable controls
                    UIEnable();
                }
                else
                {
                    // Close this form
                    Close();
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
                    // validate the custom reader
                    bool isValid = ValidateCustomReader();

                    // if isValid is true
                    if (isValid)
                    {
                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway();

                        // save the selected reader
                        bool saved = gateway.SaveCustomReader(ref selectedReader);

                        // if the value for saved is true
                        if (saved)
                        {
                            // reload the CustomReaders
                            this.SelectedTable.CustomReaders = gateway.LoadCustomReadersForTable(this.SelectedTable.TableId);
                            ActionType = ActionTypeEnum.NoAction;

                            // set the readerName
                            string readerName = SelectedReader.ReaderName;

                            // Redisplay the custom readers
                            DisplayCustomReaders();

                            // find the index
                            int index = FindReaderIndex(readerName);

                            // set the index
                            ReadersListBox.SelectedIndex = index;

                            // redisplay the selected custom reader (might not be needed if it fires above)
                            ReadersListBox_SelectedIndexChanged(this, null);

                            // Show failure
                            ShowStatus("Status", "Custom Reader Saved.", Color.ForestGreen);
                        }
                        else
                        {
                            // Show failure
                            ShowStatus("Status", "Save Failed", Color.Firebrick);

                            // get the last exception
                            Exception exception = gateway.GetLastException();

                            // Show the user a warning the save failed
                            MessageHelper.DisplayMessage("An error occurred saving your Custom Reader. Debug the issue in the OnSave event.", "Save Failed");
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // Enable or disa
                UIEnable();
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
                // if a selected index was set
                if (selectedIndex >= 0)
                {
                    // If the control object exists
                    if ((control != null) && (HasSelectedTable) && (SelectedTable.HasReaderFieldSets) && (selectedIndex < SelectedTable.ReaderFieldSets.Count))
                    {
                        // if the value for HasSelectedReader is true
                        if (HasSelectedReader)
                        {
                            // Set the FieldSet
                            SelectedReader.FieldSet = SelectedTable.ReaderFieldSets[selectedIndex];

                            // If the value for the property SelectedReader.HasFieldSet is true
                            if (SelectedReader.HasFieldSet)
                            {
                                // Set the FieldSetId
                                SelectedReader.FieldSetId = SelectedReader.FieldSet.FieldSetId;
                            }
                        }
                    }
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region OnTextChanged(LabelTextBoxControl sender, string text)
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            public void OnTextChanged(Control control, string text)
            {
                // cast the control as a LabelTextBoxControl
                LabelTextBoxControl sender = control as LabelTextBoxControl;

                // If the SelectedReader object exists
                if ((this.HasSelectedReader) && (TextHelper.Exists(text)))
                {
                    // Set the ReaderName
                    SelectedReader.ReaderName = text;
                    SelectedReader.ClassName = text;
                    
                    // if the value for HasOpenProject is true
                    if (HasOpenProject)
                    {
                        // Set the Reader fileName
                        SelectedReader.FileName = Path.Combine(OpenProject.ReaderFolder, text + ".cs");
                    }

                    // Display the selected custom reader
                    DisplaySelectedCustomReader();
                }

                // Enable controls
                UIEnable();
            }
            #endregion

            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // Hide the StatusLabel
                StatusLabel.Visible = false;

                if (this.HasSelectedTable)
                {
                    // determine action by the button text
                    switch (tabButton.ButtonText)
                    {
                        case "...":

                            // EditFieldSets
                            EditFieldSets();

                            // required
                            break;

                        case "Add":

                            // Add a new reader                            
                            AddNewReader();

                            // required
                            break;

                        case "Edit":

                           // Edit Selected
                           EditSelectedReader();

                            // required
                            break;

                        case "Delete":

                            // Delete the SelectedCustomReader
                            DeleteCustomReader();

                            // required
                            break;
                        }
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region AddNewReader()
            /// <summary>
            /// This method Add New Reader
            /// </summary>
            public void AddNewReader()
            {
                // Set the ActionType
                ActionType = ActionTypeEnum.AddButtonClicked;

                // Create a new instance of a 'CustomReader' object.
                this.SelectedReader = new CustomReader();

                // Erase the current values
                Clear();

                // Set the TableId
                this.SelectedReader.TableId = this.SelectedTable.TableId;

                // Create a new instance of a 'CustomReadersWriter' object.
                CustomReadersWriter writer = new CustomReadersWriter();

                // Export the selected reader
                StoredReader = writer.ExportCustomReader(SelectedReader);

                // Enable or disable controls
                UIEnable();

                // Set Focus to the TextBox of the ReaderNameControl
                this.ReaderNameControl.SetFocusToTextBox();
            }
            #endregion
            
            #region Clear()
            /// <summary>
            /// This method Clear
            /// </summary>
            public void Clear()
            {
                // Erase the current text
                ReaderNameControl.Text = "";
                ClassNameControl.Text = "";
                FileNameControl.Text = "";
                FieldSetControl.SelectedIndex = -1;
                FieldSetControl.ComboBoxText = "";
            }
            #endregion
            
            #region Close()
            /// <summary>
            /// This method Close
            /// </summary>
            public void Close()
            {
                // if the value for HasParentCustomReadersForm is true
                if (HasParentCustomReadersForm)
                {
                    // close the parent form
                    ParentCustomReadersForm.Close();
                }
            }
            #endregion
            
            #region DeleteCustomReader()
            /// <summary>
            /// This method Delete Custom Reader
            /// </summary>
            public void DeleteCustomReader()
            {
                // Save button is not needed to be enabled
                ActionType = ActionTypeEnum.NoAction;

                // If the SelectedReader object exists
                if (this.HasSelectedReader)
                {
                    // Show the user a message
                    string message = "Are you sure you wish to delete the selected Reader? This action cannot be undone.";
                    string title = "Confirm Delete";

                    // Get Dialog Result
                    DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // if user choose 'Yes'
                    if (result == DialogResult.Yes)
                    {
                        // user confirmed the delete
                                
                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway();

                        // perform the delete
                        bool deleted = gateway.DeleteCustomReader(this.SelectedReader.CustomReaderId);

                        // if the value for deleted is true
                        if (deleted)
                        {
                            // load the CustomReaders for the SelectedTable
                            this.SelectedTable.CustomReaders = gateway.LoadCustomReadersForTable(this.SelectedTable.TableId);

                            // Redisplay the custom readers
                            DisplayCustomReaders();

                            // Erase the SelectedReader
                            this.SelectedReader = null;

                            // Erase any current selections just in case
                            this.ReadersListBox.SelectedIndex = -1;

                            // Make sure the buttons are not enabled with a selected item
                            ReadersListBox_SelectedIndexChanged(this, new EventArgs());

                            // Clear any current display
                            Clear();
                        }
                    }
                }
            }
            #endregion
            
            #region DisplayCustomReaders()
            /// <summary>
            /// This method Display Custom Readers
            /// </summary>
            public void DisplayCustomReaders()
            {
                // Clear the list
                this.ReadersListBox.Items.Clear();

                // locals
                int selectedReaderId = 0;
                int index = -1;
                int selectedIndex = -1;

                // if the value for HasSelectedReader is true
                if (HasSelectedReader)
                {
                    // set the selectedReaderId
                    selectedReaderId = SelectedReader.CustomReaderId;
                }

                // If the SelectedTable object exists
                if ((this.HasSelectedTable) && (this.SelectedTable.HasCustomReaders))
                {
                    // iterate the CustomReaders                    
                    foreach (CustomReader customReader in this.SelectedTable.CustomReaders)
                    {
                        // Increment the value for index
                        index++;

                        // Add this item
                        ReadersListBox.Items.Add(customReader);

                        // if this is the selectedCustomReader
                        if (customReader.CustomReaderId == selectedReaderId)
                        {
                            // set the selectedIndex
                            selectedIndex = index;
                        }
                    }

                    // set the selectedIndex
                    ReadersListBox.SelectedIndex = selectedIndex;
                }
            }
            #endregion
            
            #region DisplaySelectedCustomReader()
            /// <summary>
            /// This method Display Selected Custom Reader
            /// </summary>
            public void DisplaySelectedCustomReader()
            {
                // locals
                string readerName = "";
                string className = "";
                string fileName = "";
                int fieldSetIndex = -1;

                // if the value for HasSelectedReader is true
                if (HasSelectedReader)
                {
                    readerName = SelectedReader.ReaderName;
                    className = SelectedReader.ClassName;
                    fileName = SelectedReader.FileName;
                    fieldSetIndex = GetReaderFieldSetIndex(SelectedReader.FieldSetId);
                }

                // display the values
                ReaderNameControl.Text = readerName;
                ClassNameControl.Text = className;
                FileNameControl.Text = fileName;
                FieldSetControl.SelectedIndex = fieldSetIndex;
            }
            #endregion
            
            #region EditFieldSets()
            /// <summary>
            /// This method Edit Field Sets
            /// </summary>
            public void EditFieldSets()
            {
                 // Create a new instance of a 'FieldSetEditorForm' object.
                FieldSetEditorForm form = new FieldSetEditorForm();

                // Setup the control
                form.Setup(this.SelectedTable, false, false, null);

                // Show the FieldSetEditor form
                form.ShowDialog();

                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway();

                // Load the FieldSets
                this.SelectedTable.FieldSets = gateway.LoadFieldSetsForTable(this.SelectedTable.TableId);

                // Reload the FieldSets
                FieldSetControl.LoadItems(SelectedTable.ReaderFieldSets);
            }
            #endregion
            
            #region EditSelectedReader()
            /// <summary>
            /// This method Edit Selected Reader
            /// </summary>
            public void EditSelectedReader()
            {
                // Set the ActionType
                ActionType = ActionTypeEnum.EditButtonClicked;

                // Create a new instance of a 'CustomReadersWriter' object.
                CustomReadersWriter writer = new CustomReadersWriter();

                // Export the selected reader
                StoredReader = writer.ExportCustomReader(SelectedReader);

                // Enable or disable controls
                UIEnable();

                // Set Focus to the TextBox of the ReaderNameControl
                this.ReaderNameControl.SetFocusToTextBox();
            }
            #endregion
            
            #region FindReaderIndex(string readerName)
            /// <summary>
            /// This method returns the Reader Index
            /// </summary>
            public int FindReaderIndex(string readerName)
            {
                // initial value
                int readerIndex = -1;

                // local
                int tempIndex = -1;

                // if the SelectedTable.CustomReaders exist
                if ((HasSelectedTable) && (SelectedTable.HasCustomReaders))
                {
                    // iterate the custom readers                    
                    foreach (CustomReader reader in SelectedTable.CustomReaders)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this is the reader being searched for
                        if (TextHelper.IsEqual(reader.ReaderName, readerName))
                        {
                            // set the return value
                            readerIndex = tempIndex;

                            // break out of this loop
                            break;
                        }
                    }
                }
                
                // return value
                return readerIndex;
            }
            #endregion
            
            #region GetReaderFieldSetIndex(int fieldSetId)
            /// <summary>
            /// This method returns the Field Set Index for the FieldSetId given.
            /// Note, this method returns the ReaderFieldSet index, not the Index of 
            /// all FieldSets for a table. This could be different.
            /// </summary>
            public int GetReaderFieldSetIndex(int fieldSetId)
            {
                // initial value
                int fieldSetIndex = -1;

                // local
                int tempIndex = -1;

                // verify a fieldSetId is set
                if (fieldSetId > 0)
                {
                    // if the value for HasSelectedTable is true
                    if ((HasSelectedTable) && (SelectedTable.HasReaderFieldSets))
                    {   
                        // iterate the ReaderFieldSets                    
                        foreach (FieldSet readerFieldSet in SelectedTable.ReaderFieldSets)
                        {      
                            // Increment the value for tempIndex
                            tempIndex++;

                            // if this is the item being sought
                            if (readerFieldSet.FieldSetId == fieldSetId)
                            {
                                // set the return value
                                fieldSetIndex = tempIndex;

                                // break out of this loop
                                break;
                            }
                        }
                    }
                }
                
                // return value
                return fieldSetIndex;
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Setup the listener only for the ReaderName
                this.ReaderNameControl.OnTextChangedListener = this;
                
                // Setup the listener for the SelectedIndex changed
                this.FieldSetControl.SelectedIndexListener = this;

                // The button starts off with Done and enabled
                this.SaveCancelControl.SetupCancelButton("Done", 80);

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region Setup(Project openProject, DTNTable selectedTable, CustomReader selectedReader)
            /// <summary>
            /// This method prepares this control for creating or editing Custom Readers.
            /// </summary>
            public void Setup(Project openProject, DTNTable selectedTable, CustomReader selectedReader = null)
            {
                // store the args
                OpenProject = openProject;
                this.SelectedTable = selectedTable;
                this.SelectedReader = selectedReader;
                
                // If the SelectedTable object exists
                if (this.HasSelectedTable)
                {
                    // Set the TableName
                    this.TableControl.Text = this.SelectedTable.TableName;

                    // Load the FieldSets (where ReaderMode equals true)
                    this.FieldSetControl.LoadItems(this.SelectedTable.ReaderFieldSets);
                }
                else
                {
                    // Set the TableName
                    this.TableControl.Text = "";
                }

                // Display the readers
                DisplayCustomReaders();

                // Display the SelectedCustomReader
                DisplaySelectedCustomReader();
            }
            #endregion
            
            #region ShowStatus(string lableText, string text, Color color)
            /// <summary>
            /// This method Show Status
            /// </summary>
            public void ShowStatus(string lableText, string text, Color color)
            {
                // Set the text
                StatusLabel.LabelText = lableText;
                StatusLabel.LabelColor = color;
                StatusLabel.ValueLabelColor = color;
                StatusLabel.Text = text;
                StatusLabel.Visible = true;
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {  
                // Enable or disable the controls based upon if we have a SelectedReader or not
                ReaderNameControl.Editable = HasSelectedReader;
                FieldSetControl.Editable = HasSelectedReader;
                EditFieldSetsButton.Enabled = EditingInProgress;

                // these two controls are set via the ReaderNameControl
                ClassNameControl.Editable = false;
                FileNameControl.Editable = false;

                // Disable or enable the buttons based upon the ActionType
                if (EditingInProgress)
                {
                    // Disable all the buttons while editing is in progress
                    AddButton.Enabled = false;
                    EditButton.Enabled = false;
                    EditButton.Selected = false;
                    DeleteButton.Enabled = false;
                    DeleteButton.Selected = false;
                    ReaderNameControl.Editable = true;
                    FieldSetControl.Editable = true;
                    EditFieldSetsButton.Enabled = true;

                    // Change to Cancel
                    this.SaveCancelControl.SetupCancelButton("Cancel", 80);
                }
                else
                {
                    // Not Editable
                    ReaderNameControl.Editable = false;
                    FieldSetControl.Editable = false;
                    EditFieldSetsButton.Enabled = false;

                    // you can always add a new one if not editing
                    AddButton.Enabled = true;

                    // if the value for HasSelectedReader is true
                    if (HasSelectedReader)
                    {
                        // These buttons require a selected reader
                        EditButton.Enabled = true;
                        EditButton.Selected = true;
                        DeleteButton.Enabled = true;
                        DeleteButton.Selected = true;
                    }
                    else
                    {
                        // withhout a SelectedReader, you cannot Edit or Delete
                        EditButton.Enabled = false;
                        EditButton.Selected = false;
                        DeleteButton.Enabled = false;
                        DeleteButton.Selected = false;
                    }

                    // Change back to Done
                    this.SaveCancelControl.SetupCancelButton("Done", 80);
                }

                // if we are in Add New Mode
                if (ActionType == ActionTypeEnum.AddButtonClicked)
                {
                    // Enable the Save button
                    SaveCancelControl.EnableSaveButton(true);
                }
                else if (ActionType == ActionTypeEnum.EditButtonClicked)
                {
                    // Create a new instance of a 'CustomReadersWriter' object.
                    CustomReadersWriter writer = new CustomReadersWriter();

                    // Export the selected reader
                    string currentReaderXml = writer.ExportCustomReader(SelectedReader);

                    // determine if there are changes or not
                    bool hasChanges = !TextHelper.IsEqual(StoredReader, currentReaderXml);

                    // Enable the save button if there are changes
                    SaveCancelControl.EnableSaveButton(hasChanges);
                }
                else
                {
                    // Disable the save button
                    SaveCancelControl.EnableSaveButton(false);
                }
            }
            #endregion
            
            #region ValidateCustomReader()
            /// <summary>
            /// This method returns the Custom Reader
            /// </summary>
            public bool ValidateCustomReader()
            {
                // initial value
                bool valid = false;

                // if the SelectedReader exists
                if (HasSelectedReader)
                {
                    // default to valid
                    valid = true;

                    // if the ReaderName is not set
                    if (!TextHelper.Exists(SelectedReader.ReaderName))
                    {
                        // Show failure
                        ShowStatus("Status", "Name is required.", Color.Firebrick);

                        // Set Focus to the TextBox for ReaderName
                        ReaderNameControl.SetFocusToTextBox();

                        // not valid
                        valid = false;
                    }

                    // if the ReaderName is not set
                    if ((valid) && (!SelectedReader.HasFieldSetId))
                    {
                        // Show failure
                        ShowStatus("Status", "Field Set is required.", Color.Firebrick);

                        // not valid
                        valid = false;
                    }
                }
                
                // return value
                return valid;
            }
            #endregion
            
        #endregion

        #region Properties

            #region ActionType
            /// <summary>
            /// This property gets or sets the value for 'ActionType'.
            /// </summary>
            public ActionTypeEnum ActionType
            {
                get { return actionType; }
                set { actionType = value; }
            }
            #endregion
            
            #region EditingInProgress
            /// <summary>
            /// This read only property returns the value for 'EditingInProgress', which is true if the ActionType
            /// is set to AddNew or Edit
            /// </summary>
            public bool EditingInProgress
            {
                get
                {
                    // initial value
                    bool editing = (ActionType != ActionTypeEnum.NoAction);
                    
                    // return value
                    return editing;
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
            
            #region HasParentCustomReadersForm
            /// <summary>
            /// This property returns true if this object has a 'ParentCustomReadersForm'.
            /// </summary>
            public bool HasParentCustomReadersForm
            {
                get
                {
                    // initial value
                    bool hasParentCustomReadersForm = (this.ParentCustomReadersForm != null);
                    
                    // return value
                    return hasParentCustomReadersForm;
                }
            }
            #endregion
            
            #region HasSelectedReader
            /// <summary>
            /// This property returns true if this object has a 'SelectedReader'.
            /// </summary>
            public bool HasSelectedReader
            {
                get
                {
                    // initial value
                    bool hasSelectedReader = (this.SelectedReader != null);
                    
                    // return value
                    return hasSelectedReader;
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
            
            #region HasStoredReader
            /// <summary>
            /// This property returns true if the 'StoredReader' exists.
            /// </summary>
            public bool HasStoredReader
            {
                get
                {
                    // initial value
                    bool hasStoredReader = (!String.IsNullOrEmpty(this.StoredReader));
                    
                    // return value
                    return hasStoredReader;
                }
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
            
            #region ParentCustomReadersForm
            /// <summary>
            /// This read only property returns the value for 'ParentCustomReadersForm'.
            /// </summary>
            public CustomReadersEditorForm ParentCustomReadersForm
            {
                get
                {
                    // initial value
                    CustomReadersEditorForm parentForm = this.ParentForm as CustomReadersEditorForm;
                    
                    // return value
                    return parentForm;
                }
            }
            #endregion
            
            #region SelectedReader
            /// <summary>
            /// This property gets or sets the value for 'SelectedReader'.
            /// </summary>
            public CustomReader SelectedReader
            {
                get { return selectedReader; }
                set { selectedReader = value; }
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

            #region StoredReader
            /// <summary>
            /// This property gets or sets the value for 'StoredReader'.
            /// </summary>
            public string StoredReader
            {
                get { return storedReader; }
                set { storedReader = value; }
            }
        #endregion

        #endregion
    }
    #endregion

}
