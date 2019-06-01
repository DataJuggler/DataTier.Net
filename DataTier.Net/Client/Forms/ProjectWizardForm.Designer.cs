
#region using statements

using DataTierClient.Enumerations;
using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{
    
    #region class ProjectWizardForm
    /// <summary>
    /// This form is the designer for the ProjectWizardForm.
    /// </summary>
    partial class ProjectWizardForm
    {
        
        #region Controls
        internal ProjectWizardControl ProjectWizardControl;
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Windows Form Designer generated code

            #region Dispose(bool disposing)
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            } 
            #endregion

            #region InitializeComponent()
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectWizardForm));
            this.ProjectWizardControl = new DataTierClient.Controls.ProjectWizardControl();
            this.SuspendLayout();
            // 
            // ProjectWizardControl
            // 
            this.ProjectWizardControl.BackColor = System.Drawing.Color.Linen;
            this.ProjectWizardControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjectWizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectWizardControl.InitialSelectedProject = null;
            this.ProjectWizardControl.Location = new System.Drawing.Point(0, 0);
            this.ProjectWizardControl.Name = "ProjectWizardControl";
            this.ProjectWizardControl.ParentMainForm = null;
            this.ProjectWizardControl.SelectedProject = null;
            this.ProjectWizardControl.Size = new System.Drawing.Size(852, 360);
            this.ProjectWizardControl.TabIndex = 0;
            // 
            // ProjectWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 360);
            this.Controls.Add(this.ProjectWizardControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Project";
            this.Activated += new System.EventHandler(this.ProjectWizardForm_Activated);
            this.ResumeLayout(false);

            } 
            #endregion

        #endregion
        
    }
    #endregion
    
}