

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
        private TabButton EnumerationsButton;
        private TabButton BrowseProjectFolderButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.CheckBox BlazorServicesCheckBox;
        private System.Windows.Forms.Label CreateDotNetProject;
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
            this.BlazorServicesCheckBox = new System.Windows.Forms.CheckBox();
            this.CreateDotNetProject = new System.Windows.Forms.Label();
            this.Graph = new System.Windows.Forms.Label();
            this.AutoFillChildFolderInfo = new System.Windows.Forms.PictureBox();
            this.ShowAutoFillHelpButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.BrowseProjectFolderButton = new DataTierClient.Controls.TabButton();
            this.EnumerationsButton = new DataTierClient.Controls.TabButton();
            this.ProjectTypeControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.Version2CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.AutoFillChildFolderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectFolderTextBox
            // 
            this.ProjectFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFolderTextBox.Location = new System.Drawing.Point(210, 60);
            this.ProjectFolderTextBox.Name = "ProjectFolderTextBox";
            this.ProjectFolderTextBox.Size = new System.Drawing.Size(373, 27);
            this.ProjectFolderTextBox.TabIndex = 74;
            this.ProjectFolderTextBox.TextChanged += new System.EventHandler(this.ProjectFolderTextBox_TextChanged);
            // 
            // ProjectNameTextBox
            // 
            this.ProjectNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameTextBox.Location = new System.Drawing.Point(210, 20);
            this.ProjectNameTextBox.Name = "ProjectNameTextBox";
            this.ProjectNameTextBox.Size = new System.Drawing.Size(218, 27);
            this.ProjectNameTextBox.TabIndex = 73;
            this.ProjectNameTextBox.TextChanged += new System.EventHandler(this.ProjectNameTextBox_TextChanged);
            // 
            // ProjectFolderLabel
            // 
            this.ProjectFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFolderLabel.Location = new System.Drawing.Point(32, 63);
            this.ProjectFolderLabel.Name = "ProjectFolderLabel";
            this.ProjectFolderLabel.Size = new System.Drawing.Size(180, 20);
            this.ProjectFolderLabel.TabIndex = 71;
            this.ProjectFolderLabel.Text = "Project Folder:";
            this.ProjectFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameLabel.Location = new System.Drawing.Point(32, 24);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(180, 20);
            this.ProjectNameLabel.TabIndex = 70;
            this.ProjectNameLabel.Text = "Project Name:";
            this.ProjectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AutoFillChildFoldersCheckBox
            // 
            this.AutoFillChildFoldersCheckBox.AutoSize = true;
            this.AutoFillChildFoldersCheckBox.Checked = true;
            this.AutoFillChildFoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillChildFoldersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoFillChildFoldersCheckBox.Location = new System.Drawing.Point(90, 137);
            this.AutoFillChildFoldersCheckBox.Name = "AutoFillChildFoldersCheckBox";
            this.AutoFillChildFoldersCheckBox.Size = new System.Drawing.Size(181, 24);
            this.AutoFillChildFoldersCheckBox.TabIndex = 77;
            this.AutoFillChildFoldersCheckBox.Text = "Auto Fill Child Folders";
            this.AutoFillChildFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // BlazorServicesCheckBox
            // 
            this.BlazorServicesCheckBox.AutoSize = true;
            this.BlazorServicesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlazorServicesCheckBox.Location = new System.Drawing.Point(90, 233);
            this.BlazorServicesCheckBox.Name = "BlazorServicesCheckBox";
            this.BlazorServicesCheckBox.Size = new System.Drawing.Size(195, 24);
            this.BlazorServicesCheckBox.TabIndex = 83;
            this.BlazorServicesCheckBox.Text = "Enable Blazor Features";
            this.BlazorServicesCheckBox.UseVisualStyleBackColor = true;
            this.BlazorServicesCheckBox.Visible = false;
            this.BlazorServicesCheckBox.CheckedChanged += new System.EventHandler(this.BlazorServicesCheckBox_CheckedChanged);
            // 
            // CreateDotNetProject
            // 
            this.CreateDotNetProject.AutoSize = true;
            this.CreateDotNetProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateDotNetProject.Location = new System.Drawing.Point(347, 139);
            this.CreateDotNetProject.Name = "CreateDotNetProject";
            this.CreateDotNetProject.Size = new System.Drawing.Size(240, 20);
            this.CreateDotNetProject.TabIndex = 85;
            this.CreateDotNetProject.Text = "Create DataTier in Project Folder";
            this.CreateDotNetProject.Visible = false;
            this.CreateDotNetProject.Click += new System.EventHandler(this.CreateDotNetProject_Click);
            this.CreateDotNetProject.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CreateDotNetProject.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.Color.MidnightBlue;
            this.Graph.Location = new System.Drawing.Point(347, 162);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(268, 13);
            this.Graph.TabIndex = 86;
            this.Graph.Visible = false;
            // 
            // AutoFillChildFolderInfo
            // 
            this.AutoFillChildFolderInfo.BackgroundImage = global::DataTierClient.Properties.Resources.AutoFill_Child_Folders;
            this.AutoFillChildFolderInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AutoFillChildFolderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoFillChildFolderInfo.Location = new System.Drawing.Point(2048, 19);
            this.AutoFillChildFolderInfo.Name = "AutoFillChildFolderInfo";
            this.AutoFillChildFolderInfo.Size = new System.Drawing.Size(600, 160);
            this.AutoFillChildFolderInfo.TabIndex = 91;
            this.AutoFillChildFolderInfo.TabStop = false;
            this.AutoFillChildFolderInfo.Visible = false;
            this.AutoFillChildFolderInfo.Click += new System.EventHandler(this.AutoFillChildFolderInfo_Click);
            this.AutoFillChildFolderInfo.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.AutoFillChildFolderInfo.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ShowAutoFillHelpButton
            // 
            this.ShowAutoFillHelpButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShowAutoFillHelpButton.BackgroundImage")));
            this.ShowAutoFillHelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowAutoFillHelpButton.FlatAppearance.BorderSize = 0;
            this.ShowAutoFillHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowAutoFillHelpButton.Location = new System.Drawing.Point(285, 132);
            this.ShowAutoFillHelpButton.Name = "ShowAutoFillHelpButton";
            this.ShowAutoFillHelpButton.Size = new System.Drawing.Size(32, 32);
            this.ShowAutoFillHelpButton.TabIndex = 90;
            this.ShowAutoFillHelpButton.UseVisualStyleBackColor = true;
            this.ShowAutoFillHelpButton.Click += new System.EventHandler(this.ShowAutoFillHelpButton_Click);
            this.ShowAutoFillHelpButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ShowAutoFillHelpButton.MouseLeave += new System.EventHandler(this.Button_Leave);
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
            // BrowseProjectFolderButton
            // 
            this.BrowseProjectFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseProjectFolderButton.BackgroundImage")));
            this.BrowseProjectFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseProjectFolderButton.ButtonNumber = 0;
            this.BrowseProjectFolderButton.ButtonText = "...";
            this.BrowseProjectFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // EnumerationsButton
            // 
            this.EnumerationsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnumerationsButton.BackgroundImage")));
            this.EnumerationsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnumerationsButton.ButtonNumber = 0;
            this.EnumerationsButton.ButtonText = "Enumerations";
            this.EnumerationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnumerationsButton.Location = new System.Drawing.Point(430, 19);
            this.EnumerationsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EnumerationsButton.Name = "EnumerationsButton";
            this.EnumerationsButton.NotSelectedImage = null;
            this.EnumerationsButton.Selected = false;
            this.EnumerationsButton.SelectedImage = null;
            this.EnumerationsButton.ShowNotSelectedImageWhenDisabled = true;
            this.EnumerationsButton.Size = new System.Drawing.Size(132, 28);
            this.EnumerationsButton.TabIndex = 79;
            // 
            // ProjectTypeControl
            // 
            this.ProjectTypeControl.BackColor = System.Drawing.Color.Transparent;
            this.ProjectTypeControl.ComboBoxLeftMargin = 1;
            this.ProjectTypeControl.ComboBoxText = "";
            this.ProjectTypeControl.ComoboBoxFont = null;
            this.ProjectTypeControl.Editable = true;
            this.ProjectTypeControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectTypeControl.HideLabel = false;
            this.ProjectTypeControl.LabelBottomMargin = 0;
            this.ProjectTypeControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ProjectTypeControl.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectTypeControl.LabelText = "Project Type:";
            this.ProjectTypeControl.LabelTopMargin = 0;
            this.ProjectTypeControl.LabelWidth = 120;
            this.ProjectTypeControl.List = null;
            this.ProjectTypeControl.Location = new System.Drawing.Point(90, 186);
            this.ProjectTypeControl.Name = "ProjectTypeControl";
            this.ProjectTypeControl.SelectedIndex = -1;
            this.ProjectTypeControl.SelectedIndexListener = null;
            this.ProjectTypeControl.Size = new System.Drawing.Size(360, 28);
            this.ProjectTypeControl.Sorted = false;
            this.ProjectTypeControl.Source = null;
            this.ProjectTypeControl.TabIndex = 92;
            // 
            // Version2CheckBox
            // 
            this.Version2CheckBox.AutoSize = true;
            this.Version2CheckBox.Checked = true;
            this.Version2CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Version2CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version2CheckBox.Location = new System.Drawing.Point(90, 107);
            this.Version2CheckBox.Name = "Version2CheckBox";
            this.Version2CheckBox.Size = new System.Drawing.Size(226, 24);
            this.Version2CheckBox.TabIndex = 93;
            this.Version2CheckBox.Text = "Project Templates Version 2";
            this.Version2CheckBox.UseVisualStyleBackColor = true;
            this.Version2CheckBox.CheckedChanged += new System.EventHandler(this.Version2CheckBox_CheckedChanged);
            // 
            // ProjectEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Version2CheckBox);
            this.Controls.Add(this.ProjectTypeControl);
            this.Controls.Add(this.AutoFillChildFolderInfo);
            this.Controls.Add(this.ShowAutoFillHelpButton);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.CreateDotNetProject);
            this.Controls.Add(this.BlazorServicesCheckBox);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.BrowseProjectFolderButton);
            this.Controls.Add(this.EnumerationsButton);
            this.Controls.Add(this.AutoFillChildFoldersCheckBox);
            this.Controls.Add(this.ProjectFolderTextBox);
            this.Controls.Add(this.ProjectNameTextBox);
            this.Controls.Add(this.ProjectFolderLabel);
            this.Controls.Add(this.ProjectNameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectEditorControl";
            this.Size = new System.Drawing.Size(680, 308);
            ((System.ComponentModel.ISupportInitialize)(this.AutoFillChildFolderInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.Label Graph;
        private System.Windows.Forms.Button ShowAutoFillHelpButton;
        private System.Windows.Forms.PictureBox AutoFillChildFolderInfo;
        private DataJuggler.Win.Controls.LabelComboBoxControl ProjectTypeControl;
        private System.Windows.Forms.CheckBox Version2CheckBox;
    }
    #endregion

}
