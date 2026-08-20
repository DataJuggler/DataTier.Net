

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
        private Exception error;
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
            
            #region CopyDetailsButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CopyDetailsButton' is clicked.
            /// </summary>
            private void CopyDetailsButton_Click(object sender, EventArgs e)
            {
                // if the value for HasError is true
                if (HasError)
                {
                    // Copy the message
                    Clipboard.SetText(Error.ToString());

                    // Show the Copied Icon
                    CopiedIcon.Visible = true;

                    // Start the timer
                    CopyTimer.Start();
                }
            }
            #endregion
            
            #region CopyTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Copy Timer _ Tick
            /// </summary>
            private void CopyTimer_Tick(object sender, EventArgs e)
            {
                // only run once
                CopyTimer.Stop();

                // Hide
                CopiedIcon.Visible = false;
            }
            #endregion
            
            #region DisplayMessageControl_Resize(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Display Message Control _ Resize
            /// </summary>
            private void DisplayMessageControl_Resize(object sender, EventArgs e)
            {
                // Set the width
                ButtonLeftMarginPanel.Width = (MessageLabel.Width - (OKButton.Width / 2)) / 2;

                // Set the Left of the DisplayMessageControl
                CopyDetailsButton.Left = ButtonLeftMarginPanel.Width + OKButton.Width + 32;
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

        #region Methods

            #region Setup(string messageText, Exception exception)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Setup(string messageText, Exception exception)
            {
                // store the args
                this.MessageText = messageText;
                this.Error = exception;

                // Show the CopyDetails button if an error exists
                CopyDetailsButton.Visible = HasError;
            }
            #endregion
            
        #endregion

        #region Properties

            #region Error
            /// <summary>
            /// This property gets or sets the value for 'Error'.
            /// </summary>
            public Exception Error
            {
                get { return error; }
                set { error = value; }
            }
            #endregion
            
            #region HasError
            /// <summary>
            /// This property returns true if this object has an 'Error'.
            /// </summary>
            public bool HasError
            {
                get
                {
                    // initial value
                    bool hasError = (Error != null);

                    // return value
                    return hasError;
                }
            }
            #endregion
            
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
