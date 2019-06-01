

#region using statements

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

    #region class CustomReadersEditorForm
    /// <summary>
    /// This form is used to host the CustomReadersEditorControl.
    /// </summary>
    public partial class CustomReadersEditorForm : Form
    {  
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'CustomReadersEditorForm' object.
        /// </summary>
        public CustomReadersEditorForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Setup(Project openProject, DTNTable selectedTable, CustomReader selectedReader = null)
            /// <summary>
            /// This method Setup
            /// </summary>
            public void Setup(Project openProject, DTNTable selectedTable, CustomReader selectedReader = null)
            {
                // Setup the form
                CustomReadersEditor.Setup(openProject, selectedTable, selectedReader);
            }
            #endregion
            
        #endregion

    }
    #endregion

}
