

#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class ProjectChooserForm
    /// <summary>
    /// This is the designer code for the ProjectChooserForm.
    /// </summary>
    partial class ProjectChooserForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox ProjectsListBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label DeleteInfoLabel;
        private Controls.TabButton CancelChooseProjectButton;
        #endregion
        
        #region Methods
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectChooserForm));
            this.ProjectsListBox = new System.Windows.Forms.ListBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.DeleteInfoLabel = new System.Windows.Forms.Label();
            this.CancelChooseProjectButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // ProjectsListBox
            // 
            this.ProjectsListBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectsListBox.FormattingEnabled = true;
            this.ProjectsListBox.ItemHeight = 15;
            this.ProjectsListBox.Location = new System.Drawing.Point(19, 28);
            this.ProjectsListBox.Name = "ProjectsListBox";
            this.ProjectsListBox.Size = new System.Drawing.Size(292, 214);
            this.ProjectsListBox.TabIndex = 0;
            this.ProjectsListBox.DoubleClick += new System.EventHandler(this.ProjectsListBox_DoubleClick);
            this.ProjectsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectsListBox_KeyDown);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(19, 10);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(230, 15);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "Double click on a project to select.";
            // 
            // DeleteInfoLabel
            // 
            this.DeleteInfoLabel.AutoSize = true;
            this.DeleteInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.DeleteInfoLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteInfoLabel.Location = new System.Drawing.Point(48, 249);
            this.DeleteInfoLabel.Name = "DeleteInfoLabel";
            this.DeleteInfoLabel.Size = new System.Drawing.Size(235, 15);
            this.DeleteInfoLabel.TabIndex = 3;
            this.DeleteInfoLabel.Text = "(Press \'Delete\' to remove a project)";
            // 
            // CancelChooseProjectButton
            // 
            this.CancelChooseProjectButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.CancelChooseProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelChooseProjectButton.ButtonNumber = 0;
            this.CancelChooseProjectButton.ButtonText = "Cancel";
            this.CancelChooseProjectButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelChooseProjectButton.Location = new System.Drawing.Point(238, 296);
            this.CancelChooseProjectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CancelChooseProjectButton.Name = "CancelChooseProjectButton";
            this.CancelChooseProjectButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.CancelChooseProjectButton.Selected = true;
            this.CancelChooseProjectButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.CancelChooseProjectButton.ShowNotSelectedImageWhenDisabled = true;
            this.CancelChooseProjectButton.Size = new System.Drawing.Size(80, 28);
            this.CancelChooseProjectButton.TabIndex = 4;
            // 
            // ProjectChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(331, 336);
            this.Controls.Add(this.CancelChooseProjectButton);
            this.Controls.Add(this.DeleteInfoLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ProjectsListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectChooserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Project";
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
