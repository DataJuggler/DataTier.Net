

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class OrderByFieldControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class OrderByFieldControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
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
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.MoveLeftButton = new System.Windows.Forms.PictureBox();
            this.BottomMarginPanel2 = new System.Windows.Forms.Panel();
            this.TopMarginPanel2 = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.MoveRightButton = new System.Windows.Forms.PictureBox();
            this.BottomMarginPanel3 = new System.Windows.Forms.Panel();
            this.TopMarginPanel3 = new System.Windows.Forms.Panel();
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.FieldNameLabel = new System.Windows.Forms.Label();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OrderByDescendingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftMarginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveLeftButton)).BeginInit();
            this.RightMarginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveRightButton)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.Controls.Add(this.MoveLeftButton);
            this.LeftMarginPanel.Controls.Add(this.BottomMarginPanel2);
            this.LeftMarginPanel.Controls.Add(this.TopMarginPanel2);
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(20, 60);
            this.LeftMarginPanel.TabIndex = 1;
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.BackgroundImage = global::DataTierClient.Properties.Resources.MoveLeft;
            this.MoveLeftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveLeftButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveLeftButton.Location = new System.Drawing.Point(0, 16);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(20, 28);
            this.MoveLeftButton.TabIndex = 6;
            this.MoveLeftButton.TabStop = false;
            this.MoveLeftButton.Visible = false;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            this.MoveLeftButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MoveLeftButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // BottomMarginPanel2
            // 
            this.BottomMarginPanel2.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel2.Location = new System.Drawing.Point(0, 44);
            this.BottomMarginPanel2.Name = "BottomMarginPanel2";
            this.BottomMarginPanel2.Size = new System.Drawing.Size(20, 16);
            this.BottomMarginPanel2.TabIndex = 5;
            // 
            // TopMarginPanel2
            // 
            this.TopMarginPanel2.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel2.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel2.Name = "TopMarginPanel2";
            this.TopMarginPanel2.Size = new System.Drawing.Size(20, 16);
            this.TopMarginPanel2.TabIndex = 4;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.Controls.Add(this.MoveRightButton);
            this.RightMarginPanel.Controls.Add(this.BottomMarginPanel3);
            this.RightMarginPanel.Controls.Add(this.TopMarginPanel3);
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(148, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(20, 60);
            this.RightMarginPanel.TabIndex = 2;
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.BackgroundImage = global::DataTierClient.Properties.Resources.MoveRight;
            this.MoveRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveRightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveRightButton.Location = new System.Drawing.Point(0, 16);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(20, 28);
            this.MoveRightButton.TabIndex = 7;
            this.MoveRightButton.TabStop = false;
            this.MoveRightButton.Visible = false;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            this.MoveRightButton.MouseEnter += new System.EventHandler(this.MoveRightButton_MouseEnter);
            this.MoveRightButton.MouseLeave += new System.EventHandler(this.MoveRightButton_MouseLeave);
            // 
            // BottomMarginPanel3
            // 
            this.BottomMarginPanel3.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel3.Location = new System.Drawing.Point(0, 44);
            this.BottomMarginPanel3.Name = "BottomMarginPanel3";
            this.BottomMarginPanel3.Size = new System.Drawing.Size(20, 16);
            this.BottomMarginPanel3.TabIndex = 6;
            // 
            // TopMarginPanel3
            // 
            this.TopMarginPanel3.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel3.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel3.Name = "TopMarginPanel3";
            this.TopMarginPanel3.Size = new System.Drawing.Size(20, 16);
            this.TopMarginPanel3.TabIndex = 5;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(20, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(128, 8);
            this.TopMarginPanel.TabIndex = 3;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(20, 52);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(128, 8);
            this.BottomMarginPanel.TabIndex = 4;
            // 
            // MainPanel
            // 
            this.MainPanel.BackgroundImage = global::DataTierClient.Properties.Resources.JackIsADullBoyGray;
            this.MainPanel.Controls.Add(this.FieldNameLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(20, 8);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(128, 44);
            this.MainPanel.TabIndex = 5;
            // 
            // FieldNameLabel
            // 
            this.FieldNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.FieldNameLabel.ContextMenuStrip = this.ContextMenu;
            this.FieldNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldNameLabel.ForeColor = System.Drawing.Color.Black;
            this.FieldNameLabel.Location = new System.Drawing.Point(0, 0);
            this.FieldNameLabel.Name = "FieldNameLabel";
            this.FieldNameLabel.Size = new System.Drawing.Size(128, 44);
            this.FieldNameLabel.TabIndex = 6;
            this.FieldNameLabel.Text = "Field Name";
            this.FieldNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FieldNameLabel.Click += new System.EventHandler(this.FieldNameLabel_Click);
            this.FieldNameLabel.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FieldNameLabel.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Enabled = false;
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderByDescendingMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(247, 26);
            // 
            // OrderByDescendingMenuItem
            // 
            this.OrderByDescendingMenuItem.Enabled = false;
            this.OrderByDescendingMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByDescendingMenuItem.Name = "OrderByDescendingMenuItem";
            this.OrderByDescendingMenuItem.Size = new System.Drawing.Size(246, 22);
            this.OrderByDescendingMenuItem.Text = "Order By Descending";
            this.OrderByDescendingMenuItem.Click += new System.EventHandler(this.OrderByDescendingMenuItem_Click);
            // 
            // OrderByFieldControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderByFieldControl";
            this.Size = new System.Drawing.Size(168, 60);
            this.LeftMarginPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MoveLeftButton)).EndInit();
            this.RightMarginPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MoveRightButton)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.PictureBox MoveLeftButton;
        private System.Windows.Forms.Panel BottomMarginPanel2;
        private System.Windows.Forms.Panel TopMarginPanel2;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.PictureBox MoveRightButton;
        private System.Windows.Forms.Panel BottomMarginPanel3;
        private System.Windows.Forms.Panel TopMarginPanel3;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label FieldNameLabel;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OrderByDescendingMenuItem;
    }
    #endregion

}
