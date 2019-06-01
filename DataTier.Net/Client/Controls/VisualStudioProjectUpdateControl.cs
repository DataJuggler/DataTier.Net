

#region using statements

using DataTierClient.ClientUtil;
using DataTierClient.Forms;
using ObjectLibrary.BusinessObjects;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using DataJuggler.Net;
using DataTierClient.Controls.Interfaces;

#endregion

namespace DataTierClient.Controls
{

    #region class VisualStudioProjectUpdateControl : UserControl, ITabButtonParent
    /// <summary>
    /// This control is used to update a VisualStudioProject aftera  build.
    /// You only need to run this after new tables are added to a database.
    /// This utility does not remove project items at this time. You must
    /// remove items manually.
    /// </summary>
    public partial class VisualStudioProjectUpdateControl : UserControl, ITabButtonParent
    {
    
        #region Private Variables
        private Project currentProject;
        private VisualStudioSolution vsSolution;
        private IList<ProjectFile> files;
        private bool removalMode;
        #endregion

        #region Constructor

            #region Default Constructor
            /// <summary>
            /// Create a new instance of 'VisualStudioProjectUpdateControl' object.
            /// </summary>
            public VisualStudioProjectUpdateControl()
            {
                // Create controls
                InitializeComponent();
                
                // perform initializations
                Init();
            }
            #endregion
        
        #endregion

        #region Events

            #region ALCBrowseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when theuser click the 'ALCBrowseButton'.
            /// This is used to select the project in the solution if the
            /// name of the project has been changed from the default
            /// 'ApplicationLogicComponent'.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ALCBrowseButton_Click(object sender, EventArgs e)
            {
                // select the project
                SelectProject(this.ALCTextBox);
            }
            #endregion

            #region CancelUpdateButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event cancels this update.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CancelUpdateButton_Click(object sender, EventArgs e)
            {
                // if the parent update form exists
                if (this.HasParentUpdateForm)
                {
                    // set user cancelled to true (should already be true)
                    this.ParentUpdateForm.UserCancelled = true;
                    
                    // close the form
                    this.ParentUpdateForm.Close();
                }
            } 
            #endregion

            #region DACBrowseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'DACBrowseButton' is clicked.
            /// This is used to select the project in the solution if the
            /// name of the project has been changed from the default
            /// 'DataAccessComponent'.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DACBrowseButton_Click(object sender, EventArgs e)
            {
                // select the project
                SelectProject(this.DACTextBox);
            } 
            #endregion

            #region ObjectLibraryBrowseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'ObjectLibraryBrowseButton' is clicked.
            ///  This is used to select the project in the solution if the
            /// name of the project has been changed from the default
            /// 'ObjectLibrary'.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ObjectLibraryBrowseButton_Click(object sender, EventArgs e)
            {
                // select the project
                SelectProject(this.ObjectLibraryTextBox);
            } 
            #endregion

            #region SolutionBrowseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The SolutionBrowseButton browses for the .sln file that
            /// contains all the project files.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SolutionBrowseButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // Browse for the folder
                    DialogHelper.ChooseSolutionFile(this.SolutionTextBox);

                    // set the solution fileName
                    string solutionFileName = this.SolutionTextBox.Text;

                    // if the fileName exists
                    if (!String.IsNullOrEmpty(solutionFileName))
                    {
                        // if the parent form exists
                        if (this.ParentUpdateForm != null)
                        {
                            // turn on a wait cursor
                            this.ParentUpdateForm.Cursor = Cursors.WaitCursor;
                        
                            // force everything to catch up
                            this.Refresh();
                            Application.DoEvents();
                        }
                    
                        // Find a visual studio solution
                        this.VSSolution = VisualStudioHelper.FindSolution(solutionFileName);

                        // display the VSSolution
                        this.DisplayVSSolution();

                        // if the parent form exists
                        if (this.ParentUpdateForm != null)
                        {
                            // turn on a wait cursor
                            this.ParentUpdateForm.Cursor = Cursors.Default;

                            // force everything to catch up
                            this.Refresh();
                            Application.DoEvents();
                        }
                    }
                }
                catch (Exception error)
                {
                    // create a message to show to the user
                    string message = "There was an error reading your solution. The error thrown was:" + Environment.NewLine + error.ToString();
                    string title = "Visual Studio Update Failure";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region UpdateProjectButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This method performs the update once all the projects
            /// in the solution have been selected.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void UpdateProjectButton_Click(object sender, EventArgs e)
            {
                // locals
                string title = "Update Complete";
                string message = "Your Visual Studio project has been updated.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Information;
                bool updated = false;
                
                try
                {
                    // if the parent form exists
                    if (this.HasParentUpdateForm)
                    {
                        // turn on the wait cursor
                        this.ParentUpdateForm.Cursor = Cursors.WaitCursor;
                        
                        // force everything to catch up
                        this.Refresh();
                        Application.DoEvents();
                    }
                
                    // get the name of the file
                    string fileName = this.SolutionTextBox.Text;

                    // if the fileName exists
                    if ((!String.IsNullOrEmpty(fileName)) && (this.Files != null))
                    {
                        // update the solution
                        updated = VisualStudioHelper.UpdateSolution(this.VSSolution, fileName, this.Files.ToList(), removalMode);
                    }

                    // If the ParentUpdateForm object exists
                    if (this.HasParentUpdateForm)
                    {
                        // Restore the cursor
                        this.ParentUpdateForm.Cursor = Cursors.Default;

                         // force everything to catch up before showing any message boxes
                        this.Refresh();
                        Application.DoEvents();
                    }

                    // if updated
                    if ((!updated) && (!RemovalMode))
                    {
                        // set the title and message with the failure
                        title = "Update Failure";
                        message = "There was a failure while attempting to update your projecst. You must update your projects manually.";
                        icon = MessageBoxIcon.Warning;

                        // Show a message to the user
                        MessageBox.Show(message, title, button, icon);
                    }
                    else if ((!updated) && (RemovalMode))
                    {
                        // set the title and message with the failure
                        title = "Removal Failure";
                        message = "There was a failure while attempting to remove files from your projects. You must update your projectsm manually.";
                        icon = MessageBoxIcon.Warning;

                        // Show a message to the user
                        MessageBox.Show(message, title, button, icon);
                    }
                    else
                    {
                        // Show a message to the user
                        MessageBox.Show(message, title, button, icon);

                        // if the parent form exists
                        if (this.HasParentUpdateForm)
                        {
                            // the user did not cancel
                            this.ParentUpdateForm.UserCancelled = false;
                            
                            // close the parent form
                            this.ParentUpdateForm.Close();
                        }
                    }
                }
                catch (Exception error)
                {
                    // If the ParentUpdateForm object exists
                    if (this.HasParentUpdateForm)
                    {
                        // Restore the cursor
                        this.ParentUpdateForm.Cursor = Cursors.Default;
                    }

                    // set the title and message with the failure
                    title = "Update Failure";
                    message = "There was a failure while attempting to update your project. You must update your projects manually." + Environment.NewLine + error.ToString();

                    // create an icon
                    icon = MessageBoxIcon.Warning;

                    // Show a message to the user
                    MessageBox.Show(message, title, button, icon);
                }
                finally
                {
                    // If the ParentUpdateForm object exists
                    if (this.HasParentUpdateForm)
                    {
                        // Restore the cursor
                        this.ParentUpdateForm.Cursor = Cursors.Default;
                    }
                }
            } 
            #endregion
        
        #endregion
        
        #region Methods

            #region DisplayVSSolution()
            /// <summary>
            /// Display the visual solution.
            /// </summary>
            private void DisplayVSSolution()
            {
                string alcProjectName = "";
                string dacProjectName = "";
                string objectLibraryProjectName = "";
                
                // if the VSSolution exists
                if (this.HasVSSolution)
                {
                    // set the values to display
                    alcProjectName = this.VSSolution.ApplicationLogicComponentProjectName;
                    dacProjectName = this.VSSolution.DataAccessComponentProjectName;
                    objectLibraryProjectName = this.VSSolution.ObjectLibraryProjectName;
                }
                
                // display values now
                this.ALCTextBox.Text = alcProjectName;
                this.DACTextBox.Text = dacProjectName;
                this.ObjectLibraryTextBox.Text = objectLibraryProjectName;
                
                // Enable Controls
                UIEnable();
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            private void Init()
            {
                // enable controls
                UIEnable();
            }   
            #endregion

            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // determine action by the button text
                switch (tabButton.ButtonText)
                {
                    case "...":
    
                        // All the Elipses use the same button text
                        switch (tabButton.ButtonNumber)
                        {
                            case 1:

                                // Browse for the solution
                                SolutionBrowseButton_Click(this, null);

                                // required
                                break;

                            case 2:

                                // Browse for the ALC
                                ALCBrowseButton_Click(this, null);

                                // required
                                break;

                            case 3:

                                // Browse for the DAC
                                DACBrowseButton_Click(this, null);

                                // required
                                break;

                            case 4:

                                // Browse for the ObjectLibrary
                                ObjectLibraryBrowseButton_Click(this, null);

                                // required
                                break;
                        }


                        // required
                        break;

                    case "Update Project":

                        // Call the UpdateProjectButton_Click event
                        UpdateProjectButton_Click(this, null);

                        // required
                        break;

                    case "Cancel":

                        // Call the CancelSaveButton_Click event
                        CancelUpdateButton_Click(this, null);

                        // required
                        break;
                }
            }
            #endregion

            #region SelectProject(TextBox textBox)
            /// <summary>
            /// This method selects a project and populates the
            /// TextBox text with the project name.
            /// </summary>
            /// <param name="textBox"></param>
            private void SelectProject(TextBox textBox)
            {
                // if the VSSolution exists
                if ((this.VSSolution != null) && (this.VSSolution.AllSolutionProjects != null) && (this.VSSolution.AllSolutionProjects.Count > 0) && (textBox != null))
                {
                    // create
                    ProjectChooserForm chooserForm = new ProjectChooserForm(this.VSSolution.AllSolutionProjects);
                    
                    // show the dialog
                    chooserForm.ShowDialog();
                    
                    // if the user did not cancel
                    if ((!chooserForm.UserCancelled) && (!String.IsNullOrEmpty(chooserForm.SelectedVSProject)))
                    {
                        // set the text of the text box
                        textBox.Text = chooserForm.SelectedVSProject;
                    }
                }
            }  
            #endregion

            #region Setup(Project currentProject, IList<string> files, bool removalMode = false)
            /// <summary>
            /// This method prepares this control to run.
            /// </summary>
            /// <param name="currentProject"></param>
            internal void Setup(Project currentProject, IList<ProjectFile> files, bool removalMode = false)
            {
                // set the current project
                this.CurrentProject = currentProject;
                
                // set the files
                this.Files = files;

                // Are we in RemovalMode or not?
                this.RemovalMode = removalMode;

                // Remove Mode
                if (this.RemovalMode)
                {
                    // Remove the files
                    this.ParentForm.Text = "Remove Project Files";
                }
            } 
            #endregion

            #region UIEnable()
            /// <summary>
            /// Enable controls on this control.
            /// </summary>
            private void UIEnable()
            {
                // validate the solution
                bool isValid = this.ValidateSolution();
                
                // do we have a VSSolution
                bool hasSolutionProjects = ((this.HasVSSolution) && (this.VSSolution.AllSolutionProjects != null) && (this.VSSolution.AllSolutionProjects != null));
                
                // enable the button if this is valid
                this.UpdateProjectButton.Enabled = isValid;
                
                // enable the browse buttons if there are solution projects
                this.ALCBrowseButton.Enabled = hasSolutionProjects;
                this.DACBrowseButton.Enabled = hasSolutionProjects;
                this.ObjectLibraryBrowseButton.Enabled = hasSolutionProjects;
            }
            #endregion

            #region ValidateSolution()
            /// <summary>
            /// This method validates the solution.
            /// </summary>
            /// <returns></returns>
            private bool ValidateSolution()
            {
                // initial value
                bool valid = false;
                
                // if the VSSolution exists
                if (this.HasVSSolution)
                {
                    // is the ALCProjectName set?
                    bool hasALCProjectName = (!String.IsNullOrEmpty(this.VSSolution.ApplicationLogicComponentProjectName));

                    // is the ALCProjectName set?
                    bool hasDACProjectName = (!String.IsNullOrEmpty(this.VSSolution.DataAccessComponentProjectName));

                    // is the ALCProjectName set?
                    bool hasObjectLibraryProjectName = (!String.IsNullOrEmpty(this.VSSolution.ObjectLibraryProjectName));
                    
                    // verify there are files to update 
                    bool hasFiles = ((this.Files != null) && (this.Files.Count > 0));
                    
                    // if all the projects exist 
                    valid = ((hasALCProjectName) && (hasDACProjectName) && (hasObjectLibraryProjectName) && (hasFiles));
                }
                
                // return value
                return valid;
            }    
            #endregion
        
        #endregion
        
        #region Properties

            #region CurrentProject
            /// <summary>
            /// The current 'Project' that was just build using DataTier.Net.
            /// </summary>
            public Project CurrentProject
            {
                get { return currentProject; }
                set { currentProject = value; }
            } 
            #endregion

            #region Files
            /// <summary>
            /// This is a collection of ProjectFile that were created
            /// during a build. 
            /// </summary>
            public IList<ProjectFile> Files
            {
                get { return files; }
                set { files = value; }
            } 
            #endregion

            #region HasParentUpdateForm
            /// <summary>
            /// Does this object have a parent update form.
            /// </summary>
            public bool HasParentUpdateForm
            {
                get
                {
                    // initial value
                    bool hasParentUpdateForm = (this.ParentUpdateForm != null);

                    // return value
                    return hasParentUpdateForm;
                }
            } 
            #endregion

            #region HasVSSolution
            /// <summary>
            /// Does this object have a VisualStudioSolution.
            /// </summary>
            public bool HasVSSolution
            {
                get
                {
                    // initial value
                    bool hasVSSolution = (this.VSSolution != null);

                    // return value
                    return hasVSSolution;
                }
            }
            #endregion
            
            #region ParentUpdateForm
            /// <summary>
            /// This read only property returns the Parent
            /// VisualStuidioProjectUpdateForm that this object sits on.
            /// </summary>
            public VisualStudioProjectUpdateForm ParentUpdateForm
            {
                get
                {
                    // initial value
                    VisualStudioProjectUpdateForm parentUpdateForm = this.ParentForm as VisualStudioProjectUpdateForm;

                    // return value
                    return parentUpdateForm;
                }
            } 
            #endregion

            #region RemovalMode
            /// <summary>
            /// This property gets or sets the value for 'RemovalMode'.
            /// </summary>
            public bool RemovalMode
            {
                get { return removalMode; }
                set { removalMode = value; }
            }
            #endregion
            
            #region VSSolution
            /// <summary>
            /// The visual studio solution file that will be updated.
            /// </summary>
            public VisualStudioSolution VSSolution
            {
                get { return vsSolution; }
                set { vsSolution = value; }
            } 
            #endregion
        
        #endregion

    } 
    #endregion
    
}
