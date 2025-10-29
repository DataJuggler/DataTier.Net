

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

    #region class GridColumnBuilderForm
    /// <summary>
    /// This form hosts the GridColumnBuilderControl
    /// </summary>
    public partial class GridColumnBuilderForm : Form
    {  
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'GridColumnBuilderForm' object.
        /// </summary>
        public GridColumnBuilderForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Setup(DTNTable table)
            /// <summary>
            /// Setup
            /// </summary>
            public void Setup(DTNTable table)
            {
                // if the Control exists
                if (this.GridColumnBuilderControl != null)
                {
                    // Set the SelectedTable
                    this.GridColumnBuilderControl.SelectedTable = table;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
