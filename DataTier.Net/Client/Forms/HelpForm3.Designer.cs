
namespace DataTierClient.Forms
{
    partial class HelpForm3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm3));
            this.HelpImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HelpImage)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpImage
            // 
            this.HelpImage.BackgroundImage = global::DataTierClient.Properties.Resources.HelpImages3;
            this.HelpImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpImage.Location = new System.Drawing.Point(0, 0);
            this.HelpImage.Name = "HelpImage";
            this.HelpImage.Size = new System.Drawing.Size(944, 762);
            this.HelpImage.TabIndex = 1;
            this.HelpImage.TabStop = false;
            // 
            // HelpForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 762);
            this.Controls.Add(this.HelpImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Structure of a DataTier.Net Project";
            ((System.ComponentModel.ISupportInitialize)(this.HelpImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox HelpImage;
    }
}