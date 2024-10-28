

#region using statements

using ObjectLibrary.BusinessObjects;
using DataTierClient.Controls;
using DataTierClient.Controls.Interfaces;
using DataGateway;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

#endregion

namespace DataTierClient.Forms
{

    #region class ProjectChooserForm : Form
    /// <summary>
    /// This form is used to select a project from the list of all projects.
    /// </summary>
    public partial class ProjectChooserForm : Form, ITabButtonParent
    {
    
        #region Private Variables
        private List<Project> allProjects;
        private IList<string> vistualStudioProjects;
        private Project selectedProject;
        private string selectedVSProject;
        private bool userCancelled;
		private Gateway gateway;
        private bool visualStudioMode;
        #endregion

        #region Constructors
        
            #region DataTier.Net Project Mode Constructor
            /// <summary>
            /// Constructor
            /// </summary>
            public ProjectChooserForm(List<Project> allProjects)
            {
                // this is the start up open project
                this.VisualStudioMode = false;
            
                // Create Controls
                InitializeComponent();
                
                // Create the gateway
                this.Gateway = new Gateway();
                
                // The user did cancel by default
                this.UserCancelled = true;
                
                // Set Properties
                this.AllProjects = allProjects;
                
                // Display Projects
                DisplayProjects();
            }
            #endregion

            #region Visual Studio Project Mode Constructor
            /// <summary>
            /// Constructor
            /// </summary>
            public ProjectChooserForm(IList<string> projects)
            {
                try
                {
                    // Create Controls
                    InitializeComponent();

                    // this is Visual Studio Mode
                    this.VisualStudioMode = true;

                    // Create the gateway
                    this.Gateway = new Gateway();

                    // The user did cancel by default
                    this.UserCancelled = true;

                    // Set Properties
                    this.VisualStudioProjects = projects;

                    // Display Projects
                    DisplayVisualStudioProjects();
                }
                catch (Exception error)
                {
                    // for debugging only (for now)
                    string err = error.ToString();
                }
            }
            #endregion
        
        #endregion
        
        #region Events

            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The user clicked the cancel button.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // the user did cancel (just to confirm, should already be true)
                this.UserCancelled = true;

                // close this form
                this.Close();
            }
            #endregion

            #region ProjectsListBox_DoubleClick(object sender, EventArgs e)
            /// <summary>
            /// This method displays the OpenProject.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ProjectsListBox_DoubleClick(object sender, EventArgs e)
            {
                if (this.VisualStudioMode)
                {
                    // Cast the SelectedItem as a Project
                    string projectName = this.ProjectsListBox.SelectedItem as string;

                    // if the project exists
                    if (!String.IsNullOrEmpty(projectName))
                    {
                        // Set the SelectedProject
                        this.SelectedVSProject = projectName;

                        // User did not cancel
                        this.UserCancelled = false;

                        // Close this form
                        this.Close();
                    }    
                }
                else
                {
                    // if the SelectedItem is a project
                    if (ProjectsListBox.SelectedItem is Project project)
                    {
                        // Set the SelectedProject
                        this.SelectedProject = project;

                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway();

                        // Load the AllReferences
                        gateway.LoadProjectReferencesForProject(ref project);

                        // User did not cancel
                        this.UserCancelled = false;

                        // Close this form
                        this.Close();
                    }    
                }
            }
            #endregion

			#region ProjectsListBox_KeyDown(object sender, KeyEventArgs e)
			/// <summary>
			/// This event is used to handle the delete key to delete a project.
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void ProjectsListBox_KeyDown(object sender, KeyEventArgs e)
			{
				// if the Delete key was exists
				if ((e.KeyCode == Keys.Delete) && (!this.VisualStudioMode))
				{
                    if (ProjectsListBox.SelectedItem is Project selectedProject)
                    {
						// get the user's ocnfirmation to delete
						string message = "Are you wish to delete the project '" + selectedProject.ProjectName + "'? This action can not be undone.";
						string title = "Confirm Delete";
						
						// Get the user's permission before deleting
						DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						
						// if the user choose 'Yes'
						if(dialogResult == DialogResult.Yes)
						{	
							// Delete the project
							bool deleted = this.Gateway.AppController.ControllerManager.ProjectController.Delete(selectedProject);
							
							// if the project was deleted
							if(deleted)
							{	
								// Fetch All Projects
								this.AllProjects = this.Gateway.AppController.ControllerManager.ProjectController.FetchAll(null);
								
								// Display Projects
								this.DisplayProjects();
							}
						}
					}
				}
			} 
			#endregion
        
        #endregion
        
        #region Method

            #region DisplayProjects()
            /// <summary>
            /// This method displays the all projects.
            /// </summary>
            private void DisplayProjects()
            {
                // Clear the list box
                this.ProjectsListBox.Items.Clear();
                
                // if the AllProjects exist
                if(this.AllProjects != null)
                {
                    // Sort the projects
                    List<Project> projects = AllProjects.OrderBy(x => x.ProjectName).ToList();

                    // update the list to be sorted
                    AllProjects = projects;

                    // if the all projects exist
                    foreach(Project project in AllProjects)
                    {
                        // Add this item
                        this.ProjectsListBox.Items.Add(project);
                    }
                }
            } 
            #endregion

            #region DisplayVisualStudioProjects()
            /// <summary>
            /// This method displays all projects
            /// from a Visual Studio solution.
            /// </summary>
            private void DisplayVisualStudioProjects()
            {
                // Clear the list box
                this.ProjectsListBox.Items.Clear();

                // if the VistualStudioProjects exist
                if (this.VisualStudioProjects != null)
                {
                    // if the all projects exist
                    foreach (string project in this.VisualStudioProjects)
                    {
                        // Add this item
                        this.ProjectsListBox.Items.Add(project);
                    }
                }
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
                    case "Cancel":

                        // Call the CancelButton_Click event
                        CancelButton_Click(this, null);

                        // required
                        break;
                }
            }
            #endregion
           
        #endregion
        
        #region Properties

            #region AllProjects
            /// <summary>
            /// A collection of all projects.
            /// </summary>
            public List<Project> AllProjects
            {
                get { return allProjects; }
                set { allProjects = value; }
            }
            #endregion

			#region Gateway
			/// <summary>
			/// The Gateway for this object.
			/// </summary>
			internal Gateway Gateway
			{
				get { return gateway; }
				set { gateway = value; }
			}
			#endregion
			
            #region SelectedProject
            /// <summary>
            /// This property is the selected project after
            /// the user makes a selection.
            /// </summary>
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
            }
            #endregion

            #region SelectedVSProject
            /// <summary>
            /// This property returns the selected Visual Studio Project Name.
            /// </summary>
            public string SelectedVSProject
            {
                get { return selectedVSProject; }
                set { selectedVSProject = value; }
            } 
            #endregion

            #region UserCancelled
            /// <summary>
            /// Did the user cancel or make a selection.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
            #endregion

            #region VisualStudioMode
            /// <summary>
            /// This mode is set to true when selecting a VisualStudioProject.
            /// </summary>
            public bool VisualStudioMode
            {
                get { return visualStudioMode; }
                set { visualStudioMode = value; }
            } 
            #endregion

            #region VistualStudioProjects
            /// <summary>
            /// This is a list of VisualStudioProjects from a solution.
            /// </summary>
            public IList<string> VisualStudioProjects
            {
                get { return vistualStudioProjects; }
                set { vistualStudioProjects = value; }
            } 
            #endregion

        #endregion 
        
    }
    #endregion
    
}