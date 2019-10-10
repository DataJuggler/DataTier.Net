

#region using statements

using ObjectLibrary.BusinessObjects;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Forms
{

    #region class FieldSetEditorForm
    /// <summary>
    /// This form is used to host the FieldSetEditor control. 
    /// </summary>
    public partial class FieldSetEditorForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FieldSetEditorForm' object.
        /// </summary>
        public FieldSetEditorForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

           
        #endregion

        #region Methods

            #region Setup(DTNTable table, bool parameterMode, bool parameterModeReadOnly = false, FieldSet fieldSet = null)
            /// <summary>
            /// This method prepares this control to be shown.
            /// </summary>
            public void Setup(DTNTable table, bool parameterMode, bool parameterModeReadOnly = false, FieldSet fieldSet = null)
            {
                // Setup the control
                this.FieldSetEditor.Setup(table, parameterMode, parameterModeReadOnly, fieldSet);
            }
        #endregion

            #region SetupForOrderByMode(DTNTable table, FieldSet fieldSet = null)
            /// <summary>
            /// This method prepares the FieldSetEditor control to be shown in OrderByMode
            /// </summary>
            public void SetupForOrderByMode(DTNTable table, FieldSet fieldSet = null)
            {
                // Setup the control
                this.FieldSetEditor.SetupForOrderByMode(table, fieldSet);
            }
            #endregion

        #endregion
    }
    #endregion

}
