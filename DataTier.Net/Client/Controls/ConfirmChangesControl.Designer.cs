

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ConfirmChangesControl
    /// <summary>
    /// This is the designer file for the ConfirmChangesControl.
    /// </summary>
    partial class ConfirmChangesControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label ProjectFolderLabel;
        private System.Windows.Forms.Label ProjectPathInfoLabel;
        private System.Windows.Forms.Panel SeperatorPanel;
        private System.Windows.Forms.CheckedListBox CodeItemsListBox;
        private System.Windows.Forms.Button ConfirmUpdateButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.ListView StatusListBox;
        private System.Windows.Forms.Panel SeperatorPanel2;
        private System.Windows.Forms.ImageList Images;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmChangesControl));
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProjectFolderLabel = new System.Windows.Forms.Label();
            this.ProjectPathInfoLabel = new System.Windows.Forms.Label();
            this.SeperatorPanel = new System.Windows.Forms.Panel();
            this.CodeItemsListBox = new System.Windows.Forms.CheckedListBox();
            this.ConfirmUpdateButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.StatusListBox = new System.Windows.Forms.ListView();
            this.Images = new System.Windows.Forms.ImageList(this.components);
            this.SeperatorPanel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 560);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(1080, 40);
            this.SaveCancelControl.TabIndex = 0;
            // 
            // ProjectFolderLabel
            // 
            this.ProjectFolderLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProjectFolderLabel.Location = new System.Drawing.Point(0, 0);
            this.ProjectFolderLabel.Name = "ProjectFolderLabel";
            this.ProjectFolderLabel.Size = new System.Drawing.Size(1080, 24);
            this.ProjectFolderLabel.TabIndex = 8;
            this.ProjectFolderLabel.Text = "Project Folder:";
            this.ProjectFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ProjectFolderLabel, "All file names are the typical name if your project was created from a DataTier.N" +
        "et.ClassLibrary project template.\r\n");
            // 
            // ProjectPathInfoLabel
            // 
            this.ProjectPathInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProjectPathInfoLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectPathInfoLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ProjectPathInfoLabel.Location = new System.Drawing.Point(0, 24);
            this.ProjectPathInfoLabel.Name = "ProjectPathInfoLabel";
            this.ProjectPathInfoLabel.Size = new System.Drawing.Size(1080, 20);
            this.ProjectPathInfoLabel.TabIndex = 10;
            this.ProjectPathInfoLabel.Text = "All paths are relative to the project folder.";
            this.ProjectPathInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ProjectPathInfoLabel, "All file names are the typical name if your project was created from a DataTier.N" +
        "et.ClassLibrary project template.\r\n");
            // 
            // SeperatorPanel
            // 
            this.SeperatorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SeperatorPanel.Location = new System.Drawing.Point(0, 544);
            this.SeperatorPanel.Name = "SeperatorPanel";
            this.SeperatorPanel.Size = new System.Drawing.Size(1080, 16);
            this.SeperatorPanel.TabIndex = 7;
            // 
            // CodeItemsListBox
            // 
            this.CodeItemsListBox.CheckOnClick = true;
            this.CodeItemsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CodeItemsListBox.Enabled = false;
            this.CodeItemsListBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeItemsListBox.FormattingEnabled = true;
            this.CodeItemsListBox.Location = new System.Drawing.Point(0, 44);
            this.CodeItemsListBox.Name = "CodeItemsListBox";
            this.CodeItemsListBox.Size = new System.Drawing.Size(1080, 151);
            this.CodeItemsListBox.TabIndex = 20;
            // 
            // ConfirmUpdateButton
            // 
            this.ConfirmUpdateButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.ConfirmUpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfirmUpdateButton.FlatAppearance.BorderSize = 0;
            this.ConfirmUpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConfirmUpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConfirmUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmUpdateButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmUpdateButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ConfirmUpdateButton.Location = new System.Drawing.Point(448, 220);
            this.ConfirmUpdateButton.Name = "ConfirmUpdateButton";
            this.ConfirmUpdateButton.Size = new System.Drawing.Size(184, 40);
            this.ConfirmUpdateButton.TabIndex = 97;
            this.ConfirmUpdateButton.Text = "Confirm Update";
            this.ConfirmUpdateButton.UseVisualStyleBackColor = true;
            this.ConfirmUpdateButton.Click += new System.EventHandler(this.ConfirmUpdateButton_Click);
            this.ConfirmUpdateButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ConfirmUpdateButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.StatusListBox);
            this.MainPanel.Controls.Add(this.SeperatorPanel2);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.RightMarginPanel);
            this.MainPanel.Controls.Add(this.LeftMarginPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel.Location = new System.Drawing.Point(0, 264);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1080, 280);
            this.MainPanel.TabIndex = 98;
            // 
            // StatusListBox
            // 
            this.StatusListBox.AutoArrange = false;
            this.StatusListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusListBox.FullRowSelect = true;
            this.StatusListBox.Location = new System.Drawing.Point(16, 24);
            this.StatusListBox.Name = "StatusListBox";
            this.StatusListBox.Size = new System.Drawing.Size(1048, 172);
            this.StatusListBox.SmallImageList = this.Images;
            this.StatusListBox.TabIndex = 60;
            this.StatusListBox.UseCompatibleStateImageBehavior = false;
            this.StatusListBox.View = System.Windows.Forms.View.List;
            // 
            // Images
            // 
            this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
            this.Images.TransparentColor = System.Drawing.Color.Transparent;
            this.Images.Images.SetKeyName(0, "success.ico");
            this.Images.Images.SetKeyName(1, "Failed.ico");
            // 
            // SeperatorPanel2
            // 
            this.SeperatorPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SeperatorPanel2.Location = new System.Drawing.Point(16, 196);
            this.SeperatorPanel2.Name = "SeperatorPanel2";
            this.SeperatorPanel2.Size = new System.Drawing.Size(1048, 84);
            this.SeperatorPanel2.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(16, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1048, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "Status:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(1064, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 280);
            this.RightMarginPanel.TabIndex = 9;
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 280);
            this.LeftMarginPanel.TabIndex = 8;
            // 
            // ConfirmChangesControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ConfirmUpdateButton);
            this.Controls.Add(this.CodeItemsListBox);
            this.Controls.Add(this.ProjectPathInfoLabel);
            this.Controls.Add(this.ProjectFolderLabel);
            this.Controls.Add(this.SeperatorPanel);
            this.Controls.Add(this.SaveCancelControl);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ConfirmChangesControl";
            this.Size = new System.Drawing.Size(1080, 600);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
