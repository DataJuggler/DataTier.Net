

#region using statements

using ObjectLibrary.BusinessObjects;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Forms
{

    #region class BlazorServicesForm
    /// <summary>
    /// This form is used to host the BlazorServicesControl.
    /// </summary>
    public partial class BlazorServicesForm : Form
    {
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'BlazorServicesForm' object.
        /// </summary>
        public BlazorServicesForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Setup(Project project, DTNTable table)
            /// <summary>
            /// This method Setups this control
            /// </summary>
            public void Setup(Project project, DTNTable table)
            {
                // Setup the control
                BlazorDataServicesControl.Setup(project, table);
            }
        #endregion

        #endregion

        #region Properties

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
