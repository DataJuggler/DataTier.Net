

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

    #region class DataEditorForm
    /// <summary>
    /// This form is used to host the DataEditorControl
    /// </summary>
    public partial class DataEditorForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DataEditorForm' object.
        /// </summary>
        public DataEditorForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region GetChangesSet()
            /// <summary>
            /// This method returns the Changes Set
            /// </summary>
            public ChangesSet GetChangesSet()
            {
                // initial value
                ChangesSet changesSet = null;

                // If the DataEditorControl object exists
                if (DataEditorControl != null)
                {
                    // set the return value
                    changesSet = DataEditorControl.GetChangesSet();
                }
                
                // return value
                return changesSet;
            }
            #endregion
            
            #region Setup(Project openProject)
            /// <summary>
            /// This method is used to setup the tables on the DataEditorControl
            /// </summary>
            public void Setup(Project openProject)
            {
                // setup the Tables
                this.DataEditorControl.Setup(openProject);
            }
            #endregion

        #endregion

        #region Properties

            #region Tables
            /// <summary>
            /// This read only property returns the Tables from the DataEditor.OpenProject
            /// </summary>
            public List<DTNTable> Tables
            {
                get
                {
                    // initial value
                    List<DTNTable> tables = null;

                    // if the DataEditorControl exists
                    if (this.DataEditorControl != null)
                    {
                        // Set the return value
                        tables = this.DataEditorControl.Tables;
                    }

                    // return value
                    return tables;
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

                    // if DataEditorControl exists
                    if (DataEditorControl != null)
                    {
                        // set the return value
                        userCancelled = DataEditorControl.UserCancelled;
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
