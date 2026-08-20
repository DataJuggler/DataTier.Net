

#region using statements

using System.Windows.Forms;
using System;

#endregion

namespace DataTierClient.Forms
{

    #region class DisplayMessageForm
    /// <summary>
    /// This form is the host of the DisplayMessageControl
    /// </summary>
    public partial class DisplayMessageForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DisplayMessageForm' object.
        /// </summary>
        public DisplayMessageForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region DisplayMessageForm_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// event is fired when Display Message Form _ Key Down
            /// </summary>
            private void DisplayMessageForm_KeyDown(object sender, KeyEventArgs e)
            {
                // if Enter or Esc is pressed
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape))
                {
                    // Close this form
                    Close();
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region SetMessageText(string messageText, Exception error)
            /// <summary>
            /// Set Message Text
            /// </summary>
            public void Setup(string messageText, Exception error)
            {
                // Set the text
                DisplayMessageControl.Setup(messageText, error);
            }
            #endregion

        #endregion

    }
    #endregion

}
