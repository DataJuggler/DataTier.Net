

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ConfirmRemovalControl
    /// <summary>
    /// This is the designer file for the ConfirmRemovalControl.
    /// </summary>
    partial class ConfirmRemovalControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Panel SeperatorPanel2;
        private System.Windows.Forms.Label ProjectFolderLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SeperatorPanel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.CheckedListBox CodeItemsListBox;
        private System.Windows.Forms.CheckBox DeleteFilesCheckBox;
        private System.Windows.Forms.Panel LeftMarginPanel;
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
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProjectFolderLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SeperatorPanel2 = new System.Windows.Forms.Panel();
            this.SeperatorPanel = new System.Windows.Forms.Panel();
            this.DeleteFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.CodeItemsListBox = new System.Windows.Forms.CheckedListBox();
            this.SeperatorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 552);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(960, 48);
            this.SaveCancelControl.TabIndex = 0;
            // 
            // ProjectFolderLabel
            // 
            this.ProjectFolderLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProjectFolderLabel.Location = new System.Drawing.Point(0, 0);
            this.ProjectFolderLabel.Name = "ProjectFolderLabel";
            this.ProjectFolderLabel.Size = new System.Drawing.Size(960, 24);
            this.ProjectFolderLabel.TabIndex = 8;
            this.ProjectFolderLabel.Text = "Project Folder:";
            this.ProjectFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ProjectFolderLabel, "All file names are the typical name if your project was created from a DataTier.N" +
        "et.ClassLibrary project template.\r\n");
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(960, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "All paths are relative to the project folder.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.label1, "All file names are the typical name if your project was created from a DataTier.N" +
        "et.ClassLibrary project template.\r\n");
            // 
            // SeperatorPanel2
            // 
            this.SeperatorPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SeperatorPanel2.Location = new System.Drawing.Point(0, 536);
            this.SeperatorPanel2.Name = "SeperatorPanel2";
            this.SeperatorPanel2.Size = new System.Drawing.Size(960, 16);
            this.SeperatorPanel2.TabIndex = 7;
            // 
            // SeperatorPanel
            // 
            this.SeperatorPanel.Controls.Add(this.DeleteFilesCheckBox);
            this.SeperatorPanel.Controls.Add(this.LeftMarginPanel);
            this.SeperatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SeperatorPanel.Location = new System.Drawing.Point(0, 48);
            this.SeperatorPanel.Name = "SeperatorPanel";
            this.SeperatorPanel.Size = new System.Drawing.Size(960, 32);
            this.SeperatorPanel.TabIndex = 15;
            // 
            // DeleteFilesCheckBox
            // 
            this.DeleteFilesCheckBox.Checked = true;
            this.DeleteFilesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DeleteFilesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeleteFilesCheckBox.Location = new System.Drawing.Point(4, 0);
            this.DeleteFilesCheckBox.Name = "DeleteFilesCheckBox";
            this.DeleteFilesCheckBox.Size = new System.Drawing.Size(410, 32);
            this.DeleteFilesCheckBox.TabIndex = 2;
            this.DeleteFilesCheckBox.Text = "Delete files after removing from solution.";
            this.DeleteFilesCheckBox.UseVisualStyleBackColor = true;
            this.DeleteFilesCheckBox.Click += new System.EventHandler(this.DeleteFilesCheckBox_Click);
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(4, 32);
            this.LeftMarginPanel.TabIndex = 1;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoLabel.Location = new System.Drawing.Point(0, 508);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(960, 28);
            this.InfoLabel.TabIndex = 19;
            this.InfoLabel.Text = "Uncheck any items you do not wish to remove.";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CodeItemsListBox
            // 
            this.CodeItemsListBox.CheckOnClick = true;
            this.CodeItemsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeItemsListBox.FormattingEnabled = true;
            this.CodeItemsListBox.Location = new System.Drawing.Point(0, 80);
            this.CodeItemsListBox.Name = "CodeItemsListBox";
            this.CodeItemsListBox.Size = new System.Drawing.Size(960, 428);
            this.CodeItemsListBox.TabIndex = 20;
            // 
            // ConfirmRemovalControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.CodeItemsListBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.SeperatorPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProjectFolderLabel);
            this.Controls.Add(this.SeperatorPanel2);
            this.Controls.Add(this.SaveCancelControl);
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ConfirmRemovalControl";
            this.Size = new System.Drawing.Size(960, 600);
            this.SeperatorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}


