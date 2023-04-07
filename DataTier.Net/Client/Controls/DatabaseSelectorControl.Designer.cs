

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class DatabaseSelectorControl
    /// <summary>
    /// This is the designer code for the DatabaseSelectorControl control.
    /// </summary>
    partial class DatabaseSelectorControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel BottomFillerPanel;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private SQLDatabaseEditor SqlDatabaseEditor;
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
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.BottomFillerPanel = new System.Windows.Forms.Panel();
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.SqlDatabaseEditor = new DataTierClient.Controls.SQLDatabaseEditor();
            this.SuspendLayout();
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(592, 16);
            this.TopMarginPanel.TabIndex = 5;
            // 
            // BottomFillerPanel
            // 
            this.BottomFillerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomFillerPanel.Location = new System.Drawing.Point(0, 493);
            this.BottomFillerPanel.Name = "BottomFillerPanel";
            this.BottomFillerPanel.Size = new System.Drawing.Size(592, 16);
            this.BottomFillerPanel.TabIndex = 8;
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 16);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 477);
            this.LeftMarginPanel.TabIndex = 9;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(576, 16);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 477);
            this.RightMarginPanel.TabIndex = 10;
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 509);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(592, 40);
            this.SaveCancelControl.TabIndex = 4;
            // 
            // SqlDatabaseEditor
            // 
            this.SqlDatabaseEditor.AuthenticationType = ObjectLibrary.Enumerations.SQLAuthenticationTypeEnum.WindowsAuthentication;
            this.SqlDatabaseEditor.BackColor = System.Drawing.Color.Transparent;
            this.SqlDatabaseEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SqlDatabaseEditor.Location = new System.Drawing.Point(16, 16);
            this.SqlDatabaseEditor.Name = "SqlDatabaseEditor";
            this.SqlDatabaseEditor.Size = new System.Drawing.Size(560, 477);
            this.SqlDatabaseEditor.TabIndex = 14;
            this.SqlDatabaseEditor.Visible = false;
            // 
            // DatabaseSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.SqlDatabaseEditor);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Controls.Add(this.BottomFillerPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.SaveCancelControl);
            this.Name = "DatabaseSelectorControl";
            this.Size = new System.Drawing.Size(592, 549);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
