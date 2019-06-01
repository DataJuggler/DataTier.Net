

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

            #region FieldSetEditorForm_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// event is fired when Field Set Editor Form _ Key Down
            /// </summary>
            private void FieldSetEditorForm_KeyDown(object sender, KeyEventArgs e)
            {
                // Handle the Keydown on the control
                this.FieldSetEditor.FieldsListBox_KeyDown(sender, e);
            }
            #endregion
            
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

        #endregion
    }
    #endregion

}
