

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTierClient.Forms;

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
