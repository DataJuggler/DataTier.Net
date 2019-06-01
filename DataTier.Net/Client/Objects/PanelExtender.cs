using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTierClient.Objects
{

    #region class PanelExtender : Panel
    /// <summary>
    /// This class inherits from Panel; this is intended to stop the flickering on the panels
    /// </summary>
    public class PanelExtender : Panel
    {
       
        #region Constructor
        /// <summary>
        /// Create a new instance of a PanelExtender object
        /// </summary>
        public PanelExtender()
        {
            // Set Style to stop flickering
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
        }
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
