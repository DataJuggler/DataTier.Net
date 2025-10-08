

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class PromptHelper
    /// <summary>
    /// This class is used to prompt the user for a value
    /// </summary>
    public static class PromptHelper
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region PromptUserForString(string text, string caption)
            /// <summary>
            /// method Show Dialog and prompts the user
            /// </summary>
            public static string PromptUserForString(string text, string caption)
            {
                // initial value
                string input = "";

                // Create a form
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top=20, Text=text, Width=400 };
                TextBox textBox = new TextBox() { Left = 50, Top=50, Width=400 };
                Button confirmation = new Button() { Text = "Ok", Left=350, Width=100, Top=70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                    
                // set the form
                input = prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";

                // set the value
                return input;
            }
            #endregion

            #region PromptUserForInteger(string text, string caption)
            /// <summary>
            /// method Show Dialog and prompts the user
            /// </summary>
            public static int PromptUserForInteger(string text, string caption)
            {
                // initial value
                int input = 0;

                // get the raw input
                string temp = PromptUserForString(text, caption);

                // parse the input
                input = NumericHelper.ParseInteger(temp, 0, -1);

                // set the value
                return input;
            }  
            #endregion

        #endregion
            
    }
    #endregion
    
}
