

#region using statements

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region interface ICheckChangedListener
    public interface ICheckChangedListener
    {

        #region Methods

            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            /// <summary>
            /// The checkbox has been checked or unchecked.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked);
            #endregion

        #endregion

    }
    #endregion 

}
