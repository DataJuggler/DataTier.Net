

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class HelpControl
    /// <summary>
    /// This is the designer code for the HelpControl control.
    /// </summary>
    partial class HelpControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Label HelpTopicLabel;
        private System.Windows.Forms.RichTextBox HelpTopicText;
        private System.Windows.Forms.Panel TextImageSeperator;
        private System.Windows.Forms.Panel ImagePanel;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpControl));
                this.TopMarginPanel = new System.Windows.Forms.Panel();
                this.BottomMarginPanel = new System.Windows.Forms.Panel();
                this.LeftMarginPanel = new System.Windows.Forms.Panel();
                this.RightMarginPanel = new System.Windows.Forms.Panel();
                this.HelpTopicLabel = new System.Windows.Forms.Label();
                this.HelpTopicText = new System.Windows.Forms.RichTextBox();
                this.TextImageSeperator = new System.Windows.Forms.Panel();
                this.ImagePanel = new System.Windows.Forms.Panel();
                this.SuspendLayout();
                // 
                // TopMarginPanel
                // 
                this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
                this.TopMarginPanel.Location = new System.Drawing.Point(0, 0);
                this.TopMarginPanel.Name = "TopMarginPanel";
                this.TopMarginPanel.Size = new System.Drawing.Size(632, 16);
                this.TopMarginPanel.TabIndex = 1;
                // 
                // BottomMarginPanel
                // 
                this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.BottomMarginPanel.Location = new System.Drawing.Point(0, 568);
                this.BottomMarginPanel.Name = "BottomMarginPanel";
                this.BottomMarginPanel.Size = new System.Drawing.Size(632, 16);
                this.BottomMarginPanel.TabIndex = 4;
                // 
                // LeftMarginPanel
                // 
                this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
                this.LeftMarginPanel.Location = new System.Drawing.Point(0, 16);
                this.LeftMarginPanel.Name = "LeftMarginPanel";
                this.LeftMarginPanel.Size = new System.Drawing.Size(16, 552);
                this.LeftMarginPanel.TabIndex = 5;
                // 
                // RightMarginPanel
                // 
                this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
                this.RightMarginPanel.Location = new System.Drawing.Point(616, 16);
                this.RightMarginPanel.Name = "RightMarginPanel";
                this.RightMarginPanel.Size = new System.Drawing.Size(16, 552);
                this.RightMarginPanel.TabIndex = 6;
                // 
                // HelpTopicLabel
                // 
                this.HelpTopicLabel.Dock = System.Windows.Forms.DockStyle.Top;
                this.HelpTopicLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.HelpTopicLabel.ForeColor = System.Drawing.Color.Firebrick;
                this.HelpTopicLabel.Location = new System.Drawing.Point(16, 16);
                this.HelpTopicLabel.Name = "HelpTopicLabel";
                this.HelpTopicLabel.Size = new System.Drawing.Size(600, 35);
                this.HelpTopicLabel.TabIndex = 7;
                this.HelpTopicLabel.Text = "Project Folder Help";
                // 
                // HelpTopicText
                // 
                this.HelpTopicText.Dock = System.Windows.Forms.DockStyle.Top;
                this.HelpTopicText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.HelpTopicText.Location = new System.Drawing.Point(16, 51);
                this.HelpTopicText.Name = "HelpTopicText";
                this.HelpTopicText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
                this.HelpTopicText.Size = new System.Drawing.Size(600, 200);
                this.HelpTopicText.TabIndex = 9;
                this.HelpTopicText.Text = resources.GetString("HelpTopicText.Text");
                // 
                // TextImageSeperator
                // 
                this.TextImageSeperator.Dock = System.Windows.Forms.DockStyle.Top;
                this.TextImageSeperator.Location = new System.Drawing.Point(16, 251);
                this.TextImageSeperator.Name = "TextImageSeperator";
                this.TextImageSeperator.Size = new System.Drawing.Size(600, 15);
                this.TextImageSeperator.TabIndex = 12;
                // 
                // ImagePanel
                // 
                this.ImagePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImagePanel.BackgroundImage")));
                this.ImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ImagePanel.Location = new System.Drawing.Point(16, 266);
                this.ImagePanel.Name = "ImagePanel";
                this.ImagePanel.Size = new System.Drawing.Size(600, 302);
                this.ImagePanel.TabIndex = 13;
                // 
                // HelpControl
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.Linen;
                this.Controls.Add(this.ImagePanel);
                this.Controls.Add(this.TextImageSeperator);
                this.Controls.Add(this.HelpTopicText);
                this.Controls.Add(this.HelpTopicLabel);
                this.Controls.Add(this.RightMarginPanel);
                this.Controls.Add(this.LeftMarginPanel);
                this.Controls.Add(this.BottomMarginPanel);
                this.Controls.Add(this.TopMarginPanel);
                this.Name = "HelpControl";
                this.Size = new System.Drawing.Size(632, 584);
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
