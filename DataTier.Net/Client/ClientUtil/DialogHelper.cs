

#region using statements

using System;
using System.Windows.Forms;
using System.IO;

#endregion


namespace DataTierClient.ClientUtil
{

    #region DialogHelper
    /// <summary>
    /// This class is designed to folders
    /// for DirectoryChooser.
    /// </summary>
    public class DialogHelper
    {
    
        #region Static Methods

            #region ChooseFolder(TextBox textBox)
            /// <summary>
            /// This method makes it easy to select a path and display it in a TextBox
            /// </summary>
            /// <param name="textBox"></param>
            /// <returns></returns>
            internal static void ChooseFolder(TextBox textBox)
            {
                // Create folderBrowser
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                
                // Show folderbrowser
                folderBrowser.ShowDialog();
                
                // if the text box exists
                if(textBox != null)
                {
                    // Set text on text box
                    textBox.Text = folderBrowser.SelectedPath;
                }
            }
            #endregion

            #region ChooseFolder(TextBox textBox, string selectedPath)
            /// <summary>
            /// This method is used to choose a folder.
            /// </summary>
            /// <param name="textBox"></param>
            /// <returns></returns>
            internal static void ChooseFolder(TextBox textBox, string selectedPath)
            {
                // Create folderBrowser
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                // Set the selectedPath
                folderBrowser.SelectedPath = selectedPath;
                
                // Show folderbrowser
                folderBrowser.ShowDialog();

                // if there is a selectedPath
                bool hasSelectedPath = (!String.IsNullOrEmpty(folderBrowser.SelectedPath));
                bool hasTextBox = (textBox != null);

                // if the text box exists
                if ((hasSelectedPath) && (hasTextBox))
                {
                    // Set text on text box
                    textBox.Text = folderBrowser.SelectedPath;
                }
            }
            #endregion

            #region ChooseSolutionFile(TextBox textBox)
            /// <summary>
            /// This method browses for a solution file and sets
            /// the resulted file as the text box text.
            /// </summary>
            /// <param name="textBox"></param>
            internal static void ChooseSolutionFile(TextBox textBox)
            {
                // open fileDialog
                OpenFileDialog fileBrowser = new OpenFileDialog();

                // Add extension
                fileBrowser.Filter = "Visual Studio Solution (*.sln)|*.sln";

                // Show fileBrowser
                fileBrowser.ShowDialog();

                // if the text box exists
                if (textBox != null)
                {
                    // Set text on text box
                    textBox.Text = fileBrowser.FileName;
                }
            } 
            #endregion
            
        #endregion

    }
    #endregion
    
}
