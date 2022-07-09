

#region using statements

using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls.Interfaces
{

    #region interface ISelectedIndexListener
    /// <summary>
    /// This is used by controls that use that host the LabelComboControl (or others later)
    /// </summary>
    public interface ISliderValueChangedListener
    {

        #region Methods

            #region OnSliderValueChanged(TrackBar trackBar, int sliderValue);
            /// <summary>
            /// Subscribe to this method to be alerted when the value changes.
            /// </summary>
            /// <param name="control"></param>
            /// <param name="selectedIndex"></param>
            void OnSliderValueChanged(TrackBar trackBar, int sliderValue);
            #endregion

        #endregion

    } 
    #endregion
    
}
