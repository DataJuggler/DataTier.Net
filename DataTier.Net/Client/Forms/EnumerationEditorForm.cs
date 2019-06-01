

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;

#endregion

namespace DataTierClient.Forms
{

    #region class EnumerationEditorForm : Form
    /// <summary>
    /// This form is used to host the EnumerationEditor control.
    /// </summary>
    public partial class EnumerationEditorForm : Form
    {
    
        #region Constructor
        /// <summary>
        /// Create a new instance of an EnumerationEditorForm()
        /// </summary>
        public EnumerationEditorForm()
        {
            // Create Controls
            InitializeComponent();
        } 
        #endregion
        
        #region Methods

            #region Setup(Project selectedProject)
            /// <summary>
            /// This method is used to setup this control. 
            /// </summary>
            /// <param name="selectedProject"></param>
            public void Setup(Project selectedProject)
            {
                // Call the same method on the control.
                this.EnumerationEditor.Setup(selectedProject);
            }
            #endregion
        
        #endregion

    } 
    #endregion
	
}