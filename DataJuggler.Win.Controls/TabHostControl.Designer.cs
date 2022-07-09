

#region using statements


#endregion

namespace DataJuggler.Win.Controls
{

    #region class TabHostControl
    /// <summary>
    /// This class is used to Host TabButtons
    /// </summary>
    partial class TabHostControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabHostControl));
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.TabButtonHostPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(20, 64);
            this.LeftMarginPanel.TabIndex = 2;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(20, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(1580, 32);
            this.TopMarginPanel.TabIndex = 4;
            // 
            // TabButtonHostPanel
            // 
            this.TabButtonHostPanel.BackColor = System.Drawing.Color.Transparent;
            this.TabButtonHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabButtonHostPanel.Location = new System.Drawing.Point(20, 32);
            this.TabButtonHostPanel.Name = "TabButtonHostPanel";
            this.TabButtonHostPanel.Size = new System.Drawing.Size(1580, 32);
            this.TabButtonHostPanel.TabIndex = 5;
            // 
            // TabHostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.TabButtonHostPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.DoubleBuffered = true;
            this.Name = "TabHostControl";
            this.Size = new System.Drawing.Size(1600, 64);
            this.ResumeLayout(false);

            }
            #endregion

            private System.Windows.Forms.Panel TopMarginPanel;


        #endregion
            private System.Windows.Forms.Panel TabButtonHostPanel;

    }
    #endregion

}
