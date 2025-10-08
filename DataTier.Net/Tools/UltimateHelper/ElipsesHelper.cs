

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.Core.UltimateHelper.Enumerations;
using System.IO;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class ElipsesHelper
    /// <summary>
    /// This class is used to easily connect any 'Browse' or elipses (...) button to a text box
    /// </summary>
    public class ElipsesHelper
    {

        #region Constants
        private const string DefaultFilter = "All files (*.*)|*.*|All files (*.*)|*.*";
        #endregion

        #region Methods

            #region BrowseForDirectory(TextBox textBox)
            /// This method is used to browse for a directory
            /// </summary>
            /// <param name="textBox"></param>
            /// <param name="initialDirectory"></param>
            public static void BrowseForDirectory(TextBox textBox)
            {
                try
                {
                    // If the textBox object exists
                    if (NullHelper.Exists(textBox))
                    {
                        // Create an FolderBrowserDialog
                        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                        // Set the SelectedPath
                        folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;

                        // If the dialog result is 'ok'
                        if (folderBrowser.ShowDialog() == DialogResult.OK)
                        {
                            // Set the Text
                            textBox.Text = folderBrowser.SelectedPath;
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

            #region BrowseForFile(TextBox textBox, string filter = "", string fileName = "")
            /// This method is used to browse for a file
            /// </summary>
            /// <param name="textBox"></param>
            /// <param name="pattern"></param>
            /// <param name="fileName"></param>
            public static void BrowseForFile(TextBox textBox, string filter = "", string fileName = "")
            {
                try
                {
                    // If the textBox object exists
                    if (NullHelper.Exists(textBox))
                    {
                        // Create an openFileDialog
                        OpenFileDialog openFileDialog = new OpenFileDialog();

                        // if the filter exists
                        if (TextHelper.Exists(filter))
                        {
                            // Use the filter passed in
                            openFileDialog.Filter = filter;
                        }
                        else
                        {  
                            // Use the DefaultFilter
                            openFileDialog.Filter = DefaultFilter;

                            // Set the FilterIndex
                            openFileDialog.FilterIndex = 2;
                        }

                        // If the fileName string exists
                        if (TextHelper.Exists(fileName))
                        {
                            // Set the FileName
                            openFileDialog.FileName = fileName;
                        }

                        // Set RestoreDirectory to true
                        openFileDialog.RestoreDirectory = true;

                        // If the dialog result is 'ok'
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Set the Text
                            textBox.Text = openFileDialog.FileName;
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

        #endregion
        
    }
    #endregion

}
