

#region using statements

using DataJuggler.Net;
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

    #region class ConfirmRemovalForm
    /// <summary>
    /// This form is used to host the ConfirmRemovalControl
    /// </summary>
    public partial class ConfirmRemovalForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ConfirmRemovalForm' object.
        /// </summary>
        public ConfirmRemovalForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region GetDeleteFiles()
            /// <summary>
            /// This method returns the Delete Files ();
            /// </summary>
            public bool GetDeleteFiles()
            {
                // initial value
                bool deleteFiles = false;

                if (this.ConfirmRemovalControl != null)
                {
                    // initial value
                    deleteFiles = this.ConfirmRemovalControl.DeleteFiles;
                }
                
                // return value
                return deleteFiles;
            }
            #endregion
            
            #region GetProjectFileManager()
            /// <summary>
            /// This method returns the Project File Manager
            /// </summary>
            public ProjectFileManager GetProjectFileManager()
            {
                // initial value
                ProjectFileManager projectFileManager = null;

                // if the control exists
                if (this.ConfirmRemovalControl != null)
                {
                    // Set the ProjectFileManager
                    projectFileManager = this.ConfirmRemovalControl.ProjectFileManager;
                }
                
                // return value
                return projectFileManager;
            }
            #endregion
            
            #region Setup(ProjectFileManager projectFileManager, string projectFolder)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Setup(ProjectFileManager projectFileManager, string projectFolder)
            {
                // Setup the control
                this.ConfirmRemovalControl.Setup(projectFileManager, projectFolder);
            }
            #endregion

        #endregion

        #region Properties

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

                    // if ConfirmRemovalControl exists
                    if (ConfirmRemovalControl != null)
                    {
                        // set the return value
                        userCancelled = ConfirmRemovalControl.UserCancelled;
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
