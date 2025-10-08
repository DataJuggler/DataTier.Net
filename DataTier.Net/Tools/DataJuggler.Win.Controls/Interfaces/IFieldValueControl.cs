

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region IFieldValueControl
    /// <summary>
    /// This interface is used for the LabelTextBoxControl, LabelComboControl and the LabelCheckBoxControl.
    /// </summary>
    public interface IFieldValueControl
    {
        
        #region Methods

            #region Clear();
            /// <summary>
            /// The control should have a Clear method.
            /// </summary>
            void Clear(); 
            #endregion
        
        #endregion
        
        #region Properties

            #region FieldLabel
            /// <summary>
            /// Return the label from the control.
            /// </summary>
            Label FieldLabel
            {
                get;
            }
            #endregion

            #region LabelWidth
            /// <summary>
            /// Get or Set the width of the Label for this control.
            /// </summary>
            int LabelWidth
            {
                get;
                set;
            } 
            #endregion
        
        #endregion
        
    } 
    #endregion
    
}
