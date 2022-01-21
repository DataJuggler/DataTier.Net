
#region using statements

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Enumerations;
using DataTierClient.Controls.Images;

#endregion

namespace DataTierClient.Controls
{

    #region class WizardStatusControl : UserControl, ITabButtonParent
    /// <summary>
    /// This object is designed to set the active control
    /// being edited in the ProjectWizardControl.
    /// </summary>
    public partial class WizardStatusControl : UserControl, ITabButtonParent
    {
    
        #region Private Variables
        private TabButton selectedButton;
        #endregion
    
        #region Constructor
        /// <summary>
        /// Create a new instance of a WizardStatusControl.
        /// </summary>
        public WizardStatusControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations For This Object
            Init();
        }
        #endregion
        
        #region Events

            #region ControllersTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the ControllersTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ControllersTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if(this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.ControllersTab);
                }
            } 
            #endregion

            #region DatabasesTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the DatabasesTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DatabasesTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.DatabasesTab);
                }
            } 
            #endregion

            #region DataManagerTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the DataManagerTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataManagerTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.DataManagerTab);
                }
            } 
            #endregion

            #region DataObjectsTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the DataObjectsTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataObjectsTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {  
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.DataObjectsTab);
                }
            } 
            #endregion

            #region DataOperationsTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the DataOperationsTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DataOperationsTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.DataOperationsTab);
                }       
            }
            #endregion

            #region ProjectsTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the ProjectsTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            internal void ProjectsTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.ProjectsTab);
                }
            } 
            #endregion

            #region ReadersTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the ReadersTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReadersTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.ReadersTab);
                }
            } 
            #endregion

            #region WritersTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the WritersTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WritersTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.WritersTab);
                }
            } 
            #endregion

            #region StoredProceduresTab_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the StoredProceduresTab button
            /// is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void StoredProceduresTab_Click(object sender, EventArgs e)
            {
                // if this object has a ParentProjectWizard
                if (this.HasParentProjectWizard)
                {
                    // Notify parent that this button was selected.
                    this.ParentProjectWizard.ButtonSelected(ActiveControlEnum.StoredProceduresTab);
                }
            } 
            #endregion
        
        #endregion 

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object
            /// </summary>
            private void Init()
            {
                // Default To Left
                this.Dock = DockStyle.Left;   
            }
            #endregion

            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // Set Button Images
                SetSelectedButton(tabButton);
                
                // determine action by the button text
                switch (tabButton.ButtonText)
                {
                    case "Projects":

                        // Call the event
                        ProjectsTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Databases":

                        // Call the event
                        DatabasesTab_Click(this, new EventArgs());

                        // required
                        break;
                        
                    case "Data Objects":

                        // Call the event
                        DataObjectsTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Data Manager":

                        // Call the event
                        DataManagerTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Data Operations":

                        // Call the event
                        DataOperationsTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Controllers":

                        // Call the event
                        ControllersTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Readers":

                        // Call the event
                        ReadersTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Writers":

                        // Call the event
                        WritersTab_Click(this, new EventArgs());

                        // required
                        break;

                    case "Stored Procedures":

                        // Call the event
                        StoredProceduresTab_Click(this, new EventArgs());

                        // required
                        break;
                }
            }
            #endregion

            #region SetSelectedButton(TabButton tabButton)
            /// <summary>
            /// This method sets the selected button by passing in
            /// the ActiveControlEnum from the wizard.
            /// </summary>
            /// <param name="tabButton"></param>
            internal void SetSelectedButton(ActiveControlEnum selectedControl)
            {
                // initial value
                TabButton tabButton = null;
               
                // Determine Which Button To Make Visible
                switch (selectedControl)
                {
                    case ActiveControlEnum.ProjectsTab:

                        // set tabButton
                        tabButton = this.ProjectsTab;

                        // required
                        break;

                    case ActiveControlEnum.DatabasesTab:

                        // set tabButton
                        tabButton = this.DatabasesTab;

                        // required
                        break;

                    case ActiveControlEnum.DataObjectsTab:

                        // set tabButton
                        tabButton = this.DataObjectsTab;

                        // required
                        break;

                    case ActiveControlEnum.DataManagerTab:

                        // set tabButton
                        tabButton = this.DataManagerTab;

                        // required
                        break;

                    case ActiveControlEnum.DataOperationsTab:

                        // set tabButton
                        tabButton = this.DataOperationsTab;

                        // required
                        break;

                    case ActiveControlEnum.ControllersTab:

                        // set tabButton
                        tabButton = this.ControllersTab;

                        // required
                        break;

                    case ActiveControlEnum.ReadersTab:

                        // set tabButton
                        tabButton = this.ReadersTab;

                        // required
                        break;

                    case ActiveControlEnum.WritersTab:

                        // set tabButton
                        tabButton = this.WritersTab;

                        // required
                        break;

                    case ActiveControlEnum.StoredProceduresTab:

                        // set tabButton
                        tabButton = this.StoredProceduresTab;

                        // required
                        break;
                }
                
                // set the tabButton
                if(tabButton != null)
                {
                    // Set the tabButton
                    this.SetSelectedButton(tabButton);
                }
                
                // Refresh
                this.Refresh();
            }
            #endregion

            #region SetSelectedButton(TabButton tabButton)
            /// <summary>
            /// This method selects the tabButton passed in and unselects
            /// all other buttons.
            /// </summary>
            /// <param name="tabButton"></param>
            internal void SetSelectedButton(TabButton tabButton)
            {
                // loop through each control
                foreach(Control control in this.Controls)
                {
                    // get the current control cast as a TabControl
                    TabButton tabControl = control as TabButton;
                    
                    // if this is a tabControl
                    if(tabControl != null)
                    {
                        // if this is the selected control
                        tabControl.Selected = (tabControl.ButtonText == tabButton.ButtonText);
                        
                        // if this button is selected
                        if(tabButton.Selected)
                        {
                            // Set the SelectedButton
                            this.SelectedButton = tabButton;
                        }
                    }
                } 
                
                // Refresh
                this.Refresh();              
            }
            #endregion
        
        #endregion
        
        #region Properties

            #region HasParentProjectWizard
            /// <summary>
            /// Does this object have a ParentProjectWizard.
            /// </summary>
            private bool HasParentProjectWizard
            {
                get
                {
                    // initial value
                    bool hasParentContactWizard = (this.ParentProjectWizard != null);

                    // return value
                    return hasParentContactWizard;
                }
            } 
            #endregion
            
            #region ParentProjectWizard
            /// <summary>
            /// The parent of this control
            /// </summary>
            public ProjectWizardControl ParentProjectWizard
            {
                get
                {
                    // initial value
                    ProjectWizardControl parentProjectWizard = (this.Parent) as ProjectWizardControl;

                    // return value
                    return parentProjectWizard;
                }
            }
            #endregion

            #region SelectedButton
            /// <summary>
            /// The Button That is Currently Selected
            /// </summary>
            public TabButton SelectedButton
            {
                get { return selectedButton; }
                set { selectedButton = value; }
            } 
            #endregion
        
        #endregion
        
    }
    #endregion
    
}
