

#region using statements

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using ObjectLibrary.BusinessObjects;
using DataTierClient.Controls.Images;
using DataTierClient.Controls.Interfaces;

#endregion

namespace DataTierClient.Controls
{

    #region class WizardControlPanel : UserControl
    public partial class WizardControlPanel : UserControl, ITabButtonParent
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 
        /// 'WizardControlPanel' control.
        /// </summary>
        public WizardControlPanel()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region BackButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Go back to the previous control
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BackButton_Click(object sender, EventArgs e)
            {
                // if the parent contact wizard exists
                if(this.ParentProjectWizard != null)
                {
                    // Move to the previous control
                    this.ParentProjectWizard.MovePrev();
                }
            }
            #endregion

            #region DoneButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The done button, finish editing the current contact
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DoneButton_Click(object sender, EventArgs e)
            {
                // if this objects parent form exists
                if(this.ParentForm != null)
                {
                    // close this form.
                    this.ParentForm.Close();
                }
            }
            #endregion

            #region NextButton_Click(object sender, EventArgs e)
            /// <summary>
            /// Advance to the next control in the wizard
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void NextButton_Click(object sender, EventArgs e)
            {
                // if the parent contact wizard exists
                if (this.ParentProjectWizard != null)
                {
                    // Move to the previous control
                    this.ParentProjectWizard.MoveNext();
                }
            }
            #endregion

            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event saves the current project
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                // if the parent project wizard exists
                if(this.HasParentProjectWizard)
                {
                    // if the project validates
                    if(this.ValidateProject())
                    {
                        // Save and close thie form
                        this.ParentProjectWizard.SaveAndClose();
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            /// Perform any Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Set the DockStyle to Botton
                this.Dock = DockStyle.Bottom;
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
                    case "Back":

                        // call the BackButton
                        BackButton_Click(this, null);

                        // required
                        break;

                    case "Next":

                        // call the NextButton_Click
                        NextButton_Click(this, null);

                        // required
                        break;

                    case "Save":

                        // Call the SaveButton_Click event
                        SaveButton_Click(this, null);

                        // required
                        break;

                    case "Done":

                        // Call the DoneButton_Click event
                        DoneButton_Click(this, null);

                        // required
                        break;

                }
            }
            #endregion

            #region ValidateProject()
            /// <summary>
            /// This method validates a project.
            /// </summary>
            /// <returns></returns>
            private bool ValidateProject()
            {
                // initial value
                bool valid = false;
                
                // If the ParentProjectWizard exists
                if(this.HasParentProjectWizard)
                {
                    // Validate the project
                    valid = this.ParentProjectWizard.Validate();
                }
                
                // return value
                return valid;
            }  
            #endregion
        
        #endregion
        
        #region Properties

            #region HasParentProjectWizard
            /// <summary>
            /// Does this object have a parentProjectWizard
            /// </summary>
            public bool HasParentProjectWizard
            {
                get
                {
                    // initial value
                    bool hasParentProjectWizard = (this.ParentProjectWizard != null);
                    
                    // return value
                    return hasParentProjectWizard;
                }
            } 
            #endregion
            
            #region ParentProjectWizard
            /// <summary>
            /// The parent of this control
            /// </summary>
            public ProjectWizardControl ParentProjectWizard
            {
                get
                {
                    // initial value
                    ProjectWizardControl parentProjectWizard = this.Parent as ProjectWizardControl;

                    // return value
                    return parentProjectWizard;
                }
            }
            #endregion
            
            #region SelectedProject
            /// <summary>
            /// The selected project from the 
            /// ParentProjectWizard control.
            /// </summary>
            public Project SelectedProject
            {
                get
                {
                    // initial value
                    Project project = null;
                    
                    // if this object has parent project wizard
                    if(this.HasParentProjectWizard)
                    {
                        // set project from the ParentProjectWizard
                        project = this.ParentProjectWizard.SelectedProject;
                    }
                    
                    // return value
                    return project;
                }
            }
            #endregion

        #endregion

    }
    #endregion
    
}


