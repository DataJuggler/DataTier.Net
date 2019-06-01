

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

    #region class NewStoredProcedureEditorForm
    /// <summary>
    /// This form is used to host the NewStoredProcedureEditor control. 
    /// </summary>
    public partial class NewStoredProcedureEditorForm : Form
    {

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'NewProcedureEditorForm' object.
        /// </summary>
        public NewStoredProcedureEditorForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Setup(MethodInfo methodInfo, Project openProject, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null)
            /// <summary>
            /// This method prepares the NewProcedureEditor control.
            /// </summary>
            public void Setup(MethodInfo methodInfo, Project openProject, CustomReader customReader = null, DTNField orderByField = null, FieldSet orderByFieldSet = null)
            {
                // If the NewStoredProcedureEditor object exists
                if (NewStoredProcedureEditor != null)
                {
                    // Setup the control
                    this.NewStoredProcedureEditor.Setup(methodInfo, openProject, customReader, orderByField, orderByFieldSet);
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
