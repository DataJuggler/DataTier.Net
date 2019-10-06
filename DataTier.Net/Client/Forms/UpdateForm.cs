

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

    #region class UpdateForm
    /// <summary>
    /// This class is used to host the UpdateControl
    /// </summary>
    public partial class UpdateForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateForm' object.
        /// </summary>
        public UpdateForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Setup(bool showSQLUpdate)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(bool showSQLUpdate)
            {
                // Setup the control
                this.UpdateControl.Setup(showSQLUpdate);
            }
            #endregion
            
        #endregion

    }
    #endregion

}
