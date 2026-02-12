

#region using statements

using System;
using System.Windows.Forms;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Win.Controls;
using System.IO;
using DataJuggler.Core.UltimateHelper.Objects;
using DataJuggler.Core.UltimateHelper;
using System.Collections.Generic;
using System.Text;

#endregion

namespace ProcedureFinder
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this application
    /// </summary>
    public partial class MainForm : Form, ITextChanged
    {  
       
        #region Constructor
        /// <summary>
        /// This class is used to count the number of custom procedures in a RAD Studio project
        /// </summary>
        public MainForm()
        {   
            // Create control
            InitializeComponent();

            // Set the listener
            this.SelectedFolderControl.OnTextChangedListener = this;
        }
        #endregion
        
        #region Events
            
            #region BrowseFolderButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'BrowseFolderButton' is clicked.
            /// </summary>
            private void BrowseFolderButton_Click(object sender, EventArgs e)
            {
                // Create folderBrowser
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                // Show folderbrowser
                folderBrowser.ShowDialog();

                // Display the SelectedPath
                this.SelectedFolderControl.Text = folderBrowser.SelectedPath;
            }
            #endregion
            
            #region CopyButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'CopyButton' is clicked.
            /// </summary>
            private void CopyButton_Click(object sender, EventArgs e)
            {
                // Copy the text to the clipboard
                string text = this.ProceduresTextBox.Text;

                // copy the text to the clipboard
                Clipboard.SetText(text);

                // Show a message to the user
                MessageBox.Show("The text has been copied to the clipboard.", "Text Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
            
            #region OnTextChanged(LabelTextBoxControl control, string text)
            /// <summary>
            /// This event is fired when the Text Changed event is fired
            /// </summary>
            public void OnTextChanged(LabelTextBoxControl control, string text)
            {
                // Find the procedures
                FindProcedures();
            }
            #endregion
            
        #endregion

        #region Methods

            #region FindProcedures()
            /// <summary>
            /// This method Finds all the Procedures in a file
            /// </summary>
            public void FindProcedures()
            {
                // get the path
                string path = this.SelectedFolderControl.Text;

                // locals
                StringBuilder sb = new StringBuilder();
                string proceduresFound = "";

                // if the path exists
                if (Directory.Exists(path))
                {
                    // Find the files in the director matching the pattern given
                    string[] files = Directory.GetFiles(path, "*.cs", SearchOption.TopDirectoryOnly);

                    // if there are one or more files were found
                    if ((files != null) && (files.Length > 0))
                    {
                        // iterate the files
                        foreach (string filePath in files)
                        {  
                            // read all the text of the file
                            string fileText = File.ReadAllText(filePath);

                            // if the fileText exists
                            if (TextHelper.Exists(fileText))
                            {
                                // get the text of the file
                                List<TextLine> lines = TextHelper.GetTextLines(fileText);

                                // if there are one or more lines
                                if (ListHelper.HasOneOrMoreItems(lines))
                                {
                                    // Iterate the items in the collection
                                    foreach (TextLine textLine in lines)
                                    {
                                        // if this line contains the text 'ProcedureName'
                                        if ((textLine.Text.Contains("ProcedureName")) && (!textLine.Text.Contains("@ProcedureName")))
                                        {
                                            // Get the procedureName
                                            string procedureName = GetProcedureName(textLine.Text);

                                            // if the procedureName was found
                                            if (TextHelper.Exists(procedureName))
                                            {
                                                // append a procedureName
                                                sb.Append(procedureName);

                                                // Append the new line character
                                                sb.Append(Environment.NewLine);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // now get the text from the string builder
                    proceduresFound = sb.ToString();

                    // Set the text
                    this.ProceduresTextBox.Text = proceduresFound;
                }
            }
            #endregion
            
            #region GetProcedureName(string lineText)
            /// <summary>
            /// This method returns the Procedure Name
            /// </summary>
            private string GetProcedureName(string lineText)
            {
                // initial value
                string procedureName = "";

                // locals
                int startIndex = -1;
                int endIndex = -1;
                int len = 0;
                string quote = "\"";

                // verify the lineText exists
                if (TextHelper.Exists(lineText))
                {
                    // get the startIndex
                    startIndex = lineText.IndexOf(quote);
                    endIndex = lineText.LastIndexOf(quote);

                    // if the endIndex is greater than the startIndex and the startIndex is greater than zero
                    if ((endIndex > startIndex) && (startIndex > 0))
                    {
                        // increment startIndex
                        startIndex++;

                        // set the endIndex and startIndex
                        len = endIndex - startIndex;

                        // get the procedureName
                        procedureName = lineText.Substring(startIndex, len);
                    }
                }

                // return value
                return procedureName;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
