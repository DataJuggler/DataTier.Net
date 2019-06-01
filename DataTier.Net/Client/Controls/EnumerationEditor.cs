

#region using statements

using System;
using System.Windows.Forms;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using DataTierClient.Controls.Interfaces;
using DataTierClient;

#endregion

namespace DataTierClient.Controls
{

    #region class EnumerationEditor : UserControl
    /// <summary>
    /// This control edits enumerations for this project.
    /// </summary>
    public partial class EnumerationEditor : UserControl, ITabButtonParent
    {

        #region Private Variables
        private Gateway gateway;
        private Project selectedProject;
        private Enumeration selectedEnumeration;
        private bool editMode;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an 'EnumerationEditor'
        /// </summary>
        public EnumerationEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region AddButton_Click(object sender, EventArgs e)
        /// <summary>
        /// The Add button was clicked, this creates a new Enumeration object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Create a new enumeration
            this.SelectedEnumeration = new Enumeration();

            // Set EditMode to true
            this.EditMode = true;

            // Set Focus to the TextBox
            this.FieldNameTextBox.Focus();
        }
        #endregion

        #region CancelSaveButton_Click(object sender, EventArgs e)
        /// <summary>
        /// The Cancel button was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSaveButton_Click(object sender, EventArgs e)
        {
            // Set to false
            this.EditMode = false;
        }
        #endregion

        #region ConfirmDelete(string itemType)
        /// <summary>
        /// If the user confirms deleting
        /// the selected item
        /// </summary>
        /// <returns></returns>
        public bool ConfirmDelete(string itemType, string name)
        {
            // initial value
            bool confirmed = false;

            // locals
            string prompt = "Are you sure you wisth to delete the selected '" + itemType + "' named '" + name + "'?" + System.Environment.NewLine + "This action can not be undone.";
            string title = "Confirm Delete";

            // Get Dialog Result
            DialogResult result = MessageBox.Show(prompt, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // if user choose 'Yes'
            if (result == DialogResult.Yes)
            {
                // user confirmed the delete
                confirmed = true;
            }

            // return value
            return confirmed;
        }
        #endregion

        #region DeleteButton_Click(object sender, EventArgs e)
        /// <summary>
        /// The Delete button was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // if the SelectedEnumeration exists
            if (this.HasSelectedEnumeration)
            {
                // get user confirmation
                bool confirmed = this.ConfirmDelete("Enumeration", this.SelectedEnumeration.FieldName);

                // if confirmed
                if (confirmed)
                {
                    // delete the selected enumeration
                    bool deleted = this.Gateway.AppController.ControllerManager.EnumerationController.Delete(this.SelectedEnumeration);

                    // if deleted
                    if (deleted)
                    {
                        // Reload the enumerations for the SelectedProject and display them
                        ReloadAndDisplayEnumerations();
                    }
                }
            }
        }
        #endregion

        #region EditButton_Click(object sender, EventArgs e)
        /// <summary>
        /// The Edit button was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            // Set EditMode to true
            this.EditMode = true;

            // Set Focus to the TextBox
            this.FieldNameTextBox.Focus();
        }
        #endregion

        #region EnumerationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// A selection was made in the list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnumerationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the selected enumeration
            this.SelectedEnumeration = this.EnumerationsListBox.SelectedItem as Enumeration;
        }
        #endregion

        #region DoneButton_Click(object sender, EventArgs e)
        /// <summary>
        /// Close the form that hosts this control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneButton_Click(object sender, EventArgs e)
        {
            // If the parent form exists
            if (this.ParentForm != null)
            {
                // Close this form
                this.ParentForm.Close();
            }
        }
        #endregion

        #region SaveButton_Click(object sender, EventArgs e)
        /// <summary>
        /// Insert or Update the existing enumeration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // if the SelectedEnumeration exists
            if ((this.HasSelectedEnumeration) && (this.SelectedProject != null))
            {
                // Capture the values
                this.SelectedEnumeration.FieldName = this.FieldNameTextBox.Text;
                this.SelectedEnumeration.EnumerationName = this.DataTypeTextBox.Text;
                this.SelectedEnumeration.ProjectId = this.SelectedProject.ProjectId;

                // get a local copy
                Enumeration enumeration = this.SelectedEnumeration;

                // if saved
                bool saved = this.Gateway.AppController.ControllerManager.EnumerationController.Save(ref enumeration);

                // if saved
                if (saved)
                {
                    // no longer editing
                    this.EditMode = false;

                    // reload the enumeraitons
                    ReloadAndDisplayEnumerations();

                    // Select this item again
                    int index = FindIndex(enumeration);

                    // set the index
                    this.EnumerationsListBox.SelectedIndex = index;
                }
            }
        }
        #endregion

        #endregion

        #region Methods

            #region DisplayEnumerations()
            /// <summary>
            /// This method displays the enumerations for this project.
            /// </summary>
            private void DisplayEnumerations()
            {
                // clear the list box
                this.EnumerationsListBox.Items.Clear();

                // if the SelectedProject exists
                if ((this.SelectedProject != null) && (this.SelectedProject.Enumerations != null))
                {
                    // iterate the items
                    foreach (Enumeration enumeration in this.SelectedProject.Enumerations)
                    {
                        // add this item
                        this.EnumerationsListBox.Items.Add(enumeration);
                    }
                }
            }
            #endregion

            #region DisplaySelectedEnumeration()
            /// <summary>
            /// This method displays the selected enumeration.
            /// </summary>
            private void DisplaySelectedEnumeration()
            {
                // Display the values
                this.FieldNameTextBox.Text = this.SelectedFieldName;
                this.DataTypeTextBox.Text = this.SelectedDataType;
            }
            #endregion

            #region FindIndex(Enumeration enumeration)
            /// <summary>
            /// This method finds an index of an enumeration
            /// </summary>
            /// <param name="enumeration"></param>
            /// <returns></returns>
            private int FindIndex(Enumeration enumeration)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // if the enumeration exists
                if (enumeration != null)
                {
                    // iterate the items
                    foreach (object item in this.EnumerationsListBox.Items)
                    {
                        // increment tempIndex
                        tempIndex++;

                        // cast the item as an Enumeration
                        Enumeration tempEnumeration = item as Enumeration;

                        // if this is the matching item
                        if ((tempEnumeration != null) && (tempEnumeration.EnumerationId == enumeration.EnumerationId))
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of foreach loop
                            break;
                        }
                    }
                }

                // return value
                return index;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create the Gateway
                this.Gateway = new Gateway();
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

                        // call the AddButton_Click event
                        AddButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditButton_Click event
                        EditButton_Click(this, null);

                        // required
                        break;

                    case "Delete":

                        // Call the DeleteButton_Click event
                        DeleteButton_Click(this, null);

                        // required
                        break;

                    case "Save":

                        // Call the SaveButton_Click event
                        SaveButton_Click(this, null);

                        // required
                        break;

                    case "Cancel":

                        // Call the CancelSaveButton_Click event
                        CancelSaveButton_Click(this, null);

                        // required
                        break;

                    case "Done":

                        // Call the DoneButton_Click event
                        DoneButton_Click(this, null);

                        // required
                        break;

                }
            }
            #endregion

            #region ReloadAndDisplayEnumerations()
            /// <summary>
            /// Load the enumerations for the selected project and display them.
            /// </summary>
            private void ReloadAndDisplayEnumerations()
            {
                // reload the enumerations for this project
                this.SelectedProject.Enumerations = this.Gateway.LoadEnumerationsForProject(this.SelectedProject.ProjectId);

                // Redisplay the list of enumerations
                this.DisplayEnumerations();
            }
            #endregion

            #region Setup(Project selectedProject)
            /// <summary>
            /// This method is used to setup this control. 
            /// </summary>
            /// <param name="selectedProject"></param>
            public void Setup(Project selectedProject)
            {
                // Set the selected project
                this.SelectedProject = selectedProject;

                // if the SelectedProject exists
                if (this.SelectedProject != null)
                {
                    // load and display the enumerations
                    ReloadAndDisplayEnumerations();
                }
            }
            #endregion

            #region UIControl()
            /// <summary>
            /// Enable or disable controls or show or hide controls as needed.
            /// </summary>
            private void UIControl()
            {
                // if we are in EditMode
                if (this.EditMode)
                {
                    // enable the Save and Cancel button
                    this.AddButton.Enabled = false;
                    this.EditButton.Enabled = false;
                    this.DeleteButton.Enabled = false;
                    this.DoneButton.Enabled = false;
                    this.EnumerationsListBox.Enabled = false;
                    this.SaveButton.Enabled = true;
                    this.CancelButton.Enabled = true;
                    this.SaveButton.Enabled = true;
                    this.FieldNameTextBox.Enabled = true;
                    this.DataTypeTextBox.Enabled = true;
                }
                else
                {
                    // Disable the Add, Edit, Delete and Finished Buttons
                    this.SaveButton.Enabled = false;
                    this.CancelButton.Enabled = false;
                    this.SaveButton.Enabled = false;
                    this.FieldNameTextBox.Enabled = false;
                    this.DataTypeTextBox.Enabled = false;
                    this.AddButton.Enabled = true;
                    this.EditButton.Enabled = true;
                    this.DeleteButton.Enabled = true;
                    this.DoneButton.Enabled = true;
                    this.EnumerationsListBox.Enabled = true;
                }

                // refresh everything
                this.Refresh();
            }
            #endregion

        #endregion

        #region Properties

            #region EditMode
            /// <summary>
            /// Are we currently in EditMode (only the Save or Cancel button is enable)
            /// </summary>
            public bool EditMode
            {
                get { return editMode; }
                set
                {
                    // set the value
                    editMode = value;

                    // Setup for EditMode
                    UIControl();
                }
            }
            #endregion

            #region Gateway
            /// <summary>
            /// The gateway to perform data operations
            /// </summary>
            internal Gateway Gateway
            {
                get { return gateway; }
                set { gateway = value; }
            }
            #endregion

            #region HasSelectedEnumeration
            /// <summary>
            /// Does this object have a selected enumeration ?
            /// </summary>
            public bool HasSelectedEnumeration
            {
                get
                {
                    // initial value
                    bool hasSelectedEnumeration = (this.SelectedEnumeration != null);

                    // return value
                    return hasSelectedEnumeration;
                }
            }
            #endregion

            #region SelectedEnumeration
            /// <summary>
            /// The enumeration that is being created or edited.
            /// </summary>
            public Enumeration SelectedEnumeration
            {
                get { return selectedEnumeration; }
                set
                {
                    // set the value
                    selectedEnumeration = value;

                    // display the selected enumeration
                    this.DisplaySelectedEnumeration();
                }
            }
            #endregion

            #region SelectedDataType
            /// <summary>
            /// This read only property returns the Data Type (Name)
            /// for the SelectedEnumeration.
            /// </summary>
            public string SelectedDataType
            {
                get
                {
                    // initial value
                    string dataType = "";

                    // if the SelectedEnumeration exists
                    if (this.HasSelectedEnumeration)
                    {
                        // set the return value
                        dataType = this.SelectedEnumeration.EnumerationName;
                    }

                    // return value
                    return dataType;
                }
            }
            #endregion

            #region SelectedFieldName
            /// <summary>
            /// This read only property returns the Field Name
            /// of the SelectedEnumeration
            /// </summary>
            public string SelectedFieldName
            {
                get
                {
                    // initial value
                    string fieldName = "";

                    // if the SelectedEnumeration exists
                    if (this.HasSelectedEnumeration)
                    {
                        // set the return value
                        fieldName = this.SelectedEnumeration.FieldName;
                    }

                    // return value
                    return fieldName;
                }
            }
            #endregion

            #region SelectedProject
            /// <summary>
            /// The SelectedProject being edited or created.
            /// </summary>
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
            }
            #endregion

        #endregion

    } 
    #endregion
    
}
