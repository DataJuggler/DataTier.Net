namespace DataTierClient.Forms
{
    partial class BlazorServicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlazorServicesForm));
            this.BlazorDataServicesControl = new DataTierClient.Controls.BlazorDataServicesControl();
            this.SuspendLayout();
            // 
            // BlazorDataServicesControl
            // 
            this.BlazorDataServicesControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BlazorDataServicesControl.BackgroundImage")));
            this.BlazorDataServicesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlazorDataServicesControl.Location = new System.Drawing.Point(0, 0);
            this.BlazorDataServicesControl.Name = "BlazorDataServicesControl";
            this.BlazorDataServicesControl.Project = null;
            this.BlazorDataServicesControl.ServicesFolder = null;
            this.BlazorDataServicesControl.Size = new System.Drawing.Size(724, 361);
            this.BlazorDataServicesControl.TabIndex = 0;
            this.BlazorDataServicesControl.Table = null;
            // 
            // BlazorServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 361);
            this.Controls.Add(this.BlazorDataServicesControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BlazorServicesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blazor Data Services";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BlazorDataServicesControl BlazorDataServicesControl;
    }
}