

#region using statements

using DataTierClient.Forms;
using ObjectLibrary.Enumerations;
using System;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class DialogControl
    /// <summary>
    /// This control is used to capture a user's response in a more graphical way than a MessageBox DialogResult.
    /// </summary>
    public partial class DialogControl : UserControl
    {
        
        #region Private Variables
        private UserResponseEnum userResponse;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DialogControl' object.
        /// </summary>
        public DialogControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
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
            
            #region NoButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'NoButton' is clicked.
            /// </summary>
            private void NoButton_Click(object sender, EventArgs e)
            {
                // Set the return value
                this.UserResponse = UserResponseEnum.Cancelled;

                // Close the parent form
                Close();
            }
            #endregion
            
            #region YesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'YesButton' is clicked.
            /// </summary>
            private void YesButton_Click(object sender, EventArgs e)
            {
                // Set the return value
                this.UserResponse = UserResponseEnum.Confirmed;

                // Close the parent form
                Close();
            }
            #endregion
            
        #endregion

        #region Methods

            #region Close()
            /// <summary>
            /// This method Close
            /// </summary>
            public void Close()
            {
                // If the ParentDialogControlForm object exists
                if (this.HasParentDialogControlForm)
                {
                    // Close the parent form
                    this.ParentDialogControlForm.Close();
                }
            }
            #endregion
            
            #region Setup(string fieldName, string tableName, string procedureName)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(string fieldName, string tableName, string procedureName)
            {
                // Change out the Text
                this.MessageLabel.Text = this.MessageLabel.Text.Replace("[FieldName]", fieldName).Replace("[TableName]", tableName).Replace("[ProcedureName]", procedureName);
            }
            #endregion

            #region Setup(string message)
            /// <summary>
            /// This method Setups this control with the text to display.
            /// </summary>
            public void Setup(string message)
            {
                // Change out the Text
                this.MessageLabel.Text = message;
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasParentDialogControlForm
            /// <summary>
            /// This property returns true if this object has a 'ParentDialogControlForm'.
            /// </summary>
            public bool HasParentDialogControlForm
            {
                get
                {
                    // initial value
                    bool hasParentDialogControlForm = (this.ParentDialogControlForm != null);
                    
                    // return value
                    return hasParentDialogControlForm;
                }
            }
            #endregion
            
            #region ParentDialogControlForm
            /// <summary>
            /// This read only returns the ParentForm cast as a DialogControlForm.
            /// </summary>
            public DialogControlForm ParentDialogControlForm
            {
                get
                {
                    // initial value
                    DialogControlForm parentDialogControlForm = this.ParentForm as DialogControlForm;

                    // return value
                    return parentDialogControlForm;
                }
            }
            #endregion

            #region UserResponse
            /// <summary>
            /// This property gets or sets the value for 'UserResponse'.
            /// </summary>
            public UserResponseEnum UserResponse
            {
                get { return userResponse; }
                set { userResponse = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
