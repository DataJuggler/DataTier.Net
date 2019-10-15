

#region using statements

using DataGateway;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class CustomMethodsEditor
    /// <summary>
    /// This control is used to edit the Custom Methods for a project
    /// </summary>
    public partial class CustomMethodsEditor : UserControl, ITabButtonParent
    {
        
        #region Private Variables
        private List<Method> methodsList;
        private Method selectedMethod;
        private DTNTable selectedTable;
        private ActionTypeEnum actionType;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomMethodEditor' object.
        /// </summary>
        public CustomMethodsEditor()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region MethodsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
            /// <summary>
            /// event is fired when Methods List Box _ Mouse Double Click
            /// </summary>
            private void MethodsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                // get the index of the item clicked
                int index = this.MethodsListBox.IndexFromPoint(e.Location);
                
                // if the index was found
                if (index != System.Windows.Forms.ListBox.NoMatches)
                {
                    if ((this.HasSelectedTable) && (this.SelectedTable.HasMethods))
                    {
                        // if the index is in range
                        if (index < this.SelectedTable.Methods.Count)
                        {
                            // get the index
                            Method method = this.SelectedTable.Methods[index];

                            // if the method is the right way (just verifying before the wrong thing is edited
                            if (method.Name == MethodsListBox.Items[index].ToString())
                            {
                                // set to true
                                this.MethodsListBox.SelectedIndex = index;

                                // Set Edit to true and bail
                                Edit();
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region MethodsListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when a selection is made in the 'MethodsListBox_'.
            /// </summary>
            private void MethodsListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // if the value for HasMethodsList is true
                if ((HasMethodsList) && (MethodsListBox.SelectedIndex >= 0))
                {
                    // get the method
                    this.SelectedMethod = this.MethodsList[MethodsListBox.SelectedIndex];
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
        #endregion

        #region Methods

            #region DisplayMethods(int selectedIndex = -1)
            /// <summary>
            /// This method Display Methods
            /// </summary>
            public void DisplayMethods(int selectedIndex = -1)
            {
                // if the MethodsListBox exists and the MethodsList exists
                if ((this.MethodsListBox != null) && (this.MethodsList != null))
                {
                    // Clear the ListBox
                    this.MethodsListBox.Items.Clear();

                    // If the MethodsList collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(MethodsList))
                    {
                        // Iterate the collection of Method objects
                        foreach (Method method in MethodsList)
                        {
                            // Add this item
                            MethodsListBox.Items.Add(method);
                        }

                        // verify the index is in range
                        if (selectedIndex < MethodsListBox.Items.Count)
                        {
                            // set the selected index
                            MethodsListBox.SelectedIndex = selectedIndex;
                        }
                    }

                    // Enable or Disable Controls
                    UIEnable();
                }
            }
            #endregion
            
            #region Edit()
            /// <summary>
            /// This method Edit
            /// </summary>
            public void Edit()
            {
                // Set the ActionType
                this.ActionType = ActionTypeEnum.EditButtonClicked;

                // If the ParentCustomMethodsEditorForm object exists
                if (this.HasParentCustomMethodsEditorForm)
                {
                    // Close the parent form
                    this.ParentCustomMethodsEditorForm.Close();
                }
            }
            #endregion

            #region Setup(List<Method> methods)
            /// <summary>
            /// This method Sets up this control
            /// </summary>
            public void Setup(DTNTable selectedTable, List<Method> methods)
            {
                // store the args
                this.SelectedTable = selectedTable;
                this.MethodsList = methods;
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

                        // Set the ActionType
                        this.ActionType = ActionTypeEnum.AddButtonClicked;

                        // If the ParentCustomMethodsEditorForm object exists
                        if (this.HasParentCustomMethodsEditorForm)
                        {
                            // Close the parent form
                            this.ParentCustomMethodsEditorForm.Close();
                        }

                        // required
                        break;

                    case "Edit":

                        // Select Edit
                       Edit();

                        // required
                        break;

                    case "Delete":

                        // If the SelectedMethod object exists
                        if ((this.HasSelectedMethod) && (this.HasSelectedTable))
                        {
                            // Show the user a message
                            string message = "Are you sure you wish to delete this method? This action cannot be undone.";
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
                                bool deleted = gateway.DeleteMethod(this.selectedMethod.MethodId);

                                // if the value for deleted is true
                                if (deleted)
                                {
                                    // load the Methods for the SelectedTable
                                    this.SelectedTable.Methods = gateway.LoadMethodsForTable(this.SelectedTable.TableId);

                                    // Set the MethodsList
                                    MethodsList = this.SelectedTable.Methods;

                                    // Just to make sure the caller knows no action is required (should already be set to NoAction value)
                                    ActionType = ActionTypeEnum.NoAction;

                                    // Erase the SelectedMethod
                                    this.SelectedMethod = null;

                                    // Make sure the buttons are not enabled with a selected item
                                    MethodsListBox_SelectedIndexChanged(this, new EventArgs());
                                }
                            }
                        }

                        // required
                        break;
                }
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {  
                // Enable the Add Button if there is a SelectedTable that is not excluded
                this.AddButton.Enabled = ((this.HasSelectedTable) && (this.SelectedTable.HasMethods));
                
                // Enable the Edit and Delete Buttons if there is a SelectedMethod
                this.EditButton.Enabled = this.HasSelectedMethod;
                this.DeleteButton.Enabled = this.HasSelectedMethod;
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
            
            #region HasMethodsList
            /// <summary>
            /// This property returns true if this object has a 'MethodsList'.
            /// </summary>
            public bool HasMethodsList
            {
                get
                {
                    // initial value
                    bool hasMethodsList = (this.MethodsList != null);
                    
                    // return value
                    return hasMethodsList;
                }
            }
            #endregion
            
            #region HasParentCustomMethodsEditorForm
            /// <summary>
            /// This property returns true if this object has a 'ParentCustomMethodsEditorForm'.
            /// </summary>
            public bool HasParentCustomMethodsEditorForm
            {
                get
                {
                    // initial value
                    bool hasParentCustomMethodsEditorForm = (this.ParentCustomMethodsEditorForm != null);
                    
                    // return value
                    return hasParentCustomMethodsEditorForm;
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
            
            #region MethodsList
            /// <summary>
            /// This property gets or sets the value for 'MethodsList'.
            /// </summary>
            public List<Method> MethodsList
            {
                get { return methodsList; }
                set 
                { 
                    // set the value
                    methodsList = value;

                    // Display the methods
                    DisplayMethods();
                }
            }
            #endregion
            
            #region ParentCustomMethodsEditorForm
            /// <summary>
            /// This read only property returns the value for 'ParentCustomMethodsEditorForm'.
            /// </summary>
            public CustomMethodsEditorForm ParentCustomMethodsEditorForm
            {
                get
                {
                    // initial value
                    CustomMethodsEditorForm customMethodsEditorForm = this.ParentForm as CustomMethodsEditorForm;
                    
                    // return value
                    return customMethodsEditorForm;
                }
            }
            #endregion
            
            #region SelectedMethod
            /// <summary>
            /// This property gets or sets the value for 'SelectedMethod'.
            /// </summary>
            public Method SelectedMethod
            {
                get { return selectedMethod; }
                set 
                { 
                    selectedMethod = value;
                }
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

        #endregion
    }
    #endregion

}
