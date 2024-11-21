

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

#endregion

namespace DataTierClient.Controls
{

    #region class DisplayMessageControl
    /// <summary>
    /// This method is used to display a message and looks better than a MessageBox..
    /// </summary>
    public partial class DisplayMessageControl : UserControl
    {
        
        #region Private Variables
        private string messageText;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DisplayMessageControl' object.
        /// </summary>
        public DisplayMessageControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region DisplayMessageControl_Resize(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Display Message Control _ Resize
            /// </summary>
            private void DisplayMessageControl_Resize(object sender, EventArgs e)
            {
                // Set the width
                ButtonLeftMarginPanel.Width = (MessageLabel.Width - (OKButton.Width / 2)) / 2;
            }
            #endregion
            
            #region OKButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'OKButton' is clicked.
            /// </summary>
            private void OKButton_Click(object sender, EventArgs e)
            {
                // If the ParentForm object exists
                if (ParentForm != null)
                {
                    // Close the ParentForm
                    ParentForm.Close();
                }
            }
            #endregion
            
            #region OKButton_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when OK Button _ Mouse Enter
            /// </summary>
            private void OKButton_MouseEnter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region OKButton_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when OK Button _ Mouse Leave
            /// </summary>
            private void OKButton_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
        #endregion

        #region Properties
        
            #region MessageText
            /// <summary>
            /// This property gets or sets the value for 'MessageText'.
            /// </summary>
            public string MessageText
            {
                get { return messageText; }
                set 
                {
                    messageText = value;

                    // Display the text
                    MessageLabel.Text = value;
                }
            }
        #endregion

        #endregion
    }
    #endregion

}
