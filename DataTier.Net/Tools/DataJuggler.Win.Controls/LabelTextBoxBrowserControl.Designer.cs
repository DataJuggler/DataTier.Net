

#region using statements


#endregion

namespace DataJuggler.Win.Controls
{

    #region class LabelTextBoxBrowserControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class LabelTextBoxBrowserControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Panel TextBoxTopMarginPanel;
        private System.Windows.Forms.Panel TextBoxBottomMarginPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel LabelRightMargin;
        private System.Windows.Forms.Panel LabelTopMarginPanel;
        private System.Windows.Forms.Panel LabelBottomMarginPanel;

        // exposing the Label and TextBox
        public System.Windows.Forms.Label Label;
        public System.Windows.Forms.TextBox TextBox;
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.TextBoxTopMarginPanel = new System.Windows.Forms.Panel();
            this.TextBoxBottomMarginPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Label = new System.Windows.Forms.Label();
            this.LabelRightMargin = new System.Windows.Forms.Panel();
            this.LabelTopMarginPanel = new System.Windows.Forms.Panel();
            this.LabelBottomMarginPanel = new System.Windows.Forms.Panel();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.BackgroundImage = global::DataJuggler.Win.Controls.Properties.Resources.DarkButton;
            this.BrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BrowseButton.Location = new System.Drawing.Point(352, 0);
            this.BrowseButton.MaximumSize = new System.Drawing.Size(48, 32);
            this.BrowseButton.MinimumSize = new System.Drawing.Size(48, 32);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(48, 32);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.BrowseButton.MouseEnter += new System.EventHandler(this.BrowseButton_MouseEnter);
            this.BrowseButton.MouseLeave += new System.EventHandler(this.BrowseButton_MouseLeave);
            // 
            // TextBoxTopMarginPanel
            // 
            this.TextBoxTopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxTopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxTopMarginPanel.Name = "TextBoxTopMarginPanel";
            this.TextBoxTopMarginPanel.Size = new System.Drawing.Size(352, 0);
            this.TextBoxTopMarginPanel.TabIndex = 20;
            // 
            // TextBoxBottomMarginPanel
            // 
            this.TextBoxBottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBoxBottomMarginPanel.Location = new System.Drawing.Point(0, 32);
            this.TextBoxBottomMarginPanel.Name = "TextBoxBottomMarginPanel";
            this.TextBoxBottomMarginPanel.Size = new System.Drawing.Size(352, 0);
            this.TextBoxBottomMarginPanel.TabIndex = 21;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.Label);
            this.LeftPanel.Controls.Add(this.LabelRightMargin);
            this.LeftPanel.Controls.Add(this.LabelTopMarginPanel);
            this.LeftPanel.Controls.Add(this.LabelBottomMarginPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(160, 32);
            this.LeftPanel.TabIndex = 23;
            // 
            // Label
            // 
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(158, 32);
            this.Label.TabIndex = 18;
            this.Label.Text = "[LabelText]";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelRightMargin
            // 
            this.LabelRightMargin.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelRightMargin.Location = new System.Drawing.Point(158, 0);
            this.LabelRightMargin.Name = "LabelRightMargin";
            this.LabelRightMargin.Size = new System.Drawing.Size(2, 32);
            this.LabelRightMargin.TabIndex = 17;
            // 
            // LabelTopMarginPanel
            // 
            this.LabelTopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelTopMarginPanel.Name = "LabelTopMarginPanel";
            this.LabelTopMarginPanel.Size = new System.Drawing.Size(160, 0);
            this.LabelTopMarginPanel.TabIndex = 7;
            // 
            // LabelBottomMarginPanel
            // 
            this.LabelBottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelBottomMarginPanel.Location = new System.Drawing.Point(0, 32);
            this.LabelBottomMarginPanel.Name = "LabelBottomMarginPanel";
            this.LabelBottomMarginPanel.Size = new System.Drawing.Size(160, 0);
            this.LabelBottomMarginPanel.TabIndex = 5;
            // 
            // TextBox
            // 
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.Location = new System.Drawing.Point(160, 0);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(192, 31);
            this.TextBox.TabIndex = 24;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LabelTextBoxBrowserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TextBoxBottomMarginPanel);
            this.Controls.Add(this.TextBoxTopMarginPanel);
            this.Controls.Add(this.BrowseButton);
            this.Name = "LabelTextBoxBrowserControl";
            this.Size = new System.Drawing.Size(400, 32);
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
