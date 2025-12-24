

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class DisplayMessageControl
    /// <summary>
    /// This class is the designer for the DisplayMessageControl
    /// </summary>
    partial class DisplayMessageControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel ButtonLeftMarginPanel;
        private System.Windows.Forms.Label MessageLabel;
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
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.ButtonLeftMarginPanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(16, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(476, 16);
            this.TopMarginPanel.TabIndex = 101;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(492, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 172);
            this.RightMarginPanel.TabIndex = 100;
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 172);
            this.LeftMarginPanel.TabIndex = 99;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(16, 156);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(476, 16);
            this.BottomMarginPanel.TabIndex = 106;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.OKButton);
            this.ButtonPanel.Controls.Add(this.ButtonLeftMarginPanel);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(16, 116);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(476, 40);
            this.ButtonPanel.TabIndex = 107;
            // 
            // OKButton
            // 
            this.OKButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OKButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.OKButton.Location = new System.Drawing.Point(200, 0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(72, 40);
            this.OKButton.TabIndex = 109;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            this.OKButton.MouseEnter += new System.EventHandler(this.OKButton_MouseEnter);
            this.OKButton.MouseLeave += new System.EventHandler(this.OKButton_MouseLeave);
            // 
            // ButtonLeftMarginPanel
            // 
            this.ButtonLeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonLeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonLeftMarginPanel.Name = "ButtonLeftMarginPanel";
            this.ButtonLeftMarginPanel.Size = new System.Drawing.Size(200, 40);
            this.ButtonLeftMarginPanel.TabIndex = 107;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageLabel.Font = new System.Drawing.Font("Calibri", 16F);
            this.MessageLabel.Location = new System.Drawing.Point(16, 16);
            this.MessageLabel.MaximumSize = new System.Drawing.Size(476, 92);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(476, 92);
            this.MessageLabel.TabIndex = 109;
            this.MessageLabel.Text = "Oops. Something went wrong. It is recommended you try again, as it usually works " +
    "the second time.";
            // 
            // DisplayMessageControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Font = new System.Drawing.Font("Calibri", 16F);
            this.Name = "DisplayMessageControl";
            this.Size = new System.Drawing.Size(508, 172);
            this.Resize += new System.EventHandler(this.DisplayMessageControl_Resize);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}



