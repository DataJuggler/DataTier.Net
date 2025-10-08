

#region using statements


#endregion

namespace DataJuggler.Win.Controls
{

    #region class TabButton
    /// <summary>
    /// This class represents a TabButton
    /// </summary>
    partial class TabButton
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel BottomMarginPanel;
        private System.Windows.Forms.Label Label;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabButton));
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(200, 12);
            this.TopMarginPanel.TabIndex = 0;
            this.TopMarginPanel.Click += new System.EventHandler(this.TabButton_Click);
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(0, 36);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(200, 4);
            this.BottomMarginPanel.TabIndex = 1;
            this.BottomMarginPanel.Click += new System.EventHandler(this.TabButton_Click);
            // 
            // Label
            // 
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Font = new System.Drawing.Font("Verdana", 13F);
            this.Label.Location = new System.Drawing.Point(0, 12);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(200, 24);
            this.Label.TabIndex = 2;
            this.Label.Text = "Button";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label.Click += new System.EventHandler(this.TabButton_Click);
            this.Label.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Label.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // TabButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Label);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.DoubleBuffered = true;
            this.Name = "TabButton";
            this.Size = new System.Drawing.Size(200, 40);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
