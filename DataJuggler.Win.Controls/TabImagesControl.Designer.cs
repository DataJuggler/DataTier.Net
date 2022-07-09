

#region using statements


#endregion

namespace DataJuggler.Win.Controls
{

    #region class TabImagesControl
    /// <summary>
    /// This class is used to host the images for the TabButtons.
    /// </summary>
    partial class TabImagesControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox BlueTab;
        private System.Windows.Forms.PictureBox DisabledTab;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabImagesControl));
            this.BlueTab = new System.Windows.Forms.PictureBox();
            this.DisabledTab = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisabledTab)).BeginInit();
            this.SuspendLayout();
            // 
            // BlueTab
            // 
            this.BlueTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BlueTab.BackgroundImage")));
            this.BlueTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BlueTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlueTab.Location = new System.Drawing.Point(0, 0);
            this.BlueTab.Name = "BlueTab";
            this.BlueTab.Size = new System.Drawing.Size(200, 40);
            this.BlueTab.TabIndex = 0;
            this.BlueTab.TabStop = false;
            // 
            // DisabledTab
            // 
            this.DisabledTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DisabledTab.BackgroundImage")));
            this.DisabledTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DisabledTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.DisabledTab.Location = new System.Drawing.Point(0, 40);
            this.DisabledTab.Name = "DisabledTab";
            this.DisabledTab.Size = new System.Drawing.Size(200, 40);
            this.DisabledTab.TabIndex = 1;
            this.DisabledTab.TabStop = false;
            // 
            // TabImagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DisabledTab);
            this.Controls.Add(this.BlueTab);
            this.DoubleBuffered = true;
            this.Name = "TabImagesControl";
            this.Size = new System.Drawing.Size(200, 80);
            ((System.ComponentModel.ISupportInitialize)(this.BlueTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisabledTab)).EndInit();
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
