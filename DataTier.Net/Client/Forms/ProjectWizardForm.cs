

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Forms
{

    #region class ProjectWizardForm
    /// <summary>
    /// This class is used to host the ProjectWizardControl
    /// </summary>
    public partial class ProjectWizardForm : Form
    {
        
        #region Private Variables
        private bool formActivated;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a ProjectWizardForm.
        /// </summary>
        public ProjectWizardForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region ProjectWizardForm_Activated(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Project Wizard Form _ Activated
            /// </summary>
            private void ProjectWizardForm_Activated(object sender, EventArgs e)
            {
                // if the form has not been Activated yet
                if (!this.FormActivated)
                {
                    // Set Focus To The ProjectNameControl
                    this.ProjectWizardControl.SetFocusToProjectNameControl();
                }

                // set FormActivated to true
                this.FormActivated = true;
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region FormActivated
            /// <summary>
            /// This property gets or sets the value for 'FormActivated'.
            /// </summary>
            public bool FormActivated
            {
                get { return formActivated; }
                set { formActivated = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
