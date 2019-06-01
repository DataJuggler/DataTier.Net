
#region using statements

using DataTierClient.Objects;
using ObjectLibrary.BusinessObjects;
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

    #region class CustomMethodEditorForm
    /// <summary>
    /// This form is used to host the CustomMethodEditor control.
    /// </summary>
    public partial class CustomMethodEditorForm : Form
    {

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomMethodEditorForm' object.
        /// </summary>
        public CustomMethodEditorForm()
        {
            // Create Controls
            InitializeComponent();

            // Default to true
            this.CustomMethodEditor.UserCancelled = true;
        }
        #endregion

        #region Methods

            #region Setup(DTNTable table, Project selectedProject)
            /// <summary>
            /// Prepares the CustomMethodEditor to be run
            /// </summary>
            public void Setup(DTNTable table, Project selectedProject, Method selectedMethod = null)
            {
                // Pass in the table to the control
                this.CustomMethodEditor.Setup(table, selectedProject, selectedMethod);
            }
            #endregion

        #endregion

        #region Properties

            #region HasMethodInfo
            /// <summary>
            /// This property returns true if this object has a 'MethodInfo'.
            /// </summary>
            public bool HasMethodInfo
            {
                get
                {
                    // initial value
                    bool hasMethodInfo = (this.MethodInfo != null);
                    
                    // return value
                    return hasMethodInfo;
                }
            }
            #endregion
            
            #region MethodInfo
            /// <summary>
            /// This read only property returns the value for 'MethodInfo'.
            /// </summary>
            public MethodInfo MethodInfo
            {
                get 
                { 
                    // initial value
                    MethodInfo methodInfo = null;

                    // If the CustomMethodEditor object exists
                    if (CustomMethodEditor != null)
                    {
                        // get the methodInfo from the control
                        methodInfo = CustomMethodEditor.MethodInfo;
                    }

                    // return value
                    return methodInfo;
                }
            }
            #endregion

            #region UserCancelled
            /// <summary>
            /// This read only property returns the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get 
                { 
                    // initial value (default to true)
                    bool userCancelled = true;

                    // If the CustomMethodEditor object exists
                    if (CustomMethodEditor != null)
                    {
                        // did the user cancel or not
                        userCancelled = CustomMethodEditor.UserCancelled;
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
