
#region using statements

#endregion

namespace DataTierClient.Controls
{

    #region class VisualStudioProjectUpdateControl
    /// <summary>
    /// This is the designer code for the VisualStudioProjectUpdateControl control.
    /// </summary>
    partial class VisualStudioProjectUpdateControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox SolutionTextBox;
        private System.Windows.Forms.Label SolutionLabel;
        private System.Windows.Forms.TextBox ObjectLibraryTextBox;
        private System.Windows.Forms.Label ObjectLibraryLabel;
        private System.Windows.Forms.Label DACLabel;
        private System.Windows.Forms.TextBox DACTextBox;
        private System.Windows.Forms.Label WarningLabel;
        private TabButton SolutionBrowseButton;
        private TabButton DACBrowseButton;
        private TabButton ObjectLibraryBrowseButton;
        private TabButton UpdateProjectButton;
        private TabButton CancelUpdateButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualStudioProjectUpdateControl));
            this.SolutionTextBox = new System.Windows.Forms.TextBox();
            this.SolutionLabel = new System.Windows.Forms.Label();
            this.ObjectLibraryTextBox = new System.Windows.Forms.TextBox();
            this.ObjectLibraryLabel = new System.Windows.Forms.Label();
            this.DACLabel = new System.Windows.Forms.Label();
            this.DACTextBox = new System.Windows.Forms.TextBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.CancelUpdateButton = new DataTierClient.Controls.TabButton();
            this.UpdateProjectButton = new DataTierClient.Controls.TabButton();
            this.ObjectLibraryBrowseButton = new DataTierClient.Controls.TabButton();
            this.DACBrowseButton = new DataTierClient.Controls.TabButton();
            this.SolutionBrowseButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // SolutionTextBox
            // 
            this.SolutionTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolutionTextBox.Location = new System.Drawing.Point(161, 22);
            this.SolutionTextBox.Name = "SolutionTextBox";
            this.SolutionTextBox.Size = new System.Drawing.Size(440, 34);
            this.SolutionTextBox.TabIndex = 101;
            // 
            // SolutionLabel
            // 
            this.SolutionLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolutionLabel.Location = new System.Drawing.Point(21, 27);
            this.SolutionLabel.Name = "SolutionLabel";
            this.SolutionLabel.Size = new System.Drawing.Size(140, 24);
            this.SolutionLabel.TabIndex = 100;
            this.SolutionLabel.Text = "Solution File:";
            this.SolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ObjectLibraryTextBox
            // 
            this.ObjectLibraryTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectLibraryTextBox.Location = new System.Drawing.Point(161, 126);
            this.ObjectLibraryTextBox.Name = "ObjectLibraryTextBox";
            this.ObjectLibraryTextBox.Size = new System.Drawing.Size(440, 34);
            this.ObjectLibraryTextBox.TabIndex = 112;
            // 
            // ObjectLibraryLabel
            // 
            this.ObjectLibraryLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectLibraryLabel.Location = new System.Drawing.Point(21, 131);
            this.ObjectLibraryLabel.Name = "ObjectLibraryLabel";
            this.ObjectLibraryLabel.Size = new System.Drawing.Size(140, 24);
            this.ObjectLibraryLabel.TabIndex = 111;
            this.ObjectLibraryLabel.Text = "Object Library:";
            this.ObjectLibraryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DACLabel
            // 
            this.DACLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DACLabel.Location = new System.Drawing.Point(19, 79);
            this.DACLabel.Name = "DACLabel";
            this.DACLabel.Size = new System.Drawing.Size(140, 24);
            this.DACLabel.TabIndex = 105;
            this.DACLabel.Text = "DAC Project:";
            this.DACLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DACTextBox
            // 
            this.DACTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DACTextBox.Location = new System.Drawing.Point(161, 74);
            this.DACTextBox.Name = "DACTextBox";
            this.DACTextBox.Size = new System.Drawing.Size(440, 34);
            this.DACTextBox.TabIndex = 106;
            // 
            // WarningLabel
            // 
            this.WarningLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel.ForeColor = System.Drawing.Color.LightSlateGray;
            this.WarningLabel.Location = new System.Drawing.Point(53, 173);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(548, 24);
            this.WarningLabel.TabIndex = 114;
            this.WarningLabel.Text = "Your Project Files are Backed Up.\r\n\r\n";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelUpdateButton
            // 
            this.CancelUpdateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelUpdateButton.BackgroundImage")));
            this.CancelUpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelUpdateButton.ButtonNumber = 0;
            this.CancelUpdateButton.ButtonText = "Cancel";
            this.CancelUpdateButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelUpdateButton.Location = new System.Drawing.Point(576, 252);
            this.CancelUpdateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CancelUpdateButton.Name = "CancelUpdateButton";
            this.CancelUpdateButton.NotSelectedImage = null;
            this.CancelUpdateButton.Selected = false;
            this.CancelUpdateButton.SelectedImage = null;
            this.CancelUpdateButton.ShowNotSelectedImageWhenDisabled = true;
            this.CancelUpdateButton.Size = new System.Drawing.Size(80, 32);
            this.CancelUpdateButton.TabIndex = 120;
            // 
            // UpdateProjectButton
            // 
            this.UpdateProjectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpdateProjectButton.BackgroundImage")));
            this.UpdateProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateProjectButton.ButtonNumber = 0;
            this.UpdateProjectButton.ButtonText = "Update Projects";
            this.UpdateProjectButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateProjectButton.Location = new System.Drawing.Point(420, 252);
            this.UpdateProjectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UpdateProjectButton.Name = "UpdateProjectButton";
            this.UpdateProjectButton.NotSelectedImage = null;
            this.UpdateProjectButton.Selected = false;
            this.UpdateProjectButton.SelectedImage = null;
            this.UpdateProjectButton.ShowNotSelectedImageWhenDisabled = true;
            this.UpdateProjectButton.Size = new System.Drawing.Size(148, 32);
            this.UpdateProjectButton.TabIndex = 119;
            // 
            // ObjectLibraryBrowseButton
            // 
            this.ObjectLibraryBrowseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ObjectLibraryBrowseButton.BackgroundImage")));
            this.ObjectLibraryBrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ObjectLibraryBrowseButton.ButtonNumber = 4;
            this.ObjectLibraryBrowseButton.ButtonText = "...";
            this.ObjectLibraryBrowseButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectLibraryBrowseButton.Location = new System.Drawing.Point(600, 127);
            this.ObjectLibraryBrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ObjectLibraryBrowseButton.Name = "ObjectLibraryBrowseButton";
            this.ObjectLibraryBrowseButton.NotSelectedImage = null;
            this.ObjectLibraryBrowseButton.Selected = false;
            this.ObjectLibraryBrowseButton.SelectedImage = null;
            this.ObjectLibraryBrowseButton.ShowNotSelectedImageWhenDisabled = true;
            this.ObjectLibraryBrowseButton.Size = new System.Drawing.Size(40, 32);
            this.ObjectLibraryBrowseButton.TabIndex = 118;
            // 
            // DACBrowseButton
            // 
            this.DACBrowseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DACBrowseButton.BackgroundImage")));
            this.DACBrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DACBrowseButton.ButtonNumber = 3;
            this.DACBrowseButton.ButtonText = "...";
            this.DACBrowseButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DACBrowseButton.Location = new System.Drawing.Point(600, 75);
            this.DACBrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DACBrowseButton.Name = "DACBrowseButton";
            this.DACBrowseButton.NotSelectedImage = null;
            this.DACBrowseButton.Selected = false;
            this.DACBrowseButton.SelectedImage = null;
            this.DACBrowseButton.ShowNotSelectedImageWhenDisabled = true;
            this.DACBrowseButton.Size = new System.Drawing.Size(40, 32);
            this.DACBrowseButton.TabIndex = 117;
            // 
            // SolutionBrowseButton
            // 
            this.SolutionBrowseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SolutionBrowseButton.BackgroundImage")));
            this.SolutionBrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SolutionBrowseButton.ButtonNumber = 1;
            this.SolutionBrowseButton.ButtonText = "...";
            this.SolutionBrowseButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolutionBrowseButton.Location = new System.Drawing.Point(600, 23);
            this.SolutionBrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SolutionBrowseButton.Name = "SolutionBrowseButton";
            this.SolutionBrowseButton.NotSelectedImage = null;
            this.SolutionBrowseButton.Selected = false;
            this.SolutionBrowseButton.SelectedImage = null;
            this.SolutionBrowseButton.ShowNotSelectedImageWhenDisabled = true;
            this.SolutionBrowseButton.Size = new System.Drawing.Size(40, 32);
            this.SolutionBrowseButton.TabIndex = 115;
            // 
            // VisualStudioProjectUpdateControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CancelUpdateButton);
            this.Controls.Add(this.UpdateProjectButton);
            this.Controls.Add(this.ObjectLibraryBrowseButton);
            this.Controls.Add(this.DACBrowseButton);
            this.Controls.Add(this.SolutionBrowseButton);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.ObjectLibraryTextBox);
            this.Controls.Add(this.ObjectLibraryLabel);
            this.Controls.Add(this.DACTextBox);
            this.Controls.Add(this.DACLabel);
            this.Controls.Add(this.SolutionTextBox);
            this.Controls.Add(this.SolutionLabel);
            this.Name = "VisualStudioProjectUpdateControl";
            this.Size = new System.Drawing.Size(680, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}



