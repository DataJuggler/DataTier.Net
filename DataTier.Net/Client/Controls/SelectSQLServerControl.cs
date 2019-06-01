

#region using statements

using System;
using System.Windows.Forms;
using DataTierClient.Forms;
using DataTierClient.Controls.Interfaces;
using DataTierClient.ClientUtil;
using System.Threading;

#endregion 


namespace DataTierClient.Controls
{

    #region class SelectSQLServerControl
    /// <summary>
    /// This control selects a sql Server from a list of SQLServers.
    /// </summary>
    public partial class SelectSQLServerControl : UserControl, ISaveCancelControl
    {
    
        #region Private Variables
        private TextBox selectionTextBox;
        private bool loading;
        #endregion
    
        #region Constructor
        /// <summary>
        /// Create a new instance of a SelectSQLServerControl
        /// </summary>
        public SelectSQLServerControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this control
            Init();
        }
        #endregion
        
        #region Events

            #region ServersListBox_DoubleClick(object sender, EventArgs e)
            /// <summary>
            /// This method selects an item.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ServersListBox_DoubleClick(object sender, EventArgs e)
            {
                // Save the selected servere
                this.OnSave();
            }
            #endregion

            #region ServersListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// This method enables the Select button if we have
            /// a selected item
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Enable Controls
                UIEnable();
            }
            #endregion
        
        #endregion
        
        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            private void Init()
            {  
                // Enable Controls
                UIEnable();
            }
            #endregion

            #region Loading
            /// <summary>
            /// Is this control still loading
            /// </summary>
            public bool Loading
            {
                get { return loading; }
                set { loading = value; }
            }
            #endregion

            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// </summary>
            public void OnSave()
            {
                // get the serverName
                string serverName = this.ServersListBox.SelectedItem as string;

                // if a selectin was made
                if ((!String.IsNullOrEmpty(serverName)) && (this.SelectionTextBox != null))
                {
                    // Set the text. 
                    this.SelectionTextBox.Text = serverName;

                    // if the parent form exists
                    if (this.HasParentSelectSQLServerForm)
                    {
                        // Close the form
                        this.ParentSelectSQLServerForm.Close();
                    }
                }
            }
            #endregion

            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // if the parent form exists
                if (this.HasParentSelectSQLServerForm)
                {
                    // Close the form
                    this.ParentSelectSQLServerForm.Close();
                }
            }
            #endregion

            #region Setup(TextBox textBoxArg)
            /// <summary>
            /// This method prepares this control to be shown to the user.
            /// </summary>
            /// <param name="sqlServersArg"></param>
            /// <param name="textBoxArg"></param>
            internal void Setup(TextBox textBoxArg)
            {
                // Set SelectionTextBox
                this.SelectionTextBox = textBoxArg;
                
                // Load sql Servers To ListBox
                SQLSMOHelper.GetSQLServers(this.ServersListBox);
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// Enable Controls on this control.
            /// </summary>
            private void UIEnable()
            {
                // set the enable property
                bool enabled = (this.ServersListBox.SelectedItem != null);

                // enable the control
                this.SaveCancelControl.EnableSaveButton(enabled);
            }
            #endregion
        
        #endregion
        
        #region Properties

            #region HasParentSelectSQLServerForm
            /// <summary>
            /// Does this control have a ParentSelectSQLServerForm
            /// </summary>
            internal bool HasParentSelectSQLServerForm
            {   
                get
                {
                    // initial value
                    bool hasParentSelectSQLServerForm = (this.ParentSelectSQLServerForm != null);
                    
                    // return value
                    return hasParentSelectSQLServerForm;
                }
            }
            #endregion

            #region ParentSelectSQLServerForm
            /// <summary>
            /// The ParentSelectSQLServerForm
            /// </summary>
            public SelectSQLServerForm ParentSelectSQLServerForm
            {
                get
                {
                    // initial value
                    SelectSQLServerForm sqlServerForm = this.ParentForm as SelectSQLServerForm;
                    
                    // return value
                    return sqlServerForm;
                }
            }
            #endregion

            #region SelectionTextBox
            /// <summary>
            /// The TextBox to place the selected ServerName in.
            /// </summary>
            public TextBox SelectionTextBox
            {
                get { return selectionTextBox; }
                set { selectionTextBox = value; }
            }
            #endregion
        
        #endregion
        
    }
    #endregion
    
}
