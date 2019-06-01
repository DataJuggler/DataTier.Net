

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net;
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

    #region class ConfirmChangesForm
    /// <summary>
    /// This form is used to host the ConfirmChangesControl
    /// </summary>
    public partial class ConfirmChangesForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ConfirmChangesForm' object.
        /// </summary>
        public ConfirmChangesForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods
            
            #region Setup(MethodInfo methodInfo, Project project)
            /// <summary>
            /// This method prepares the ConfirmChangesControl to be shown
            /// </summary>
            public void Setup(MethodInfo methodInfo, Project project)
            {
                // If the ConfirmChangesControl object exists
                if (ConfirmChangesControl != null)
                {
                    // Setup the ConfirmChangesControl
                    ConfirmChangesControl.Setup(methodInfo, project);
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region CustomReaderMustBeIncluded
            /// <summary>
            /// This read only property returns the value for 'CustomReaderMustBeIncluded'.
            /// </summary>
            public bool CustomReaderMustBeIncluded
            {
                get
                {
                    // initial value
                    bool customReaderMustBeIncluded = false;

                    // If the ConfirmChangesControl object exists
                    if (NullHelper.Exists(ConfirmChangesControl))
                    {
                        // set the return value
                        customReaderMustBeIncluded = ConfirmChangesControl.CustomReaderMustBeIncluded;
                    }
                    
                    // return value
                    return customReaderMustBeIncluded;
                }
            }
            #endregion

            #region HasProjectFileManager
            /// <summary>
            /// This property returns true if this object has a 'ProjectFileManager'.
            /// </summary>
            public bool HasProjectFileManager
            {
                get
                {
                    // initial value
                    bool hasProjectFileManager = (this.ProjectFileManager != null);
                    
                    // return value
                    return hasProjectFileManager;
                }
            }
            #endregion
            
            #region ProjectFileManager
            /// <summary>
            /// This read only property returns the value for 'ProjectFileManager'.
            /// </summary>
            public ProjectFileManager ProjectFileManager
            {
                get
                {
                    // initial value
                    ProjectFileManager projectFileManager = null;
                    
                    // If the ConfirmChangesControl object exists
                    if (ConfirmChangesControl != null)
                    {
                        // set the return value
                        projectFileManager = ConfirmChangesControl.ProjectFileManager;
                    }
                    
                    // return value
                    return projectFileManager;
                }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This read only property returns the value of UserCancelled from the DataEditorControl
            /// </summary>
            public bool UserCancelled
            {
                get
                {
                    // initial value
                    bool userCancelled = true;

                    // if ConfirmChangesControl exists
                    if (ConfirmChangesControl != null)
                    {
                        // set the return value
                        userCancelled = ConfirmChangesControl.UserCancelled;
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
