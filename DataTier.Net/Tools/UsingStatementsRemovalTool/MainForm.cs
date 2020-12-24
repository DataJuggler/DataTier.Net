

#region using statements

using System;
using System.Windows.Forms;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using DataJuggler.Win.Controls.Enumerations;
using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace UsingStatementsRemovalTool
{

    #region class MainForm
    /// <summary>
    /// This is the main form for this app.
    /// </summary>
    public partial class MainForm : Form, ITextChanged
    {
        
        #region Private Variables
        private string dataTierFolder;
        private string deleteProcsFolder;
        private string fetchProcsFolder;
        private string insertProcsFolder;
        private string updateProcsFolder;
        private List<string> filesToProcess;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region OnTextChanged(Control sender, string text)
            /// <summary>
            /// event is fired when On Text Changed
            /// </summary>
            public void OnTextChanged(Control sender, string text)
            {
                // Update our property
                this.DataTierFolder = text;

                // Update child properties
                this.DeleteControl.Text = Path.Combine(DataTierFolder, "DeleteProcedures");
                this.FetchControl.Text = Path.Combine(DataTierFolder, "FetchProcedures");
                this.InsertControl.Text = Path.Combine(DataTierFolder, "InsertProcedures");
                this.UpdateControl.Text = Path.Combine(DataTierFolder, "UpdateProcedures");

                // update everything
                Refresh();
            }
            #endregion
            
            #region ProcessButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ProcessButton' is clicked.
            /// </summary>
            private void ProcessButton_Click(object sender, EventArgs e)
            {
                // we want only csharp files
                string extension = ".cs";

                // local
                bool nameSpaceReached = false;
                StringBuilder sb = null;

                // Create a new collection of 'string' objects.
                List<string> extensions = new List<string>();

                // Add this item
                extensions.Add(extension);

                // get the files to process
                FilesToProcess = FileHelper.GetFilesRecursively(DataTierFolder, ref filesToProcess, extensions);

                // If the FilesToProcess collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(FilesToProcess))
                {
                    // Setup the Graph
                    this.Graph.Minimum = 0;
                    this.Graph.Maximum = FilesToProcess.Count;
                    this.Graph.Value = 0;
                    this.Graph.Visible = true;

                    // update everything
                    Refresh();
                    Application.DoEvents();

                    // Iterate the collection of string objects
                    foreach (string fileToProcess in FilesToProcess)
                    {
                        // reset this value
                        nameSpaceReached = false;

                        // get the text of this file
                        string fileText = File.ReadAllText(fileToProcess);

                        // If the fileText string exists
                        if (TextHelper.Exists(fileText))
                        {
                            // get the textLines
                            List<TextLine> textLines = WordParser.GetTextLines(fileText);

                            // If the textLines collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(textLines))
                            {
                                // Create a new instance of a 'StringBuilder' object.
                                sb = new StringBuilder();
                              
                                // Append two blank lines
                                sb.Append(Environment.NewLine);
                                sb.Append(Environment.NewLine);

                                // Iterate the collection of TextLine objects
                                foreach (TextLine line in textLines)
                                {
                                    // if the value for nameSpaceReached is true
                                    if (nameSpaceReached)
                                    {
                                        // append the line text and ending newline character
                                        sb.Append(line.Text);
                                        sb.Append(Environment.NewLine);
                                    }
                                    else
                                    {
                                        // if the lines starts with namespace                                    
                                        if (line.Text.StartsWith("namespace"))
                                        {
                                            // set the value
                                            nameSpaceReached = true;

                                            // append the line text and ending newline character
                                            sb.Append(line.Text);
                                            sb.Append(Environment.NewLine);
                                        }
                                    }
                                }
                            }

                            // delete this file
                            File.Delete(fileToProcess);

                            // Write out the file without the namespace
                            File.AppendAllText(fileToProcess, sb.ToString());

                            // Increment the value for Graph
                            Graph.Value++;

                            // update the graph every 10 records
                            if (Graph.Value % 10 == 0)
                            {
                                // update everything
                                Refresh();
                            }
                        }
                    }
                }

                // Show a message box
                MessageBox.Show("The import has finished", "Done");
            }
            #endregion
            
            #region ProcessButton_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Mouse Enter
            /// </summary>
            private void ProcessButton_MouseEnter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region ProcessButton_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Mouse Leave
            /// </summary>
            private void ProcessButton_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Wire up the button
                this.DataTierFolderControl.OnTextChangedListener = this;

                // Select a Folder
                this.DataTierFolderControl.BrowseType = BrowseTypeEnum.Folder;
            }
            #endregion
            
        #endregion

        #region Properties

            #region DataTierFolder
            /// <summary>
            /// This property gets or sets the value for 'DataTierFolder'.
            /// </summary>
            public string DataTierFolder
            {
                get { return dataTierFolder; }
                set { dataTierFolder = value; }
            }
            #endregion
            
            #region DeleteProcsFolder
            /// <summary>
            /// This property gets or sets the value for 'DeleteProcsFolder'.
            /// </summary>
            public string DeleteProcsFolder
            {
                get { return deleteProcsFolder; }
                set { deleteProcsFolder = value; }
            }
            #endregion
            
            #region FetchProcsFolder
            /// <summary>
            /// This property gets or sets the value for 'FetchProcsFolder'.
            /// </summary>
            public string FetchProcsFolder
            {
                get { return fetchProcsFolder; }
                set { fetchProcsFolder = value; }
            }
            #endregion
            
            #region FilesToProcess
            /// <summary>
            /// This property gets or sets the value for 'FilesToProcess'.
            /// </summary>
            public List<string> FilesToProcess
            {
                get { return filesToProcess; }
                set { filesToProcess = value; }
            }
            #endregion
            
            #region HasDataTierFolder
            /// <summary>
            /// This property returns true if the 'DataTierFolder' exists.
            /// </summary>
            public bool HasDataTierFolder
            {
                get
                {
                    // initial value
                    bool hasDataTierFolder = (!String.IsNullOrEmpty(this.DataTierFolder));
                    
                    // return value
                    return hasDataTierFolder;
                }
            }
            #endregion
            
            #region HasFilesToProcess
            /// <summary>
            /// This property returns true if this object has a 'FilesToProcess'.
            /// </summary>
            public bool HasFilesToProcess
            {
                get
                {
                    // initial value
                    bool hasFilesToProcess = (this.FilesToProcess != null);
                    
                    // return value
                    return hasFilesToProcess;
                }
            }
            #endregion
            
            #region InsertProcsFolder
            /// <summary>
            /// This property gets or sets the value for 'InsertProcsFolder'.
            /// </summary>
            public string InsertProcsFolder
            {
                get { return insertProcsFolder; }
                set { insertProcsFolder = value; }
            }
            #endregion
            
            #region UpdateProcsFolder
            /// <summary>
            /// This property gets or sets the value for 'UpdateProcsFolder'.
            /// </summary>
            public string UpdateProcsFolder
            {
                get { return updateProcsFolder; }
                set { updateProcsFolder = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
