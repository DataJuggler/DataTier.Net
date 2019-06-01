

#region using statements

using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using DataJuggler.Net;

#endregion

namespace DataTierClient.Forms
{

    #region VisualStudioProjectUpdateForm : Form
    /// <summary>
    /// This form is used to host the VisualStudioUpdateControl
    /// to update your VisualStudioSolution to include the files
    /// that were just generated after a build with DataTier.Net.
    /// This is only needed to be run if new files were added to the 
    /// project.
    /// </summary>
    public partial class VisualStudioProjectUpdateForm : Form
    {
    
        #region Private Variables
        private bool userCancelled;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'VisualStudioProjectUpdateForm' object.
        /// </summary>
        public VisualStudioProjectUpdateForm()
        {
            // Create controls
            InitializeComponent();
            
            // perform initializations for this object.
            Init();
        }
        #endregion
        
        #region Methods

            #region Init()
            /// <summary>
            /// This method is used to perform initializatons for this object.
            /// </summary>
            private void Init()
            {
                // default to user cancelled.
                this.UserCancelled = true;
            } 
            #endregion

            #region Setup(Project currentProject, IList<ProjectFile> files, bool removalMode = false)
            /// <summary>
            /// This method prepares the VisualStudioProjectUpdateControl.
            /// </summary>
            /// <param name="currentProject"></param>
            public void Setup(Project currentProject, IList<ProjectFile> files, bool removalMode = false)
            {
                // setup the control
                this.VisualStudioProjectUpdateControl.Setup(currentProject, files, removalMode);
            }  
            #endregion
        
        #endregion
        
        #region Properties

            #region UserCancelled
            /// <summary>
            /// Did the user cancel this update?
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            } 
            #endregion
        
        #endregion

    } 
    #endregion
    
}
