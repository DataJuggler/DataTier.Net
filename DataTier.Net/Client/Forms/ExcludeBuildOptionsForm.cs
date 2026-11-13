

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
using ObjectLibrary.BusinessObjects;

#endregion

namespace DataTierClient.Forms
{

    #region class ExcludeBuildOptionsForm
    /// <summary>
    /// This class hosts the ExcludeBuildOptionsControls
    /// </summary>
    public partial class ExcludeBuildOptionsForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ExcludeBuildOptionsForm' object.
        /// </summary>
        public ExcludeBuildOptionsForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Methods
            
            #region Setup(DTNTable tablle)
            /// <summary>
            /// Setup
            /// </summary>
            public void Setup(DTNTable tablle)
            {
                // pase the control
                this.ExcludeBuildOptionsControl.Setup(tablle);
            }
            #endregion
            
        #endregion
        
        #region Properties

            #region UserCancelled
            /// <summary>
            /// This read only property returns the value of UserCancelled from the object ExcludeBuildOptionsControl.
            /// </summary>
            public bool UserCancelled
            {

                get
                {
                    // initial value
                    bool userCancelled = false;

                    // if ExcludeBuildOptionsControl exists
                    if (ExcludeBuildOptionsControl != null)
                    {
                        // set the return value
                        userCancelled = ExcludeBuildOptionsControl.UserCancelled;
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
