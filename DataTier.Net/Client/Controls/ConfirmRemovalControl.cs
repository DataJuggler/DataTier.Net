

#region using statements

using DataJuggler.Net;
using DataJuggler.Core.UltimateHelper;
using DataTierClient.ClientUtil;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using ObjectLibrary.BusinessObjects;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls
{

    #region class ConfirmRemovalControl
    /// <summary>
    /// This control is used to get the user's confirmation before removing the files
    /// </summary>
    public partial class ConfirmRemovalControl : UserControl, ISaveCancelControl
    {

        #region Private Variables
        private bool userCancelled;
        private ProjectFileManager projectFileManager;
        private bool loading;
        private string projectFolder;
        private bool deleteFiles;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ConfirmRemovalControl' object.
        /// </summary>
        public ConfirmRemovalControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region CodeItemsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            /// <summary>
            /// event is fired when Code Items List Box _ Item Check
            /// </summary>
            private void CodeItemsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                // if not loading            
                if (!this.Loading)
                {
                    // get the listBox
                    CheckedListBox listBox = sender as CheckedListBox;

                    // if the ListBox exists
                    if (NullHelper.Exists(listBox))
                    {
                        // if Checked
                        if (e.NewValue == CheckState.Checked)
                        {
                            // Do not Exclude since this file is checked
                            this.ProjectFileManager.Files[e.Index].Exclude = false;
                        }
                        else if (e.NewValue == CheckState.Unchecked)
                        {
                            // Exclude since this file is unchecked
                            this.ProjectFileManager.Files[e.Index].Exclude = true;
                        }
                    }
                }
            }
            #endregion
            
            #region DeleteFilesCheckBox_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DeleteFilesCheckBox' is clicked.
            /// </summary>
            private void DeleteFilesCheckBox_Click(object sender, EventArgs e)
            {
                // if we are not loading
                if (!this.Loading)
                {   
                    // If the checkbox is checked, then DeleteFiles is true
                    this.DeleteFiles = this.DeleteFilesCheckBox.Checked;
                }
            }
            #endregion
            
        #endregion

        #region Methods
        
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to the user did cancel
                this.UserCancelled = true;
            }
            #endregion
            
            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the ParentForm exists
                if (this.HasParentConfirmRemovalForm)
                {
                    // Close Form
                    this.ParentConfirmRemovalForm.Close();
                }
            }
            #endregion
            
            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// </summary>
            public void OnSave()
            {
                try
                {  
                    // User Did Not Cancel
                    this.UserCancelled = false;

                    // If the ParentForm exists
                    if (this.HasParentConfirmRemovalForm)
                    {
                        // Close Form
                        this.ParentConfirmRemovalForm.Close();
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion

            #region Setup(ProjectFileManager projectFileManager, string projectFolder, bool deleteFiles = true)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Setup(ProjectFileManager projectFileManager, string projectFolder, bool deleteFiles = true)
            {
                // Set this to true
                this.Loading = true;

                // If the projectFolder string exists
                if ((TextHelper.Exists(projectFolder)) && (projectFolder.Length > 80))
                {
                    // abbreviate
                    projectFolder = projectFolder.Substring(1, 80) + "...";
                }

                // store the args
                this.ProjectFileManager = projectFileManager;
                this.ProjectFolder = projectFolder;
                this.DeleteFiles = deleteFiles;
                
                // Set the projectRootPath
                this.ProjectFolderLabel.Text = "Project Folder: " + projectFolder;          
                
                // Remove everything
                this.CodeItemsListBox.Items.Clear();

                // if there are one or more Files to be removed
                if (ListHelper.HasOneOrMoreItems(projectFileManager.Files.ToList()))
                {
                    // Iterate the collection of ProjectFile objects
                    foreach (ProjectFile file in projectFileManager.Files)
                    {
                        // if this is the Gateway
                        if (file.ProjectType == DataManager.ProjectTypeEnum.Gateway)
                        {
                           // Do not display or remove the Gateway file, but it is needed to remove the Gateway methods
                        }
                        else
                        {
                            // Add this item
                            this.CodeItemsListBox.Items.Add(file.ShortFilePath, true);
                        }
                    }
                }

                // if there are one or more MethodNames
                if (ListHelper.HasOneOrMoreItems(projectFileManager.GatewayMethodNames))
                {  
                    // iterate the MethodNames
                    foreach (string methodName in projectFileManager.GatewayMethodNames)
                    {  
                        // Add this item
                        this.CodeItemsListBox.Items.Add("[Gateway Method] " + methodName, true);
                    }
                }

                // Setup the SaveButton
                this.SaveCancelControl.SetupSaveButton("Confirm Code Removal", 240);

                // Enable the Save button
                this.SaveCancelControl.EnableSaveButton(true);

                // turn off loading
                this.Loading = false;
            }
            #endregion
            
        #endregion

        #region Properties

            #region DeleteFiles
            /// <summary>
            /// This property gets or sets the value for 'DeleteFiles'.
            /// </summary>
            public bool DeleteFiles
            {
                get { return deleteFiles; }
                set { deleteFiles = value; }
            }
            #endregion
            
            #region HasParentConfirmRemovalForm
            /// <summary>
            /// This property returns true if this object has a 'ParentConfirmRemovalForm'.
            /// </summary>
            public bool HasParentConfirmRemovalForm
            {
                get
                {
                    // initial value
                    bool hasParentConfirmRemovalForm = (this.ParentConfirmRemovalForm != null);
                    
                    // return value
                    return hasParentConfirmRemovalForm;
                }
            }
            #endregion
            
            #region HasProjectFolder
            /// <summary>
            /// This property returns true if the 'ProjectRootPath' exists.
            /// </summary>
            public bool HasProjectFolder
            {
                get
                {
                    // initial value
                    bool hasProjectFolder = (!String.IsNullOrEmpty(this.ProjectFolder));
                    
                    // return value
                    return hasProjectFolder;
                }
            }
            #endregion
            
            #region Loading
            /// <summary>
            /// This property gets or sets the value for 'Loading'.
            /// </summary>
            public bool Loading
            {
                get { return loading; }
                set { loading = value; }
            }
            #endregion
            
            #region ParentConfirmRemovalForm
            /// <summary>
            /// This read only property returns the value for 'ParentConfirmRemovalForm'.
            /// </summary>
            public ConfirmRemovalForm ParentConfirmRemovalForm
            {
                get
                {
                    // initial value
                    ConfirmRemovalForm parentConfirmRemovalForm = this.ParentForm as ConfirmRemovalForm;
                    
                    // return value
                    return parentConfirmRemovalForm;
                }
            }
            #endregion
            
            #region ProjectFileManager
            /// <summary>
            /// This property gets or sets the value for 'ProjectFileManager'.
            /// </summary>
            public ProjectFileManager ProjectFileManager
            {
                get { return projectFileManager; }
                set { projectFileManager = value; }
            }
            #endregion
            
            #region ProjectRootPath
            /// <summary>
            /// This property gets or sets the value for 'ProjectRootPath'.
            /// </summary>
            public string ProjectFolder
            {
                get { return projectFolder; }
                set { projectFolder = value; }
            }
            #endregion
            
            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
