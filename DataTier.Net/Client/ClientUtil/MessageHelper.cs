

#region using statements

using DataTierClient.Forms;
using System.Media;
using DataJuggler.Core.UltimateHelper;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class MessageHelper
    /// <summary>
    /// This class is used to make it easy to change out MessageBoxes to DisplayMessageForms.
    /// </summary>
    internal class MessageHelper
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region DisplayMessage(string messageText, string title)
            /// <summary>
            /// method Display Message
            /// </summary>
            public static void DisplayMessage(string messageText, string title)
            {
                string playSoundSetting = ConfigurationHelper.ReadAppSetting("PlaySound");
                bool playSound = BooleanHelper.ParseBoolean(playSoundSetting, false, false);

                // if the value for playSound is true
                if (playSound)
                {
                    // Create a new instance of a 'SoundPlayer' object.
                    SoundPlayer soundPlayer = new SoundPlayer("Sounds/alert.wav");
                    soundPlayer.Play();
                }

                // Create a new instance of a 'DisplayMessageForm' object.
                DisplayMessageForm form = new DisplayMessageForm();
                
                // Setup Form and Control
                form.SetMessageText(messageText);
                form.Text = title;

                // Show the Form
                form.ShowDialog();
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
