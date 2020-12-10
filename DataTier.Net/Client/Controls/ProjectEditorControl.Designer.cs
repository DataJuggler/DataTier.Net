

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
        private System.Windows.Forms.CheckBox DotNet5CheckBox;
        private System.Windows.Forms.CheckBox BlazorServicesCheckBox;
        private DataJuggler.Win.Controls.LabelComboBoxControl BindingCallbackOptionControl;
        private System.Windows.Forms.Label CreateDotNet5Project;
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
            this.DotNet5CheckBox = new System.Windows.Forms.CheckBox();
            this.BlazorServicesCheckBox = new System.Windows.Forms.CheckBox();
            this.BindingCallbackOptionControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.CreateDotNet5Project = new System.Windows.Forms.Label();
            this.Graph = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProjectFolderTextBox
            // 
            this.ProjectFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFolderTextBox.Location = new System.Drawing.Point(210, 58);
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
            this.ProjectFolderLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFolderLabel.Location = new System.Drawing.Point(32, 62);
            this.ProjectFolderLabel.Name = "ProjectFolderLabel";
            this.ProjectFolderLabel.Size = new System.Drawing.Size(180, 20);
            this.ProjectFolderLabel.TabIndex = 71;
            this.ProjectFolderLabel.Text = "Project Folder:";
            this.ProjectFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.AutoFillChildFoldersCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoFillChildFoldersCheckBox.Location = new System.Drawing.Point(82, 176);
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
            this.InfoLabel.Location = new System.Drawing.Point(89, 200);
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
            this.HelpButton.Location = new System.Drawing.Point(629, 55);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(32, 32);
            this.HelpButton.TabIndex = 81;
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            this.HelpButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.HelpButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DotNet5CheckBox
            // 
            this.DotNet5CheckBox.AutoSize = true;
            this.DotNet5CheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DotNet5CheckBox.Location = new System.Drawing.Point(82, 106);
            this.DotNet5CheckBox.Name = "DotNet5CheckBox";
            this.DotNet5CheckBox.Size = new System.Drawing.Size(163, 22);
            this.DotNet5CheckBox.TabIndex = 82;
            this.DotNet5CheckBox.Text = "Dot Net 5 Project";
            this.DotNet5CheckBox.UseVisualStyleBackColor = true;
            this.DotNet5CheckBox.CheckedChanged += new System.EventHandler(this.DotNet5CheckBox_CheckedChanged);
            // 
            // BlazorServicesCheckBox
            // 
            this.BlazorServicesCheckBox.AutoSize = true;
            this.BlazorServicesCheckBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlazorServicesCheckBox.Location = new System.Drawing.Point(82, 138);
            this.BlazorServicesCheckBox.Name = "BlazorServicesCheckBox";
            this.BlazorServicesCheckBox.Size = new System.Drawing.Size(213, 22);
            this.BlazorServicesCheckBox.TabIndex = 83;
            this.BlazorServicesCheckBox.Text = "Enable Blazor Features";
            this.BlazorServicesCheckBox.UseVisualStyleBackColor = true;
            this.BlazorServicesCheckBox.Visible = false;
            this.BlazorServicesCheckBox.CheckedChanged += new System.EventHandler(this.BlazorServicesCheckBox_CheckedChanged);
            // 
            // BindingCallbackOptionControl
            // 
            this.BindingCallbackOptionControl.BackColor = System.Drawing.Color.Transparent;
            this.BindingCallbackOptionControl.ComboBoxLeftMargin = 1;
            this.BindingCallbackOptionControl.ComboBoxText = "";
            this.BindingCallbackOptionControl.ComoboBoxFont = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BindingCallbackOptionControl.Editable = true;
            this.BindingCallbackOptionControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BindingCallbackOptionControl.HideLabel = false;
            this.BindingCallbackOptionControl.LabelBottomMargin = 0;
            this.BindingCallbackOptionControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.BindingCallbackOptionControl.LabelFont = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BindingCallbackOptionControl.LabelText = "Bindings:";
            this.BindingCallbackOptionControl.LabelTopMargin = 0;
            this.BindingCallbackOptionControl.LabelWidth = 96;
            this.BindingCallbackOptionControl.List = null;
            this.BindingCallbackOptionControl.Location = new System.Drawing.Point(293, 134);
            this.BindingCallbackOptionControl.Name = "BindingCallbackOptionControl";
            this.BindingCallbackOptionControl.SelectedIndex = -1;
            this.BindingCallbackOptionControl.SelectedIndexListener = null;
            this.BindingCallbackOptionControl.Size = new System.Drawing.Size(329, 28);
            this.BindingCallbackOptionControl.Sorted = false;
            this.BindingCallbackOptionControl.Source = null;
            this.BindingCallbackOptionControl.TabIndex = 84;
            this.BindingCallbackOptionControl.Visible = false;
            // 
            // CreateDotNet5Project
            // 
            this.CreateDotNet5Project.AutoSize = true;
            this.CreateDotNet5Project.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateDotNet5Project.Location = new System.Drawing.Point(347, 108);
            this.CreateDotNet5Project.Name = "CreateDotNet5Project";
            this.CreateDotNet5Project.Size = new System.Drawing.Size(271, 18);
            this.CreateDotNet5Project.TabIndex = 85;
            this.CreateDotNet5Project.Text = "Create DataTier in Project Folder";
            this.CreateDotNet5Project.Visible = false;
            this.CreateDotNet5Project.Click += new System.EventHandler(this.CreateDotNet5Project_Click);
            this.CreateDotNet5Project.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CreateDotNet5Project.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.Color.MidnightBlue;
            this.Graph.Location = new System.Drawing.Point(347, 95);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(0, 13);
            this.Graph.TabIndex = 86;
            this.Graph.Visible = false;
            // 
            // ProjectEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.CreateDotNet5Project);
            this.Controls.Add(this.BindingCallbackOptionControl);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.BlazorServicesCheckBox);
            this.Controls.Add(this.DotNet5CheckBox);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.BrowseProjectFolderButton);
            this.Controls.Add(this.EnumerationsButton);
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

        private System.Windows.Forms.Label Graph;
    }
    #endregion

}
