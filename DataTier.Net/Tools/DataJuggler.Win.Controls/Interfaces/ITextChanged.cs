

#region using statements

using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region interface ITextChanged
    /// <summary>
    /// This is used by controls that use that host the LabelComboControl (or others later)
    /// </summary>
    public interface ITextChanged
    {

        #region Methods

            #region OnTextChanged(LabelTextBoxControl sender, string text);
            /// <summary>
            /// The Selected has changed.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            void OnTextChanged(LabelTextBoxControl sender, string text);
            #endregion

        #endregion

    } 
    #endregion
    
}
