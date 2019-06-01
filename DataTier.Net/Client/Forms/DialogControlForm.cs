

#region using statements

using ObjectLibrary.Enumerations;
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

namespace DataTierClient.Forms
{

    #region class DialogControlForm
    /// <summary>
    /// This form is the host of the DialogControl
    /// </summary>
    public partial class DialogControlForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DialogControlForm' object.
        /// </summary>
        public DialogControlForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Methods
        
            #region Setup(string fieldName, string tableName, string procedureName, string title)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(string fieldName, string tableName, string procedureName, string title)
            {
                // display the title
                this.Text = title;

                // Change out the Text
                this.DialogControl.Setup(fieldName, tableName, procedureName);
            }
            #endregion

            #region Setup(string message)
            /// <summary>
            /// This method Setups this control with the text to display.
            /// </summary>
            public void Setup(string message, string title)
            {  
                // display the title
                this.Text = title;

                // Change out the Text
                this.DialogControl.Setup(message);
            }
        #endregion

        #endregion

        #region Properties

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

            #region UserResponse
            /// <summary>
            /// This read only property returns the UserResponse from the DialogControl.
            /// </summary>
            public UserResponseEnum UserResponse
            {
                get
                {
                    // initial value
                    UserResponseEnum userResponse = UserResponseEnum.NoResponse;

                    // If the DialogControl object exists
                    if (DialogControl != null)
                    {
                        // set the return value
                        userResponse = DialogControl.UserResponse;
                    }

                    // return value
                    return userResponse;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
