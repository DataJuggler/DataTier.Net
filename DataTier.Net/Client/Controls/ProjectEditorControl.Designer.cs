

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ProjectEditorControl
    /// <summary>
    /// This is the designer code for the ProjectEditorControl control.
    /// </summary>
    partial class ProjectEditorControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox ProjectFolderTextBox;
        private System.Windows.Forms.TextBox ProjectNameTextBox;
        private System.Windows.Forms.Label ProjectFolderLabel;
        private System.Windows.Forms.Label ProjectNameLabel;
        private System.Windows.Forms.CheckBox AutoFillChildFoldersCheckBox;
        private System.Windows.Forms.Label InfoLabel;
        private TabButton EnumerationsButton;
        private TabButton BrowseProjectFolderButton;
        private System.Windows.Forms.Button HelpButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEditorControl));
            this.ProjectFolderTextBox = new System.Windows.Forms.TextBox();
            this.ProjectNameTextBox = new System.Windows.Forms.TextBox();
            this.ProjectFolderLabel = new System.Windows.Forms.Label();
            this.ProjectNameLabel = new System.Windows.Forms.Label();
            this.AutoFillChildFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.EnumerationsButton = new DataTierClient.Controls.TabButton();
            this.BrowseProjectFolderButton = new DataTierClient.Controls.TabButton();
            this.HelpButton = new System.Windows.Forms.Button();
            this.DotNetCoreCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ProjectFolderTextBox
            // 
            this.ProjectFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFolderTextBox.Location = new System.Drawing.Point(218, 60);
            this.ProjectFolderTextBox.Name = "ProjectFolderTextBox";
            this.ProjectFolderTextBox.Size = new System.Drawing.Size(373, 27);
            this.ProjectFolderTextBox.TabIndex = 74;
            this.ProjectFolderTextBox.TextChanged += new System.EventHandler(this.ProjectFolderTextBox_TextChanged);
            // 
            // ProjectNameTextBox
            // 
            this.ProjectNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameTextBox.Location = new System.Drawing.Point(218, 20);
            this.ProjectNameTextBox.Name = "ProjectNameTextBox";
            this.ProjectNameTextBox.Size = new System.Drawing.Size(304, 27);
            this.ProjectNameTextBox.TabIndex = 73;
            this.ProjectNameTextBox.TextChanged += new System.EventHandler(this.ProjectNameTextBox_TextChanged);
            // 
            // ProjectFolderLabel
            // 
            this.ProjectFolderLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFolderLabel.Location = new System.Drawing.Point(20, 64);
            this.ProjectFolderLabel.Name = "ProjectFolderLabel";
            this.ProjectFolderLabel.Size = new System.Drawing.Size(200, 20);
            this.ProjectFolderLabel.TabIndex = 71;
            this.ProjectFolderLabel.Text = "Project Folder:";
            this.ProjectFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameLabel.Location = new System.Drawing.Point(20, 24);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(200, 20);
            this.ProjectNameLabel.TabIndex = 70;
            this.ProjectNameLabel.Text = "Project Name:";
            this.ProjectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AutoFillChildFoldersCheckBox
            // 
            this.AutoFillChildFoldersCheckBox.AutoSize = true;
            this.AutoFillChildFoldersCheckBox.Checked = true;
            this.AutoFillChildFoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillChildFoldersCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoFillChildFoldersCheckBox.Location = new System.Drawing.Point(114, 153);
            this.AutoFillChildFoldersCheckBox.Name = "AutoFillChildFoldersCheckBox";
            this.AutoFillChildFoldersCheckBox.Size = new System.Drawing.Size(199, 22);
            this.AutoFillChildFoldersCheckBox.TabIndex = 77;
            this.AutoFillChildFoldersCheckBox.Text = "Auto Fill Child Folders";
            this.AutoFillChildFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ForeColor = System.Drawing.Color.DimGray;
            this.InfoLabel.Location = new System.Drawing.Point(111, 178);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(459, 96);
            this.InfoLabel.TabIndex = 78;
            this.InfoLabel.Text = resources.GetString("InfoLabel.Text");
            // 
            // EnumerationsButton
            // 
            this.EnumerationsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnumerationsButton.BackgroundImage")));
            this.EnumerationsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnumerationsButton.ButtonNumber = 0;
            this.EnumerationsButton.ButtonText = "Enumerations";
            this.EnumerationsButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnumerationsButton.Location = new System.Drawing.Point(529, 19);
            this.EnumerationsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnumerationsButton.Name = "EnumerationsButton";
            this.EnumerationsButton.NotSelectedImage = null;
            this.EnumerationsButton.Selected = false;
            this.EnumerationsButton.SelectedImage = null;
            this.EnumerationsButton.ShowNotSelectedImageWhenDisabled = true;
            this.EnumerationsButton.Size = new System.Drawing.Size(132, 28);
            this.EnumerationsButton.TabIndex = 79;
            // 
            // BrowseProjectFolderButton
            // 
            this.BrowseProjectFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseProjectFolderButton.BackgroundImage")));
            this.BrowseProjectFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseProjectFolderButton.ButtonNumber = 0;
            this.BrowseProjectFolderButton.ButtonText = "...";
            this.BrowseProjectFolderButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseProjectFolderButton.Location = new System.Drawing.Point(582, 59);
            this.BrowseProjectFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseProjectFolderButton.Name = "BrowseProjectFolderButton";
            this.BrowseProjectFolderButton.NotSelectedImage = null;
            this.BrowseProjectFolderButton.Selected = false;
            this.BrowseProjectFolderButton.SelectedImage = null;
            this.BrowseProjectFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseProjectFolderButton.Size = new System.Drawing.Size(40, 28);
            this.BrowseProjectFolderButton.TabIndex = 80;
            // 
            // HelpButton
            // 
            this.HelpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HelpButton.BackgroundImage")));
            this.HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Location = new System.Drawing.Point(629, 57);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(32, 32);
            this.HelpButton.TabIndex = 81;
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            this.HelpButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.HelpButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DotNetCoreCheckBox
            // 
            this.DotNetCoreCheckBox.AutoSize = true;
            this.DotNetCoreCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DotNetCoreCheckBox.Location = new System.Drawing.Point(114, 112);
            this.DotNetCoreCheckBox.Name = "DotNetCoreCheckBox";
            this.DotNetCoreCheckBox.Size = new System.Drawing.Size(192, 22);
            this.DotNetCoreCheckBox.TabIndex = 82;
            this.DotNetCoreCheckBox.Text = "Dot Net Core Project";
            this.DotNetCoreCheckBox.UseVisualStyleBackColor = true;
            this.DotNetCoreCheckBox.CheckedChanged += new System.EventHandler(this.DotNetCoreCheckBox_CheckedChanged);
            // 
            // ProjectEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DotNetCoreCheckBox);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.BrowseProjectFolderButton);
            this.Controls.Add(this.EnumerationsButton);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.AutoFillChildFoldersCheckBox);
            this.Controls.Add(this.ProjectFolderTextBox);
            this.Controls.Add(this.ProjectNameTextBox);
            this.Controls.Add(this.ProjectFolderLabel);
            this.Controls.Add(this.ProjectNameLabel);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectEditorControl";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.CheckBox DotNetCoreCheckBox;
    }
    #endregion

}
