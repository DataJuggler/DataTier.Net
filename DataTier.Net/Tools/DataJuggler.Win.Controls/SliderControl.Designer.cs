namespace DataJuggler.Win.Controls
{
    partial class SliderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            this.SuspendLayout();
            // 
            // Slider
            // 
            this.Slider.BackColor = System.Drawing.Color.GhostWhite;
            this.Slider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Slider.Location = new System.Drawing.Point(0, 0);
            this.Slider.Maximum = 5;
            this.Slider.Minimum = 1;
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(278, 30);
            this.Slider.TabIndex = 0;
            this.Slider.Value = 1;
            this.Slider.ValueChanged += new System.EventHandler(this.Slider_ValueChanged);
            // 
            // SliderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Slider);
            this.DoubleBuffered = true;
            this.Name = "SliderControl";
            this.Size = new System.Drawing.Size(278, 30);
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar Slider;
    }
}
