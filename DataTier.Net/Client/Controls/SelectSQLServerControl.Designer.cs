

namespace DataTierClient.Controls
{

    #region class SelectSQLServerControl (Designer)
    /// <summary>
    /// This is the designer for the SelectSQLServerControl
    /// </summary>
    partial class SelectSQLServerControl
    {
        
        #region Controls
        internal System.Windows.Forms.Label ServersLabel;
        internal System.Windows.Forms.ListBox ServersListBox;
        internal System.Windows.Forms.Label InfoLabel;
        internal SaveCancelControl SaveCancelControl;
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Component Designer generated code

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
            this.ServersLabel = new System.Windows.Forms.Label();
            this.ServersListBox = new System.Windows.Forms.ListBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.SuspendLayout();
            // 
            // ServersLabel
            // 
            this.ServersLabel.AutoSize = true;
            this.ServersLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServersLabel.Location = new System.Drawing.Point(20, 16);
            this.ServersLabel.Name = "ServersLabel";
            this.ServersLabel.Size = new System.Drawing.Size(85, 27);
            this.ServersLabel.TabIndex = 0;
            this.ServersLabel.Text = "Servers:";
            // 
            // ServersListBox
            // 
            this.ServersListBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServersListBox.FormattingEnabled = true;
            this.ServersListBox.ItemHeight = 26;
            this.ServersListBox.Location = new System.Drawing.Point(23, 40);
            this.ServersListBox.Name = "ServersListBox";
            this.ServersListBox.Size = new System.Drawing.Size(372, 316);
            this.ServersListBox.TabIndex = 1;
            this.ServersListBox.SelectedIndexChanged += new System.EventHandler(this.ServersListBox_SelectedIndexChanged);
            this.ServersListBox.DoubleClick += new System.EventHandler(this.ServersListBox_DoubleClick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Linen;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.InfoLabel.Location = new System.Drawing.Point(17, 359);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(384, 27);
            this.InfoLabel.TabIndex = 2;
            this.InfoLabel.Text = "(Double click on a server name to select)";
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 406);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(420, 48);
            this.SaveCancelControl.TabIndex = 3;
            // 
            // SelectSQLServerControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ServersListBox);
            this.Controls.Add(this.ServersLabel);
            this.Name = "SelectSQLServerControl";
            this.Size = new System.Drawing.Size(420, 454);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            
            #endregion
            
        #endregion
        
    }
    #endregion
    
}


