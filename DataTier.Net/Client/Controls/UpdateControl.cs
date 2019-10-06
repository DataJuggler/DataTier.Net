

#region using statements

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

    #region class UpdateControl
    /// <summary>
    /// This control is used to notify the user changes have occurred.
    /// </summary>
    public partial class UpdateControl : UserControl
    {
        
        #region Private Variables
        private bool showSQLUpdate;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateControl' object.
        /// </summary>
        public UpdateControl()
        {
            // Create Controls           
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Display()
            /// <summary>
            /// This method Display
            /// </summary>
            public void Display()
            {
                // Show the NoChanges label
                NoChangesLabel.Visible = !ShowSQLUpdate;
                SQLUpdateInstructions.Visible = ShowSQLUpdate;
            }
            #endregion
            
            #region Setup(bool showSQLUpdate)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(bool showSQLUpdate)
            {
                // store the arg
                ShowSQLUpdate = showSQLUpdate;
            }
            #endregion
            
        #endregion
        
        #region Events
            
            #region OkButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'OkButton' is clicked.
            /// </summary>
            private void OkButton_Click(object sender, EventArgs e)
            {
                // Close the ParentForm
                this.ParentForm.Close();
            }
            #endregion
            
            #region OkButton_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Ok Button _ Mouse Enter
            /// </summary>
            private void OkButton_MouseEnter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region OkButton_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Ok Button _ Mouse Leave
            /// </summary>
            private void OkButton_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
        #endregion

        #endregion

        #region Properties

            #region ShowSQLUpdate
            /// <summary>
            /// This property gets or sets the value for 'ShowSQLUpdate'.
            /// </summary>
            public bool ShowSQLUpdate
            {
                get { return showSQLUpdate; }
                set { showSQLUpdate = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
