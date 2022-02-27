

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

namespace DataTierClient.Forms
{

    #region class SetupForm
    /// <summary>
    /// This form hosts the SetupControl
    /// </summary>
    public partial class SetupForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SetupForm' object.
        /// </summary>
        public SetupForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Properties

            #region UserCancelled
            /// <summary>
            /// This read only property returns the value for UserCancelled from the SetupControl.
            /// </summary>
            public bool UserCancelled
            {
                get
                {
                    // initial value
                    bool userCancelled = true;

                    // if the SetupControl exists
                    if (SetupControl != null)
                    {
                        // return value
                        userCancelled = SetupControl.UserCancelled;
                    }

                    // return value
                    return userCancelled;
                }
            }
        #endregion

        #endregion

    }
    #endregion

}
